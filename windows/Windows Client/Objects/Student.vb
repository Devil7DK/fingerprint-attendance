﻿Imports System.ComponentModel

Namespace Objects
    Public Class Student

#Region "Properties/Fields"
        Property ID As Integer
        <DisplayName("Roll Number")>
        Property RollNo As Integer
        Property Name As String
        <DisplayName("Father Name")>
        Property FatherName As String
        Property Course As Course
        Property Shift As Enums.Shifts
        Property Photo As Image
        <DisplayName("Admitted Year")>
        Property AdmittedYear As String

        <DisplayName("Finger Print ID")>
        Property FingerPrintID As Integer
#End Region

#Region "Constructor"
        Sub New()
            Me.ID = 0
            Me.RollNo = 0
            Me.Name = ""
            Me.FatherName = ""
            Me.Course = New Course()
            Me.Shift = Enums.Shifts.Shift1
            Me.Photo = Nothing
            Me.AdmittedYear = 2019
            Me.FingerPrintID = 0
        End Sub

        Sub New(ByVal ID As Integer, ByVal RollNo As Integer, ByVal Name As String, ByVal FatherName As String, ByVal Course As Course, ByVal Shift As Enums.Shifts, ByVal Photo As Bitmap, ByVal AdmittedYear As Integer, ByVal FingerPrintID As Integer)
            Me.ID = ID
            Me.RollNo = RollNo
            Me.Name = Name
            Me.FatherName = FatherName
            Me.Course = Course
            Me.Shift = Shift
            Me.Photo = Photo
            Me.AdmittedYear = AdmittedYear
            Me.FingerPrintID = FingerPrintID
        End Sub
#End Region

    End Class
End Namespace