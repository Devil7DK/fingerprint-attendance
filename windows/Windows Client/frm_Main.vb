Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class frm_Main

#Region "Variables"
    Dim OverlayHandle As IOverlaySplashScreenHandle
#End Region

#Region "Properties"
    Property Courses As BindingList(Of Objects.Course)
        Get
            Return CType(gc_Courses.DataSource, BindingList(Of Objects.Course))
        End Get
        Set(value As BindingList(Of Objects.Course))
            gc_Courses.DataSource = value
            gc_Courses.RefreshDataSource()
        End Set
    End Property

    Property Students As BindingList(Of Objects.Student)
        Get
            Return CType(gc_Students.DataSource, BindingList(Of Objects.Student))
        End Get
        Set(value As BindingList(Of Objects.Student))
            gc_Students.DataSource = value
            gc_Students.RefreshDataSource()
        End Set
    End Property

    Property Staffs As BindingList(Of Objects.Staff)
        Get
            Return CType(gc_Staffs.DataSource, BindingList(Of Objects.Staff))
        End Get
        Set(value As BindingList(Of Objects.Staff))
            gc_Staffs.DataSource = value
            gc_Staffs.RefreshDataSource()
        End Set
    End Property

    Property Attendances As BindingList(Of Objects.Attendance)
        Get
            Return CType(gc_Attendance.DataSource, BindingList(Of Objects.Attendance))
        End Get
        Set(value As BindingList(Of Objects.Attendance))
            gc_Attendance.DataSource = value
            gc_Attendance.RefreshDataSource()
        End Set
    End Property
#End Region

