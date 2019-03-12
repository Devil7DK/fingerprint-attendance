Namespace Objects
    Public Class Course

#Region "Properties"
        Property ID As Integer
        Property ShortName As String
        Property FullName As String
        Property Prefix As String
#End Region

#Region "Constructor"
        Sub New()
            Me.ID = 0
            Me.ShortName = ""
            Me.FullName = ""
            Me.Prefix = ""
        End Sub

        Sub New(ByVal ID As Integer, ByVal ShortName As String, ByVal FullName As String, ByVal Prefix As String)
            Me.ID = ID
            Me.ShortName = ShortName
            Me.FullName = FullName
            Me.Prefix = Prefix
        End Sub
#End Region

    End Class
End Namespace