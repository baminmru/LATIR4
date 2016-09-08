Option Strict Off
Option Explicit On
Friend Class frmDicList
	Inherits System.Windows.Forms.Form
	
	Public OK As Boolean
    Public model As MTZMetaModel.MTZMetaModel.Application
    Public Result As String

    Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
        OK = False
        Me.Hide()
    End Sub

    Private Sub frmDicList_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        lstJournal.Items.Clear()
        OK = False
        Dim i As Integer
        'Dim ti As tmpInst
        'For i = 1 To model.ObjectType.Count
        '    If model.OBJECTTYPE.Item(i).IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
        '        ti = New tmpInst
        '        ti.ObjType = model.OBJECTTYPE.Item(i).Name
        '        ti.Name = model.OBJECTTYPE.Item(i).the_Comment
        '        ti.ID = model.OBJECTTYPE.Item(i).ID
        '        lstJournal.Items.Add(ti)
        '    End If
        'Next


        Dim rs As DataTable = Manager.Session.GetRowsExDT("OBJECTTYPE", "name,the_comment,issingleinstance," + Manager.Session.GetProvider.ID2Base("objecttypeid"), , , , " order by Name")
        Dim o As tmpInst


        For i = 0 To rs.Rows.Count - 1
            If rs.Rows(i)("IsSingleInstance") <> 0 Then
                o = New tmpInst
                o.Name = rs.Rows(i)("Name") & " (" & rs.Rows(i)("the_comment") & ")"
                o.ObjType = rs.Rows(i)("Name")
                o.IsSingle = rs.Rows(i)("IsSingleInstance")
                o.ID = New Guid(rs.Rows(i)("objecttypeid").ToString)

                lstJournal.Items.Add(o)
            End If
        Next
        If (lstJournal.Items.Count > 0) Then
            lstJournal.SelectedIndex = 0
        End If

    End Sub
	

	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		If lstJournal.SelectedIndex >= 0 Then
            OK = True
            Dim ti As tmpInst
            ti = lstJournal.Items(lstJournal.SelectedIndex)
            Result = ti.ID.ToString()
			Me.Hide()
		End If
	End Sub
	
	Private Sub lstJournal_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstJournal.DoubleClick
		OKButton_Click(OKButton, New System.EventArgs())
	End Sub

    Private Sub lstJournal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstJournal.SelectedIndexChanged

    End Sub

    Private Sub frmDicList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
    End Sub
End Class