Option Strict Off
Option Explicit On
'UPGRADE_WARNING: Class instancing was changed to public. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1043"'
<System.Runtime.InteropServices.ProgId("ProjectHolder_NET.ProjectHolder")> Public Class ProjectHolder
	
	'local variable(s) to hold property value(s)
	Private mvarAttributes As Attributes 'local copy
	Private mvarModules As Modules 'local copy
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект класса Modules
	'  ,или Nothing
	'See Also:
	'  Attributes
	'  Load
	'  Save
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Modules
	' Set variable = me.Modules
	Public ReadOnly Property Modules() As Modules
		Get
			If mvarModules Is Nothing Then
				mvarModules = New Modules
			End If
			Modules = mvarModules
		End Get
	End Property
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект класса Attributes
	'  ,или Nothing
	'See Also:
	'  Load
	'  Modules
	'  Save
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
	
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Private Sub Class_Terminate_Renamed()
		'UPGRADE_NOTE: Object mvarModules may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		mvarModules = Nothing
		'UPGRADE_NOTE: Object mvarAttributes may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		mvarAttributes = Nothing
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	'Parameters:
	'[IN][OUT]  node , тип параметра: IXMLDOMElement,
	'[IN][OUT]   xdom , тип параметра: DOMDocument  - ...
	'See Also:
	'  Attributes
	'  Load
	'  Modules
	'  Save
	'  XMLLoad
	'Example:
	'  call me.XMLSave(<параметры>)
    Public Sub XMLSave(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
        Attributes.XMLSave(node, xdom)
        Modules.XMLSave(node, xdom)
    End Sub

    'Parameters:
    '[IN][OUT]  node , тип параметра: IXMLDOMNode  - ...
    'See Also:
    '  Attributes
    '  Load
    '  Modules
    '  Save
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<параметры>)
    Public Sub XMLLoad(ByRef node As System.Xml.XmlNode)
        On Error Resume Next
        Dim e_list As System.Xml.XmlNodeList
        e_list = node.selectNodes("AttributeHolder")
        Attributes.XMLLoad(e_list)
        e_list = node.selectNodes("ModuleHolder")
        Modules.XMLLoad(e_list)
    End Sub

    'Parameters:
    '[IN]   path , тип параметра: String  - ...
    'See Also:
    '  Attributes
    '  Modules
    '  Save
    '  XMLLoad
    '  XMLSave
    'Example:
    '  call me.Load(<параметры>)
    Public Sub Load(ByVal path As String)
        Dim xdom As System.XML.xmlDocument
        xdom = New System.XML.XmlDocument
        xdom.Load(path)
        If Not xdom.HasChildNodes Then Exit Sub
        Dim xnode As System.Xml.XmlNode
        xnode = xdom.ChildNodes.Item(1)
        XMLLoad(xnode)
    End Sub

    'Parameters:
    '[IN]   path , тип параметра: String  - ...
    'See Also:
    '  Attributes
    '  Load
    '  Modules
    '  XMLLoad
    '  XMLSave
    'Example:
    '  call me.Save(<параметры>)
    Public Sub Save(ByVal path As String)
        Dim xdom As System.XML.xmlDocument
        xdom = New System.XML.xmlDocument
        xdom.loadXML("<?xml version=""1.0""?><root></root>")
        Dim xnode As System.Xml.XmlNode
        xnode = xdom.childNodes.Item(1)
        XMLSave(xnode, xdom)
        xdom.Save(path)
    End Sub
End Class