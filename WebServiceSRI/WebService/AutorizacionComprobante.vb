Imports System.Xml

Public Class AutorizacionComprobante

#Region "VARIABLES"

    Private autorizacionesValue As New List(Of Autorizacion)
    Private claveAccesoConsultadaValue As String = String.Empty
    Private autorizacionValue As Autorizacion = Nothing
    Private isAutorizadoValue As Boolean
    Private soapStringValue As String = String.Empty
    Private isPendienteValue As Boolean
    Private xmlRespuesta As XmlNode
    'Private strRespuestaSOA As String = ""

#End Region

#Region "PROPERTIES"

    Public ReadOnly Property IsPendiente() As Boolean
        Get
            Return isPendienteValue
        End Get
    End Property

    Public ReadOnly Property SoapString() As String
        Get
            Return soapStringValue
        End Get
    End Property

    Public ReadOnly Property IsAutorizado() As Boolean
        Get
            Return isAutorizadoValue
        End Get
    End Property

    Public ReadOnly Property Autorizacion() As Autorizacion
        Get
            If autorizacionValue IsNot Nothing Then
                Return autorizacionValue
            ElseIf autorizacionesValue.Count > 0 Then
                Return autorizacionesValue(0)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property NumeroComprobantes() As Integer
        Get
            Return autorizacionesValue.Count
        End Get
    End Property

    Public ReadOnly Property Autorizaciones() As List(Of Autorizacion)
        Get
            Return autorizacionesValue
        End Get
    End Property

    Public ReadOnly Property ClaveAccesoConsultada() As String
        Get
            Return claveAccesoConsultadaValue
        End Get
    End Property

    Public ReadOnly Property ClaveContingencia() As String
        Get
            If claveAccesoConsultadaValue <> String.Empty AndAlso claveAccesoConsultadaValue.Length = 49 Then
                Return claveAccesoConsultadaValue.Substring(10, 37)
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property xmlRespuestaSRI() As String
        Get
            'Return strRespuestaSOA
            Return xmlRespuesta.InnerXml
        End Get
    End Property

#End Region

#Region "CONSTRUCTOR"

    Public Sub New()
        isPendienteValue = False
    End Sub

    Friend Sub New(ByVal soapString As String)
        soapStringValue = soapString.Trim
        '-----------------------------------------------------------------------------
        If soapStringValue <> String.Empty Then
            readXML(soapStringValue)
        End If
    End Sub

#End Region

