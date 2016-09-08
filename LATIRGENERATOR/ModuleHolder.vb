Option Strict Off
Option Explicit On
'UPGRADE_WARNING: Class instancing was changed to public. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1043"'
<System.Runtime.InteropServices.ProgId("ModuleHolder_NET.ModuleHolder")> Public Class ModuleHolder
	
	Private mvarModuleName As String 'local copy
	Private mvarFile As String 'local copy
	Private mvarAttributes As Attributes 'local copy
	Private mvarBlocks As Blocks 'local copy
	
	'Parameters:
	' ���������� ���
	'Returns:
	'  ������ ������ Blocks
	'  ,��� Nothing
	'See Also:
	'  Attributes
	'  File
	'  ModuleName
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Blocks
	' Set variable = me.Blocks
	Public ReadOnly Property Blocks() As Blocks
		Get
			If mvarBlocks Is Nothing Then
				mvarBlocks = New Blocks
			End If
			Blocks = mvarBlocks
		End Get
	End Property
	
	'Parameters:
	' ���������� ���
	'Returns:
	'  ������ ������ Attributes
	'  ,��� Nothing
	'See Also:
	'  Blocks
	'  File
	'  ModuleName
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Attributes
	' Set variable = me.Attributes
	Public ReadOnly Property Attributes() As Attributes
		Get
			If mvarAttributes Is Nothing Then
				mvarAttributes = New Attributes
			End If
			Attributes = mvarAttributes
		End Get
	End Property
	
	'Parameters:
	'[IN]   vData , ��� ���������: String  - ...
	'See Also:
	'  Attributes
	'  Blocks
	'  ModuleName
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' value = <��������>
	' me.File = value
	
	'Parameters:
	' ���������� ���
	'Returns:
	'  �������� ���� String
	'See Also:
	'  Attributes
	'  Blocks
	'  ModuleName
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as String
	' variable = me.File
	Public Property File() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.File
			File = mvarFile
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.File = 5
			mvarFile = Value
		End Set
	End Property
	
	'Parameters:
	'[IN]   vData , ��� ���������: String  - ...
	'See Also:
	'  Attributes
	'  Blocks
	'  File
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' value = <��������>
	' me.ModuleName = value
	
	'Parameters:
	' ���������� ���
	'Returns:
	'  �������� ���� String
	'See Also:
	'  Attributes
	'  Blocks
	'  File
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as String
	' variable = me.ModuleName
	Public Property ModuleName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.ModuleName
			Return mvarModuleName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.ModuleName = 5
			mvarModuleName = Value
		End Set
	End Property
	
	Private ReadOnly Property Code() As String
		Get
			Dim b As BlockHolder
            Dim s As String = String.Empty
			For	Each b In Blocks
				s = s & vbCrLf & b.BlockCode
			Next b
			Return s
		End Get
	End Property
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Private Sub Class_Terminate_Renamed()
		'UPGRADE_NOTE: Object mvarAttributes may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		mvarAttributes = Nothing
		'UPGRADE_NOTE: Object mvarBlocks may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		mvarBlocks = Nothing
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	'Parameters:
	'[IN][OUT]  node , ��� ���������: IXMLDOMElement,
	'[IN][OUT]   xdom , ��� ���������: DOMDocument  - ...
	'See Also:
	'  Attributes
	'  Blocks
	'  File
	'  ModuleName
	'  XMLLoad
	'Example:
	'  call me.XMLSave(<���������>)
    Public Sub XMLSave(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
        On Error Resume Next
        Dim e_ As System.Xml.XmlElement
        node.setAttribute("ModuleName", ModuleName)
        node.setAttribute("File", File)
        Attributes.XMLSave(node, xdom)
        Blocks.XMLSave(node, xdom)
    End Sub

    'Parameters:
    '[IN][OUT]  node , ��� ���������: IXMLDOMNode  - ...
    'See Also:
    '  Attributes
    '  Blocks
    '  File
    '  ModuleName
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<���������>)
    Public Sub XMLLoad(ByRef node As System.Xml.XmlNode)
        On Error Resume Next
        Dim e_list As System.Xml.XmlNodeList
        Dim e_ As System.Xml.XmlNode
        'UPGRADE_WARNING: Couldn't resolve default property of object node.Attributes.getNamedItem().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        ModuleName = node.Attributes.getNamedItem("ModuleName").Value
        'ModuleName = Replace(ModuleName, vbLf, vbCrLf)
        'UPGRADE_WARNING: Couldn't resolve default property of object node.Attributes.getNamedItem().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        File = node.Attributes.getNamedItem("File").Value
        'File = Replace(File, vbLf, vbCrLf)
        e_list = node.selectNodes("AttributeHolder")
        Attributes.XMLLoad(e_list)
        e_list = node.selectNodes("BlockHolder")
        Blocks.XMLLoad(e_list)
    End Sub
End Class