Imports System.ComponentModel
Imports System.Data.SQLite

Namespace Database
    Public Class Attendances

#Region "Variables"
        Private Shared TableName As String = "attendance"
#End Region

#Region "Public Functions"
        Public Shared Function Load(ByVal CloseConnection As Boolean, ByVal Courses As List(Of Objects.Course), ByVal Staffs As List(Of Objects.Staff), ByVal Students As List(Of Objects.Student)) As BindingList(Of Objects.Attendance)
            Dim R As New BindingList(Of Objects.Attendance) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}

            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("SELECT * FROM {0};", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Using Reader As SQLiteDataReader = Command.ExecuteReader
                    While Reader.Read
                        Dim ID As Integer = Reader.Item("id")
                        Dim [Date] As Date = Date.Parse(Reader.Item("date"))
                        Dim Hour As Integer = Reader.Item("hour")
                        Dim Course As Objects.Course = Courses.Find(Function(c) c.ID = Reader.Item("course"))
                        Dim Year As Integer = Reader.Item("year")
                        Dim Shift As Enums.Shifts = Reader.Item("shift")
                        Dim Staff As Objects.Staff = Staffs.Find(Function(c) c.ID = Reader.Item("staff"))

                        Dim AttendanceData As BindingList(Of Objects.Attendance.Item) = Utils.Serializer.FromZXML(Of BindingList(Of Objects.Attendance.Item))(If(IsDBNull(Reader.Item("data")), Nothing, CType(Reader.Item("data"), Byte())))
                        For i As Integer = 0 To AttendanceData.Count - 1
                            Dim Student As Objects.Student = Students.Find(Function(c) c.ID = AttendanceData(i).StudentID)
                            If Student IsNot Nothing Then
                                AttendanceData(i).Student = Student
                            End If
                        Next

                        R.Add(New Objects.Attendance(ID, [Date], Hour, Course, Year, Shift, Staff, AttendanceData))
                    End While
                End Using
            End Using

            If CloseConnection AndAlso Connection.State = ConnectionState.Open Then Connection.Close()

            Return R
        End Function

        Public Shared Function Add(ByVal Attendance As Objects.Attendance) As Boolean
            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("INSERT INTO {0} (date,hour,course,year,shift,staff,data) VALUES (@date,@hour,@course,@year,@shift,@staff,@data);SELECT last_insert_rowid();", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Command.Parameters.AddWithValue("@date", Attendance.Date.ToString("dd/MM/yyyy"))
                Command.Parameters.AddWithValue("@hour", Attendance.Hour)
                Command.Parameters.AddWithValue("@course", Attendance.Course.ID)
                Command.Parameters.AddWithValue("@year", Attendance.Year)
                Command.Parameters.AddWithValue("@shift", CInt(Attendance.Shift))
                Command.Parameters.AddWithValue("@staff", Attendance.Staff.ID)
                Command.Parameters.AddWithValue("@data", Utils.Serializer.ToZXML(Attendance.AttendanceData))

                Dim ID As Integer = Command.ExecuteScalar
                If ID > 0 Then
                    Attendance.ID = ID
                    Return True
                Else
                    Return False
                End If
            End Using
        End Function

        Public Shared Function Update(ByVal Attendance As Objects.Attendance) As Boolean
            Dim Connection As SQLiteConnection = GetConnection()
            Dim CommandString As String = String.Format("UPDATE {0} SET date=@date,hour=@hour,course=@course,year=@year,shift=@shift,staff=@staff,data=@data WHERE id=@id;", TableName)

            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Using Command As New SQLiteCommand(CommandString, Connection)
                Command.Parameters.AddWithValue("@id", Attendance.ID)
                Command.Parameters.AddWithValue("@date", Attendance.Date.ToString("dd/MM/yyyy"))
                Command.Parameters.AddWithValue("@hour", Attendance.Hour)
                Command.Parameters.AddWithValue("@course", Attendance.Course.ID)
                Command.Parameters.AddWithValue("@year", Attendance.Year)
                Command.Parameters.AddWithValue("@shift", CInt(Attendance.Shift))
                Command.Parameters.AddWithValue("@staff", Attendance.Staff.ID)
                Command.Parameters.AddWithValue("@data", Utils.Serializer.ToZXML(Attendance.AttendanceData))

                Return Command.ExecuteNonQuery = 1
            End Using
        End Function

        Public Shared Function Remove(ByVal Attendance As Objects.Attendance) As Boolean
            Return Common.Remove(Attendance.ID, TableName)
        End Function
#End Region

    End Class
End Namespace