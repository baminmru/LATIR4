Public Interface IRowEditor
    Event Changed()
    Event Saved()
    Event Refreshed()
    Sub Save()
    Function IsOK() As Boolean
    Function IsChanged() As Boolean
    Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base, ByVal RowReadOnly As Boolean)
End Interface
