
Option Explicit On


Friend Class R2OMap


    Private mvarID As Guid 'local copy
    Private mvarRowID As Guid 'local copy

    
    Public Property RowID() As Guid
        Get
            Return mvarRowID
        End Get
        Set(ByVal Value As Guid)
            mvarRowID = Value
        End Set
    End Property

    Public Property ID() As Guid
        Get
            Return mvarID
        End Get
        Set(ByVal Value As Guid)
            mvarID = Value
        End Set
    End Property


        Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

