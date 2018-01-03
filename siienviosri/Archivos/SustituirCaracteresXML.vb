Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient

Public Class SustituirCaracteresXML
    Private strArchivoXML As String = ""

    Public Property ArchivoXml() As String
        Get
            Return strArchivoXML
        End Get
        Set(value As String)
            strArchivoXML = value
        End Set
    End Property

    Private Sub SustituirCaracterSRI()
        Dim strm As StreamReader = Nothing
        Dim tempfile As String = PathArchivo & "\temp.xml"
        Dim strline As String = ""

        Try
            FileCopy(strArchivoXML, tempfile)
        Catch ex As Exception
            'Excepción que se produce cuando un archivo xml no cumple con el formato o estructura.            
            Dim er As New Log
            er.NombreFuncion = "SustituirCaracteresXML.IsValidXML"
            er.SistemaError = ex.Message
            er.MensajeError = "No se ha podido realizar la copia del archivo " & strArchivoXML
        End Try

        Dim strmwriter As New StreamWriter(strArchivoXML, True, System.Text.Encoding.UTF8)
        strmwriter.AutoFlush = True
        strm = New StreamReader(tempfile)

        strline = strm.ReadLine()

        strline = Replace(strline, "*", "x")
        strmwriter.WriteLine(strline)

        strline = strm.ReadToEnd
        strmwriter.WriteLine(strline)

        strm.Close()
        strm = Nothing

        strmwriter.Flush()
        strmwriter.Close()
        strmwriter = Nothing
    End Sub

    Private Sub ReemplazarCaracteresEspeciales(ByVal NroLinea As Long, ByVal NroPosicion As Integer)
        Dim strm As StreamReader = Nothing
        Dim strline As String = ""
        Dim strreplace As String = ""
        Dim tempfile As String = "archivo01.xml"

        Try
            FileCopy(strArchivoXML, tempfile)
        Catch ex As System.NullReferenceException
            'Excepción que se produce cuando un archivo xml no cumple con el formato o estructura.            
            Dim er As New Log
            er.NombreFuncion = "SustituirCaracteresXML.IsValidXML"
            er.SistemaError = ex.Message
            er.MensajeError = "No se ha podido realizar la copia del archivo " & strArchivoXML
        Catch ex As Exception
            'Excepción que se produce cuando un archivo xml no cumple con el formato o estructura.            
            Dim er As New Log
            er.NombreFuncion = "SustituirCaracteresXML.IsValidXML"
            er.SistemaError = ex.Message
            er.MensajeError = "No se ha podido realizar la copia del archivo " & strArchivoXML
        End Try

        Dim strmwriter As New StreamWriter(strArchivoXML)
        strmwriter.AutoFlush = True
        strm = New StreamReader(tempfile)

        Dim i As Long = 0
        While i < NroLinea - 1
            strline = strm.ReadLine()
            strmwriter.WriteLine(strline)
            i = i + 1
        End While

        strline = strm.ReadLine()
        Dim lineposition As Int32
        Dim caracter As String = ""

        Try
            '-------------------------------------
            caracter = Mid(strline, NroPosicion - 1, 1)
            Select Case caracter
                Case "&"
                    lineposition = strline.IndexOf("&", NroPosicion - 2)
                    If lineposition > 0 Then
                        strreplace = " &amp;"
                    End If
                Case "<"
                    lineposition = strline.IndexOf("<", NroPosicion - 2)
                    If lineposition > 0 Then
                        strreplace = " &lt;"
                    End If
                Case ">"
                    lineposition = strline.IndexOf(">", NroPosicion - 2)
                    If lineposition > 0 Then
                        strreplace = " &gt;"
                    End If
                Case "'"
                    lineposition = strline.IndexOf("'", NroPosicion - 2)
                    If lineposition > 0 Then
                        strreplace = " &apos;"
                    End If
            End Select
            '-------------------------------------

            strline = (strline.Substring(0, lineposition - 1) & strreplace) + strline.Substring(lineposition + 1)
            strmwriter.WriteLine(strline)

            strline = strm.ReadToEnd
            strmwriter.WriteLine(strline)

            strm.Close()
            strm = Nothing

            strmwriter.Flush()
            strmwriter.Close()
            strmwriter = Nothing

            File.Delete(tempfile)
        Catch ex As System.ArgumentOutOfRangeException
            'Excepción que se produce cuando un archivo xml no cumple con el formato o estructura.            
            Dim er As New Log
            er.NombreFuncion = "SustituirCaracteresXML.ReemplazarCaracteresEspeciales"
            er.SistemaError = ex.Message
            er.MensajeError = "Error fatal en estructura XML, hay etiquetas sin cerrar " & strArchivoXML
        Catch ex As System.NullReferenceException
            'Excepción que se produce cuando un archivo xml no cumple con el formato o estructura.            
            Dim er As New Log
            er.NombreFuncion = "SustituirCaracteresXML.ReemplazarCaracteresEspeciales"
            er.SistemaError = ex.Message
            er.MensajeError = "Error fatal en estructura XML, hay caracteres en blanco " & strArchivoXML
        Catch ex As System.ArgumentException
            'Excepción que se produce cuando un archivo xml no cumple con el formato o estructura.            
            Dim er As New Log
            er.NombreFuncion = "SustituirCaracteresXML.ReemplazarCaracteresEspeciales"
            er.SistemaError = ex.Message
            er.MensajeError = "Error fatal en archivo XML, tiene un tamaño de 0Kb. Archivo Borrado " & strArchivoXML
            strmwriter.Flush()
            strmwriter.Close()
            strmwriter = Nothing
            File.Delete(strArchivoXML)
        End Try
    End Sub

    Public Function LoadXMLDoc() As Boolean
        Dim xdoc As XmlDocument = Nothing
        Dim reader As XmlTextReader = Nothing
        Dim lnum As Long = 0
        Dim pos As Long = 0
        Dim Newxml As String = ""

        Try
            reader = New XmlTextReader(strArchivoXML)
            xdoc = New XmlDocument()
            xdoc.Load(reader)
            reader.Close()
            Return True
        Catch ex As XmlException
            reader.Close()
            'MessageBox.Show(ex.Message)
            lnum = ex.LineNumber
            pos = ex.LinePosition

            ReemplazarCaracteresEspeciales(lnum, pos)

            'xdoc = LoadXMLDoc()
            Return False
        End Try
    End Function
End Class
