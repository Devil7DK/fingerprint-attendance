Imports System.ComponentModel
Imports DevExpress.Data
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
#End Region

#Region "Subs"
    Private Async Function LoadData() As Task
        ShowProgressPanel()

        Dim Courses As New BindingList(Of Objects.Course) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}
        Dim Staffs As New BindingList(Of Objects.Staff) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}
        Dim Students As New BindingList(Of Objects.Student) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}
        Await Task.Run(Sub()
                           Courses = Database.Courses.Load(False)
                           Staffs = Database.Staffs.Load(False)
                           Students = Database.Students.Load(Courses.ToList, True)
                       End Sub)
        Me.Courses = Courses
        Me.Staffs = Staffs
        Me.Students = Students

        HideProgressPanel()
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

    Private Sub gv_Students_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles gv_Students.CustomRowCellEdit
        If e.Column.FieldName = "Course" Then
            Dim cmb As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
            cmb.Items.AddRange(Courses.ToArray)
            e.RepositoryItem = cmb
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
            Dim D As New frm_DeviceComm(Students, Staffs.ToList, YearShift.Year, YearShift.Shift, YearShift.Course)
            D.ShowDialog()
        End If
    End Sub
#End Region

End Class