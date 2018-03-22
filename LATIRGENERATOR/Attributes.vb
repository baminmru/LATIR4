
Option Strict Off
Option Explicit On
'UPGRADE_WARNING: Class instancing was changed to public. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1043"'
<System.Runtime.InteropServices.ProgId("Attributes_NET.Attributes")> Public Class Attributes
	Implements System.Collections.IEnumerable
	
	'local variable to hold collection
	Private mcol As Collection
	
	'Parameters:
	'[IN]   Name , тип параметра: String  - ...
	'Returns:
	'  объект класса AttributeHolder
	'  ,или Nothing
	'See Also:
	'  Count
	'  Item
	'  NewEnum
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as AttributeHolder
	' Set variable = me.Add(<параметры>)
	Public Function Add(ByVal Name As String) As AttributeHolder
		'create a new object
		Dim objNewMember As AttributeHolder
		
		On Error Resume Next
		objNewMember = Item(Name)
		If objNewMember Is Nothing Then
			objNewMember = New AttributeHolder
			objNewMember.Name = Name
			mcol.Add(objNewMember, Name)
		End If
		
		'return the object created
		Add = objNewMember
		'UPGRADE_NOTE: Object objNewMember may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		objNewMember = Nothing
	End Function
	
	'Parameters:
	'[IN][OUT]  vntIndexKey , тип параметра: Variant  - ...
	'Returns:
	'  объект класса AttributeHolder
	'  ,или Nothing
	'See Also:
	'  Add
	'  Count
	'  NewEnum
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as AttributeHolder
	' Set variable = me.Item(<параметры>)
	Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As AttributeHolder
		Get
            Try
                Return mcol.Item(vntIndexKey)
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
	End Property
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа Long
	'See Also:
	'  Add
	'  Item
	'  NewEnum
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Long
	' variable = me.Count
	Public ReadOnly Property Count() As Integer
		Get
			'used when retrieving the number of elements in the
			'collection. Syntax: Debug.Print x.Count
			Count = mcol.Count()
		End Get
	End Property
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект класса IUnknown
	'  ,или Nothing
	'See Also:
	'  Add
	'  Count
	'  Item
	'  Remove
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as IUnknown
	' Set variable = me.NewEnum
	'UPGRADE_NOTE: NewEnum property was commented out. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1054"'
	'Public ReadOnly Property NewEnum() As stdole.IUnknown
		'Get
			'this property allows you to enumerate
			'this collection with the For...Each syntax
			'NewEnum = mcol._NewEnum
		'End Get
	'End Property
	
	Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		'UPGRADE_TODO: Uncomment and change the following line to return the collection enumerator. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1055"'
        GetEnumerator = mcol.GetEnumerator
	End Function
	
	'Parameters:
	'[IN][OUT]  vntIndexKey , тип параметра: Variant  - ...
	'See Also:
	'  Add
	'  Count
	'  Item
	'  NewEnum
	'  XMLLoad
	'  XMLSave
	'Example:
	'  call me.Remove(<параметры>)
	Public Sub Remove(ByRef vntIndexKey As Object)
		'used when removing an element from the collection
		'vntIndexKey contains either the Index or Key, which is why
		'it is declared as a Variant
		'Syntax: x.Remove(xyz)
		
		
		mcol.Remove(vntIndexKey)
	End Sub
	
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Private Sub Class_Initialize_Renamed()
		'creates the collection when this class is created
		mcol = New Collection
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Private Sub Class_Terminate_Renamed()
		'destroys collection when this class is terminated
		'UPGRADE_NOTE: Object mcol may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		mcol = Nothing
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	'Parameters:
	'[IN][OUT]   ParentNode , тип параметра: IXMLDOMElement,
	'[IN][OUT]   xdom , тип параметра: DOMDocument  - ...
	'See Also:
	'  Add
	'  Count
	'  Item
	'  NewEnum
	'  Remove
	'  XMLLoad
	'Example:
	'  call me.XMLSave(<параметры>)
    Public Sub XMLSave(ByRef ParentNode As System.Xml.XmlElement, ByRef xdom As System.Xml.XmlDocument)
        Dim o As AttributeHolder
        Dim i As Integer
        Dim node As System.Xml.XmlElement
        For i = 1 To Count
            o = Item(i)
            node = xdom.createElement("AttributeHolder")
            'UPGRADE_WARNING: Couldn't resolve default property of object node. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            ParentNode.AppendChild(node)
            o.XMLSave(node, xdom)
        Next
    End Sub

    'Parameters:
    '[IN][OUT]   NodeList , тип параметра: IXMLDOMNodeList  - ...
    'See Also:
    '  Add
    '  Count
    '  Item
    '  NewEnum
    '  Remove
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<параметры>)
    Public Sub XMLLoad(ByRef NodeList As System.Xml.XmlNodeList)
        On Error Resume Next
        Dim node As System.Xml.XmlElement
        Dim i As Integer
        For i = 0 To NodeList.Count - 1
            node = NodeList.Item(i)

            If Item((node.Attributes.GetNamedItem("Name").Value)) Is Nothing Then
                'UPGRADE_WARNING: Couldn't resolve default property of object node. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Add(node.Attributes.GetNamedItem("Name").Value).XMLLoad(node)
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object node. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                Item((node.Attributes.GetNamedItem("Name").Value)).XMLLoad(node)
            End If

        Next
    End Sub
End Class