Option Strict Off
Option Explicit On
'UPGRADE_WARNING: Class instancing was changed to public. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1043"'
<System.Runtime.InteropServices.ProgId("ControlProperty_NET.ControlProperty")> Public Class ControlProperty
	
	
	Private m_Parent As Object
	Private m_Application As Object
	
	Private m_Name As String
	
	Private m_PropValue As String
	Public Event MakeBrief(ByRef BriefString As String)
	
	'Parameters:
	'[IN][OUT]  newParent , ��� ���������: Object  - ...
	'See Also:
	'  Application
	'  MakeBrief
	'  Name
	'  PropValue
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' set value = <������>
	' set me.Parent = value
	
	'Parameters:
	' ���������� ���
	'Returns:
	'  ������ ������ ������ Visual Basic
	'  ,��� Nothing
	'See Also:
	'  Application
	'  MakeBrief
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
	'[IN][OUT]  newApplication , ��� ���������: Object  - ...
	'See Also:
	'  MakeBrief
	'  Name
	'  Parent
	'  PropValue
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' set value = <������>
	' set me.Application = value
	
	'Parameters:
	' ���������� ���
	'Returns:
	'  ������ ������ ������ Visual Basic
	'  ,��� Nothing
	'See Also:
	'  MakeBrief
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
	'[IN]   newValue , ��� ���������: String  - ...
	'See Also:
	'  Application
	'  MakeBrief
	'  Parent
	'  PropValue
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' value = <��������>
	' me.Name = value
	
	'Parameters:
	' ���������� ���
	'Returns:
	'  �������� ���� String
	'See Also:
	'  Application
	'  MakeBrief
	'  Parent
	'  PropValue
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as String
	' variable = me.Name
	Public Property Name() As String
		Get
			
			Return m_Name
		End Get
		Set(ByVal Value As String)
			
			m_Name = Value
		End Set
	End Property
	
	' let
	'Parameters:
	'[IN]   newValue , ��� ���������: String  - ...
	'See Also:
	'  Application
	'  MakeBrief
	'  Name
	'  Parent
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' value = <��������>
	' me.PropValue = value
	
	'Parameters:
	' ���������� ���
	'Returns:
	'  �������� ���� String
	'See Also:
	'  Application
	'  MakeBrief
	'  Name
	'  Parent
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as String
	' variable = me.PropValue
	Public Property PropValue() As String
		Get
			
			PropValue = m_PropValue
		End Get
		Set(ByVal Value As String)
			
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
	'[IN][OUT]  node , ��� ���������: IXMLDOMElement,
	'[IN][OUT]   xdom , ��� ���������: DOMDocument  - ...
	'See Also:
	'  Application
	'  MakeBrief
	'  Name
	'  Parent
	'  PropValue
	'  XMLLoad
	'Example:
	'  call me.XMLSave(<���������>)
    Public Sub XMLSave(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
        On Error Resume Next
        Dim e_ As System.Xml.XmlElement


        node.SetAttribute("Name", Name)
        ' &#xD;&#xA;
        'node.SetAttribute("PropValue", PropValue.Replace("&#xD;&#xA;", vbCrLf))
        node.SetAttribute("PropValue", PropValue)
    End Sub

    'Parameters:
    '[IN][OUT]  node , ��� ���������: IXMLDOMNode  - ...
    'See Also:
    '  Application
    '  MakeBrief
    '  Name
    '  Parent
    '  PropValue
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<���������>)
    Public Sub XMLLoad(ByRef node As System.Xml.XmlNode)
        On Error Resume Next
        Dim e_list As System.Xml.XmlNodeList
        Dim e_ As System.Xml.XmlNode

        Name = Replace(node.Attributes.getNamedItem("Name").Value, vbLf, vbCrLf)
        PropValue = Replace(node.Attributes.getNamedItem("PropValue").Value, vbLf, vbCrLf)

    End Sub
End Class