#Region "Subs"
    Private Async Function LoadData() As Task
        ShowProgressPanel()

        Dim Courses As New BindingList(Of Objects.Course) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}
        Dim Staffs As New BindingList(Of Objects.Staff) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}
        Dim Students As New BindingList(Of Objects.Student) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}
        Dim Attendances As New BindingList(Of Objects.Attendance) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}
        Await Task.Run(Sub()
                           Courses = Database.Courses.Load(False)
                           Staffs = Database.Staffs.Load(False)
                           Students = Database.Students.Load(Courses.ToList, False)
                           Attendances = Database.Attendances.Load(True, Courses.ToList, Staffs.ToList, Students.ToList)
                       End Sub)
        Me.Courses = Courses
        Me.Staffs = Staffs
        Me.Students = Students
        Me.Attendances = Attendances

        HideProgressPanel()
    End Function

    Private Function FormatBytes(ByVal BytesCaller As ULong) As String
        Dim DoubleBytes As Double

        Try
            Select Case BytesCaller
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(BytesCaller / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(BytesCaller / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(BytesCaller / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(BytesCaller / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = BytesCaller ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return "0 bytes"
        End Try
    End Function
#End Region

#Region "Progress Panel"
    Sub ShowProgressPanel()
        OverlayHandle = SplashScreenManager.ShowOverlayForm(Me)
    End Sub

    Sub HideProgressPanel()
        If OverlayHandle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(OverlayHandle)
    End Sub
#End Region

#Region "Grid Events"
    Private Sub gv_Courses_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles gv_Courses.RowUpdated
        Dim Item As Objects.Course = CType(e.Row, Objects.Course)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If Database.Courses.Add(Item) Then
                gc_Courses.RefreshDataSource()
            Else
                Courses.Remove(Item)
                gc_Courses.RefreshDataSource()
            End If
        Else
            If Database.Courses.Update(Item) Then
                gc_Courses.RefreshDataSource()
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save edited values to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub gv_Staffs_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles gv_Staffs.RowUpdated
        Dim Item As Objects.Staff = CType(e.Row, Objects.Staff)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If Database.Staffs.Add(Item) Then
                gc_Staffs.RefreshDataSource()
            Else
                Staffs.Remove(Item)
                gc_Staffs.RefreshDataSource()
            End If
        Else
            If Database.Staffs.Update(Item) Then
                gc_Staffs.RefreshDataSource()
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save edited values to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub gv_Students_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles gv_Students.RowUpdated
        Dim Item As Objects.Student = CType(e.Row, Objects.Student)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If Database.Students.Add(Item) Then
                gc_Students.RefreshDataSource()
            Else
                Students.Remove(Item)
                gc_Students.RefreshDataSource()
            End If
        Else
            If Database.Students.Update(Item) Then
                gc_Students.RefreshDataSource()
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save edited values to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub gv_Attendances_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles gv_Attendance.RowUpdated
        Dim Item As Objects.Attendance = CType(e.Row, Objects.Attendance)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If Database.Attendances.Add(Item) Then
                gc_Attendance.RefreshDataSource()
            Else
                Attendances.Remove(Item)
                gc_Attendance.RefreshDataSource()
            End If
        Else
            If Database.Attendances.Update(Item) Then
                gc_Attendance.RefreshDataSource()
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save edited values to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub gv_Students_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles gv_Students.CustomRowCellEdit
        If e.Column.FieldName = "Course" Then
            Dim cmb As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
            cmb.Items.AddRange(Courses.ToArray)
            e.RepositoryItem = cmb
        End If
    End Sub

    Private Sub gv_Attendance_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles gv_Attendance.CustomRowCellEdit
        If e.Column.FieldName = "Hour" Then
            Dim cmb As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
            cmb.Items.AddRange({1, 2, 3, 4, 5})
            e.RepositoryItem = cmb
        ElseIf e.Column.FieldName = "Course" Then
            Dim cmb As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
            cmb.Items.AddRange(Courses.ToArray)
            e.RepositoryItem = cmb
        ElseIf e.Column.FieldName = "Year" Then
            Dim cmb As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
            For i As Integer = Now.Year To 2000 Step -1
                cmb.Items.Add(i)
            Next
            e.RepositoryItem = cmb
        ElseIf e.Column.FieldName = "Staff" Then
            Dim cmb As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
            cmb.Items.AddRange(Staffs.ToArray)
            e.RepositoryItem = cmb
        End If
    End Sub

    Private Sub gc_Attendance_ViewRegistered(sender As Object, e1 As ViewOperationEventArgs) Handles gc_Attendance.ViewRegistered
        If e1.View.IsDetailView Then
            AddHandler CType(e1.View, GridView).CustomRowCellEdit, Sub(ByVal s As Object, e As CustomRowCellEditEventArgs)
                                                                       If e.Column.FieldName = "Student" Then
                                                                           Dim cmb As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
                                                                           cmb.Items.AddRange(Students.ToArray)
                                                                           e.RepositoryItem = cmb
                                                                       End If
                                                                   End Sub

            AddHandler CType(e1.View, GridView).RowUpdated, Sub(ByVal s As Object, e As RowEventArgs)
                                                                If e1.View.SourceRow IsNot Nothing Then
                                                                    Database.Attendances.Update(CType(e1.View.SourceRow, Objects.Attendance))
                                                                End If
                                                            End Sub
        End If
    End Sub

    Private Sub gv_Courses_RowDeleting(sender As Object, e As RowDeletingEventArgs) Handles gv_Courses.RowDeleting
        If Not Database.Courses.Remove(CType(e.Row, Objects.Course)) Then
            e.Cancel = True
            DevExpress.XtraEditors.XtraMessageBox.Show("Unable to remove selected item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub gv_Staffs_RowDeleting(sender As Object, e As RowDeletingEventArgs) Handles gv_Staffs.RowDeleting
        If Not Database.Staffs.Remove(CType(e.Row, Objects.Staff)) Then
            e.Cancel = True
            DevExpress.XtraEditors.XtraMessageBox.Show("Unable to remove selected item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub gv_Students_RowDeleting(sender As Object, e As RowDeletingEventArgs) Handles gv_Students.RowDeleting
        If Not Database.Students.Remove(CType(e.Row, Objects.Student)) Then
            e.Cancel = True
            DevExpress.XtraEditors.XtraMessageBox.Show("Unable to remove selected item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub gv_Attendance_RowDeleting(sender As Object, e As RowDeletingEventArgs) Handles gv_Attendance.RowDeleting
        If Not Database.Attendances.Remove(CType(e.Row, Objects.Attendance)) Then
            e.Cancel = True
            DevExpress.XtraEditors.XtraMessageBox.Show("Unable to remove selected item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub gc_Courses_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles gc_Courses.ProcessGridKey
        If e.KeyData = Keys.Delete Then
            gv_Courses.DeleteSelectedRows()
            e.Handled = True
        End If
    End Sub

    Private Sub gc_Staffs_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles gc_Staffs.ProcessGridKey
        If e.KeyData = Keys.Delete Then
            gv_Staffs.DeleteSelectedRows()
            e.Handled = True
        End If
    End Sub

    Private Sub gc_Students_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles gc_Students.ProcessGridKey
        If e.KeyData = Keys.Delete Then
            gv_Students.DeleteSelectedRows()
            e.Handled = True
        End If
    End Sub

    Private Sub gc_Attendance_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles gc_Attendance.ProcessGridKey
        If e.KeyData = Keys.Delete Then
            gv_Attendance.DeleteSelectedRows()
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Form Events"
    Private Async Sub frm_Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Await LoadData()
    End Sub
#End Region

#Region "Button Events"
    Private Async Sub btn_Refresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Refresh.ItemClick
        Await LoadData()
    End Sub

    Private Sub btn_Comm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Comm.ItemClick
        Dim YearShift As New frm_SelectYearShift(Courses.ToList)
        If YearShift.ShowDialog = DialogResult.OK Then
            Dim Students As List(Of Objects.Student) = Me.Students.ToList.FindAll(Function(c) c.AdmittedYear = YearShift.Year And c.Shift = YearShift.Shift And c.Course.ID = YearShift.Course.ID)
            Dim D As New frm_DeviceComm(Students, Staffs.ToList, YearShift.Year, YearShift.Shift, YearShift.Course, Attendances.ToList)
            D.ShowDialog()
        End If
    End Sub

    Private Sub btn_CompactDatabase_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_CompactDatabase.ItemClick
        Try
            Dim SizePrevious As Integer = Database.GetSize
            Database.Compact()
            Dim SizeAfter As Integer = Database.GetSize
            DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("Successfully shrinked the database!{0}{0}Size Before Shrink:{1}{0}Size After Shrink: {2}", vbNewLine, FormatBytes(SizePrevious), FormatBytes(SizeAfter)), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Exit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Exit.ItemClick
        Me.Close()
    End Sub

    Private Async Sub btn_Report_Percentage_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Report_Percentage.ItemClick
        Await Task.Run(Sub()
                           Dim D As frm_SelectDate
                           Dim DialogResult As DialogResult = DialogResult.Cancel
                           Invoke(Sub()
                                      Dim D1 As New frm_SelectDate(Courses.ToList)
                                      DialogResult = D1.ShowDialog
                                      D = D1
                                  End Sub)
                           If DialogResult = DialogResult.OK Then
                               Invoke(Sub() ShowProgressPanel())
                               Dim Data As Objects.AttendanceConsolidate = Objects.AttendanceConsolidate.Consolidate(D.DateFrom, D.DateTo, D.Course, D.Year, D.Shift, Students.ToList, Attendances.ToList)
                               Dim Report As New report_Consolidated(Data)
                               Invoke(Sub() HideProgressPanel())
                               Invoke(Sub()
                                          Dim Viewer As New frm_ReportViewer(Report)
                                          Viewer.ShowDialog()
                                      End Sub)
                           End If
                       End Sub)
    End Sub

    Private Async Sub btn_Report_Date_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Report_Date.ItemClick
        Dim D As New frm_SelectDate(Courses.ToList)
        If D.ShowDialog(Me) = DialogResult.OK Then
            dlg_SaveExcel.FileName = String.Format("Attendance_{0}_{1}_{2}_{3} to {4}.xlsx", D.Course.ShortName, If(D.Shift = Enums.Shifts.Shift1, "Shift I", "Shift II"), String.Format("{0}-{1}", D.Year.ToString.Substring(2, 2), (D.Year + 3).ToString.Substring(2, 2)), D.DateFrom.ToString("dd-MM-yyyy"), D.DateTo.ToString("dd-MM-yyyy"))
            If dlg_SaveExcel.ShowDialog(Me) = DialogResult.OK Then
                Try
                    ShowProgressPanel()
                    Await Task.Run(Sub()
                                       Dim Data As New Objects.AttendanceDateHour(Students.ToList, Attendances.ToList)
                                       Data.Consolidate(D.DateFrom, D.DateTo, D.Course, D.Year, D.Shift)
                                       Data.GenerateExcel(dlg_SaveExcel.FileName)
                                       Invoke(Sub()
                                                  If DevExpress.XtraEditors.XtraMessageBox.Show("Report generated successfully & saved to selected location. Do you want to open generated file...?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                                                      Process.Start(dlg_SaveExcel.FileName)
                                                  End If
                                              End Sub)
                                   End Sub)
                    HideProgressPanel()
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
#End Region

End Class