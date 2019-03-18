'=========================================================================='
'                                                                          '
'                    (C) Copyright 2018 Devil7 Softwares.                  '
'                                                                          '
' Licensed under the Apache License, Version 2.0 (the "License");          '
' you may not use this file except in compliance with the License.         '
' You may obtain a copy of the License at                                  '
'                                                                          '
'                http://www.apache.org/licenses/LICENSE-2.0                '
'                                                                          '
' Unless required by applicable law or agreed to in writing, software      '
' distributed under the License is distributed on an "AS IS" BASIS,        '
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. '
' See the License for the specific language governing permissions and      '
' limitations under the License.                                           '
'                                                                          '
' Contributors :                                                           '
'     Dineshkumar T                                                        '
'                                                                          '
'=========================================================================='

Namespace Utils
    Public Class XtraFormTemp
        Inherits DevExpress.XtraEditors.XtraForm
        Protected Overrides Function GetAllowSkin() As Boolean
            Return True
        End Function
        Sub New()
            Try
                If My.Settings.Skin <> "" Then
                    Me.LookAndFeel.SkinName = My.Settings.Skin
                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Sub XtraFormTemp_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            DevExpress.Skins.SkinManager.EnableFormSkins()
        End Sub
    End Class
End Namespace