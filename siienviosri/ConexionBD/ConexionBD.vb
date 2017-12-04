Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Xml

Public Class ConexionBD

    Private Function ConexionServidorPrincipal() As SqlConnection
        Dim Decodificar As New CodificarBase64
        Dim archivo As New Archivo
        'codificar un string 
        Decodificar.CodificarTexto = "fuentes\ia2012,nitro2015,sa,Rtl8139c"
        Decodificar.DecodificarTexto = archivo.LeerArchivoTexto("C:\IA\EnvioSRI\iadt000.ibz")

        Dim TestArray() As String = Split(Decodificar.DecodificarTexto, ",")
        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=" & TestArray(0) & ";Initial Catalog=" & TestArray(1) & ";" & _
                                "User ID=" & TestArray(2) & ";Password=" & TestArray(3) & ";"
        Return conn
    End Function

    Public Function RecuperarConfiguracion() As DataTable
        Dim sql As String
        Dim dt As DataTable = New DataTable

        sql = "SELECT NombreEmpresa, RUC, ComprobantesGenerados, ComprobantesFirmados, ComprobantesAutorizados, " & _
              "ComprobantesNoAutorizados,ComprobantesPorAutorizar, UbicacionArchivoToken, ContrasenaToken, TipoAmbiente, ComprobantesContingencia, ComprobantesEnviados,wsSriPruebasRecepcion,wsSriPruebasAutorizacion,wsSriProduccionRecepcion,wsSriProduccionAutorizacion " & _
              "FROM dbo.GNOpcion"
        Dim comando As SqlCommand = New SqlCommand(sql, ConexionServidorPrincipal)
        Dim adap As SqlDataAdapter = New SqlDataAdapter(comando)
        adap.Fill(dt)

        Return dt
    End Function

    Public Function RecuperarConfigServidorCorreo() As DataTable
        Dim log As New Log
        log.NombreFuncion = "Metodo :RecuperarConfigServidorCorreo"
        Try
            Dim sql As String
            Dim dt As DataTable = New DataTable
            sql = "SELECT * FROM gnopcion"

            Dim comando As SqlCommand = New SqlCommand(sql, ConexionServidorPrincipal)
            Dim adap As SqlDataAdapter = New SqlDataAdapter(comando)
            adap.Fill(dt)

            Return dt
        Catch ex As Exception
            log.SistemaError = ex.Message
            log.MensajeError = "Error al ejecutar metodo RecuperarConfigServidorCorreo"
            Throw New Exception(ex.Message)

            '//
        End Try

    End Function

    Public Function DatosCliente(ByVal strArchivo As String) As DataTable
        Dim sql As String
        Dim dt As DataTable = New DataTable
        Dim datos As New Datos

        sql = "SELECT Nombre, Direccion1, Telefono1, Email FROM pcprovcli WHERE ruc = '" & datos.RecuperarRUCCliente(strArchivo) & "'"

        Dim comando As SqlCommand = New SqlCommand(sql, ConexionServidorPrincipal)
        Dim adap As SqlDataAdapter = New SqlDataAdapter(comando)
        adap.Fill(dt)

        Return dt
    End Function

    Public Function DatosClienteCorreo(ByVal strArchivo As String) As DataTable
        Dim sql As String
        Dim dt As DataTable = New DataTable
        Dim datos As New Datos

        sql = "SELECT Nombre, Direccion1, Telefono1, Email FROM pcprovcli WHERE ruc = '" & datos.RecuperarRUCClienteCorreo(strArchivo) & "'"

        Dim comando As SqlCommand = New SqlCommand(sql, ConexionServidorPrincipal)
        Dim adap As SqlDataAdapter = New SqlDataAdapter(comando)
        adap.Fill(dt)

        Return dt
    End Function

    Public Sub GuardarConfigServidorCorreo(ByVal strPuertoSMTP As String, ByVal strServidorCorreo As String, ByVal strUsuario As String, ByVal strContrasenia As String, ByVal strAsunto As String, ByVal strMensaje As String, ByVal intConexionSegura As Byte, ByVal EnviarCopiaA As String, ByVal NombreUsuario As String)
        Dim conn01 As DataTable = RecuperarConfigServidorCorreo()
        If conn01.Rows.Count > 0 Then
            Using Conn As SqlConnection = ConexionServidorPrincipal()
                Conn.Open()
                Using Cmd As SqlCommand = Conn.CreateCommand()
                    Cmd.CommandText = "UPDATE gnopcion " & _
                        "SET PuertoCorreo = '" & strPuertoSMTP & "', ServidorCorreo = '" & strServidorCorreo & "', CuentaCorreo = '" & strUsuario & "', " & _
                        "PasswordCorreo = '" & strContrasenia & "', ConexionSegura = " & intConexionSegura & ", Asunto = '" & strAsunto & "', MensajeCorreo = '" & strMensaje & "' , CopiaCorreo = '" & EnviarCopiaA & "' , NombreUsuario = '" & NombreUsuario & "'"
                    Cmd.ExecuteNonQuery()
                End Using
            End Using
        Else
            Using Conn As SqlConnection = ConexionServidorPrincipal()
                Conn.Open()
                Using Cmd As SqlCommand = Conn.CreateCommand()
                    Cmd.CommandText = "INSERT INTO ConfigServidorCorreo " & _
                        "(ProtocoloSMTP, ServidorCorreo, NombreUsuario, ContraseniaCorreo, ConexionSegura, Asunto, Mensaje) " & _
                        "VALUES ('" & strPuertoSMTP & "', '" & strServidorCorreo & "', '" & strUsuario & "', '" & _
                        strContrasenia & "', " & intConexionSegura & ", '" & strAsunto & "', '" & strMensaje & "')"
                    Cmd.ExecuteNonQuery()
                End Using
            End Using
        End If
    End Sub

    Public Sub GuardarConfiguracionGeneral(ByVal strComprobantesGenerados As String, ByVal strComprobantesFirmados As String, _
                                          ByVal strComprobantesAutorizados As String, ByVal strComprobantesNoAutorizados As String, _
                                          ByVal strUbicacionArchivoToken As String, ByVal strContrasenaToken As String, _
                                          ByVal strTipoAmbiente As String, ByVal strComprobantesContingencia As String, _
                                          ByVal strComprobantesEnviado As String, _
                                          ByVal strWsRecepcionProduccion As String, ByVal strWsAutorizacionProduccion As String, _
                                          ByVal strWsRecepcionPruebas As String, ByVal strWsAutorizacionPruebas As String,
                                          ByVal strComprobantesPorAutorizar As String)
        Using Conn As SqlConnection = ConexionServidorPrincipal()
            Conn.Open()
            Using Cmd As SqlCommand = Conn.CreateCommand()
                Cmd.CommandText = "UPDATE GNOpcion " & _
                    "SET " & _
                    "ComprobantesGenerados = '" & strComprobantesGenerados & "'," & _
                    "ComprobantesFirmados = '" & strComprobantesFirmados & "'," & _
                    "ComprobantesAutorizados = '" & strComprobantesAutorizados & "'," & _
                    "ComprobantesNoAutorizados = '" & strComprobantesNoAutorizados & "'," & _
                    "ComprobantesPorAutorizar = '" & strComprobantesPorAutorizar & "'," & _
                    "UbicacionArchivoToken = '" & strUbicacionArchivoToken & "'," & _
                    "ContrasenaToken = '" & strContrasenaToken & "'," & _
                    "TipoAmbiente = '" & strTipoAmbiente & "'," & _
                    "ComprobantesEnviados = '" & strComprobantesEnviado & "'," & _
                    "ComprobantesContingencia = '" & strComprobantesContingencia & "'," & _
                    "wsSriPruebasRecepcion = '" & strWsRecepcionPruebas & "'," & _
                    "wsSriPruebasAutorizacion = '" & strWsAutorizacionPruebas & "'," & _
                    "wsSriProduccionRecepcion = '" & strWsRecepcionProduccion & "'," & _
                    "wsSriProduccionAutorizacion = '" & strWsAutorizacionProduccion & "'"
                Cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub GuardarDatosSRI(ByVal strClaveAcceso As String, ByVal strArchivoXML As String, _
                                          ByVal intEnviado As Byte, ByVal strCodigoMensaje As String, _
                                          ByVal strInformacionAdicional As String, ByVal strTipoEmision As String, _
                                          ByVal strNumeroAutorizacion As String, ByVal dteFechaAutorizacion As Date, ByVal intIDTrans As ULong)
        Dim dato As New Datos

        Try
            Using Conn As SqlConnection = ConexionServidorPrincipal()
                Conn.Open()
                Using Cmd As SqlCommand = Conn.CreateCommand()
                    Cmd.CommandText = "UPDATE InfoComprobantes " & _
                                        "SET " & _
                                        "ClaveAcceso = '" & strClaveAcceso & "', " & _
                                        "ArchivoXML = @punteroaCampoXML, " & _
                                        "Enviado = " & intEnviado & ", " & _
                                        "CodigoMensaje = '" & strCodigoMensaje & "', " & _
                                        "InformacionAdicional = '" & strInformacionAdicional & "', " & _
                                        "TipoEmision = '" & strTipoEmision & "', " & _
                                        "NumeroAutorizacion = '" & strNumeroAutorizacion & "', " & _
                                        "FechaAutorizacion = '" & dteFechaAutorizacion & "' " & _
                                        "WHERE TransID = " & intIDTrans
                    If strArchivoXML <> "" Then
                        Dim ParametroSQLXML As SqlXml = New SqlXml(New XmlTextReader(New StringReader(strArchivoXML)))
                        Cmd.Parameters.AddWithValue("@punteroaCampoXML", ParametroSQLXML)
                    Else
                        Dim ParametroSQLXML As SqlXml = New SqlXml(New XmlTextReader(New StringReader("<estado>No Registrado</estado>")))
                        Cmd.Parameters.AddWithValue("@punteroaCampoXML", ParametroSQLXML)
                    End If
                    Cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As System.Data.SqlClient.SqlException
            '//
        End Try
    End Sub

    Public Function GrabarClavesContingencia(ByVal strClave As String) As Boolean
        Dim conn01 As DataTable = RecuperarsClavesContingencia(strClave)

        If conn01.Rows.Count > 0 Then
            Return True
        Else
            Using Conn As SqlConnection = ConexionServidorPrincipal()
                Conn.Open()
                Using Cmd As SqlCommand = Conn.CreateCommand()
                    Cmd.CommandText = "INSERT INTO ClavesContingenciaSRI (ClaveContingencia, Activo) VALUES ('" & strClave & "', '1')"
                    Cmd.ExecuteNonQuery()
                End Using
            End Using
            Return False
        End If
    End Function

    Private Function RecuperarsClavesContingencia(ByVal strClave As String) As DataTable
        Dim sql As String
        Dim dt As DataTable = New DataTable
        sql = "SELECT * FROM ClavesContingenciaSRI WHERE ClaveContingencia = '" & strClave & "'"

        Dim comando As SqlCommand = New SqlCommand(sql, ConexionServidorPrincipal)
        Dim adap As SqlDataAdapter = New SqlDataAdapter(comando)
        adap.Fill(dt)

        Return dt
    End Function

    Public Sub ActualizarGNComprobante(ByVal strNroFactura As String, ByVal intEstado As UShort)
        'Dim intNroNumero As Integer = CInt(strNroFactura)
        Dim conn01 As DataTable = RecuperarConfigServidorCorreo()
        strNroFactura = CadenaSinCeros(strNroFactura)

        Try
            If conn01.Rows.Count > 0 Then
                Using Conn As SqlConnection = ConexionServidorPrincipal()
                    Conn.Open()
                    Using Cmd As SqlCommand = Conn.CreateCommand()
                        Cmd.CommandText = "UPDATE GNComprobante " & _
                            "SET EstadoFacElect = " & intEstado & " " & _
                            "WHERE NumTrans = '" & strNroFactura & "'"
                        Cmd.ExecuteNonQuery()
                    End Using
                End Using
            Else
            End If
        Catch ex As System.Data.SqlClient.SqlException
            '//
        End Try
    End Sub

    Private Function CadenaSinCeros(ByVal sEntrada As String) As String
        ' http://gmoralescruz.blogspot.com/2011/05/metodo-para-eliminar-ceros-la-izquierda.html
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim sIntermedio As String = ""

        For j = 1 To Len(sEntrada)
            If Mid(sEntrada, j, 1) <> "0" Then
                sIntermedio = Mid(sEntrada, j)
                Exit For
            End If
        Next
        CadenaSinCeros = sIntermedio
    End Function

    Public Function RecuperarContingenciaValida() As DataTable
        Dim sql As String
        Dim dt As DataTable = New DataTable
        sql = "SELECT * FROM ClavesContingenciaSRI WHERE Activo = " & 1

        Dim comando As SqlCommand = New SqlCommand(sql, ConexionServidorPrincipal)
        Dim adap As SqlDataAdapter = New SqlDataAdapter(comando)
        adap.Fill(dt)

        Return dt
    End Function

    Public Sub GuardarContingenciaNoValida(ByVal strClave As String)

        Using Conn As SqlConnection = ConexionServidorPrincipal()
            Conn.Open()
            Using Cmd As SqlCommand = Conn.CreateCommand()
                Cmd.CommandText = "UPDATE ClavesContingenciaSRI " & _
                "SET Activo = 0 " & _
                "WHERE ClaveContingencia = '" & strClave & "'"
                Cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub ActualizarDatosSRI(ByVal strClaveAcceso As String, _
                                         ByVal intEnviado As Byte, ByVal strCodigoMensaje As String, _
                                         ByVal strInformacionAdicional As String, ByVal strTipoEmision As String, _
                                         ByVal intIDTrans As ULong)
        Dim dato As New Datos

        Using Conn As SqlConnection = ConexionServidorPrincipal()
            Conn.Open()
            Using Cmd As SqlCommand = Conn.CreateCommand()
                Cmd.CommandText = "UPDATE InfoComprobantes " & _
                                    "SET " & _
                                    "ClaveAcceso = '" & strClaveAcceso & "', " & _
                                    "Enviado = " & intEnviado & ", " & _
                                    "CodigoMensaje = '" & strCodigoMensaje & "', " & _
                                    "InformacionAdicional = '" & strInformacionAdicional & "', " & _
                                    "TipoEmision = '" & strTipoEmision & "' " & _
                                    "WHERE TransID = " & intIDTrans
                Cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Function obtenerInfoComprobantes(ByVal intIDTrans As ULong) As DataTable
        Dim sql As String
        Dim dt As DataTable = New DataTable
        sql = "select * from InfoComprobantes where TransID =" & intIDTrans

        Dim comando As SqlCommand = New SqlCommand(sql, ConexionServidorPrincipal)
        Dim adap As SqlDataAdapter = New SqlDataAdapter(comando)
        adap.Fill(dt)

        Return dt
    End Function

    Public Function obtenerVariableReeviaCorreo() As DataTable
        Dim sql As String
        Dim dt As DataTable = New DataTable
        sql = "select * from gnopcion2 where codigo ='ReenviaCompElecError' "

        Dim comando As SqlCommand = New SqlCommand(sql, ConexionServidorPrincipal)
        Dim adap As SqlDataAdapter = New SqlDataAdapter(comando)
        adap.Fill(dt)

        Return dt
    End Function

    'Actualizar el xml generado y firmado
    'para el parametro de firmada 
    'si es 0 o null no esta firmada(No se puende enviar)
    'si es 1 es firmada (se debe encia por primera vez)
    'si es 2 es firmada ,ya se envio anteriormente y debe enviar agregando al asundo Correción)
    'si es 3 es firmada, ya se envio anteriormente y ya no se debe enviar nuevamente 
    Public Sub guardarXMLOffLine(ByVal strArchivoXML As String, ByVal intIDTrans As ULong, ByVal esFirmada As Integer)
        Dim dato As New Datos

        Try
            Using Conn As SqlConnection = ConexionServidorPrincipal()
                Conn.Open()
                Using Cmd As SqlCommand = Conn.CreateCommand()
                    Cmd.CommandText = "UPDATE InfoComprobantes " & _
                                        "SET " & _
                                        "ArchivoXmlOffLine = @punteroaCampoXML  " & _
                                        ",bandpdf = @bandpdf  " & _
                                        ",EstaFirmada = @estaFirmada  " & _
                                        "WHERE TransID = " & intIDTrans
                    If strArchivoXML <> "" Then
                        Dim ParametroSQLXML As SqlXml = New SqlXml(New XmlTextReader(New StringReader(strArchivoXML)))
                        Cmd.Parameters.AddWithValue("@punteroaCampoXML", ParametroSQLXML)
                    Else
                        Dim ParametroSQLXML As SqlXml = New SqlXml(New XmlTextReader(New StringReader("<estado>No Registrado</estado>")))
                        Cmd.Parameters.AddWithValue("@punteroaCampoXML", ParametroSQLXML)
                    End If
                    'bandera para que permita nuevamente  enviar el archivo
                    Cmd.Parameters.AddWithValue("@bandpdf", 0)
                    Cmd.Parameters.AddWithValue("@estaFirmada", esFirmada)
                    Cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As System.Data.SqlClient.SqlException
            '//
        End Try
    End Sub
End Class
