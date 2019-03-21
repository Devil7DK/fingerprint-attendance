Imports System.ComponentModel
Imports System.Data.SQLite

Namespace Database
    Public Class Courses

#Region "Variables"
        Private Shared TableName As String = "courses"
#End Region

#Region "Public Functions"
        Public Shared Function Load(ByVal CloseConnection As Boolean) As BindingList(Of Objects.Course)
            Dim R As New BindingList(Of Objects.Course) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}

            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("SELECT * FROM {0};", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Using Reader As SQLiteDataReader = Command.ExecuteReader
                    While Reader.Read
                        Dim ID As Integer = Reader.Item("id")
                        Dim ShortName As String = Reader.Item("shortname").ToString
                        Dim FullName As String = Reader.Item("fullname").ToString
                        Dim Prefix As String = Reader.Item("prefix").ToString
                        R.Add(New Objects.Course(ID, ShortName, FullName, Prefix))
                    End While
                End Using
            End Using

            If CloseConnection AndAlso Connection.State = ConnectionState.Open Then Connection.Close()

            Return R
        End Function

        Public Shared Function Add(ByVal Course As Objects.Course) As Boolean
            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("INSERT INTO {0} (shortname,fullname,prefix) VALUES (@shortname,@fullname,@prefix);SELECT last_insert_rowid();", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Command.Parameters.AddWithValue("@shortname", Course.ShortName)
                Command.Parameters.AddWithValue("@fullname", Course.FullName)
                Command.Parameters.AddWithValue("@prefix", Course.Prefix)

                Dim ID As Integer = Command.ExecuteScalar
                If ID > 0 Then
                    Course.ID = ID
                    Return True
                Else
                    Return False
                End If
            End Using
        End Function

        Public Shared Function Update(ByVal Course As Objects.Course) As Boolean
            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("UPDATE {0} SET shortname=@shortname,fullname=@fullname,prefix=@prefix WHERE id=@id;", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Command.Parameters.AddWithValue("@id", Course.ID)
                Command.Parameters.AddWithValue("@shortname", Course.ShortName)
                Command.Parameters.AddWithValue("@fullname", Course.FullName)
                Command.Parameters.AddWithValue("@prefix", Course.Prefix)

                Return Command.ExecuteNonQuery = 1
            End Using
        End Function

        Public Shared Function Remove(ByVal Course As Objects.Course) As Boolean
            Return Common.Remove(Course.ID, TableName)
        End Function
#End Region

    End Class
End Namespace