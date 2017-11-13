Imports System.Text

Friend Module Metodos

    Public Function ToBase64String(ByVal value As String) As String
        Try
            ToBase64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(value))
        Catch ex As Exception
            ToBase64String = String.Empty
        End Try
    End Function

End Module