#Region "METODOS"

    Private Sub readXML(ByVal soapString As String)
        Dim xml As New System.Xml.XmlDocument
        '----------------------------------------------------------------
        Try
            xml.LoadXml(soapString)
            '------------------------------------------------------------
            readXML(xml.DocumentElement)
            '------------------------------------------------------------
            readIsAutorizado()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Read XML")
        End Try
        '----------------------------------------------------------------
        xml = Nothing
    End Sub

    Private Sub readXML(ByVal node As XmlNode)
        For Each nodeChild As XmlNode In node.ChildNodes
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName.Contains("RespuestaAutorizacionComprobante") = True Then
                    readAutorizacioneComprobante(nodeChild)
                ElseIf nodeChild.LocalName.Contains("autorizaciones") = True Then
                    readAutorizaciones(nodeChild)
                End If
                '-----------------------------------------------------------
                If nodeChild.ChildNodes.Count > 0 Then
                    readXML(nodeChild)
                End If
            End If
        Next
    End Sub

    Private Sub readAutorizacioneComprobante(ByVal node As XmlNode)
        For Each nodeChild As XmlNode In node.ChildNodes
            If nodeChild.LocalName.Contains("claveAccesoConsultada") Then
                If claveAccesoConsultadaValue = String.Empty Then
                    claveAccesoConsultadaValue = nodeChild.InnerText
                End If
            End If
        Next

        xmlRespuesta = node
        'If strRespuestaSOA = "" Then
        '    strRespuestaSOA = node.InnerText
        'End If
    End Sub

    Private Sub readAutorizaciones(ByVal node As XmlNode)
        For Each nodeChild As XmlNode In node.ChildNodes
            Dim autorizacion As Autorizacion = Nothing
            '--------------------------------------------------------------------
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName.Contains("autorizacion") = True Then
                    If nodeChild.HasChildNodes = True Then
                        autorizacion = New Autorizacion
                        '--------------------------------------------------------
                        readAutorizacion(nodeChild, autorizacion)
                    End If
                End If
                '----------------------------------------------------------------
                If autorizacion IsNot Nothing Then
                    autorizacionesValue.Add(autorizacion)
                End If
                '----------------------------------------------------------------
                If nodeChild.ChildNodes.Count > 0 Then
                    readAutorizaciones(nodeChild)
                End If
            End If
            '--------------------------------------------------------------------
            autorizacion = Nothing
        Next
    End Sub

    Private Sub readAutorizacion(ByVal node As XmlNode, ByVal autorizacion As Autorizacion)
        For Each nodeChild As XmlNode In node.ChildNodes
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName = "estado" Then
                    autorizacion.Estado = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "fechaAutorizacion" Then
                    autorizacion.FechaAutorizacion = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "ambiente" Then
                    autorizacion.Ambiente = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "comprobante" Then
                    autorizacion.Comprobante = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "numeroAutorizacion" Then
                    autorizacion.NumeroAutorizacion = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "mensajes" Then
                    readMensajes(nodeChild, autorizacion)
                End If
                '----------------------------------------------------------------
                If nodeChild.ChildNodes.Count > 0 Then
                    readAutorizacion(nodeChild, autorizacion)
                End If
            End If
        Next
    End Sub

    Private Sub readMensajes(ByVal node As XmlNode, ByVal autorizacion As Autorizacion)
        For Each nodeChild As XmlNode In node.ChildNodes
            Dim mensaje As Mensaje = Nothing
            '--------------------------------------------------------------------
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName = "mensaje" AndAlso nodeChild.ParentNode IsNot Nothing Then
                    If nodeChild.HasChildNodes = True AndAlso nodeChild.ParentNode.LocalName <> "mensaje" Then
                        mensaje = New Mensaje
                        '--------------------------------------------------------
                        readMensaje(nodeChild, mensaje)
                        '--------------------------------------------------------
                        If mensaje.Identificador = "60" Then
                            mensaje = Nothing
                        ElseIf mensaje.Identificador = "70" Then
                            isPendienteValue = True
                        End If
                    End If
                End If
                '----------------------------------------------------------------
                If mensaje IsNot Nothing Then
                    autorizacion.Mensajes.Add(mensaje)
                End If
                '----------------------------------------------------------------
                If nodeChild.ChildNodes.Count > 0 Then
                    readMensajes(nodeChild, autorizacion)
                End If
            End If
            '--------------------------------------------------------------------
            mensaje = Nothing
        Next
    End Sub

    Private Sub readMensaje(ByVal node As XmlNode, ByVal mensaje As Mensaje)
        For Each nodeChild As XmlNode In node.ChildNodes
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName = "identificador" Then
                    mensaje.Identificador = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "informacionAdicional" Then
                    mensaje.InformacionAdicional = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "mensaje" Then
                    mensaje.Mensaje = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "tipo" Then
                    mensaje.Tipo = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "estado" Then
                    mensaje.Estado = nodeChild.InnerText
                End If
                '----------------------------------------------------------------
                If nodeChild.ChildNodes.Count > 0 Then
                    readMensaje(nodeChild, mensaje)
                End If
            End If
        Next
    End Sub

    Private Sub readIsAutorizado()
        autorizacionValue = Nothing
        '-------------------------------------------------------------------------------------
        For Each x As Autorizacion In autorizacionesValue
            If x.IsAutorizado = True Then
                autorizacionValue = x : Exit For
            End If
        Next
        '-------------------------------------------------------------------------------------
        isAutorizadoValue = (autorizacionValue IsNot Nothing)
    End Sub

#End Region

End Class
