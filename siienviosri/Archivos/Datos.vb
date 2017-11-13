Imports System.IO.File
Imports System.Xml

Public Class Datos
    Private strNombreCliente As String = ""
    Private strDireccion As String = ""
    Private strTelefono As String = ""
    Private strCorreo As String = ""
    Private strNombreEmpresa As String = ""
    Private strRucEmpresa As String = ""

    Public ReadOnly Property IdTransaccion(ByVal strArchivoXML As String) As ULong
        Get
            Dim intIdTransaccion As ULong = 0

            If Exists(strArchivoXML) Then
                intIdTransaccion = CULng(Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(strArchivoXML, 14), 10))
            End If

            Return intIdTransaccion
        End Get
    End Property

    Public ReadOnly Property CodigoComprobante(ByVal strClaveAcceso As String) As String
        Get
            Dim strCodigoComprobante As String = ""

            strCodigoComprobante = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(strClaveAcceso, 10), 2)

            Return strCodigoComprobante
        End Get
    End Property

    Public ReadOnly Property NombreEmpresa() As String
        Get
            DatosEmpresa()
            Return strNombreEmpresa
        End Get
    End Property

    Public ReadOnly Property RucEmpresa() As String
        Get
            DatosEmpresa()
            Return strRucEmpresa
        End Get
    End Property

    Public ReadOnly Property NroComprobante(ByVal strClaveAcceso As String) As String
        Get
            Dim strNroComprobante As String = ""

            strNroComprobante = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(strClaveAcceso, 39), 9)

            Return strNroComprobante
        End Get
    End Property

    Public ReadOnly Property RecuperarRUCCliente(ByVal strArchivoXML As String) As String
        'Get
        '    Dim strRUC As String = ""

        '    If Exists(strArchivoXML) Then
        '        Dim doc = System.Xml.Linq.XDocument.Load(strArchivoXML)
        '        Dim parsed = From item In doc.Descendants("infoFactura")
        '                     Select item.Element("identificacionComprador")

        '        For Each name As String In parsed
        '            strRUC = name
        '        Next
        '    End If

        '    Return strRUC
        'End Get
        Get
            Dim RucCliente As String = ""
            Dim XML As New Archivo

            RucCliente = XML.leerElementosXML(strArchivoXML, "identificacionComprador")
            Return RucCliente

        End Get
    End Property

    Public ReadOnly Property RecuperarRUCClienteCorreo(ByVal strArchivoXML As String) As String
        Get
            Dim RucCliente As String = ""
            Dim XML As New Archivo

            RucCliente = XML.leerElementosXMLCorreo(strArchivoXML, "identificacionComprador")
            Return RucCliente

        End Get
    End Property

    Public ReadOnly Property RecuperarClaveAcceso(ByVal strArchivoXML As String) As String
        Get
            Dim ClaveAcceso As String = ""
            Dim XML As New Archivo

            ClaveAcceso = XML.leerElementosXML(strArchivoXML, "claveAcceso")
            Return ClaveAcceso

        End Get
    End Property

    Public ReadOnly Property RecuperarTipoEmision(ByVal strArchivoXML As String) As String
        Get
            Dim TipoEmision As String = ""
            Dim XML As New Archivo

            TipoEmision = XML.leerElementosXML(strArchivoXML, "tipoEmision")
            Return TipoEmision

        End Get
    End Property

    Public ReadOnly Property RecuperarRazonSocial(ByVal strArchivoXML As String) As String
        Get
            Dim RazonSocial As String = ""
            Dim XML As New Archivo

            RazonSocial = XML.leerElementosXML(strArchivoXML, "razonSocial")
            Return RazonSocial
        End Get

        'Dim NombreComercial As String = ""
        'Dim reader As XmlTextReader = Nothing
        'reader = New XmlTextReader(strArchivoXML)
        'Dim doc = System.Xml.Linq.XDocument.Load(reader)
        'reader.Close()
        'Dim parsed = From item In doc.Descendants("infoTributaria")
        '             Select item.Element("nombreComercial")

        'For Each name As String In parsed
        '    NombreComercial = name
        'Next

        'Return NombreComercial
    End Property

    Public ReadOnly Property RecuperarRazonSocialCorreo(ByVal strArchivoXML As String) As String
        Get
            Dim RazonSocial As String = ""
            Dim XML As New Archivo

            RazonSocial = XML.leerElementosXMLRazonSocial(strArchivoXML, "razonSocial")
            Return RazonSocial
        End Get
    End Property

    Public ReadOnly Property RecuperarNombreCliente(ByVal strArchivoXML As String) As String
        Get
            DatosCliente(strArchivoXML)
            Return strNombreCliente
        End Get
    End Property

    Public ReadOnly Property RecuperarDireccionCliente(ByVal strArchivoXML As String) As String
        Get
            DatosCliente(strArchivoXML)
            Return strDireccion
        End Get
    End Property

    Public ReadOnly Property RecuperarTelefonoCliente(ByVal strArchivoXML As String) As String
        Get
            DatosCliente(strArchivoXML)
            Return strTelefono
        End Get
    End Property

    Public ReadOnly Property RecuperarCorreoCliente(ByVal strArchivoXML As String) As String
        Get
            Dim strCorreoE As String = ""
            Dim XML As New Archivo
            'Dim DC As DatosCliente

            If strEmailCli <> "" Then
                strCorreoE = strEmailCli
            Else
                Dim DB As New ConexionBD
                Dim CONN As DataTable = DB.DatosCliente(strArchivoXML)
                If CONN.Rows.Count > 0 Then
                    Dim row As DataRow = CONN.Rows(0)

                    strCorreoE = Convert.ToString(row("Email"))
                End If
            End If

            Return strCorreoE

        End Get
    End Property

    Private Sub DatosCliente(ByVal strArchivoXML As String)
        Dim BD As New ConexionBD
        Dim conn As DataTable = BD.DatosCliente(strArchivoXML)

        If conn.Rows.Count > 0 Then
            Dim row As DataRow = conn.Rows(0)

            strNombreCliente = Convert.ToString(row("Nombre"))
            strDireccion = Convert.ToString(row("Direccion1"))
            strTelefono = Convert.ToString(row("Telefono1"))
            strCorreo = Convert.ToString(row("Email"))
        End If
    End Sub

    Private Sub DatosEmpresa()
        Dim BD As New ConexionBD
        Dim conn As DataTable = BD.RecuperarConfiguracion

        If conn.Rows.Count > 0 Then
            Dim row As DataRow = conn.Rows(0)

            strNombreEmpresa = Convert.ToString(row("NombreEmpresa"))
            strRucEmpresa = Convert.ToString(row("RUC"))
        End If
    End Sub

    Public Function ReemplazarCaracter(ByVal strTexto As String, ByVal strCaracter01 As String, ByVal strCaracter02 As String) As String

        strTexto = strTexto.Replace("&lt;", strCaracter01)
        strTexto = strTexto.Replace("&gt;", strCaracter02)
        Return strTexto
    End Function

    Public Function ArcFinXML(ByVal strTexto As String) As String
        Dim intInicio As Integer = strTexto.IndexOf("<autorizaciones>")
        Dim intFin As Integer = strTexto.LastIndexOf("</autorizaciones>")
        Dim strXmlCorrecto As String = strTexto.Substring(intInicio, (intFin + 17) - intInicio)

        strXmlCorrecto = strXmlCorrecto.Replace("<?xml version=""1.0"" encoding=""UTF-8""?>", "")
        Return strXmlCorrecto
    End Function
End Class
