Imports System.IO
Imports System.Xml

Module modConfiguracion
    Private strPathArchivo As String = ""
    'Private strArchivoRelativoXML As String = ""

    Public strNombreCli As String
    Public strDireccionCli As String
    Public strTelefonoCli As String
    Public strEmailCli As String
    Public blnEnviarCopiaEmail As Boolean = False
    Public blnUsarProxy As Boolean = False
    Public strDireccionProxy As String
    Public intPuertoProxy As Integer
    Public strArchivoParaEnviar As String = ""
    Public strArchivoParaEnviarPDF As String = ""
    Public strArchivoRelativoXML As String = ""

    Public Property PathArchivo() As String
        Get
            Return strPathArchivo
        End Get
        Set(value As String)
            If value = "" Then
                strPathArchivo = "C:\IA\EnvioSRI"
            Else
                strPathArchivo = value
            End If
        End Set
    End Property

    'Public Property ArchivoRelativo() As String
    '    Get
    '        Dim xml As New Archivo

    '        strArchRelativoXML = xml.LeerArchivoTexto(strArchivoRelativoXML)
    '        Return strArchRelativoXML
    '    End Get
    '    Set(value As String)
    '        strArchivoRelativoXML = value
    '    End Set
    'End Property

    Public Sub ArchivoRelativo(ByVal strArchivo As String)
        Dim xml As New Archivo

        strArchivoRelativoXML = xml.LeerArchivoTexto(strArchivo)
    End Sub

    Public Sub CargarDatosCliente()
        Dim DB As New ConexionBD
        Dim CONN As DataTable = DB.DatosCliente(strArchivoRelativoXML)

        If CONN.Rows.Count > 0 Then
            Dim row As DataRow = CONN.Rows(0)

            strNombreCli = Convert.ToString(row("Nombre"))
            strDireccionCli = Convert.ToString(row("Direccion1"))
            strTelefonoCli = Convert.ToString(row("Telefono1"))
            strEmailCli = Convert.ToString(row("Email"))
        End If
    End Sub

    Public Sub CargarDatosClienteCorreo()
        Dim DB As New ConexionBD
        Dim CONN As DataTable = DB.DatosClienteCorreo(strArchivoRelativoXML)

        If CONN.Rows.Count > 0 Then
            Dim row As DataRow = CONN.Rows(0)

            strNombreCli = Convert.ToString(row("Nombre"))
            strDireccionCli = Convert.ToString(row("Direccion1"))
            strTelefonoCli = Convert.ToString(row("Telefono1"))
            strEmailCli = Convert.ToString(row("Email"))
        End If
    End Sub
End Module
