Imports System.IO
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Windows.Forms.UserControl

Public Class TreeUtils
    Public Shared Sub PrepareImageList(ByRef TreeImageList As ImageList)
        LoadIcon(TreeImageList, "tree1.ico")
        LoadIcon(TreeImageList, "tree2.ico")
    End Sub

    Private Shared Sub LoadIcon(ByRef TreeImageList As ImageList, ByVal IcoName As String)
        Dim IcoPath As String
        Dim FileName As String

        IcoPath = String.Empty
        FileName = ButtonUtils.MakeFileName(IcoPath, IcoName)

        If (File.Exists(FileName)) Then
            Try
                TreeImageList.Images.Add(New Icon(FileName))
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        Else
            IcoPath = "IMAGES"
            FileName = ButtonUtils.MakeFileName(IcoPath, IcoName)
            Try
                TreeImageList.Images.Add(New Icon(FileName))
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If


    End Sub
End Class

