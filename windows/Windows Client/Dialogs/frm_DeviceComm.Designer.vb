<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_DeviceComm
    Inherits Utils.XtraFormTemp

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_DeviceComm))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.lst_Ports = New DevExpress.XtraBars.BarEditItem()
        Me.lst_Ports_Edit = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.btn_RefreshPorts = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Connect = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Disconnect = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.tc_Main = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_Students = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_Students = New DevExpress.XtraGrid.GridControl()
        Me.gv_Students = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.panel_Students = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Students_Export = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Students_Sync = New DevExpress.XtraEditors.SimpleButton()
        Me.tp_Staffs = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_Staffs = New DevExpress.XtraGrid.GridControl()
        Me.gv_Staffs = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Staffs_Export = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Staffs_Sync = New DevExpress.XtraEditors.SimpleButton()
        Me.tp_Attendance = New DevExpress.XtraTab.XtraTabPage()
        Me.ArduinoPort = New System.IO.Ports.SerialPort(Me.components)
        Me.gc_Attendances = New DevExpress.XtraGrid.GridControl()
        Me.gv_Attendances = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Attendance_Import = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lst_Ports_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tc_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_Main.SuspendLayout()
        Me.tp_Students.SuspendLayout()
        CType(Me.gc_Students, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Students, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel_Students, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_Students.SuspendLayout()
        Me.tp_Staffs.SuspendLayout()
        CType(Me.gc_Staffs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Staffs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.tp_Attendance.SuspendLayout()
        CType(Me.gc_Attendances, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Attendances, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.lst_Ports, Me.btn_RefreshPorts, Me.btn_Connect, Me.btn_Disconnect})
        Me.BarManager.MainMenu = Me.Bar2
        Me.BarManager.MaxItemId = 4
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.lst_Ports_Edit})
        Me.BarManager.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.lst_Ports), New DevExpress.XtraBars.LinkPersistInfo(Me.btn_RefreshPorts), New DevExpress.XtraBars.LinkPersistInfo(Me.btn_Connect, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btn_Disconnect)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'lst_Ports
        '
        Me.lst_Ports.Caption = "COM Port :"
        Me.lst_Ports.Edit = Me.lst_Ports_Edit
        Me.lst_Ports.EditWidth = 100
        Me.lst_Ports.Id = 0
        Me.lst_Ports.Name = "lst_Ports"
        Me.lst_Ports.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'lst_Ports_Edit
        '
        Me.lst_Ports_Edit.AutoHeight = False
        Me.lst_Ports_Edit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lst_Ports_Edit.Name = "lst_Ports_Edit"
        Me.lst_Ports_Edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'btn_RefreshPorts
        '
        Me.btn_RefreshPorts.Caption = "Refresh"
        Me.btn_RefreshPorts.Id = 1
        Me.btn_RefreshPorts.ImageOptions.SvgImage = CType(resources.GetObject("btn_RefreshPorts.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_RefreshPorts.Name = "btn_RefreshPorts"
        '
        'btn_Connect
        '
        Me.btn_Connect.Caption = "Connect"
        Me.btn_Connect.Enabled = False
        Me.btn_Connect.Id = 2
        Me.btn_Connect.ImageOptions.SvgImage = CType(resources.GetObject("btn_Connect.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btn_Disconnect
        '
        Me.btn_Disconnect.Caption = "Disconnect"
        Me.btn_Disconnect.Enabled = False
        Me.btn_Disconnect.Id = 3
        Me.btn_Disconnect.ImageOptions.SvgImage = CType(resources.GetObject("btn_Disconnect.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Disconnect.Name = "btn_Disconnect"
        Me.btn_Disconnect.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Size = New System.Drawing.Size(800, 24)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 427)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(800, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 24)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 403)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(800, 24)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 403)
        '
        'tc_Main
        '
        Me.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_Main.Location = New System.Drawing.Point(0, 24)
        Me.tc_Main.Name = "tc_Main"
        Me.tc_Main.SelectedTabPage = Me.tp_Students
        Me.tc_Main.Size = New System.Drawing.Size(800, 403)
        Me.tc_Main.TabIndex = 4
        Me.tc_Main.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tp_Students, Me.tp_Staffs, Me.tp_Attendance})
        '
        'tp_Students
        '
        Me.tp_Students.Controls.Add(Me.gc_Students)
        Me.tp_Students.Controls.Add(Me.panel_Students)
        Me.tp_Students.Name = "tp_Students"
        Me.tp_Students.Size = New System.Drawing.Size(794, 375)
        Me.tp_Students.Text = "Students"
        '
        'gc_Students
        '
        Me.gc_Students.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Students.Location = New System.Drawing.Point(0, 0)
        Me.gc_Students.MainView = Me.gv_Students
        Me.gc_Students.MenuManager = Me.BarManager
        Me.gc_Students.Name = "gc_Students"
        Me.gc_Students.Size = New System.Drawing.Size(794, 341)
        Me.gc_Students.TabIndex = 0
        Me.gc_Students.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_Students})
        '
        'gv_Students
        '
        Me.gv_Students.GridControl = Me.gc_Students
        Me.gv_Students.Name = "gv_Students"
        Me.gv_Students.OptionsBehavior.Editable = False
        Me.gv_Students.OptionsBehavior.ReadOnly = True
        Me.gv_Students.OptionsView.ShowGroupPanel = False
        '
        'panel_Students
        '
        Me.panel_Students.Controls.Add(Me.btn_Students_Export)
        Me.panel_Students.Controls.Add(Me.btn_Students_Sync)
        Me.panel_Students.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel_Students.Location = New System.Drawing.Point(0, 341)
        Me.panel_Students.Name = "panel_Students"
        Me.panel_Students.Size = New System.Drawing.Size(794, 34)
        Me.panel_Students.TabIndex = 1
        '
        'btn_Students_Export
        '
        Me.btn_Students_Export.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Students_Export.ImageOptions.SvgImage = CType(resources.GetObject("btn_Students_Export.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Students_Export.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        Me.btn_Students_Export.Location = New System.Drawing.Point(77, 2)
        Me.btn_Students_Export.Name = "btn_Students_Export"
        Me.btn_Students_Export.Size = New System.Drawing.Size(81, 30)
        Me.btn_Students_Export.TabIndex = 1
        Me.btn_Students_Export.Text = "Export"
        '
        'btn_Students_Sync
        '
        Me.btn_Students_Sync.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Students_Sync.ImageOptions.SvgImage = CType(resources.GetObject("btn_Students_Sync.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Students_Sync.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        Me.btn_Students_Sync.Location = New System.Drawing.Point(2, 2)
        Me.btn_Students_Sync.Name = "btn_Students_Sync"
        Me.btn_Students_Sync.Size = New System.Drawing.Size(75, 30)
        Me.btn_Students_Sync.TabIndex = 0
        Me.btn_Students_Sync.Text = "Sync"
        '
        'tp_Staffs
        '
        Me.tp_Staffs.Controls.Add(Me.gc_Staffs)
        Me.tp_Staffs.Controls.Add(Me.PanelControl1)
        Me.tp_Staffs.Name = "tp_Staffs"
        Me.tp_Staffs.Size = New System.Drawing.Size(794, 375)
        Me.tp_Staffs.Text = "Staffs"
        '
        'gc_Staffs
        '
        Me.gc_Staffs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Staffs.Location = New System.Drawing.Point(0, 0)
        Me.gc_Staffs.MainView = Me.gv_Staffs
        Me.gc_Staffs.MenuManager = Me.BarManager
        Me.gc_Staffs.Name = "gc_Staffs"
        Me.gc_Staffs.Size = New System.Drawing.Size(794, 341)
        Me.gc_Staffs.TabIndex = 2
        Me.gc_Staffs.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_Staffs})
        '
        'gv_Staffs
        '
        Me.gv_Staffs.GridControl = Me.gc_Staffs
        Me.gv_Staffs.Name = "gv_Staffs"
        Me.gv_Staffs.OptionsBehavior.Editable = False
        Me.gv_Staffs.OptionsBehavior.ReadOnly = True
        Me.gv_Staffs.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Staffs_Export)
        Me.PanelControl1.Controls.Add(Me.btn_Staffs_Sync)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 341)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(794, 34)
        Me.PanelControl1.TabIndex = 3
        '
        'btn_Staffs_Export
        '
        Me.btn_Staffs_Export.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Staffs_Export.ImageOptions.SvgImage = CType(resources.GetObject("btn_Staffs_Export.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Staffs_Export.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        Me.btn_Staffs_Export.Location = New System.Drawing.Point(77, 2)
        Me.btn_Staffs_Export.Name = "btn_Staffs_Export"
        Me.btn_Staffs_Export.Size = New System.Drawing.Size(81, 30)
        Me.btn_Staffs_Export.TabIndex = 1
        Me.btn_Staffs_Export.Text = "Export"
        '
        'btn_Staffs_Sync
        '
        Me.btn_Staffs_Sync.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Staffs_Sync.ImageOptions.SvgImage = CType(resources.GetObject("btn_Staffs_Sync.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Staffs_Sync.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        Me.btn_Staffs_Sync.Location = New System.Drawing.Point(2, 2)
        Me.btn_Staffs_Sync.Name = "btn_Staffs_Sync"
        Me.btn_Staffs_Sync.Size = New System.Drawing.Size(75, 30)
        Me.btn_Staffs_Sync.TabIndex = 0
        Me.btn_Staffs_Sync.Text = "Sync"
        '
        'tp_Attendance
        '
        Me.tp_Attendance.Controls.Add(Me.gc_Attendances)
        Me.tp_Attendance.Controls.Add(Me.PanelControl2)
        Me.tp_Attendance.Name = "tp_Attendance"
        Me.tp_Attendance.Size = New System.Drawing.Size(794, 375)
        Me.tp_Attendance.Text = "Attendance"
        '
        'gc_Attendances
        '
        Me.gc_Attendances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Attendances.Location = New System.Drawing.Point(0, 0)
        Me.gc_Attendances.MainView = Me.gv_Attendances
        Me.gc_Attendances.MenuManager = Me.BarManager
        Me.gc_Attendances.Name = "gc_Attendances"
        Me.gc_Attendances.Size = New System.Drawing.Size(794, 341)
        Me.gc_Attendances.TabIndex = 2
        Me.gc_Attendances.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_Attendances})
        '
        'gv_Attendances
        '
        Me.gv_Attendances.GridControl = Me.gc_Attendances
        Me.gv_Attendances.Name = "gv_Attendances"
        Me.gv_Attendances.OptionsBehavior.Editable = False
        Me.gv_Attendances.OptionsBehavior.ReadOnly = True
        Me.gv_Attendances.OptionsView.ShowGroupPanel = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btn_Attendance_Import)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 341)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(794, 34)
        Me.PanelControl2.TabIndex = 3
        '
        'btn_Attendance_Import
        '
        Me.btn_Attendance_Import.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Attendance_Import.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Attendance_Import.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        Me.btn_Attendance_Import.Location = New System.Drawing.Point(2, 2)
        Me.btn_Attendance_Import.Name = "btn_Attendance_Import"
        Me.btn_Attendance_Import.Size = New System.Drawing.Size(81, 30)
        Me.btn_Attendance_Import.TabIndex = 1
        Me.btn_Attendance_Import.Text = "Import"
        '
        'frm_DeviceComm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.tc_Main)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_DeviceComm"
        Me.Text = "Device Communication"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lst_Ports_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tc_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_Main.ResumeLayout(False)
        Me.tp_Students.ResumeLayout(False)
        CType(Me.gc_Students, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Students, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel_Students, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_Students.ResumeLayout(False)
        Me.tp_Staffs.ResumeLayout(False)
        CType(Me.gc_Staffs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Staffs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.tp_Attendance.ResumeLayout(False)
        CType(Me.gc_Attendances, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Attendances, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents lst_Ports As DevExpress.XtraBars.BarEditItem
    Friend WithEvents lst_Ports_Edit As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents btn_RefreshPorts As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Connect As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Disconnect As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents tc_Main As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tp_Students As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gc_Students As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_Students As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents panel_Students As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Students_Export As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Students_Sync As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ArduinoPort As IO.Ports.SerialPort
    Friend WithEvents tp_Staffs As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gc_Staffs As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_Staffs As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Staffs_Export As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Staffs_Sync As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tp_Attendance As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gc_Attendances As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_Attendances As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Attendance_Import As DevExpress.XtraEditors.SimpleButton
End Class
