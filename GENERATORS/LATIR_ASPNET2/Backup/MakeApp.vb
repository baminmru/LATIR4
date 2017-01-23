Option Strict Off
Option Explicit On
Module MakeApp
	
    Public Sub MakeParents(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response)
        Dim s As String
        s = "<%@ Control Language=""c#"" AutoEventWireup=""false"" Codebehind=""ucParent.ascx.cs"" Inherits=""" & ot.name & ".ASPNET.ucParent"" TargetSchema=""http://schemas.microsoft.com/intellisense/ie5""%>"
        SetExt(o, "ucParent.ASCX", "")
        o.Block = "code"
        o.OutNL(s)

        s = ""
        's = s & vbCrLf & "  namespace " & ot.name & ".ASPNET"
        s = s & vbCrLf & "  namespace Mokasin.ASPNET"
        s = s & vbCrLf & "{"
        s = s & vbCrLf & "  using System;"
        s = s & vbCrLf & "  using System.Data;"
        s = s & vbCrLf & "  using System.Collections;"
        s = s & vbCrLf & "  using System.Drawing;"
        s = s & vbCrLf & "  using System.Web;"
        s = s & vbCrLf & "  using System.Web.UI.WebControls;"
        s = s & vbCrLf & "  using System.Web.UI.HtmlControls;"
        s = s & vbCrLf & "  using MKSNManager.MKSN;"
        s = s & vbCrLf & "  using MKSN.Web.UI.Common;"

        s = s & vbCrLf
        s = s & vbCrLf & "  public class InfoEventArgs: EventArgs"
        s = s & vbCrLf & "  {"
        s = s & vbCrLf & "    public InfoEventArgs(string Message, System.Drawing.Color Color)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      this.message = Message;"
        s = s & vbCrLf & "      this.color = Color;"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf & "    public string message;"
        s = s & vbCrLf & "    public System.Drawing.Color color;"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "  public class ucParent  : System.Web.UI.UserControl "
        s = s & vbCrLf & "  {"
        s = s & vbCrLf & "    // Общая часть"
        s = s & vbCrLf & "    // Параметры страницы"
        s = s & vbCrLf & "    protected string Mode = ""Short"";"
        s = s & vbCrLf & "    protected string Print = ""No"";"
        s = s & vbCrLf & "    protected string ContentID = string.Empty;"
        s = s & vbCrLf & "    protected string Feature = string.Empty;"
        s = s & vbCrLf & "    protected string BackUrl = string.Empty;"
        s = s & vbCrLf & "    public System.Web.UI.StateBag ParentViewState;"
        s = s & vbCrLf & "    // Режимы работы контрола"
        s = s & vbCrLf & "    public bool AllowEdit = false;"
        s = s & vbCrLf & "    public bool AllowAddNew = false;"
        s = s & vbCrLf & "    public bool AddNew = false;"
        s = s & vbCrLf & "    // Менеджер работы с данными"
        s = s & vbCrLf & "    public MKSNManager.MKSN.Manager MKSNManager = null;"
        s = s & vbCrLf & "    // Плоская часть"
        s = s & vbCrLf & "    private MKSNManager.Document.DocRow_Base  rowItem = null;"
        s = s & vbCrLf & "    //public ArrayList DenyVisible = new ArrayList();"
        s = s & vbCrLf & "    //public ArrayList DenyEdit = new ArrayList();"
        s = s & vbCrLf & "    // Для таблиц"
        s = s & vbCrLf & "    //public string DataTextFormatString = string.Empty;"
        s = s & vbCrLf & "    //public string DataTextField = string.Empty;"
        s = s & vbCrLf & "    //public string DataNavigateUrlField = string.Empty;"
        s = s & vbCrLf & "    //public string IDField = ""ID"";"
        s = s & vbCrLf & "    //public string EditPageURL = string.Empty;"
        s = s & vbCrLf & "    public string Filter = string.Empty;"
        s = s & vbCrLf & "    public string Sorting = string.Empty;"
        s = s & vbCrLf & "    public string PageNum  = string.Empty;"
        s = s & vbCrLf & "    public bool AllowDelete = false;"

        s = s & vbCrLf & "    //public string AllowEditField = string.Empty;"
        s = s & vbCrLf & "    //public ArrayList AllowEditFieldValues = new ArrayList();"

        s = s & vbCrLf & "    //public bool AddStatusColumn;"
        s = s & vbCrLf & "    //public string  SelectIDParameterName  = ""ContentID"";"
        s = s & vbCrLf & "    public DataTable DataTable = null;"
        s = s & vbCrLf & "    public DataView DataView = null;"
        s = s & vbCrLf & "    private MKSNManager.Document.DocCollection_Base dataSource = null;"
        s = s & vbCrLf & "    public DataComponent DataComponent = null;"
        s = s & vbCrLf & "    public PortalPage EditPage = null;"
        s = s & vbCrLf & "    // События для плоской части"
        s = s & vbCrLf & "    public virtual event System.EventHandler OnFieldInit;"
        s = s & vbCrLf & "    public virtual event System.EventHandler OnBeforeSave;"
        s = s & vbCrLf & "    public virtual event System.EventHandler OnAfterSave;"
        s = s & vbCrLf & "    public virtual event System.EventHandler OnCancel;"

        s = s & vbCrLf & "    public delegate void InfoEventHandler(object sender, InfoEventArgs e);"
        s = s & vbCrLf & "    public virtual event InfoEventHandler OnInfo;"

        s = s & vbCrLf
        s = s & vbCrLf & "    public virtual string CancelButtonID"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "     get"
        s = s & vbCrLf & "     {"
        s = s & vbCrLf & "        return string.Empty;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    public virtual string SaveButtonID"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "     get"
        s = s & vbCrLf & "     {"
        s = s & vbCrLf & "      return string.Empty;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    public MKSNManager.Document.DocCollection_Base MKSNDataSource"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      get"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        return dataSource;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "      set"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        dataSource = value;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    public virtual MKSNManager.Document.DocRow_Base MKSNRowItem"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      get"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        return rowItem;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "      set"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        rowItem = value;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    private void Page_Load(object sender, System.EventArgs e)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      Mode = Parameter(""mode"");"
        s = s & vbCrLf & "      Print = Parameter(""Print"");"
        s = s & vbCrLf & "      ContentID  = Parameter(""ID"");"
        s = s & vbCrLf & "      Feature = Parameter(""Feature"");"
        s = s & vbCrLf & "      BackUrl = Server.UrlDecode(Parameter(""BackUrl""));"
        s = s & vbCrLf & "      AddNew = Mode.IndexOf(""addnew"") > -1;"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    public static void AddParameter(ref string URL, string Key, string Value)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      if ((URL.IndexOf(""?"" + Key + ""="") == -1) && (URL.IndexOf(""&"" + Key + ""="") == -1) )"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        if (URL.IndexOf(""?"") == -1)"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          URL = URL + ""?"" + Key + ""="" + Value;"
        s = s & vbCrLf & "          return;"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "        else"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          URL = URL + ""&"" + Key + ""="" + Value;"
        s = s & vbCrLf & "          return;"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "      string URLEnd = string.Empty;"
        s = s & vbCrLf & "      string URLBegin = string.Empty;"
        s = s & vbCrLf & "      int ValueStartIdx = -1;"
        s = s & vbCrLf & "      int StartIdx = URL.IndexOf(""?"" + Key + ""="");"
        s = s & vbCrLf & "      if (StartIdx  == -1)"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        StartIdx = URL.IndexOf(""&"" + Key + ""="");"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "      if (StartIdx > -1)"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        ValueStartIdx =  StartIdx  + Key.Length + 2;"
        s = s & vbCrLf & "        URLEnd = URL.Substring(ValueStartIdx);"
        s = s & vbCrLf & "        URLBegin = URL.Substring(0, ValueStartIdx);"
        s = s & vbCrLf & "        if (URLEnd.IndexOf(""&"") > -1)"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          URLEnd =  URLEnd.Substring(URLEnd.IndexOf(""&""));"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "        else"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          URLEnd = string.Empty;"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "      URL = URLBegin + Value + URLEnd;"
        s = s & vbCrLf & "    }"

        s = s & vbCrLf & "    public string Parameter(string Key)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      if (Request[Key] != null)"
        s = s & vbCrLf & "        return Request[Key].ToString();"
        s = s & vbCrLf & "      return string.Empty;"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    #region Web Form Designer generated code"
        s = s & vbCrLf & "    override protected void OnInit(EventArgs e)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      base.OnInit(e);"
        s = s & vbCrLf & "      InitializeComponent();"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    public static string GetDatePickerScript()"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "    string Result;"
        s = s & vbCrLf & "    Result = ""<iframe id=\""CalFrame\"" style=\""DISPLAY: none; Z-INDEX: 100; WIDTH: 148px; POSITION: absolute; HEIGHT: 151px\"""";"
        s = s & vbCrLf & "    Result += "" marginWidth=\""0\"" marginHeight=\""0\"" src=\""Include/calendar/datepick.htm\"" frameBorder=\""0\"""";"
        s = s & vbCrLf & "    Result += ""noResize scrolling=\""no\""></iframe>\n"";"
        s = s & vbCrLf & "    Result += ""<script language=\""javascript\"">\n"";"
        s = s & vbCrLf & "    Result += ""function ShowCalendar(strImg,strEdit,strChanged)\n"";"
        s = s & vbCrLf & "    Result += ""{\n"";"
        s = s & vbCrLf & "    Result += ""o=document.all;\n"";"
        s = s & vbCrLf & "    Result += ""var oImg = o[strImg];\n"";"
        s = s & vbCrLf & "    Result += ""var oEdit = o[strEdit];\n"";"
        s = s & vbCrLf & "    Result += ""var oChanged = o[strChanged];\n"";"
        s = s & vbCrLf & "    Result += ""window.frames.CalFrame.SetTheDate( oEdit, oChanged);\n"";"
        s = s & vbCrLf & "    Result += ""var eL=0;\n"";"
        s = s & vbCrLf & "    Result += ""var eT=0;\n"";"
        s = s & vbCrLf & "    Result += ""for(var p=oImg; p&&p.tagName!=\""DIV\""; p=p.offsetParent){\n"";"
        s = s & vbCrLf & "    Result += ""var calendarWidth=146\n"";"
        s = s & vbCrLf & "    Result += ""eL+=p.offsetLeft;\n"";"
        s = s & vbCrLf & "    Result += ""eT+=p.offsetTop;\n"";"
        s = s & vbCrLf & "    Result += ""if((eL +\n"";"
        s = s & vbCrLf & "    Result += ""calendarWidth)>(document.body.offsetLeft+document.body.offsetWidth))\n"";"
        s = s & vbCrLf & "    Result += ""eL+=p.offsetLeft-((eL + calendarWidth + 2)-(document.body.offsetLeft+document.body.offsetWidth));\n"";"
        s = s & vbCrLf & "    Result += ""}\n"";"
        s = s & vbCrLf & "    Result += ""var dF = document.all.CalFrame;\n"";"
        s = s & vbCrLf & "    Result += ""var eH=oImg.offsetHeight+5;\n"";"
        s = s & vbCrLf & "    Result += ""var dH=dF.style.pixelHeight;\n"";"
        s = s & vbCrLf & "    Result += ""var sT=document.body.scrollTop;\n"";"
        s = s & vbCrLf & "    Result += ""dF.style.left=eL;\n"";"
        s = s & vbCrLf & "    Result += ""if(eT-dH >= sT && eT+eH+dH > document.body.clientHeight+sT)\n"";"
        s = s & vbCrLf & "    Result += ""dF.style.top=eT-dH;\n"";"
        s = s & vbCrLf & "    Result += ""else\n"";"
        s = s & vbCrLf & "    Result += ""dF.style.top=eT+eH;\n"";"
        s = s & vbCrLf & "    Result += ""document.all.CalFrame.style.display = \""block\""; }\n"";"
        s = s & vbCrLf & "    Result += ""</script>\n"";"
        s = s & vbCrLf & "    return Result;"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf & "    private void InitializeComponent()"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      this.Load += new System.EventHandler(this.Page_Load);"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf & "    #endregion"
        s = s & vbCrLf & "  }"
        s = s & vbCrLf & "}"

        SetExt(o, "ucParent.ASCX.cs", "")
        o.Block = "code"
        o.OutNL(s)
    End Sub
	
    Public Sub MakeApps(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response)
        Dim s As String

        's = s & vbCrLf & "Option Explicit On"
        's = s & vbCrLf & ""
        's = s & vbCrLf & "Imports System.xml"
        's = s & vbCrLf & "Imports MKSNManager"
        's = s & vbCrLf & ""
        's = s & vbCrLf & "Namespace " & ot.name
        's = s & vbCrLf & ""
        's = s & vbCrLf & MakeEnums(m)
        's = s & vbCrLf & ""
        's = s & vbCrLf & "    Public Class Application"
        's = s & vbCrLf & "        Inherits MKSNManager.Document.Doc_Base"
        's = s & vbCrLf & ""
        '
        '
        's = s & vbCrLf & ""
        's = s & vbCrLf & "        Protected Overrides Function MyTypeName() As String"
        's = s & vbCrLf & "            MyTypeName = """ & ot.name & """"
        's = s & vbCrLf & "        End Function"
        's = s & vbCrLf & ""
        '
        '
        '
        'For i = 1 To ot.PART.Count
        'n1 = ot.PART.Item(i).name
        's = s & vbCrLf & "  Private m_" & n1 & " As " & n1 & "_col"
        '
        's = s & vbCrLf & "        Public ReadOnly Property " & n1 & "() As " & n1 & "_col"
        's = s & vbCrLf & "            Get"
        's = s & vbCrLf & "                If m_" & n1 & " Is Nothing Then"
        's = s & vbCrLf & "                    m_" & n1 & " = New " & n1 & "_col"
        's = s & vbCrLf & "                    m_" & n1 & ".Application = Me"
        's = s & vbCrLf & "                    m_" & n1 & ".Parent = Me"
        's = s & vbCrLf & "                    m_" & n1 & ".Refresh()"
        's = s & vbCrLf & "                End If"
        's = s & vbCrLf & "                " & n1 & " = m_" & n1 & ""
        's = s & vbCrLf & "            End Get"
        's = s & vbCrLf & "        End Property"
        '
        'Next
        '
        's = s & vbCrLf & ""
        's = s & vbCrLf & "        Public Overrides Sub Dispose()"
        '
        'For i = 1 To ot.PART.Count
        '  n1 = ot.PART.Item(i).name
        '  s = s & vbCrLf & "            " & n1 & ".Dispose()"
        'Next
        's = s & vbCrLf & "        End Sub"
        's = s & vbCrLf & ""
        '
        's = s & vbCrLf & "        Protected Overrides Function FindInCollections(ByVal Table As String, ByVal InstID As String) As MKSNManager.Document.DocRow_Base"
        's = s & vbCrLf & "            dim mFindInCollections As MKSNManager.Document.DocRow_Base"
        'For i = 1 To ot.PART.Count
        '  n1 = ot.PART.Item(i).name
        '  s = s & vbCrLf & "            mFindInCollections = " & n1 & ".FindObject(Table, InstID)"
        '  s = s & vbCrLf & "            if not mFindInCollections is nothing then return mFindInCollections"
        'Next
        '
        's = s & vbCrLf & "        End Function"
        '
        '
        's = s & vbCrLf & ""
        's = s & vbCrLf & "        Protected Overrides Sub XMLLoadCollections(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)"
        's = s & vbCrLf & "            Dim e_list As XmlNodeList"
        's = s & vbCrLf & "            On Error Resume Next"
        'For i = 1 To ot.PART.Count
        '  n1 = ot.PART.Item(i).name
        '
        's = s & vbCrLf & "            e_list = node.SelectNodes(""" & UCase(n1) & "_COL"")"
        's = s & vbCrLf & "            " & n1 & ".XMLLoad(e_list, LoadMode)"
        'Next
        's = s & vbCrLf & "        End Sub"
        's = s & vbCrLf & ""
        's = s & vbCrLf & "        Public Overrides Sub XMLSaveCollections(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)"
        'For i = 1 To ot.PART.Count
        '  n1 = ot.PART.Item(i).name
        '
        's = s & vbCrLf & "            " & n1 & ".XMLSave(node, Xdom)"
        'Next
        's = s & vbCrLf & "        End Sub"
        '
        '
        '
        '
        's = s & vbCrLf & "Public Overrides Sub BatchUpdate()"
        's = s & vbCrLf & "  If Not Application.WorkOffline Then"
        '
        'For i = 1 To ot.PART.Count
        '  s = s & vbCrLf & "    " & ot.PART.Item(i).name & ".BatchUpdate"
        'Next
        '
        's = s & vbCrLf & "  End If"
        's = s & vbCrLf & "End Sub"
        '
        '
        's = s & vbCrLf & "    End Class"
        's = s & vbCrLf & "End Namespace"
        s = "//todo"""
        SetExt(o, "Application", "cs")

        o.Block = "code"
        o.OutNL(s)

    End Sub
	
	
    Public Function MakeEnums(ByRef m As MTZMetaModel.MTZMetaModel.Application) As String
        Dim i, j As Integer
        Dim s As String = String.Empty

        For i = 1 To m.FIELDTYPE.Count
            With m.FIELDTYPE.Item(i)
                If .TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                    s = s & vbCrLf & "public enum enum" & MakeValidName(.Name) & "'" & NoLF(.the_Comment)
                    For j = 1 To .ENUMITEM.Count
                        s = s & vbCrLf & "  " & MakeValidName(.Name) & "_" & MakeValidName(.ENUMITEM.Item(j).Name) & "=" & .ENUMITEM.Item(j).NameValue & "'" & .ENUMITEM.Item(j).Name
                    Next
                    s = s & vbCrLf & "end enum "
                End If
            End With
        Next

        MakeEnums = s

    End Function
End Module