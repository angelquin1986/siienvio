Imports System.Net.Mail
Imports System.Net
Imports System.IO

''' <summary>
''' Permite el envio de correo-e a un destinatario
''' </summary>
''' <remarks>
''' transmite el correo electrónico al host SMTP que se designe para la entrega 
''' del correo. Puede crear datos adjuntos del mensaje
''' </remarks>
Public Class EnviarCorreoE
    Dim _Message As New MailMessage()
    Dim _SMTP As SmtpClient

    ''' <summary>
    ''' Configuración servidor SMTP para el envio de Correo-E
    ''' </summary>
    ''' <remarks>
    ''' Especificamos los parametros para configurar el servidor 
    ''' SMTP, también el encabezado y cuerpo del mensaje
    ''' </remarks>
    Private _intPuerto As UShort = 0
    Private _strServidorCorreo As String = ""
    Private _strUsuario As String = ""
    Private _strContrasena As String = ""
    Private _blnConexionCifradaSLL As Boolean = False
    Private _Porxy As Boolean = False

    ''' <summary>
    ''' Datos necesarios para el envío de correo-e
    ''' </summary>
    ''' <remarks>Especifica los datos necesarios para el encabezado y cuerpo del mensaje</remarks>
    Private _strDe As String = ""
    Private _strPara As String = ""
    Private _strAsunto As String = ""
    Private _blnBodyHtml As Boolean = False
    Private _strMensaje As String = ""
    Private _strArchivo01 As String = ""
    Private _strArchivo02 As String = ""
    Private _strCC As String = ""
    Private _strUsuarioSesion As String = ""

    ''' <summary>
    ''' Establece el puerto de red para comunicarse con el Servidor
    ''' </summary>
    ''' <value>Valor númerico que identifica el puerto de red</value>
    ''' <returns>Devuelve el número del puerto de red establecido</returns>
    ''' <remarks>Un puerto de red es una interfaz para comunicarse con un programa a través de una red</remarks>
    Public Property Puerto() As UShort
        Get
            Return _intPuerto
        End Get
        Set(ByVal value As UShort)
            _intPuerto = value
        End Set
    End Property

    ''' <summary>
    ''' Establece el servidor que permite la transferencia de correo
    ''' </summary>
    ''' <value>Corresponde a la dirección que identifica al servidor de correo</value>
    ''' <returns>Devuelve La dirección del servidor de correo establecida</returns>
    ''' <remarks>Un servidor de correo es una aplicación de red ubicada en un servidor en internet</remarks>
    Public Property ServidorCorreo() As String
        Get
            Return _strServidorCorreo
        End Get
        Set(ByVal value As String)
            _strServidorCorreo = value
        End Set
    End Property

    ''' <summary>
    ''' Establece el usuario que se encarga del envío de correo atreves del servidor
    ''' </summary>
    ''' <value>Corresponde a una dirección de correo valida</value>
    ''' <returns>Devuelve la dirección de correo establecida</returns>
    ''' <remarks>Un usuario de correo representa a alguien que tiene un identificador de usuario de la organización</remarks>
    Public Property Usuario() As String
        Get
            Return _strUsuario
        End Get
        Set(ByVal value As String)
            _strUsuario = value
        End Set
    End Property

    ''' <summary>
    ''' Establece la contraseña que corresponde al usuario de correo electrónico
    ''' </summary>
    ''' <returns>Devuelve la contraseña del usuario de correo electrónico</returns>
    Public Property Contrasena() As String
        Get
            Return _strContrasena
        End Get
        Set(ByVal value As String)
            _strContrasena = value
        End Set
    End Property

    ''' <summary>
    ''' El servidor de correo precisa una conexión cifrada SSL
    ''' </summary>
    ''' <value>Establece TRUE para activar la conexión cifrada</value>
    ''' <returns>Devuelve valor boolean sobre el estado de la conexion cifrada</returns>
    ''' <remarks>Es un protocolo criptográfico que proporciona comunicacion segura por una red</remarks>
    Public Property ConexionCifrada() As Boolean
        Get
            Return _blnConexionCifradaSLL
        End Get
        Set(ByVal value As Boolean)
            _blnConexionCifradaSLL = value
        End Set
    End Property

    '----------------- Cabecera y Cuerpo del Mensaje --------------------

    ''' <summary>
    ''' Usuario de correo electrónico del remitente
    ''' </summary>
    ''' <value>Corresponde a una dirección de correo electrónico</value>
    ''' <returns>Devuelve la dirección de correo del remitente</returns>
    ''' <remarks>Corresponde al correo electrónico del remitente</remarks>
    'Public Property De() As String
    '    Get
    '        Return _strDe
    '    End Get
    '    Private Set(ByVal value As String)
    '        _strDe = value
    '    End Set
    'End Property

    Public Property Para() As String
        Get
            Return _strPara
        End Get
        Set(ByVal value As String)
            _strPara = value
        End Set
    End Property

    Public Property CC() As String
        Get
            Return _strCC
        End Get
        Set(ByVal value As String)
            _strCC = value
        End Set
    End Property

    Public Property Asunto() As String
        Get
            Return _strAsunto
        End Get
        Set(ByVal value As String)
            _strAsunto = value
        End Set
    End Property

    Public Property MensajeHTML() As Boolean
        Get
            Return _blnBodyHtml
        End Get
        Set(ByVal value As Boolean)
            _blnBodyHtml = value
        End Set
    End Property

    Public Property Mensaje() As String
        Get
            Return _strMensaje
        End Get
        Set(ByVal value As String)
            _strMensaje = value
        End Set
    End Property

    Public Property AdjuntarArchivoXML() As String
        Get
            Return _strArchivo01
        End Get
        Set(ByVal value As String)
            _strArchivo01 = value
        End Set
    End Property

    Public Property AdjuntarArchivoPDF() As String
        Get
            Return _strArchivo02
        End Get
        Set(ByVal value As String)
            _strArchivo02 = value
        End Set
    End Property

    Public Property Proxy() As Boolean
        Get
            Return _Porxy
        End Get
        Set(ByVal value As Boolean)
            _Porxy = value
        End Set
    End Property

    Public Property UsuarioSesion() As String
        Get
            Return _strUsuarioSesion
        End Get
        Set(value As String)
            _strUsuarioSesion = value
        End Set
    End Property

    '----------------- Configuración de servidor STMP --------------------
    Private Sub SMTP()
        If _Porxy = True Then
            Dim PXY As New UsarProxy
            _SMTP = New SmtpClient(PXY.Servidor, PXY.Puerto)
        Else
            _SMTP = New SmtpClient()
        End If

        With _SMTP
            .Credentials = New NetworkCredential(_strUsuarioSesion, _strContrasena)
            '.UseDefaultCredentials = True
            .Host = _strServidorCorreo
            .Port = _intPuerto
            .EnableSsl = _blnConexionCifradaSLL
        End With
    End Sub

    Public Function Enviar() As Boolean
        Dim datos As New Datos
        Dim strXMLRelativo As String = ""
        'strXMLRelativo = ArchivoRelativo
        Dim RazonSocial As String = datos.RecuperarRazonSocialCorreo(strArchivoRelativoXML)
        Dim AdjuntoXML As Attachment
        Dim AdjuntoPDF As Attachment

        Try
            With _Message
                .To.Add(_strPara) 'Cuenta de Correo al que se le quiere enviar el e-mail
                .From = New MailAddress(_strUsuario, RazonSocial, System.Text.Encoding.UTF8) 'Quien lo envía
                .Subject = _strAsunto 'Sujeto del e-mail
                .SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                .Body = _strMensaje 'contenido del mail
                .BodyEncoding = System.Text.Encoding.UTF8
                .Priority = MailPriority.Normal
                .IsBodyHtml = _blnBodyHtml
                If _strCC <> "" Then
                    Dim copy = New MailAddress(_strCC, "RIDE Enviado", System.Text.Encoding.UTF8)
                    .CC.Add(copy) 'Envia copia del correo
                End If
                If _strArchivo01 <> "" And File.Exists(_strArchivo01) = True Then
                    AdjuntoXML = New Attachment(_strArchivo01)
                    .Attachments.Add(AdjuntoXML)
                End If
                If _strArchivo02 <> "" And File.Exists(_strArchivo02) = True Then
                    AdjuntoPDF = New Attachment(_strArchivo02)
                    .Attachments.Add(AdjuntoPDF)
                End If
            End With

            SMTP()
            _SMTP.Send(_Message)
            _Message.Dispose()

            Return True
        Catch ex As SmtpException
            Dim err As New Log
            err.NombreFuncion = "EnviarCorreoE.Enviar"
            err.SistemaError = ex.Message
            err.MensajeError = "Correo no enviado"
            Return False
        Catch ex As System.FormatException
            Dim err As New Log
            err.NombreFuncion = "EnviarCorreoE.Enviar"
            err.SistemaError = ex.Message
            err.MensajeError = "Correo no enviado"
            Return False
        End Try
    End Function
End Class
