Public Class Comprobante

#Region "VARIABLES"

    Private mensajesValue As New List(Of Mensaje)
    Private claveAccesoValue As String = String.Empty

#End Region

#Region "PROPERTIES"

    Public Property ClaveAcceso() As String
        Get
            Return claveAccesoValue
        End Get
        Set(ByVal value As String)
            claveAccesoValue = value
        End Set
    End Property

    Public Property Mensajes() As List(Of Mensaje)
        Get
            Return mensajesValue
        End Get
        Set(ByVal value As List(Of Mensaje))
            mensajesValue = value
        End Set
    End Property

#End Region

End Class
