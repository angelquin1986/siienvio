Public Class Mensaje

#Region "VARIABLES"

    Private tipoValue As String = String.Empty
    Private mensajeValue As String = String.Empty
    Private identificadorValue As String = String.Empty
    Private informacionAdicionalValue As String = String.Empty
    Private estadoValue As String = String.Empty

#End Region

#Region "PROPERTIES"

    Public ReadOnly Property IsError() As Boolean
        Get
            If tipoValue = "ERROR" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Property Identificador() As String
        Get
            Return identificadorValue
        End Get
        Set(ByVal value As String)
            identificadorValue = value
        End Set
    End Property

    Public Property Mensaje() As String
        Get
            Return mensajeValue
        End Get
        Set(ByVal value As String)
            mensajeValue = value
        End Set
    End Property

    Public Property InformacionAdicional() As String
        Get
            Return informacionAdicionalValue
        End Get
        Set(ByVal value As String)
            informacionAdicionalValue = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return tipoValue
        End Get
        Set(ByVal value As String)
            tipoValue = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return estadoValue
        End Get
        Set(ByVal value As String)
            estadoValue = value
        End Set
    End Property
#End Region

#Region "CONSTRUCTOR"

    Sub New()
    End Sub

    Sub New(ByVal Identificador As String, ByVal Mensaje As String, ByVal InformacionAdicional As String, ByVal Tipo As String)
        identificadorValue = Identificador
        mensajeValue = Mensaje
        informacionAdicionalValue = InformacionAdicional
        tipoValue = Tipo
    End Sub

#End Region

End Class