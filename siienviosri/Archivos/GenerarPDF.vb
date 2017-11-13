'https://nplanchart.wordpress.com/2011/04/22/consumir-dll-de-visual-basic-6-0-en-net-c/

''Imports Sii4A32
''Imports GnprintG

Public Class GenerarPDF
    ''Dim ab As Sii4A32.GNComprobante = New Sii4A32.GNComprobante()
    'Dim gobjMain As Sii4A32.SiiMain = New Sii4A32.SiiMain()

    ''Private mobjImp As Object
    'Dim objImp As GnprintG.PrintTrans = New GnprintG.PrintTrans()
    'Dim mobjImp As GnprintG.PrintTrans = New GnprintG.PrintTrans()
    ''Dim empresa As Sii4A32.Empresa = New Sii4A32.Empresa()
    'Private mobjGNComp As GNComprobante

    Public Sub ExpPDF()
        ImprimirPDF(False)
    End Sub

    Private Sub ImprimirPDF(ByVal Directo As Boolean)
        'Dim emp As Empresa
        'Dim cod As String
        'gobjMain = New SiiMain
        'gobjMain.Inicializar()

        'emp = gobjMain.RecuperaEmpresa(cod)

        'If Not (emp Is Nothing) Then
        '    If Not (gobjMain.EmpresaActual Is Nothing) Then
        '        'gobjMain.EmpresaActual.Cerrar
        '        'gobjMain.EmpresaActual.CerrarModulo(ModuloSii)
        '    End If
        '    'jeaa 07/10/2010 anulado para grabar a que modulo ingresa
        '    'Abre la base de datos de la empresa
        '    'emp.abrir

        '    'Abre la base de datos de la empresa
        '    'emp.AbrirModulo(ModuloSii)
        'End If
        'If Not ImprimeTransPDF(mobjGNComp, mobjImp) Then
        '    '        Me.Show             '*** MAKOTO 11/nov/00 Para que no se pierda el enfoque
        'End If
    End Sub

    'Public Function ImprimeTransPDF(ByVal gc As Sii4A32.GNComprobante, ByRef objImp As Object) As Boolean
    '    'Dim crearRIDE As Boolean

    '    ''If (gc.transid = 0) Or gc.Modificado Then
    '    ''    ImprimeTransPDF = False
    '    ''    Exit Function
    '    ''End If

    '    'crearRIDE = (objImp Is Nothing)
    '    ''If Not crearRIDE Then crearRIDE = (objImp.NombreDLL <> "GNprintg")
    '    ''If crearRIDE Then
    '    ''    objImp = Nothing
    '    ''    objImp = CreateObject("GNprintg.PrintTrans")
    '    ''End If

    '    ''objImp.GeneraPDFTrans(gobjMain.EmpresaActual, True, 1, 0, "", 0, gc)

    '    'objImp.GeneraPDFTrans(gobjMain.EmpresaActual, True, 1, 264956, "", 0)

    '    'ImprimeTransPDF = False
    'End Function

End Class
