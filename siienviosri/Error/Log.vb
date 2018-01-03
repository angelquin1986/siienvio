Public Class Log
    Private strNomFunc As String
    Private strMensaje As String
    Private strMenSyst As String
    Private strDircLog As String

    Public Property NombreFuncion() As String
        Get
            Return strNomFunc
        End Get
        Set(ByVal value As String)
            strNomFunc = value
        End Set
    End Property

    Public Property MensajeError() As String
        Get
            Return strMensaje
        End Get
        Set(ByVal value As String)
            strMensaje = value
            EscribirLog()
        End Set
    End Property

    Public Property SistemaError() As String
        Get
            Return strMenSyst
        End Get
        Set(ByVal value As String)
            strMenSyst = value
        End Set
    End Property

    Public Property ArchivoLog() As String
        Get
            Return strDircLog
        End Get
        Set(ByVal value As String)
            strDircLog = value
        End Set
    End Property

    Private Sub EscribirLog()
        Dim MensajeError As String = ""
        Dim Archivo As New Archivo

        If strDircLog = "" Then
            strDircLog = "logEnvioSRI.log"
        End If

        MensajeError = strNomFunc & " :: " & strMensaje & vbLf & strMenSyst & vbLf + _
            System.DateTime.Now + vbLf & "==="
        Archivo.GuardarArchivoTexto(strDircLog, MensajeError, True)
    End Sub
End Class
