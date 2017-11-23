Option Explicit On
Option Strict On

Imports System
Imports System.IO
Imports System.Text

''' -----------------------------------------------------------------------------
''' <project>Codificar texto en base64</project>
''' <class>CodificarBase64</class>
''' <autor>Guido Ramirez</autor>
''' <date>04/MAR/2014</date>
''' <Propietario>IshidayAsociados</Propietario>
''' -----------------------------------------------------------------------------
''' 
''' <summary>
'''   Permite Codificar y Decodificar un valor de tipo string en Base64
''' </summary>
''' <remarks>
'''   Crea una nueva instancia de la clase CodificarBase64 
''' </remarks>
''' <example>
''' Ejemplo de implementación de la clase CodificarBase64
''' <code>
'''   Dim codificar As CodificarBase64
'''   codificar = New CodificarBase64()
'''
'''   codificar.CodificarTexto = Me.txtCodificar.Text
'''   Me.txtTextoCodificado.Text = codificar.CodificarTexto
''' </code>
''' </example>
Public Class CodificarBase64
    Private CodTexto As String
    Private DecTexto As String

    Sub New(ByVal CodTexto As String, ByVal DecTexto As String)
        Me.CodTexto = CodTexto
        Me.DecTexto = DecTexto
    End Sub

    Sub New()
    End Sub
    Public Function StringToBase64() As String
        ' Obtener una representación de bytes de la cadena de origen.
        Dim b As Byte() = Encoding.Unicode.GetBytes(CodTexto)

        ' Devuelve la cadena Unicode con codificación Base64.
        Return Convert.ToBase64String(b)
    End Function

    Public Function Base64ToString() As String
        ' Decodificar la cadena codificada en base 64 a una matriz de bytes.
        Dim b As Byte() = Convert.FromBase64String(DecTexto)

        ' Devuelve la cadena Unicode decodificado.
        Return Encoding.Unicode.GetString(b)
    End Function

    ''' <summary>
    ''' Recibe una cadena de texto tipo String y devuelve una cadena de 
    ''' texto codificado en base64
    ''' </summary>
    ''' <value>Recibe un valor de tipo String</value>
    ''' <returns>Devuelve un valor tipo String codificado en base64</returns>
    ''' <remarks>Acepta un tipo String y devuelve tipo String</remarks>
    Public Property CodificarTexto() As String
        Get
            Return StringToBase64()
        End Get
        Set(ByVal value As String)
            CodTexto = value
        End Set
    End Property

    ''' <summary>
    ''' Recibe una cadena de texto de tipo String codificado en base64 y devuelve 
    ''' una cadena de texto de tipo String
    ''' </summary>
    ''' <value>Recibe un tipo de valor String codificado en base64</value>
    ''' <returns>Devuelve un valor de tipo String</returns>
    ''' <remarks>Acepta un tipo String y devuelve tipo String</remarks>
    Public Property DecodificarTexto() As String
        Get
            Return Base64ToString()
        End Get
        Set(ByVal value As String)
            DecTexto = value
        End Set
    End Property
End Class
