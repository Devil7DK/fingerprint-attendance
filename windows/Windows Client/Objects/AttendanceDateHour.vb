Imports DevExpress.Spreadsheet

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

            CurrentStudents.Sort(New Utils.StudentComparer)

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

        Sub GenerateExcel(ByVal FilePath As String)
            Dim Workbook As New Workbook
            Dim Sheet As Worksheet = Workbook.Sheets.Item(0)
            Workbook.Unit = DevExpress.Office.DocumentUnit.Point

            ' Common
            Dim BeginRow As Integer = 2
            Dim BeginColumn As Integer = 4
            Dim CurrentColumn As Integer = BeginColumn
            Dim MaxRowStudents As Integer = BeginRow
            Dim MaxRow As Integer = BeginRow

            Dim HeaderColor As Color = Color.FromArgb(40, 96, 164)
            Dim SubHeaderColor As Color = Color.FromArgb(83, 141, 213)

            Dim DateColumnWidth As Integer = 60
            Dim HourColumnWidth As Integer = 30

            Dim SumPresent As Integer() = Array.CreateInstance(GetType(Integer), Students.Count)
            Dim SumOnDuty As Integer() = Array.CreateInstance(GetType(Integer), Students.Count)
            Dim SumAbsent As Integer() = Array.CreateInstance(GetType(Integer), Students.Count)
            For i As Integer = 0 To Students.Count - 1
                SumPresent(i) = 0
                SumOnDuty(i) = 0
                SumAbsent(i) = 0
            Next

            ' Serial Number
            Dim SerialNoCell = Sheet.Range("A1:A2")
            Sheet.MergeCells(SerialNoCell)
            SerialNoCell.Font.Bold = True
            SerialNoCell.Font.Color = Color.White
            SerialNoCell.FillColor = HeaderColor
            SerialNoCell.SetValueFromText("Sl. No.")

            For SerialNo As Integer = 1 To Students.Count
                Sheet.Cells.Item(String.Format("A{0}", BeginRow + SerialNo)).SetValueFromText(SerialNo)
            Next

            ' Reg No
            Dim RegNoCell = Sheet.Range("B1:B2")
            Sheet.MergeCells(RegNoCell)
            RegNoCell.Font.Bold = True
            RegNoCell.Font.Color = Color.White
            RegNoCell.FillColor = HeaderColor
            RegNoCell.SetValueFromText("Reg. No.")

            For Index As Integer = 0 To Students.Count - 1
                Sheet.Cells.Item(String.Format("B{0}", BeginRow + Index + 1)).SetValueFromText(Students(Index).RegNo)
            Next

            ' Student Name
            Dim NameCell = Sheet.Range("C1:C2")
            Sheet.MergeCells(NameCell)
            NameCell.Font.Bold = True
            NameCell.Font.Color = Color.White
            NameCell.FillColor = HeaderColor
            NameCell.SetValueFromText("Student Name")

            For Index As Integer = 0 To Students.Count - 1
                Sheet.Cells.Item(String.Format("C{0}", BeginRow + Index + 1)).SetValueFromText(Students(Index).Name)
            Next
            MaxRowStudents += Students.Count
            MaxRow = MaxRowStudents + 2

            ' Present Row
            Dim PresentHeaderCell = Sheet.Range(String.Format("A{0}:C{0}", MaxRow))
            Sheet.MergeCells(PresentHeaderCell)
            PresentHeaderCell.Font.Bold = True
            PresentHeaderCell.Font.Color = Color.White
            PresentHeaderCell.FillColor = HeaderColor
            PresentHeaderCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right
            PresentHeaderCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
            PresentHeaderCell.SetValueFromText("No. of Students Present")
            MaxRow += 1

            ' On Duty Row
            Dim OnDutyHeaderCell = Sheet.Range(String.Format("A{0}:C{0}", MaxRow))
            Sheet.MergeCells(OnDutyHeaderCell)
            OnDutyHeaderCell.Font.Bold = True
            OnDutyHeaderCell.Font.Color = Color.White
            OnDutyHeaderCell.FillColor = HeaderColor
            OnDutyHeaderCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right
            OnDutyHeaderCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
            OnDutyHeaderCell.SetValueFromText("No. of Students On Duty")
            MaxRow += 1

            ' Absent Row
            Dim AbsentHeaderCell = Sheet.Range(String.Format("A{0}:C{0}", MaxRow))
            Sheet.MergeCells(AbsentHeaderCell)
            AbsentHeaderCell.Font.Bold = True
            AbsentHeaderCell.Font.Color = Color.White
            AbsentHeaderCell.FillColor = HeaderColor
            AbsentHeaderCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right
            AbsentHeaderCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
            AbsentHeaderCell.SetValueFromText("No. of Students Absent")

            ' Attendance
            For Each DateAttendance As DateAttendance In Me.AttendanceData
                ' Date Header
                Dim DateHeaderCell = Sheet.Range(String.Format("{0}1:{1}1", GetColumnName(CurrentColumn), GetColumnName(CurrentColumn + DateAttendance.HourAttendance.Count - 1)))
                Sheet.MergeCells(DateHeaderCell)
                DateHeaderCell.Font.Bold = True
                DateHeaderCell.Font.Color = Color.White
                DateHeaderCell.FillColor = HeaderColor
                DateHeaderCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
                DateHeaderCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
                DateHeaderCell.SetValueFromText(DateAttendance.Date.ToString("dd-MM-yyyy"))


                Dim StartColumnName As String = GetColumnName(CurrentColumn)
                Dim EndColumnName As String = GetColumnName(CurrentColumn)
                ' Hours
                For Each HourAttendance As HourAttendance In DateAttendance.HourAttendance
                    Dim ColumnName As String = GetColumnName(CurrentColumn)
                    EndColumnName = ColumnName

                    Dim HourHeaderCell = Sheet.Range(String.Format("{0}2", ColumnName))
                    HourHeaderCell.Font.Bold = True
                    HourHeaderCell.Font.Color = Color.White
                    HourHeaderCell.FillColor = SubHeaderColor
                    HourHeaderCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
                    HourHeaderCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
                    HourHeaderCell.SetValueFromText(HourAttendance.Hour)
                    HourHeaderCell.ColumnWidth = HourColumnWidth

                    Dim Present As Integer = 0
                    Dim Absent As Integer = 0
                    Dim OnDuty As Integer = 0
                    Dim CurrentRow As Integer = BeginRow + 1
                    For Index As Integer = 0 To HourAttendance.Attendance.Count - 1
                        Dim HourCell = Sheet.Range(String.Format("{0}{1}", ColumnName, CurrentRow))
                        HourCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
                        HourCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
                        Select Case HourAttendance.Attendance(Index)
                            Case Enums.AttendanceState.Absent
                                HourCell.SetValueFromText("A")
                                HourCell.Font.Color = Color.Red
                                Absent += 1
                                SumAbsent(Index) += 1
                            Case Enums.AttendanceState.OnDuty
                                HourCell.SetValueFromText("OD")
                                OnDuty += 1
                                SumOnDuty(Index) += 1
                            Case Enums.AttendanceState.Present
                                HourCell.SetValueFromText("P")
                                Present += 1
                                SumPresent(Index) += 1
                        End Select
                        CurrentRow += 1
                    Next
                    CurrentColumn += 1

                    CurrentRow += 1
                    ' No of Present
                    Dim PresentCell = Sheet.Range(String.Format("{0}{1}", ColumnName, CurrentRow))
                    Sheet.MergeCells(PresentCell)
                    PresentCell.Font.Bold = True
                    PresentCell.Font.Color = Color.White
                    PresentCell.FillColor = HeaderColor
                    PresentCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right
                    PresentCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
                    PresentCell.SetValueFromText(Present)
                    CurrentRow += 1

                    ' No of OnDuty
                    Dim OnDutyCell = Sheet.Range(String.Format("{0}{1}", ColumnName, CurrentRow))
                    Sheet.MergeCells(OnDutyCell)
                    OnDutyCell.Font.Bold = True
                    OnDutyCell.Font.Color = Color.White
                    OnDutyCell.FillColor = HeaderColor
                    OnDutyCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right
                    OnDutyCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
                    OnDutyCell.SetValueFromText(OnDuty)
                    CurrentRow += 1

                    ' No of Absent
                    Dim AbsentCell = Sheet.Range(String.Format("{0}{1}", ColumnName, CurrentRow))
                    Sheet.MergeCells(AbsentCell)
                    AbsentCell.Font.Bold = True
                    AbsentCell.Font.Color = Color.White
                    AbsentCell.FillColor = HeaderColor
                    AbsentCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right
                    AbsentCell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
                    AbsentCell.SetValueFromText(Absent)
                    CurrentRow += 1

                Next

                ' Outer Boarder
                Dim BorderRange = Sheet.Range(String.Format("{0}1:{1}{2}", StartColumnName, EndColumnName, MaxRow))
                BorderRange.Borders.SetOutsideBorders(Color.Black, BorderLineStyle.Thick)
                If (BorderRange.ColumnWidth * BorderRange.ColumnCount) < DateColumnWidth Then BorderRange.ColumnWidth = (DateColumnWidth / BorderRange.ColumnCount)
            Next

            ' Summary
            Dim SumStartColumn As String = GetColumnName(CurrentColumn)
            Dim SummaryCell = Sheet.Range(String.Format("{0}1:{1}1", GetColumnName(CurrentColumn), GetColumnName(CurrentColumn + 2)))
            Sheet.MergeCells(SummaryCell)
            SummaryCell.Font.Bold = True
            SummaryCell.Font.Color = Color.White
            SummaryCell.FillColor = HeaderColor
            SummaryCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
            SummaryCell.SetValueFromText("Summary")

            ' Sum Present
            Dim SumPresentCell = Sheet.Range(String.Format("{0}2", GetColumnName(CurrentColumn)))
            SumPresentCell.Font.Bold = True
            SumPresentCell.Font.Color = Color.White
            SumPresentCell.FillColor = SubHeaderColor
            SumPresentCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
            SumPresentCell.SetValueFromText("Present")
            For Index As Integer = 0 To Students.Count - 1
                Sheet.Cells.Item(String.Format("{0}{1}", GetColumnName(CurrentColumn), BeginRow + Index + 1)).SetValueFromText(SumPresent(Index))
            Next
            CurrentColumn += 1

            ' Sum OnDuty
            Dim SumOnDutyCell = Sheet.Range(String.Format("{0}2", GetColumnName(CurrentColumn)))
            SumOnDutyCell.Font.Bold = True
            SumOnDutyCell.Font.Color = Color.White
            SumOnDutyCell.FillColor = SubHeaderColor
            SumOnDutyCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
            SumOnDutyCell.SetValueFromText("OnDuty")
            For Index As Integer = 0 To Students.Count - 1
                Sheet.Cells.Item(String.Format("{0}{1}", GetColumnName(CurrentColumn), BeginRow + Index + 1)).SetValueFromText(SumOnDuty(Index))
            Next
            CurrentColumn += 1

            ' Sum Absent
            Dim SumAbsentCell = Sheet.Range(String.Format("{0}2", GetColumnName(CurrentColumn)))
            SumAbsentCell.Font.Bold = True
            SumAbsentCell.Font.Color = Color.White
            SumAbsentCell.FillColor = SubHeaderColor
            SumAbsentCell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
            SumAbsentCell.SetValueFromText("Absent")
            For Index As Integer = 0 To Students.Count - 1
                Sheet.Cells.Item(String.Format("{0}{1}", GetColumnName(CurrentColumn), BeginRow + Index + 1)).SetValueFromText(SumAbsent(Index))
            Next

            Dim SumBorderRange = Sheet.Range(String.Format("{0}1:{1}{2}", SumStartColumn, GetColumnName(CurrentColumn), MaxRow))
            SumBorderRange.Borders.SetOutsideBorders(Color.Black, BorderLineStyle.Thick)

            Workbook.SaveDocument(FilePath, DocumentFormat.Xlsx)
        End Sub

        Private Function GetColumnName(ColumnNumber As Integer) As String
            Dim Dividend As Integer = ColumnNumber
            Dim ColumnName As String = String.Empty
            Dim Modulo As Integer

            While Dividend > 0
                Modulo = (Dividend - 1) Mod 26
                ColumnName = Convert.ToChar(65 + Modulo).ToString() & ColumnName
                Dividend = CInt((Dividend - Modulo) / 26)
            End While

            Return ColumnName
        End Function
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