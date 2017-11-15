Imports System.IO
Imports System.Xml

Public Class Archivo
    Private LecturaArch As StreamReader = Nothing
    Private EscrituraArch As StreamWriter = Nothing
    Private strCarpetaGenerados As String = ""
    Private strCarpetaFirmados As String = ""
    Private strCarpetaAutorizados As String = ""
    Private strCarpetaContingencia As String = ""
    Private strCarpetaPorAutorizar As String = ""
    Private strCarpetaNoAutorizados As String = ""
    Private strNombreArchivo As String = ""

    '---------------------------------------------------
    'Uso local
    Private strTag As String = ""
    Private strTagValor As String = ""
    Private reader As XmlTextReader
    Private xml As XmlDocument = Nothing
    Dim blnComprobar As Boolean = False
    '---------------------------------------------------

    Public Property CarpetaPorAutorizar() As String
        Get
            Return strCarpetaPorAutorizar
        End Get
        Set(ByVal value As String)
            strCarpetaPorAutorizar = value
        End Set
    End Property

    Public Property CarpetaGenerados() As String
        Get
            Return strCarpetaGenerados
        End Get
        Set(value As String)
            strCarpetaGenerados = value
        End Set
    End Property

    Public Property CarpetaFirmados() As String
        Get
            Return strCarpetaFirmados
        End Get
        Set(value As String)
            strCarpetaFirmados = value
        End Set
    End Property

    Public Property CarpetaAutorizados() As String
        Get
            Return strCarpetaAutorizados
        End Get
        Set(value As String)
            strCarpetaAutorizados = value
        End Set
    End Property

    Public Property CarpetaContingencia() As String
        Get
            Return strCarpetaContingencia
        End Get
        Set(value As String)
            strCarpetaContingencia = value
        End Set
    End Property

    Public Property NombreArchivo() As String
        Get
            Return strNombreArchivo
        End Get
        Set(value As String)
            strNombreArchivo = value
        End Set
    End Property

    Public Property CarpetaNoAutorizados() As String
        Get
            Return strCarpetaNoAutorizados
        End Get
        Set(value As String)
            strCarpetaNoAutorizados = value
        End Set
    End Property

    Public Sub GuardarArchivoTexto(ByVal strFileName As String, ByVal strTextoPlano As String, ByVal logValor As Boolean)
        LecturaArch = Nothing
        'LecturaArch.Close()
        'LecturaArch.Dispose()
        EscrituraArch = New StreamWriter(strFileName, logValor, System.Text.Encoding.UTF8)
        EscrituraArch.WriteLine(strTextoPlano)
        EscrituraArch.Flush()
        EscrituraArch.Close()
        EscrituraArch.Dispose()
        EscrituraArch = Nothing
    End Sub

    Public Function LeerArchivoTexto(ByVal strFileName As String) As String
        Dim strValor As String

        EscrituraArch = Nothing
        strValor = ""
        LecturaArch = New StreamReader(strFileName, System.Text.Encoding.Default, True)
        strValor = LecturaArch.ReadToEnd()
        LecturaArch.Dispose()
        LecturaArch.Close()
        LecturaArch = Nothing
        Return strValor
    End Function

    Public Function IsValidXML(value As String) As Boolean
        Dim reader As XmlTextReader = Nothing
        Dim xml As XmlDocument = Nothing
        Try
            ' Check we actually have a value
            If String.IsNullOrEmpty(value) = False Then
                ' Try to load the value into a document
                reader = New XmlTextReader(value)
                xml = New XmlDocument()
                xml.Load(reader)
                reader.Close()
                ' If we managed with no exception then this is valid XML!
            End If

            Return True
        Catch ex As System.Xml.XmlException
            'Excepción que se produce cuando un archivo xml no cumple con el formato o estructura.            
            reader.Close()

            Dim er As New Log
            Dim xm As New SustituirCaracteresXML

            er.NombreFuncion = "Archivo.IsValidXML"
            er.SistemaError = ex.Message
            er.MensajeError = "La estructura XML, XSD no valido " & value
            '----------------------------------
            xm.ArchivoXml = value
            xm.LoadXMLDoc()
            '----------------------------------
            Return False
        Catch ex As System.IO.FileNotFoundException
            'Excepción que se produce cuando se produce un error al intentar tener acceso a un archivo que no existe en el disco.            
            reader.Close()

            Dim er As New Log

            er.NombreFuncion = "Archivo.IsValidXML"
            er.SistemaError = ex.Message
            er.MensajeError = "No existe el archivo " & value
            Return False
        Catch ex As System.NullReferenceException
            'Excepción que se produce cuando un archivo xml no cumple con el formato o estructura.            
            Dim er As New Log
            er.NombreFuncion = "Archivo.IsValidXML"
            er.SistemaError = ex.Message
            er.MensajeError = "No existe el archivo " & value
        Catch e As System.IO.IOException
            '//
            Return False
        End Try
        Return False
    End Function

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
    'Metodo para eliminar un archivo
    Public Function eliminarArchivo(ByVal strNombreArchivo As String) As Boolean
        If System.IO.File.Exists(strNombreArchivo) Then
            File.Delete(strNombreArchivo)
        End If
        Return True

    End Function
    'Metodo para cargar  una lista de nombres de ar
    Public Function cargarListaNombreArchivo(ByVal strPathArchivo As String, ByVal txtNombreArchivo As String) As Collection
        '"*.xml"
        'limpiar los datos  de la lista de comprobantes generados
        Dim lstListaComprobantes As New Collection
        lstListaComprobantes.Clear()

        Dim directorio As DirectoryInfo = New DirectoryInfo(strPathArchivo)

        If directorio.Attributes <> -1 Then
            'tomo los  archivos  que necesita buscar
            For Each filesfrom In directorio.GetFiles(txtNombreArchivo, IO.SearchOption.AllDirectories)
                lstListaComprobantes.Add(filesfrom.Name)
            Next
        End If
        Return lstListaComprobantes
    End Function
    Public Function CrearArchivos(ByVal xmlSRI_Devuleve As String, ByVal intEstado As Byte) As Boolean ' Funcion crea archivo autorizado
        Dim strGenerados As String = strCarpetaGenerados & "\" & strNombreArchivo
        Dim strFirmados As String = strCarpetaFirmados & "\" & strNombreArchivo
        Dim strAutorizados As String = strCarpetaAutorizados & "\" & strNombreArchivo
        Dim strContingencia As String = strCarpetaContingencia & "\" & strNombreArchivo
        Dim strNoAutorizados As String = strCarpetaNoAutorizados & "\" & strNombreArchivo
        Dim strPorAutorizar As String = strCarpetaPorAutorizar & "\" & strNombreArchivo

        CopiaGenerados(strCarpetaGenerados, strNombreArchivo, strArchivoRelativoXML)
        'Dim prueba As String = strArchivoRelativoXML

        Select Case intEstado
            Case 1 ' Autorizados
                If File.Exists(strGenerados) Then File.Delete(strGenerados)
                'ahora el proceso de envio  tiene que tomar de por autorizar por tal motivo va a No autorizado
                If File.Exists(strPorAutorizar) Then File.Delete(strPorAutorizar)
                If File.Exists(strAutorizados) Then File.Delete(strAutorizados)
                GuardarArchivoTexto(strAutorizados, xmlSRI_Devuleve, True)
                strArchivoParaEnviar = strAutorizados
            Case 2 ' No Autorizado
                If File.Exists(strGenerados) Then File.Delete(strGenerados)
                'ahora el proceso de envio  tiene que tomar de por autorizar por tal motivo va a No autorizado
                If File.Exists(strPorAutorizar) Then File.Delete(strPorAutorizar)
                If File.Exists(strContingencia) Then File.Delete(strContingencia)
                If File.Exists(strNoAutorizados) Then File.Delete(strNoAutorizados)
                GuardarArchivoTexto(strNoAutorizados, xmlSRI_Devuleve, True)
            Case 3 ' Contingencia
                Dim dato As New Datos
                Dim intIdTransaccion As ULong = dato.IdTransaccion(strGenerados)
                Dim strTipoEmision As String = dato.RecuperarTipoEmision(strArchivoRelativoXML)

                If File.Exists(strGenerados) Then File.Delete(strGenerados)
                If File.Exists(strContingencia) Then File.Delete(strContingencia)
                If File.Exists(strFirmados) Then File.Delete(strFirmados)

                Dim BD As New ConexionBD
                Dim strClaveAcceso As String = ""

                strClaveAcceso = dato.RecuperarClaveAcceso(strArchivoRelativoXML)
                GuardarArchivoTexto(strGenerados, strArchivoRelativoXML, True)

                BD.ActualizarDatosSRI(strClaveAcceso, _
                              0, _
                              "00", _
                              "No hay conexion a los webservice del SRI", _
                              "2", _
                              dato.IdTransaccion(strContingencia))
        End Select
        Return True
    End Function

    Public Function LeerXML(ByVal filename As String, ByVal strTag As String) As String
        'http://msdn.microsoft.com/es-es/library/1af7xa52%28v=vs.110%29.aspx
        Dim reader As XmlTextReader = Nothing
        Dim blnComprobar As Boolean = False
        Dim strValor As String = ""
        'Dim ms As MemoryStream = FileManager.GetFileStream(filename)

        Try
            ' Load the reader with the data file and ignore all white space nodes.         
            reader = New XmlTextReader(filename)
            reader.WhitespaceHandling = WhitespaceHandling.None

            ' Parse the file and display each of the nodes.
            While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        If reader.Name = strTag Then
                            blnComprobar = True
                        End If
                    Case XmlNodeType.Text
                        If blnComprobar = True Then
                            strValor = reader.Value
                            blnComprobar = False
                            Exit While
                        End If
                End Select
            End While

            Return strValor
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Function

    Public Function leerElementosXML(ByVal strArchivoXML As String, ByVal strNombreTag As String) As String
        Dim xmlString As String = getOuterXML(strArchivoXML)
        Dim x As New System.Xml.XmlDocument

        strTag = strNombreTag
        strTagValor = ""
        '--------------------------------------------------------------------------------------------------
        x.PreserveWhitespace = True
        '--------------------------------------------------------------------------------------------------
        x.LoadXml(xmlString)
        '--------------------------------------------------------------------------------------------------
        readElements(x.DocumentElement)
        '--------------------------------------------------------------------------------------------------
        strTag = ""
        x = Nothing

        Return strTagValor
    End Function

    Public Function leerElementosXMLCorreo(ByVal strArchivoXML As String, ByVal strNombreTag As String) As String
        Dim strRucCliente As String = ""

        Try
            If strArchivoXML <> String.Empty Then
                Dim xmlDocumento As XDocument = XDocument.Load(New StringReader(strArchivoXML))

                For Each N In xmlDocumento.<autorizaciones>.<autorizacion>.<comprobante>.<factura>.<infoFactura>.Elements
                    Select Case N.Name.ToString()
                        Case Is = strNombreTag
                            strRucCliente = N.Value
                    End Select
                Next
            End If
            Return strRucCliente
        Catch ex As System.Xml.XmlException
            '//
            Return strRucCliente
        End Try
    End Function

    Public Function leerElementosXMLRazonSocial(ByVal strArchivoXML As String, ByVal strNombreTag As String) As String
        Dim strRazonSocial As String = ""

        If strArchivoXML <> String.Empty Then
            Dim xmlDocumento As XDocument = XDocument.Load(New StringReader(strArchivoXML))

            For Each N In xmlDocumento.<autorizaciones>.<autorizacion>.<comprobante>.<factura>.<infoTributaria>.Elements
                Select Case N.Name.ToString()
                    Case Is = strNombreTag
                        strRazonSocial = N.Value
                End Select
            Next
        End If
        Return strRazonSocial
    End Function

    Private Sub readElements(ByVal node As XmlNode)
        For Each nodeChild As XmlNode In node.ChildNodes
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName.Contains(strTag) = True Then
                    strTagValor = nodeChild.InnerText
                End If
                '' Revisar --> NodeChild ->System.Xml.Element ->Attributes ->Nodes 
                ''                       ->System.Xml.XmlAttribute ->FirstChild
                ''                       ->System.XmlXmlText ->Data
                'If strTag = "Email" And nodeChild.LocalName = "campoAdicional" Then
                '    Dim strText As System.Xml.XmlText = nodeChild.FirstChild
                '    If strText.InnerText = strTag Then
                '        strText = nodeChild.FirstChild
                '        strTagValor = strText.Data
                '    End If
                'End If
            End If
            If blnComprobar = False Then
                If nodeChild.ChildNodes.Count > 0 Then
                    If strTagValor = String.Empty Then
                        blnComprobar = True
                        readElements(nodeChild)
                        blnComprobar = False
                    End If
                End If
            End If
        Next
    End Sub

    Private Function getOuterXML(ByVal fileNameXML As String) As String
        Dim retVal As String = String.Empty
        '--------------------------------------------------------------------------------------------------------
        If fileNameXML <> String.Empty Then
            reader = New XmlTextReader(New StringReader(fileNameXML))
            xml = New XmlDocument()
            '----------------------------------------------------------------------------------------------------
            xml.PreserveWhitespace = True
            '----------------------------------------------------------------------------------------------------
            xml.Load(reader)
            '----------------------------------------------------------------------------------------------------
            retVal = xml.OuterXml
            '----------------------------------------------------------------------------------------------------
            'reader.Close()
        End If
        reader.Close()
        reader = Nothing
        xml = Nothing
        '--------------------------------------------------------------------------------------------------------
        getOuterXML = retVal
        '--------------------------------------------------------------------------------------------------------
    End Function

    Private Sub readElementsInfoAdicional(ByVal node As XmlNode)
        For Each nodeChild As XmlNode In node.ChildNodes
            If nodeChild.NodeType <> XmlNodeType.Text Then
                If nodeChild.LocalName.Contains(strTag) = True Then
                    strTagValor = nodeChild.InnerText
                End If
                If strTag = "Email" And nodeChild.LocalName = "CampoAdicional" Then
                    Dim strValor As String = nodeChild.GetNamespaceOfPrefix("nombre")
                End If
            End If
            If blnComprobar = False Then
                If nodeChild.ChildNodes.Count > 0 Then
                    If strTagValor = String.Empty Then
                        blnComprobar = True
                        readElements(nodeChild)
                        blnComprobar = False
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub CopiaGenerados(ByVal strPathDirectorio As String, ByVal strNombreArchivo As String, ByVal strContenidoArchivo As String)
        Dim strCopiaGen As String = strPathDirectorio.Replace("Generados", "Copia Generados")

        If System.IO.Directory.Exists(strCopiaGen) Then
        Else
            System.IO.Directory.CreateDirectory(strCopiaGen)
        End If

        'FileCopy(strPathDirectorio & "\" & strNombreArchivo, strCopiaGen & "\" & strNombreArchivo)
        If File.Exists(strCopiaGen & "\" & strNombreArchivo) Then File.Delete(strCopiaGen & "\" & strNombreArchivo)
        GuardarArchivoTexto(strCopiaGen & "\" & strNombreArchivo, strContenidoArchivo, True)

    End Sub

    Public Sub MoverEnviados(ByVal strPathDirectorio As String, ByVal strNombreArchivo As String, ByVal strContenidoArchivo As String)

        Try
            Dim strCopiaGen As String = strPathDirectorio.Replace("Autorizados", "Enviados")

            If System.IO.Directory.Exists(strCopiaGen) Then
            Else
                System.IO.Directory.CreateDirectory(strCopiaGen)
            End If

            If File.Exists(strCopiaGen & "\" & strNombreArchivo) Then File.Delete(strCopiaGen & "\" & strNombreArchivo)
            File.Move(strPathDirectorio & "\" & strNombreArchivo, strCopiaGen & "\" & strNombreArchivo)
        Catch ex As System.IO.IOException
            '//
        End Try

    End Sub
End Class
