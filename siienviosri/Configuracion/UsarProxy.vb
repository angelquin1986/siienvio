Imports WebServiceSRI

Public Class UsarProxy
    Private strHost As String = ""
    Private intPort As UShort = 0

    Public ReadOnly Property Servidor() As String
        Get
            strHost = strDireccionProxy
            Return strHost
        End Get
    End Property

    Public ReadOnly Property Puerto() As UShort
        Get
            intPort = intPuertoProxy
            Return intPort
        End Get
    End Property
End Class
