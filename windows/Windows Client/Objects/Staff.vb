Imports System.ComponentModel

Namespace Objects
    Public Class Staff

#Region "Properties/Fields"
        Property ID As Integer
        Property Name As String
        Property Photo As Image

        <DisplayName("Finger Print ID")>
        Property FingerPrintID As Integer
#End Region

#Region "Constructor"
        Sub New()
            Me.ID = 0
            Me.Name = ""
            Me.Photo = Nothing
            Me.FingerPrintID = 0
        End Sub

        Sub New(ByVal ID As Integer, ByVal Name As String, ByVal Photo As Bitmap, ByVal FingerPrintID As Integer)
            Me.ID = ID
            Me.Name = Name
            Me.Photo = Photo
            Me.FingerPrintID = FingerPrintID
        End Sub
#End Region

#Region "Subs"
        Public Overrides Function ToString() As String
            Return Name
        End Function
#End Region

    End Class
End Namespace