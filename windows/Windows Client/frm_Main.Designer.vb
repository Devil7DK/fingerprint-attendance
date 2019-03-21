<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btn_Refresh = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Comm = New DevExpress.XtraBars.BarButtonItem()
        Me.rp_Home = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_Database = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpg_Device = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.tc_Main = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_Students = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_Students = New DevExpress.XtraGrid.GridControl()
        Me.gv_Students = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tp_Staffs = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_Staffs = New DevExpress.XtraGrid.GridControl()
        Me.gv_Staffs = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tp_Courses = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_Courses = New DevExpress.XtraGrid.GridControl()
        Me.gv_Courses = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.dlg_SelectImage = New System.Windows.Forms.OpenFileDialog()
        Me.ApplicationMenu = New DevExpress.XtraBars.Ribbon.ApplicationMenu(Me.components)
        Me.btn_CompactDatabase = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Exit = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tc_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_Main.SuspendLayout()
        Me.tp_Students.SuspendLayout()
        CType(Me.gc_Students, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Students, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Staffs.SuspendLayout()
        CType(Me.gc_Staffs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Staffs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Courses.SuspendLayout()
        CType(Me.gc_Courses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Courses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ApplicationButtonDropDownControl = Me.ApplicationMenu
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btn_Refresh, Me.btn_Comm, Me.btn_CompactDatabase, Me.btn_Exit})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 5
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rp_Home})
        Me.RibbonControl.ShowCategoryInCaption = False
        Me.RibbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowQatLocationSelector = False
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(603, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'btn_Refresh
        '
        Me.btn_Refresh.Caption = "Refresh"
        Me.btn_Refresh.Id = 1
        Me.btn_Refresh.ImageOptions.SvgImage = CType(resources.GetObject("btn_Refresh.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Refresh.Name = "btn_Refresh"
        '
        'btn_Comm
        '
        Me.btn_Comm.Caption = "Import/Export"
        Me.btn_Comm.Id = 2
        Me.btn_Comm.ImageOptions.SvgImage = CType(resources.GetObject("btn_Comm.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Comm.Name = "btn_Comm"
        '
        'rp_Home
        '
        Me.rp_Home.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_Database, Me.rpg_Device})
        Me.rp_Home.Name = "rp_Home"
        Me.rp_Home.Text = "Home"
        '
        'rpg_Database
        '
        Me.rpg_Database.ItemLinks.Add(Me.btn_Refresh)
        Me.rpg_Database.Name = "rpg_Database"
        Me.rpg_Database.ShowCaptionButton = False
        Me.rpg_Database.Text = "Database"
        '
        'rpg_Device
        '
        Me.rpg_Device.ItemLinks.Add(Me.btn_Comm)
        Me.rpg_Device.Name = "rpg_Device"
        Me.rpg_Device.ShowCaptionButton = False
        Me.rpg_Device.Text = "Device"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 418)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(603, 31)
        '
        'tc_Main
        '
        Me.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_Main.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.tc_Main.Location = New System.Drawing.Point(0, 143)
        Me.tc_Main.Name = "tc_Main"
        Me.tc_Main.SelectedTabPage = Me.tp_Students
        Me.tc_Main.Size = New System.Drawing.Size(603, 275)
        Me.tc_Main.TabIndex = 2
        Me.tc_Main.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tp_Students, Me.tp_Staffs, Me.tp_Courses})
        '
        'tp_Students
        '
        Me.tp_Students.Controls.Add(Me.gc_Students)
        Me.tp_Students.Name = "tp_Students"
        Me.tp_Students.Size = New System.Drawing.Size(597, 247)
        Me.tp_Students.Text = "Students"
        '
        'gc_Students
        '
        Me.gc_Students.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Students.Location = New System.Drawing.Point(0, 0)
        Me.gc_Students.MainView = Me.gv_Students
        Me.gc_Students.MenuManager = Me.RibbonControl
        Me.gc_Students.Name = "gc_Students"
        Me.gc_Students.Size = New System.Drawing.Size(597, 247)
        Me.gc_Students.TabIndex = 1
        Me.gc_Students.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_Students})
        '
        'gv_Students
        '
        Me.gv_Students.GridControl = Me.gc_Students
        Me.gv_Students.Name = "gv_Students"
        Me.gv_Students.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv_Students.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv_Students.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        '
        'tp_Staffs
        '
        Me.tp_Staffs.Controls.Add(Me.gc_Staffs)
        Me.tp_Staffs.Name = "tp_Staffs"
        Me.tp_Staffs.Size = New System.Drawing.Size(597, 247)
        Me.tp_Staffs.Text = "Staffs"
        '
        'gc_Staffs
        '
        Me.gc_Staffs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Staffs.Location = New System.Drawing.Point(0, 0)
        Me.gc_Staffs.MainView = Me.gv_Staffs
        Me.gc_Staffs.MenuManager = Me.RibbonControl
        Me.gc_Staffs.Name = "gc_Staffs"
        Me.gc_Staffs.Size = New System.Drawing.Size(597, 247)
        Me.gc_Staffs.TabIndex = 1
        Me.gc_Staffs.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_Staffs})
        '
        'gv_Staffs
        '
        Me.gv_Staffs.GridControl = Me.gc_Staffs
        Me.gv_Staffs.Name = "gv_Staffs"
        Me.gv_Staffs.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv_Staffs.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv_Staffs.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        '
        'tp_Courses
        '
        Me.tp_Courses.Controls.Add(Me.gc_Courses)
        Me.tp_Courses.Name = "tp_Courses"
        Me.tp_Courses.Size = New System.Drawing.Size(597, 247)
        Me.tp_Courses.Text = "Courses"
        '
        'gc_Courses
        '
        Me.gc_Courses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Courses.Location = New System.Drawing.Point(0, 0)
        Me.gc_Courses.MainView = Me.gv_Courses
        Me.gc_Courses.MenuManager = Me.RibbonControl
        Me.gc_Courses.Name = "gc_Courses"
        Me.gc_Courses.Size = New System.Drawing.Size(597, 247)
        Me.gc_Courses.TabIndex = 0
        Me.gc_Courses.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_Courses})
        '
        'gv_Courses
        '
        Me.gv_Courses.GridControl = Me.gc_Courses
        Me.gv_Courses.Name = "gv_Courses"
        Me.gv_Courses.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv_Courses.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv_Courses.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        '
        'dlg_SelectImage
        '
        Me.dlg_SelectImage.Filter = "All Supported Image Files|*.bmp;*.jpg;*.jpeg;*.png"
        '
        'ApplicationMenu
        '
        Me.ApplicationMenu.ItemLinks.Add(Me.btn_CompactDatabase)
        Me.ApplicationMenu.ItemLinks.Add(Me.btn_Exit, True)
        Me.ApplicationMenu.Name = "ApplicationMenu"
        Me.ApplicationMenu.Ribbon = Me.RibbonControl
        '
        'btn_CompactDatabase
        '
        Me.btn_CompactDatabase.Caption = "Compact Database"
        Me.btn_CompactDatabase.Description = "Shrinks & Rebuilds the Database"
        Me.btn_CompactDatabase.Id = 3
        Me.btn_CompactDatabase.ImageOptions.SvgImage = CType(resources.GetObject("btn_CompactDatabase.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_CompactDatabase.Name = "btn_CompactDatabase"
        '
        'btn_Exit
        '
        Me.btn_Exit.Caption = "Exit"
        Me.btn_Exit.Description = "Close & Exit the Application"
        Me.btn_Exit.Id = 4
        Me.btn_Exit.ImageOptions.SvgImage = CType(resources.GetObject("btn_Exit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Exit.Name = "btn_Exit"
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 449)
        Me.Controls.Add(Me.tc_Main)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Name = "frm_Main"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Students Attendance Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tc_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_Main.ResumeLayout(False)
        Me.tp_Students.ResumeLayout(False)
        CType(Me.gc_Students, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Students, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Staffs.ResumeLayout(False)
        CType(Me.gc_Staffs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Staffs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Courses.ResumeLayout(False)
        CType(Me.gc_Courses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Courses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents rp_Home As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents tc_Main As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tp_Students As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tp_Staffs As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tp_Courses As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gc_Courses As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_Courses As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_Students As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_Students As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_Staffs As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_Staffs As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dlg_SelectImage As OpenFileDialog
    Friend WithEvents rpg_Database As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_Refresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Comm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpg_Device As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ApplicationMenu As DevExpress.XtraBars.Ribbon.ApplicationMenu
    Friend WithEvents btn_CompactDatabase As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Exit As DevExpress.XtraBars.BarButtonItem
End Class
