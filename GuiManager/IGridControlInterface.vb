Public Interface IGridControlInterface
    Event OnGridAdd(ByRef OK As Boolean, ByVal ID As System.Guid)
    Event OnGridRefresh()
    Event OnGridFind(ByVal UseDefault As Boolean)
    Event OnGridDel(ByRef OK As Boolean, ByVal ID As System.Guid)
    Event OnGridEdit(ByRef OK As Boolean, ByVal ID As System.Guid)
    Event OnGridProp(ByRef OK As Boolean, ByRef UseDefault As Boolean)
    Event OnGridRun(ByRef OK As Boolean, ByVal ID As System.Guid, ByRef UseDefault As Boolean)
    Event OnGridPrint(ByRef OK As Boolean, ByRef UseDefault As Boolean)

    Event OnGridRowColChange(ByVal ID As System.Guid)
    Event OnGridGetData(ByVal ID As System.Guid)
End Interface
