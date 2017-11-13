Imports System.Xml

Public Class RecepcionComprobante

#Region "VARIABLES"

    Private estadoValue As String = String.Empty
    Private soapStringValue As String = String.Empty
    Private comprobantesValue As New List(Of Comprobante)

#End Region

#Region "PROPERTIES"

    Public ReadOnly Property SoapString() As String
        Get
            Return soapStringValue
        End Get
    End Property

    Public ReadOnly Property NumeroComprobantes() As Integer
        Get
            Return comprobantesValue.Count
        End Get
    End Property

    Public ReadOnly Property Comprobantes() As List(Of Comprobante)
        Get
            Return comprobantesValue
        End Get
    End Property

    Public ReadOnly Property Comprobante() As Comprobante
        Get
            If comprobantesValue IsNot Nothing AndAlso comprobantesValue.Count > 0 Then
                Return comprobantesValue(0)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property IsRecibida() As Boolean
        Get
            If estadoValue = "RECIBIDA" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property Estado() As String
        Get
            Return estadoValue
        End Get
    End Property

#End Region

#Region "CONSTRUCTOR"

    Sub New()
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
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Read XML")
        End Try
        '----------------------------------------------------------------
        xml = Nothing
    End Sub

    Private Sub readXML(ByVal node As XmlNode)
        For Each nodeChild As XmlNode In node.ChildNodes
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName = "estado" Then
                    estadoValue = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "comprobantes" Then
                    readComprobantes(nodeChild)
                End If
                '----------------------------------------------------------
                If nodeChild.ChildNodes.Count > 0 Then
                    readXML(nodeChild)
                End If
            End If
        Next
    End Sub

    Private Sub readComprobantes(ByVal node As XmlNode)
        For Each nodeChild As XmlNode In node.ChildNodes
            Dim comprobante As Comprobante = Nothing
            '--------------------------------------------------------------------
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName = "comprobante" Then
                    If nodeChild.HasChildNodes = True Then
                        comprobante = New Comprobante
                        '--------------------------------------------------------
                        readComprobante(nodeChild, comprobante)
                    End If
                End If
                '----------------------------------------------------------------
                If comprobante IsNot Nothing Then
                    comprobantesValue.Add(comprobante)
                End If
                '----------------------------------------------------------------
                If nodeChild.ChildNodes.Count > 0 Then
                    readComprobantes(nodeChild)
                End If
            End If
            '--------------------------------------------------------------------
            comprobante = Nothing
        Next
    End Sub

    Private Sub readComprobante(ByVal node As XmlNode, ByVal comprobante As Comprobante)
        For Each nodeChild As XmlNode In node.ChildNodes
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName.Contains("claveAcceso") = True Then
                    comprobante.ClaveAcceso = nodeChild.InnerText
                ElseIf nodeChild.LocalName = "mensajes" Then
                    readMensajes(nodeChild, comprobante)
                End If
                '----------------------------------------------------------------
                If nodeChild.ChildNodes.Count > 0 Then
                    readComprobante(nodeChild, comprobante)
                End If
            End If
        Next
    End Sub

    Private Sub readMensajes(ByVal node As XmlNode, ByVal comprobante As Comprobante)
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
                        End If
                    End If
                End If
                '----------------------------------------------------------------
                If mensaje IsNot Nothing Then
                    comprobante.Mensajes.Add(mensaje)
                End If
                '----------------------------------------------------------------
                If nodeChild.ChildNodes.Count > 0 Then
                    readMensajes(nodeChild, comprobante)
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

#End Region

End Class
