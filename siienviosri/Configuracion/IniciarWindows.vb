Option Explicit On
Option Strict On

''' -----------------------------------------------------------------------------
''' <project>Iniciar Aplicación con MS Windows</project>
''' <class>IniciarWindows</class>
''' <autor>Guido Ramirez</autor>
''' <date>07/OCT/2014</date>
''' <Propietario>IshidayAsociados</Propietario>
''' -----------------------------------------------------------------------------
''' 
''' <summary>
'''   Permite que la aplicacion inicie al arrancar he iniciar sesion en MS Windows
''' </summary>

Imports Microsoft
Imports Microsoft.Win32
Imports Microsoft.Win32.Registry

Public Class IniciarWindows
    Private Function start_Up(ByVal bCrear As Boolean) As String

        ' clave del registro para   
        ' colocar el path del ejecutable para iniciar con windows  
        Const CLAVE As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

        'ProductName : el nombre del programa.  
        Dim subClave As String = Application.ProductName.ToString
        ' Mensaje para retornar el resultado  
        Dim msg As String = ""

        Try
            ' Abre la clave del usuario actual (CurrentUser) para poder extablecer el dato  
            ' si la clave CurrentVersion\Run no existe la crea  
            Dim Registro As RegistryKey = CurrentUser.CreateSubKey(CLAVE, RegistryKeyPermissionCheck.ReadWriteSubTree)

            With Registro

                .OpenSubKey(CLAVE, True)

                Select Case bCrear
                    ' Crear  
                    '--------------------------------------------------------------------------------------------
                    Case True
                        ' Escribe el path con SetValue   
                        'Valores : ProductName el nombre del programa y ExecutablePath : la ruta del exe  
                        .SetValue(subClave, _
                                  Application.ExecutablePath.ToString)
                        Return "Ok .. clave añadida"
                        ' Eliminar  
                        '--------------------------------------------------------------------------------------------
                        'Elimina la entrada con DeleteValue  
                    Case False
                        If .GetValue(subClave, "").ToString <> "" Then
                            .DeleteValue(subClave) ' eliminar  
                            msg = "Ok .. clave eliminada"
                        Else

                            msg = "No se eliminó , por que el programa" & _
                                   " no iniciaba con windows"
                        End If
                End Select
            End With
            ' Error  
            '--------------------------------------------------------------------------------------------
        Catch ex As Exception
            msg = ex.Message.ToString
        End Try
        'retorno  
        Return msg
    End Function

    Public Sub IniciarConWindows()
        start_Up(True)
    End Sub

    Public Sub NoIniciarConWindows()
        start_Up(False)
    End Sub

End Class
