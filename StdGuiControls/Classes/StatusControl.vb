Public Class StatusControl

#Region "Declarations"
    Protected mGUIManager As LATIR2GuiManager.LATIRGuiManager
    Protected mDocItem As LATIR2.Document.Doc_Base

#End Region

#Region "Events"
    Public Event CheckFor(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid, ByRef OK As Boolean)
    Public Event BeforeChangeState(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid)
    Public Event AfterChangeState(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid)
#End Region

    Public Function GuiManager() As LATIR2GuiManager.LATIRGuiManager
        GuiManager = mGUIManager
    End Function

    Public Function DocItem() As LATIR2.Document.Doc_Base
        DocItem = mDocItem
    End Function

    Public Overridable Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByRef DocItem As LATIR2.Document.Doc_Base, ByVal AllowEdit As Boolean, ByVal AllowAdd As Boolean, ByVal AllowDel As Boolean)
        mGUIManager = gm
        mDocItem = DocItem
        'InitializeComponent()
        If AllowEdit = False Then
            cmbStatus.Enabled = False
            cmdChangeSatus.Enabled = False
        Else
            cmbStatus.Enabled = True
            cmdChangeSatus.Enabled = True
        End If
        InitCombo()
    End Sub

    Private Sub InitCombo()
        lblStatus.Text = DocItem.StatusName
        cmbStatus.DisplayMember = "NAME"
        cmbStatus.ValueMember = "ID"
        cmbStatus.DataSource = DocItem.AvailableStatusDT()
    End Sub


    Private Sub cmdChangeSatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeSatus.Click
        Dim id As System.Guid, OK As Boolean

        If cmbStatus.Items.Count > 0 Then
            id = cmbStatus.SelectedValue
            OK = True
            If MsgBox("Изменить состояние документа " & DocItem.Brief & " на <" & cmbStatus.Text & "> ?", MsgBoxStyle.YesNo, "Смена состояния") = MsgBoxResult.Yes Then
                RaiseEvent CheckFor(DocItem, id, OK)

                If OK Then
                    RaiseEvent BeforeChangeState(DocItem, id)
                    DocItem.StatusID = id
                    RaiseEvent AfterChangeState(DocItem, id)
                    InitCombo()
                End If
            End If
        End If
    End Sub
End Class
