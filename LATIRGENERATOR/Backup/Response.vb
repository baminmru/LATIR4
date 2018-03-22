Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("Response_NET.Response")> Public Class Response
	'local variable(s) to hold property value(s)
	
	'local variable(s) to hold property value(s)
	Private mvarCurrentBlock As BlockHolder 'local copy
	Private mvarPrj As ProjectHolder
	'local variable(s) to hold property value(s)
	Private mvarCurrentModule As String 'local copy
	Private mvarBlock As String 'local copy
	Public Event OnExec(ByRef s As String)
	Public Event OnStatus(ByRef s As String, ByRef progress As Integer)
	
	'Parameters:
	'[IN]   s , тип параметра: String  - ...
	'See Also:
	'  Block
	'  Clear
	'  Code
	'  CountOfLines
	'  CurrentBlock
	'  InsertLines
	'  Line
	'  Lines
	'  Load
	'  Module
	'  OnExec
	'  Out
	'  OutNL
	'  Project
	'  RemoveLine
	'  Save
	'Example:
	'  call me.Exec(<параметры>)
	Public Sub Exec(ByVal s As String)
		RaiseEvent OnExec(s)
	End Sub
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  Clear
	'  Code
	'  CountOfLines
	'  CurrentBlock
	'  Exec
	'  InsertLines
	'  Line
	'  Lines
	'  Load
	'  Module
	'  OnExec
	'  Out
	'  OutNL
	'  Project
	'  RemoveLine
	'  Save
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.Block = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  Clear
	'  Code
	'  CountOfLines
	'  CurrentBlock
	'  Exec
	'  InsertLines
	'  Line
	'  Lines
	'  Load
	'  Module
	'  OnExec
	'  Out
	'  OutNL
	'  Project
	'  RemoveLine
	'  Save
	'Example:
	' dim variable as String
	' variable = me.Block
	Public Property Block() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Block
			Block = mvarBlock
		End Get
		Set(ByVal Value As String)
			
			On Error Resume Next
			If mvarBlock <> "" And mvarCurrentModule <> "" Then
				CurrentBlock.Flush()
			End If
			
			mvarBlock = Value
            If ModuleName = "" Then
                ModuleName = "Module1"
            End If
            If Project.Modules.Item(ModuleName).Blocks(Value) Is Nothing Then
                Project.Modules.Item(ModuleName).Blocks.Add(Value)
            End If
        End Set
    End Property

    'Parameters:
    '[IN]   vData , тип параметра: String  - ...
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    ' dim value as Variant
    ' value = <значение>
    ' me.Module = value

    'Parameters:
    ' параметров нет
    'Returns:
    '  значение типа String
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    ' dim variable as String
    ' variable = me.Module
    'UPGRADE_NOTE: Module was upgraded to ModuleName. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Public Property ModuleName() As String
        Get
            ModuleName = mvarCurrentModule
        End Get
        Set(ByVal Value As String)
            On Error Resume Next
            If mvarBlock <> "" And mvarCurrentModule <> "" Then
                CurrentBlock.Flush()
            End If
            mvarCurrentModule = Value
            If Project.Modules.Item(mvarCurrentModule) Is Nothing Then
                Project.Modules.Add(mvarCurrentModule)
            End If
        End Set
    End Property






    Private Property mvarCode() As String
        Get
            If CurrentBlock Is Nothing Then
                Return ""
            Else
                Return CurrentBlock.BlockCode
            End If
        End Get
        Set(ByVal Value As String)
            If Not CurrentBlock Is Nothing Then
                CurrentBlock.BlockCode = Value
            End If
        End Set
    End Property


    Private WriteOnly Property AppendCode() As String
        Set(ByVal Value As String)
            If Not CurrentBlock Is Nothing Then
                CurrentBlock.AppendCode(Value)
            End If
        End Set
    End Property

    'Parameters:
    ' параметров нет
    'Returns:
    '  объект класса BlockHolder
    '  ,или Nothing
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    ' dim variable as BlockHolder
    ' Set variable = me.CurrentBlock
    Public ReadOnly Property CurrentBlock() As BlockHolder
        Get
            If Block = "" Then
                Block = "Block1"
            End If
            CurrentBlock = Project.Modules(ModuleName).Blocks(Block)
        End Get
    End Property

    'Parameters:
    ' параметров нет
    'Returns:
    '  объект класса String()
    '  ,или Nothing
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    ' dim variable as String()
    ' Set variable = me.Lines
    Public ReadOnly Property Lines() As String()
        Get
            Return Split(mvarCode, vbCrLf)
        End Get
    End Property

    'Parameters:
    '[IN]   at , тип параметра: String  - ...
    'Returns:
    '  значение типа String
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    ' dim variable as String
    ' variable = me.Line(<параметры>)
    Public ReadOnly Property Line(ByVal at As String) As String
        Get
            Dim l() As String
            l = Split(mvarCode, vbCrLf)
            Line = l(CInt(at))
        End Get
    End Property

    'Parameters:
    ' параметров нет
    'Returns:
    '  значение типа Long
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    ' dim variable as Long
    ' variable = me.CountOfLines
    Public ReadOnly Property CountOfLines() As Integer
        Get
            Dim l() As String

            If mvarCode <> "" Then
                l = Split(mvarCode, vbCrLf)
                CountOfLines = UBound(l) + 1
            Else
                CountOfLines = 0
            End If
        End Get
    End Property

    'Parameters:
    '[IN]   vData , тип параметра: String  - ...
    'See Also:
    '  Block
    '  Clear
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    ' dim value as Variant
    ' value = <значение>
    ' me.Code = value

    'Parameters:
    ' параметров нет
    'Returns:
    '  значение типа String
    'See Also:
    '  Block
    '  Clear
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    ' dim variable as String
    ' variable = me.Code
    Public Property Code() As String
        Get
            'used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.Code
            Code = mvarCode
        End Get
        Set(ByVal Value As String)
            'used when assigning a value to the property, on the left side of an assignment.
            'Syntax: X.Code = 5
            mvarCode = Value
        End Set
    End Property

    'Parameters:
    ' параметров нет
    'Returns:
    '  объект класса ProjectHolder
    '  ,или Nothing
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  RemoveLine
    '  Save
    'Example:
    ' dim variable as ProjectHolder
    ' Set variable = me.Project()
    Public Function Project() As ProjectHolder
        If mvarPrj Is Nothing Then
            mvarPrj = New ProjectHolder
        End If
        Project = mvarPrj
    End Function

    'Parameters:
    '[IN]   s , тип параметра: String,
    '[IN]   at , тип параметра: Long  - ...
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    '  call me.InsertLines(<параметры>)
    Public Sub InsertLines(ByVal s As String, ByVal at As Integer)
        Dim l() As String
        Dim o As String
        Dim i As Integer
        l = Split(mvarCode, vbCrLf)
        o = ""
        For i = 0 To at
            If i <= UBound(l) Then
                If o <> "" Then
                    o = o & vbCrLf
                End If
                o = o & l(i)
            End If
        Next
        If o <> "" Then
            o = o & vbCrLf
        End If
        o = o & s
        For i = at + 1 To UBound(l)
            If o <> "" Then
                o = o & vbCrLf
            End If
            o = o & l(i)
        Next
        mvarCode = o
    End Sub

    'Parameters:
    '[IN]   at , тип параметра: Long  - ...
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  Save
    'Example:
    '  call me.RemoveLine(<параметры>)
    Public Sub RemoveLine(ByVal at As Integer)
        Dim l() As String
        Dim o As String
        Dim i As Integer
        l = Split(mvarCode, vbCrLf)
        o = ""
        For i = 0 To UBound(l)
            If i <> at Then
                If o <> "" Then
                    o = o & vbCrLf
                End If
                o = o & l(i)
            End If
        Next
        mvarCode = o
    End Sub

    'Parameters:
    ' параметров нет
    'See Also:
    '  Block
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    '  call me.Clear()
    Public Sub Clear()
        mvarCode = ""
    End Sub

    'Parameters:
    '[IN]   Text , тип параметра: String  - ...
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    '  call me.Out(<параметры>)
    Public Sub Out(ByVal Text As String)
        AppendCode = Text
    End Sub

    'Parameters:
    '[IN]   Text , тип параметра: String  - ...
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    '  call me.OutNL(<параметры>)
    Public Sub OutNL(ByVal Text As String)
        AppendCode = Text & vbCrLf
    End Sub

    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Terminate_Renamed()
        'UPGRADE_NOTE: Object mvarCurrentBlock may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        mvarCurrentBlock = Nothing
        'UPGRADE_NOTE: Object mvarPrj may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        mvarPrj = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub

    'Parameters:
    '[IN]   path , тип параметра: String  - ...
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    '  Save
    'Example:
    '  call me.Load(<параметры>)
    Public Sub Load(ByVal path As String)
        Project.Load(path)
    End Sub

    'Parameters:
    '[IN]   path , тип параметра: String  - ...
    'See Also:
    '  Block
    '  Clear
    '  Code
    '  CountOfLines
    '  CurrentBlock
    '  Exec
    '  InsertLines
    '  Line
    '  Lines
    '  Load
    '  Module
    '  OnExec
    '  Out
    '  OutNL
    '  Project
    '  RemoveLine
    'Example:
    '  call me.Save(<параметры>)
    Public Sub Save(ByVal path As String)
        Project.Save(path)
    End Sub
    Public Sub Status(ByVal msg As String, ByVal pos As Integer)
        On Error Resume Next
        RaiseEvent OnStatus(msg, pos)
    End Sub
End Class