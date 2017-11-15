Imports WebServiceSRI

Public Class EnvioSRI
    Private strArchivoXMLPorAutorizar As String = ""
    Private strTipoEmision As String = ""
    Private strNumeroAutorizacion As String = ""
    Private strInformacionAdicional As String = ""
    Private strCodigoMensaje As String = ""
    Private dteFechaAutorizacion As Date
    Private strXMLAutorizado As String = ""
    Private blnUsarProxy As Boolean = False

    Public Property ArchivoXMLPorAutorizar() As String
        Get
            Return strArchivoXMLPorAutorizar
        End Get
        Set(ByVal value As String)
            strArchivoXMLPorAutorizar = value
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
    'Metodo principal para enviar el comprobante al SRI
    Public Function enviarComprobanteAlSRI(ByVal urlWsRecepcionProd As String, ByVal urlWsAutorizacionProd As String, ByVal urlWsRecepcionPru As String, ByVal urlWsAutoPru As String) As Byte
        Dim werServiceSRI As New WebServiceSRI.WebServiceSRI(urlWsRecepcionProd, urlWsAutorizacionProd, urlWsRecepcionPru, urlWsAutoPru)

        Dim intCorrecto As Byte = 0
        ' intCorrecto = 1 - Autorizado
        ' intCorrecto = 2 - No Autorizado
        ' intCorrecto = 3 - Contingencia

        If strArchivoXMLPorAutorizar = String.Empty Then
            intCorrecto = 0
            Return intCorrecto
        End If

        '--------------------------------------------------------------------------------------------
        ' ESTABLECER VALORES DE PROXY
        '--------------------------------------------------------------------------------------------
        If blnUsarProxy = True Then
            Dim PXY As New UsarProxy
            werServiceSRI.UsarProxy(True, PXY.Servidor, PXY.Puerto)
        Else
            werServiceSRI.UsarProxy(False, "", 0)
        End If
        '--------------------------------------------------------------------------------------------

        Try
            'Envia el archivo xml al SRI(WS recepcion) y retorno la validacion  si es correcta
            If werServiceSRI.enviarComprobanteSRIPorNombreArchivo(strArchivoXMLPorAutorizar) = True Then
                'valida si el comprobante ya tiene la bandera de autorizado
                If werServiceSRI.AutorizacionComprobante.IsAutorizado = True Then
                    'toma los datos de autorizacion
                    Dim at As WebServiceSRI.Autorizacion = werServiceSRI.AutorizacionComprobante.Autorizacion
                    strTipoEmision = werServiceSRI.TipoEmision
                    strNumeroAutorizacion = at.NumeroAutorizacion
                    dteFechaAutorizacion = at.FechaAutorizacion
                    strCodigoMensaje = "60"
                    strInformacionAdicional = at.Estado
                    strXMLAutorizado = werServiceSRI.AutorizacionComprobante.xmlRespuestaSRI
                    'bandera  para validar que esta autorizado
                    intCorrecto = 1
                ElseIf werServiceSRI.AutorizacionComprobante.NumeroComprobantes > 0 Then
                    LimpiarDatos()
                    For Each mensaje As WebServiceSRI.Mensaje In werServiceSRI.AutorizacionComprobante.Autorizacion.Mensajes
                        'MsgBox(String.Format("Mensaje Error:{0}", mensaje.Mensaje), MsgBoxStyle.Critical)   
                        strCodigoMensaje = mensaje.Identificador
                        strInformacionAdicional = strInformacionAdicional & ". " & mensaje.Mensaje
                        strXMLAutorizado = werServiceSRI.AutorizacionComprobante.xmlRespuestaSRI
                        Exit For
                    Next
                    intCorrecto = 2
                End If
                'Cuando falla  el Ws de Recepcion por problemas en el archvivo 
            ElseIf werServiceSRI.RecepcionComprobante.NumeroComprobantes > 0 Then
                LimpiarDatos()
                For Each mensaje As WebServiceSRI.Mensaje In werServiceSRI.RecepcionComprobante.Comprobante.Mensajes
                    strTipoEmision = werServiceSRI.TipoEmision
                    strCodigoMensaje = mensaje.Identificador
                    strInformacionAdicional = strInformacionAdicional & "." & mensaje.InformacionAdicional & ". " & mensaje.Mensaje
                    strXMLAutorizado = werServiceSRI.AutorizacionComprobante.xmlRespuestaSRI
                    'Exit For
                Next
                intCorrecto = 2
            ElseIf werServiceSRI.IsOnLine = False Then
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
        werServiceSRI = Nothing
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
