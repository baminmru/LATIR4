Public Interface ITreeControlInterface
    Event OnTreeAddRoot(ByRef OK As Boolean)
    Event OnTreeAdd(ByRef OK As Boolean, ByVal ID As System.Guid)
    Event OnTreeEdit(ByRef OK As Boolean, ByVal ID As System.Guid)
    Event OnTreeDel(ByRef OK As Boolean, ByVal ID As System.Guid)
    Event OnTreeRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean)
    Event OnTreePrint(ByRef OK As Boolean, ByRef UseDefault As Boolean)
    Event OnTreeProp(ByRef OK As Boolean, ByRef UseDefault As Boolean)
    Event OnTreeRefresh(ByRef OK As Boolean)
    Event OnTreeFind(ByRef OK As Boolean, ByRef UseDefault As Boolean)

    Event OnTreeGetData(ByVal Parent As System.Guid)
    Event OnTreeSelect(ByVal ID As System.Guid)
End Interface
