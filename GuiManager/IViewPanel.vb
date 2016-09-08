Public Interface IViewPanel
    Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ReadOnlyView As Boolean)
    Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean
    Function IsOK() As Boolean
    Function IsChanged() As Boolean
    Function Verify(ByVal NoError As Boolean) As Boolean
End Interface
