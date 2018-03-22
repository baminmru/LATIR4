
Option Strict Off
Option Explicit On
'UPGRADE_WARNING: Class instancing was changed to public. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1043"'
<System.Runtime.InteropServices.ProgId("ControlData_col_NET.ControlData_col")> Public Class ControlData_col
	
	
	Dim mcol As Collection
	Dim m_Parent As Object
	Dim m_Application As Object
	
	Friend ReadOnly Property ChildNodeID() As String
		Get
			Return "{D853A7A0-EE9F-4101-B700-0F34BAD9318D}"
		End Get
	End Property
	
	Friend ReadOnly Property ChildStructID() As String
		Get
			Return "{28DEEB54-5B3C-403C-97D1-F99626C87C64}"
		End Get
	End Property
	
	Friend ReadOnly Property ChildAggStructID() As String
		Get
			'UPGRADE_WARNING: Couldn't resolve default property of object Parent.StructID. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			Return Parent.StructID
		End Get
	End Property
	
	'Parameters:
	'[IN][OUT]  newParent , тип параметра: Object  - ...
	'See Also:
	'  Add
	'  Application
	'  Count
	'  Item
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' set value = <объект>
	' set me.Parent = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект любого класса Visual Basic
	'  ,или Nothing
	'See Also:
	'  Add
	'  Application
	'  Count
	'  Item
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Object
	' Set variable = me.Parent
	Public Property Parent() As Object
		Get
			Parent = m_Parent
		End Get
		Set(ByVal Value As Object)
			m_Parent = Value
		End Set
	End Property
	
	'Parameters:
	'[IN][OUT]  newApplication , тип параметра: Object  - ...
	'See Also:
	'  Add
	'  Count
	'  Item
	'  Parent
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' set value = <объект>
	' set me.Application = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект любого класса Visual Basic
	'  ,или Nothing
	'See Also:
	'  Add
	'  Count
	'  Item
	'  Parent
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Object
	' Set variable = me.Application
	Public Property Application() As Object
		Get
			If m_Parent Is Nothing Then
				Application = Me
			Else
				Application = m_Application
			End If
		End Get
		Set(ByVal Value As Object)
			m_Application = Value
		End Set
	End Property
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа Long
	'See Also:
	'  Add
	'  Application
	'  Item
	'  Parent
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Long
	' variable = me.Count
	Public ReadOnly Property Count() As Integer
		Get
			Count = mcol.Count()
		End Get
	End Property
	
	Private Sub CloseParents()
		'UPGRADE_NOTE: Object m_Application may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		m_Application = Nothing
		'UPGRADE_NOTE: Object m_Parent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		m_Parent = Nothing
	End Sub
	
	'Parameters:
	'[IN]   ID , тип параметра: String = ""  - ...
	'Returns:
	'  объект класса ControlData
	'  ,или Nothing
	'See Also:
	'  Application
	'  Count
	'  Item
	'  Parent
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as ControlData
	' Set variable = me.Add(<параметры>)
	Public Function Add(Optional ByVal ID As String = "") As ControlData
		Dim o As ControlData
		o = New ControlData
		If ID = "" Then
			mcol.Add(o)
		Else
			mcol.Add(o, ID)
			o.Name = ID
		End If
		o.Parent = Me
		o.Application = Me.Application
		Add = o
		'UPGRADE_NOTE: Object o may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		o = Nothing
	End Function
	
	'Parameters:
	'[IN]   ID , тип параметра: Variant  - ...
	'Returns:
	'  объект класса ControlData
	'  ,или Nothing
	'See Also:
	'  Add
	'  Application
	'  Count
	'  Parent
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as ControlData
	' Set variable = me.Item(<параметры>)
	Public Function Item(ByVal ID As Object) As ControlData
		On Error Resume Next
        If Not mcol.Item(ID) Is Nothing Then
            Return mcol.Item(ID)
        End If
        Return Nothing
	End Function
	
	
	Friend Sub CloseClass()
		On Error Resume Next
		Dim i As Integer
		Dim o As ControlData
		For i = 1 To mcol.Count()
			o = mcol.Item(i)
			o.CloseClass()
		Next 
		CloseParents()
		'UPGRADE_NOTE: Object mcol may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		mcol = Nothing
	End Sub
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Private Sub Class_Initialize_Renamed()
		mcol = New Collection
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'Parameters:
	'[IN]   vntIndexKey , тип параметра: Variant  - ...
	'See Also:
	'  Add
	'  Application
	'  Count
	'  Item
	'  Parent
	'  XMLLoad
	'  XMLSave
	'Example:
	'  call me.Remove(<параметры>)
	Public Sub Remove(ByVal vntIndexKey As Object)
		mcol.Remove(vntIndexKey)
	End Sub
	
	'Parameters:
	'[IN][OUT]   ParentNode , тип параметра: IXMLDOMElement,
	'[IN][OUT]   xdom , тип параметра: DOMDocument  - ...
	'See Also:
	'  Add
	'  Application
	'  Count
	'  Item
	'  Parent
	'  Remove
	'  XMLLoad
	'Example:
	'  call me.XMLSave(<параметры>)
    Public Sub XMLSave(ByRef ParentNode As System.Xml.XmlElement, ByRef xdom As System.XML.xmlDocument)
        Dim o As ControlData
        Dim i As Integer
        Dim node As System.Xml.XmlElement
        'While ParentNode.childNodes.count > 0
        '  ParentNode.removeChild ParentNode.childNodes.Item(1)
        'Wend
        For i = 1 To Count
            o = Item(i)
            node = xdom.createElement("ControlData")
            'UPGRADE_WARNING: Couldn't resolve default property of object node. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            ParentNode.appendChild(node)
            o.XMLSave(node, xdom)
        Next
    End Sub

    'Parameters:
    '[IN][OUT]   NodeList , тип параметра: IXMLDOMNodeList  - ...
    'See Also:
    '  Add
    '  Application
    '  Count
    '  Item
    '  Parent
    '  Remove
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<параметры>)
    Public Sub XMLLoad(ByRef NodeList As System.Xml.XmlNodeList)
        On Error Resume Next
        Dim o As ControlData
        Dim node As System.Xml.XmlElement
        Dim i As Integer

        For i = 0 To NodeList.Count - 1
            node = NodeList.Item(i)
            'UPGRADE_WARNING: Couldn't resolve default property of object node. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            Add().XMLLoad(node)
        Next

    End Sub
End Class