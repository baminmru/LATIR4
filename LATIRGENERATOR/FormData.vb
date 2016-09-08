Option Strict Off
Option Explicit On
'UPGRADE_WARNING: Class instancing was changed to public. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1043"'
<System.Runtime.InteropServices.ProgId("FormData_NET.FormData")> Public Class FormData
	
	Private m_Parent As Object
	Private m_Application As Object
	
	Private m_ControlData As ControlData_col
	
	Private m_PropertyData As PropertyData_col
	
	Private m_Name As String
	Public Event MakeBrief(ByRef BriefString As String)
	
	'Parameters:
	'[IN][OUT]  newParent , тип параметра: Object  - ...
	'See Also:
	'  Application
	'  CloseClass
	'  ControlData
	'  MakeBrief
	'  Name
	'  PropertyData
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
	'  CloseClass
	'  ControlData
	'  MakeBrief
	'  Name
	'  PropertyData
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
	' параметров нет
	'Returns:
	'  объект любого класса Visual Basic
	'  ,или Nothing
	'See Also:
	'  CloseClass
	'  ControlData
	'  MakeBrief
	'  Name
	'  Parent
	'  PropertyData
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as Object
	' Set variable = me.Application
	Public ReadOnly Property Application() As Object
		Get
			Application = Me
		End Get
	End Property
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект класса ControlData_col
	'  ,или Nothing
	'See Also:
	'  Application
	'  CloseClass
	'  MakeBrief
	'  Name
	'  Parent
	'  PropertyData
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as ControlData_col
	' Set variable = me.ControlData
	Public ReadOnly Property ControlData() As ControlData_col
		Get
			If m_ControlData Is Nothing Then
				m_ControlData = New ControlData_col
				m_ControlData.Parent = Me
				m_ControlData.Application = Me.Application
			End If
			ControlData = m_ControlData
		End Get
	End Property
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект класса PropertyData_col
	'  ,или Nothing
	'See Also:
	'  Application
	'  CloseClass
	'  ControlData
	'  MakeBrief
	'  Name
	'  Parent
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as PropertyData_col
	' Set variable = me.PropertyData
	Public ReadOnly Property PropertyData() As PropertyData_col
		Get
			If m_PropertyData Is Nothing Then
				m_PropertyData = New PropertyData_col
				m_PropertyData.Parent = Me
				m_PropertyData.Application = Me.Application
			End If
			PropertyData = m_PropertyData
		End Get
	End Property
	
	' let
	'Parameters:
	'[IN]   newValue , тип параметра: String  - ...
	'See Also:
	'  Application
	'  CloseClass
	'  ControlData
	'  MakeBrief
	'  Parent
	'  PropertyData
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
	'  CloseClass
	'  ControlData
	'  MakeBrief
	'  Parent
	'  PropertyData
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
	
	Private Sub CloseParents()
		'UPGRADE_NOTE: Object m_Application may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		m_Application = Nothing
		'UPGRADE_NOTE: Object m_Parent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
		m_Parent = Nothing
	End Sub
	
	'Parameters:
	' параметров нет
	'See Also:
	'  Application
	'  ControlData
	'  MakeBrief
	'  Name
	'  Parent
	'  PropertyData
	'  XMLLoad
	'  XMLSave
	'Example:
	'  call me.CloseClass()
	Public Sub CloseClass()
		
		If Not m_ControlData Is Nothing Then
			m_ControlData.CloseClass()
			'UPGRADE_NOTE: Object m_ControlData may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
			m_ControlData = Nothing
		End If
		If Not m_PropertyData Is Nothing Then
			m_PropertyData.CloseClass()
			'UPGRADE_NOTE: Object m_PropertyData may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
			m_PropertyData = Nothing
		End If
		CloseParents()
	End Sub
	
	'Parameters:
	'[IN][OUT]  node , тип параметра: IXMLDOMElement,
	'[IN][OUT]   xdom , тип параметра: DOMDocument  - ...
	'See Also:
	'  Application
	'  CloseClass
	'  ControlData
	'  MakeBrief
	'  Name
	'  Parent
	'  PropertyData
	'  XMLLoad
	'Example:
	'  call me.XMLSave(<параметры>)
    Public Sub XMLSave(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
        On Error Resume Next
        Dim e_ As System.Xml.XmlElement
        node.setAttribute("Name", Name)
        ControlData.XMLSave(node, xdom)
        PropertyData.XMLSave(node, xdom)
    End Sub

    'Parameters:
    '[IN][OUT]  node , тип параметра: IXMLDOMNode  - ...
    'See Also:
    '  Application
    '  CloseClass
    '  ControlData
    '  MakeBrief
    '  Name
    '  Parent
    '  PropertyData
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<параметры>)
    Public Sub XMLLoad(ByRef node As System.Xml.XmlNode)
        On Error Resume Next
        Dim e_list As System.Xml.XmlNodeList
        Dim e_ As System.Xml.XmlNode
        Name = Replace(node.Attributes.getNamedItem("Name").Value, vbLf, vbCrLf)
        e_list = node.selectNodes("ControlData")
        'If e_list.count > 0 Then Stop
        ControlData.XMLLoad(e_list)
        e_list = node.SelectNodes("PropertyData")
        'If e_list.count > 0 Then Stop
        PropertyData.XMLLoad(e_list)
    End Sub
End Class