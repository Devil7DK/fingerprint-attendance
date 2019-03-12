Imports System.ComponentModel
Imports System.Data.SQLite

Namespace Database
    Public Class Staffs

#Region "Variables"
        Private Shared TableName As String = "staffs"
#End Region

#Region "Public Functions"
        Public Shared Function Load(ByVal CloseConnection As Boolean) As BindingList(Of Objects.Staff)
            Dim R As New BindingList(Of Objects.Staff) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}

            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("SELECT * FROM {0};", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Using Reader As SQLiteDataReader = Command.ExecuteReader
                    While Reader.Read
                        Dim ID As Integer = Reader.Item("id")
                        Dim Name As String = Reader.Item("name").ToString
                        Dim FingerPrintID As Integer = Reader.Item("fingerprintid")

                        Dim Photo As Bitmap = Nothing
                        Dim PhotoData As Byte() = If(IsDBNull(Reader.Item("photo")), Nothing, Reader.Item("photo"))
                        If PhotoData IsNot Nothing Then
                            Using MS As New IO.MemoryStream(PhotoData)
                                Photo = Image.FromStream(MS)
                            End Using
                        End If

                        R.Add(New Objects.Staff(ID, Name, Photo, FingerPrintID))
                    End While
                End Using
            End Using

            If CloseConnection AndAlso Connection.State = ConnectionState.Open Then Connection.Close()

            Return R
        End Function

        Public Shared Function Add(ByVal Staff As Objects.Staff) As Boolean
            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("INSERT INTO {0} (name,photo,fingerprintid) VALUES (@name,@photo,@fingerprintid);SELECT last_insert_rowid();", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Command.Parameters.AddWithValue("@name", Staff.Name)
                Command.Parameters.AddWithValue("@fingerprintid", Staff.FingerPrintID)

                If Staff.Photo Is Nothing Then
                    Command.Parameters.AddWithValue("@photo", Nothing)
                Else
                    Using MS As New IO.MemoryStream
                        Staff.Photo.Save(MS, Staff.Photo.RawFormat)
                        Command.Parameters.AddWithValue("@photo", MS.ToArray)
                    End Using
                End If

                Dim ID As Integer = Command.ExecuteScalar
                If ID > 0 Then
                    Staff.ID = ID
                    Return True
                Else
                    Return False
                End If
            End Using
        End Function
#End Region

    End Class
End Namespace