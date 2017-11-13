Imports WebServiceSRI

Public Class EnvioSRI
    Private strArchivoXMLFirmado As String = ""
    Private strTipoEmision As String = ""
    Private strNumeroAutorizacion As String = ""
    Private strInformacionAdicional As String = ""
    Private strCodigoMensaje As String = ""
    Private dteFechaAutorizacion As Date
    Private strXMLAutorizado As String = ""
    Private blnUsarProxy As Boolean = False

    Public Property ArchivoXMLFirmado() As String
        Get
            Return strArchivoXMLFirmado
        End Get
        Set(ByVal value As String)
            strArchivoXMLFirmado = value
        End Set
    End Property

    Public ReadOnly Property NumeroAutorizacion() As String
        Get
            Return strNumeroAutorizacion
        End Get
    End Property

    Public ReadOnly Property FechaAutorizacion() As Date
        Get
            Return dteFechaAutorizacion
        End Get
    End Property

    Public ReadOnly Property TipoEmision() As String
        Get
            Return strTipoEmision
        End Get
    End Property

    Public ReadOnly Property InformacionAdicional() As String
        Get
            strInformacionAdicional = Microsoft.VisualBasic.Replace(strInformacionAdicional, "'", " ")
            Return strInformacionAdicional
        End Get
    End Property

    Public ReadOnly Property CodigoMensaje() As String
        Get
            Return strCodigoMensaje
        End Get
    End Property

    Public Property Proxy() As Boolean
        Get
            Return blnUsarProxy
        End Get
        Set(ByVal value As Boolean)
            blnUsarProxy = value
        End Set
    End Property

    Public ReadOnly Property ArchivoXMLAutorizado() As String
        Get
            Dim dato As New Datos

            If strCodigoMensaje = "60" Then
                Return dato.ArcFinXML(dato.ReemplazarCaracter(strXMLAutorizado, "<", ">"))
            Else
                Return dato.ReemplazarCaracter(strXMLAutorizado, "<", ">")
            End If
        End Get
    End Property

    Public Function sendComprobanteSRI() As Byte
        Dim ws As New WebServiceSRI.WebServiceSRI

        Dim intCorrecto As Byte = 0
        ' intCorrecto = 1 - Autorizado
        ' intCorrecto = 2 - No Autorizado
        ' intCorrecto = 3 - Contingencia

        If strArchivoXMLFirmado = String.Empty Then
            intCorrecto = 0
            Return intCorrecto
        End If

        '--------------------------------------------------------------------------------------------
        ' ESTABLECER VALORES DE PROXY
        '--------------------------------------------------------------------------------------------
        If blnUsarProxy = True Then
            Dim PXY As New UsarProxy
            ws.UsarProxy(True, PXY.Servidor, PXY.Puerto)
        Else
            ws.UsarProxy(False, "", 0)
        End If
        '--------------------------------------------------------------------------------------------

        Try
            If ws.sendComprobante(strArchivoXMLFirmado) = True Then
                If ws.AutorizacionComprobante.IsAutorizado = True Then
                    Dim at As WebServiceSRI.Autorizacion = ws.AutorizacionComprobante.Autorizacion
                    strTipoEmision = ws.TipoEmision
                    strNumeroAutorizacion = at.NumeroAutorizacion
                    dteFechaAutorizacion = at.FechaAutorizacion
                    strCodigoMensaje = "60"
                    strInformacionAdicional = at.Estado
                    strXMLAutorizado = ws.AutorizacionComprobante.xmlRespuestaSRI
                    intCorrecto = 1
                ElseIf ws.AutorizacionComprobante.NumeroComprobantes > 0 Then
                    LimpiarDatos()
                    For Each mensaje As WebServiceSRI.Mensaje In ws.AutorizacionComprobante.Autorizacion.Mensajes
                        'MsgBox(String.Format("Mensaje Error:{0}", mensaje.Mensaje), MsgBoxStyle.Critical)   
                        strCodigoMensaje = mensaje.Identificador
                        strInformacionAdicional = strInformacionAdicional & ". " & mensaje.Mensaje
                        strXMLAutorizado = ws.AutorizacionComprobante.xmlRespuestaSRI
                        Exit For
                    Next
                    intCorrecto = 2
                End If
            ElseIf ws.RecepcionComprobante.NumeroComprobantes > 0 Then
                LimpiarDatos()
                For Each mensaje As WebServiceSRI.Mensaje In ws.RecepcionComprobante.Comprobante.Mensajes
                    strTipoEmision = ws.TipoEmision
                    strCodigoMensaje = mensaje.Identificador
                    strInformacionAdicional = strInformacionAdicional & "." & mensaje.InformacionAdicional & ". " & mensaje.Mensaje
                    strXMLAutorizado = ws.AutorizacionComprobante.xmlRespuestaSRI
                    'Exit For
                Next
                intCorrecto = 2
            ElseIf ws.IsOnLine = False Then
                LimpiarDatos()
                'MsgBox("No hay conexion a los webservice del SRI", MsgBoxStyle.Exclamation)
                strInformacionAdicional = "No hay conexion a los webservice del SRI"
                intCorrecto = 3
            End If

        Catch ex As Exception
            LimpiarDatos()
            'MsgBox(ex.Message, MsgBoxStyle.Critical)
            strInformacionAdicional = ex.Message
            intCorrecto = 3
        End Try
        '--------------------------------------------------------------------------------------------
        ws = Nothing
        Return intCorrecto
    End Function

    Private Sub LimpiarDatos()
        strCodigoMensaje = ""
        strInformacionAdicional = ""
        strTipoEmision = ""
        strNumeroAutorizacion = ""
        dteFechaAutorizacion = Now
    End Sub
End Class
