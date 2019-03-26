Namespace Utils
    Public Class StudentComparer : Implements IComparer(Of Objects.Student)

#Region "Functions"
        Public Function Compare(x As Objects.Student, y As Objects.Student) As Integer Implements IComparer(Of Objects.Student).Compare
            Return x.RollNo.CompareTo(y.RollNo)
        End Function
#End Region

    End Class
End Namespace