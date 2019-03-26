Namespace Objects
    Public Class AttendanceConsolidate

#Region "Properties"
        Property DateFrom As Date
        Property DateTo As Date
        Property Course As Course
        Property Year As Integer
        Property Shift As Enums.Shifts

        Property Data As List(Of Item)

        Property TotalHours As Integer
        ReadOnly Property YearStr As String
            Get
                Return String.Format("{0}-{1}", Year, Year + 3)
            End Get
        End Property
        ReadOnly Property ShiftStr As String
            Get
                If Shift = Enums.Shifts.Shift1 Then
                    Return "Shift 1"
                Else
                    Return "Shift 2"
                End If
            End Get
        End Property
#End Region

#Region "Constructor"
        Sub New()
            Me.DateFrom = Today
            Me.DateTo = Today
            Me.Course = Nothing
            Me.Year = Today.Year
            Me.Shift = Enums.Shifts.Shift1
            Me.Data = New List(Of Item)
            Me.TotalHours = 0
        End Sub

        Sub New(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal Course As Course, ByVal Year As Integer, ByVal Shift As Enums.Shifts, ByVal Data As List(Of Item), ByVal TotalHours As Integer)
            Me.DateFrom = DateFrom
            Me.DateTo = DateTo
            Me.Course = Course
            Me.Year = Year
            Me.Shift = Shift
            Me.Data = Data
            Me.TotalHours = TotalHours

            If Data IsNot Nothing And TotalHours > 0 Then
                For Each Item As Item In Data
                    Item.TotalHours = TotalHours
                Next
            End If
        End Sub
#End Region

#Region "Functions"
        Public Shared Function Consolidate(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal Course As Course, ByVal Year As Integer, ByVal Shift As Enums.Shifts, ByVal Students As List(Of Student), ByVal Attendances As List(Of Attendance)) As AttendanceConsolidate
            Dim CurrentAttendances As List(Of Attendance) = Attendances.FindAll(Function(c) c.Course.ID = Course.ID AndAlso c.Shift = Shift AndAlso c.Year = Year AndAlso (c.Date >= DateFrom AndAlso c.Date <= DateTo))
            Dim CurrentStudents As List(Of Student) = Students.FindAll(Function(c) c.Course.ID = Course.ID AndAlso c.AdmittedYear = Year AndAlso c.Shift = Shift)

            CurrentStudents.Sort(New Utils.StudentComparer)

            Dim Data As New List(Of Item)
            For Each Student As Student In CurrentStudents
                Data.Add(New Item(Student))
            Next

            Dim ProcessedHours As New List(Of String)
            Dim TotalHours As Integer = 0
            For Each Attendance As Attendance In CurrentAttendances
                Dim Str As String = String.Format("{0}_{1}", Attendance.Date.ToString("ddMMyy"), Attendance.Hour)
                If Not ProcessedHours.Contains(Str) Then
                    ProcessedHours.Add(Str)
                    TotalHours += 1

                    For Each AttendanceItem As Objects.Attendance.Item In Attendance.AttendanceData
                        If AttendanceItem.AttendanceState = Enums.AttendanceState.Present Or AttendanceItem.AttendanceState = Enums.AttendanceState.OnDuty Then
                            Dim Item As Item = Data.Find(Function(c) c.Student.ID = AttendanceItem.StudentID)
                            If Item IsNot Nothing Then
                                Item.HoursPresent += 1
                            End If
                        End If
                    Next
                End If
            Next

            Return New AttendanceConsolidate(DateFrom, DateTo, Course, Year, Shift, Data, TotalHours)
        End Function
#End Region

#Region "Objects"
        Public Class Item

#Region "Properties"
            Property Student As Student
            Property HoursPresent As Integer
            ReadOnly Property Percentage As Integer
                Get
                    If TotalHours <= 0 Then
                        Return 0
                    Else
                        Return Math.Round((HoursPresent / TotalHours) * 100, 0)
                    End If
                End Get
            End Property

            <System.ComponentModel.Browsable(False)>
            Property TotalHours As Integer
#End Region

#Region "Constructor"
            Sub New(ByVal Student As Student)
                Me.Student = Student
                Me.TotalHours = 0
                Me.HoursPresent = 0
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace