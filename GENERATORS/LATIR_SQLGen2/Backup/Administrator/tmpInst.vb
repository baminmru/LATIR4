Option Strict Off
Option Explicit On
Friend Class tmpInst
	
    Private mvarID As Guid 'local copy
	Private mvarObjType As String 'local copy
	Private mvarName As String
	Private mvarIsSingle As Integer
	Private mvarLockUserID As String
	
	
	Public Property LockUserID() As String
		Get
			LockUserID = mvarLockUserID
		End Get
		Set(ByVal Value As String)
			mvarLockUserID = Value
		End Set
	End Property
	
	
	
	Public Property IsSingle() As String
		Get
			IsSingle = CStr(mvarIsSingle)
		End Get
		Set(ByVal Value As String)
			mvarIsSingle = CInt(Value)
		End Set
	End Property
	
	
	
	Public Property Name() As String
		Get
			Name = mvarName
		End Get
		Set(ByVal Value As String)
			mvarName = Value
		End Set
	End Property
	
	
	
	
    Public Property ID() As Guid
        Get
            ID = mvarID
        End Get
        Set(ByVal Value As Guid)
            mvarID = Value
        End Set
    End Property
	
	
	Public Property ObjType() As String
		Get
			ObjType = mvarObjType
		End Get
		Set(ByVal Value As String)
			mvarObjType = Value
		End Set
	End Property
End Class