Imports System.ComponentModel
Imports System.Data.SQLite

Namespace Database
    Public Class Students

#Region "Variables"
        Private Shared TableName As String = "students"
#End Region

#Region "Public Functions"
        Public Shared Function Load(ByVal Courses As List(Of Objects.Course), ByVal CloseConnection As Boolean) As BindingList(Of Objects.Student)
            Dim R As New BindingList(Of Objects.Student) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}

            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("SELECT * FROM {0};", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Using Reader As SQLiteDataReader = Command.ExecuteReader
                    While Reader.Read
                        Dim ID As Integer = Reader.Item("id")
                        Dim RollNo As Integer = Reader.Item("rollno")
                        Dim Name As String = Reader.Item("name").ToString
                        Dim FatherName As String = Reader.Item("fathername").ToString
                        Dim Course As Objects.Course = Courses.Find(Function(c) c.ID = Reader.Item("course"))
                        Dim Shift As Enums.Shifts = [Enum].Parse(GetType(Enums.Shifts), Reader.Item("shift"))
                        Dim AdmittedYear As Integer = Reader.Item("admittedyear")
                        Dim FingerPrintID As Integer = Reader.Item("fingerprintid")

                        Dim Photo As Bitmap = Nothing
                        Dim PhotoData As Byte() = If(IsDBNull(Reader.Item("photo")), Nothing, Reader.Item("photo"))
                        If PhotoData IsNot Nothing Then
                            Using MS As New IO.MemoryStream(PhotoData)
                                Photo = Image.FromStream(MS)
                            End Using
                        End If

                        R.Add(New Objects.Student(ID, RollNo, Name, FatherName, Course, Shift, Photo, AdmittedYear, FingerPrintID))
                    End While
                End Using
            End Using

            If CloseConnection AndAlso Connection.State = ConnectionState.Open Then Connection.Close()

            Return R
        End Function

        Public Shared Function Add(ByVal Student As Objects.Student) As Boolean
            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("INSERT INTO {0} (rollno,name,fathername,course,shift,photo,admittedyear,fingerprintid) VALUES (@rollno,@name,@fathername,@course,@shift,@photo,@admittedyear,@fingerprintid);SELECT last_insert_rowid();", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Command.Parameters.AddWithValue("@rollno", Student.RollNo)
                Command.Parameters.AddWithValue("@name", Student.Name)
                Command.Parameters.AddWithValue("@fathername", Student.FatherName)
                Command.Parameters.AddWithValue("@course", Student.Course.ID)
                Command.Parameters.AddWithValue("@shift", Student.Shift)
                Command.Parameters.AddWithValue("@admittedyear", Student.AdmittedYear)
                Command.Parameters.AddWithValue("@fingerprintid", Student.FingerPrintID)

                If Student.Photo Is Nothing Then
                    Command.Parameters.AddWithValue("@photo", Nothing)
                Else
                    Using MS As New IO.MemoryStream
                        Student.Photo.Save(MS, Student.Photo.RawFormat)
                        Command.Parameters.AddWithValue("@photo", MS.ToArray)
                    End Using
                End If

                Dim ID As Integer = Command.ExecuteScalar
                If ID > 0 Then
                    Student.ID = ID
                    Return True
                Else
                    Return False
                End If
            End Using
        End Function
#End Region

    End Class
End Namespace