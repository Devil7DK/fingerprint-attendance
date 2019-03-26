<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SelectYearShift
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
        Me.lbl_Year = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Shift = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Year = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txt_Shift = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btn_OK = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Cancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_Course = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Course = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.txt_Year.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Shift.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Course.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Year
        '
        Me.lbl_Year.Location = New System.Drawing.Point(12, 15)
        Me.lbl_Year.Name = "lbl_Year"
        Me.lbl_Year.Size = New System.Drawing.Size(75, 13)
        Me.lbl_Year.TabIndex = 0
        Me.lbl_Year.Text = "Admitted Year :"
        '
        'lbl_Shift
        '
        Me.lbl_Shift.Location = New System.Drawing.Point(58, 41)
        Me.lbl_Shift.Name = "lbl_Shift"
        Me.lbl_Shift.Size = New System.Drawing.Size(29, 13)
        Me.lbl_Shift.TabIndex = 1
        Me.lbl_Shift.Text = "Shift :"
        '
        'txt_Year
        '
        Me.txt_Year.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Year.Location = New System.Drawing.Point(93, 12)
        Me.txt_Year.Name = "txt_Year"
        Me.txt_Year.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_Year.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txt_Year.Size = New System.Drawing.Size(207, 20)
        Me.txt_Year.TabIndex = 0
        '
        'txt_Shift
        '
        Me.txt_Shift.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Shift.Location = New System.Drawing.Point(93, 38)
        Me.txt_Shift.Name = "txt_Shift"
        Me.txt_Shift.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_Shift.Properties.Items.AddRange(New Object() {"Shift I", "Shift II"})
        Me.txt_Shift.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txt_Shift.Size = New System.Drawing.Size(207, 20)
        Me.txt_Shift.TabIndex = 1
        '
        'btn_OK
        '
        Me.btn_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_OK.Location = New System.Drawing.Point(225, 99)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 3
        Me.btn_OK.Text = "OK"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancel.Location = New System.Drawing.Point(12, 99)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 4
        Me.btn_Cancel.Text = "Cancel"
        '
        'lbl_Course
        '
        Me.lbl_Course.Location = New System.Drawing.Point(46, 67)
        Me.lbl_Course.Name = "lbl_Course"
        Me.lbl_Course.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Course.TabIndex = 6
        Me.lbl_Course.Text = "Course :"
        '
        'txt_Course
        '
        Me.txt_Course.Location = New System.Drawing.Point(93, 64)
        Me.txt_Course.Name = "txt_Course"
        Me.txt_Course.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_Course.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txt_Course.Size = New System.Drawing.Size(207, 20)
        Me.txt_Course.TabIndex = 2
        '
        'frm_SelectYearShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 133)
        Me.ControlBox = False
        Me.Controls.Add(Me.txt_Course)
        Me.Controls.Add(Me.lbl_Course)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.txt_Shift)
        Me.Controls.Add(Me.txt_Year)
        Me.Controls.Add(Me.lbl_Shift)
        Me.Controls.Add(Me.lbl_Year)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frm_SelectYearShift"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Year & Shift"
        CType(Me.txt_Year.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Shift.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Course.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Year As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Shift As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Year As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txt_Shift As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btn_OK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_Course As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Course As DevExpress.XtraEditors.ComboBoxEdit
End Class
