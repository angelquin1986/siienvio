
Public Class FirmarXML
    Private strArchivoP12 As String = ""
    Private strContrasenaToken As String = ""
    Private strGenerados As String = ""
    Private strFirmados As String = ""
    Private strArchivoXML As String = ""
    Private strArchivoFirmado As String = ""
    Private archivo As Archivo

    Sub New(ByVal archivo As Archivo)
        Me.archivo = archivo
    End Sub

    Sub New()

    End Sub

    Public Property ArchivoP12() As String
        Get
            Return strArchivoP12
        End Get
        Set(ByVal value As String)
            strArchivoP12 = value
        End Set
    End Property

    Public Property ContrasenaToken() As String
        Get
            Return strContrasenaToken
        End Get
        Set(ByVal value As String)
            strContrasenaToken = value
        End Set
    End Property

    Public Property DirectorioGenerados() As String
        Get
            Return strGenerados
        End Get
        Set(ByVal value As String)
            strGenerados = value
        End Set
    End Property

    Public Property DirectorioFirmados() As String
        Get
            Return strFirmados
        End Get
        Set(ByVal value As String)
            strFirmados = value
        End Set
    End Property

    Public Property ArchivoXMLGenerado() As String
        Get
            Return strArchivoXML
        End Get
        Set(ByVal value As String)
            strArchivoXML = value
        End Set
    End Property

    Public ReadOnly Property ArchivoXMLFirmado() As String
        Get
            Return strArchivoFirmado
        End Get
    End Property

    Private Function establecerParametros() As String
        strArchivoFirmado = strFirmados & "\" & strArchivoXML
        '---------------------------------------------------------------------------
        Return strArchivoP12 & " " & _
            strContrasenaToken & " " & _
            strGenerados & "\" & strArchivoXML & " " & _
            strFirmados & "\" & strArchivoXML
    End Function
    'metodo para firmar el archivo xml 
    Public Function Firmar() As Boolean
        Shell("C:\IA\EnvioSRI\FirmarXML\FirmarXMLv01 " & establecerParametros(), AppWinStyle.Hide)
        System.Threading.Thread.Sleep(6000)

        Try
            'Validar si el archivo  firmado existe para eliminar el archivo  de generados
            If System.IO.File.Exists(ArchivoXMLFirmado()) Then
                'eliminar el archivo de  generados
                archivo.eliminarArchivo(strGenerados & "\" & strArchivoXML)
                'copiar el archivo en la carpeta de por autorizar
                My.Computer.FileSystem.CopyFile(ArchivoXMLFirmado(), archivo.CarpetaPorAutorizar & "\" & strArchivoXML)
                Return (True)

            Else
                Return False
            End If

        Catch ex As Exception
            Dim er As New Log
            er.NombreFuncion = "FirmarXML"
            er.SistemaError = ex.Message
            er.MensajeError = ArchivoXMLFirmado()
            Return False
        End Try
    End Function
End Class
