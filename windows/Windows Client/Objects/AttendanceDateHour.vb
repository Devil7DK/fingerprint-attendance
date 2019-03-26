Namespace Objects
    Public Class AttendanceDateHour

#Region "Variables"
        Dim AllStudents As List(Of Student)
        Dim AllAttendanceData As List(Of Attendance)
#End Region

#Region "Properties"
        Property Students As List(Of Student)
        Property AttendanceData As List(Of DateAttendance)
#End Region

#Region "Constructor"
        Sub New(ByVal Students As List(Of Student), ByVal AttendanceData As List(Of Attendance))
            Me.AllStudents = Students
            Me.AllAttendanceData = AttendanceData
        End Sub
#End Region

#Region "Functions"
        Sub Consolidate(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Course As Course, ByVal Year As Integer, ByVal Shift As Enums.Shifts)
            Dim CurrentAttendanceData As List(Of Attendance) = AllAttendanceData.FindAll(Function(c) c.Course.ID = Course.ID AndAlso c.Year = Year AndAlso c.Shift = Shift AndAlso (c.Date >= FromDate AndAlso c.Date <= ToDate))
            Dim CurrentStudents As List(Of Student) = AllStudents.FindAll(Function(c) c.Course.ID = Course.ID AndAlso c.AdmittedYear = Year AndAlso c.Shift = Shift)

            Me.Students = CurrentStudents
            Me.AttendanceData = New List(Of DateAttendance)

            While CurrentAttendanceData.Count <> 0
                Dim Item1 As Attendance = CurrentAttendanceData(0)
                Dim TmpItems As List(Of Attendance) = CurrentAttendanceData.FindAll(Function(c) c.Date = Item1.Date)
                Dim Hours As New Dictionary(Of Integer, Attendance)

                For Each i As Attendance In TmpItems
                    If Not Hours.ContainsKey(i.Hour) Then Hours.Add(i.Hour, i)
                    CurrentAttendanceData.Remove(i)
                Next

                Dim AttendanceItem As New DateAttendance(Item1.Date, Hours.Count)
                For Index1 As Integer = 0 To Hours.Keys.Count - 1
                    Dim Hour As Integer = Hours.Keys(Index1)
                    Dim Attendance As Attendance = Hours.Item(Hour)
                    Dim HourData As New HourAttendance(Hour, CurrentStudents.Count)
                    If HourData IsNot Nothing Then
                        For Index2 As Integer = 0 To CurrentStudents.Count - 1
                            Dim Student As Student = CurrentStudents(Index2)
                            Dim Data As Attendance.Item = Attendance.AttendanceData.ToList().Find(Function(c) c.StudentID = Student.ID)
                            If Data Is Nothing Then
                                HourData.Attendance.SetValue(Enums.AttendanceState.Absent, Index2)
                            Else
                                HourData.Attendance.SetValue(Data.AttendanceState, Index2)
                            End If
                        Next
                    End If
                    AttendanceItem.HourAttendance.SetValue(HourData, Index1)
                Next

                Me.AttendanceData.Add(AttendanceItem)
            End While
        End Sub
#End Region

#Region "Objects"
        Public Class DateAttendance

#Region "Properties"
            Property [Date] As Date
            Property HourAttendance As HourAttendance()
#End Region

#Region "Constructor"
            Sub New(ByVal [Date] As Date, ByVal HoursCount As Integer)
                Me.Date = [Date]
                Me.HourAttendance = Array.CreateInstance(GetType(HourAttendance), HoursCount)
            End Sub
#End Region

        End Class

        Public Class HourAttendance

#Region "Properties"
            Property Hour As Integer
            Property Attendance As Enums.AttendanceState()
#End Region

#Region "Constructor"
            Sub New(ByVal Hour As Integer, ByVal StudentCount As Integer)
                Me.Hour = Hour
                Me.Attendance = Array.CreateInstance(GetType(Enums.AttendanceState), StudentCount)

                For i As Integer = 0 To StudentCount - 1
                    Me.Attendance(i) = Enums.AttendanceState.Absent
                Next
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace