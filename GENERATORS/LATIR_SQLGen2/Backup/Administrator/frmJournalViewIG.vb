Public Class frmJournalViewIG
    Public GuiManager As LATIRGuiManager.LATIRGuiManager
    Dim dt As DataTable
    Public Sub Attach(ByVal gm As LATIRGuiManager.LATIRGuiManager)
        GuiManager = gm

        dt = GuiManager.Manager.Session.GetRowsExDT("INSTANCE", , , "OBJTYPE='MTZjrnl'")
        cmbJournals.Items.Clear()
        'cmbJournals.Sorted = True

        cmbJournals.DisplayMember = "Name"
        cmbJournals.ValueMember = "INSTANCEID"
        cmbJournals.DataSource = dt

    End Sub

   

    Private Sub cmbJournals_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJournals.SelectedIndexChanged
        Dim OID As System.Guid

        OID = cmbJournals.SelectedValue

        Dim jdef As MTZJrnl.MTZJrnl.Application
        jdef = CType(GuiManager.Manager.GetInstanceObject(OID), MTZJrnl.MTZJrnl.Application)
        jv.Attach(GuiManager, jdef, Me)
    End Sub



    Private Sub jv_JVOnEdit(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refesh As Boolean) Handles jv.JVOnEdit
        Dim obj As LATIR.Document.Doc_Base
        Dim dg As LATIRGuiManager.Doc_GUIBase
        If InstanceID.Equals(System.Guid.Empty) Then Exit Sub
        obj = GuiManager.Manager.GetInstanceObject(InstanceID)
        If obj Is Nothing Then
            MsgBox("Не удалось получить доступ к объекту")
            Exit Sub
        End If
        dg = GuiManager.GetTypeGUI(obj.TypeName)
        If dg Is Nothing Then
            MsgBox("Не удалось получить доступ к интерфейсной части объекта")
            Exit Sub
        End If
        dg.ShowForm("", obj)
        Refesh = False
        UseDefault = False
    End Sub



    Private Sub jv_JVOnDel(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refesh As Boolean) Handles jv.JVOnDel
        Dim obj As LATIR.Document.Doc_Base
        If InstanceID.Equals(System.Guid.Empty) Then Exit Sub
        obj = GuiManager.Manager.GetInstanceObject(InstanceID)
        If obj Is Nothing Then
            MsgBox("Не удалось получить доступ к объекту")
            Exit Sub
        End If
        If MsgBox("Удалить документ: <" & obj.Brief & "> ?", vbYesNo + vbQuestion, "Удаление документа") = vbYes Then
            GuiManager.Manager.DeleteInstance(obj)
        End If
        UseDefault = False
    End Sub

    Private Sub jv_JVOnRun(ByVal InstanceID As System.Guid, ByVal RowID As System.Guid, ByVal ViewBase As String, ByRef UseDefault As Boolean, ByRef Refesh As Boolean) Handles jv.JVOnRun
        Dim f As frmChild
        f = New frmChild

        Dim obj As LATIR.Document.Doc_Base
        Dim dg As LATIRGuiManager.Doc_GUIBase
        If InstanceID.Equals(System.Guid.Empty) Then Exit Sub
        obj = GuiManager.Manager.GetInstanceObject(InstanceID)
        If obj Is Nothing Then
            MsgBox("Не удалось получить доступ к объекту")
            Exit Sub
        End If
        dg = GuiManager.GetTypeGUI(obj.TypeName)
        If dg Is Nothing Then
            MsgBox("Не удалось получить доступ к интерфейсной части объекта")
            Exit Sub
        End If
        f.AppendControl(dg.GetObjectControl("", obj.TypeName))
        f.MdiParent = Me.MdiParent
        f.Attach(GuiManager, obj)
        f.Show()
        UseDefault = False
    End Sub

   
End Class