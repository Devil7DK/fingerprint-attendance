﻿Imports System.Data.SQLite

Namespace Database
    Public Module Common

#Region "Variables"
        Private Connection As SQLiteConnection
        Private DatabasePath As String = IO.Path.Combine(Application.StartupPath, "data.db")
#End Region

#Region "Public Functions"
        Public Function GetConnection() As SQLiteConnection
            If Connection Is Nothing Then
                Connection = New SQLiteConnection(String.Format("Data Source={0};Version=3;Pooling=True;Max Pool Size=100;", DatabasePath))
            End If
            Return Connection
        End Function

        Public Function Remove(ByVal ID As Integer, ByVal TableName As String)
            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("DELETE FROM {0} WHERE id=@id", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Command.Parameters.AddWithValue("@id", ID)

                Return Command.ExecuteNonQuery = 1
            End Using
        End Function

        Public Function GetSize() As Integer
            Return My.Computer.FileSystem.GetFileInfo(DatabasePath).Length
        End Function

        Public Sub Compact()
            Using cmd As SQLiteCommand = GetConnection.CreateCommand
                cmd.CommandText = "vacuum"
                cmd.ExecuteNonQuery()
            End Using
        End Sub
#End Region

    End Module
End Namespace