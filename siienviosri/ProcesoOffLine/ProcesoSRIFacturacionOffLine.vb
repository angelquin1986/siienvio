'@autor aquingaluisa
'Clase para manejar el proceso  offLine del SRI para las Facturas
Public Class ProcesoSRIFacturacionOffLine
    Private Property archivo As Archivo
    Private Property sriEnvio As EnvioSRI
    Private Property txtUrlRecepcionProduccion As String
    Private Property txtUrlAutorizacionProduccion As String
    Private Property txtUrlRecepcionPruebas As String
    Private Property txtUrlAutorizacionPruebas As String
    Private Property utilizaProxy As Boolean

    Sub New(ByVal directorioFirmados As String, ByVal directorioGenerados As String, ByVal directorioAutorizados As String,
                                           ByVal directorioContingencia As String, ByVal directorioPorAutorizar As String,
                                           ByVal directorioNoAutorizados As String,
                                           ByVal txtUrlRecepcionProduccion As String, ByVal txtUrlAutorizacionProduccion As String,
                                           ByVal txtUrlRecepcionPruebas As String, ByVal txtUrlAutorizacionPruebas As String,
                                           ByVal utilizaProxy As Boolean)
        sriEnvio = New EnvioSRI()
        archivo = New Archivo()
        archivo.CarpetaContingencia = directorioContingencia
        archivo.CarpetaAutorizados = directorioAutorizados
        archivo.CarpetaFirmados = directorioFirmados
        archivo.CarpetaGenerados = directorioGenerados
        archivo.CarpetaNoAutorizados = directorioNoAutorizados
        archivo.CarpetaPorAutorizar = directorioPorAutorizar
        Me.txtUrlRecepcionProduccion = txtUrlRecepcionProduccion
        Me.txtUrlAutorizacionProduccion = txtUrlAutorizacionProduccion
        Me.txtUrlRecepcionPruebas = txtUrlRecepcionPruebas
        Me.txtUrlAutorizacionPruebas = txtUrlAutorizacionPruebas
        Me.utilizaProxy = utilizaProxy
    End Sub

    Public Sub ejecutarProcesoOffLineSRI(ByVal txtdirecionArchivoP12 As String, ByVal txtpasswodP12 As String,
                                         ByVal lstListaComprobantesGenerados As Collection, ByVal esContigencia As Boolean)
        '1.- Primero se debe firmar los  comprobantes electronicos de la carpeta de generados,
        'el proceso firma los archivos los cambia al directorio firmados y  los amacena en base de datos
        Me.firmarDocumentosElectronicos(txtdirecionArchivoP12, txtpasswodP12, lstListaComprobantesGenerados, esContigencia)

        '2.- Autorizar los documentos electronicos que se encuentran en el directorio firmados
        Me.autorizarDocumentosElectronicos()
    End Sub
    'Firmar los documentos de la carpeta de generados y lo coloca en la carpeta de firmados
    Private Sub firmarDocumentosElectronicos(ByVal txtdirecionArchivoP12 As String, ByVal txtpasswodP12 As String,
                                           ByVal lstListaComprobantesGenerados As Collection, ByVal esContigencia As Boolean)
        Dim Firma As New FirmarXML(Me.archivo)
        Dim strArchivoXMLGenerado As String = ""
        Dim strNombreArchivo As String = ""
        Dim estaFirmado As Boolean = False

        Firma.ArchivoP12 = txtdirecionArchivoP12
        Firma.ContrasenaToken = txtpasswodP12
        Firma.DirectorioFirmados = archivo.CarpetaFirmados

        For Each item As String In lstListaComprobantesGenerados
            strArchivoXMLGenerado = archivo.CarpetaGenerados & "\" & item
            strNombreArchivo = item
            'se carga el nombre del archivo que se va a utilizar
            archivo.NombreArchivo = strNombreArchivo
            '-------------------------------------------------------------
            'comprobar si el archivo xml es correcto
            If archivo.IsValidXML(strArchivoXMLGenerado) Then
                If esContigencia = True Then
                    Firma.DirectorioGenerados = archivo.CarpetaContingencia
                Else
                    Firma.DirectorioGenerados = archivo.CarpetaGenerados
                End If
                Firma.ArchivoXMLGenerado = strNombreArchivo
                'firma el archivo xml a enviar
                estaFirmado = Firma.Firmar()
                If estaFirmado Then
                    'almacenar los archivos firmados en base
                    Me.guardarXmlOfLine()
                End If

            End If
            '-------------------------------------------------------------
            strArchivoXMLGenerado = ""
            strArchivoRelativoXML = ""
            strArchivoParaEnviar = ""
            strNombreArchivo = ""
        Next
        'Falta la parte en el caso de que no se pueda firmar tiene que  dejar el registro en la base de datos
    End Sub
    'Autorizar los documentos electronicos que se encuentran en la carpeta autorizados
    Private Sub autorizarDocumentosElectronicos()
        'tomar los archivos  por autorizar  de la carpeta 
        Dim nombreArchivoFirmadoCol = archivo.cargarListaNombreArchivo(archivo.CarpetaPorAutorizar, "*.xml")
        If nombreArchivoFirmadoCol.Count > 0 Then
            For Each nombrerArchivoFirmado In nombreArchivoFirmadoCol
                archivo.NombreArchivo = nombrerArchivoFirmado
                sriEnvio.ArchivoXMLPorAutorizar = Me.archivo.CarpetaPorAutorizar & "\" & nombrerArchivoFirmado
                sriEnvio.Proxy = Me.utilizaProxy
                Dim respuesta As Dictionary(Of String, String) = sriEnvio.enviarComprobanteAlSRI(Me.txtUrlRecepcionProduccion, Me.txtUrlAutorizacionProduccion,
                                                Me.txtUrlRecepcionPruebas, Me.txtUrlAutorizacionPruebas)
                Select Case respuesta.Item("codigoRespuesta")
                    Case "1"
                        'AUTORIZADO
                        GuardarDatosSRI(1, respuesta, archivo.CarpetaPorAutorizar & "\" & archivo.NombreArchivo)
                        archivo.CrearArchivos(sriEnvio.ArchivoXMLAutorizado, 1)
                        'EnviarCorreo()
                    Case "2"
                        'NO AUTORIZADO
                        GuardarDatosSRI(1, respuesta, archivo.CarpetaPorAutorizar & "\" & archivo.NombreArchivo)
                        archivo.CrearArchivos(Microsoft.VisualBasic.Left(sriEnvio.ArchivoXMLAutorizado, 30000), 2)
                    Case "3" 'la contingencia es cuado esta con errores
                        'CONTINGENCIA
                        GuardarDatosSRI(0, respuesta, archivo.CarpetaPorAutorizar & "\" & archivo.NombreArchivo)
                        archivo.CrearArchivos(sriEnvio.ArchivoXMLAutorizado, 3)
                    Case Else 'la contingencia es cuado esta con errores
                        'CONTINGENCIA
                        GuardarDatosSRI(0, respuesta, archivo.CarpetaPorAutorizar & "\" & archivo.NombreArchivo)
                        archivo.CrearArchivos(sriEnvio.ArchivoXMLAutorizado, 3)
                End Select
            Next
        End If
    End Sub
    'Metodo para guardar en el xml en  base
    Private Sub guardarXmlOfLine()
        Dim db As New ConexionBD
        Dim dato As New Datos
        Dim strClaveAcceso As String = ""
        Dim strArchivoXML As String = ""

        'path de los archivos firmados
        strArchivoXML = archivo.CarpetaFirmados & "\" & archivo.NombreArchivo
        'leer el archivo 
        ArchivoRelativo(strArchivoXML)

        Dim xmlContenido = WebServiceSRI.WebServiceSRI.getOuterXML(strArchivoXML)

        'para el parametro de firmada 
        'si es 0 o null no esta firmada(No se puende enviar)
        'si es 1 es firmada (se debe enviar por primera vez)
        'si es 2 es firmada ,ya se envio anteriormente y debe enviar agregando al asundo Correción)
        'si es 3 es firmada, ya se envio anteriormente y ya no se debe enviar nuevamente 

        Dim dataComp As DataTable = db.obtenerInfoComprobantes(dato.IdTransaccion(strArchivoXML))
        Dim row As DataRow = dataComp.Rows(0)
        Dim intBanderaEstaFirmado As Integer

        Dim dataVariableReenvio As DataTable = db.obtenerVariableReeviaCorreo()
        Dim intBanderaReenviarCorreo As Boolean
        If dataVariableReenvio IsNot Nothing AndAlso dataVariableReenvio.Rows.Count > 0 Then
            If dataVariableReenvio.Rows(0).IsNull("Valor") = False AndAlso dataVariableReenvio.Rows(0)("Valor") = 0 Then
                intBanderaReenviarCorreo = False
            Else
                intBanderaReenviarCorreo = True
            End If

        Else
            intBanderaReenviarCorreo = True
        End If

        Dim boolBandPdf As Boolean = row("BandPdf")
        'si ya fue enviado
        If boolBandPdf Then
            If intBanderaReenviarCorreo Then
                intBanderaEstaFirmado = 2
            Else
                intBanderaReenviarCorreo = 3
            End If
        Else
            'se almacena como firmado y requiere envio
            If dataVariableReenvio IsNot Nothing AndAlso dataVariableReenvio.Rows.Count > 0 AndAlso dataVariableReenvio.Rows(0).IsNull("Valor") Then
                intBanderaEstaFirmado = 1
            Else
                If row.IsNull("EstaFirmada") Then
                    intBanderaEstaFirmado = 1
                Else
                    intBanderaEstaFirmado = row("EstaFirmada")
                End If

            End If

        End If
        db.guardarXMLOffLine(xmlContenido, dato.IdTransaccion(strArchivoXML), intBanderaEstaFirmado)
    End Sub
    Private Sub GuardarDatosSRI(ByVal intEnviado As Byte, ByVal respuesta As Dictionary(Of String, String), ByRef strPathArchivo As String)
        Dim BD As New ConexionBD
        Dim dato As New Datos
        Dim strArchivoXML As String = ""
        Dim strXMLRelativo As String = ""
        Dim strClaveAcceso As String = ""
        Dim strMensajeAlterno As String = ""
        Dim strCodigoAlterno As String = ""
        Dim intEstado As Byte = respuesta.Item("codigoRespuesta")
        'para autorizar o no autorizar debe cojer del path de  firmados
        strArchivoXML = strPathArchivo

        ArchivoRelativo(strArchivoXML)
        CargarDatosCliente()
        strClaveAcceso = dato.RecuperarClaveAcceso(strArchivoRelativoXML)

        BD.ActualizarGNComprobante(dato.NroComprobante(strClaveAcceso), intEstado)

        '// Verifica que el SRI desvuelva el archivo XML autorizado
        strMensajeAlterno = sriEnvio.InformacionAdicional
        strCodigoAlterno = sriEnvio.CodigoMensaje

        'valida que contine un error
        If Len(sriEnvio.ArchivoXMLAutorizado) < 4 Then
            intEstado = 2
            If (respuesta.Item("codigoRespuesta") <> String.Empty) Then
                strMensajeAlterno = respuesta.Item("mensajeRespuesta")
            Else
                strMensajeAlterno = "Reenviar comprobante. SRI no ha devuelto XML."

            End If
            strCodigoAlterno = "35"
        End If

        '// Guarda el estado de los comprobantes en la base de datos
        If intEstado = 1 Then
            BD.GuardarDatosSRI(strClaveAcceso, _
                          sriEnvio.ArchivoXMLAutorizado, _
                          intEnviado, _
                          sriEnvio.CodigoMensaje, _
                          sriEnvio.InformacionAdicional, _
                          sriEnvio.TipoEmision, _
                          sriEnvio.NumeroAutorizacion, _
                          sriEnvio.FechaAutorizacion, _
                          dato.IdTransaccion(strArchivoXML))
        Else
            BD.GuardarDatosSRI(strClaveAcceso, _
                          "", _
                          intEnviado, _
                          strCodigoAlterno, _
                          strMensajeAlterno, _
                          sriEnvio.TipoEmision, _
                          "", _
                          sriEnvio.FechaAutorizacion, _
                          dato.IdTransaccion(strArchivoXML))
        End If
    End Sub

End Class
