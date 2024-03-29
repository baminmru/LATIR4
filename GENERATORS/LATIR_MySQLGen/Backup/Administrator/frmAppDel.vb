Option Strict Off
Option Explicit On
Imports MTZMetaModel.MTZMetaModel
Friend Class frmAppDel
    Inherits System.Windows.Forms.Form

    Public OK As Boolean
    Public model As MTZMetaModel.MTZMetaModel.Application
    Public Result As Object

    Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
        OK = False
        Me.Hide()
    End Sub

    'UPGRADE_WARNING: Form event frmAppDel.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub frmAppDel_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        lstJournal.Items.Clear()
        OK = False
        Dim i As Integer
        model.MTZAPP.Refresh()
        For i = 1 To model.MTZAPP.Count
            lstJournal.Items.Add(New VB6.ListBoxItem(model.MTZAPP.Item(i).Name, i))
        Next
        If (lstJournal.Items.Count > 0) Then
            lstJournal.SelectedIndex = 0
        End If
        Call frmAppDel_Resize(Me, New System.EventArgs())
    End Sub

    'UPGRADE_WARNING: Event frmAppDel.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub frmAppDel_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error Resume Next
        lstJournal.Top = VB6.TwipsToPixelsY(30)
        lstJournal.Left = VB6.TwipsToPixelsX(30)
        lstJournal.Height = Me.ClientRectangle.Height
        lstJournal.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 100 - VB6.PixelsToTwipsX(OKButton.Width))

        OKButton.Top = VB6.TwipsToPixelsY(50)
        OKButton.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 50 - VB6.PixelsToTwipsX(OKButton.Width))

        CancelButton_Renamed.Left = OKButton.Left
        CancelButton_Renamed.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(OKButton.Top) + 50 + VB6.PixelsToTwipsY(OKButton.Height))
    End Sub

    Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
        If lstJournal.SelectedIndex >= 0 Then
            OK = True
            Result = model.MTZAPP.Item(VB6.GetItemData(lstJournal, lstJournal.SelectedIndex))
            Me.Hide()
        End If
    End Sub


    Private Sub lstJournal_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstJournal.DoubleClick
        OKButton_Click(OKButton, New System.EventArgs())
    End Sub
End Class