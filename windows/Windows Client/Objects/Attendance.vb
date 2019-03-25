Imports System.ComponentModel

Namespace Objects
    Public Class Attendance

#Region "Properties"
        Property ID As Integer
        Property [Date] As Date
        Property Hour As Integer
        Property Course As Course
        Property Year As Integer
        Property Shift As Enums.Shifts
        Property Staff As Staff
        Property AttendanceData As BindingList(Of Item)
#End Region

#Region "Constructor"
        Sub New()
            Me.ID = -1
            Me.Date = Now
            Me.Hour = 1
            Me.Course = Nothing
            Me.Year = Now.Year
            Me.Shift = Enums.Shifts.Shift1
            Me.Staff = Nothing
            Me.AttendanceData = New BindingList(Of Item) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}
        End Sub

        Sub New(ByVal ID As Integer, ByVal [Date] As Date, ByVal Hour As Integer, ByVal Course As Course, ByVal Year As Integer, ByVal Shift As Enums.Shifts, ByVal Staff As Objects.Staff, ByVal AttendanceData As BindingList(Of Item))
            Me.ID = ID
            Me.Date = [Date]
            Me.Hour = Hour
            Me.Course = Course
            Me.Year = Year
            Me.Shift = Shift
            Me.Staff = Staff
            Me.AttendanceData = AttendanceData
            With AttendanceData
                .AllowNew = True
                .AllowEdit = True
                .AllowRemove = True
            End With
        End Sub
#End Region

#Region "Objects"
        Public Class Item

#Region "Properties"
            Property StudentID As Integer
                Get
                    Return If(Student Is Nothing, -1, Student.ID)
                End Get
                Set(value As Integer)

                End Set
            End Property

            <Xml.Serialization.XmlIgnore>
            Property Student As Student
            Property AttendanceState As Enums.AttendanceState
#End Region

#Region "Constructor"
            Sub New()
                Me.Student = Nothing
                Me.AttendanceState = Enums.AttendanceState.Absent
            End Sub

            Sub New(ByVal Student As Student, ByVal AttendanceState As Enums.AttendanceState)
                Me.Student = Student
                Me.AttendanceState = AttendanceState
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace