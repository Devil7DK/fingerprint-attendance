Public Class frm_SelectDate

#Region "Variables"
    Dim Courses As List(Of Objects.Course)
#End Region

#Region "Properties"
    Property Year As Integer = 2016
    Property Shift As Enums.Shifts = Enums.Shifts.Shift1
    Property Course As Objects.Course
    Property DateFrom As Date
    Property DateTo As Date
#End Region

#Region "Constructor"
    Sub New(ByVal Courses As List(Of Objects.Course))
        InitializeComponent()

        Me.Courses = Courses
    End Sub
#End Region

#Region "Form Events"
    Private Sub frm_SelectYearShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Course As Objects.Course In Courses
            txt_Course.Properties.Items.Add(Course)
        Next
        For Year As Integer = Now.Year To 2000 Step -1
            txt_Year.Properties.Items.Add(Year)
        Next
        txt_Course.SelectedIndex = 0
        txt_Year.SelectedIndex = 0
        txt_Shift.SelectedIndex = 0
        txt_Date_From.DateTime = Today
        txt_Date_To.DateTime = Today
    End Sub
#End Region

#Region "Button Events"
    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Other Events"
    Private Sub txt_Year_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_Year.SelectedIndexChanged
        Me.Year = txt_Year.SelectedItem
    End Sub

    Private Sub txt_Shift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_Shift.SelectedIndexChanged
        Me.Shift = txt_Shift.SelectedIndex
    End Sub

    Private Sub txt_Course_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_Course.SelectedIndexChanged
        Me.Course = txt_Course.SelectedItem
    End Sub

    Private Sub txt_Date_From_DateTimeChanged(sender As Object, e As EventArgs) Handles txt_Date_From.DateTimeChanged
        Me.DateFrom = txt_Date_From.DateTime
    End Sub

    Private Sub txt_Date_To_DateTimeChanged(sender As Object, e As EventArgs) Handles txt_Date_To.DateTimeChanged
        Me.DateTo = txt_Date_To.DateTime
    End Sub
#End Region

End Class