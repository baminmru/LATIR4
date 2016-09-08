Option Strict Off
Option Explicit On
'UPGRADE_WARNING: Class instancing was changed to public. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1043"'
<System.Runtime.InteropServices.ProgId("PropertyData_NET.PropertyData")> Public Class PropertyData
	
	
	Private m_Parent As Object
	Private m_Application As Object
	Private m_Name As String
	Private m_PropValue As Object
	
	'Parameters:
	'[IN][OUT]  newParent , тип параметра: Object  - ...
	'See Also:
	'  Application
	'  Name
	'  PropValue
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
	'  Application
	'  Name
	'  PropValue
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
	'  Name
	'  Parent
	'  PropValue
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
	'  Name
	'  Parent
	'  PropValue
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Object
	' Set variable = me.Application
	Public Property Application() As Object
		Get
			Application = m_Application
		End Get
		Set(ByVal Value As Object)
			m_Application = Value
		End Set
	End Property
	
	' let
	'Parameters:
	'[IN]   newValue , тип параметра: String  - ...
	'See Also:
	'  Application
	'  Parent
	'  PropValue
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.Name = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  Application
	'  Parent
	'  PropValue
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as String
	' variable = me.Name
	Public Property Name() As String
		Get
			'LoadFromCash
			'AccessDate = Now
			
			Return m_Name
		End Get
		Set(ByVal Value As String)
			'LoadFromCash
			''AccessDate = Now: KeepInMemory = True
			
			m_Name = Value
		End Set
	End Property
	
	' let
	'Parameters:
	'[IN]   newValue , тип параметра: Variant  - ...
	'See Also:
	'  Application
	'  Name
	'  Parent
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.PropValue = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект любого класса Visual Basic
	'  ,или Nothing
	'  ,или значение любого скал€рного типа
	'See Also:
	'  Application
	'  Name
	'  Parent
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Variant
	' variable = me.PropValue
	' Set variable = me.PropValue
	Public Property PropValue() As Object
		Get
			'LoadFromCash
			'AccessDate = Now
			
			'UPGRADE_WARNING: Couldn't resolve default property of object m_PropValue. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: Couldn't resolve default property of object PropValue. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			PropValue = m_PropValue
		End Get
		Set(ByVal Value As Object)
			'LoadFromCash
			''AccessDate = Now: KeepInMemory = True
			
			'UPGRADE_WARNING: Couldn't resolve default property of object newValue. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: Couldn't resolve default property of object m_PropValue. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			m_PropValue = Value
		End Set
	End Property
	
	Private Sub CloseParents()
		'UPGRADE_NOTE: Object m_Application may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		m_Application = Nothing
		'UPGRADE_NOTE: Object m_Parent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		m_Parent = Nothing
	End Sub
	
	
	
	Friend Sub CloseClass()
		
		CloseParents()
	End Sub
	
	'Parameters:
	'[IN][OUT]  node , тип параметра: IXMLDOMElement,
	'[IN][OUT]   xdom , тип параметра: DOMDocument  - ...
	'See Also:
	'  Application
	'  Name
	'  Parent
	'  PropValue
	'  XMLLoad
	'Example:
	'  call me.XMLSave(<параметры>)
    Public Sub XMLSave(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
        On Error Resume Next
        Dim e_ As System.Xml.XmlElement
        'LoadFromCash

        node.SetAttribute("Name", Name)
        ' 
        node.setAttribute("PropValue", PropValue)
    End Sub

    'Parameters:
    '[IN][OUT]  node , тип параметра: IXMLDOMNode  - ...
    'See Also:
    '  Application
    '  Name
    '  Parent
    '  PropValue
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<параметры>)
    Public Sub XMLLoad(ByRef node As System.Xml.XmlNode)
        On Error Resume Next
        Dim e_list As System.Xml.XmlNodeList
        Dim e_ As System.Xml.XmlNode
        Name = Replace(node.Attributes.getNamedItem("Name").Value, vbLf, vbCrLf)
        'UPGRADE_WARNING: Couldn't resolve default property of object node.Attributes.getNamedItem().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        PropValue = node.Attributes.getNamedItem("PropValue").Value

    End Sub
End Class