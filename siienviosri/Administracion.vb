Imports System.IO
Imports System.Threading
Imports System.Data
Imports System.Xml


Public Class Administracion
    Private strArchivoFirmado As String
    Private srtCodigoMensaje As String
    Private srtInformacionAdicional As String
    Private intEnviadoEMail As Boolean
    Private dtefechaEnvio As Date
    Private blnCambiarTextoBotonEnvio As Boolean
    Private strTipoEmision As String
    Private strNumeroAutorizacion As String
    Private dteFechaAutorizacion As Date
    Private blnContingencia As Boolean
    Private strArchivoComprobante As String
    Private strCodigoComprobante As String
    Private intIdTransaccion As ULong

    Dim SRI As New EnvioSRI
    Dim Archivo As New Archivo
    Dim lstListaComprobantesGenerados As New Collection
    Dim lstListaComprobantesFirmados As New Collection


    Private Sub Administracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnContingencia = False
        CargarConfiguracionServidorCorreo()
        CargarConfiguracion()
        'configurarListView()
        cargaListaComprobantesGenerados()

        If chkIniciarAplicacion.Checked = True Then
            Me.btnFirmarEnviar_Click(sender, e)
            Me.WindowState = FormWindowState.Minimized
        End If

    End Sub

    Private Sub autorizarFacturaElectronica()

        Dim Firma As New FirmarXML
        Dim strArchivoXMLGenerado As String = ""
        Dim strNombreArchivo As String = ""


        Firma.ArchivoP12 = txtArchivoP12.Text
        Firma.ContrasenaToken = txtContraseniaToken.Text
        Firma.DirectorioFirmados = txtComprobantesFirmados.Text

        For Each item As String In lstListaComprobantesGenerados
            strArchivoXMLGenerado = Me.txtComprobantesGenerados.Text & "\" & item
            strNombreArchivo = item
            'se carga los path nesesarios de las otras carpetas
            '-------------------------------------------------------------
            Archivo.CarpetaContingencia = txtcomprobantesContingencia.Text
            Archivo.CarpetaAutorizados = txtComprobantesAutorizados.Text
            Archivo.CarpetaFirmados = txtComprobantesFirmados.Text
            Archivo.CarpetaGenerados = txtComprobantesGenerados.Text
            Archivo.CarpetaNoAutorizados = txtComprobantesNoautorizados.Text
            Archivo.NombreArchivo = strNombreArchivo
            '-------------------------------------------------------------
            'comprobar si el archivo xml es correcto
            If Archivo.IsValidXML(strArchivoXMLGenerado) Then
                If blnContingencia = True Then
                    Firma.DirectorioGenerados = txtcomprobantesContingencia.Text
                Else
                    Firma.DirectorioGenerados = txtComprobantesGenerados.Text
                End If
                Firma.ArchivoXMLGenerado = strNombreArchivo
                'firma el archivo xml a enviar
                If Firma.Firmar() Then
                    'toma el path del archivo firmado que  nos retorna del objeto  FirmarXML
                    SRI.ArchivoXMLPorAutorizar = Firma.ArchivoXMLFirmado
                    SRI.Proxy = chkUtilizarProxy.Checked
                    Select Case SRI.enviarComprobanteAlSRI(txtUrlRecepcionProduccion.Text, txtUrlAutorizacionProduccion.Text, txtUrlRecepcionPruebas.Text, txtUrlAutorizacionPruebas.Text)
                        Case 1
                            'AUTORIZADO
                            GuardarDatosSRI(1, 1)
                            Archivo.CrearArchivos(SRI.ArchivoXMLAutorizado, 1)
                            'EnviarCorreo()
                        Case 2
                            'NO AUTORIZADO
                            GuardarDatosSRI(1, 2)
                            Archivo.CrearArchivos(Microsoft.VisualBasic.Left(SRI.ArchivoXMLAutorizado, 30000), 2)
                        Case 3 'la contingencia es cuado esta con errores
                            'CONTINGENCIA
                            GuardarDatosSRI(0, 3)
                            Archivo.CrearArchivos(SRI.ArchivoXMLAutorizado, 3)
                        Case Else 'la contingencia es cuado esta con errores
                            'CONTINGENCIA
                            GuardarDatosSRI(0, 3)
                            Archivo.CrearArchivos(SRI.ArchivoXMLAutorizado, 3)
                    End Select
                End If
            End If
            '-------------------------------------------------------------
            strArchivoXMLGenerado = ""
            strArchivoRelativoXML = ""
            strArchivoParaEnviar = ""
            strNombreArchivo = ""
        Next
    End Sub

    Private Function establecerParametros(ByVal strArchivo As String) As String
        Dim strArchivoP12 As String = txtArchivoP12.Text
        Dim strGenerados As String = txtComprobantesGenerados.Text
        Dim strFirmados As String = txtComprobantesFirmados.Text
        '---------------------------------------------------------------------------
        strArchivoFirmado = Me.txtComprobantesFirmados.Text & "\" & strArchivo
        '---------------------------------------------------------------------------
        Return Me.txtArchivoP12.Text & " " & _
            Me.txtContraseniaToken.Text & " " & _
            Me.txtComprobantesGenerados.Text & "\" & strArchivo & " " & _
            Me.txtComprobantesFirmados.Text & "\" & strArchivo
    End Function

    Private Function establecerParametrosContingencia(ByVal strArchivo As String) As String
        Dim strArchivoP12 As String = txtArchivoP12.Text
        Dim strGenerados As String = txtcomprobantesContingencia.Text
        Dim strFirmados As String = txtComprobantesFirmados.Text
        '---------------------------------------------------------------------------
        strArchivoFirmado = Me.txtComprobantesFirmados.Text & "\" & strArchivo
        '---------------------------------------------------------------------------
        Return Me.txtArchivoP12.Text & " " & _
            Me.txtContraseniaToken.Text & " " & _
            Me.txtcomprobantesContingencia.Text & "\" & strArchivo & " " & _
            Me.txtComprobantesFirmados.Text & "\" & strArchivo
    End Function
    'Evento que se ejecutar en  el intervalo seleccionado  por la pantalla
    Private Sub tmrActualizaLista_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrActualizaLista.Tick
        tmrActualizaLista.Stop()
        'metodo general de siiEnvia
        ejecutarProcesoSiiEnvia()
        tiempoEjecutar()
    End Sub
    'Metodo general que se ejecuta en el timer  de la aplicacion
    Public Sub ejecutarProcesoSiiEnvia()
        Dim log As New Log
        log.NombreFuncion = "Metodo Principal :ejecutarProcesoSiiEnvia()"
        Try
            'para el caso de que la lista este vacia debera buscar comprobantes
            If lstListaComprobantesGenerados.Count <= 0 Then
                cargaListaComprobantesGenerados()
            End If
            'valida si la lista de comprobantes generados  esta llena  para procesarlos
            ''autorizarFacturaElectronica()
            Dim procesoOffLine As New ProcesoSRIFacturacionOffLine(txtComprobantesFirmados.Text, txtComprobantesGenerados.Text, txtComprobantesAutorizados.Text, txtcomprobantesContingencia.Text, txtComprobantesPorAutorizar.Text, txtComprobantesNoautorizados.Text, _
                                                            txtUrlRecepcionProduccion.Text, txtUrlAutorizacionProduccion.Text, txtUrlRecepcionPruebas.Text, txtUrlAutorizacionPruebas.Text, chkUtilizarProxy.Checked)
            procesoOffLine.ejecutarProcesoOffLineSRI(txtArchivoP12.Text, txtContraseniaToken.Text, lstListaComprobantesGenerados, False)
            lstListaComprobantesGenerados.Clear()
            ' @aquingaluisa Metodo comentado porque Angel confirma que el envio de mail lo hacen desde el AUTOREADER
            'cargarReEnvioCorreo()

            log.SistemaError = "Termino con exito"
            log.MensajeError = "Termino con exito :ejecutarProcesoSiiEnvia"
        Catch ex As Exception
            log.SistemaError = ex.Message
            log.MensajeError = "Error al ejecutar metodo"
        End Try

        
    End Sub
    'Metodo para iniciar nuevamente la ejecucion del timer
    Private Sub tiempoEjecutar()
        tmrActualizaLista.Interval = (Convert.ToString(nudNumActualiza.Value) * 1000)
        tmrActualizaLista.Start()
    End Sub

    'Private Sub configurarListView()
    '    Dim cabecera1, cabecera2 As ColumnHeader

    '    cabecera1 = New ColumnHeader
    '    cabecera2 = New ColumnHeader
    '    '--------------------------------------------------------------------------------------------
    '    cabecera1.Text = "Archivos Firmados"
    '    cabecera2.Text = "Fecha"
    '    cabecera1.Width = 450
    '    cabecera2.Width = 170
    '    cabecera1.TextAlign = HorizontalAlignment.Left
    '    cabecera2.TextAlign = HorizontalAlignment.Left
    '    '--------------------------------------------------------------------------------------------
    '    lstListaComprobantes.Columns.Add(cabecera1)
    '    lstListaComprobantes.Columns.Add(cabecera2)
    '    lstListaComprobantes.View = View.Details
    'End Sub

    Private Sub cargaListaComprobantesGeneradosDeprecado()
        'limpiar los datos  de la lista de comprobantes generados
        lstListaComprobantesGenerados.Clear()

        Dim newCurrentDirectory As DirectoryInfo = New DirectoryInfo(txtComprobantesGenerados.Text)

        If newCurrentDirectory.Attributes <> -1 Then
            For Each filesfrom In newCurrentDirectory.GetFiles("*.xml", IO.SearchOption.AllDirectories)
                ' Dim NewItem01 As ListViewItem = MlstListaComprobantes.Items.Add(filesfrom.Name)
                'NewItem01.SubItems.Add(filesfrom.CreationTime)
            Next
        End If
    End Sub

    'metodo para cargar los datos de la carpeta generados
    Private Sub cargaListaComprobantesGenerados()
        Dim archivo As New Archivo()
        lstListaComprobantesGenerados.Clear()
        lstListaComprobantesGenerados = archivo.cargarListaNombreArchivo(txtComprobantesGenerados.Text, "*.xml")
    End Sub
    'metodo para cargar los datos de la carpeta contingencia
    Private Sub cargaListaComprobantesContingencia()
        Dim archivo As New Archivo()
        lstListaComprobantesGenerados.Clear()
        lstListaComprobantesGenerados = archivo.cargarListaNombreArchivo(txtcomprobantesContingencia.Text, "*.xml")
    End Sub

    Private Sub cargaListaComprobantesFirmados()
        Dim archivo As New Archivo()
        lstListaComprobantesGenerados.Clear()
        lstListaComprobantesGenerados = archivo.cargarListaNombreArchivo(txtComprobantesFirmados.Text, "*.xml")
    End Sub

    Private Sub CargarConfiguracion()
        Dim Decodificar As New CodificarBase64
        Dim BD As New ConexionBD
        Dim Archivo As New Archivo

        Dim conn As DataTable = BD.RecuperarConfiguracion()
        Dim strTipoAmbiente As String = ""
        '--------------------------------------------------------------------------------------------
        If conn.Rows.Count > 0 Then
            Dim row As DataRow = conn.Rows(0)
            txtComprobantesGenerados.Text = Convert.ToString(row("ComprobantesGenerados"))
            txtComprobantesFirmados.Text = Convert.ToString(row("ComprobantesFirmados"))
            txtComprobantesAutorizados.Text = Convert.ToString(row("ComprobantesAutorizados"))
            txtComprobantesNoautorizados.Text = Convert.ToString(row("ComprobantesNoAutorizados"))
            txtArchivoP12.Text = Convert.ToString(row("UbicacionArchivoToken"))
            txtContraseniaToken.Text = Convert.ToString(row("ContrasenaToken"))
            strTipoAmbiente = Convert.ToString(row("TipoAmbiente"))
            txtcomprobantesContingencia.Text = Convert.ToString(row("ComprobantesContingencia"))
            txtComprobantesEnviados.Text = Convert.ToString(row("ComprobantesEnviados"))
            txtUrlAutorizacionProduccion.Text = Convert.ToString(row("wsSriProduccionAutorizacion"))
            txtUrlRecepcionProduccion.Text = Convert.ToString(row("wsSriProduccionRecepcion"))
            txtUrlAutorizacionPruebas.Text = Convert.ToString(row("wsSriPruebasAutorizacion"))
            txtUrlRecepcionPruebas.Text = Convert.ToString(row("wsSriPruebasRecepcion"))

        End If
        '--------------------------------------------------------------------------------------------
        If strTipoAmbiente = "1" Then
            optTipoAmbientePruebas.Checked = True
            optTipoAmbienteProduccion.Checked = False
        Else
            optTipoAmbienteProduccion.Checked = True
            optTipoAmbientePruebas.Checked = False
        End If

        Decodificar.DecodificarTexto = Archivo.LeerArchivoTexto("C:\IA\EnvioSRI\iadt000.ibz")
        Dim TestArray() As String = Split(Decodificar.DecodificarTexto, ",")
        txtServidorBDP.Text = TestArray(0)
        txtBaseDatosP.Text = TestArray(1)
        txtNombreUsuarioBDP.Text = TestArray(2)
        txtContrasenaBDP.Text = TestArray(3)

        Decodificar.DecodificarTexto = Archivo.LeerArchivoTexto("C:\IA\EnvioSRI\iadt001.ibz")
        Dim TestArray1() As String = Split(Decodificar.DecodificarTexto, ",")
        txtServidorBDS.Text = TestArray1(0)
        txtBaseDatosS.Text = TestArray1(1)
        txtNombreUsuarioBDS.Text = TestArray1(2)
        txtContrasenaBDS.Text = TestArray1(3)

        Try
            Decodificar.DecodificarTexto = Archivo.LeerArchivoTexto("C:\IA\EnvioSRI\iadt002.ibz")
            Dim TestArray2() As String = Split(Decodificar.DecodificarTexto, ",")
            chkUtilizarProxy.Checked = TestArray2(0)
            txtDireccionProxy.Text = TestArray2(1)
            txtPuertoProxy.Text = TestArray2(2)
            chkIniciarAplicacion.Checked = TestArray2(3)
            chkIniciarConWindows.Checked = TestArray2(4)
            nudNumActualiza.Value = System.Convert.ToDecimal(TestArray2(5))
            dtpHoraEnvio.Value = System.Convert.ToDateTime(TestArray2(6))
        Catch ex As System.IndexOutOfRangeException
            '//
        End Try
        'Establece una variable global para guardar resultado de proxy
        blnUsarProxy = chkUtilizarProxy.Checked
        strDireccionProxy = txtDireccionProxy.Text
        If txtPuertoProxy.Text <> "" Then
            intPuertoProxy = CInt(txtPuertoProxy.Text)
        Else
            intPuertoProxy = CInt("0")
        End If

    End Sub

    Private Sub CargarConfiguracionServidorCorreo()
        Dim BD As New ConexionBD
        Dim conn As DataTable = BD.RecuperarConfigServidorCorreo()
        'Dim strTipoAmbiente As String

        If conn.Rows.Count > 0 Then
            Dim row As DataRow = conn.Rows(0)
            txtPuerto.Text = Convert.ToString(row("PuertoCorreo"))
            txtServidorCorreo.Text = Convert.ToString(row("ServidorCorreo"))
            txtNombreUsuario.Text = Convert.ToString(row("CuentaCorreo"))
            txtContrasenaCorreo.Text = Convert.ToString(row("PasswordCorreo"))
            chkConexionSegura.Checked = Convert.ToBoolean(row("ConexionSegura"))
            txtAsunto.Text = Convert.ToString(row("Asunto"))
            txtMensaje.Text = Convert.ToString(row("MensajeCorreo"))
            txtEnviarCopia.Text = Convert.ToString(row("CopiaCorreo"))
            txtUsuarioCorreo.Text = Convert.ToString(row("NombreUsuario"))
        End If
    End Sub

    Private Sub EnviarCorreo()

        Dim Dato As New Datos
        Dim Correo As New EnviarCorreoE
        Dim strXMLRelativo As String = ""

        If Dato.RecuperarCorreoCliente(strArchivoRelativoXML) <> "" Then
            Correo.Puerto = CUShort(txtPuerto.Text)
            Correo.ServidorCorreo = txtServidorCorreo.Text
            Correo.Usuario = txtNombreUsuario.Text
            Correo.Contrasena = txtContrasenaCorreo.Text
            Correo.ConexionCifrada = chkConexionSegura.Checked
            Correo.Para = Dato.RecuperarCorreoCliente(strXMLRelativo) '//
            Correo.Asunto = txtAsunto.Text
            Correo.Mensaje = txtMensaje.Text
            Correo.MensajeHTML = True
            Correo.AdjuntarArchivoXML = strArchivoParaEnviar '//
            Correo.AdjuntarArchivoPDF = strArchivoParaEnviarPDF
            Correo.Proxy = chkUtilizarProxy.Checked
            Correo.CC = txtEnviarCopia.Text
            Correo.UsuarioSesion = txtUsuarioCorreo.Text
            Correo.Enviar()
            strEmailCli = ""
        End If
    End Sub

    Private Sub GuardarDatosSRI(ByVal intEnviado As Byte, ByVal intEstado As Byte)
        Dim BD As New ConexionBD
        Dim dato As New Datos
        Dim strArchivoXML As String = ""
        Dim strXMLRelativo As String = ""
        Dim strClaveAcceso As String = ""
        Dim strMensajeAlterno As String = ""
        Dim strCodigoAlterno As String = ""

        strArchivoXML = Archivo.CarpetaGenerados & "\" & Archivo.NombreArchivo

        ArchivoRelativo(strArchivoXML)
        CargarDatosCliente()
        strClaveAcceso = dato.RecuperarClaveAcceso(strArchivoRelativoXML)

        BD.ActualizarGNComprobante(dato.NroComprobante(strClaveAcceso), intEstado)

        '// Verifica que el SRI desvuelva el archivo XML autorizado
        strMensajeAlterno = SRI.InformacionAdicional
        strCodigoAlterno = SRI.CodigoMensaje

        If Len(SRI.ArchivoXMLAutorizado) < 4 Then
            intEstado = 2

            strMensajeAlterno = "Reenviar comprobante. SRI no ha devuelto XML."
            strCodigoAlterno = "35"
        End If

        '// Guarda el estado de los comprobantes en la base de datos
        If intEstado = 1 Then
            BD.GuardarDatosSRI(strClaveAcceso, _
                          SRI.ArchivoXMLAutorizado, _
                          intEnviado, _
                          SRI.CodigoMensaje, _
                          SRI.InformacionAdicional, _
                          SRI.TipoEmision, _
                          SRI.NumeroAutorizacion, _
                          SRI.FechaAutorizacion, _
                          dato.IdTransaccion(strArchivoXML))
        Else
            BD.GuardarDatosSRI(strClaveAcceso, _
                          "", _
                          intEnviado, _
                          strCodigoAlterno, _
                          strMensajeAlterno, _
                          SRI.TipoEmision, _
                          "", _
                          SRI.FechaAutorizacion, _
                          dato.IdTransaccion(strArchivoXML))
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        GuardarConfiguracion()
    End Sub

    Private Sub btnFirmarEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirmarEnviar.Click
        If blnCambiarTextoBotonEnvio = False Then
            btnFirmarEnviar.Text = "Detener"
            blnCambiarTextoBotonEnvio = True
            tiempoEjecutar()
        Else
            tmrActualizaLista.Stop()
            btnFirmarEnviar.Text = "Iniciar"
            blnCambiarTextoBotonEnvio = False
        End If
    End Sub

    Private Sub GuardarConfiguracion()
        Dim intConexionSeguridad As Byte
        Dim strTipoAmbiente01 As String
        Dim Codificar As New CodificarBase64
        Dim Archivo As New Archivo
        Dim BD As New ConexionBD

        If txtComprobantesGenerados.Text = "" Or Len(txtComprobantesGenerados.Text) >= 255 Then
            MsgBox("El directorio no cumple con los requisitos")
            txtComprobantesGenerados.Focus()
            Exit Sub
        End If

        If txtComprobantesFirmados.Text = "" Or Len(txtComprobantesFirmados.Text) >= 255 Then
            MsgBox("El directorio no cumple con los requisitos")
            txtComprobantesFirmados.Focus()
            Exit Sub
        End If

        If txtComprobantesAutorizados.Text = "" Or Len(txtComprobantesAutorizados.Text) >= 255 Then
            MsgBox("El directorio no cumple con los requisitos")
            txtComprobantesAutorizados.Focus()
            Exit Sub
        End If

        If txtComprobantesNoautorizados.Text = "" Or Len(txtComprobantesNoautorizados.Text) >= 255 Then
            MsgBox("El directorio no cumple con los requisitos")
            txtComprobantesNoautorizados.Focus()
            Exit Sub
        End If

        If txtcomprobantesContingencia.Text = "" Or Len(txtcomprobantesContingencia.Text) >= 255 Then
            MsgBox("El directorio no cumple con los requisitos")
            txtcomprobantesContingencia.Focus()
            Exit Sub
        End If

        If txtComprobantesEnviados.Text = "" Or Len(txtComprobantesEnviados.Text) >= 255 Then
            MsgBox("El directorio no cumple con los requisitos")
            txtComprobantesEnviados.Focus()
            Exit Sub
        End If

        If txtArchivoP12.Text = "" Or Len(txtArchivoP12.Text) >= 255 Then
            MsgBox("La dirección de archivo no cumple con los requisitos")
            txtArchivoP12.Focus()
            Exit Sub
        End If

        If txtContraseniaToken.Text = "" Or Len(txtContraseniaToken.Text) >= 50 Then
            MsgBox("La contraseña no cumple con los requisitos")
            txtContraseniaToken.Focus()
            Exit Sub
        Else
            Try
                Dim cert As System.Security.Cryptography.X509Certificates.X509Certificate2
                cert = New System.Security.Cryptography.X509Certificates.X509Certificate2(txtArchivoP12.Text, txtContraseniaToken.Text, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable Or System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.PersistKeySet)
            Catch e As Exception
                Dim MensajeError As [String] = "Error" & vbLf & "El archivo no podrá ser firmado" & vbLf & vbLf & "• El certificado digital no es valido" & vbLf & "• La contraseña del certificado es incorrecta" & vbLf & vbLf + Convert.ToString(e.Message)
                System.Windows.Forms.MessageBox.Show(MensajeError, "Ishida & Asociados", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.[Error])
                txtContraseniaToken.Focus()
                Exit Sub
            End Try
        End If

        If optTipoAmbientePruebas.Checked = True Then
            strTipoAmbiente01 = "1"
        Else
            strTipoAmbiente01 = "2"
        End If

        If txtPuerto.Text = "" Or Len(txtPuerto.Text) >= 5 Then
            MsgBox("El puerdo SMTP no cumple con los requisitos")
            txtPuerto.Focus()
            Exit Sub
        End If

        If txtServidorCorreo.Text = "" Or Len(txtServidorCorreo.Text) >= 50 Then
            MsgBox("El servidor de correo SMTP no cumple con los requisitos")
            txtServidorCorreo.Focus()
            Exit Sub
        End If

        If txtNombreUsuario.Text = "" Or Len(txtNombreUsuario.Text) >= 50 Then
            MsgBox("La dirección de correo no cumple con los requisitos")
            txtNombreUsuario.Focus()
            Exit Sub
        End If

        If txtUsuarioCorreo.Text = "" Or Len(txtUsuarioCorreo.Text) >= 50 Then
            MsgBox("El nombre de usuario no cumple con los requisitos")
            txtUsuarioCorreo.Focus()
            Exit Sub
        End If

        If txtContrasenaCorreo.Text = "" Or Len(txtContrasenaCorreo.Text) >= 50 Then
            MsgBox("la contraseña no cumple con los requisitos")
            txtContrasenaCorreo.Focus()
            Exit Sub
        End If

        If txtAsunto.Text = "" Or Len(txtAsunto.Text) >= 50 Then
            MsgBox("El asunto no cumple con los requisitos")
            txtAsunto.Focus()
            Exit Sub
        End If

        If txtMensaje.Text = "" Or Len(txtMensaje.Text) >= 4000 Then
            MsgBox("El mensaje no cumple con los requisitos")
            txtMensaje.Focus()
            Exit Sub
        End If

        If chkUtilizarProxy.Checked = True And txtDireccionProxy.Text = "" Then
            MsgBox("La dirección proxy no es correcta")
            txtDireccionProxy.Focus()
            Exit Sub
        End If

        If chkUtilizarProxy.Checked = True And txtPuertoProxy.Text = "" Then
            MsgBox("El puerto proxy no es correcto")
            txtPuertoProxy.Focus()
            Exit Sub
        End If

        If txtUrlRecepcionProduccion.Text = "" Or Len(txtUrlRecepcionProduccion.Text) >= 255 Then
            MsgBox("Las dirección  del ws Recepción Producción no puede ser nula.")
            txtUrlRecepcionProduccion.Focus()
            Exit Sub
        End If
        If txtUrlAutorizacionProduccion.Text = "" Or Len(txtUrlAutorizacionProduccion.Text) >= 255 Then
            MsgBox("Las dirección  del ws Autorización Producción no puede ser nula.")
            txtUrlAutorizacionProduccion.Focus()
            Exit Sub
        End If
        If txtUrlRecepcionPruebas.Text = "" Or Len(txtUrlRecepcionPruebas.Text) >= 255 Then
            MsgBox("Las dirección  del ws Recepción Pruebas no puede ser nula.")
            txtUrlRecepcionPruebas.Focus()
            Exit Sub
        End If
        If txtUrlAutorizacionPruebas.Text = "" Or Len(txtUrlAutorizacionPruebas.Text) >= 255 Then
            MsgBox("Las dirección  del ws Autorización Producción no puede ser nula.")
            txtUrlAutorizacionPruebas.Focus()
            Exit Sub
        End If

        If chkConexionSegura.Checked = True Then
            intConexionSeguridad = 1
        Else
            intConexionSeguridad = 0
        End If

        '--------------------------------------------------------------------------------------------
        Dim IniciarConWindows As New IniciarWindows
        If chkIniciarConWindows.Checked = True Then
            IniciarConWindows.IniciarConWindows()
        Else
            IniciarConWindows.NoIniciarConWindows()
        End If
        '--------------------------------------------------------------------------------------------

        Codificar.CodificarTexto = txtServidorBDP.Text & "," & txtBaseDatosP.Text & "," & txtNombreUsuarioBDP.Text & "," & txtContrasenaBDP.Text
        Archivo.GuardarArchivoTexto("C:\IA\EnvioSRI\iadt000.ibz", Codificar.CodificarTexto, False)

        Codificar.CodificarTexto = txtServidorBDS.Text & "," & txtBaseDatosS.Text & "," & txtNombreUsuarioBDS.Text & "," & txtContrasenaBDS.Text
        Archivo.GuardarArchivoTexto("C:\IA\EnvioSRI\iadt001.ibz", Codificar.CodificarTexto, False)

        Codificar.CodificarTexto = chkUtilizarProxy.Checked & "," & txtDireccionProxy.Text & "," & txtPuertoProxy.Text & "," & chkIniciarAplicacion.Checked & "," & chkIniciarConWindows.Checked & "," & System.Convert.ToString(nudNumActualiza.Value) & "," & dtpHoraEnvio.Value
        Archivo.GuardarArchivoTexto("C:\IA\EnvioSRI\iadt002.ibz", Codificar.CodificarTexto, False)

        BD.GuardarConfigServidorCorreo(txtPuerto.Text, txtServidorCorreo.Text, txtNombreUsuario.Text, txtContrasenaCorreo.Text, txtAsunto.Text, txtMensaje.Text, intConexionSeguridad, txtEnviarCopia.Text, txtUsuarioCorreo.Text)
        BD.GuardarConfiguracionGeneral(txtComprobantesGenerados.Text, txtComprobantesFirmados.Text, txtComprobantesAutorizados.Text, txtComprobantesNoautorizados.Text, txtArchivoP12.Text, txtContraseniaToken.Text, strTipoAmbiente01, txtcomprobantesContingencia.Text, txtComprobantesEnviados.Text,
                                       txtUrlRecepcionProduccion.Text, txtUrlAutorizacionProduccion.Text, txtUrlRecepcionPruebas.Text, txtUrlAutorizacionPruebas.Text)
    End Sub

    Private Sub btnExaminar01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar01.Click
        Dim folderDlg As New FolderBrowserDialog

        folderDlg.ShowNewFolderButton = True

        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            txtComprobantesGenerados.Text = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub btnExaminar02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar02.Click
        Dim folderDlg As New FolderBrowserDialog

        folderDlg.ShowNewFolderButton = True

        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            txtComprobantesFirmados.Text = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub btnExaminar03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar03.Click
        Dim folderDlg As New FolderBrowserDialog

        folderDlg.ShowNewFolderButton = True

        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            txtComprobantesAutorizados.Text = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub btnExaminar04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar04.Click
        Dim folderDlg As New FolderBrowserDialog

        folderDlg.ShowNewFolderButton = True

        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            txtComprobantesNoautorizados.Text = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar05.Click
        Dim fileDialogBox As New OpenFileDialog()

        fileDialogBox.Filter = "Certificado estandar x.509 en formato p12 (*.p12)|*.p12|" _
            & "Certificado estandar x.509 en formato pfx (*.pfx)|*.pfx|" _
            & "Todos los archivos(*.*)|"

        fileDialogBox.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        If (fileDialogBox.ShowDialog() = DialogResult.OK) Then
            txtArchivoP12.Text = fileDialogBox.FileName
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExaminar06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar06.Click
        Dim fileDialogBox As New OpenFileDialog()

        fileDialogBox.Filter = "Archivo de texto (*.txt)|*.txt|" _
            & "Todos los archivos(*.*)|"

        fileDialogBox.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        If (fileDialogBox.ShowDialog() = DialogResult.OK) Then
            txtClaveContingencia.Text = fileDialogBox.FileName
        End If
    End Sub

    Private Sub btnCargarClaves_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarClaves.Click
        If txtClaveContingencia.Text = "" Or Len(txtClaveContingencia.Text) >= 255 Then
            MsgBox("No ha seleccionado ningún archivo")
        Else
            btnCargarClaves.Enabled = False
            CargarClavesContingencia(txtClaveContingencia.Text)
            btnCargarClaves.Enabled = True
        End If
    End Sub

    Public Sub CargarClavesContingencia(ByVal strArchivo As String)
        Dim BD As New ConexionBD
        Dim LineaDeTexto As String = ""
        Dim devuelta As Boolean
        Dim intRespuesta As Byte
        Dim intContador As Integer

        If strArchivo <> "" Then
            Try 'abre el archivo y detecta cualesquiera errores mediante un controlador
                FileOpen(1, strArchivo, OpenMode.Input)
                Do Until EOF(1) 'lee las líneas contenidas en el archivo
                    LineaDeTexto = LineInput(1) 'Lee la línea entera                    
                    devuelta = BD.GrabarClavesContingencia(LineaDeTexto)
                    If devuelta = True Then
                        intRespuesta = MsgBox("La clave de contingencia " & LineaDeTexto & " ya ha sido ingresada " _
                        & vbCrLf & "¿Desea continuar?", vbQuestion + vbYesNo, "Clave de contingencia")
                        If intRespuesta = vbNo Then
                            Exit Do
                        End If
                    Else
                        intContador = intContador + 1
                    End If
                Loop
                intRespuesta = MsgBox("Se han registrado " & intContador & " claves de contingencia.", vbInformation + vbOKOnly, "Clave de contingencia")
            Catch
                MsgBox("No ha seleccionado ningún archivo") 'Si no seleccionas archivo
            Finally
                FileClose(1) 'cierra el archivo
            End Try
        Else
            MsgBox("No ha seleccionado ningún archivo") 'Si no seleccionas archivo
        End If
    End Sub

    Private Sub btnExaminar07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar07.Click
        Dim folderDlg As New FolderBrowserDialog

        folderDlg.ShowNewFolderButton = True

        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            txtcomprobantesContingencia.Text = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub btnReenviarComprobantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReenviarComprobantes.Click
        tmrActualizaLista.Stop()
        'carga la lista de generados como contingencia
        cargaListaComprobantesContingencia()
        blnContingencia = True
        autorizarFacturaElectronica()
    End Sub

    Private Sub chkUtilizarProxy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUtilizarProxy.CheckedChanged
        If chkUtilizarProxy.Checked = True Then
            txtDireccionProxy.Enabled = True
            txtPuertoProxy.Enabled = True
        Else
            txtDireccionProxy.Enabled = False
            txtPuertoProxy.Enabled = False
        End If

    End Sub

    Private Sub ntfAreaNotificacion_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ntfAreaNotificacion.MouseDoubleClick
        'Primero lo maximizamos
        Me.WindowState = FormWindowState.Normal
        'Refrescamos los controles del formulario, sólo por nitidez.
        Me.Refresh()
        'Lo volvemos a hacer visible
        Me.Visible = True
        Me.BringToFront()
        ntfAreaNotificacion.Visible = False
    End Sub

    '==================================================================================================
    '==================================================================================================
    Private Sub ReEnviarCorreo()
        Dim Archivos As New Archivo
        Dim strArchivoXMLAutorizados As String = ""
        Dim strArchivoPDF As String = ""
        Dim strPathDirectorio As String = Me.txtComprobantesAutorizados.Text
        Dim strCopiaGen As String = Me.txtComprobantesAutorizados.Text

        For Each item As ListViewItem In lstReEnviarCorreo.Items
            strArchivoXMLAutorizados = strCopiaGen & "\" & item.Text
            strArchivoPDF = item.Text
            strArchivoPDF = strArchivoPDF.Replace(".xml", ".pdf")

            If File.Exists(strArchivoXMLAutorizados) Then
                ArchivoRelativo(strArchivoXMLAutorizados)
                CargarDatosClienteCorreo()

                strArchivoParaEnviar = txtComprobantesAutorizados.Text & "\" & item.Text
                strArchivoParaEnviarPDF = txtComprobantesAutorizados.Text & "\" & strArchivoPDF

                'If File.Exists(txtComprobantesAutorizados.Text & "\" & strArchivoPDF) Then File.Delete(txtComprobantesAutorizados.Text & "\" & strArchivoPDF)
                If File.Exists(strArchivoParaEnviar) And File.Exists(strArchivoParaEnviarPDF) Then
                    EnviarCorreo()

                    'Archivos.MoverEnviados(Me.txtComprobantesAutorizados.Text, item.Text, strArchivoRelativoXML)
                    Archivos.MoverEnviados(Me.txtComprobantesAutorizados.Text, item.Text, "")
                    Archivos.MoverEnviados(Me.txtComprobantesAutorizados.Text, strArchivoPDF, "")
                End If
            End If
        Next
    End Sub

    Private Sub cargaListViewEnviarCorreo()
        lstReEnviarCorreo.Items.Clear()

        Dim newCurrentDirectory As DirectoryInfo = New DirectoryInfo(txtComprobantesAutorizados.Text)

        If newCurrentDirectory.Attributes <> -1 Then
            For Each filesfrom In newCurrentDirectory.GetFiles("*.xml", IO.SearchOption.AllDirectories)
                Dim NewItem01 As ListViewItem = Me.lstReEnviarCorreo.Items.Add(filesfrom.Name)
                NewItem01.SubItems.Add(filesfrom.CreationTime)
            Next
        End If
    End Sub

    Private Sub cargarReEnvioCorreo()
        Dim strHoraSistema As String = Now.ToString("HH:mm")
        Dim dteEstablecida As DateTime = dtpHoraEnvio.Value
        Dim dteMinuto As String = dteEstablecida.Minute
        Dim dteMinuto15 As String = dteEstablecida.Minute + 15
        Dim steHoraFin As String = dteEstablecida.Hour
        Dim strHoraGuardada As String = dteEstablecida.Hour

        If dteMinuto < 10 Then
            dteMinuto = "0" & dteMinuto
        End If
        If dteMinuto15 > 60 Then
            dteMinuto15 = "00"
            steHoraFin = steHoraFin + 1
        End If

        If strHoraGuardada < 10 Then
            steHoraFin = "0" & strHoraGuardada
            strHoraGuardada = "0" & strHoraGuardada
        End If

        Dim strHoraEstablecida As String = strHoraGuardada & ":" & dteMinuto
        Dim strHoraFin As String = steHoraFin & ":" & dteMinuto15

        If (strHoraSistema >= strHoraEstablecida) And (strHoraSistema < strHoraFin) Then
            cargaListViewEnviarCorreo()
            ReEnviarCorreo()
        End If

    End Sub

    '==================================================================================================
    '==================================================================================================
    Private Sub cargaListViewEnviarFTP()
        lstListaFTP.Items.Clear()

        Dim newCurrentDirectory As DirectoryInfo = New DirectoryInfo(txtComprobantesAutorizados.Text)

        If newCurrentDirectory.Attributes <> -1 Then
            For Each filesfrom In newCurrentDirectory.GetFiles("*.xml", IO.SearchOption.AllDirectories)
                Dim NewItem01 As ListViewItem = Me.lstReEnviarCorreo.Items.Add(filesfrom.Name)
                NewItem01.SubItems.Add(filesfrom.CreationTime)
            Next
        End If
    End Sub

    Private Sub EnviarCompFTP()
        Dim Archivos As New Archivo
        Dim strArchivoXMLAutorizados As String = ""
        Dim strArchivoPDF As String = ""
        Dim strPathDirectorio As String = Me.txtComprobantesAutorizados.Text
        Dim strCopiaGen As String = Me.txtComprobantesAutorizados.Text

        For Each item As ListViewItem In lstListaFTP.Items

        Next
    End Sub

    Private Sub btnExaminar08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar08.Click
        Dim folderDlg As New FolderBrowserDialog

        folderDlg.ShowNewFolderButton = True

        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            txtComprobantesEnviados.Text = folderDlg.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPruebaTimer.Click
        ejecutarProcesoSiiEnvia()
    End Sub

    Private Sub Label32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label32.Click

    End Sub

    Private Sub TabCompFirmados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCompFirmados.Click

    End Sub
End Class