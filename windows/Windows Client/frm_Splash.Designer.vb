<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Splash
    Inherits DevExpress.XtraSplashScreen.SplashScreen

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Splash))
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.SuspendLayout()
        '
        'ProgressPanel1
        '
        Me.ProgressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel1.Appearance.ForeColor = System.Drawing.Color.White
        Me.ProgressPanel1.Appearance.Options.UseBackColor = True
        Me.ProgressPanel1.Appearance.Options.UseForeColor = True
        Me.ProgressPanel1.BackgroundImage = CType(resources.GetObject("ProgressPanel1.BackgroundImage"), System.Drawing.Image)
        Me.ProgressPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ProgressPanel1.BarAnimationElementThickness = 2
        Me.ProgressPanel1.ContentAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.ProgressPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 30)
        Me.ProgressPanel1.ShowCaption = False
        Me.ProgressPanel1.ShowDescription = False
        Me.ProgressPanel1.Size = New System.Drawing.Size(568, 320)
        Me.ProgressPanel1.TabIndex = 0
        Me.ProgressPanel1.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Line
        '
        'frm_Splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 320)
        Me.Controls.Add(Me.ProgressPanel1)
        Me.Name = "frm_Splash"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
End Class
