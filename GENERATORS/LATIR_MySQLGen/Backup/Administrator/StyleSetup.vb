Imports System.Windows.Forms
Imports System.IO

Public Class StyleSetup

  


    Private ReadOnly Property StyleLibrariesDirectory() As DirectoryInfo

        Get
            ' Return a DirectoryInfo object that points to the StyleLibraries folder included in this
            ' sample project.
            Dim di As DirectoryInfo = New DirectoryInfo(System.IO.Path.GetDirectoryName(Application.ExecutablePath))
            'di = di.Parent
            'di = di.Parent

            Dim styleLibrariesDir() As DirectoryInfo = di.GetDirectories("Styles")

            If (styleLibrariesDir.Length > 0) Then
                Return styleLibrariesDir(0)
            End If

            Return Nothing
        End Get
    End Property

    Private Sub LoadComboWithStyleLibraryFiles(ByVal comboBox As Infragistics.Win.UltraWinEditors.UltraComboEditor, ByVal fromDirectory As DirectoryInfo)

        If (fromDirectory Is Nothing) Then
            Exit Sub
        End If

        Dim styleLibraryFiles() As FileInfo = fromDirectory.GetFiles("*.isl")

        Dim styleLibraryFile As FileInfo
        comboBox.Items.Clear()


        For Each styleLibraryFile In styleLibraryFiles
            comboBox.Items.Add(styleLibraryFile)
        Next

    End Sub

    Public Sub New()

        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadComboWithStyleLibraryFiles(cmbStyles, StyleLibrariesDirectory)
    End Sub

    Private Sub cmbStyles_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStyles.ValueChanged
  

        ' Get a FileInfo reference to the currently selected StyleLibrary.
        Dim selectedStyleLibrary As FileInfo = Nothing

        If (TypeOf cmbStyles.SelectedItem.DataValue Is FileInfo) Then
            selectedStyleLibrary = cmbStyles.SelectedItem.DataValue
        End If

        ' Do the right thing depending on whether a StyleLibrary is selected or not.
        If Not (selectedStyleLibrary Is Nothing) Then

            ' Apply the StyleLibrary.
            Infragistics.Win.AppStyling.StyleManager.Load(selectedStyleLibrary.FullName)
        End If
    End Sub

  
End Class
