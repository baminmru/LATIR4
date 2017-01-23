Option Strict Off
Option Explicit On
'UPGRADE_WARNING: Class instancing was changed to public. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1043"'
<System.Runtime.InteropServices.ProgId("BlockHolder_NET.BlockHolder")> Public Class BlockHolder
	
	
	Private mvarBlockName As String 'local copy
	Private mvarAttributes As Attributes 'local copy
    Private mvarFormData As LATIRGenerator.FormData
	Private wr As Writer
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект класса Attributes
	'  ,или Nothing
	'See Also:
	'  BlockCode
	'  BlockName
	'  FormData
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
	' параметров нет
	'Returns:
	'  объект класса MTZGenerator.FormData
	'  ,или Nothing
	'See Also:
	'  Attributes
	'  BlockCode
	'  BlockName
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as MTZGenerator.FormData
	' Set variable = me.FormData
    Public ReadOnly Property FormData() As LATIRGenerator.FormData
        Get
            If mvarFormData Is Nothing Then
                mvarFormData = New LATIRGenerator.FormData
            End If
            FormData = mvarFormData
        End Get
    End Property
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  Attributes
	'  BlockName
	'  FormData
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.BlockCode = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  Attributes
	'  BlockName
	'  FormData
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as String
	' variable = me.BlockCode
	Public Property BlockCode() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.BlockCode
			BlockCode = wr.getBuf
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.BlockCode = 5
			'UPGRADE_NOTE: Object wr may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
			wr = Nothing
			wr = New Writer
			wr.putBuf(Value)
			wr.Flush()
		End Set
	End Property
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  Attributes
	'  BlockCode
	'  FormData
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.BlockName = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  Attributes
	'  BlockCode
	'  FormData
	'  XMLLoad
	'  XMLSave
	'Example:
	' dim variable as String
	' variable = me.BlockName
	Public Property BlockName() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.BlockName
			Return mvarBlockName
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.BlockName = 5
			mvarBlockName = Value
		End Set
	End Property
	
	Public Sub AppendCode(ByVal s As String)
		wr.putBuf2(s)
	End Sub
	
	'Parameters:
	'[IN][OUT]  node , тип параметра: IXMLDOMElement,
	'[IN][OUT]   xdom , тип параметра: DOMDocument  - ...
	'See Also:
	'  Attributes
	'  BlockCode
	'  BlockName
	'  FormData
	'  XMLLoad
	'Example:
	'  call me.XMLSave(<параметры>)
    Public Sub XMLSave(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
        On Error Resume Next
        Dim e_ As System.Xml.XmlElement
        node.SetAttribute("BlockName", BlockName)

        ' &#xD;&#xA;
        'node.SetAttribute("BlockCode", BlockCode.Replace("&#xD;&#xA;", vbCrLf))
        node.SetAttribute("BlockCode", BlockCode)
        Attributes.XMLSave(node, xdom)

        If FormData.Name <> "" Then
        End If
        Dim nnode As System.Xml.XmlElement
        nnode = xdom.createElement("FormData")
        'UPGRADE_WARNING: Couldn't resolve default property of object nnode. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        node.appendChild(nnode)
        FormData.XMLSave(nnode, xdom)

    End Sub

    'Parameters:
    '[IN][OUT]  node , тип параметра: IXMLDOMNode  - ...
    'See Also:
    '  Attributes
    '  BlockCode
    '  BlockName
    '  FormData
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<параметры>)
    Public Sub XMLLoad(ByRef node As System.Xml.XmlNode)
        On Error Resume Next
        Dim e_list As System.Xml.XmlNodeList
        Dim e_ As System.Xml.XmlNode
        'BlockName = Replace(node.Attributes.getNamedItem("BlockName").Value, vbLf, vbCrLf)
        BlockName = node.Attributes.GetNamedItem("BlockName").Value
        'BlockCode = Replace(node.Attributes.getNamedItem("BlockCode").Value, vbLf, vbCrLf)
        BlockCode = node.Attributes.GetNamedItem("BlockCode").Value
        e_list = node.selectNodes("AttributeHolder")
        Attributes.XMLLoad(e_list)
        e_list = node.selectNodes("FormData")
        If e_list.Count = 1 Then FormData.XMLLoad(e_list.Item(0))

    End Sub


    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Initialize_Renamed()
        wr = New Writer
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Terminate_Renamed()
        'UPGRADE_NOTE: Object mvarAttributes may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        mvarAttributes = Nothing
        'UPGRADE_NOTE: Object mvarFormData may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        mvarFormData = Nothing
        'UPGRADE_NOTE: Object wr may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        wr = Nothing

    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub

    Public Sub Flush()
        wr.Flush()
    End Sub
End Class