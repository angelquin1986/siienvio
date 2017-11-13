Public Class Autorizacion

#Region "VARIABLES"

    Private estadoValue As String = String.Empty
    Private fechaAutorizacionValue As String = String.Empty
    Private numeroAutorizacionValue As String = String.Empty
    Private ambienteValue As String = String.Empty
    Private comprobanteValue As String = String.Empty
    Private mensajesValue As New List(Of Mensaje)

#End Region

#Region "PROPERTIES"

    Public ReadOnly Property IsAutorizado() As Boolean
        Get
            If estadoValue = "AUTORIZADO" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Property Estado() As String
        Get
            Return estadoValue
        End Get
        Set(ByVal value As String)
            estadoValue = value
        End Set
    End Property

    Public Property FechaAutorizacion() As String
        Get
            Return fechaAutorizacionValue
        End Get
        Set(ByVal value As String)
            fechaAutorizacionValue = value
        End Set
    End Property

    Public Property NumeroAutorizacion() As String
        Get
            Return numeroAutorizacionValue
        End Get
        Set(ByVal value As String)
            numeroAutorizacionValue = value
        End Set
    End Property

    Public Property Ambiente() As String
        Get
            Return ambienteValue
        End Get
        Set(ByVal value As String)
            ambienteValue = value
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

    Public Property Comprobante() As String
        Get
            Return comprobanteValue
        End Get
        Set(ByVal value As String)
            comprobanteValue = value
        End Set
    End Property

#End Region

#Region "CONSTRUCTOR"

    Sub New()
    End Sub

#End Region

End Class
