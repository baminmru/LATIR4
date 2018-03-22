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
        Dim j As Integer
        model.MTZAPP.Refresh()
        Dim dt As DataTable
        dt = model.MTZAPP.GetDataTable()
        lstJournal.ValueMember = "ID"
        lstJournal.DisplayMember = "Brief"
        lstJournal.DataSource = dt
        'd()
        'For i = 1 To model.MTZAPP.Count
        '    j = lstJournal.Items.Add(model.MTZAPP.Item(i).Name)

        'Next
        If (lstJournal.Items.Count > 0) Then
            lstJournal.SelectedIndex = 0
        End If

    End Sub

   

    Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
        If lstJournal.SelectedIndex >= 0 Then
            OK = True
            Result = model.MTZAPP.Item(lstJournal.Items(lstJournal.SelectedIndex)("ID"))
            Me.Hide()
        End If
    End Sub


    Private Sub lstJournal_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstJournal.DoubleClick
        OKButton_Click(OKButton, New System.EventArgs())
    End Sub
End Class