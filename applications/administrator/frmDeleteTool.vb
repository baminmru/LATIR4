Option Strict Off
Option Explicit On
Friend Class frmDeleteTool
	Inherits System.Windows.Forms.Form
	Public TypeName_Renamed As String
	Public site_Renamed As String
	Public OK As Boolean
	Public ID As String
	Public Brief As String


	Private Sub cmbType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbType.SelectedIndexChanged
		Dim i As Integer
        Dim rs As DataTable
		On Error Resume Next

		Dim tt, o As tmpInst
        tt = cmbType.Items(cmbType.SelectedIndex)
        rs = Manager.Session.GetRowsEx("INSTANCE", "", "", " ObjType='" & tt.ObjType & "'", "order by name")
		i = 0
        lstObj.Items.Clear()
        For i = 0 To rs.Rows.Count - 1
          
            On Error Resume Next
            o = New tmpInst
            o.ID = New Guid(rs.Rows(i)("InstanceID").ToString)
            o.Name = rs.Rows(i)("Name")
            o.ObjType = rs.Rows(i)("ObjType")

            o.LockUserID = rs.Rows(i)("LockUserID") & ""


            If o.LockUserID <> "" Then
                o.Name = o.Name & "(locked)"
                lstObj.Items.Add(o)

            Else
                lstObj.Items.Add(o)
            End If

         

        Next

        rs = Nothing
      
    End Sub




    Private Sub cmdKill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdKill.Click
        On Error Resume Next
        Dim i As Integer
        Dim ti As tmpInst
        For i = 0 To lstObj.Items.Count - 1
            If lstObj.GetItemChecked(i) Then
                ti = lstObj.Items(i)
                Manager.DeleteInstance(Manager.GetInstanceObject(ti.ID))
            End If
        Next
        cmbType_SelectedIndexChanged(cmbType, New System.EventArgs())
    End Sub

    Private Sub cmdSelAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelAll.Click
        Dim i As Integer
        For i = 0 To lstObj.Items.Count - 1
            lstObj.SetItemChecked(i, True)
        Next
    End Sub

   

    Private Sub cmdUnselAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnselAll.Click
        Dim i As Integer
        For i = 0 To lstObj.Items.Count - 1
            lstObj.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub frmDeleteTool_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        lstObj.Items.Clear()
        Dim rs As DataTable
        Dim i As Object
        Dim n, tn As String

        rs = Manager.Session.GetRowsEx("OBJECTTYPE", "*", , , , "order by the_Comment")

        Dim o As tmpInst


        For i = 0 To rs.Rows.Count - 1
            o = New tmpInst
            o.Name = rs.Rows(i)("the_comment")
            o.ObjType = rs.Rows(i)("Name")
            o.IsSingle = rs.Rows(i)("IsSingleInstance")

            cmbType.Items.Add(o)
        Next
        rs = Nothing

        If cmbType.Items.Count > 0 Then
            cmbType.SelectedIndex = 0
        End If

    End Sub

  
End Class