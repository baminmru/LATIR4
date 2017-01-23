Option Strict Off
Option Explicit On
Module MakeRowProc
	
    Public Sub MakeRow(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef o As LATIRGenerator.Response)
        Dim s As String
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim p1 As MTZMetaModel.MTZMetaModel.PART
        Dim n1 As String
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim tt As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        tt = TypeForStruct(p)

        s = "<%@ Control Language=""c#"" AutoEventWireup=""false"" Codebehind=""uc" & p.name & ".ascx.cs"" Inherits=""" & tt.name & ".ASPNET.uc" & p.name & """ TargetSchema=""http://schemas.microsoft.com/intellisense/ie5""%>"
        s = s & vbCrLf & "<TABLE id=""Table1"" cellSpacing=""0"" cellPadding=""1"" width=""100%"" border=""0"">"

        Dim ctlName As String
        p.FIELD.Sort = "sequence"


        s = s & vbCrLf & "  <TR>"
        s = s & vbCrLf & "  <TD colspan=3 align=center>"
        s = s & vbCrLf & "        <asp:Label id=""" & p.name & "LabelInfo"" runat=""server""></asp:Label>"
        s = s & vbCrLf & "  </TD>"
        s = s & vbCrLf & "  </TR>"
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FIELDTYPE
            s = s & vbCrLf & "  <TR>"
            s = s & vbCrLf & "      <TD width=20%>"
            s = s & vbCrLf & "        <asp:Label id=""lbl" & f.name & """ runat=""server"" Width=""100%"" ForeColor=""#000000"">" & f.Caption & ":</asp:Label>"
            s = s & vbCrLf & "      </TD>"
            s = s & vbCrLf & "      <TD width=40%>"
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                ctlName = "cmb" & f.Name
                s = s & vbCrLf & "<asp:DropDownList id=""cmb" & f.Name & """ runat=""server"" Width=""100%""></asp:DropDownList>"
            ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                ctlName = "cmb" & f.Name
                s = s & vbCrLf & "<asp:DropDownList id=""cmb" & f.Name & """ runat=""server"" Width=""100%""></asp:DropDownList>"
            Else
                If MapFT(m, ft.ID.ToString(), tid) = "DATE" Then
                    s = s & vbCrLf & "<input id=""changedDate" & f.Name & """ type=""hidden"" value=0 name=""changedDate" & f.Name & """ runat=""server"">"
                    s = s & vbCrLf & "<asp:textbox id=""Date" & f.Name & """ runat=""server"" Width=""70px""></asp:textbox>"
                    s = s & vbCrLf & "<A id='btn" & f.Name & "' alt=""Календарь"" href=""javascript:ShowCalendar('DateEdBtn" & f.Name & "','<%=this.Date" & f.Name & ".ClientID%>','<%=this.changedDate" & f.Name & ".ClientID.ToString()%>')"" >"
                    s = s & vbCrLf & "<img id=DateEdBtn" & f.Name & " height=14  src=""<%=Request.ApplicationPath%>/Include/Calendar/calendar.gif""  width=23 border=0></A>"
                    ctlName = "Date" & f.Name
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "DATETIME" Then
                    s = s & vbCrLf & "<input id=""changedDate" & f.Name & """ type=""hidden"" value=0 name=""changedDate" & f.Name & """ runat=""server"">"
                    s = s & vbCrLf & "<asp:textbox id=""Date" & f.Name & """ runat=""server"" Width=""70px""></asp:textbox>"
                    s = s & vbCrLf & "<A id='btn" & f.Name & "' alt=""Календарь"" href=""javascript:ShowCalendar('DateEdBtn" & f.Name & "','<%=this.Date" & f.Name & ".ClientID%>','<%=this.changedDate" & f.Name & ".ClientID.ToString()%>')"" >"
                    s = s & vbCrLf & "<img id=DateEdBtn" & f.Name & " height=14  src=""<%=Request.ApplicationPath%>/Include/Calendar/calendar.gif""  width=23 border=0></A>"
                    s = s & vbCrLf & "<asp:textbox id=""Time" & f.Name & """ runat=""server"" Width=""50px""></asp:textbox>"
                    ctlName = "Date" & f.Name
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "TIME" Then
                    ctlName = "Time" & f.Name
                    s = s & vbCrLf & "<asp:textbox id=""Time" & f.Name & """ runat=""server"" Width=""50px""></asp:textbox>"
                Else
                    ctlName = "txt" & f.Name
                    s = s & vbCrLf & "          <asp:TextBox id=""txt" & f.Name & """ runat=""server"" Width=""100%"""
                    s = s & " MaxLength=""" & GetFieldSize(f, tid) & """"
                    s = s & " Text="""">"
                    s = s & "</asp:TextBox>"
                End If
            End If
            s = s & vbCrLf & "      </TD>"
            ' место для валидатора
            s = s & vbCrLf & "      <TD width=40%>"
            If f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                s = s & vbCrLf & "          <asp:RequiredFieldValidator id=""rfv" & f.Name & """ runat=""server"" ErrorMessage=""Заполните поле"" ControlToValidate=""" & ctlName & """></asp:RequiredFieldValidator>"
            End If
            s = s & vbCrLf & "      </TD>"
            s = s & vbCrLf & "    </TR>"
        Next
        s = s & vbCrLf & "  <TR>"
        s = s & vbCrLf & "      <TD>"
        s = s & vbCrLf & "      </TD>"
        s = s & vbCrLf & "      <TD align=""right"">"
        s = s & vbCrLf & "        <asp:Button id=""btnSave"" runat=""server"" Text=""Сохранить"" Width=""88px""></asp:Button>"
        s = s & vbCrLf & "        <asp:Button id=""btnCancel"" runat=""server"" Text=""Отмена"" Width=""88px"" CausesValidation=""false""></asp:Button>&nbsp;"
        s = s & vbCrLf & "      </TD>"
        s = s & vbCrLf & "      <TD></TD>"
        s = s & vbCrLf & "   </TR>"
        s = s & vbCrLf & "</TABLE>"
        s = s & vbCrLf & "<script language=""javascript"" type=""text/javascript"">" & vbCrLf
        s = s & vbCrLf & "function " & p.name & "Load()" & vbCrLf
        s = s & vbCrLf & "{" & vbCrLf
        s = s & vbCrLf & "    <%=GetOnLoadScript()%>" & vbCrLf
        s = s & vbCrLf & "}" & vbCrLf
        s = s & vbCrLf & "function ElementShow(elName)" & vbCrLf
        s = s & vbCrLf & "{" & vbCrLf
        s = s & vbCrLf & " var el;" & vbCrLf
        s = s & vbCrLf & " el = document.getElementById(elName);" & vbCrLf
        s = s & vbCrLf & " if (el != null)" & vbCrLf
        s = s & vbCrLf & " {" & vbCrLf
        s = s & vbCrLf & "   el.style.display = '';" & vbCrLf
        s = s & vbCrLf & " }" & vbCrLf
        s = s & vbCrLf & "}" & vbCrLf
        s = s & vbCrLf & "function ElementHide(elName)" & vbCrLf
        s = s & vbCrLf & "{" & vbCrLf
        s = s & vbCrLf & " var el;" & vbCrLf
        s = s & vbCrLf & " el = document.getElementById(elName);" & vbCrLf
        s = s & vbCrLf & " if (el != null)" & vbCrLf
        s = s & vbCrLf & " {" & vbCrLf
        s = s & vbCrLf & "   el.style.display = 'none';" & vbCrLf
        s = s & vbCrLf & " }" & vbCrLf
        s = s & vbCrLf & "}" & vbCrLf
        s = s & vbCrLf & "</script>" & vbCrLf
        SetExt(o, "uc" & p.name & ".ASCX", "")
        o.Block = "code"
        o.OutNL(s)
        s = ""
        s = s & vbCrLf & ""
        s = s & vbCrLf & "namespace " & tt.name & ".ASPNET"
        s = s & vbCrLf & "{"
        s = s & vbCrLf & "  using System;"
        s = s & vbCrLf & "  using System.Data;"
        s = s & vbCrLf & "  using System.IO;"
        s = s & vbCrLf & "  using System.Collections;"
        s = s & vbCrLf & "  using System.Drawing;"
        s = s & vbCrLf & "  using System.Web;"
        s = s & vbCrLf & "  using System.Web.UI.WebControls;"
        s = s & vbCrLf & "  using System.Web.UI.HtmlControls;"
        s = s & vbCrLf & "  using System.Globalization;"
        s = s & vbCrLf & "  using Mokasin.ASPNET;"
        s = s & vbCrLf & "  using " & tt.name & ";"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "  /// <summary>"
        s = s & vbCrLf & "  ///    uc" & p.name & " - форма редактирования раздела " & p.Caption
        s = s & vbCrLf & "  /// </summary>"
        s = s & vbCrLf & "  public class uc" & p.name & "  : ucParent "
        s = s & vbCrLf & "  {"
        s = s & vbCrLf & "    protected System.Web.UI.WebControls.Label " & p.name & "LabelInfo;"
        s = s & vbCrLf & "    protected System.Web.UI.WebControls.Button btnSave;"
        s = s & vbCrLf & "    protected System.Web.UI.WebControls.Button btnCancel;"
        s = s & vbCrLf & "    protected ArrayList ControlsToHide = new ArrayList();"

        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FIELDTYPE
            s = s & vbCrLf & "    protected System.Web.UI.WebControls.Label lbl" & f.name & ";"
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                ctlName = "cmb" & f.Name
                s = s & vbCrLf & "    protected System.Web.UI.WebControls.DropDownList " & ctlName & ";"
            ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                ctlName = "cmb" & f.Name
                s = s & vbCrLf & "    protected System.Web.UI.WebControls.DropDownList " & ctlName & ";"
            Else
                If MapFT(m, ft.ID.ToString(), tid) = "DATE" Then
                    s = s & vbCrLf & "    protected System.Web.UI.HtmlControls.HtmlInputHidden changedDate" & f.Name & ";"
                    s = s & vbCrLf & "    protected System.Web.UI.WebControls.TextBox Date" & f.Name & ";"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "DATETIME" Then
                    s = s & vbCrLf & "    protected System.Web.UI.HtmlControls.HtmlInputHidden changedDate" & f.Name & ";"
                    s = s & vbCrLf & "    protected System.Web.UI.WebControls.TextBox Date" & f.Name & ";"
                    s = s & vbCrLf & "    protected System.Web.UI.WebControls.TextBox Time" & f.Name & ";"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "TIME" Then
                    s = s & vbCrLf & "    protected System.Web.UI.WebControls.TextBox Time" & f.Name & ";"
                Else
                    ctlName = "txt" & f.Name
                    s = s & vbCrLf & "    protected System.Web.UI.WebControls.TextBox " & ctlName & ";"
                End If
            End If
            If f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                s = s & vbCrLf & "    protected System.Web.UI.WebControls.RequiredFieldValidator rfv" & f.Name & ";"
            End If
        Next


        s = s & vbCrLf & "    public override event System.EventHandler OnFieldInit;"
        s = s & vbCrLf & "    public override event System.EventHandler OnBeforeSave;"
        s = s & vbCrLf & "    public override event System.EventHandler OnAfterSave;"
        s = s & vbCrLf & "    public override event System.EventHandler OnCancel;"
        s = s & vbCrLf & "    public override event InfoEventHandler OnInfo;"
        s = s & vbCrLf
        s = s & vbCrLf & "    public override string CancelButtonID"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      get"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        return btnCancel.ClientID;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    public override string SaveButtonID"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      get"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        return btnSave.ClientID;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    public " & ot.Name & "." & p.name & " RowItem"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      get"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        return (" & ot.Name & "." & p.name & ")base.MKSNRowItem;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    private bool ReadOnly"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      get"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        return !AllowEdit;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    private void Page_Unload(object sender, System.EventArgs e)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      return;"
        '  s = s & vbCrLf & "      if (ParentViewState == null) return;"
        '
        '  For i = 1 To p.FIELD.Count
        '    Set f = p.FIELD.Item(i)
        '    Set ft = f.FIELDTYPE
        '
        '
        '    If ft.TypeStyle = TypeStyle_Ssilka Then
        '      ctlName = "cmb" & f.name
        '      s = s & vbCrLf & "      if (" & ctlName & ".SelectedValue.ToString() != string.Empty)"
        '      s = s & vbCrLf & "      {"
        '      If f.ReferenceType = ReferenceType_Na_stroku_razdela Then
        '        s = s & vbCrLf & "        ParentViewState.Add(ClientID + """ & f.name & """, " & ctlName & ".SelectedValue.ToString());"
        '      Else
        '        s = s & vbCrLf & "        ParentViewState.Add(ClientID + """ & f.name & """, " & ctlName & ".SelectedValue.ToString());"
        '      End If
        '      s = s & vbCrLf & "      }"
        '    ElseIf ft.TypeStyle = TypeStyle_Perecislenie Then
        '      ctlName = "cmb" & f.name
        '      s = s & vbCrLf & "        ParentViewState.Add(ClientID + """ & f.name & """, " & ctlName & ".SelectedValue);"
        '    Else
        '      ctlName = "txt" & f.name
        '      If MapFT(m, ft.ID, tid) = "DATE" Then
        '        s = s & vbCrLf & "       try"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "         if (Date" & f.name & ".Text != string.Empty)"
        '        s = s & vbCrLf & "         {"
        '        s = s & vbCrLf & "              ParentViewState.Add(ClientID + """ & f.name & """, Convert.ToDateTime(Date" & f.name & ".Text));"
        '        s = s & vbCrLf & "         }"
        '        s = s & vbCrLf & "         else "
        '        s = s & vbCrLf & "         {"
        '        s = s & vbCrLf & "              ParentViewState.Add(ClientID + """ & f.name & """, DateTime.MinValue);"
        '        s = s & vbCrLf & "         }"
        '        s = s & vbCrLf & "       }"
        '        s = s & vbCrLf & "       catch"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "       }"
        '      ElseIf MapFT(m, ft.ID, tid) = "DATETIME" Then
        '        s = s & vbCrLf & "       try"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "         if (Date" & f.name & ".Text != string.Empty)"
        '        s = s & vbCrLf & "         {"
        '        s = s & vbCrLf & "            DateTime newValue;"
        '        s = s & vbCrLf & "            newValue = Convert.ToDateTime(Date" & f.name & ".Text + "" "" +  Time" & f.name & ".Text);"
        '        s = s & vbCrLf & "            ParentViewState.Add(ClientID + """ & f.name & """, newValue);"
        '        s = s & vbCrLf & "         }"
        '        s = s & vbCrLf & "         else "
        '        s = s & vbCrLf & "         {"
        '        s = s & vbCrLf & "              ParentViewState.Add(ClientID + """ & f.name & """, DateTime.MinValue);"
        '        s = s & vbCrLf & "         }"
        '        s = s & vbCrLf & "       }"
        '        s = s & vbCrLf & "       catch"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "       }"
        '      ElseIf MapFT(m, ft.ID, tid) = "TIME" Then
        '        ctlName = "Time" & f.name
        '        s = s & vbCrLf & "       try"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "         if (" & ctlName & ".Text != string.Empty)"
        '        s = s & vbCrLf & "         {"
        '        s = s & vbCrLf & "              ParentViewState.Add(ClientID + """ & f.name & """, Convert.ToDateTime(" & ctlName & ".Text));"
        '        s = s & vbCrLf & "         }"
        '        s = s & vbCrLf & "         else "
        '        s = s & vbCrLf & "         {"
        '        s = s & vbCrLf & "              ParentViewState.Add(ClientID + """ & f.name & """, DateTime.MinValue);"
        '        s = s & vbCrLf & "         }"
        '        s = s & vbCrLf & "       }"
        '        s = s & vbCrLf & "       catch"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "         " & p.name & "LabelInfo.Text = ""Введите правильное время в поле " & f.Caption & " (например 12:00)"";"
        '        s = s & vbCrLf & "         return;"
        '        s = s & vbCrLf & "       }"
        '      ElseIf MapFT(m, ft.ID, tid) = "INTEGER" Then
        '        s = s & vbCrLf & "       try"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "          ParentViewState.Add(ClientID + """ & f.name & """, Convert.ToInt32( " & ctlName & ".Text));"
        '        s = s & vbCrLf & "       }"
        '        s = s & vbCrLf & "       catch"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "       }"
        '      ElseIf MapFT(m, ft.ID, tid) = "NUMERIC" Then
        '        s = s & vbCrLf & "       try"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "          ParentViewState.Add(ClientID + """ & f.name & """, Convert.ToDouble( " & ctlName & ".Text));"
        '        s = s & vbCrLf & "       }"
        '        s = s & vbCrLf & "       catch"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "       }"
        '      ElseIf MapFT(m, ft.ID, tid) = "GUID" Then
        '        s = s & vbCrLf & "       try"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "          ParentViewState.Add(ClientID + """ & f.name & """, new System.Guid(" & ctlName & ".Text));"
        '        s = s & vbCrLf & "       }"
        '        s = s & vbCrLf & "       catch"
        '        s = s & vbCrLf & "       {"
        '        s = s & vbCrLf & "       }"
        '      Else
        '           s = s & vbCrLf & "       ParentViewState.Add(ClientID + """ & f.name & """," & ctlName & ".Text);"
        '      End If
        '    End If
        '  Next

        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    private void Page_Load(object sender, System.EventArgs e)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      if (RowItem != null)"
        s = s & vbCrLf & "      {"
        Dim DefaultValue As String
        Dim dfilt As Integer
        Dim bFoo As Boolean
        Dim dfilt1 As Integer
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FIELDTYPE
            DefaultValue = GetDefaultValue(f, tid)

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                ctlName = "cmb" & f.Name




                On Error Resume Next
                If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                    p1 = f.RefToPart
                    p1.PARTVIEW.Sort = "sequence"
                    If p1.PARTVIEW.Count = 0 Then
                        s = s & vbCrLf & "          // Для раздела " & p1.Name & " не определена View - используем  сам раздел"
                        s = s & vbCrLf & "          DataTable dt" & f.Name & " = MKSNManager.Session.GetRowsExDT(""" & p1.Name & """, string.Empty, string.Empty, string.Empty, string.Empty);"
                        s = s & vbCrLf & "          if (dt" & f.Name & "!=null) { "
                        s = s & vbCrLf & "            " & ctlName & ".DataSource = dt" & f.Name & ";"
                        s = s & vbCrLf & "            " & ctlName & ".DataTextField = """ & p1.Name & "ID"";"
                        For j = 1 To p1.FIELD.Count
                            If p1.FIELD.Item(j).IsBrief Then
                                s = s & vbCrLf & "            " & ctlName & ".DataTextField = """ & p1.FIELD.Item(j).Name & """;"
                                Exit For
                            End If
                        Next
                        s = s & vbCrLf & "            " & ctlName & ".DataValueField = """ & p1.Name & "ID"";"
                        s = s & vbCrLf & "          }"
                    Else
                        s = s & vbCrLf & "          string Filter" & f.Name & " = string.Empty;"
                        s = s & vbCrLf & "          string DataTextFormatString" & f.Name & " = string.Empty;"
                        If (f.DINAMICFILTERSCRIPT.Count > 0) Then
                            For dfilt = 1 To f.DINAMICFILTERSCRIPT.Count
                                If (Not f.DINAMICFILTERSCRIPT.Item(dfilt).Target Is Nothing) Then
                                    'UPGRADE_WARNING: Couldn't resolve default property of object f.DINAMICFILTERSCRIPT.Item(dfilt).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    If (f.DINAMICFILTERSCRIPT.Item(dfilt).Target.ID.ToString() = tid) Then
                                        s = s & vbCrLf & f.DINAMICFILTERSCRIPT.Item(dfilt).Code
                                    End If
                                End If
                            Next
                        End If
                        s = s & vbCrLf & "          DataTable dt" & f.Name & " = MKSNManager.Session.GetView(""" & p1.PARTVIEW.Item(1).the_Alias & """, Filter" & f.Name & ", """ & p1.PARTVIEW.Item(1).ViewColumn.Item(1).the_Alias & """);"

                        s = s & vbCrLf & "          " & "if  (DataTextFormatString" & f.Name & "  != string.Empty )"
                        s = s & vbCrLf & "          " & "{"
                        s = s & vbCrLf & "          " & "cmb" & f.Name & ".DataSource = ConfigureView(dt" & f.Name & ", DataTextFormatString" & f.Name & ");"
                        s = s & vbCrLf & "          " & ctlName & ".DataTextField = ""text"";"
                        s = s & vbCrLf & "          " & "}"
                        s = s & vbCrLf & "          " & "else"
                        s = s & vbCrLf & "          " & "{"
                        s = s & vbCrLf & "          " & ctlName & ".DataSource = dt" & f.Name & ".DefaultView;"
                        s = s & vbCrLf & "          " & ctlName & ".DataTextField = """ & p1.PARTVIEW.Item(1).ViewColumn.Item(1).the_Alias & """;"
                        s = s & vbCrLf & "          " & "}"

                        For j = 1 To p1.PARTVIEW.Item(1).ViewColumn.Count
                            s = s & vbCrLf & "          //" & ctlName & ".DataTextField = """ & p1.PARTVIEW.Item(1).ViewColumn.Item(j).the_Alias & """;"
                        Next
                        s = s & vbCrLf & "          " & ctlName & ".DataValueField = ""ID"";"
                    End If

                Else
                    bFoo = False
                    If (f.DINAMICFILTERSCRIPT.Count > 0) Then
                        For dfilt1 = 1 To f.DINAMICFILTERSCRIPT.Count
                            If (Not f.DINAMICFILTERSCRIPT.Item(dfilt1).Target Is Nothing) Then
                                'UPGRADE_WARNING: Couldn't resolve default property of object f.DINAMICFILTERSCRIPT.Item(dfilt1).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                If (f.DINAMICFILTERSCRIPT.Item(dfilt1).Target.ID.ToString() = tid) Then
                                    s = s & vbCrLf & f.DINAMICFILTERSCRIPT.Item(dfilt1).Code
                                    bFoo = True
                                End If
                            End If
                        Next
                    End If
                    If (Not bFoo) Then
                        If f.RefToType Is Nothing Then
                            s = s & vbCrLf & "          DataTable dt" & f.Name & " = MKSNManager.Session.GetView(""INSTANCE"", string.Empty, string.Empty);"
                        Else
                            'UPGRADE_WARNING: Couldn't resolve default property of object f.RefToType.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Dim RefToType As MTZMetaModel.MTZMetaModel.OBJECTTYPE
                            RefToType = f.RefToType
                            s = s & vbCrLf & "          DataTable dt" & f.Name & " = MKSNManager.Session.GetView(""INSTANCE"", ""objtype='" & RefToType.Name & "'"", string.Empty);"
                        End If
                        s = s & vbCrLf & "          " & ctlName & ".DataSource = dt" & f.Name & ".DefaultView;"
                        s = s & vbCrLf & "          " & ctlName & ".DataTextField = ""Name"";"
                        s = s & vbCrLf & "          " & ctlName & ".DataValueField = ""InstanceID"";"
                    End If
                End If
                s = s & vbCrLf & "          " & ctlName & ".DataBind();"
                s = s & vbCrLf & "          if (RowItem." & f.Name & "!= null)"
                s = s & vbCrLf & "          {"
                s = s & vbCrLf & "            " & ctlName & ".SelectedValue = RowItem." & f.Name & ".ID.ToString();"
                s = s & vbCrLf & "          }"
                If f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    s = s & vbCrLf & "          " & ctlName & ".Items.Insert(0, new System.Web.UI.WebControls.ListItem(string.Empty, string.Empty));"
                End If
                If (DefaultValue <> "") Then
                    s = s & vbCrLf & "          try"
                    s = s & vbCrLf & "          {"
                    s = s & vbCrLf & "          if (AddNew && !IsPostBack)"
                    s = s & vbCrLf & "            " & ctlName & ".SelectedValue  = " & DefaultValue & ";"
                    s = s & vbCrLf & "          }"
                    s = s & vbCrLf & "          catch{ }"
                End If
            ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                ctlName = "cmb" & f.Name
                For j = 1 To ft.ENUMITEM.Count
                    s = s & vbCrLf & "          " & ctlName & ".Items.Insert(0, new System.Web.UI.WebControls.ListItem(""" & ft.ENUMITEM.Item(j).Name & """, """ & ft.ENUMITEM.Item(j).NameValue & """));"
                Next
                s = s & vbCrLf & "          " & ctlName & ".SelectedValue = ((int)RowItem." & f.Name & ").ToString();"
            Else
                ctlName = "txt" & f.Name
                If MapFT(m, ft.ID.ToString(), tid) = "DATE" Then
                    ctlName = "Date" & f.Name
                    If (DefaultValue <> "") Then
                        s = s & vbCrLf & "          try"
                        s = s & vbCrLf & "          {"
                        s = s & vbCrLf & "           if (AddNew && !IsPostBack)"
                        s = s & vbCrLf & "           {"
                        s = s & vbCrLf & "             Date" & f.Name & ".Text = " & DefaultValue & ";"
                        s = s & vbCrLf & "           }"
                        s = s & vbCrLf & "          }"
                        s = s & vbCrLf & "          catch{ }"
                    End If
                    s = s & vbCrLf & "          if(RowItem." & f.Name & ".FieldValue != Convert.ToDateTime(""30.12.1899"") && RowItem." & f.Name & ".FieldValue != Convert.ToDateTime(""01.01.0001""))"
                    s = s & vbCrLf & "            Date" & f.Name & ".Text=RowItem." & f.Name & ".FieldValue.ToShortDateString();"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "DATETIME" Then
                    ctlName = "Date" & f.Name
                    If (DefaultValue <> "") Then
                        s = s & vbCrLf & "          try"
                        s = s & vbCrLf & "          {"
                        s = s & vbCrLf & "          if (AddNew && !IsPostBack) {"
                        If (InStr(1, DefaultValue, vbCrLf) > 0) Then
                            s = s & vbCrLf & "          Date" & f.Name & ".Text = " & Mid(DefaultValue, 1, InStr(1, DefaultValue, vbCrLf)) & ";"
                            s = s & vbCrLf & "          Time" & f.Name & ".Text = " & Mid(DefaultValue, InStr(1, DefaultValue, vbCrLf) + 1) & ";"
                        Else
                            s = s & vbCrLf & "          Date" & f.Name & ".Text = " & DefaultValue & ";"
                        End If
                        s = s & vbCrLf & "          }"
                        s = s & vbCrLf & "          catch{ }"

                        s = s & vbCrLf & "         }"
                    End If
                    s = s & vbCrLf & "          if(RowItem." & f.Name & ".FieldValue != Convert.ToDateTime(""30.12.1899"") && RowItem." & f.Name & ".FieldValue != Convert.ToDateTime(""01.01.0001""))"
                    s = s & vbCrLf & "          {"
                    s = s & vbCrLf & "            Date" & f.Name & ".Text = RowItem." & f.Name & ".ToShortDateString();"
                    s = s & vbCrLf & "            Time" & f.Name & ".Text = RowItem." & f.Name & ".ToShortTimeString();"
                    s = s & vbCrLf & "          }"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "TIME" Then
                    ctlName = "Time" & f.Name
                    s = s & vbCrLf & "            Time" & f.Name & ".Text=RowItem." & f.Name & ".FieldValue.ToShortTimeString();"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "IMAGE" Then
                    s = s & vbCrLf & "   if (!(DataComponent.DenyVisible.IndexOf(""" & f.Name & """) > -1)) {"
                    s = s & vbCrLf & "           MemoryStream  ms" & f.Name & " = new MemoryStream();"
                    s = s & vbCrLf & "           BinaryWriter bw" & f.Name & " = new BinaryWriter(ms" & f.Name & ");"
                    s = s & vbCrLf & "           bw" & f.Name & ".Write (RowItem." & f.Name & ".FieldValue);"
                    s = s & vbCrLf & "           BinaryReader br" & f.Name & "= new BinaryReader(ms" & f.Name & ");"
                    s = s & vbCrLf & "           " & ctlName & ".Text = br" & f.Name & ".ReadString();"
                    s = s & vbCrLf & "   }"
                Else
                    If (DefaultValue <> "") Then
                        s = s & vbCrLf & "          try"
                        s = s & vbCrLf & "          {"
                        s = s & vbCrLf & "          if (AddNew)"
                        s = s & vbCrLf & "            " & ctlName & ".Text = " & DefaultValue & ";"
                        s = s & vbCrLf & "          }"
                        s = s & vbCrLf & "          catch{ }"
                    End If
                    ctlName = "txt" & f.Name
                    s = s & vbCrLf & "   if (!(DataComponent.DenyVisible.IndexOf(""" & f.Name & """) > -1)) {"
                    s = s & vbCrLf & "          " & ctlName & ".Text = GetValueFromRowItem(RowItem." & f.Name & ".FieldValue);"
                    s = s & vbCrLf & "   }"
                End If
            End If
            s = s & vbCrLf & "          " & ctlName & ".ToolTip = """ & f.Caption & """;"
            s = s & vbCrLf & "          if (ReadOnly || (DataComponent.DenyEdit.IndexOf(""" & f.name & """) > -1))"
            s = s & vbCrLf & "          {"
            s = s & vbCrLf & "            ControlsToHide.Add(""btn" & f.name & """);"
            s = s & vbCrLf & "            " & ctlName & ".Enabled = false;"
            If f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                s = s & vbCrLf & "            rfv" & f.Name & ".Enabled = false;"
            End If
            s = s & vbCrLf & "          }"
            s = s & vbCrLf & "          if (DataComponent.DenyVisible.IndexOf(""" & f.name & """) > -1) "
            s = s & vbCrLf & "          {"
            s = s & vbCrLf & "            lbl" & f.name & ".Visible = false;"
            s = s & vbCrLf & "            " & ctlName & ".Visible = false;"
            If f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                s = s & vbCrLf & "            rfv" & f.Name & ".Enabled = false;"
            End If
            s = s & vbCrLf & "          }"
            s = s & vbCrLf & "          if (OnFieldInit != null)"
            s = s & vbCrLf & "          {"
            s = s & vbCrLf & "            OnFieldInit(" & ctlName & ", new EventArgs());"
            s = s & vbCrLf & "          }"
        Next
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "      if (ReadOnly) btnSave.Enabled = false;"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "    #region Web Form Designer generated code"
        s = s & vbCrLf & "    override protected void OnInit(EventArgs e)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      base.OnInit(e);"
        s = s & vbCrLf & "      InitializeComponent();"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "    private void InitializeComponent()"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);"
        s = s & vbCrLf & "      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);"
        s = s & vbCrLf & "      this.Load += new System.EventHandler(this.Page_Load);"
        s = s & vbCrLf & "      this.Unload += new System.EventHandler(this.Page_Unload);"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "    }"
        s = s & vbCrLf & "    #endregion"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "     private string GetValueFromRowItem(object RowItemValue)"
        s = s & vbCrLf & "     {"
        s = s & vbCrLf & "       string Result = string.Empty;"
        s = s & vbCrLf & "       if (RowItemValue != null)"
        s = s & vbCrLf & "       {"
        s = s & vbCrLf & "         Result = RowItemValue.ToString();"
        s = s & vbCrLf & "       }"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "       return Result;"
        s = s & vbCrLf & "     }"
        s = s & vbCrLf
        s = s & vbCrLf & "    private void btnCancel_Click(object sender, System.EventArgs e)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "        if (OnCancel != null)"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          OnCancel(this, new EventArgs());"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "        else"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "           Response.Redirect(BackUrl);"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf
        s = s & vbCrLf & "    private void btnSave_Click(object sender, System.EventArgs e)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "         if (RowItem == null)"
        s = s & vbCrLf & "         {"
        s = s & vbCrLf & "           if (OnInfo != null)"
        s = s & vbCrLf & "           {"
        s = s & vbCrLf & "              OnInfo(this, new InfoEventArgs(""Не создана запись."", System.Drawing.Color.Red));"
        s = s & vbCrLf & "           }"
        s = s & vbCrLf & "           else"
        s = s & vbCrLf & "           {"
        s = s & vbCrLf & "              " & p.name & "LabelInfo.Text = ""Не создана запись. "";"
        s = s & vbCrLf & "              " & p.name & "LabelInfo.ForeColor = System.Drawing.Color.Red;"
        s = s & vbCrLf & "           }"
        s = s & vbCrLf & "         }"
        s = s & vbCrLf & "        if (OnBeforeSave != null)"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          OnBeforeSave(this, new EventArgs());"
        s = s & vbCrLf & "        }"
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FIELDTYPE
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                ctlName = "cmb" & f.Name
                s = s & vbCrLf & "      if (" & ctlName & ".SelectedValue.ToString() != string.Empty)"
                s = s & vbCrLf & "      {"
                If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object f.RefToPart.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Dim RefToPart As MTZMetaModel.MTZMetaModel.PART
                    RefToPart = f.RefToPart
                    s = s & vbCrLf & "        RowItem." & f.Name & " = RowItem.Application.FindRowObject(""" & RefToPart.Name & """, new Guid(" & ctlName & ".SelectedValue.ToString()));"
                Else
                    s = s & vbCrLf & "        try {"
                    s = s & vbCrLf & "        RowItem." & f.Name & " = MKSNManager.GetInstanceObject( new Guid(" & ctlName & ".SelectedValue.ToString()));"
                    s = s & vbCrLf & "        }catch {}"
                End If
                s = s & vbCrLf & "      }"
                s = s & vbCrLf & "      else"
                s = s & vbCrLf & "      {"
                s = s & vbCrLf & "        try {"
                s = s & vbCrLf & "        RowItem." & f.Name & " = null;"
                s = s & vbCrLf & "        }catch {}"
                s = s & vbCrLf & "      }"
            ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                ctlName = "cmb" & f.Name
                s = s & vbCrLf & "        RowItem." & f.Name & " = (" & tt.Name & ".enum" & ft.Name & ")Convert.ToInt32(" & ctlName & ".SelectedValue);"
            Else
                ctlName = "txt" & f.Name
                If MapFT(m, ft.ID.ToString(), tid) = "DATE" Then
                    s = s & vbCrLf & "       try"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "         if (Date" & f.Name & ".Text != string.Empty)"
                    s = s & vbCrLf & "         {"
                    s = s & vbCrLf & "              RowItem." & f.Name & ".FieldValue = Convert.ToDateTime(Date" & f.Name & ".Text);"
                    s = s & vbCrLf & "         }"
                    s = s & vbCrLf & "         else "
                    s = s & vbCrLf & "         {"
                    s = s & vbCrLf & "              RowItem." & f.Name & ".FieldValue = DateTime.MinValue;"
                    s = s & vbCrLf & "         }"
                    s = s & vbCrLf & "       }"
                    s = s & vbCrLf & "       catch"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "         if (OnInfo != null)"
                    s = s & vbCrLf & "           {"
                    s = s & vbCrLf & "              OnInfo(this, new InfoEventArgs(""Введите правильную дату в поле " & f.Caption & " (например 14.11.1973)"", System.Drawing.Color.Red));"
                    s = s & vbCrLf & "           }"
                    s = s & vbCrLf & "           else"
                    s = s & vbCrLf & "           {"
                    s = s & vbCrLf & "              " & p.Name & "LabelInfo.Text = ""Введите правильную дату в поле " & f.Caption & " (например 14.11.1973)"";"
                    s = s & vbCrLf & "           }"
                    s = s & vbCrLf & "       }"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "DATETIME" Then
                    s = s & vbCrLf & "       try"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "         if (Date" & f.Name & ".Text != string.Empty)"
                    s = s & vbCrLf & "         {"
                    s = s & vbCrLf & "            DateTime newValue;"
                    s = s & vbCrLf & "            newValue = Convert.ToDateTime(Date" & f.Name & ".Text + "" "" +  Time" & f.Name & ".Text);"
                    s = s & vbCrLf & "            RowItem." & f.Name & ".FieldValue = newValue;"
                    s = s & vbCrLf & "         }"
                    s = s & vbCrLf & "         else "
                    s = s & vbCrLf & "         {"
                    s = s & vbCrLf & "              RowItem." & f.Name & ".FieldValue = DateTime.MinValue;"
                    s = s & vbCrLf & "         }"
                    s = s & vbCrLf & "       }"
                    s = s & vbCrLf & "       catch"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "         if (OnInfo != null)"
                    s = s & vbCrLf & "         {"
                    s = s & vbCrLf & "            OnInfo(this, new InfoEventArgs(""Введите правильную дату в поле " & f.Caption & " (например 14.11.1973)"", System.Drawing.Color.Red));"
                    s = s & vbCrLf & "         }"
                    s = s & vbCrLf & "         else"
                    s = s & vbCrLf & "         {"
                    s = s & vbCrLf & "            " & p.Name & "LabelInfo.Text = ""Введите правильную дату в поле " & f.Caption & " (например 14.11.1973)"";"
                    s = s & vbCrLf & "            lbl" & f.Name & ".ForeColor = System.Drawing.Color.Red;"
                    s = s & vbCrLf & "         }"
                    s = s & vbCrLf & "         return;"
                    s = s & vbCrLf & "       }"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "TIME" Then
                    ctlName = "Time" & f.Name
                    s = s & vbCrLf & "       try"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "         if (" & ctlName & ".Text != string.Empty)"
                    s = s & vbCrLf & "         {"
                    s = s & vbCrLf & "              RowItem." & f.Name & ".FieldValue = Convert.ToDateTime(Time" & f.Name & ".Text);"
                    s = s & vbCrLf & "         }"
                    s = s & vbCrLf & "         else "
                    s = s & vbCrLf & "         {"
                    s = s & vbCrLf & "              RowItem." & f.Name & ".FieldValue = DateTime.MinValue;"
                    s = s & vbCrLf & "         }"
                    s = s & vbCrLf & "       }"
                    s = s & vbCrLf & "       catch"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "         " & p.Name & "LabelInfo.Text = ""Введите правильное время в поле " & f.Caption & " (например 12:00)"";"
                    s = s & vbCrLf & "         return;"
                    s = s & vbCrLf & "       }"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "INTEGER" Then
                    s = s & vbCrLf & "       try"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "          RowItem." & f.Name & ".FieldValue = Convert.ToInt32( " & ctlName & ".Text);"
                    s = s & vbCrLf & "       }"
                    s = s & vbCrLf & "       catch"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "         " & p.Name & "LabelInfo.Text = ""Введите правильное число в поле " & f.Caption & " (например 100)"";"
                    s = s & vbCrLf & "         return;"
                    s = s & vbCrLf & "       }"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "NUMERIC" Then
                    s = s & vbCrLf & "       try"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "          RowItem." & f.Name & ".FieldValue = Convert.ToDouble( " & ctlName & ".Text);"
                    s = s & vbCrLf & "       }"
                    s = s & vbCrLf & "       catch"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "         " & p.Name & "LabelInfo.Text = ""Введите правильное число в поле " & f.Caption & " (например 10)"";"
                    s = s & vbCrLf & "         return;"
                    s = s & vbCrLf & "       }"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "GUID" Then
                    s = s & vbCrLf & "       try"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "          RowItem." & f.Name & ".FieldValue = new System.Guid(" & ctlName & ".Text);"
                    s = s & vbCrLf & "       }"
                    s = s & vbCrLf & "       catch"
                    s = s & vbCrLf & "       {"
                    s = s & vbCrLf & "         " & p.Name & "LabelInfo.Text = ""Ожидался GUID в поле " & f.Caption & " "";"
                    s = s & vbCrLf & "         return;"
                    s = s & vbCrLf & "       }"
                ElseIf MapFT(m, ft.ID.ToString(), tid) = "IMAGE" Then
                    s = s & vbCrLf & "     MemoryStream  ms" & f.Name & " = new MemoryStream();"
                    s = s & vbCrLf & "     BinaryWriter bw" & f.Name & " = new BinaryWriter(ms" & f.Name & ");"
                    s = s & vbCrLf & "     bw" & f.Name & ".Write (" & ctlName & ".Text);"
                    s = s & vbCrLf & "     BinaryReader br" & f.Name & "= new BinaryReader(ms" & f.Name & ");"
                    s = s & vbCrLf & "     RowItem." & f.Name & ".FieldValue = br" & f.Name & ".ReadBytes((int)ms" & f.Name & ".Length);"
                Else
                    s = s & vbCrLf & "   RowItem." & f.Name & ".FieldValue = " & ctlName & ".Text;"
                End If
            End If
        Next
        s = s & vbCrLf & "      try"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        RowItem.Save();"
        s = s & vbCrLf & "        if (OnInfo != null)"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          OnInfo(this, new InfoEventArgs(""Данные успешно сохранены"", System.Drawing.Color.Green));"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "        else"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          " & p.name & "LabelInfo.ForeColor = System.Drawing.Color.Green;"
        s = s & vbCrLf & "          " & p.name & "LabelInfo.Text = ""Данные сохранены"";"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "        if (OnAfterSave != null)"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          OnAfterSave(this, new EventArgs());"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "      catch(Exception Ex)"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        " & p.name & "LabelInfo.Text = ""Данные не сохранены. "" + Ex.Message;"
        s = s & vbCrLf & "        " & p.name & "LabelInfo.ForeColor = System.Drawing.Color.Red;"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "    }"

        s = s & vbCrLf & "    private DataView ConfigureView(DataTable dt, string DataTextFormatString)"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      DataView Result = null;"
        s = s & vbCrLf & "      DataTable NewDT = new DataTable(dt.TableName);"
        s = s & vbCrLf & "      NewDT.Columns.Add(""text"");"
        s = s & vbCrLf & "      NewDT.Columns.Add(""id"");"
        s = s & vbCrLf & "      foreach(DataRow dr  in dt.Rows)"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        DataRow newDr = NewDT.NewRow();"
        s = s & vbCrLf & "        newDr[""id""] = dr[""ID""].ToString();"
        s = s & vbCrLf & "        string Text =  DataTextFormatString;"
        s = s & vbCrLf & "        foreach(DataColumn col in dt.Columns )"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "           Text = Text.Replace(col.ColumnName, dr[col].ToString());"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "        newDr[""text""] = Text;"
        s = s & vbCrLf & "        NewDT.Rows.Add(newDr);"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "      Result = NewDT.DefaultView;"
        s = s & vbCrLf & "      Result.Sort = ""text"";"
        s = s & vbCrLf & "      return Result;"
        s = s & vbCrLf & "    }"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "    protected string GetOnLoadScript()"
        s = s & vbCrLf & "    {"
        s = s & vbCrLf & "      string result = string.Empty;"
        s = s & vbCrLf & "      if (ControlsToHide != null)"
        s = s & vbCrLf & "      {"
        s = s & vbCrLf & "        foreach(string str in ControlsToHide)"
        s = s & vbCrLf & "        {"
        s = s & vbCrLf & "          result += ""ElementHide('"" + str + ""');"";"
        s = s & vbCrLf & "        }"
        s = s & vbCrLf & "      }"
        s = s & vbCrLf & "      return result;"
        s = s & vbCrLf & "    }"

        s = s & vbCrLf & "  }"
        s = s & vbCrLf & "}"
        SetExt(o, "uc" & p.name & ".ASCX.cs", "")
        o.Block = "code"
        o.OutNL(s)
        For i = 1 To p.PART.Count
            MakeRow(tid, m, ot, p.PART.Item(i), o)
        Next
    End Sub
End Module