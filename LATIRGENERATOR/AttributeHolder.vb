Option Strict Off
Option Explicit On
'UPGRADE_WARNING: Class instancing was changed to public. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1043"'
<System.Runtime.InteropServices.ProgId("AttributeHolder_NET.AttributeHolder")> Public Class AttributeHolder
	
  Private mvarName As String 'local copy
	Private mvarValue As String 'local copy
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  Name
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.Value = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  Name
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as String
	' variable = me.Value
	Public Property Value() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Value
			Value = mvarValue
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.Value = 5
			mvarValue = Value
		End Set
	End Property
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  Value
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
	'  Value
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as String
	' variable = me.Name
	Public Property Name() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Name
			Return mvarName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.Name = 5
			mvarName = Value
		End Set
	End Property
	
	'Parameters:
	'[IN][OUT]  node , тип параметра: IXMLDOMElement,
	'[IN][OUT]   xdom , тип параметра: DOMDocument  - ...
	'See Also:
	'  Name
	'  Value
	'  XMLLoad
	'Example:
	'  call me.XMLSave(<параметры>)
    Public Sub XMLSave(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
        On Error Resume Next
        Dim e_ As System.Xml.XmlElement  'System.Xml.XmlElement

        ' TEST 
        ' &#xD;&#xA;
        node.SetAttribute("Name", Name)
        'node.SetAttribute("Value", Value.Replace("&#xD;&#xA;", vbCrLf))
        node.SetAttribute("Value", Value)
    End Sub

    'Parameters:
    '[IN][OUT]  node , тип параметра: IXMLDOMNode  - ...
    'See Also:
    '  Name
    '  Value
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<параметры>)
    Public Sub XMLLoad(ByRef node As System.Xml.XmlNode)
        On Error Resume Next
        Dim e_list As System.Xml.XmlNodeList
        Dim e_ As System.Xml.XmlNode
        'UPGRADE_WARNING: Couldn't resolve default property of object node.Attributes.getNamedItem().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Name = node.Attributes.GetNamedItem("Name").Value
        'Name = Replace(Name, vbLf, vbCrLf)
        'UPGRADE_WARNING: Couldn't resolve default property of object node.Attributes.getNamedItem().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Value = node.Attributes.GetNamedItem("Value").Value
        'Value = Replace(Value, vbLf, vbCrLf)
    End Sub
End Class