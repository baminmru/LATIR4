Option Strict Off
Option Explicit On

<System.Runtime.InteropServices.ProgId("ControlData_NET.ControlData")> Public Class ControlData
	
	
	Private m_Parent As Object
	Private m_Application As Object
	
	Private m_ControlData As ControlData_col
	
	Private m_Properties As Properties_col
	
	Private m_Name As String
	
	Private m_ControlIndex As Integer
	
	Private m_PROGID As String
	
	'Parameters:
	' параметров нет
	'Returns:
	'  объект класса ControlData_col
	'  ,или Nothing
	'See Also:
	'  Application
	'  ControlIndex
	'  Name
	'  Parent
	'  PROGID
	'  Properties
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
            Return m_ControlData
        End Get
    End Property

    'Parameters:
    '[IN][OUT]  newParent , тип параметра: Object  - ...
    'See Also:
    '  Application
    '  ControlData
    '  ControlIndex
    '  Name
    '  PROGID
    '  Properties
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
    '  ControlData
    '  ControlIndex
    '  Name
    '  PROGID
    '  Properties
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
    '  ControlData
    '  ControlIndex
    '  Name
    '  Parent
    '  PROGID
    '  Properties
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
    '  ControlData
    '  ControlIndex
    '  Name
    '  Parent
    '  PROGID
    '  Properties
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

    'Parameters:
    ' параметров нет
    'Returns:
    '  объект класса Properties_col
    '  ,или Nothing
    'See Also:
    '  Application
    '  ControlData
    '  ControlIndex
    '  Name
    '  Parent
    '  PROGID
    '  XMLLoad
    '  XMLSave
    'Example:
    ' dim variable as Properties_col
    ' Set variable = me.Properties
    Public ReadOnly Property Properties() As Properties_col
        Get
            If m_Properties Is Nothing Then
                m_Properties = New Properties_col
                m_Properties.Parent = Me
                m_Properties.Application = Me.Application

            End If
            Properties = m_Properties
        End Get
    End Property

    ' let
    'Parameters:
    '[IN]   newValue , тип параметра: String  - ...
    'See Also:
    '  Application
    '  ControlData
    '  ControlIndex
    '  Parent
    '  PROGID
    '  Properties
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
    '  ControlData
    '  ControlIndex
    '  Parent
    '  PROGID
    '  Properties
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
    '[IN]   newValue , тип параметра: Long  - ...
    'See Also:
    '  Application
    '  ControlData
    '  Name
    '  Parent
    '  PROGID
    '  Properties
    '  XMLLoad
    '  XMLSave
    'Example:
    ' dim value as Variant
    ' value = <значение>
    ' me.ControlIndex = value

    'Parameters:
    ' параметров нет
    'Returns:
    '  значение типа Long
    'See Also:
    '  Application
    '  ControlData
    '  Name
    '  Parent
    '  PROGID
    '  Properties
    '  XMLLoad
    '  XMLSave
    'Example:
    ' dim variable as Long
    ' variable = me.ControlIndex
    Public Property ControlIndex() As Integer
        Get
            'LoadFromCash
            'AccessDate = Now

            ControlIndex = m_ControlIndex
        End Get
        Set(ByVal Value As Integer)
            'LoadFromCash
            ''AccessDate = Now: KeepInMemory = True

            m_ControlIndex = Value
        End Set
    End Property

    ' let
    'Parameters:
    '[IN]   newValue , тип параметра: String  - ...
    'See Also:
    '  Application
    '  ControlData
    '  ControlIndex
    '  Name
    '  Parent
    '  Properties
    '  XMLLoad
    '  XMLSave
    'Example:
    ' dim value as Variant
    ' value = <значение>
    ' me.PROGID = value

    'Parameters:
    ' параметров нет
    'Returns:
    '  значение типа String
    'See Also:
    '  Application
    '  ControlData
    '  ControlIndex
    '  Name
    '  Parent
    '  Properties
    '  XMLLoad
    '  XMLSave
    'Example:
    ' dim variable as String
    ' variable = me.PROGID
    Public Property PROGID() As String
        Get
            'LoadFromCash
            'AccessDate = Now

            PROGID = m_PROGID
        End Get
        Set(ByVal Value As String)
            'LoadFromCash
            ''AccessDate = Now: KeepInMemory = True

            m_PROGID = Value
        End Set
    End Property

    Private Sub CloseParents()
        'UPGRADE_NOTE: Object m_Application may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        m_Application = Nothing
        'UPGRADE_NOTE: Object m_Parent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
        m_Parent = Nothing
    End Sub





    Friend Sub CloseClass()

        If Not m_ControlData Is Nothing Then
            m_ControlData.CloseClass()
            'UPGRADE_NOTE: Object m_ControlData may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
            m_ControlData = Nothing
        End If
        If Not m_Properties Is Nothing Then
            m_Properties.CloseClass()
            'UPGRADE_NOTE: Object m_Properties may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
            m_Properties = Nothing
        End If
        CloseParents()
    End Sub

    'Parameters:
    '[IN][OUT]  node , тип параметра: IXMLDOMElement,
    '[IN][OUT]   xdom , тип параметра: DOMDocument  - ...
    'See Also:
    '  Application
    '  ControlData
    '  ControlIndex
    '  Name
    '  Parent
    '  PROGID
    '  Properties
    '  XMLLoad
    'Example:
    '  call me.XMLSave(<параметры>)
    Public Sub XMLSave(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
        On Error Resume Next
        Dim e_ As System.Xml.XmlElement
        'LoadFromCash

        node.setAttribute("Name", Name)
        node.setAttribute("ControlIndex", ControlIndex)
        node.setAttribute("PROGID", PROGID)
        Properties.XMLSave(node, xdom)
        ControlData.XMLSave(node, xdom)
    End Sub

    'Parameters:
    '[IN][OUT]  node , тип параметра: IXMLDOMNode  - ...
    'See Also:
    '  Application
    '  ControlData
    '  ControlIndex
    '  Name
    '  Parent
    '  PROGID
    '  Properties
    '  XMLSave
    'Example:
    '  call me.XMLLoad(<параметры>)
    Public Sub XMLLoad(ByRef node As System.Xml.XmlNode)
        On Error Resume Next
        Dim e_list As System.Xml.XmlNodeList
        Dim e_ As System.Xml.XmlNode

        Name = Replace(node.attributes.getNamedItem("Name").Value, vbLf, vbCrLf)
        'UPGRADE_WARNING: Couldn't resolve default property of object node.Attributes.getNamedItem().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        ControlIndex = node.attributes.getNamedItem("ControlIndex").Value
        PROGID = Replace(node.attributes.getNamedItem("PROGID").Value, vbLf, vbCrLf)

        e_list = node.selectNodes("Properties")
        Properties.XMLLoad(e_list)
        e_list = node.selectNodes("ControlData")
        ControlData.XMLLoad(e_list)
    End Sub
End Class