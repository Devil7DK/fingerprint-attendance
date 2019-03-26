Public Class report_Consolidated

#Region "Constructor"
    Sub New(ByVal Data As Objects.AttendanceConsolidate)
        InitializeComponent()

        Me.ObjectDataSource1.DataSource = Data
        Me.DataMember = "Data"
    End Sub
#End Region

End Class