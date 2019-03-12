Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraSplashScreen

Public Class frm_Main

#Region "Variable"
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

        Dim Courses As New BindingList(Of Objects.Course)
        Dim Staffs As New BindingList(Of Objects.Staff)
        Dim Students As New BindingList(Of Objects.Student)
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
        If e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Dim Item As Objects.Course = CType(e.Row, Objects.Course)
            If Database.Courses.Add(Item) Then
                gc_Courses.RefreshDataSource()
            Else
                Courses.Remove(Item)
                gc_Courses.RefreshDataSource()
            End If
        End If
    End Sub

    Private Sub gv_Staffs_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles gv_Staffs.RowUpdated
        If e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Dim Item As Objects.Staff = CType(e.Row, Objects.Staff)
            If Database.Staffs.Add(Item) Then
                gc_Staffs.RefreshDataSource()
            Else
                Staffs.Remove(Item)
                gc_Staffs.RefreshDataSource()
            End If
        End If
    End Sub

    Private Sub gv_Students_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles gv_Students.RowUpdated
        If e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Dim Item As Objects.Student = CType(e.Row, Objects.Student)
            If Database.Students.Add(Item) Then
                gc_Students.RefreshDataSource()
            Else
                Students.Remove(Item)
                gc_Students.RefreshDataSource()
            End If
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
#End Region

End Class