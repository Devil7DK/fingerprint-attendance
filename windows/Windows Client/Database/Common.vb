Imports System.Data.SQLite

Namespace Database
    Public Module Common

#Region "Variables"
        Private Connection As SQLiteConnection
#End Region

#Region "Public Functions"
        Public Function GetConnection() As SQLiteConnection
            If Connection Is Nothing Then
                Connection = New SQLiteConnection(String.Format("Data Source={0};Version=3;Pooling=True;Max Pool Size=100;", IO.Path.Combine(Application.StartupPath, "data.db")))
            End If
            Return Connection
        End Function
#End Region

    End Module
End Namespace