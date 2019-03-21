Imports System.IO.Ports

Public Class frm_DeviceComm

#Region "Variables"
    Dim OverlayHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle
#End Region

#Region "Properties"
    Property Students As List(Of Objects.Student)
        Get
            If gc_Students.DataSource Is Nothing Then gc_Students.DataSource = New List(Of Objects.Student)
            Return CType(gc_Students.DataSource, List(Of Objects.Student))
        End Get
        Set(value As List(Of Objects.Student))
            gc_Students.DataSource = value
            gc_Students.RefreshDataSource()
        End Set
    End Property

    Property Staffs As List(Of Objects.Staff)
        Get
            If gc_Staffs.DataSource Is Nothing Then gc_Staffs.DataSource = New List(Of Objects.Staff)
            Return CType(gc_Staffs.DataSource, List(Of Objects.Staff))
        End Get
        Set(value As List(Of Objects.Staff))
            gc_Staffs.DataSource = value
            gc_Staffs.RefreshDataSource()
        End Set
    End Property

    Property Year As Integer = 2016
    Property Shift As Enums.Shifts = Enums.Shifts.Shift1
    Property Course As Objects.Course = Nothing
#End Region

#Region "Constructor"
    Sub New(ByVal Students As List(Of Objects.Student), ByVal Staffs As List(Of Objects.Staff), ByVal Year As Integer, ByVal Shift As Enums.Shifts, ByVal Course As Objects.Course)
        InitializeComponent()

        Me.Students = Students
        Me.Staffs = Staffs
        Me.Year = Year
        Me.Shift = Shift
        Me.Course = Course
    End Sub
#End Region

#Region "Progress Panel"
    Sub ShowProgressPanel()
        OverlayHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)
    End Sub

    Sub HideProgressPanel()
        If OverlayHandle IsNot Nothing Then DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlayHandle)
    End Sub
#End Region

