Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim archivo As New Archivo
        Dim archivoXML As New SustituirCaracteresXML
        'Dim valor As New GenerarPDF

        'archivo.LeerXML("C:\Temp\Generados\2011201401019005550700110040010000003240000267647.xml", "ruc")
        archivoXML.ArchivoXml = "C:\Temp\Generados\2011201401019005550700110040010000003240000267647.xml"
        archivoXML.LoadXMLDoc()
        'valor.ExpPDF()
    End Sub
End Class