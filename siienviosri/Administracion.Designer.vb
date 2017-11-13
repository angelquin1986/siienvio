<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Administracion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Administracion))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabDirectorios = New System.Windows.Forms.TabPage()
        Me.btnExaminar08 = New System.Windows.Forms.Button()
        Me.txtComprobantesEnviados = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnExaminar07 = New System.Windows.Forms.Button()
        Me.txtcomprobantesContingencia = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnExaminar04 = New System.Windows.Forms.Button()
        Me.btnExaminar03 = New System.Windows.Forms.Button()
        Me.btnExaminar02 = New System.Windows.Forms.Button()
        Me.btnExaminar01 = New System.Windows.Forms.Button()
        Me.txtComprobantesNoautorizados = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtComprobantesAutorizados = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtComprobantesFirmados = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComprobantesGenerados = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabAutFirma = New System.Windows.Forms.TabPage()
        Me.optTipoAmbienteProduccion = New System.Windows.Forms.RadioButton()
        Me.optTipoAmbientePruebas = New System.Windows.Forms.RadioButton()
        Me.btnExaminar05 = New System.Windows.Forms.Button()
        Me.txtContraseniaToken = New System.Windows.Forms.TextBox()
        Me.txtArchivoP12 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbToken = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabCompFirmados = New System.Windows.Forms.TabPage()
        Me.lstListaFTP = New System.Windows.Forms.ListView()
        Me.lstReEnviarCorreo = New System.Windows.Forms.ListView()
        Me.btnReenviarComprobantes = New System.Windows.Forms.Button()
        Me.btnCargarClaves = New System.Windows.Forms.Button()
        Me.btnExaminar06 = New System.Windows.Forms.Button()
        Me.txtClaveContingencia = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lstListaComprobantes = New System.Windows.Forms.ListView()
        Me.tabServidorCorreo = New System.Windows.Forms.TabPage()
        Me.txtUsuarioCorreo = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtEnviarCopia = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkConexionSegura = New System.Windows.Forms.CheckBox()
        Me.txtContrasenaCorreo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNombreUsuario = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtServidorCorreo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPuerto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabConfBaseDatos = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tbpBDPrincipal = New System.Windows.Forms.TabPage()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtContrasenaBDP = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNombreUsuarioBDP = New System.Windows.Forms.TextBox()
        Me.txtBaseDatosP = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtServidorBDP = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tbpBDSecundaria = New System.Windows.Forms.TabPage()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtContrasenaBDS = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtNombreUsuarioBDS = New System.Windows.Forms.TextBox()
        Me.txtBaseDatosS = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtServidorBDS = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tbpOpcionesAvanzadas = New System.Windows.Forms.TabPage()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.dtpHoraEnvio = New System.Windows.Forms.DateTimePicker()
        Me.chkIniciarConWindows = New System.Windows.Forms.CheckBox()
        Me.chkIniciarAplicacion = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.nudNumActualiza = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtPuertoProxy = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtDireccionProxy = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.chkUtilizarProxy = New System.Windows.Forms.CheckBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.tmrActualizaLista = New System.Windows.Forms.Timer(Me.components)
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnFirmarEnviar = New System.Windows.Forms.Button()
        Me.ntfAreaNotificacion = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.tabDirectorios.SuspendLayout()
        Me.TabAutFirma.SuspendLayout()
        Me.TabCompFirmados.SuspendLayout()
        Me.tabServidorCorreo.SuspendLayout()
        Me.TabConfBaseDatos.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tbpBDPrincipal.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpBDSecundaria.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpOpcionesAvanzadas.SuspendLayout()
        CType(Me.nudNumActualiza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabDirectorios)
        Me.TabControl1.Controls.Add(Me.TabAutFirma)
        Me.TabControl1.Controls.Add(Me.TabCompFirmados)
        Me.TabControl1.Controls.Add(Me.tabServidorCorreo)
        Me.TabControl1.Controls.Add(Me.TabConfBaseDatos)
        Me.TabControl1.Location = New System.Drawing.Point(6, 9)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(664, 233)
        Me.TabControl1.TabIndex = 0
        '
        'tabDirectorios
        '
        Me.tabDirectorios.Controls.Add(Me.btnExaminar08)
        Me.tabDirectorios.Controls.Add(Me.txtComprobantesEnviados)
        Me.tabDirectorios.Controls.Add(Me.Label31)
        Me.tabDirectorios.Controls.Add(Me.btnExaminar07)
        Me.tabDirectorios.Controls.Add(Me.txtcomprobantesContingencia)
        Me.tabDirectorios.Controls.Add(Me.Label17)
        Me.tabDirectorios.Controls.Add(Me.btnExaminar04)
        Me.tabDirectorios.Controls.Add(Me.btnExaminar03)
        Me.tabDirectorios.Controls.Add(Me.btnExaminar02)
        Me.tabDirectorios.Controls.Add(Me.btnExaminar01)
        Me.tabDirectorios.Controls.Add(Me.txtComprobantesNoautorizados)
        Me.tabDirectorios.Controls.Add(Me.Label4)
        Me.tabDirectorios.Controls.Add(Me.txtComprobantesAutorizados)
        Me.tabDirectorios.Controls.Add(Me.Label3)
        Me.tabDirectorios.Controls.Add(Me.txtComprobantesFirmados)
        Me.tabDirectorios.Controls.Add(Me.Label2)
        Me.tabDirectorios.Controls.Add(Me.txtComprobantesGenerados)
        Me.tabDirectorios.Controls.Add(Me.Label1)
        Me.tabDirectorios.Location = New System.Drawing.Point(4, 22)
        Me.tabDirectorios.Name = "tabDirectorios"
        Me.tabDirectorios.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDirectorios.Size = New System.Drawing.Size(656, 207)
        Me.tabDirectorios.TabIndex = 0
        Me.tabDirectorios.Text = "Configurar Directorios"
        Me.tabDirectorios.UseVisualStyleBackColor = True
        '
        'btnExaminar08
        '
        Me.btnExaminar08.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar08.Location = New System.Drawing.Point(560, 164)
        Me.btnExaminar08.Name = "btnExaminar08"
        Me.btnExaminar08.Size = New System.Drawing.Size(29, 21)
        Me.btnExaminar08.TabIndex = 17
        Me.btnExaminar08.Text = "..."
        Me.btnExaminar08.UseVisualStyleBackColor = True
        '
        'txtComprobantesEnviados
        '
        Me.txtComprobantesEnviados.Location = New System.Drawing.Point(178, 165)
        Me.txtComprobantesEnviados.Name = "txtComprobantesEnviados"
        Me.txtComprobantesEnviados.Size = New System.Drawing.Size(376, 20)
        Me.txtComprobantesEnviados.TabIndex = 16
        Me.txtComprobantesEnviados.Text = "C:\Direccion\Enviados"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(14, 168)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(122, 13)
        Me.Label31.TabIndex = 15
        Me.Label31.Text = "Comprobantes Enviados"
        '
        'btnExaminar07
        '
        Me.btnExaminar07.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar07.Location = New System.Drawing.Point(560, 135)
        Me.btnExaminar07.Name = "btnExaminar07"
        Me.btnExaminar07.Size = New System.Drawing.Size(29, 21)
        Me.btnExaminar07.TabIndex = 14
        Me.btnExaminar07.Text = "..."
        Me.btnExaminar07.UseVisualStyleBackColor = True
        '
        'txtcomprobantesContingencia
        '
        Me.txtcomprobantesContingencia.Location = New System.Drawing.Point(178, 136)
        Me.txtcomprobantesContingencia.Name = "txtcomprobantesContingencia"
        Me.txtcomprobantesContingencia.Size = New System.Drawing.Size(376, 20)
        Me.txtcomprobantesContingencia.TabIndex = 13
        Me.txtcomprobantesContingencia.Text = "C:\Direccion\Contingencia"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(14, 139)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(140, 13)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Comprobantes Contingencia"
        '
        'btnExaminar04
        '
        Me.btnExaminar04.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar04.Location = New System.Drawing.Point(560, 105)
        Me.btnExaminar04.Name = "btnExaminar04"
        Me.btnExaminar04.Size = New System.Drawing.Size(29, 21)
        Me.btnExaminar04.TabIndex = 11
        Me.btnExaminar04.Text = "..."
        Me.btnExaminar04.UseVisualStyleBackColor = True
        '
        'btnExaminar03
        '
        Me.btnExaminar03.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar03.Location = New System.Drawing.Point(560, 75)
        Me.btnExaminar03.Name = "btnExaminar03"
        Me.btnExaminar03.Size = New System.Drawing.Size(29, 21)
        Me.btnExaminar03.TabIndex = 10
        Me.btnExaminar03.Text = "..."
        Me.btnExaminar03.UseVisualStyleBackColor = True
        '
        'btnExaminar02
        '
        Me.btnExaminar02.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar02.Location = New System.Drawing.Point(560, 46)
        Me.btnExaminar02.Name = "btnExaminar02"
        Me.btnExaminar02.Size = New System.Drawing.Size(29, 21)
        Me.btnExaminar02.TabIndex = 9
        Me.btnExaminar02.Text = "..."
        Me.btnExaminar02.UseVisualStyleBackColor = True
        '
        'btnExaminar01
        '
        Me.btnExaminar01.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar01.Location = New System.Drawing.Point(560, 15)
        Me.btnExaminar01.Name = "btnExaminar01"
        Me.btnExaminar01.Size = New System.Drawing.Size(29, 21)
        Me.btnExaminar01.TabIndex = 8
        Me.btnExaminar01.Text = "..."
        Me.btnExaminar01.UseVisualStyleBackColor = True
        '
        'txtComprobantesNoautorizados
        '
        Me.txtComprobantesNoautorizados.Location = New System.Drawing.Point(178, 106)
        Me.txtComprobantesNoautorizados.Name = "txtComprobantesNoautorizados"
        Me.txtComprobantesNoautorizados.Size = New System.Drawing.Size(376, 20)
        Me.txtComprobantesNoautorizados.TabIndex = 7
        Me.txtComprobantesNoautorizados.Text = "C:\Direccion\No Autorizados"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Comprobantes No Autorizados"
        '
        'txtComprobantesAutorizados
        '
        Me.txtComprobantesAutorizados.Location = New System.Drawing.Point(178, 76)
        Me.txtComprobantesAutorizados.Name = "txtComprobantesAutorizados"
        Me.txtComprobantesAutorizados.Size = New System.Drawing.Size(376, 20)
        Me.txtComprobantesAutorizados.TabIndex = 5
        Me.txtComprobantesAutorizados.Text = "C:\Direccion\Autorizados"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Comprobantes Autorizados"
        '
        'txtComprobantesFirmados
        '
        Me.txtComprobantesFirmados.Location = New System.Drawing.Point(178, 46)
        Me.txtComprobantesFirmados.Name = "txtComprobantesFirmados"
        Me.txtComprobantesFirmados.Size = New System.Drawing.Size(376, 20)
        Me.txtComprobantesFirmados.TabIndex = 3
        Me.txtComprobantesFirmados.Text = "C:\Direccion\Firmados"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Comprobantes Firmados"
        '
        'txtComprobantesGenerados
        '
        Me.txtComprobantesGenerados.Location = New System.Drawing.Point(178, 16)
        Me.txtComprobantesGenerados.Name = "txtComprobantesGenerados"
        Me.txtComprobantesGenerados.Size = New System.Drawing.Size(376, 20)
        Me.txtComprobantesGenerados.TabIndex = 1
        Me.txtComprobantesGenerados.Text = "C:\Direccion\Generados"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comprobantes Generados"
        '
        'TabAutFirma
        '
        Me.TabAutFirma.Controls.Add(Me.optTipoAmbienteProduccion)
        Me.TabAutFirma.Controls.Add(Me.optTipoAmbientePruebas)
        Me.TabAutFirma.Controls.Add(Me.btnExaminar05)
        Me.TabAutFirma.Controls.Add(Me.txtContraseniaToken)
        Me.TabAutFirma.Controls.Add(Me.txtArchivoP12)
        Me.TabAutFirma.Controls.Add(Me.Label7)
        Me.TabAutFirma.Controls.Add(Me.Label6)
        Me.TabAutFirma.Controls.Add(Me.cmbToken)
        Me.TabAutFirma.Controls.Add(Me.Label5)
        Me.TabAutFirma.Location = New System.Drawing.Point(4, 22)
        Me.TabAutFirma.Name = "TabAutFirma"
        Me.TabAutFirma.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAutFirma.Size = New System.Drawing.Size(656, 207)
        Me.TabAutFirma.TabIndex = 1
        Me.TabAutFirma.Text = "Autenticación Firma"
        Me.TabAutFirma.UseVisualStyleBackColor = True
        '
        'optTipoAmbienteProduccion
        '
        Me.optTipoAmbienteProduccion.AutoSize = True
        Me.optTipoAmbienteProduccion.Location = New System.Drawing.Point(149, 161)
        Me.optTipoAmbienteProduccion.Name = "optTipoAmbienteProduccion"
        Me.optTipoAmbienteProduccion.Size = New System.Drawing.Size(79, 17)
        Me.optTipoAmbienteProduccion.TabIndex = 11
        Me.optTipoAmbienteProduccion.Text = "Producción"
        Me.optTipoAmbienteProduccion.UseVisualStyleBackColor = True
        '
        'optTipoAmbientePruebas
        '
        Me.optTipoAmbientePruebas.AutoSize = True
        Me.optTipoAmbientePruebas.Checked = True
        Me.optTipoAmbientePruebas.Location = New System.Drawing.Point(149, 138)
        Me.optTipoAmbientePruebas.Name = "optTipoAmbientePruebas"
        Me.optTipoAmbientePruebas.Size = New System.Drawing.Size(64, 17)
        Me.optTipoAmbientePruebas.TabIndex = 10
        Me.optTipoAmbientePruebas.TabStop = True
        Me.optTipoAmbientePruebas.Text = "Pruebas"
        Me.optTipoAmbientePruebas.UseVisualStyleBackColor = True
        '
        'btnExaminar05
        '
        Me.btnExaminar05.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar05.Location = New System.Drawing.Point(481, 79)
        Me.btnExaminar05.Name = "btnExaminar05"
        Me.btnExaminar05.Size = New System.Drawing.Size(29, 21)
        Me.btnExaminar05.TabIndex = 9
        Me.btnExaminar05.Text = "..."
        Me.btnExaminar05.UseVisualStyleBackColor = True
        '
        'txtContraseniaToken
        '
        Me.txtContraseniaToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContraseniaToken.Location = New System.Drawing.Point(149, 109)
        Me.txtContraseniaToken.Name = "txtContraseniaToken"
        Me.txtContraseniaToken.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseniaToken.Size = New System.Drawing.Size(326, 22)
        Me.txtContraseniaToken.TabIndex = 5
        '
        'txtArchivoP12
        '
        Me.txtArchivoP12.Location = New System.Drawing.Point(149, 80)
        Me.txtArchivoP12.Name = "txtArchivoP12"
        Me.txtArchivoP12.Size = New System.Drawing.Size(326, 20)
        Me.txtArchivoP12.TabIndex = 4
        Me.txtArchivoP12.Text = "C:\temp\archivo.p12"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Contraseña"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Ubicacion archivo .p12"
        '
        'cmbToken
        '
        Me.cmbToken.FormattingEnabled = True
        Me.cmbToken.Items.AddRange(New Object() {"AFN - Certificado x.509 en formato p12", "BCE - Aladdin eToken Pro"})
        Me.cmbToken.Location = New System.Drawing.Point(149, 26)
        Me.cmbToken.Name = "cmbToken"
        Me.cmbToken.Size = New System.Drawing.Size(238, 21)
        Me.cmbToken.TabIndex = 1
        Me.cmbToken.Text = "AFN - Certificado x.509 en formato p12"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Token para firmar"
        '
        'TabCompFirmados
        '
        Me.TabCompFirmados.Controls.Add(Me.lstListaFTP)
        Me.TabCompFirmados.Controls.Add(Me.lstReEnviarCorreo)
        Me.TabCompFirmados.Controls.Add(Me.btnReenviarComprobantes)
        Me.TabCompFirmados.Controls.Add(Me.btnCargarClaves)
        Me.TabCompFirmados.Controls.Add(Me.btnExaminar06)
        Me.TabCompFirmados.Controls.Add(Me.txtClaveContingencia)
        Me.TabCompFirmados.Controls.Add(Me.Label16)
        Me.TabCompFirmados.Controls.Add(Me.lstListaComprobantes)
        Me.TabCompFirmados.Location = New System.Drawing.Point(4, 22)
        Me.TabCompFirmados.Name = "TabCompFirmados"
        Me.TabCompFirmados.Size = New System.Drawing.Size(656, 207)
        Me.TabCompFirmados.TabIndex = 2
        Me.TabCompFirmados.Text = "Claves Contingencia"
        Me.TabCompFirmados.UseVisualStyleBackColor = True
        '
        'lstListaFTP
        '
        Me.lstListaFTP.Location = New System.Drawing.Point(622, 80)
        Me.lstListaFTP.Name = "lstListaFTP"
        Me.lstListaFTP.Size = New System.Drawing.Size(34, 34)
        Me.lstListaFTP.TabIndex = 16
        Me.lstListaFTP.UseCompatibleStateImageBehavior = False
        Me.lstListaFTP.Visible = False
        '
        'lstReEnviarCorreo
        '
        Me.lstReEnviarCorreo.Location = New System.Drawing.Point(622, 40)
        Me.lstReEnviarCorreo.Name = "lstReEnviarCorreo"
        Me.lstReEnviarCorreo.Size = New System.Drawing.Size(34, 34)
        Me.lstReEnviarCorreo.TabIndex = 15
        Me.lstReEnviarCorreo.UseCompatibleStateImageBehavior = False
        Me.lstReEnviarCorreo.Visible = False
        '
        'btnReenviarComprobantes
        '
        Me.btnReenviarComprobantes.Location = New System.Drawing.Point(17, 139)
        Me.btnReenviarComprobantes.Name = "btnReenviarComprobantes"
        Me.btnReenviarComprobantes.Size = New System.Drawing.Size(198, 25)
        Me.btnReenviarComprobantes.TabIndex = 14
        Me.btnReenviarComprobantes.Text = "Reenviar Comprobantes Contingencia"
        Me.btnReenviarComprobantes.UseVisualStyleBackColor = True
        '
        'btnCargarClaves
        '
        Me.btnCargarClaves.Location = New System.Drawing.Point(179, 67)
        Me.btnCargarClaves.Name = "btnCargarClaves"
        Me.btnCargarClaves.Size = New System.Drawing.Size(107, 25)
        Me.btnCargarClaves.TabIndex = 13
        Me.btnCargarClaves.Text = "Cargar Claves"
        Me.btnCargarClaves.UseVisualStyleBackColor = True
        '
        'btnExaminar06
        '
        Me.btnExaminar06.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar06.Location = New System.Drawing.Point(513, 34)
        Me.btnExaminar06.Name = "btnExaminar06"
        Me.btnExaminar06.Size = New System.Drawing.Size(29, 21)
        Me.btnExaminar06.TabIndex = 12
        Me.btnExaminar06.Text = "..."
        Me.btnExaminar06.UseVisualStyleBackColor = True
        '
        'txtClaveContingencia
        '
        Me.txtClaveContingencia.Enabled = False
        Me.txtClaveContingencia.Location = New System.Drawing.Point(181, 35)
        Me.txtClaveContingencia.Name = "txtClaveContingencia"
        Me.txtClaveContingencia.Size = New System.Drawing.Size(326, 20)
        Me.txtClaveContingencia.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(57, 38)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Claves Contingencia"
        '
        'lstListaComprobantes
        '
        Me.lstListaComprobantes.Location = New System.Drawing.Point(622, 0)
        Me.lstListaComprobantes.Name = "lstListaComprobantes"
        Me.lstListaComprobantes.Size = New System.Drawing.Size(34, 34)
        Me.lstListaComprobantes.TabIndex = 0
        Me.lstListaComprobantes.UseCompatibleStateImageBehavior = False
        Me.lstListaComprobantes.Visible = False
        '
        'tabServidorCorreo
        '
        Me.tabServidorCorreo.Controls.Add(Me.txtUsuarioCorreo)
        Me.tabServidorCorreo.Controls.Add(Me.Label30)
        Me.tabServidorCorreo.Controls.Add(Me.txtEnviarCopia)
        Me.tabServidorCorreo.Controls.Add(Me.Label28)
        Me.tabServidorCorreo.Controls.Add(Me.txtMensaje)
        Me.tabServidorCorreo.Controls.Add(Me.Label13)
        Me.tabServidorCorreo.Controls.Add(Me.txtAsunto)
        Me.tabServidorCorreo.Controls.Add(Me.Label12)
        Me.tabServidorCorreo.Controls.Add(Me.chkConexionSegura)
        Me.tabServidorCorreo.Controls.Add(Me.txtContrasenaCorreo)
        Me.tabServidorCorreo.Controls.Add(Me.Label11)
        Me.tabServidorCorreo.Controls.Add(Me.txtNombreUsuario)
        Me.tabServidorCorreo.Controls.Add(Me.Label10)
        Me.tabServidorCorreo.Controls.Add(Me.txtServidorCorreo)
        Me.tabServidorCorreo.Controls.Add(Me.Label9)
        Me.tabServidorCorreo.Controls.Add(Me.txtPuerto)
        Me.tabServidorCorreo.Controls.Add(Me.Label8)
        Me.tabServidorCorreo.Location = New System.Drawing.Point(4, 22)
        Me.tabServidorCorreo.Name = "tabServidorCorreo"
        Me.tabServidorCorreo.Size = New System.Drawing.Size(656, 207)
        Me.tabServidorCorreo.TabIndex = 3
        Me.tabServidorCorreo.Text = "Servidor Correo"
        Me.tabServidorCorreo.UseVisualStyleBackColor = True
        '
        'txtUsuarioCorreo
        '
        Me.txtUsuarioCorreo.Location = New System.Drawing.Point(139, 123)
        Me.txtUsuarioCorreo.Name = "txtUsuarioCorreo"
        Me.txtUsuarioCorreo.Size = New System.Drawing.Size(183, 20)
        Me.txtUsuarioCorreo.TabIndex = 16
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(24, 126)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(98, 13)
        Me.Label30.TabIndex = 15
        Me.Label30.Text = "Nombre de Usuario"
        '
        'txtEnviarCopia
        '
        Me.txtEnviarCopia.Location = New System.Drawing.Point(139, 150)
        Me.txtEnviarCopia.Name = "txtEnviarCopia"
        Me.txtEnviarCopia.Size = New System.Drawing.Size(183, 20)
        Me.txtEnviarCopia.TabIndex = 14
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(24, 153)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(67, 13)
        Me.Label28.TabIndex = 13
        Me.Label28.Text = "Enviar Copia"
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(368, 61)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMensaje.Size = New System.Drawing.Size(272, 138)
        Me.txtMensaje.TabIndex = 12
        Me.txtMensaje.Text = "Envío de Comprobante Electrónico"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(365, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Mensaje"
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(438, 11)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(202, 20)
        Me.txtAsunto.TabIndex = 10
        Me.txtAsunto.Text = "Comprobantes Electronicos"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(365, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Asunto"
        '
        'chkConexionSegura
        '
        Me.chkConexionSegura.AutoSize = True
        Me.chkConexionSegura.Location = New System.Drawing.Point(139, 182)
        Me.chkConexionSegura.Name = "chkConexionSegura"
        Me.chkConexionSegura.Size = New System.Drawing.Size(107, 17)
        Me.chkConexionSegura.TabIndex = 8
        Me.chkConexionSegura.Text = "Conexión Segura"
        Me.chkConexionSegura.UseVisualStyleBackColor = True
        '
        'txtContrasenaCorreo
        '
        Me.txtContrasenaCorreo.Location = New System.Drawing.Point(139, 95)
        Me.txtContrasenaCorreo.Name = "txtContrasenaCorreo"
        Me.txtContrasenaCorreo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasenaCorreo.Size = New System.Drawing.Size(183, 20)
        Me.txtContrasenaCorreo.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(24, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Contraseña"
        '
        'txtNombreUsuario
        '
        Me.txtNombreUsuario.Location = New System.Drawing.Point(139, 68)
        Me.txtNombreUsuario.Name = "txtNombreUsuario"
        Me.txtNombreUsuario.Size = New System.Drawing.Size(183, 20)
        Me.txtNombreUsuario.TabIndex = 5
        Me.txtNombreUsuario.Text = "info@ibzssoft.com"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Dirección Correo"
        '
        'txtServidorCorreo
        '
        Me.txtServidorCorreo.Location = New System.Drawing.Point(139, 41)
        Me.txtServidorCorreo.Name = "txtServidorCorreo"
        Me.txtServidorCorreo.Size = New System.Drawing.Size(183, 20)
        Me.txtServidorCorreo.TabIndex = 3
        Me.txtServidorCorreo.Text = "mail.name.com"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Servidor de Correo"
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(139, 14)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(65, 20)
        Me.txtPuerto.TabIndex = 1
        Me.txtPuerto.Text = "25"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Protocolo SMTP"
        '
        'TabConfBaseDatos
        '
        Me.TabConfBaseDatos.Controls.Add(Me.TabControl2)
        Me.TabConfBaseDatos.Location = New System.Drawing.Point(4, 22)
        Me.TabConfBaseDatos.Name = "TabConfBaseDatos"
        Me.TabConfBaseDatos.Size = New System.Drawing.Size(656, 207)
        Me.TabConfBaseDatos.TabIndex = 4
        Me.TabConfBaseDatos.Text = "Configurar Sistema"
        Me.TabConfBaseDatos.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tbpBDPrincipal)
        Me.TabControl2.Controls.Add(Me.tbpBDSecundaria)
        Me.TabControl2.Controls.Add(Me.tbpOpcionesAvanzadas)
        Me.TabControl2.Location = New System.Drawing.Point(13, 10)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(625, 180)
        Me.TabControl2.TabIndex = 4
        '
        'tbpBDPrincipal
        '
        Me.tbpBDPrincipal.Controls.Add(Me.PictureBox2)
        Me.tbpBDPrincipal.Controls.Add(Me.Label19)
        Me.tbpBDPrincipal.Controls.Add(Me.txtContrasenaBDP)
        Me.tbpBDPrincipal.Controls.Add(Me.Label18)
        Me.tbpBDPrincipal.Controls.Add(Me.txtNombreUsuarioBDP)
        Me.tbpBDPrincipal.Controls.Add(Me.txtBaseDatosP)
        Me.tbpBDPrincipal.Controls.Add(Me.Label21)
        Me.tbpBDPrincipal.Controls.Add(Me.txtServidorBDP)
        Me.tbpBDPrincipal.Controls.Add(Me.Label20)
        Me.tbpBDPrincipal.Location = New System.Drawing.Point(4, 22)
        Me.tbpBDPrincipal.Name = "tbpBDPrincipal"
        Me.tbpBDPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpBDPrincipal.Size = New System.Drawing.Size(617, 154)
        Me.tbpBDPrincipal.TabIndex = 0
        Me.tbpBDPrincipal.Text = "Base Datos Principal"
        Me.tbpBDPrincipal.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(85, 61)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(377, 89)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 13)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Password"
        '
        'txtContrasenaBDP
        '
        Me.txtContrasenaBDP.Location = New System.Drawing.Point(436, 86)
        Me.txtContrasenaBDP.Name = "txtContrasenaBDP"
        Me.txtContrasenaBDP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasenaBDP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContrasenaBDP.Size = New System.Drawing.Size(154, 20)
        Me.txtContrasenaBDP.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(116, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Username"
        '
        'txtNombreUsuarioBDP
        '
        Me.txtNombreUsuarioBDP.Location = New System.Drawing.Point(177, 86)
        Me.txtNombreUsuarioBDP.Name = "txtNombreUsuarioBDP"
        Me.txtNombreUsuarioBDP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombreUsuarioBDP.Size = New System.Drawing.Size(154, 20)
        Me.txtNombreUsuarioBDP.TabIndex = 4
        '
        'txtBaseDatosP
        '
        Me.txtBaseDatosP.Location = New System.Drawing.Point(436, 43)
        Me.txtBaseDatosP.Name = "txtBaseDatosP"
        Me.txtBaseDatosP.Size = New System.Drawing.Size(154, 20)
        Me.txtBaseDatosP.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(353, 46)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Base de Datos"
        '
        'txtServidorBDP
        '
        Me.txtServidorBDP.Location = New System.Drawing.Point(177, 43)
        Me.txtServidorBDP.Name = "txtServidorBDP"
        Me.txtServidorBDP.Size = New System.Drawing.Size(154, 20)
        Me.txtServidorBDP.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(125, 46)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Servidor"
        '
        'tbpBDSecundaria
        '
        Me.tbpBDSecundaria.Controls.Add(Me.PictureBox3)
        Me.tbpBDSecundaria.Controls.Add(Me.Label22)
        Me.tbpBDSecundaria.Controls.Add(Me.txtContrasenaBDS)
        Me.tbpBDSecundaria.Controls.Add(Me.Label23)
        Me.tbpBDSecundaria.Controls.Add(Me.txtNombreUsuarioBDS)
        Me.tbpBDSecundaria.Controls.Add(Me.txtBaseDatosS)
        Me.tbpBDSecundaria.Controls.Add(Me.Label24)
        Me.tbpBDSecundaria.Controls.Add(Me.txtServidorBDS)
        Me.tbpBDSecundaria.Controls.Add(Me.Label25)
        Me.tbpBDSecundaria.Location = New System.Drawing.Point(4, 22)
        Me.tbpBDSecundaria.Name = "tbpBDSecundaria"
        Me.tbpBDSecundaria.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpBDSecundaria.Size = New System.Drawing.Size(617, 154)
        Me.tbpBDSecundaria.TabIndex = 1
        Me.tbpBDSecundaria.Text = "Base Datos Secundaria"
        Me.tbpBDSecundaria.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(85, 61)
        Me.PictureBox3.TabIndex = 16
        Me.PictureBox3.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(377, 89)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 13)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "Password"
        '
        'txtContrasenaBDS
        '
        Me.txtContrasenaBDS.Location = New System.Drawing.Point(436, 86)
        Me.txtContrasenaBDS.Name = "txtContrasenaBDS"
        Me.txtContrasenaBDS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasenaBDS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContrasenaBDS.Size = New System.Drawing.Size(154, 20)
        Me.txtContrasenaBDS.TabIndex = 14
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(116, 89)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 13)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "Username"
        '
        'txtNombreUsuarioBDS
        '
        Me.txtNombreUsuarioBDS.Location = New System.Drawing.Point(177, 86)
        Me.txtNombreUsuarioBDS.Name = "txtNombreUsuarioBDS"
        Me.txtNombreUsuarioBDS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombreUsuarioBDS.Size = New System.Drawing.Size(154, 20)
        Me.txtNombreUsuarioBDS.TabIndex = 12
        '
        'txtBaseDatosS
        '
        Me.txtBaseDatosS.Location = New System.Drawing.Point(436, 43)
        Me.txtBaseDatosS.Name = "txtBaseDatosS"
        Me.txtBaseDatosS.Size = New System.Drawing.Size(154, 20)
        Me.txtBaseDatosS.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(353, 46)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "Base de Datos"
        '
        'txtServidorBDS
        '
        Me.txtServidorBDS.Location = New System.Drawing.Point(177, 43)
        Me.txtServidorBDS.Name = "txtServidorBDS"
        Me.txtServidorBDS.Size = New System.Drawing.Size(154, 20)
        Me.txtServidorBDS.TabIndex = 9
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(125, 46)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 13)
        Me.Label25.TabIndex = 8
        Me.Label25.Text = "Servidor"
        '
        'tbpOpcionesAvanzadas
        '
        Me.tbpOpcionesAvanzadas.Controls.Add(Me.Label29)
        Me.tbpOpcionesAvanzadas.Controls.Add(Me.dtpHoraEnvio)
        Me.tbpOpcionesAvanzadas.Controls.Add(Me.chkIniciarConWindows)
        Me.tbpOpcionesAvanzadas.Controls.Add(Me.chkIniciarAplicacion)
        Me.tbpOpcionesAvanzadas.Controls.Add(Me.Label15)
        Me.tbpOpcionesAvanzadas.Controls.Add(Me.nudNumActualiza)
        Me.tbpOpcionesAvanzadas.Controls.Add(Me.Label14)
        Me.tbpOpcionesAvanzadas.Controls.Add(Me.GroupBox1)
        Me.tbpOpcionesAvanzadas.Location = New System.Drawing.Point(4, 22)
        Me.tbpOpcionesAvanzadas.Name = "tbpOpcionesAvanzadas"
        Me.tbpOpcionesAvanzadas.Size = New System.Drawing.Size(617, 154)
        Me.tbpOpcionesAvanzadas.TabIndex = 2
        Me.tbpOpcionesAvanzadas.Text = "Opciones Avanzadas"
        Me.tbpOpcionesAvanzadas.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(378, 99)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(94, 13)
        Me.Label29.TabIndex = 11
        Me.Label29.Text = "Hora Envió Correo"
        '
        'dtpHoraEnvio
        '
        Me.dtpHoraEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraEnvio.Location = New System.Drawing.Point(506, 93)
        Me.dtpHoraEnvio.Name = "dtpHoraEnvio"
        Me.dtpHoraEnvio.ShowUpDown = True
        Me.dtpHoraEnvio.Size = New System.Drawing.Size(74, 20)
        Me.dtpHoraEnvio.TabIndex = 10
        '
        'chkIniciarConWindows
        '
        Me.chkIniciarConWindows.AutoSize = True
        Me.chkIniciarConWindows.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIniciarConWindows.Location = New System.Drawing.Point(381, 70)
        Me.chkIniciarConWindows.Name = "chkIniciarConWindows"
        Me.chkIniciarConWindows.Size = New System.Drawing.Size(141, 17)
        Me.chkIniciarConWindows.TabIndex = 9
        Me.chkIniciarConWindows.Text = "Iniciar con MS Windows"
        Me.chkIniciarConWindows.UseVisualStyleBackColor = True
        '
        'chkIniciarAplicacion
        '
        Me.chkIniciarAplicacion.AutoSize = True
        Me.chkIniciarAplicacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIniciarAplicacion.Location = New System.Drawing.Point(381, 47)
        Me.chkIniciarAplicacion.Name = "chkIniciarAplicacion"
        Me.chkIniciarAplicacion.Size = New System.Drawing.Size(141, 17)
        Me.chkIniciarAplicacion.TabIndex = 8
        Me.chkIniciarAplicacion.Text = "Iniciar con la Aplicación "
        Me.chkIniciarAplicacion.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(573, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Seg."
        '
        'nudNumActualiza
        '
        Me.nudNumActualiza.Location = New System.Drawing.Point(506, 21)
        Me.nudNumActualiza.Name = "nudNumActualiza"
        Me.nudNumActualiza.Size = New System.Drawing.Size(54, 20)
        Me.nudNumActualiza.TabIndex = 6
        Me.nudNumActualiza.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(378, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(118, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Verificar archivos cada:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.txtPuertoProxy)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txtDireccionProxy)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.chkUtilizarProxy)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(347, 129)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configurar servidor Proxy"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(21, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'txtPuertoProxy
        '
        Me.txtPuertoProxy.Enabled = False
        Me.txtPuertoProxy.Location = New System.Drawing.Point(163, 98)
        Me.txtPuertoProxy.Name = "txtPuertoProxy"
        Me.txtPuertoProxy.Size = New System.Drawing.Size(44, 20)
        Me.txtPuertoProxy.TabIndex = 4
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(119, 101)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(38, 13)
        Me.Label27.TabIndex = 3
        Me.Label27.Text = "Puerto"
        '
        'txtDireccionProxy
        '
        Me.txtDireccionProxy.Enabled = False
        Me.txtDireccionProxy.Location = New System.Drawing.Point(163, 69)
        Me.txtDireccionProxy.Name = "txtDireccionProxy"
        Me.txtDireccionProxy.Size = New System.Drawing.Size(166, 20)
        Me.txtDireccionProxy.TabIndex = 2
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(105, 72)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(52, 13)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "Dirección"
        '
        'chkUtilizarProxy
        '
        Me.chkUtilizarProxy.AutoSize = True
        Me.chkUtilizarProxy.Location = New System.Drawing.Point(108, 33)
        Me.chkUtilizarProxy.Name = "chkUtilizarProxy"
        Me.chkUtilizarProxy.Size = New System.Drawing.Size(125, 17)
        Me.chkUtilizarProxy.TabIndex = 0
        Me.chkUtilizarProxy.Text = "Utilizar servidor proxy"
        Me.chkUtilizarProxy.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(19, 252)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(125, 25)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'tmrActualizaLista
        '
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(159, 252)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(125, 25)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnFirmarEnviar
        '
        Me.btnFirmarEnviar.Location = New System.Drawing.Point(300, 252)
        Me.btnFirmarEnviar.Name = "btnFirmarEnviar"
        Me.btnFirmarEnviar.Size = New System.Drawing.Size(125, 25)
        Me.btnFirmarEnviar.TabIndex = 14
        Me.btnFirmarEnviar.Text = "Iniciar"
        Me.btnFirmarEnviar.UseVisualStyleBackColor = True
        '
        'ntfAreaNotificacion
        '
        Me.ntfAreaNotificacion.Text = "NotifyIcon1"
        Me.ntfAreaNotificacion.Visible = True
        '
        'Administracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 291)
        Me.Controls.Add(Me.btnFirmarEnviar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Administracion"
        Me.Text = "Ishida & Asociados :: Firmar y Enviar SRI"
        Me.TabControl1.ResumeLayout(False)
        Me.tabDirectorios.ResumeLayout(False)
        Me.tabDirectorios.PerformLayout()
        Me.TabAutFirma.ResumeLayout(False)
        Me.TabAutFirma.PerformLayout()
        Me.TabCompFirmados.ResumeLayout(False)
        Me.TabCompFirmados.PerformLayout()
        Me.tabServidorCorreo.ResumeLayout(False)
        Me.tabServidorCorreo.PerformLayout()
        Me.TabConfBaseDatos.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.tbpBDPrincipal.ResumeLayout(False)
        Me.tbpBDPrincipal.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpBDSecundaria.ResumeLayout(False)
        Me.tbpBDSecundaria.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpOpcionesAvanzadas.ResumeLayout(False)
        Me.tbpOpcionesAvanzadas.PerformLayout()
        CType(Me.nudNumActualiza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabDirectorios As System.Windows.Forms.TabPage
    Friend WithEvents TabAutFirma As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComprobantesNoautorizados As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtComprobantesAutorizados As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtComprobantesFirmados As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComprobantesGenerados As System.Windows.Forms.TextBox
    Friend WithEvents btnExaminar04 As System.Windows.Forms.Button
    Friend WithEvents btnExaminar03 As System.Windows.Forms.Button
    Friend WithEvents btnExaminar02 As System.Windows.Forms.Button
    Friend WithEvents btnExaminar01 As System.Windows.Forms.Button
    Friend WithEvents btnExaminar05 As System.Windows.Forms.Button
    Friend WithEvents txtContraseniaToken As System.Windows.Forms.TextBox
    Friend WithEvents txtArchivoP12 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbToken As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents TabCompFirmados As System.Windows.Forms.TabPage
    Friend WithEvents lstListaComprobantes As System.Windows.Forms.ListView
    Friend WithEvents tmrActualizaLista As System.Windows.Forms.Timer
    Friend WithEvents tabServidorCorreo As System.Windows.Forms.TabPage
    Friend WithEvents optTipoAmbienteProduccion As System.Windows.Forms.RadioButton
    Friend WithEvents optTipoAmbientePruebas As System.Windows.Forms.RadioButton
    Friend WithEvents txtServidorCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPuerto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkConexionSegura As System.Windows.Forms.CheckBox
    Friend WithEvents txtContrasenaCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNombreUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnFirmarEnviar As System.Windows.Forms.Button
    Friend WithEvents btnCargarClaves As System.Windows.Forms.Button
    Friend WithEvents btnExaminar06 As System.Windows.Forms.Button
    Friend WithEvents txtClaveContingencia As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnExaminar07 As System.Windows.Forms.Button
    Friend WithEvents txtcomprobantesContingencia As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnReenviarComprobantes As System.Windows.Forms.Button
    Friend WithEvents TabConfBaseDatos As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tbpBDPrincipal As System.Windows.Forms.TabPage
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtContrasenaBDP As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNombreUsuarioBDP As System.Windows.Forms.TextBox
    Friend WithEvents txtBaseDatosP As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtServidorBDP As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbpBDSecundaria As System.Windows.Forms.TabPage
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtContrasenaBDS As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtNombreUsuarioBDS As System.Windows.Forms.TextBox
    Friend WithEvents txtBaseDatosS As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtServidorBDS As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents tbpOpcionesAvanzadas As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDireccionProxy As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents chkUtilizarProxy As System.Windows.Forms.CheckBox
    Friend WithEvents txtPuertoProxy As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents nudNumActualiza As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkIniciarAplicacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkIniciarConWindows As System.Windows.Forms.CheckBox
    Friend WithEvents ntfAreaNotificacion As System.Windows.Forms.NotifyIcon
    Friend WithEvents txtEnviarCopia As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lstReEnviarCorreo As System.Windows.Forms.ListView
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents dtpHoraEnvio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lstListaFTP As System.Windows.Forms.ListView
    Friend WithEvents txtUsuarioCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btnExaminar08 As System.Windows.Forms.Button
    Friend WithEvents txtComprobantesEnviados As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
End Class