#Region "Subs"
    Private Sub RefreshPorts()
        lst_Ports_Edit.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            lst_Ports_Edit.Items.Add(sp)
        Next

        If lst_Ports_Edit.Items.Count > 0 And (lst_Ports.EditValue Is Nothing Or Not lst_Ports_Edit.Items.Contains(lst_Ports.EditValue)) Then lst_Ports.EditValue = lst_Ports_Edit.Items(0)
    End Sub

    Private Async Function SyncStudents() As Task
        If ArduinoPort.IsOpen Then
            Invoke(Sub() ShowProgressPanel())
            Await Task.Run(Sub()
                               ArduinoPort.ReadExisting()
                               ArduinoPort.WriteLine("exists /students")
                               Threading.Thread.Sleep(500)
                               If ArduinoPort.BytesToRead > 0 Then
                                   Dim Exists_Str As String = ArduinoPort.ReadLine.Trim
                                   If Exists_Str = "true" Then
                                       ArduinoPort.WriteLine("readfile /students")
                                       Threading.Thread.Sleep(500)
                                       Dim StudentsData As New List(Of String)
                                       While ArduinoPort.BytesToRead > 0
                                           Dim Line As String = ArduinoPort.ReadLine.Trim()
                                           If Line <> "" Then
                                               StudentsData.Add(Line)
                                           End If
                                       End While
                                       If StudentsData.Count > 0 Then
                                           For Each Line As String In StudentsData
                                               If Line.Contains(";") Then
                                                   Dim Values As String() = Line.Split(";")
                                                   If Values.Count = 4 Then
                                                       Try
                                                           Dim ID As Integer = CInt(Values(0))
                                                           Dim FP As Integer = CInt(Values(3))
                                                           Invoke(Sub()
                                                                      Dim Student As Objects.Student = Students.Find(Function(c) c.ID = ID)
                                                                      If Student IsNot Nothing AndAlso Student.FingerPrintID <> FP Then
                                                                          Student.FingerPrintID = FP
                                                                          Database.Students.Update(Student)
                                                                      End If
                                                                  End Sub)
                                                       Catch ex As Exception

                                                       End Try
                                                   End If
                                               End If
                                           Next
                                           Invoke(Sub()
                                                      gc_Students.RefreshDataSource()
                                                      DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("Successfully syncronized {0} students.", StudentsData.Count), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                  End Sub)
                                       End If
                                   Else
                                       Invoke(Sub() DevExpress.XtraEditors.XtraMessageBox.Show("Students data doesn't exist in device!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error))
                                   End If
                               End If
                           End Sub)
            Invoke(Sub() HideProgressPanel())
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("COM Port is not open!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Private Async Function ExportStudents() As Task
        If ArduinoPort.IsOpen And Students.Count > 0 Then
            Invoke(Sub() ShowProgressPanel())
            Await Task.Run(Sub()
                               ArduinoPort.ReadExisting()
                               ArduinoPort.WriteLine("writefile /prefix")
                               Threading.Thread.Sleep(500)
                               ArduinoPort.WriteLine(String.Format("{0}{1}{2}", (New Date(Year, 1, 1)).ToString("yy"), Course.Prefix, CInt(Shift)))
                               Threading.Thread.Sleep(500)
                               ArduinoPort.WriteLine("writefile /shift")
                               Threading.Thread.Sleep(500)
                               ArduinoPort.WriteLine(CInt(Shift) + 1)
                               Threading.Thread.Sleep(500)

                               ArduinoPort.ReadExisting()
                               ArduinoPort.WriteLine("writefile /students")
                               Threading.Thread.Sleep(500)
                               If ArduinoPort.ReadLine().Trim = "OK" Then
                                   ArduinoPort.WriteLine("---SOF---")
                                   Threading.Thread.Sleep(100)
                                   For Each Student As Objects.Student In Students
                                       ArduinoPort.WriteLine(String.Format("{0};{1};{2};{3}", Student.ID, Student.RollNo.ToString("00"), Student.Name, Student.FingerPrintID))
                                       Threading.Thread.Sleep(100)
                                   Next
                                   ArduinoPort.WriteLine("---EOF---")
                                   Invoke(Sub() DevExpress.XtraEditors.XtraMessageBox.Show("Successfully exported students data to device!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information))
                               Else
                                   Invoke(Sub() DevExpress.XtraEditors.XtraMessageBox.Show("No Response from Device!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error))
                               End If
                           End Sub)
            Invoke(Sub() HideProgressPanel())
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("COM Port is not open!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Private Async Function SyncStaffs() As Task
        If ArduinoPort.IsOpen Then
            Invoke(Sub() ShowProgressPanel())
            Await Task.Run(Sub()
                               ArduinoPort.ReadExisting()
                               ArduinoPort.WriteLine("exists /staffs")
                               Threading.Thread.Sleep(500)
                               If ArduinoPort.BytesToRead > 0 Then
                                   Dim Exists_Str As String = ArduinoPort.ReadLine.Trim
                                   If Exists_Str = "true" Then
                                       ArduinoPort.WriteLine("readfile /staffs")
                                       Threading.Thread.Sleep(500)
                                       Dim StaffsData As New List(Of String)
                                       While ArduinoPort.BytesToRead > 0
                                           Dim Line As String = ArduinoPort.ReadLine.Trim()
                                           If Line <> "" And Not Line.StartsWith("---") Then
                                               StaffsData.Add(Line)
                                           End If
                                       End While
                                       If StaffsData.Count > 0 Then
                                           For Each Line As String In StaffsData
                                               If Line.Contains(";") Then
                                                   Dim Values As String() = Line.Split(";")
                                                   If Values.Count = 3 Then
                                                       Try
                                                           Dim ID As Integer = CInt(Values(0))
                                                           Dim FP As Integer = CInt(Values(2))
                                                           Invoke(Sub()
                                                                      Dim Staff As Objects.Staff = Staffs.Find(Function(c) c.ID = ID)
                                                                      If Staff IsNot Nothing AndAlso Staff.FingerPrintID <> FP Then
                                                                          Staff.FingerPrintID = FP
                                                                          Database.Staffs.Update(Staff)
                                                                      End If
                                                                  End Sub)
                                                       Catch ex As Exception

                                                       End Try
                                                   End If
                                               End If
                                           Next
                                           Invoke(Sub()
                                                      gc_Staffs.RefreshDataSource()
                                                      DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("Successfully syncronized {0} staffs.", StaffsData.Count), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                  End Sub)
                                       End If
                                   Else
                                       Invoke(Sub() DevExpress.XtraEditors.XtraMessageBox.Show("Staffs data doesn't exist in device!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error))
                                   End If
                               End If
                           End Sub)
            Invoke(Sub() HideProgressPanel())
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("COM Port is not open!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Private Async Function ExportStaffs() As Task
        If ArduinoPort.IsOpen And Staffs.Count > 0 Then
            Invoke(Sub() ShowProgressPanel())
            Await Task.Run(Sub()
                               ArduinoPort.ReadExisting()
                               ArduinoPort.WriteLine("writefile /staffs")
                               Threading.Thread.Sleep(500)
                               If ArduinoPort.ReadLine().Trim = "OK" Then
                                   ArduinoPort.WriteLine("---SOF---")
                                   Threading.Thread.Sleep(100)
                                   For Each Staff As Objects.Staff In Staffs
                                       ArduinoPort.WriteLine(String.Format("{0};{1};{2}", Staff.ID, Staff.Name, Staff.FingerPrintID))
                                       Threading.Thread.Sleep(100)
                                   Next
                                   ArduinoPort.WriteLine("---EOF---")
                                   Invoke(Sub() DevExpress.XtraEditors.XtraMessageBox.Show("Successfully exported staffs data to device!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information))
                               Else
                                   Invoke(Sub() DevExpress.XtraEditors.XtraMessageBox.Show("No Response from Device!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error))
                               End If
                           End Sub)
            Invoke(Sub() HideProgressPanel())
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("COM Port is not open!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function
#End Region

#Region "Form Events"
    Private Sub frm_DeviceComm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshPorts()
    End Sub
#End Region

#Region "Arduino Port Events"
    Private Sub btn_Connect_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Connect.ItemClick
        Try
            ArduinoPort.Open()
            btn_Connect.Enabled = False
            btn_Disconnect.Enabled = True
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Disconnect_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Disconnect.ItemClick
        ArduinoPort.Close()
        btn_Connect.Enabled = True
        btn_Disconnect.Enabled = False
    End Sub

    Private Async Sub btn_Students_Sync_Click(sender As Object, e As EventArgs) Handles btn_Students_Sync.Click
        Await SyncStudents()
    End Sub

    Private Async Sub btn_Students_Export_Click(sender As Object, e As EventArgs) Handles btn_Students_Export.Click
        Await ExportStudents()
    End Sub

    Private Async Sub btn_Staffs_Sync_Click(sender As Object, e As EventArgs) Handles btn_Staffs_Sync.Click
        Await SyncStaffs()
    End Sub

    Private Async Sub btn_Staffs_Export_Click(sender As Object, e As EventArgs) Handles btn_Staffs_Export.Click
        Await ExportStaffs()
    End Sub
#End Region

#Region "Other Events"
    Private Sub lst_Ports_EditValueChanged(sender As Object, e As EventArgs) Handles lst_Ports.EditValueChanged
        If lst_Ports.EditValue <> "" Then
            ArduinoPort.PortName = lst_Ports.EditValue

            If ArduinoPort.IsOpen Then
                btn_Connect.Enabled = False
                btn_Disconnect.Enabled = True
            Else
                btn_Connect.Enabled = True
                btn_Disconnect.Enabled = False
            End If
        End If
    End Sub
#End Region

End Class