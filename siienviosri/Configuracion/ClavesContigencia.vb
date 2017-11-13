Imports System.Xml
Imports System.Data

Module ClavesContigencia
    Dim strNuevoSecuencial As String = ""

    Public Function CambiarPorClavesContingencia(ByVal strArchivoXML As String, ByVal strRutaDestino As String, ByRef strArchivoContingencia As String, ByRef intIdTransaccion As ULong) As Boolean

        Dim strNuevoArchivo As String
        Dim myXmlDocument As XmlDocument = New XmlDocument()
        myXmlDocument.Load(strArchivoXML)

        Dim node As XmlNode
        node = myXmlDocument.DocumentElement

        Dim node2 As XmlNode 'Used for internal loop.
        For Each node In node.ChildNodes
            'Find the price child node.
            For Each node2 In node.ChildNodes
                If node2.Name = "tipoEmision" Then
                    node2.InnerText = 2
                End If
                'If node2.name = "secuencial" Then
                '    Dim valor As Integer = 0

                '    Select Case CInt(node2.InnerText)
                '        Case Is < 100
                '            valor = 10000000 * CInt(node2.InnerText)
                '        Case Is < 1000
                '            valor = 1000000 * CInt(node2.InnerText)
                '        Case Is < 10000
                '            valor = 100000 * CInt(node2.InnerText)
                '        Case Is < 100000
                '            valor = 10000 * CInt(node2.InnerText)
                '        Case Is < 1000000
                '            valor = 1000 * CInt(node2.InnerText)
                '        Case Is < 10000000
                '            valor = 100 * CInt(node2.InnerText)
                '    End Select

                '    node2.InnerText = CStr(valor)
                'End If
                If node2.Name = "claveAcceso" Then
                    '                    nodePriceText = node2.InnerText
                    Dim strClave As String
                    strClave = node2.InnerText

                    ' Double the price.
                    Dim blnGenero As Boolean
                    blnGenero = GenerarClave(strClave)
                    'Console.WriteLine("Old Price = " & node2.InnerText & Strings.Chr(9) & "New price = " & newprice)
                    If blnGenero = True Then
                        node2.InnerText = strClave
                        strNuevoArchivo = strClave
                        myXmlDocument.Save(strRutaDestino & "\" & strNuevoArchivo & ".xml")
                        strArchivoContingencia = strRutaDestino & "\" & strNuevoArchivo & ".xml"
                        '----------------------
                        'Dim Sii4A As New Sii4A

                        'Sii4A.ArchivoXML = strArchivoContingencia
                        'Sii4A.Enviado = False
                        'Sii4A.InformacionAdicional = "No hay conexion a los servicios web del SRI"
                        'Sii4A.TipoEmision = "Contingencia"
                        'Sii4A.NroAutorizacion = ""
                        'Sii4A.IdTransaccion = intIdTransaccion
                        'Sii4A.GrabarSii4A()
                        '----------------------
                        Return True
                    Else
                        Return False
                    End If
                End If
            Next
        Next
    End Function

    Private Function GenerarClave(ByRef strClave As String) As Boolean
        Dim BD As New ConexionBD
        Dim conn01 As DataTable = BD.RecuperarContingenciaValida()
        Dim strNueva As String
        Dim i As Byte
        Dim intSuma As Integer
        Dim intPonderado As Byte
        Dim intResto As Integer

        intSuma = 0
        intPonderado = 8

        strNueva = Left(strClave, 10)

        Dim strClaveContingencia As String
        '--------------------------------------------------------------------------------------------
        If conn01.Rows.Count > 0 Then
            Dim row As DataRow = conn01.Rows(0)
            strClaveContingencia = Convert.ToString(row("ClaveContingencia"))
            BD.GuardarContingenciaNoValida(strClaveContingencia)
            strNuevoSecuencial = strClaveContingencia
        Else
            Return False
        End If

        strNueva = strNueva & strClaveContingencia & "2" 'Emisión por Indisponibilidad del Sistema

        For i = 0 To Len(strNueva) - 1
            If intPonderado < 3 Then
                intPonderado = 8
            End If
            intPonderado = intPonderado - 1
            intSuma = intSuma + CInt(strNueva.Substring(i, 1) * (intPonderado))
        Next

        Select Case (11 - (intSuma Mod 11))
            Case 10
                intResto = 1
            Case 11
                intResto = 0
            Case Is < 10
                intResto = (11 - (intSuma Mod 11))
        End Select

        strNueva = strNueva & intResto
        strClave = strNueva
        Return True
    End Function
End Module
