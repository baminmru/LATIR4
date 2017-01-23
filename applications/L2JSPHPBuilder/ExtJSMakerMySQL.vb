Imports System.IO
Imports System.Text


Public Class ExtJSMakerMYSQL

    Private basepath As String = "index.php/"
    Private Sub ExtJSMaker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer
        Dim ti As tmpInst
        model.OBJECTTYPE.Sort = "Name"
        For i = 1 To model.OBJECTTYPE.Count
            ti = New tmpInst()
            ti.ID = model.OBJECTTYPE.Item(i).ID
            ti.Name = model.OBJECTTYPE.Item(i).the_Comment
            ti.ObjType = model.OBJECTTYPE.Item(i).Name
            chkObjType.Items.Add(ti, False)
        Next

        Dim dt As DataTable
        dt = Manager.Session.GetData("select " + Manager.Session.GetProvider.InstanceFieldList + " from instance where objtype ='mtzjrnl' order by name")
        For i = 0 To dt.Rows.Count - 1
            ti = New tmpInst()
            ti.ID = New Guid(dt.Rows(i)("instanceid").ToString)
            ti.Name = dt.Rows(i)("name")
            ti.ObjType = ""
            chkJournals.Items.Add(ti, False)
        Next
        textBoxOutPutFolder.Text = GetSetting("BP3BUILDER", "EXTJS2MYSQL_" & Manager.Site, "PATH", "c:\")
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        folderBrowserDialogProjectOutput.SelectedPath = textBoxOutPutFolder.Text
        folderBrowserDialogProjectOutput.ShowDialog()
        textBoxOutPutFolder.Text = folderBrowserDialogProjectOutput.SelectedPath
        If Not textBoxOutPutFolder.Text.EndsWith("\") Then
            textBoxOutPutFolder.Text += "\"
            SaveSetting("BP3BUILDER", "EXTJS2MYSQL_" & Manager.Site, "PATH", textBoxOutPutFolder.Text)
        End If
    End Sub


    Private Function SysMake_Include() As String
        Dim sw As StringBuilder

        sw = New StringBuilder

        Dim JJJ As MTZJrnl.MTZJrnl.Application
        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim JR As MTZJrnl.MTZJrnl.Journal
        Dim ti As tmpInst
        Dim i As Integer
        Dim j As Integer
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim om As MTZMetaModel.MTZMetaModel.OBJECTMODE
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim m As Integer
        Dim mode As String


        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = chkObjType.CheckedItems.Count
        Me.Text = "Generating types"
        Application.DoEvents()

        pb.Visible = True
        For i = 0 To chkObjType.CheckedItems.Count - 1
            pb.Value = i + 1
            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)

            ot = model.OBJECTTYPE.Item(ti.ID.ToString())

            For m = 1 To ot.OBJECTMODE.Count
                om = ot.OBJECTMODE.Item(m)
                mode = om.Name

                sw.Append(vbCrLf & "<!--   type:" & ot.Name & " mode:" & mode & " -->" & vbCrLf)
                For j = 1 To ot.PART.Count
                    P = ot.PART.Item(j)

                    If LATIR2Framework.ObjectHelper.IsPresent(P, mode) Then
                        sw.Append(vbCrLf & "     <script type='text/javascript' src='resources/" & P.Name.ToLower() & "_" & mode & ".js'></script>")
                    End If

                Next
                sw.Append(vbCrLf & "     <script type='text/javascript' src='resources/" & ot.Name.ToLower() & "_" & mode & ".js'></script>")
                sw.Append(vbCrLf & "<!--   type:" & ot.Name & " mode:" & mode & " end -->" & vbCrLf)
            Next
            sw.Append(vbCrLf & "<!--   type:" & ot.Name & " default mode -->" & vbCrLf)
            mode = ""
            For j = 1 To ot.PART.Count
                P = ot.PART.Item(j)

                If LATIR2Framework.ObjectHelper.IsPresent(P, mode) Then
                    sw.Append(vbCrLf & "     <script type='text/javascript' src='resources/" & P.Name.ToLower() & "_" & mode & ".js'></script>")
                End If

            Next
            sw.Append(vbCrLf & "     <script type='text/javascript' src='resources/" & ot.Name.ToLower() & "_" & mode & ".js'></script>")
            sw.Append(vbCrLf & "<!--   type:" & ot.Name & " default mode end  -->" & vbCrLf)
        Next

        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = chkJournals.CheckedItems.Count

        pb.Visible = True
        For i = 0 To chkJournals.CheckedItems.Count - 1
            pb.Value = i + 1
            Application.DoEvents()
            ti = chkJournals.CheckedItems(i)

            JJJ = Manager.GetInstanceObject(ti.ID)
            If Not JJJ Is Nothing Then
                Try
                    Dim va As String
                    va = JJJ.JournalSrc.Item(1).ViewAlias
                    sw.Append(vbCrLf & "<!--   journal :" & va.ToLower() & " -->" & vbCrLf)
                    sw.Append(vbCrLf & "     <script type='text/javascript' src='resources/s_v_" & va.ToLower() & ".js'></script>")
                    sw.Append(vbCrLf & "     <script type='text/javascript' src='resources/j_v_" & va.ToLower() & ".js'></script>")
                    sw.Append(vbCrLf & "<!--   journal :" & va.ToLower() & " end -->" & vbCrLf)
                Catch ex As Exception
                End Try

            End If

        Next
        Return sw.ToString()
    End Function


    Private Function SysMake_Menu() As String
        Dim sw As StringBuilder

        sw = New StringBuilder

        Dim JJJ As MTZJrnl.MTZJrnl.Application
        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim p As MTZJrnl.MTZJrnl.Journal
        Dim ti As tmpInst
        Dim i As Integer

        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = chkJournals.CheckedItems.Count

        pb.Visible = True
        For i = 0 To chkJournals.CheckedItems.Count - 1
            pb.Value = i + 1
            Application.DoEvents()
            ti = chkJournals.CheckedItems(i)

            JJJ = Manager.GetInstanceObject(Ti.id)
            If Not JJJ Is Nothing Then

                p = JJJ.Journal.Item(1)


                If Not p Is Nothing Then

                    sw.Append(vbCrLf & "var action" & JJJ.Name & " = Ext.create('Ext.Action', {")
                    sw.Append(vbCrLf & "    itemId:             'action" & JJJ.Name & "',")
                    sw.Append(vbCrLf & "    text:               '" & p.Name & "',")
                    If p.jrnlIconCls <> "" Then
                        sw.Append(vbCrLf & "    iconCls:            '" & p.jrnlIconCls & "',")
                    Else
                        sw.Append(vbCrLf & "    iconCls:            'icon-brick',")
                    End If

                    sw.Append(vbCrLf & "			 disabled:defaultMenuDisabled,")
                    sw.Append(vbCrLf & "			 hidden:defaultMenuHidden,")
                    sw.Append(vbCrLf & "             handler: function(){")

                    sw.Append(vbCrLf & "			var j=Ext.getCmp('" & JJJ.Name.ToLower & "_jrnl');")

                    sw.Append(vbCrLf & "			if(j==null){")
                    sw.Append(vbCrLf & "				j=" & JJJ.Name & "_Jrnl();")
                    If p.jrnlIconCls <> "" Then
                        sw.Append(vbCrLf & "				j.iconCls='" & p.jrnlIconCls & "';")
                    Else
                        sw.Append(vbCrLf & "				j.iconCls='icon-brick';")
                    End If

                    sw.Append(vbCrLf & "				contentPanel.add(j);")
                    sw.Append(vbCrLf & "				contentPanel.setActiveTab(j);")
                    sw.Append(vbCrLf & "			}")
                    sw.Append(vbCrLf & "			else{")
                    sw.Append(vbCrLf & "				contentPanel.setActiveTab(j);")
                    sw.Append(vbCrLf & "			}")
                    sw.Append(vbCrLf & "             }")
                    sw.Append(vbCrLf & "});")


                End If
            End If

        Next

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        For i = 1 To model.OBJECTTYPE.Count
            ot = model.OBJECTTYPE.Item(i)
            If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                sw.Append(vbCrLf & "var action" & ot.Name & " = Ext.create('Ext.Action', {")
                sw.Append(vbCrLf & "        itemId:  'action" & ot.Name & "',")
                sw.Append(vbCrLf & "        text:   '" & ot.the_Comment & "',")
                If ot.objIconCls <> "" Then
                    sw.Append(vbCrLf & "        iconCls:  '" & ot.objIconCls & "',")
                Else
                    sw.Append(vbCrLf & "        iconCls:  'icon-brick',")
                End If

                sw.Append(vbCrLf & "			 disabled:defaultMenuDisabled,")
                sw.Append(vbCrLf & "			 hidden:defaultMenuHidden,")
                sw.Append(vbCrLf & "			handler: function(){")
                sw.Append(vbCrLf & "			var j=Ext.getCmp('" & ot.Name.ToLower() & "');")
                sw.Append(vbCrLf & "			if(j==null){")


                Dim dt As DataTable
                dt = Manager.Session.GetData("select " & Manager.Session.GetProvider().InstanceFieldList() & " from instance where objtype='" & ot.Name.ToLower() & "'")
                If dt.Rows.Count > 0 Then
                    sw.Append(vbCrLf & "				j=eval('" & ot.Name & "_Panel_'+OTEditMode('" & ot.Name & "')+'(\'" & dt.Rows(0)("instanceid").ToString() & "\', true)');")

                Else
                    ' sw.Append(vbCrLf & "				j=" & ot.Name & "_Panel_('" & Guid.NewGuid.ToString() & "', true);")
                    sw.Append(vbCrLf & "				j=eval('" & ot.Name & "_Panel_'+OTEditMode('" & ot.Name & "')+'(\'" & Guid.NewGuid.ToString() & "\', true)');")
                End If

                If ot.objIconCls <> "" Then
                    sw.Append(vbCrLf & "        j.iconCls= '" & ot.objIconCls & "';")
                Else
                    sw.Append(vbCrLf & "        j.iconCls=  'icon-brick';")
                End If
                sw.Append(vbCrLf & "				contentPanel.add(j);")
                sw.Append(vbCrLf & "				contentPanel.setActiveTab(j);")
                sw.Append(vbCrLf & "			}")
                sw.Append(vbCrLf & "			else{")
                sw.Append(vbCrLf & "				contentPanel.setActiveTab(j);")
                sw.Append(vbCrLf & "			}")
                sw.Append(vbCrLf & "        }")
                sw.Append(vbCrLf & "    });")
            End If
        Next


        Return sw.ToString()
    End Function


    Private Sub PartMake_CI(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col)
        Dim xout As String

        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        For i = 1 To pcol.Count
            P = pcol.Item(i)
            If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                xout = PartMake_CIModel(P)
                Tool_WriteFile(xout, textBoxOutPutFolder.Text & "models\", "m_" & P.Name.ToLower() & ".php")
                xout = PartMake_CIController(P)
                Tool_WriteFile(xout, textBoxOutPutFolder.Text & "controllers\", "c_" & P.Name.ToLower() & ".php")
                PartMake_CI(P.PART)
                'xout = PartMake_CIMartModel(P)
                'Tool_WriteFile(xout, textBoxOutPutFolder.Text & "models\", "m_mart_" & P.Name.ToLower() & ".php")
                'xout = PartMake_CIMartController(P)
                'Tool_WriteFile(xout, textBoxOutPutFolder.Text & "controllers\", "c_mart_" & P.Name.ToLower() & ".php")
                'PartMake_CI(P.PART)
            End If
        Next
    End Sub

    'Private Function TypeMartImport(ByVal OT As MTZMetaModel.MTZMetaModel.OBJECTTYPE) As String
    '    Dim os As MTZMetaModel.MTZMetaModel.PART = Nothing
    '    Dim osRoot As MTZMetaModel.MTZMetaModel.PART = Nothing

    '    Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
    '    Dim fld As MTZMetaModel.MTZMetaModel.FIELD

    '    Dim sw As StringBuilder
    '    sw = New StringBuilder

    '    Dim i As Integer
    '    OT.PART.Sort = "sequence"
    '    For i = 1 To OT.PART.Count
    '        os = OT.PART.Item(i)
    '        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
    '            Exit For
    '        End If
    '        os = Nothing
    '    Next
    '    If os Is Nothing Then Return ""
    '    osRoot = os

    '    sw.Append(vbCrLf & "        function Import" & OT.Name & "(){")
    '    sw.Append(vbCrLf & "      global    $server_from,$user_from,$password_from,$db_from,$firm_from,$server_to,$user_to,$password_to,$db_to;")
    '    sw.Append(vbCrLf & "$conn_from = new mysqli($server_from, $user_from, $password_from,$db_from);")
    '    sw.Append(vbCrLf & "$conn_from ->set_charset('utf8');")


    '    sw.Append(vbCrLf & "if (mysqli_connect_errno()) {")
    '    sw.Append(vbCrLf & "  exit('Connect failed: '. mysqli_connect_error());")
    '    sw.Append(vbCrLf & "}")

    '    sw.Append(vbCrLf & "$conn_to = new mysqli($server_to, $user_to, $password_to,$db_to);")
    '    sw.Append(vbCrLf & "$conn_to ->set_charset('utf8');")

    '    sw.Append(vbCrLf & "if (mysqli_connect_errno()) {")
    '    sw.Append(vbCrLf & "  exit('Connect failed: '. mysqli_connect_error());")
    '    sw.Append(vbCrLf & "}")


    '    sw.Append(vbCrLf & "$sql_del = ""delete from " & os.Name.ToLower & " where firmid=g2b('"".$firm_from.""')""; ")
    '    sw.Append(vbCrLf & "if ($conn_to->query($sql_del) === TRUE) {")
    '    sw.Append(vbCrLf & "  echo 'deleteing data';")
    '    sw.Append(vbCrLf & "}")
    '    sw.Append(vbCrLf & "else {")
    '    sw.Append(vbCrLf & " echo 'Error: '. $conn_to->error;")
    '    sw.Append(vbCrLf & "}")

    '    sw.Append(vbCrLf & "$sql_del = ""delete from instance where objtype='" & OT.Name & "' and instanceid not in (select instanceid from " & os.Name.ToLower & ")""; ")
    '    sw.Append(vbCrLf & "if ($conn_to->query($sql_del) === TRUE) {")
    '    sw.Append(vbCrLf & "  echo 'deleteing instances';")
    '    sw.Append(vbCrLf & "}")
    '    sw.Append(vbCrLf & "else {")
    '    sw.Append(vbCrLf & " echo 'Error: '. $conn_to->error;")
    '    sw.Append(vbCrLf & " }")


    '    sw.Append(vbCrLf & "$sql = ""select * from v_auto" & os.Name.ToLower & " where " & os.Name.ToLower & "_isexport_val=-1 and " & os.Name.ToLower & "_tstatusid_id='{D4721E6E-2BFF-483C-982B-52206C0572C4}' and " & os.Name.ToLower & "_firmid_id='"".$firm_from.""'""; ")


    '    sw.Append(vbCrLf & "$result = $conn_from->query($sql);")
    '    sw.Append(vbCrLf & "$cnt=0;")

    '    sw.Append(vbCrLf & "if ($result->num_rows > 0) {")


    '    sw.Append(vbCrLf & "  while($row = $result->fetch_assoc()) {")
    '    sw.Append(vbCrLf & "    $cnt=$cnt+1;")
    '    sw.Append(vbCrLf & "    echo '<br/> ('.$cnt.' of '.$result->num_rows.') ' ;//id: '. $row['id']. ' instanceid: '.$row['instanceid'];")

    '    sw.Append(vbCrLf & "	$id=$row['id'];")
    '    sw.Append(vbCrLf & "	$instanceid=$row['instanceid'];")

    '    sw.Append(vbCrLf & "	$sql_test = ""select count(*) cnt from instance where instanceid=g2b('"".$instanceid.""')""; ")

    '    sw.Append(vbCrLf & "	$result_inst = $conn_to->query($sql_test);")
    '    sw.Append(vbCrLf & "	if ($result_inst->num_rows !=0 ) {")
    '    sw.Append(vbCrLf & "	    $row_i = $result_inst->fetch_assoc();")
    '    sw.Append(vbCrLf & "		if($row_i !=null){")

    '    sw.Append(vbCrLf & "			if ($row_i['cnt']==0){")
    '    sw.Append(vbCrLf & "				$id=$row['id'];")
    '    sw.Append(vbCrLf & "				$instanceid=$row['instanceid'];")

    '    sw.Append(vbCrLf & "				$sql_ins = ""INSERT INTO `instance` (`instanceid`, `objtype`, `name`)VALUES (g2b('"".$instanceid .""'), '" & OT.Name & "', '"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_addressstring']).""')""; ")
    '    sw.Append(vbCrLf & "				// Performs the $sql query on the server to insert the values")
    '    sw.Append(vbCrLf & "				if ($conn_to->query($sql_ins) === TRUE) {")
    '    sw.Append(vbCrLf & "				  echo 'instance created';")
    '    sw.Append(vbCrLf & "				}")
    '    sw.Append(vbCrLf & "				else {")
    '    sw.Append(vbCrLf & "				 echo 'Error: '. $conn_to->error;")
    '    sw.Append(vbCrLf & "				}")
    '    sw.Append(vbCrLf & "			}")
    '    sw.Append(vbCrLf & "		}")
    '    sw.Append(vbCrLf & "	}")

    '    sw.Append(vbCrLf & "	$sql_test = ""select * from " & os.Name.ToLower & " where " & os.Name.ToLower & "id=g2b('"".$id .""')""; ")

    '    sw.Append(vbCrLf & "	$result_inst = $conn_to->query($sql_test);")
    '    sw.Append(vbCrLf & "	if ($result_inst->num_rows == 0) {")

    '    sw.Append(vbCrLf & "           echo( ' inserting... ');")
    '    sw.Append("                 $sql="" insert into   " & os.Name & vbCrLf & " (instanceid,  changestamp, " & os.Name & "ID ")

    '    os.FIELD.Sort = "sequence"
    '    For i = 1 To os.FIELD.Count
    '        fld = os.FIELD.Item(i)
    '        If fld.TheStyle.IndexOf("lock") < 0 Then
    '            ft = fld.FieldType
    '            If (ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy) Then

    '                sw.Append(",/*" & (i + 3).ToString & "*/ " & fld.Name.ToLower)

    '                If UCase(ft.Name) = "FILE" Then
    '                    sw.Append("," & fld.Name.ToLower & "_ext")
    '                End If

    '            End If
    '        End If
    '    Next

    '    sw.Append(" ) values " & "(g2b('"".$conn_to->real_escape_string($row['instanceid']).""'),'"".$conn_to->real_escape_string($row['changestamp']).""', g2b('"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "id']).""') ")





    '    os.FIELD.Sort = "sequence"
    '    For i = 1 To os.FIELD.Count
    '        fld = os.FIELD.Item(i)
    '        ft = fld.FieldType
    '        If fld.TheStyle.IndexOf("lock") < 0 Then
    '            If (ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy) Then

    '                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka And ft.Name <> "MULTIREF" Then
    '                    sw.Append(",/*" & (i + 3).ToString & "*/" & vbCrLf & " g2b('"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_id']).""')")
    '                Else

    '                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
    '                        sw.Append(",/*" & (i + 3).ToString & "*/" & vbCrLf & " '"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_val']).""'")
    '                    Else
    '                        sw.Append(",/*" & (i + 3).ToString & "*/" & vbCrLf & " '"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "']).""'")


    '                        If UCase(ft.Name) = "FILE" Then
    '                            sw.Append(",/*" & (i + 3).ToString & "*/" & vbCrLf & "  '"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_ext']).""'")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next

    '    sw.Append(" )"" ;")


    '    sw.Append(vbCrLf & " 	if ($conn_to->query($sql) === TRUE) {")
    '    sw.Append(vbCrLf & "        echo( 'inserted');")
    '    sw.Append(vbCrLf & "     }")
    '    sw.Append(vbCrLf & "    else {")
    '    sw.Append(vbCrLf & "        echo( 'Error: '. $conn_to->error.'  sql:'.$sql);")
    '    sw.Append(vbCrLf & "    }  ")
    '    sw.Append(vbCrLf & "}else{")

    '    sw.Append(vbCrLf & " echo( ' updating... ');")
    '    sw.Append(vbCrLf)
    '    sw.Append("$sql="" update  " & os.Name & " set changestamp='"".$conn_to->real_escape_string($row['changestamp']).""'")





    '    os.FIELD.Sort = "sequence"
    '    For i = 1 To os.FIELD.Count
    '        fld = os.FIELD.Item(i)
    '        ft = fld.FieldType
    '        If fld.TheStyle.IndexOf("lock") < 0 Then
    '            If (ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy) Then

    '                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka And ft.Name <> "MULTIREF" Then
    '                    sw.Append("," & vbCrLf)
    '                    sw.Append("  " & fld.Name.ToLower & "=g2b('"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_id']).""')")

    '                Else

    '                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
    '                        sw.Append("," & vbCrLf)
    '                        sw.Append("  " & fld.Name.ToLower & "='"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_val']).""'")
    '                    Else

    '                        sw.Append("," & vbCrLf)
    '                        sw.Append("  " & fld.Name.ToLower & "='"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "']).""'")


    '                        If UCase(ft.Name) = "FILE" Then
    '                            sw.Append("," & fld.Name.ToLower & "_ext=")
    '                            sw.Append("'"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_EXT']).""' ")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next
    '    sw.Append("  where  " & os.Name.ToLower & "id = g2b('"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "id']).""') "";")

    '    sw.Append(vbCrLf & " 	if ($conn_to->query($sql) === TRUE) {")
    '    sw.Append(vbCrLf & "        echo( 'updated');")
    '    sw.Append(vbCrLf & "    }")
    '    sw.Append(vbCrLf & "    else {")
    '    sw.Append(vbCrLf & "     echo( 'Error: '. $conn_to->error.'  sql:'.$sql);")
    '    sw.Append(vbCrLf & "    }")
    '    sw.Append(vbCrLf & "}")



    '    sw.Append(vbCrLf & "}")
    '    sw.Append(vbCrLf & "} // num_rows")
    '    sw.Append(vbCrLf & "else {")
    '    sw.Append(vbCrLf & "        echo 'No results';")
    '    sw.Append(vbCrLf & "}")



    '    sw.Append(vbCrLf & "$conn_from->close();")
    '    sw.Append(vbCrLf & "$conn_to->close();")
    '    sw.Append(vbCrLf & "}")




    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  copy photo

    '    For i = 1 To OT.PART.Count
    '        os = OT.PART.Item(i)
    '        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy And os.Name.ToLower.Contains("_photo") Then

    '            Exit For
    '        End If
    '        os = Nothing
    '    Next
    '    If os Is Nothing Then Return ""


    '    sw.Append(vbCrLf & "        function Import" & OT.Name & "_photo(){")
    '    sw.Append(vbCrLf & "      global    $server_from,$user_from,$password_from,$db_from,$firm_from,$server_to,$user_to,$password_to,$db_to;")
    '    sw.Append(vbCrLf & "$conn_from = new mysqli($server_from, $user_from, $password_from,$db_from);")
    '    sw.Append(vbCrLf & "$conn_from ->set_charset('utf8');")


    '    sw.Append(vbCrLf & "if (mysqli_connect_errno()) {")
    '    sw.Append(vbCrLf & "  exit('Connect failed: '. mysqli_connect_error());")
    '    sw.Append(vbCrLf & "}")

    '    sw.Append(vbCrLf & "$conn_to = new mysqli($server_to, $user_to, $password_to,$db_to);")
    '    sw.Append(vbCrLf & "$conn_to ->set_charset('utf8');")

    '    sw.Append(vbCrLf & "if (mysqli_connect_errno()) {")
    '    sw.Append(vbCrLf & "  exit('Connect failed: '. mysqli_connect_error());")
    '    sw.Append(vbCrLf & "}")



    '    sw.Append(vbCrLf & "$sql = ""select * from v_auto" & os.Name.ToLower & " where instanceid in (select instanceid from " & osRoot.Name.ToLower & " where " & osRoot.Name.ToLower & "_firmid_id='"".$firm_from.""')""; ")


    '    sw.Append(vbCrLf & "$result = $conn_from->query($sql);")
    '    sw.Append(vbCrLf & "$cnt=0;")

    '    sw.Append(vbCrLf & "if ($result->num_rows > 0) {")


    '    sw.Append(vbCrLf & "  while($row = $result->fetch_assoc()) {")
    '    sw.Append(vbCrLf & "    $cnt=$cnt+1;")
    '    sw.Append(vbCrLf & "    echo '<br/> ('.$cnt.' of '.$result->num_rows.') ' ;//id: '. $row['id']. ' instanceid: '.$row['instanceid'];")

    '    sw.Append(vbCrLf & "	$id=$row['id'];")
    '    sw.Append(vbCrLf & "	$instanceid=$row['instanceid'];")

    '    sw.Append(vbCrLf & "	$sql_test = ""select count(*) cnt from instance where instanceid=g2b('"".$instanceid.""')""; ")

    '    sw.Append(vbCrLf & "	$result_inst = $conn_to->query($sql_test);")
    '    sw.Append(vbCrLf & "	if ($result_inst->num_rows !=0 ) {")
    '    sw.Append(vbCrLf & "	    $row_i = $result_inst->fetch_assoc();")
    '    sw.Append(vbCrLf & "		if($row_i !=null){")

    '    sw.Append(vbCrLf & "			if ($row_i['cnt']==0){")
    '    sw.Append(vbCrLf & "				$id=$row['id'];")
    '    sw.Append(vbCrLf & "				$instanceid=$row['instanceid'];")

    '    sw.Append(vbCrLf & "				$sql_ins = ""INSERT INTO `instance` (`instanceid`, `objtype`, `name`)VALUES (g2b('"".$instanceid .""'), '" & OT.Name & "', '"".$conn_to->real_escape_string('???').""')""; ")
    '    sw.Append(vbCrLf & "				// Performs the $sql query on the server to insert the values")
    '    sw.Append(vbCrLf & "				if ($conn_to->query($sql_ins) === TRUE) {")
    '    sw.Append(vbCrLf & "				  echo 'instance created';")
    '    sw.Append(vbCrLf & "				}")
    '    sw.Append(vbCrLf & "				else {")
    '    sw.Append(vbCrLf & "				 echo 'Error: '. $conn_to->error;")
    '    sw.Append(vbCrLf & "				}")
    '    sw.Append(vbCrLf & "			}")
    '    sw.Append(vbCrLf & "		}")
    '    sw.Append(vbCrLf & "	}")

    '    sw.Append(vbCrLf & "	$sql_test = ""select * from " & os.Name.ToLower & " where " & os.Name.ToLower & "id=g2b('"".$id .""')""; ")

    '    sw.Append(vbCrLf & "	$result_inst = $conn_to->query($sql_test);")
    '    sw.Append(vbCrLf & "	if ($result_inst->num_rows == 0) {")

    '    sw.Append(vbCrLf & "           echo( ' inserting... ');")
    '    sw.Append("                 $sql="" insert into   " & os.Name & vbCrLf & " (instanceid,  changestamp, " & os.Name & "ID ")

    '    os.FIELD.Sort = "sequence"
    '    For i = 1 To os.FIELD.Count
    '        fld = os.FIELD.Item(i)
    '        If fld.TheStyle.IndexOf("lock") < 0 Then
    '            ft = fld.FieldType
    '            If (ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy) Then

    '                sw.Append(",/*" & (i + 3).ToString & "*/ " & fld.Name.ToLower)

    '                If UCase(ft.Name) = "FILE" Then
    '                    sw.Append("," & fld.Name.ToLower & "_ext")
    '                End If

    '            End If
    '        End If
    '    Next

    '    sw.Append(" ) values " & "(g2b('"".$conn_to->real_escape_string($row['instanceid']).""'),'"".$conn_to->real_escape_string($row['changestamp']).""', g2b('"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "id']).""') ")





    '    os.FIELD.Sort = "sequence"
    '    For i = 1 To os.FIELD.Count
    '        fld = os.FIELD.Item(i)
    '        ft = fld.FieldType
    '        If fld.TheStyle.IndexOf("lock") < 0 Then
    '            If (ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy) Then

    '                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka And ft.Name <> "MULTIREF" Then
    '                    sw.Append(",/*" & (i + 3).ToString & "*/" & vbCrLf & " g2b('"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_id']).""')")
    '                Else

    '                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
    '                        sw.Append(",/*" & (i + 3).ToString & "*/" & vbCrLf & " '"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_val']).""'")
    '                    Else
    '                        sw.Append(",/*" & (i + 3).ToString & "*/" & vbCrLf & " '"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "']).""'")


    '                        If UCase(ft.Name) = "FILE" Then
    '                            sw.Append(",/*" & (i + 3).ToString & "*/" & vbCrLf & "  '"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_ext']).""'")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next

    '    sw.Append(" )"" ;")


    '    sw.Append(vbCrLf & " 	if ($conn_to->query($sql) === TRUE) {")
    '    sw.Append(vbCrLf & "        echo( 'inserted');")
    '    sw.Append(vbCrLf & "     }")
    '    sw.Append(vbCrLf & "    else {")
    '    sw.Append(vbCrLf & "        echo( 'Error: '. $conn_to->error.'  sql:'.$sql);")
    '    sw.Append(vbCrLf & "    }  ")
    '    sw.Append(vbCrLf & "}else{")

    '    sw.Append(vbCrLf & " echo( ' updating... ');")
    '    sw.Append(vbCrLf)
    '    sw.Append("$sql="" update  " & os.Name & " set changestamp='"".$conn_to->real_escape_string($row['changestamp']).""'")





    '    os.FIELD.Sort = "sequence"
    '    For i = 1 To os.FIELD.Count
    '        fld = os.FIELD.Item(i)
    '        ft = fld.FieldType
    '        If fld.TheStyle.IndexOf("lock") < 0 Then
    '            If (ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy) Then

    '                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka And ft.Name <> "MULTIREF" Then
    '                    sw.Append("," & vbCrLf)
    '                    sw.Append("  " & fld.Name.ToLower & "=g2b('"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_id']).""')")

    '                Else

    '                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
    '                        sw.Append("," & vbCrLf)
    '                        sw.Append("  " & fld.Name.ToLower & "='"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_val']).""'")
    '                    Else

    '                        sw.Append("," & vbCrLf)
    '                        sw.Append("  " & fld.Name.ToLower & "='"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "']).""'")


    '                        If UCase(ft.Name) = "FILE" Then
    '                            sw.Append("," & fld.Name.ToLower & "_ext=")
    '                            sw.Append("'"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "_" & fld.Name.ToLower & "_EXT']).""' ")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next
    '    sw.Append("  where  " & os.Name.ToLower & "id = g2b('"".$conn_to->real_escape_string($row['" & os.Name.ToLower & "id']).""') "";")

    '    sw.Append(vbCrLf & " 	if ($conn_to->query($sql) === TRUE) {")
    '    sw.Append(vbCrLf & "        echo( 'updated');")
    '    sw.Append(vbCrLf & "    }")
    '    sw.Append(vbCrLf & "    else {")
    '    sw.Append(vbCrLf & "     echo( 'Error: '. $conn_to->error.'  sql:'.$sql);")
    '    sw.Append(vbCrLf & "    }")
    '    sw.Append(vbCrLf & "}")



    '    sw.Append(vbCrLf & "}")
    '    sw.Append(vbCrLf & "} // num_rows")
    '    sw.Append(vbCrLf & "else {")
    '    sw.Append(vbCrLf & "        echo 'No results';")
    '    sw.Append(vbCrLf & "}")



    '    sw.Append(vbCrLf & "$conn_from->close();")
    '    sw.Append(vbCrLf & "$conn_to->close();")
    '    sw.Append(vbCrLf & "}")

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    '    Return sw.ToString()



    'End Function

    Private Function GetIconName(ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal tabname As String) As String
        Dim i As Integer
        Dim iconName As String = ""
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        P.FIELD.Sort = "sequence"

        iconName = P.partIconCls
   

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            If fld.TabName.ToLower = tabname.ToLower Then
                If fld.shablonBrief.Contains("icon-") Then
                    iconName = fld.shablonBrief
                    Return iconName
                Else
                    Return iconName
                End If
            End If
        Next
        Return iconName
    End Function

    Private Sub TypeMaker(ByVal ID As Guid, ByVal objmode As String, ByVal UseMartService As Boolean)

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim P As MTZMetaModel.MTZMetaModel.PART
        ot = model.OBJECTTYPE.Item(ID.ToString())

        Dim i As Integer
        Dim sw As StringBuilder
        Dim isfirst As Boolean = True

        Dim mainPartName As String
        Dim mainPart As String
        Dim mainPartObj As MTZMetaModel.MTZMetaModel.PART = Nothing
        Dim tabcol As Collection
        Dim tn As String
        Dim ii As Integer

        mainPartName = ""
        mainPart = ""

        ot.PART.Sort = "sequence"
        PartMake_CI(ot.PART)
        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)

            If LATIR2Framework.ObjectHelper.IsPresent(P, objmode) Then
                If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                    If Not UseMartService Then
                        If mainPartName = "" And P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                            mainPartName = "int_" & P.Name.ToLower & "_" & objmode
                            mainPart = P.Name.ToLower
                            mainPartObj = P
                        End If
                    End If

                    sw = New StringBuilder
                    sw.Append(vbCrLf & "Ext.require([")
                    sw.Append(vbCrLf & "'Ext.form.*'")
                    sw.Append(vbCrLf & "]);")

                    If mainPart = P.Name.ToLower Then
                        sw.Append(vbCrLf & PartMake_InterfaceJS(ot, P, objmode, UseMartService, True))
                    Else
                        sw.Append(vbCrLf & PartMake_InterfaceJS(ot, P, objmode, UseMartService, False))
                    End If


                    sw.Append(vbCrLf & "function DefineForms_" & P.Name.ToLower() & "_" & objmode & "(){" & vbCrLf)
                    sw.Append(vbCrLf & PartMake_FormPanelJS(ot, P, objmode, UseMartService))
                    sw.Append(vbCrLf & "}")
                    Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "_js\", P.Name.ToLower() & "_" & objmode & ".js")
                End If
            End If
        Next


        sw = New StringBuilder


        sw.Append(vbCrLf & "Ext.require([")
        sw.Append(vbCrLf & "'Ext.form.*'")
        sw.Append(vbCrLf & "]);")


        sw.Append(vbCrLf & "  " & ot.Name.ToLower() & "_" & objmode & "= null;")
        sw.Append(vbCrLf & "function " & ot.Name & "_Panel_" & objmode & "(objectID, RootPanel, selection){ " & vbCrLf)

        If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "        // Prepare document for edit")
            sw.Append(vbCrLf & "        Ext.Ajax.request(")
            sw.Append(vbCrLf & "        	{")
            sw.Append(vbCrLf & "        		url:rootURL+'index.php/app/PrepareDocument',")
            sw.Append(vbCrLf & "        		method:'POST',")
            sw.Append(vbCrLf & "        		params:{")
            sw.Append(vbCrLf & "        			typename:'" + ot.Name.ToLower + "',")
            sw.Append(vbCrLf & "        			documentid:objectID")
            sw.Append(vbCrLf & "        		}")
            sw.Append(vbCrLf & "        	}")
            sw.Append(vbCrLf & "        );")
        End If

        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            If LATIR2Framework.ObjectHelper.IsPresent(P, objmode) Then
                If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                    sw.Append(vbCrLf & PartMake_JSStore(P, UseMartService))
                End If
            End If
        Next


        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            If LATIR2Framework.ObjectHelper.IsPresent(P, objmode) Then
                If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                    sw.Append(vbCrLf & "          DefineForms_" & P.Name.ToLower & "_" & objmode & "();")
                End If
            End If
        Next


        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            If LATIR2Framework.ObjectHelper.IsPresent(P, objmode) Then
                If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                    If Not UseMartService Then

                        'If mainPartName = "" And P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                        '    mainPartName = "int_" & P.Name.ToLower & "_" & objmode
                        '    mainPart = P.Name.ToLower
                        'End If

                        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                            sw.Append(vbCrLf & "  var   int_" & P.Name.ToLower & "_" & objmode & "     = DefineInterface_" & P.Name.ToLower & "_" & objmode & "('int_" & P.Name.ToLower & "', treestore_" & P.Name.ToLower() & ");")
                        Else

                            If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then

                                tabcol = New Collection
                                P.FIELD.Sort = "sequence"

                                For ii = 1 To P.FIELD.Count
                                    If LATIR2Framework.ObjectHelper.IsFieldPresent(P, P.FIELD.Item(ii).ID.ToString, objmode) And Not P.FIELD.Item(ii).TheStyle.Contains("hidden") Then
                                        If P.FIELD.Item(ii).TabName <> "" Then
                                            tn = P.FIELD.Item(ii).TabName
                                            Try
                                                tabcol.Add(tn, tn)
                                            Catch ex As Exception
                                                ' non unique
                                            End Try
                                        End If


                                    End If
                                Next
                                If mainPart = P.Name.ToLower Then
                                    sw.Append(vbCrLf & "     var   int_" & P.Name.ToLower & "_" & objmode & "     =      DefineInterface_" & P.Name.ToLower & "_" & objmode & "('int_" & P.Name.ToLower & "',store_" & P.Name.ToLower & ", selection);")
                                Else
                                    sw.Append(vbCrLf & "     var   int_" & P.Name.ToLower & "_" & objmode & "     =      DefineInterface_" & P.Name.ToLower & "_" & objmode & "('int_" & P.Name.ToLower & "',store_" & P.Name.ToLower & ");")
                                End If
                                If tabcol.Count > 0 Then
                                    For ii = 1 To tabcol.Count
                                        sw.Append(vbCrLf & "     var   int_" & P.Name.ToLower & "_" & objmode & "_tab" & ii.ToString() & "     =      DefineInterface_" & P.Name.ToLower & "_" & objmode & "_tab" & ii.ToString() & "('int_" & P.Name.ToLower & "_tab" & ii.ToString() & "',store_" & P.Name.ToLower & ");")
                                    Next

                                End If
                            Else
                                If mainPart = P.Name.ToLower Then
                                    sw.Append(vbCrLf & "     var   int_" & P.Name.ToLower & "_" & objmode & "     =      DefineInterface_" & P.Name.ToLower & "_" & objmode & "('int_" & P.Name.ToLower & "',store_" & P.Name.ToLower & ", selection);")
                                Else
                                    sw.Append(vbCrLf & "     var   int_" & P.Name.ToLower & "_" & objmode & "     =      DefineInterface_" & P.Name.ToLower & "_" & objmode & "('int_" & P.Name.ToLower & "',store_" & P.Name.ToLower & ");")
                                End If
                            End If








                        End If
                    Else
                        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                            sw.Append(vbCrLf & "  var   int_" & P.Name.ToLower & "_" & objmode & "     = DefineInterface_" & P.Name.ToLower & "_" & objmode & "('int_" & P.Name.ToLower & "', treestore_mart_" & P.Name.ToLower() & ");")
                        Else
                            sw.Append(vbCrLf & "     var   int_" & P.Name.ToLower & "_" & objmode & "     =      DefineInterface_" & P.Name.ToLower & "_" & objmode & "('int_" & P.Name.ToLower & "',store_mart_" & P.Name.ToLower & ");")

                        End If
                    End If

                End If
            End If

        Next


        ot.PART.Sort = "sequence"
        '  добавляем комбобоkc для выбора вкладки
        If ot.PART.Count > 10 Then

            sw.Append(vbCrLf & "	var store_" + ot.Name.ToLower + "_parts = Ext.create('Ext.data.ArrayStore', {")
            sw.Append(vbCrLf & "fields: ['name','tabname'		],")
            sw.Append(vbCrLf & "data : [")
            isfirst = True
            For i = 1 To ot.PART.Count
                P = ot.PART.Item(i)
                If LATIR2Framework.ObjectHelper.IsPresent(P, objmode) Then
                    'If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                    If Not isfirst Then
                        sw.Append(vbCrLf & ",")
                    End If
                    isfirst = False
                    sw.Append(vbCrLf & "	['" + P.Caption + "', 'tab_" + P.Name.ToLower() + "']")
                    'End If
                End If
            Next

            sw.Append(vbCrLf & "]")
            sw.Append(vbCrLf & "});")
        End If



        sw.Append(vbCrLf & "     " & ot.Name.ToLower() & "_" & objmode & "= Ext.create('Ext.form.Panel', {")
        sw.Append(vbCrLf & "      id: '" + ot.Name.ToLower() + "',")
        sw.Append(vbCrLf & "      layout:'fit',")

        sw.Append(vbCrLf & "      fieldDefaults: {")
        sw.Append(vbCrLf & "          labelAlign:             'top',")
        sw.Append(vbCrLf & "          msgTarget:              'side'")
        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "        defaults: {")
        sw.Append(vbCrLf & "        anchor:'100%'")
        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "")
        'If ot.objIconCls <> "" Then
        '    sw.Append(vbCrLf & "        iconCls:'" & ot.objIconCls & "',")
        'End If
        sw.Append(vbCrLf & "        instanceid:objectID,")


        sw.Append(vbCrLf & "                onCommit: function(){")
        If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "        		// Commit document changes")
            sw.Append(vbCrLf & "        			Ext.Ajax.request(")
            sw.Append(vbCrLf & "        				{")
            sw.Append(vbCrLf & "        					url:rootURL+'index.php/app/CommitDocument',")
            sw.Append(vbCrLf & "                            method:  'POST',")
            sw.Append(vbCrLf & "        					params:{")
            sw.Append(vbCrLf & "                                typename:  '" + ot.Name.ToLower() + "',")
            sw.Append(vbCrLf & "                                documentid: objectID")
            sw.Append(vbCrLf & "        					}")
            sw.Append(vbCrLf & "        					,")
            sw.Append(vbCrLf & "        					success: function(response){")
            sw.Append(vbCrLf & "        						var text = response.responseText;")
            sw.Append(vbCrLf & "        						//alert(text);")
            sw.Append(vbCrLf & "        						var res =Ext.decode(text);")
            sw.Append(vbCrLf & "        						if(res.success==false){")
            sw.Append(vbCrLf & "        							Ext.MessageBox.show({")
            sw.Append(vbCrLf & "        								title:  'Ошибка',")
            sw.Append(vbCrLf & "                                        msg:        res.msg,")
            sw.Append(vbCrLf & "                                        buttons : Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "                                        Icon : Ext.MessageBox.ERROR()")
            sw.Append(vbCrLf & "        								});")
            sw.Append(vbCrLf & "        								p1_saved=false;")
            sw.Append(vbCrLf & "        						}else{")
            sw.Append(vbCrLf & "        							if(typeof(" + ot.Name.ToLower() + "_" & objmode & ".onButtonCancel) == 'function') " + ot.Name.ToLower() + "_" & objmode & ".onButtonCancel();")
            'sw.Append(vbCrLf & "        							Ext.Ajax.request(")
            'sw.Append(vbCrLf & "        								{")
            'sw.Append(vbCrLf & "        									url:rootURL+'index.php/app/DropTempDocument',")
            'sw.Append(vbCrLf & "                                             method:     'POST',")
            'sw.Append(vbCrLf & "        									params:{")
            'sw.Append(vbCrLf & "                                            typename:   '" + ot.Name.ToLower() + "',")
            'sw.Append(vbCrLf & "                                            documentid: objectID")
            'sw.Append(vbCrLf & "        									},")
            'sw.Append(vbCrLf & "        									success: function(response){")
            'sw.Append(vbCrLf & "        										var text = response.responseText;")
            'sw.Append(vbCrLf & "        										//alert(text);")
            'sw.Append(vbCrLf & "        										var res =Ext.decode(text);")
            'sw.Append(vbCrLf & "        										if(res.success==false){")
            'sw.Append(vbCrLf & "        											// ...")
            'sw.Append(vbCrLf & "        										}")
            'sw.Append(vbCrLf & "        									}")
            'sw.Append(vbCrLf & "        								}")
            'sw.Append(vbCrLf & "        							);")
            sw.Append(vbCrLf & "        						}")
            sw.Append(vbCrLf & "        					}")
            sw.Append(vbCrLf & "        				}")
            sw.Append(vbCrLf & "        			);")
        End If
        sw.Append(vbCrLf & "        		},")

        sw.Append(vbCrLf & "        		onButtonOk: function()")
        sw.Append(vbCrLf & "        		{")
        sw.Append(vbCrLf & "        			var me = this;")


        tabcol = New Collection
        If Not mainPartObj Is Nothing Then
            P = mainPartObj
            P.FIELD.Sort = "sequence"

            For ii = 1 To P.FIELD.Count
                If LATIR2Framework.ObjectHelper.IsFieldPresent(P, P.FIELD.Item(ii).ID.ToString, objmode) And Not P.FIELD.Item(ii).TheStyle.Contains("hidden") Then
                    If P.FIELD.Item(ii).TabName <> "" Then
                        tn = P.FIELD.Item(ii).TabName
                        Try
                            tabcol.Add(tn, tn)
                        Catch ex As Exception
                            ' non unique
                        End Try
                    End If


                End If
            Next
        End If
        For ii = 1 To tabcol.Count
            sw.Append(vbCrLf & "        	    " + mainPartName + "_tab" + ii.ToString() + ".doSave( );")
        Next

        If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            If mainPartName <> "" Then
                sw.Append(vbCrLf & "        	    " + mainPartName + ".doSave( me.onCommit);")
            Else
                sw.Append(vbCrLf & "        		me.onCommit();")
                sw.Append(vbCrLf & "        		me.close();")
            End If
        Else
            If mainPartName <> "" Then
                sw.Append(vbCrLf & "        	    " + mainPartName + ".doSave( me.onCommit);")
            End If
        End If


        sw.Append(vbCrLf & "        		},")
        sw.Append(vbCrLf & "        		onButtonCancel: function()")
        sw.Append(vbCrLf & "        		{")

        If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "        			Ext.Ajax.request(")
            sw.Append(vbCrLf & "        				{")
            sw.Append(vbCrLf & "        					url:rootURL+'index.php/app/DropTempDocument',")
            sw.Append(vbCrLf & "                            method:         'POST',")
            sw.Append(vbCrLf & "        					params:{")
            sw.Append(vbCrLf & "                            typename:       '" + ot.Name.ToLower() + "',")
            sw.Append(vbCrLf & "                            documentid:     objectID")
            sw.Append(vbCrLf & "        					},")
            sw.Append(vbCrLf & "        					success: function(response){")
            sw.Append(vbCrLf & "        						var text = response.responseText;")
            sw.Append(vbCrLf & "        						//alert(text);")
            sw.Append(vbCrLf & "        						var res =Ext.decode(text);")
            sw.Append(vbCrLf & "        						if(res.success==false){")
            sw.Append(vbCrLf & "        							// ...")
            sw.Append(vbCrLf & "        						}")
            sw.Append(vbCrLf & "        					}")
            sw.Append(vbCrLf & "        				}")
            sw.Append(vbCrLf & "        			);")
        End If

        sw.Append(vbCrLf & "        		},")



        sw.Append(vbCrLf & "        canClose: function(){")
        If mainPartName <> "" Then
            sw.Append(vbCrLf & "        	return " + mainPartName + ".canClose();")
        Else
            sw.Append(vbCrLf & "        	return true;")
        End If
        sw.Append(vbCrLf & "        },")

        If ot.PART.Count > 10 Then
            sw.Append(vbCrLf & "         dockedItems: [{")
            sw.Append(vbCrLf & "            xtype:  'toolbar',")
            sw.Append(vbCrLf & "                items: [{")
            sw.Append(vbCrLf & "                    xtype:  'combobox',")
            sw.Append(vbCrLf & "					title: 'Быстрый переход',")
            sw.Append(vbCrLf & "					hideLabel: false,")
            sw.Append(vbCrLf & "                    store:  store_" + ot.Name.ToLower + "_parts,")
            sw.Append(vbCrLf & "                    displayField: 'name',")

            sw.Append(vbCrLf & "					typeAhead: true,")
            sw.Append(vbCrLf & "					//mode: 'local',")
            sw.Append(vbCrLf & "                    triggerAction:  'all',")
            sw.Append(vbCrLf & "                    emptyText:  'Выбрать вкладку',")
            sw.Append(vbCrLf & "					//selectOnFocus:true,")
            sw.Append(vbCrLf & "					width:250,")
            sw.Append(vbCrLf & "					   listeners: {")
            sw.Append(vbCrLf & "							select: function(combo, selection) {")
            sw.Append(vbCrLf & "								var post = selection[0];")
            sw.Append(vbCrLf & "								var tabpanel=" & ot.Name.ToLower & "_" & objmode & ".getComponent('tabs_" & ot.Name.ToLower() + "');")
            sw.Append(vbCrLf & "								if (post) {")
            sw.Append(vbCrLf & "									tabpanel.setActiveTab(")
            sw.Append(vbCrLf & "										tabpanel.getComponent(post.get('tabname'))")
            sw.Append(vbCrLf & "									);")
            sw.Append(vbCrLf & "								}")
            sw.Append(vbCrLf & "							}")
            sw.Append(vbCrLf & "						}")
            sw.Append(vbCrLf & "				}]")
            sw.Append(vbCrLf & "            }],")

        End If

        sw.Append(vbCrLf & "        items: [{")
        sw.Append(vbCrLf & "            xtype:'tabpanel',")
        sw.Append(vbCrLf & "            itemId:'tabs_" & ot.Name.ToLower() & "',")
        sw.Append(vbCrLf & "            activeTab: 0,")
        sw.Append(vbCrLf & "            layout: 'fit',")
        sw.Append(vbCrLf & "            tabPosition:'top',")  ' bottom
        sw.Append(vbCrLf & "            border:0,")  ''''
        sw.Append(vbCrLf & "            items:[   // tabs")

        isfirst = True
        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            If LATIR2Framework.ObjectHelper.IsPresent(P, objmode) Then
                If Not isfirst Then
                    sw.Append(vbCrLf & ",")
                End If
                isfirst = False


                If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                    sw.Append(vbCrLf & "            { // begin part tab")
                    sw.Append(vbCrLf & "            xtype:'panel',")
                    sw.Append(vbCrLf & "            border:0,")  ''''
                    sw.Append(vbCrLf & "            title: '" & P.Caption & "',")
                    sw.Append(vbCrLf & "            layout:'fit',")
                    sw.Append(vbCrLf & "            itemId:'tab_" & P.Name.ToLower() & "',")
                    'If P.shablonBrief <> "" Then
                    '    sw.Append(vbCrLf & "            iconCls:'" + P.shablonBrief + "',")
                    'End If

                    sw.Append(vbCrLf & "            items:[ // panel on tab ")
                    sw.Append(vbCrLf & P.the_Comment)

                ElseIf P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then


                    tabcol = New Collection
                    P.FIELD.Sort = "sequence"

                    For ii = 1 To P.FIELD.Count
                        If LATIR2Framework.ObjectHelper.IsFieldPresent(P, P.FIELD.Item(ii).ID.ToString, objmode) And Not P.FIELD.Item(ii).TheStyle.Contains("hidden") Then
                            If P.FIELD.Item(ii).TabName <> "" Then
                                tn = P.FIELD.Item(ii).TabName
                                Try
                                    tabcol.Add(tn, tn)
                                Catch ex As Exception
                                    ' non unique
                                End Try
                            End If


                        End If
                    Next
                    sw.Append(vbCrLf & "            { // begin part tab")
                    sw.Append(vbCrLf & "            xtype:'panel',")
                    sw.Append(vbCrLf & "            border:0,")
                    sw.Append(vbCrLf & "            title: '" & P.Caption & "',")
                    sw.Append(vbCrLf & "            layout:'fit',")
                    sw.Append(vbCrLf & "            itemId:'tab_" & P.Name.ToLower() & "',")
                    'If P.shablonBrief <> "" Then
                    '    sw.Append(vbCrLf & "            iconCls:'" + P.shablonBrief + "',")
                    'End If
                    sw.Append(vbCrLf & "            items:[ // panel on tab ")
                    sw.Append(vbCrLf & "int_" & P.Name.ToLower() & "_" & objmode & "")

                    If tabcol.Count > 0 Then
                        For ii = 1 To tabcol.Count
                            sw.Append(vbCrLf & "        ] // panel on tab  form or grid")

                            sw.Append(vbCrLf & "      } // end tab")
                            sw.Append(vbCrLf & "            ,{ // begin part tab " & ii.ToString)
                            sw.Append(vbCrLf & "            xtype:'panel',")
                            sw.Append(vbCrLf & "            border:0,")
                            sw.Append(vbCrLf & "            title: '" & tabcol.Item(ii) & "',")
                            sw.Append(vbCrLf & "            layout:'fit',")
                            sw.Append(vbCrLf & "            itemId:'tab_" & P.Name.ToLower() & "_tab" & ii.ToString() & "',")
                            Dim IconName As String
                            IconName = GetIconName(P, tabcol.Item(ii))
                            'If IconName <> "" Then
                            '    sw.Append(vbCrLf & "            iconCls:'" + IconName + "',")
                            'End If
                            sw.Append(vbCrLf & "            items:[ // panel on tab ")
                            sw.Append(vbCrLf & "int_" & P.Name.ToLower() & "_" & objmode & "_tab" & ii.ToString())
                        Next

                    End If



                ElseIf P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                    sw.Append(vbCrLf & "            { // begin part tab")
                    sw.Append(vbCrLf & "            xtype:'panel',")
                    sw.Append(vbCrLf & "            border:0,")
                    sw.Append(vbCrLf & "            title: '" & P.Caption & "',")
                    sw.Append(vbCrLf & "            layout:'fit',")
                    sw.Append(vbCrLf & "            itemId:'tab_" & P.Name.ToLower() & "',")
                    'If P.shablonBrief <> "" Then
                    '    sw.Append(vbCrLf & "            iconCls:'" + P.shablonBrief + "',")
                    'End If
                    sw.Append(vbCrLf & "            items:[ // panel on tab ")
                    sw.Append(vbCrLf & "int_" & P.Name.ToLower() & "_" & objmode & "")

                Else
                    sw.Append(vbCrLf & "            { // begin part tab")
                    sw.Append(vbCrLf & "            xtype:'panel',")
                    sw.Append(vbCrLf & "            border:0,")
                    sw.Append(vbCrLf & "            title: '" & P.Caption & "',")
                    sw.Append(vbCrLf & "            layout:'fit',")
                    sw.Append(vbCrLf & "            itemId:'tab_" & P.Name.ToLower() & "',")
                    'If P.shablonBrief <> "" Then
                    '    sw.Append(vbCrLf & "            iconCls:'" + P.shablonBrief + "',")
                    'End If
                    sw.Append(vbCrLf & "            items:[ // panel on tab ")
                    sw.Append(vbCrLf & "int_" & P.Name.ToLower() & "_" & objmode & "")

                End If

                sw.Append(vbCrLf & "        ] // panel on tab  form or grid")

                sw.Append(vbCrLf & "      } // end tab")
            End If
        Next

        sw.Append(vbCrLf & "    ] // part tabs")



        sw.Append(vbCrLf & "    }] // tabpanel")
        sw.Append(vbCrLf & "    }); //Ext.Create")

        sw.Append(vbCrLf & "    if(RootPanel==true){")
        sw.Append(vbCrLf & "       " & ot.Name.ToLower() & "_" & objmode & ".closable= true;")
        sw.Append(vbCrLf & "       " & ot.Name.ToLower() & "_" & objmode & ".title= '" & ot.the_Comment & "';")
        sw.Append(vbCrLf & "       " & ot.Name.ToLower() & "_" & objmode & ".frame= true;")

        sw.Append(vbCrLf & "    }else{")

        sw.Append(vbCrLf & "       " & ot.Name.ToLower() & "_" & objmode & ".closable= false;")
        sw.Append(vbCrLf & "       " & ot.Name.ToLower() & "_" & objmode & ".title= '';")
        sw.Append(vbCrLf & "       " & ot.Name.ToLower() & "_" & objmode & ".frame= false;")



        sw.Append(vbCrLf & "    }")

        '''' load data to store
        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            If LATIR2Framework.ObjectHelper.IsPresent(P, objmode) Then
                If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                    If Not UseMartService Then
                        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                            sw.Append(vbCrLf & "   store_" & P.Name.ToLower() & ".on('load', function() {")

                            sw.Append(vbCrLf & "        if(store_" & P.Name.ToLower() & ".count()==0){")
                            sw.Append(vbCrLf & "            store_" & P.Name.ToLower() & ".insert(0, new model_" & P.Name.ToLower() & "());")
                            sw.Append(vbCrLf & "        }")
                            sw.Append(vbCrLf & "        record= store_" & P.Name.ToLower() & ".getAt(0);")
                            sw.Append(vbCrLf & "        record['instanceid']=objectID;")

                            sw.Append(vbCrLf & "   int_" & P.Name.ToLower() & "_" & objmode & ".setActiveRecord(record,objectID);	")



                            tabcol = New Collection
                            P.FIELD.Sort = "sequence"

                            For ii = 1 To P.FIELD.Count
                                If LATIR2Framework.ObjectHelper.IsFieldPresent(P, P.FIELD.Item(ii).ID.ToString, objmode) And Not P.FIELD.Item(ii).TheStyle.Contains("hidden") Then
                                    If P.FIELD.Item(ii).TabName <> "" Then
                                        tn = P.FIELD.Item(ii).TabName
                                        Try
                                            tabcol.Add(tn, tn)
                                        Catch ex As Exception
                                            ' non unique
                                        End Try
                                    End If


                                End If
                            Next
                            If tabcol.Count > 0 Then
                                For ii = 1 To tabcol.Count
                                    sw.Append(vbCrLf & "   int_" & P.Name.ToLower() & "_" & objmode & "_tab" & ii.ToString & ".setActiveRecord(record,objectID);	")
                                Next
                            End If

                            sw.Append(vbCrLf & "   });")
                            sw.Append(vbCrLf & "       store_" & P.Name.ToLower() & ".load( {params:{ instanceid:objectID} }  );")






                        ElseIf P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                            sw.Append(vbCrLf & "   int_" & P.Name.ToLower() & "_" & objmode & ".instanceid=objectID;	")
                        Else
                            sw.Append(vbCrLf & "   int_" & P.Name.ToLower() & "_" & objmode & ".instanceid=objectID;	")
                            sw.Append(vbCrLf & "       store_" & P.Name.ToLower() & ".load(  {params:{ instanceid:objectID} } );")
                        End If
                    Else  ' MART
                        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                            sw.Append(vbCrLf & "   store_mart_" & P.Name.ToLower() & ".on('load', function() {")


                            sw.Append(vbCrLf & "        record= store_mart_" & P.Name.ToLower() & ".getAt(0);")
                            sw.Append(vbCrLf & "        record['instanceid']=objectID;")

                            sw.Append(vbCrLf & "   int_" & P.Name.ToLower() & "_" & objmode & ".setActiveRecord(record,objectID);	")
                            sw.Append(vbCrLf & "   });")

                            sw.Append(vbCrLf & "       store_mart_" & P.Name.ToLower() & ".load( {params:{ instanceid:objectID} }  );")
                        ElseIf P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                            sw.Append(vbCrLf & "   int_" & P.Name.ToLower() & "_" & objmode & ".instanceid=objectID;	")
                        Else
                            sw.Append(vbCrLf & "   int_" & P.Name.ToLower() & "_" & objmode & ".instanceid=objectID;	")
                            sw.Append(vbCrLf & "       store_mart_" & P.Name.ToLower() & ".load(  {params:{ instanceid:objectID} } );")
                        End If
                    End If

                End If
            End If
        Next

        sw.Append(vbCrLf & "    return " & ot.Name.ToLower() & "_" & objmode & ";")
        sw.Append(vbCrLf & "}")

        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "_js\", ot.Name.ToLower() & "_" & objmode & ".js")


    End Sub

    Private Sub Tool_WriteFile(ByVal s As String, ByVal path As String, ByVal fname As String)
        Dim p As String
        p = path
        If Not p.EndsWith("\") Then
            p += "\"
        End If
        Dim di As DirectoryInfo
        di = New DirectoryInfo(p)

        If Not di.Exists Then
            di.Create()
        End If

        File.WriteAllText(p & fname, s, System.Text.Encoding.UTF8)
        Dim jsc As Yahoo.Yui.Compressor.JavaScriptCompressor

        If fname.Contains(".js") Then
            Try
                jsc = New Yahoo.Yui.Compressor.JavaScriptCompressor
                s = jsc.Compress(s)
                p += "comp\"

                di = New DirectoryInfo(p)

                If Not di.Exists Then
                    di.Create()
                End If

                File.WriteAllText(p & fname, s, System.Text.Encoding.UTF8)
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Function SysMake_enumStore() As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim i As Integer
        Dim j As Integer

        For i = 1 To model.FIELDTYPE.Count
            ft = model.FIELDTYPE.Item(i)

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                sw.Append(vbCrLf & " var enum_" & ft.Name & " = Ext.create('Ext.data.ArrayStore', {")
                sw.Append(vbCrLf & "  fields: [")
                sw.Append(" {name: 'name'},")
                sw.Append(" {name: 'value',     type: 'int'}")
                sw.Append(" ],")
                sw.Append(" data: [ " & vbCrLf)
                ft.ENUMITEM.Sort = "NameValue"
                For j = 1 To ft.ENUMITEM.Count
                    If j > 1 Then
                        sw.Append(vbCrLf & ",")
                    End If
                    sw.Append("[")
                    sw.Append("'" & ft.ENUMITEM.Item(j).Name & "',")
                    sw.Append(ft.ENUMITEM.Item(j).NameValue)
                    sw.Append("]")
                Next

                sw.Append(vbCrLf & " ]});")

            End If

        Next

        Return sw.ToString
    End Function



    Private Function PartMake_JSStore(ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal UseMartService As Boolean) As String

        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        ot = LATIR2Framework.ObjectTypeHelper.TypeForStruct(P)
        Dim sw As StringBuilder
        sw = New StringBuilder()




        Dim isroot As Boolean = False
        If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
            isroot = True
        End If



        If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            If UseMartService Then
                sw.Append(vbCrLf & "    var store_mart_" & P.Name.ToLower() & " = Ext.create('Ext.data.Store', {")
            Else
                sw.Append(vbCrLf & "    var store_" & P.Name.ToLower() & " = Ext.create('Ext.data.Store', {")
            End If

            sw.Append(vbCrLf & "        model:'model_" & P.Name.ToLower() & "',")
            sw.Append(vbCrLf & "        autoLoad: false,")
            sw.Append(vbCrLf & "        autoSync: false,")
            sw.Append(vbCrLf & "        proxy: {")
            sw.Append(vbCrLf & "            type:   'ajax',")
            If UseMartService Then
                sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_mart_" & P.Name.ToLower() & "/getRows',")
            Else
                If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRowsTemp',")
                Else
                    sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
                End If

            End If

            sw.Append(vbCrLf & "            reader: {")
            sw.Append(vbCrLf & "                type:   'json'")
            sw.Append(vbCrLf & "                ,root:  'data'")
            sw.Append(vbCrLf & "                ,successProperty:  'success'")

            sw.Append(vbCrLf & "                ,messageProperty:  'msg'")
            If isroot Then
                sw.Append(vbCrLf & "                },")
                sw.Append(vbCrLf & "            extraParams:{")
                sw.Append(vbCrLf & "                instanceid: objectID")
            End If

            sw.Append(vbCrLf & "            }")



            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "    });")
        End If
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            If Not UseMartService Then
                sw.Append(vbCrLf & "    var treestore_" & P.Name.ToLower() & " = Ext.create('Ext.data.TreeStore', {")
            Else
                sw.Append(vbCrLf & "    var treestore_mart_" & P.Name.ToLower() & " = Ext.create('Ext.data.TreeStore', {")
            End If

            sw.Append(vbCrLf & "        model:'model_" & P.Name.ToLower() & "',")
            sw.Append(vbCrLf & "        autoLoad: false,")
            sw.Append(vbCrLf & "        autoSync: false,")
            sw.Append(vbCrLf & "        //folderSort: true,")
            sw.Append(vbCrLf & "        nodeParam:  'treeid',")
            sw.Append(vbCrLf & "        defaultRootId:  '{00000000-0000-0000-0000-000000000000}',")
            sw.Append(vbCrLf & "        proxy: {")
            sw.Append(vbCrLf & "            type:   'ajax',")
            If Not UseMartService Then
                If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRowsTemp',")
                Else
                    sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
                End If

            Else
                sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_mart_" & P.Name.ToLower() & "/getRows',")
            End If

            sw.Append(vbCrLf & "            reader: {")
            sw.Append(vbCrLf & "                type:   'json'")
            sw.Append(vbCrLf & "                },")
            sw.Append(vbCrLf & "            extraParams:{")
            sw.Append(vbCrLf & "                instanceid: objectID")

            'sw.Append(vbCrLf & "            },")
            'sw.Append(vbCrLf & "            listeners: {")
            'sw.Append(vbCrLf & "                exception: function(proxy, response, operation){")
            'sw.Append(vbCrLf & "                    Ext.MessageBox.show({")
            'sw.Append(vbCrLf & "                        title: 'REMOTE EXCEPTION',")
            'sw.Append(vbCrLf & "                        msg:    operation.getError(),")
            'sw.Append(vbCrLf & "                        icon : Ext.MessageBox.ERROR,")
            'sw.Append(vbCrLf & "                        buttons : Ext.Msg.OK")
            'sw.Append(vbCrLf & "                    });")
            'sw.Append(vbCrLf & "                }")
            sw.Append(vbCrLf & "            }")



            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "    });")
        End If
        Dim i As Integer
        For i = 1 To P.PART.Count
            sw.Append(vbCrLf & PartMake_JSStore(P.PART.Item(i), UseMartService))
        Next

        Return sw.ToString()
    End Function

    Private Function PartMake_JSModelAndStore(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Dim i As Integer


        Dim isroot As Boolean = False
        If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
            isroot = True
        End If


        sw.Append(vbCrLf & " Ext.define('model_" & P.Name.ToLower() & "',{")
        sw.Append(vbCrLf & "            extend:'Ext.data.Model',")
        sw.Append(vbCrLf & "        fields: [")
        sw.Append(vbCrLf & "            {name: '" & P.Name.ToLower() & "id',type: 'string'}")
        sw.Append(vbCrLf & "            ,{name: 'id',type: 'string'}")
        If isroot Then
            sw.Append(vbCrLf & "            ,{name: 'instanceid',type: 'string'}")
        Else
            sw.Append(vbCrLf & "            ,{name: 'parentid',type: 'string'}")
        End If

        sw.Append(vbCrLf & "            ,{name: 'brief',type: 'string'}")

        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "            ,{name: 'parentrowid',type: 'string'}")

        End If

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    If ft.Name.ToLower = "file" Then
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'string'}")
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "_ext', type: 'string'}")
                    Else
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'string'}")
                    End If

                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                    If ft.Name.ToLower = "date" Then
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'date',dateFormat:'Y-m-d'}")
                    ElseIf ft.Name.ToLower = "time" Then
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'date',dateFormat:'H:i:s'}")
                    ElseIf ft.Name.ToLower = "datetime" Then
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'date',dateFormat:'Y-m-d H:i:s'}")
                    ElseIf ft.Name.ToLower = "birthday" Then
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'string'}")
                    End If
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then

                    sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'number'}")

                End If
            End If


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'int'}")


            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'int'}")
                sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "_grid', type: 'string'}")

            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'string'}")
                sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "_grid', type: 'string'}")

            End If
        Next
        sw.Append(vbCrLf & "        ]")
        sw.Append(vbCrLf & "    });")

        'sw.Append(vbCrLf & "    var store_" & P.Name.ToLower() & ";")

        'sw.Append(vbCrLf & "    var store_" & P.Name.ToLower() & " = Ext.create('Ext.data.Store', {")
        'sw.Append(vbCrLf & "        model:'model_" & P.Name.ToLower() & "',")
        'sw.Append(vbCrLf & "        autoLoad: false,")
        'sw.Append(vbCrLf & "        autoSync: false,")
        'sw.Append(vbCrLf & "        proxy: {")
        'sw.Append(vbCrLf & "            type:   'ajax',")
        'sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
        ''sw.Append(vbCrLf & "            api: {")
        ''sw.Append(vbCrLf & "                read:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
        ''sw.Append(vbCrLf & "                create:  rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/newRow',")
        ''sw.Append(vbCrLf & "                update:  rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/setRow',")
        ''sw.Append(vbCrLf & "                destroy:  rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/deleteRow'")
        ''sw.Append(vbCrLf & "            },")
        'sw.Append(vbCrLf & "            reader: {")
        'sw.Append(vbCrLf & "                type:   'json'")
        'sw.Append(vbCrLf & "                ,root:  'data'")
        'sw.Append(vbCrLf & "                ,successProperty:  'success'")
        'sw.Append(vbCrLf & "                ,messageProperty:  'msg'")
        ''sw.Append(vbCrLf & "            },")

        ''sw.Append(vbCrLf & "            listeners: {")
        ''sw.Append(vbCrLf & "                exception: function(proxy, response, operation){")
        ''sw.Append(vbCrLf & "                    Ext.MessageBox.show({")
        ''sw.Append(vbCrLf & "                        title: 'REMOTE EXCEPTION',")
        ''sw.Append(vbCrLf & "                        msg:    operation.getError(),")
        ''sw.Append(vbCrLf & "                        icon : Ext.MessageBox.ERROR,")
        ''sw.Append(vbCrLf & "                        buttons : Ext.Msg.OK")
        ''sw.Append(vbCrLf & "                    });")
        ''sw.Append(vbCrLf & "                }")
        'sw.Append(vbCrLf & "            }")



        'sw.Append(vbCrLf & "        }")
        'sw.Append(vbCrLf & "    });")

        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            'sw.Append(vbCrLf & "    var treestore_" & P.Name.ToLower() & ";")
            'sw.Append(vbCrLf & "    var treestore_" & P.Name.ToLower() & " = Ext.create('Ext.data.TreeStore', {")
            'sw.Append(vbCrLf & "        model:'model_" & P.Name.ToLower() & "',")
            'sw.Append(vbCrLf & "        autoLoad: false,")
            'sw.Append(vbCrLf & "        autoSync: false,")
            'sw.Append(vbCrLf & "        //folderSort: true,")
            'sw.Append(vbCrLf & "        nodeParam:  'treeid',")
            'sw.Append(vbCrLf & "        defaultRootId:  '{00000000-0000-0000-0000-000000000000}',")
            'sw.Append(vbCrLf & "        proxy: {")
            'sw.Append(vbCrLf & "            type:   'ajax',")
            'sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
            'sw.Append(vbCrLf & "            reader: {")
            'sw.Append(vbCrLf & "                type:   'json'")
            ''sw.Append(vbCrLf & "            },")
            ''sw.Append(vbCrLf & "            listeners: {")
            ''sw.Append(vbCrLf & "                exception: function(proxy, response, operation){")
            ''sw.Append(vbCrLf & "                    Ext.MessageBox.show({")
            ''sw.Append(vbCrLf & "                        title: 'REMOTE EXCEPTION',")
            ''sw.Append(vbCrLf & "                        msg:    operation.getError(),")
            ''sw.Append(vbCrLf & "                        icon : Ext.MessageBox.ERROR,")
            ''sw.Append(vbCrLf & "                        buttons : Ext.Msg.OK")
            ''sw.Append(vbCrLf & "                    });")
            ''sw.Append(vbCrLf & "                }")
            'sw.Append(vbCrLf & "            }")



            'sw.Append(vbCrLf & "        }")
            'sw.Append(vbCrLf & "    });")
        End If

        Return sw.ToString()

    End Function




    Private Function PartMake_ComboStore(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim dt As DataTable
        dt = Manager.Session.GetData("select count(*)  cnt from field where reftopart=" & Manager.Session.GetProvider.ID2Const(P.ID))
        If dt.Rows(0)("cnt") > 0 Then
            'If P.Name.ToLower() = "tstyle" Then
            '    Stop
            'End If
            sw.Append(vbCrLf & " Ext.define('cmbmodel_" & P.Name.ToLower() & "',{")
            sw.Append(vbCrLf & "            extend:'Ext.data.Model',")
            sw.Append(vbCrLf & "        fields: [")
            sw.Append(vbCrLf & "            {name: '" & P.Name.ToLower() & "id',type: 'string'}")
            sw.Append(vbCrLf & "            ,{name: 'brief',type: 'string'}")
            sw.Append(vbCrLf & "        ]")
            sw.Append(vbCrLf & "    });")

            sw.Append(vbCrLf & "    var cmbstore_" & P.Name.ToLower() & "_loaded=false;")
            sw.Append(vbCrLf & "    var cmbstore_" & P.Name.ToLower() & " = Ext.create('Ext.data.Store', {")
            sw.Append(vbCrLf & "        model:'cmbmodel_" & P.Name.ToLower() & "',")
            sw.Append(vbCrLf & "        autoLoad: false,")
            sw.Append(vbCrLf & "        autoSync: false,")
            sw.Append(vbCrLf & "        proxy: {")
            sw.Append(vbCrLf & "            type:   'ajax',")
            sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
            sw.Append(vbCrLf & "            reader: {")
            sw.Append(vbCrLf & "                type:   'json'")
            sw.Append(vbCrLf & "                ,root:  'data'")
            sw.Append(vbCrLf & "                ,successProperty:  'success'")
            sw.Append(vbCrLf & "                ,messageProperty:  'msg'")
            sw.Append(vbCrLf & "            }")
            sw.Append(vbCrLf & "        },")
            sw.Append(vbCrLf & "       listeners: {")
            sw.Append(vbCrLf & "       'load': function(){combo_" & P.Name.ToLower() & "_loaded =true;}")
            sw.Append(vbCrLf & "       }")
            sw.Append(vbCrLf & "    });")
            ' sw.Append(vbCrLf & "    PartMake_ComboStores.push(cmbstore_" & P.Name.ToLower() & ");")
        End If

        Return sw.ToString()

    End Function


    'Private Function Combo_Load() As String
    '    Dim sw As StringBuilder
    '    sw = New StringBuilder()
    '    sw.Append(vbCrLf & "    var combo_timeout_id=null;")
    '    sw.Append(vbCrLf & "    var PartMake_ComboStoreLoaded=false;")
    '    sw.Append(vbCrLf & "    var combo_Waiter=0;")
    '    sw.Append(vbCrLf & "    var combo_Index=0;")
    '    sw.Append(vbCrLf & "    var PartMake_ComboStores=new Array();")

    '    sw.Append(vbCrLf & "    function combo_LoadAll() {")
    '    sw.Append(vbCrLf & "        combo_Index=0;")
    '    sw.Append(vbCrLf & "        combo_Waiter=0;")
    '    sw.Append(vbCrLf & "        PartMake_ComboStoreLoaded=false;")
    '    sw.Append(vbCrLf & "        PartMake_ComboStores[combo_Index].load();")
    '    sw.Append(vbCrLf & "        combo_timeout_id= setTimeout(combo_wait, 100);")
    '    sw.Append(vbCrLf & "   }")
    '    sw.Append(vbCrLf & "    function combo_LoadNext() {")
    '    sw.Append(vbCrLf & "            if(combo_Index<PartMake_ComboStores.length){")
    '    sw.Append(vbCrLf & "              combo_Index=+1;")
    '    sw.Append(vbCrLf & "              combo_Waiter=0;")
    '    sw.Append(vbCrLf & "              PartMake_ComboStoreLoaded=false;")
    '    sw.Append(vbCrLf & "              PartMake_ComboStores[combo_Index].load();")
    '    sw.Append(vbCrLf & "              combo_timeout_id= setTimeout(combo_wait, 100);")
    '    sw.Append(vbCrLf & "           } ")
    '    sw.Append(vbCrLf & "   }")

    '    sw.Append(vbCrLf & "    function combo_wait() {")
    '    sw.Append(vbCrLf & "      if(PartMake_ComboStoreLoaded){ ")
    '    sw.Append(vbCrLf & "           clearTimeout(combo_timeout_id);")
    '    sw.Append(vbCrLf & "           combo_LoadNext();")
    '    sw.Append(vbCrLf & "      }else{")
    '    sw.Append(vbCrLf & "        combo_Waiter=comboWaiter+1;")
    '    sw.Append(vbCrLf & "        if(combo_Waiter==300){ ")
    '    sw.Append(vbCrLf & "           clearTimeout(combo_timeout_id);")
    '    sw.Append(vbCrLf & "            combo_LoadNext();")
    '    sw.Append(vbCrLf & "        }else{ ")
    '    sw.Append(vbCrLf & "           combo_timeout_id= setTimeout(combo_wait, 100);")
    '    sw.Append(vbCrLf & "        } ")
    '    sw.Append(vbCrLf & "      }")
    '    sw.Append(vbCrLf & "   }")
    '    Return sw.ToString()

    'End Function



    'Private Function PartMake_XML(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
    '    Dim sout As String = ""
    '    Dim fld As MTZMetaModel.MTZMetaModel.FIELD
    '    Dim i As Integer, j As Integer
    '    Dim rs As DataTable

    '    sout = "<?xml version=""1.0"" encoding=""UTF-8""?><rows>"
    '    rs = Manager.Session.GetData("select * from " & P.Name.ToLower())

    '    For i = 0 To rs.Rows.Count - 1

    '        sout = sout & vbCrLf & "<row>"
    '        sout = sout & vbCrLf & "<ID>" & rs.Rows(i)(P.Name & "ID").ToString() & "</ID>"

    '        For j = 1 To P.FIELD.Count
    '            fld = P.FIELD.Item(j)

    '            sout = sout & vbCrLf & "<" & fld.Name.ToLower() & ">" & rs.Rows(i)(fld.Name).ToString() & "</" & fld.Name.ToLower() & ">"

    '        Next
    '        sout = sout & vbCrLf & "</row>"
    '    Next

    '    sout = sout & vbCrLf & "</rows>"
    '    PartMake_XML = sout
    'End Function

    Private Function PartMake_CIModel(ByVal p As MTZMetaModel.MTZMetaModel.PART) As String
        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        ot = LATIR2Framework.ObjectTypeHelper.TypeForStruct(p)
        Dim isroot As Boolean = False
        If TypeName(p.Parent.Parent) = "OBJECTTYPE" Then
            isroot = True
        End If

        Dim sw As StringBuilder
        sw = New StringBuilder
        Dim j As Integer
        Dim i As Integer
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE


        Dim flist As String = "B2G(" & p.Name.ToLower() & "id) as " & p.Name.ToLower() & "id, B2G(" & p.Name.ToLower() & "id) as id"
        If isroot Then
            flist = flist + ",B2G(instanceid) as instanceid"
        Else
            flist = flist + ",B2G(parentstructrowid) as parentid"
        End If

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            flist = flist & ",B2G(parentrowid) as parentrowid"
        End If
        flist = flist & "," & " " & p.Name & "_BRIEF_F(" & p.Name.ToLower() & "id , NULL) as  brief"
        'flist = flist & "," & " " & p.Name & "_BRIEF_F(b2g(" & p.Name.ToLower() & "id) , NULL) as  brief"


        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                        flist = flist & "," & fld.Name.ToLower
                        If ft.Name.ToLower = "file" Then
                            flist = flist & "," & fld.Name.ToLower & "_ext"
                        End If
                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        If ft.Name.ToLower = "date" Then
                            flist = flist & ",  DATE_FORMAT(" & fld.Name.ToLower() & ",\'%Y-%m-%d\') as  " & fld.Name.ToLower
                        ElseIf ft.Name.ToLower = "time" Then
                            flist = flist & ",  DATE_FORMAT(" & fld.Name.ToLower() & ",\'%H:%i:%s\') as  " & fld.Name.ToLower
                        ElseIf ft.Name.ToLower = "datetime" Then
                            flist = flist & ",  DATE_FORMAT(" & fld.Name.ToLower() & ",\'%Y-%m-%d %H:%i:%s\') as  " & fld.Name.ToLower
                        ElseIf ft.Name.ToLower = "birthday" Then
                            flist = flist & ",  " & fld.Name.ToLower() & " as  " & fld.Name.ToLower
                        End If



                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                        flist = flist & "," & fld.Name.ToLower
                    End If
                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
                    flist = flist & "," & fld.Name.ToLower
                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                    flist = flist & "," & fld.Name.ToLower

                    flist = flist & "," & " case " & fld.Name.ToLower() & " "
                    For i = 1 To ft.ENUMITEM.Count
                        flist = flist & " when " & ft.ENUMITEM.Item(i).NameValue.ToString() & " then \'" & ft.ENUMITEM.Item(i).Name & "\'"
                    Next
                    flist = flist & "End "
                    flist = flist & " as " & fld.Name.ToLower() & "_grid"

                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then


                    If ft.Name.ToLower() = "multiref" Then
                        If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                            flist = flist & "," & fld.Name.ToLower
                            flist = flist & "," & " " & CType(fld.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & "_MREF_F(" & fld.Name.ToLower() & ", NULL)"
                            flist = flist & " as  " & fld.Name.ToLower() & "_grid"

                        End If
                        If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                            flist = flist & ",B2G(" & fld.Name & ") " & fld.Name.ToLower
                            'flist = flist & "," & "INSTANCE_MREF_F(B2g(" & fld.Name.ToLower() & "), NULL)"
                            flist = flist & "," & "INSTANCE_MREF_F(" & fld.Name.ToLower() & ", NULL)"
                            flist = flist & " as  " & fld.Name.ToLower() & "_grid"
                        End If
                    Else
                        If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                            flist = flist & ",B2G(" & fld.Name & ") " & fld.Name.ToLower
                            'flist = flist & "," & " " & CType(fld.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & "_BRIEF_F(B2G(" & fld.Name.ToLower() & "), NULL)"
                            flist = flist & "," & " " & CType(fld.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & "_BRIEF_F(" & fld.Name.ToLower() & ", NULL)"
                            flist = flist & " as " & fld.Name.ToLower() & "_grid"
                        End If
                        If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                            flist = flist & ",B2G(" & fld.Name & ") " & fld.Name.ToLower
                            'flist = flist & "," & "INSTANCE_BRIEF_F(B2g(" & fld.Name.ToLower() & "), NULL)"
                            flist = flist & "," & "INSTANCE_BRIEF_F(" & fld.Name.ToLower() & ", NULL)"
                            flist = flist & " as  " & fld.Name.ToLower() & "_grid"
                        End If
                    End If



                End If
            End If

        Next


        sw.Append(vbCrLf & "<?php")

        sw.Append(vbCrLf & "class  M_" & p.Name.ToLower() & " extends CI_Model {")



        If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "    function getRowTemp($empId) {")
            sw.Append(vbCrLf & "    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');")
            sw.Append(vbCrLf & "	if (!empty($empId)){")
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetRowDataTemp','FieldList'=>'" & flist & "', 'PartName' => '" & p.Name.ToLower() & "', 'ID' =>  $empId 	));")
            sw.Append(vbCrLf & "	    if (!empty($res)) {")
            sw.Append(vbCrLf & "	        $result = $res[0];")
            sw.Append(vbCrLf & "	    }")
            sw.Append(vbCrLf & "	}")
            sw.Append(vbCrLf & "	return $result;")
            sw.Append(vbCrLf & "    }")
        End If

        sw.Append(vbCrLf & "    function getRow($empId) {")
        sw.Append(vbCrLf & "    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');")
        sw.Append(vbCrLf & "	if (!empty($empId)){")
        sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'" & flist & "', 'PartName' => '" & p.Name.ToLower() & "', 'ID' =>  $empId 	));")
        sw.Append(vbCrLf & "	    if (!empty($res)) {")
        sw.Append(vbCrLf & "	        $result = $res[0];")
        sw.Append(vbCrLf & "	    }")
        sw.Append(vbCrLf & "	}")
        sw.Append(vbCrLf & "	return $result;")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function setRow($data)  {")
        sw.Append(vbCrLf & "	    $data = (array)$data;")

        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType

            If ft.Name.ToLower = "file" Then

                Dim file_field As String
                file_field = fld.Name.ToLower
                sw.Append(vbCrLf & "//////////////////////////// support file data for: " & file_field)
                sw.Append(vbCrLf & "    if ($_FILES['" & file_field & "_fu']['size'] > 0 ) {")
                sw.Append(vbCrLf & "       $ext = pathinfo($_FILES['" & file_field & "_fu']['name'], PATHINFO_EXTENSION);")
                sw.Append(vbCrLf & "       $orig = pathinfo($_FILES['" & file_field & "_fu']['name'], PATHINFO_BASENAME) ;")
                sw.Append(vbCrLf & "       $filename = strtolower(trim($this->jservice->get(array('Action' => 'NewGuid')),'{}') . '.' . $ext);")
                sw.Append(vbCrLf & "       if (move_uploaded_file($_FILES['" & file_field & "_fu']['tmp_name'], $this->jservice->temp_file_path().$filename)) {")
                sw.Append(vbCrLf & "          $file_data = file_get_contents($this->jservice->temp_file_path().$filename);")
                sw.Append(vbCrLf & "          $this->jservice->get(array('Action' => 'AddFile', 'FileName'=>$filename, 'Data'=>utf8_encode($file_data), 'FileID'=>'iu_files',")
                sw.Append(vbCrLf & "            'OrigName'=>$orig   ));")
                sw.Append(vbCrLf & "          unlink($this->jservice->temp_file_path().$filename);")
                sw.Append(vbCrLf & "       }")
                sw.Append(vbCrLf & "	   if (!empty($data)) {")
                sw.Append(vbCrLf & "	        $data['" & file_field & "']=$filename;")
                sw.Append(vbCrLf & "	        $data['" & file_field & "_ext']=$ext;")
                sw.Append(vbCrLf & "       }")
                sw.Append(vbCrLf & "    }")
                sw.Append(vbCrLf & "//////////////////////////// end support file data for: " & file_field)
            End If

        Next

        sw.Append(vbCrLf & "	if (!empty($data)) {")
        sw.Append(vbCrLf & "	    if (empty($data['" & p.Name.ToLower() & "id'])) {")
        sw.Append(vbCrLf & "	        $data['" & p.Name.ToLower() & "id'] = $this->jservice->get(array('Action' => 'NewGuid'));")
        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $data['" & p.Name.ToLower() & "id'], 'DocumentID' => $data['instanceid'],'TreeID'=>$data['treeid'], 'Values'=>$data));")
        ElseIf isroot Then
            sw.Append(vbCrLf & "	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $data['" & p.Name.ToLower() & "id'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));")
        Else
            sw.Append(vbCrLf & "	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $data['" & p.Name.ToLower() & "id'], 'DocumentID' => $data['instanceid'],'ParentID' => $data['parentid'], 'Values'=>$data));")
        End If
        sw.Append(vbCrLf & "	       if(isset($res[0])){")
        sw.Append(vbCrLf & "	       	if($res[0]->result!='ok'){")
        sw.Append(vbCrLf & "	       		return array('success' => FALSE, 'msg' => $res[0]->result);")
        sw.Append(vbCrLf & "	       	} ")
        sw.Append(vbCrLf & "	       }else{")
        sw.Append(vbCrLf & "	       	return array('success' => FALSE, 'msg' => 'Unknown error' );")
        sw.Append(vbCrLf & "	       }")


        sw.Append(vbCrLf & "	    }else{")
        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $data['" & p.Name.ToLower() & "id'], 'DocumentID' => $data['instanceid'],'TreeID'=>$data['treeid'], 'Values'=>$data));")
        ElseIf isroot Then
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $data['" & p.Name.ToLower() & "id'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));")
        Else
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $data['" & p.Name.ToLower() & "id'], 'DocumentID' => $data['instanceid'],'ParentID' => $data['parentid'], 'Values'=>$data));")
        End If
        sw.Append(vbCrLf & "	       if(isset($res[0])){")
        sw.Append(vbCrLf & "	       	if($res[0]->result!='ok'){")
        sw.Append(vbCrLf & "	       		return array('success' => FALSE, 'msg' => $res[0]->result);")
        sw.Append(vbCrLf & "	       	} ")
        sw.Append(vbCrLf & "	       }else{")
        sw.Append(vbCrLf & "	       	return array('success' => FALSE, 'msg' => 'Unknown error' );")
        sw.Append(vbCrLf & "	       }")
        sw.Append(vbCrLf & "	    }")
        If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "	    return array('success' => TRUE, 'data' => $this->getRowTemp($data['" & p.Name.ToLower() & "id'] ));")
        Else
            sw.Append(vbCrLf & "	    return array('success' => TRUE, 'data' => $this->getRow($data['" & p.Name.ToLower() & "id'] ));")
        End If


        sw.Append(vbCrLf & "	} else {")
        sw.Append(vbCrLf & "	    return array('success' => FALSE, 'msg' => 'No data to store on server');")
        sw.Append(vbCrLf & "	}")



        sw.Append(vbCrLf & "    }")

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "    function newRow($instanceid,$treeid,$data)  {")
        ElseIf isroot Then
            sw.Append(vbCrLf & "    function newRow($instanceid,$data)  {")
        Else
            sw.Append(vbCrLf & "    function newRow($instanceid,$parentid,$data)  {")
        End If


        sw.Append(vbCrLf & "	  $id = $this->jservice->get(array('Action' => 'NewGuid'));")
        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $id, 'DocumentID' => $instanceid,'TreeID'=>$treeid, 'Values'=>$data)) == 'OK') {")
        ElseIf isroot Then
            sw.Append(vbCrLf & "	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {")
        Else
            sw.Append(vbCrLf & "	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $id, 'DocumentID' => $instanceid,'ParentID'=>$parentid, 'Values'=>$data)) == 'OK') {")
        End If


        sw.Append(vbCrLf & "	    return array('success' => TRUE, 'data' => $id);")
        sw.Append(vbCrLf & "	} else {")
        sw.Append(vbCrLf & "	    return array('success' => FALSE, 'msg' => 'Error while create new id');")
        sw.Append(vbCrLf & "	}")


        sw.Append(vbCrLf & "    }")

        If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "    function getRowsTemp($sort=array())")
            sw.Append(vbCrLf & "		{")
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetViewDataTemp','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "'));")
            sw.Append(vbCrLf & "	    if (count($res)) {")
            sw.Append(vbCrLf & "	        return $res;")
            sw.Append(vbCrLf & "	    } else {")
            sw.Append(vbCrLf & "	        return null;")
            sw.Append(vbCrLf & "	    }")

            sw.Append(vbCrLf & "		}")

            sw.Append(vbCrLf & "    function getRowsByInstanceTemp($id,$sort=array())")
            sw.Append(vbCrLf & "		{")
            sw.Append(vbCrLf & "	$res = $this->jservice->get(array('Action' => 'GetViewDataTemp','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));")
            sw.Append(vbCrLf & "	if (count($res) == 0) {")
            sw.Append(vbCrLf & "	    return null;")
            sw.Append(vbCrLf & "	} else {")
            sw.Append(vbCrLf & "	    return $res;")
            sw.Append(vbCrLf & "	}")
            sw.Append(vbCrLf & "		}")

            sw.Append(vbCrLf & "    function getRowsByParentTemp($id,$sort=array())")
            sw.Append(vbCrLf & "	{")

            sw.Append(vbCrLf & "	$res = $this->jservice->get(array('Action' => 'GetViewDataTemp','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));")
            sw.Append(vbCrLf & "	if (count($res) == 0) {")
            sw.Append(vbCrLf & "	    return null;")
            sw.Append(vbCrLf & "	} else {")
            sw.Append(vbCrLf & "	    return $res;")
            sw.Append(vbCrLf & "	}")
            sw.Append(vbCrLf & "  }")

            If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                sw.Append(vbCrLf & "    function getRowsByTreeTemp($treeid,$sort=array())")
                sw.Append(vbCrLf & "		{")
                sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetViewDataTemp','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => 'parentrowid=G2B(\''.$treeid.'\')'));")
                sw.Append(vbCrLf & "	    if (count($res)) {")
                sw.Append(vbCrLf & "	        return $res;")
                sw.Append(vbCrLf & "	    } else {")
                sw.Append(vbCrLf & "	        return null;")
                sw.Append(vbCrLf & "	    }")

                sw.Append(vbCrLf & "		}")

                sw.Append(vbCrLf & "    function getRowsByInstanceTreeTemp($id,$treeid,$sort=array())")
                sw.Append(vbCrLf & "		{")
                sw.Append(vbCrLf & "	$res = $this->jservice->get(array('Action' => 'GetViewDataTemp','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => 'instanceid=G2B(\''. $id . '\') and parentrowid=G2B(\''.$treeid.'\')'));")
                sw.Append(vbCrLf & "	if (count($res) == 0) {")
                sw.Append(vbCrLf & "	    return null;")
                sw.Append(vbCrLf & "	} else {")
                sw.Append(vbCrLf & "	    return $res;")
                sw.Append(vbCrLf & "	}")
                sw.Append(vbCrLf & "		}")

                sw.Append(vbCrLf & "    function getRowsByParentTreeTemp($id,$treeid,$sort=array())")
                sw.Append(vbCrLf & "	{")

                sw.Append(vbCrLf & "	$res = $this->jservice->get(array('Action' => 'GetViewDataTemp','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\') and parentrowid=G2B(\''.$treeid.'\')'));")
                sw.Append(vbCrLf & "	if (count($res) == 0) {")
                sw.Append(vbCrLf & "	    return null;")
                sw.Append(vbCrLf & "	} else {")
                sw.Append(vbCrLf & "	    return $res;")
                sw.Append(vbCrLf & "	}")
                sw.Append(vbCrLf & "  }")
            End If
        End If

        sw.Append(vbCrLf & "    function getRows($sort=array())")
        sw.Append(vbCrLf & "		{")
        sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "'));")
        sw.Append(vbCrLf & "	    if (count($res)) {")
        sw.Append(vbCrLf & "	        return $res;")
        sw.Append(vbCrLf & "	    } else {")
        sw.Append(vbCrLf & "	        return null;")
        sw.Append(vbCrLf & "	    }")

        sw.Append(vbCrLf & "		}")

        sw.Append(vbCrLf & "    function getRowsByInstance($id,$sort=array())")
        sw.Append(vbCrLf & "		{")
        sw.Append(vbCrLf & "	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));")
        sw.Append(vbCrLf & "	if (count($res) == 0) {")
        sw.Append(vbCrLf & "	    return null;")
        sw.Append(vbCrLf & "	} else {")
        sw.Append(vbCrLf & "	    return $res;")
        sw.Append(vbCrLf & "	}")
        sw.Append(vbCrLf & "		}")

        sw.Append(vbCrLf & "    function getRowsByParent($id,$sort=array())")
        sw.Append(vbCrLf & "	{")

        sw.Append(vbCrLf & "	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));")
        sw.Append(vbCrLf & "	if (count($res) == 0) {")
        sw.Append(vbCrLf & "	    return null;")
        sw.Append(vbCrLf & "	} else {")
        sw.Append(vbCrLf & "	    return $res;")
        sw.Append(vbCrLf & "	}")
        sw.Append(vbCrLf & "  }")

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "    function getRowsByTree($treeid,$sort=array())")
            sw.Append(vbCrLf & "		{")
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => 'parentrowid=G2B(\''.$treeid.'\')'));")
            sw.Append(vbCrLf & "	    if (count($res)) {")
            sw.Append(vbCrLf & "	        return $res;")
            sw.Append(vbCrLf & "	    } else {")
            sw.Append(vbCrLf & "	        return null;")
            sw.Append(vbCrLf & "	    }")

            sw.Append(vbCrLf & "		}")

            sw.Append(vbCrLf & "    function getRowsByInstanceTree($id,$treeid,$sort=array())")
            sw.Append(vbCrLf & "		{")
            sw.Append(vbCrLf & "	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => 'instanceid=G2B(\''. $id . '\') and parentrowid=G2B(\''.$treeid.'\')'));")
            sw.Append(vbCrLf & "	if (count($res) == 0) {")
            sw.Append(vbCrLf & "	    return null;")
            sw.Append(vbCrLf & "	} else {")
            sw.Append(vbCrLf & "	    return $res;")
            sw.Append(vbCrLf & "	}")
            sw.Append(vbCrLf & "		}")

            sw.Append(vbCrLf & "    function getRowsByParentTree($id,$treeid,$sort=array())")
            sw.Append(vbCrLf & "	{")

            sw.Append(vbCrLf & "	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\') and parentrowid=G2B(\''.$treeid.'\')'));")
            sw.Append(vbCrLf & "	if (count($res) == 0) {")
            sw.Append(vbCrLf & "	    return null;")
            sw.Append(vbCrLf & "	} else {")
            sw.Append(vbCrLf & "	    return $res;")
            sw.Append(vbCrLf & "	}")
            sw.Append(vbCrLf & "  }")
        End If



        sw.Append(vbCrLf & "    function deleteRow($id = null) {")
        If p.UseArchiving = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "	  if (!empty($id) && $this->jservice->get(array('Action' => 'ArchiveRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $id)) == 'OK')")
        Else
            sw.Append(vbCrLf & "	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => '" & p.Name.ToLower() & "', 'RowID' => $id)) == 'OK')")
        End If

        sw.Append(vbCrLf & "	    $result = array('success' => TRUE);")
        sw.Append(vbCrLf & "	else")
        sw.Append(vbCrLf & "	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');")
        sw.Append(vbCrLf & "	return $result;")

        sw.Append(vbCrLf & "    }")



        sw.Append(vbCrLf & "}")
        sw.Append(vbCrLf & "?>")


        Return sw.ToString()
    End Function


    'Private Function PartMake_CIMartModel(ByVal p As MTZMetaModel.MTZMetaModel.PART) As String
    '    If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
    '    Dim isroot As Boolean = False
    '    If TypeName(p.Parent.Parent) = "OBJECTTYPE" Then
    '        isroot = True
    '    End If

    '    Dim sw As StringBuilder
    '    sw = New StringBuilder
    '    Dim j As Integer
    '    Dim i As Integer
    '    Dim fld As MTZMetaModel.MTZMetaModel.FIELD
    '    Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE


    '    Dim flist As String = "B2G(" & p.Name.ToLower() & "id) as " & p.Name.ToLower() & "id, B2G(" & p.Name.ToLower() & "id) as id"
    '    If isroot Then
    '        flist = flist + ",B2G(instanceid) as instanceid"
    '    Else
    '        flist = flist + ",B2G(parentstructrowid) as parentid"
    '    End If

    '    If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
    '        flist = flist & ",B2G(parentrowid) as parentrowid"
    '    End If
    '    flist = flist & "," & " " & p.Name & "_BRIEF_F(b2g(" & p.Name.ToLower() & "id) , NULL) as  brief"


    '    For j = 1 To p.FIELD.Count
    '        fld = p.FIELD.Item(j)
    '        ft = fld.FieldType
    '        If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then

    '            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
    '                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
    '                    flist = flist & "," & fld.Name.ToLower
    '                End If
    '                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
    '                    flist = flist & ", DATE_FORMAT(" & fld.Name.ToLower() & ",\'%Y-%m-%d %H:%i:%s\') as  " & fld.Name.ToLower
    '                End If

    '                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
    '                    flist = flist & "," & fld.Name.ToLower
    '                End If
    '            End If

    '            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
    '                flist = flist & "," & fld.Name.ToLower
    '            End If

    '            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
    '                flist = flist & "," & fld.Name.ToLower

    '                flist = flist & "," & " case " & fld.Name.ToLower() & " "
    '                For i = 1 To ft.ENUMITEM.Count
    '                    flist = flist & " when " & ft.ENUMITEM.Item(i).NameValue.ToString() & " then \'" & ft.ENUMITEM.Item(i).Name & "\'"
    '                Next
    '                flist = flist & "End "
    '                flist = flist & " as " & fld.Name.ToLower() & "_grid"

    '            End If

    '            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then


    '                If ft.Name.ToLower() = "multiref" Then
    '                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
    '                        flist = flist & "," & fld.Name.ToLower
    '                        flist = flist & "," & " " & CType(fld.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & "_MREF_F(" & fld.Name.ToLower() & ", NULL)"
    '                        flist = flist & " as  " & fld.Name.ToLower() & "_grid"

    '                    End If
    '                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
    '                        flist = flist & ",B2G(" & fld.Name & ") " & fld.Name.ToLower
    '                        flist = flist & "," & "INSTANCE_MREF_F(B2g(" & fld.Name.ToLower() & "), NULL)"
    '                        flist = flist & " as  " & fld.Name.ToLower() & "_grid"
    '                    End If
    '                Else
    '                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
    '                        flist = flist & ",B2G(" & fld.Name & ") " & fld.Name.ToLower
    '                        flist = flist & "," & " " & CType(fld.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & "_BRIEF_F(B2G(" & fld.Name.ToLower() & "), NULL)"
    '                        flist = flist & " as " & fld.Name.ToLower() & "_grid"
    '                    End If
    '                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
    '                        flist = flist & ",B2G(" & fld.Name & ") " & fld.Name.ToLower
    '                        flist = flist & "," & "INSTANCE_BRIEF_F(B2g(" & fld.Name.ToLower() & "), NULL)"
    '                        flist = flist & " as  " & fld.Name.ToLower() & "_grid"
    '                    End If
    '                End If



    '            End If
    '        End If

    '    Next


    '    sw.Append(vbCrLf & "<?php")

    '    sw.Append(vbCrLf & "class  M_mart_" & p.Name.ToLower() & " extends CI_Model {")
    '    sw.Append(vbCrLf & "    function getRow($empId) {")


    '    sw.Append(vbCrLf & "    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');")
    '    sw.Append(vbCrLf & "	if (!empty($empId)){")
    '    sw.Append(vbCrLf & "	    $res = $this->martservice->get(array('Action' => 'GetRowData','FieldList'=>'" & flist & "', 'PartName' => '" & p.Name.ToLower() & "', 'ID' =>  $empId 	));")
    '    sw.Append(vbCrLf & "	    if (!empty($res)) {")
    '    sw.Append(vbCrLf & "	        $result = $res[0];")
    '    sw.Append(vbCrLf & "	    }")
    '    sw.Append(vbCrLf & "	}")
    '    sw.Append(vbCrLf & "	return $result;")
    '    sw.Append(vbCrLf & "    }")




    '    sw.Append(vbCrLf & "    function getRows()")
    '    sw.Append(vbCrLf & "		{")
    '    sw.Append(vbCrLf & "	    $res = $this->martservice->get(array('Action' => 'GetViewData','FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "'));")
    '    sw.Append(vbCrLf & "	    if (count($res)) {")
    '    sw.Append(vbCrLf & "	        return $res;")
    '    sw.Append(vbCrLf & "	    } else {")
    '    sw.Append(vbCrLf & "	        return null;")
    '    sw.Append(vbCrLf & "	    }")

    '    sw.Append(vbCrLf & "		}")

    '    sw.Append(vbCrLf & "    function getRowsByInstance($id)")
    '    sw.Append(vbCrLf & "		{")
    '    sw.Append(vbCrLf & "	$res = $this->martservice->get(array('Action' => 'GetViewData','FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));")
    '    sw.Append(vbCrLf & "	if (count($res) == 0) {")
    '    sw.Append(vbCrLf & "	    return null;")
    '    sw.Append(vbCrLf & "	} else {")
    '    sw.Append(vbCrLf & "	    return $res;")
    '    sw.Append(vbCrLf & "	}")
    '    sw.Append(vbCrLf & "		}")

    '    sw.Append(vbCrLf & "    function getRowsByParent($id)")
    '    sw.Append(vbCrLf & "	{")

    '    sw.Append(vbCrLf & "	$res = $this->martservice->get(array('Action' => 'GetViewData','FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));")
    '    sw.Append(vbCrLf & "	if (count($res) == 0) {")
    '    sw.Append(vbCrLf & "	    return null;")
    '    sw.Append(vbCrLf & "	} else {")
    '    sw.Append(vbCrLf & "	    return $res;")
    '    sw.Append(vbCrLf & "	}")
    '    sw.Append(vbCrLf & "  }")

    '    If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
    '        sw.Append(vbCrLf & "    function getRowsByTree($treeid)")
    '        sw.Append(vbCrLf & "		{")
    '        sw.Append(vbCrLf & "	    $res = $this->martservice->get(array('Action' => 'GetViewData','FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => 'parentrowid=G2B(\''.$treeid.'\')'));")
    '        sw.Append(vbCrLf & "	    if (count($res)) {")
    '        sw.Append(vbCrLf & "	        return $res;")
    '        sw.Append(vbCrLf & "	    } else {")
    '        sw.Append(vbCrLf & "	        return null;")
    '        sw.Append(vbCrLf & "	    }")

    '        sw.Append(vbCrLf & "		}")

    '        sw.Append(vbCrLf & "    function getRowsByInstanceTree($id,$treeid)")
    '        sw.Append(vbCrLf & "		{")
    '        sw.Append(vbCrLf & "	$res = $this->martservice->get(array('Action' => 'GetViewData','FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => 'instanceid=G2B(\''. $id . '\') and parentrowid=G2B(\''.$treeid.'\')'));")
    '        sw.Append(vbCrLf & "	if (count($res) == 0) {")
    '        sw.Append(vbCrLf & "	    return null;")
    '        sw.Append(vbCrLf & "	} else {")
    '        sw.Append(vbCrLf & "	    return $res;")
    '        sw.Append(vbCrLf & "	}")
    '        sw.Append(vbCrLf & "		}")

    '        sw.Append(vbCrLf & "    function getRowsByParentTree($id,$treeid)")
    '        sw.Append(vbCrLf & "	{")

    '        sw.Append(vbCrLf & "	$res = $this->martservice->get(array('Action' => 'GetViewData','FieldList'=>'" & flist & "', 'ViewName' => '" & p.Name.ToLower() & "', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\') and parentrowid=G2B(\''.$treeid.'\')'));")
    '        sw.Append(vbCrLf & "	if (count($res) == 0) {")
    '        sw.Append(vbCrLf & "	    return null;")
    '        sw.Append(vbCrLf & "	} else {")
    '        sw.Append(vbCrLf & "	    return $res;")
    '        sw.Append(vbCrLf & "	}")
    '        sw.Append(vbCrLf & "  }")
    '    End If

    '    sw.Append(vbCrLf & "}")
    '    sw.Append(vbCrLf & "?>")




    '    Return sw.ToString()
    'End Function

    Private Function PartMake_CIController(ByVal p As MTZMetaModel.MTZMetaModel.PART) As String
        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        ot = LATIR2Framework.ObjectTypeHelper.TypeForStruct(p)

        Dim isroot As Boolean = False
        If TypeName(p.Parent.Parent) = "OBJECTTYPE" Then
            isroot = True
        End If

        Dim sw As StringBuilder
        sw = New StringBuilder

        sw.Append("<?php")
        sw.Append(vbCrLf & "	 class C_" & p.Name.ToLower() & " extends CI_Controller {")

        sw.Append(vbCrLf & "    function __construct() {")
        sw.Append(vbCrLf & "         parent::__construct();")
        sw.Append(vbCrLf & "        $this->_loadModels();")
        sw.Append(vbCrLf & "    }")



        sw.Append(vbCrLf & "    function setRow() {")
        sw.Append(vbCrLf & "          log_message('debug', '" & p.Name & ".setRow post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "          log_message('debug', '" & p.Name & ".getRows get : '.json_encode($this->input->get(NULL, FALSE)));")



        sw.Append(vbCrLf & "          $data = array(")
        sw.Append(vbCrLf & "                '" & p.Name.ToLower() & "id' =>  $this->input->get_post('" & p.Name.ToLower() & "id', TRUE)")


        If isroot Then
            sw.Append(vbCrLf & "                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)")
        Else
            sw.Append(vbCrLf & "                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)")
            sw.Append(vbCrLf & "                ,'parentid' =>  $this->input->get_post('parentid', TRUE)")
        End If


        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "                ,'treeid' =>  $this->input->get_post('treeid', TRUE)")
        End If

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim j As Integer
        p.FIELD.Sort = "sequence"

        Dim sortfld As MTZMetaModel.MTZMetaModel.FIELD = Nothing
        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                sw.Append(vbCrLf & "                ,'" & fld.Name.ToLower() & "' =>   $this->input->get_post('" & fld.Name.ToLower() & "', TRUE)")
                If ft.Name.ToLower = "file" Then
                    sw.Append(vbCrLf & "                ,'" & fld.Name.ToLower() & "_ext' =>   $this->input->get_post('" & fld.Name.ToLower() & "_ext', TRUE)")
                End If
            End If
        Next


        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If fld.TheStyle.Contains("defsort") And sortfld Is Nothing Then
                    sortfld = fld
                    Exit For
                End If
            End If
        Next

        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If fld.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da And sortfld Is Nothing Then
                    sortfld = fld
                    Exit For
                End If
            End If
        Next

        sw.Append(vbCrLf & "            );")


        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $this->m_" & p.Name.ToLower() & "->setRow($data);")


        sw.Append(vbCrLf & "            print json_encode($" & p.Name.ToLower() & ");")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function newRow() {")
        sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".newRow post : '.json_encode($this->input->post(NULL, FALSE)));")


        sw.Append(vbCrLf & "          $data = array(")
        sw.Append(vbCrLf & "                '" & p.Name.ToLower() & "id' =>  $this->input->get_post('" & p.Name.ToLower() & "id', TRUE)")


        If isroot Then
            sw.Append(vbCrLf & "                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)")
        Else
            sw.Append(vbCrLf & "                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)")
            sw.Append(vbCrLf & "                ,'parentid' =>  $this->input->get_post('parentid', TRUE)")
        End If


        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "                ,'treeid' =>  $this->input->get_post('treeid', TRUE)")
        End If


        p.FIELD.Sort = "sequence"
        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                sw.Append(vbCrLf & "                ,'" & fld.Name.ToLower() & "' =>   $this->input->get_post('" & fld.Name.ToLower() & "', TRUE)")
                If ft.Name.ToLower = "file" Then
                    sw.Append(vbCrLf & "                ,'" & fld.Name.ToLower() & "_ext' =>   $this->input->get_post('" & fld.Name.ToLower() & "_ext', TRUE)")
                End If
            End If
        Next

        sw.Append(vbCrLf & "            );")

        If isroot Then
            sw.Append(vbCrLf & "                $instanceid =  $this->input->get_post('instanceid', TRUE);")
        Else
            sw.Append(vbCrLf & "                $instanceid =  $this->input->get_post('instanceid', TRUE);")
            sw.Append(vbCrLf & "                $parentid =  $this->input->get_post('parentid', TRUE);")
        End If
        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "            $treeid=$this->input->post('treeid', FALSE);")
            sw.Append(vbCrLf & "            $" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->newRow($instanceid,$treeid,$data);")
        ElseIf isroot Then
            sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->newRow($instanceid,$data);")
        Else
            sw.Append(vbCrLf & "            $" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->newRow($instanceid,$parentid,$data);")
        End If

        sw.Append(vbCrLf & "            $return = $" & p.Name.ToLower() & ";")
        sw.Append(vbCrLf & "            print json_encode($return);")
        sw.Append(vbCrLf & "    }")

        ''''''''''''''''''''''''''

        If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "    function getRowTemp() {")
            sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRow post : '.json_encode($this->input->post(NULL, FALSE)));")
            sw.Append(vbCrLf & "        $empId  =  $this->input->get_post('id', TRUE);")

            If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                sw.Append(vbCrLf & "            $treeid  =  $this->input->get_post('treeid', TRUE);")
            End If

            sw.Append(vbCrLf & "        if (isset($empId)) {")

            If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $this->m_" & p.Name.ToLower() & "->getRowTemp($empId,$treeid);")
            Else
                sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $this->m_" & p.Name.ToLower() & "->getRowTemp($empId);")
            End If

            sw.Append(vbCrLf & "            $return = array(")
            sw.Append(vbCrLf & "                'success' => true,")
            sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower())
            sw.Append(vbCrLf & "            );")
            sw.Append(vbCrLf & "            print json_encode($return);")
            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "    }")


            sw.Append(vbCrLf & "    function getRowsTemp() {")
            'sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".getRows post : '.json_encode($this->input->post(NULL, FALSE)));")
            'sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".getRows get : '.json_encode($this->input->get(NULL, FALSE)));")

            sw.Append(vbCrLf & "            $group = $this->input->get('group', FALSE); ")
            sw.Append(vbCrLf & "           $sort = $this->input->get('sort', FALSE);")
            sw.Append(vbCrLf & "           if(!$sort && $group) $sort = $group;")
            sw.Append(vbCrLf & "           if(!$sort || $group == $sort) ")
            sw.Append(vbCrLf & "            {")
            sw.Append(vbCrLf & "            	$sort = json_decode($sort);")
            Dim sft As MTZMetaModel.MTZMetaModel.FIELDTYPE
            sft = sortfld.FieldType
            If sft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                sw.Append(vbCrLf & "            	$sort[] = array('property'=>'" + sortfld.Name.ToLower() + "_grid', 'direction'=>'ASC');")
            Else
                sw.Append(vbCrLf & "            	$sort[] = array('property'=>'" + sortfld.Name.ToLower() + "', 'direction'=>'ASC');")
            End If

            sw.Append(vbCrLf & "            	$sort = json_encode($sort);")
            sw.Append(vbCrLf & "            }")

            If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                sw.Append(vbCrLf & "            $instanceid=$this->input->get('instanceid', FALSE);")
                sw.Append(vbCrLf & "           	$treeid=$this->input->get('treeid', FALSE);")

                sw.Append(vbCrLf & "                     if(isset($instanceid)){")
                sw.Append(vbCrLf & "                         if($instanceid!=''){")
                sw.Append(vbCrLf & "           			if(isset($treeid)){")
                sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByInstanceTree');")
                sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByInstanceTreeTemp($instanceid,$treeid,$sort);")
                sw.Append(vbCrLf & "           			}else{")
                sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByInstance');")
                sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByInstanceTemp($instanceid,$sort);")
                sw.Append(vbCrLf & "           			}")

                sw.Append(vbCrLf & "                         }else{")

                sw.Append(vbCrLf & "                             if(isset($treeid)){")
                sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByTree');")
                sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByTreeTemp($treeid,$sort);")
                sw.Append(vbCrLf & "           			}else{")
                sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRows');")
                sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsTemp($sort);")
                sw.Append(vbCrLf & "           			}")
                sw.Append(vbCrLf & "                         }")
                sw.Append(vbCrLf & "                     }else{")
                sw.Append(vbCrLf & "           			if(isset($treeid)){")
                sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByTree');")
                sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByTreeTemp($treeid,$sort);")
                sw.Append(vbCrLf & "           			}else{")
                sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRows');")
                sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsTemp($sort);")
                sw.Append(vbCrLf & "           			}")
                sw.Append(vbCrLf & "                     }")


                sw.Append(vbCrLf & "           print json_encode($" & p.Name.ToLower & ");")
            ElseIf isroot Then
                sw.Append(vbCrLf & "            $instanceid=$this->input->get('instanceid', FALSE);")
                sw.Append(vbCrLf & "            if(isset($instanceid)){")
                sw.Append(vbCrLf & "                if($instanceid!=''){")
                sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByInstanceTemp($instanceid,$sort);")
                sw.Append(vbCrLf & "                }else{")
                sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsTemp($sort);")
                sw.Append(vbCrLf & "                }")
                sw.Append(vbCrLf & "            }else{")
                sw.Append(vbCrLf & "              $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsTemp($sort);")
                sw.Append(vbCrLf & "            }")
                sw.Append(vbCrLf & "            $return = array(")
                sw.Append(vbCrLf & "                'success' =>  TRUE ,")
                sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
                sw.Append(vbCrLf & "            );")

                sw.Append(vbCrLf & "        print json_encode($return);")
            Else
                sw.Append(vbCrLf & "            $parentid=$this->input->get('parentid', FALSE);")
                sw.Append(vbCrLf & "            if(isset($parentid)){")
                sw.Append(vbCrLf & "                if($parentid!=''){")
                sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByParentTemp($parentid,$sort);")
                sw.Append(vbCrLf & "                }else{")
                sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsTemp($sort);")
                sw.Append(vbCrLf & "                }")
                sw.Append(vbCrLf & "            }else{")
                sw.Append(vbCrLf & "              $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsTemp($sort);")
                sw.Append(vbCrLf & "            }")
                sw.Append(vbCrLf & "            $return = array(")
                sw.Append(vbCrLf & "                'success' =>  TRUE ,")
                sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
                sw.Append(vbCrLf & "            );")

                sw.Append(vbCrLf & "        print json_encode($return);")
            End If


            sw.Append(vbCrLf & "    }")

            sw.Append(vbCrLf & "    function getRowsByInstanceTemp() {")
            sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));")
            sw.Append(vbCrLf & "            $group = $this->input->get('group', FALSE); ")
            sw.Append(vbCrLf & "           $sort = $this->input->get('sort', FALSE);")
            sw.Append(vbCrLf & "           if(!$sort && $group) $sort = $group;")
            sw.Append(vbCrLf & "           if(!$sort || $group == $sort) ")
            sw.Append(vbCrLf & "            {")
            sw.Append(vbCrLf & "            	$sort = json_decode($sort);")
            sw.Append(vbCrLf & "            	$sort[] = array('property'=>'" + sortfld.Name.ToLower() + "', 'direction'=>'ASC');")
            sw.Append(vbCrLf & "            	$sort = json_encode($sort);")
            sw.Append(vbCrLf & "            }")

            sw.Append(vbCrLf & "        $InstId  =  $this->input->get_post('instanceid', TRUE);")
            sw.Append(vbCrLf & "        if (strlen($InstId) > 0) {")
            sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByInstanceTemp($InstId,$sort);")
            sw.Append(vbCrLf & "            $return = array(")
            sw.Append(vbCrLf & "                'success' =>  TRUE ,")
            sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
            sw.Append(vbCrLf & "            );")
            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "        else {")
            sw.Append(vbCrLf & "            $return = array(")
            sw.Append(vbCrLf & "                'success' => FALSE,")
            sw.Append(vbCrLf & "                'msg'     => 'Need instanceid to query.'")
            sw.Append(vbCrLf & "            );")
            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "        print json_encode($return);")
            sw.Append(vbCrLf & "    }")


            sw.Append(vbCrLf & "    function getRowsByParentTemp() {")
            sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));")

            sw.Append(vbCrLf & "            $group = $this->input->get('group', FALSE); ")
            sw.Append(vbCrLf & "           $sort = $this->input->get('sort', FALSE);")
            sw.Append(vbCrLf & "           if(!$sort && $group) $sort = $group;")
            sw.Append(vbCrLf & "           if(!$sort || $group == $sort) ")
            sw.Append(vbCrLf & "            {")
            sw.Append(vbCrLf & "            	$sort = json_decode($sort);")
            sw.Append(vbCrLf & "            	$sort[] = array('property'=>'" + sortfld.Name.ToLower() + "', 'direction'=>'ASC');")
            sw.Append(vbCrLf & "            	$sort = json_encode($sort);")
            sw.Append(vbCrLf & "            }")

            sw.Append(vbCrLf & "        $ParentId  =  $this->input->get_post('parentid', TRUE);")
            sw.Append(vbCrLf & "        if (strlen($ParentId) > 0) {")
            sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByParentTemp($ParentId,$sort);")
            sw.Append(vbCrLf & "            $return = array(")
            sw.Append(vbCrLf & "                'success' => TRUE,")
            sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
            sw.Append(vbCrLf & "            );")
            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "        else {")
            sw.Append(vbCrLf & "            $return = array(")
            sw.Append(vbCrLf & "                'success' => FALSE,")
            sw.Append(vbCrLf & "                'msg'     => 'Need parent parentid to query.'")
            sw.Append(vbCrLf & "            );")
            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "        print json_encode($return);")
            sw.Append(vbCrLf & "    }")
        End If


        ''''''''''''''''''''''''''

        sw.Append(vbCrLf & "    function getRow() {")
        sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRow post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "        $empId  =  $this->input->get_post('id', TRUE);")

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "            $treeid  =  $this->input->get_post('treeid', TRUE);")
        End If

        sw.Append(vbCrLf & "        if (isset($empId)) {")

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $this->m_" & p.Name.ToLower() & "->getRow($empId,$treeid);")
        Else
            sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $this->m_" & p.Name.ToLower() & "->getRow($empId);")
        End If

        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => true,")
        sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower())
        sw.Append(vbCrLf & "            );")
        sw.Append(vbCrLf & "            print json_encode($return);")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    }")


        sw.Append(vbCrLf & "    function getRows() {")
        'sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".getRows post : '.json_encode($this->input->post(NULL, FALSE)));")
        'sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".getRows get : '.json_encode($this->input->get(NULL, FALSE)));")

        sw.Append(vbCrLf & "            $group = $this->input->get('group', FALSE); ")
        sw.Append(vbCrLf & "           $sort = $this->input->get('sort', FALSE);")
        sw.Append(vbCrLf & "           if(!$sort && $group) $sort = $group;")
        sw.Append(vbCrLf & "           if(!$sort || $group == $sort) ")
        sw.Append(vbCrLf & "            {")
        sw.Append(vbCrLf & "            	$sort = json_decode($sort);")
        sw.Append(vbCrLf & "            	$sort[] = array('property'=>'" + sortfld.Name.ToLower() + "', 'direction'=>'ASC');")
        sw.Append(vbCrLf & "            	$sort = json_encode($sort);")
        sw.Append(vbCrLf & "            }")

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "            $instanceid=$this->input->get('instanceid', FALSE);")
            sw.Append(vbCrLf & "           	$treeid=$this->input->get('treeid', FALSE);")

            sw.Append(vbCrLf & "                     if(isset($instanceid)){")
            sw.Append(vbCrLf & "                         if($instanceid!=''){")
            sw.Append(vbCrLf & "           			if(isset($treeid)){")
            sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByInstanceTree');")
            sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByInstanceTree($instanceid,$treeid,$sort);")
            sw.Append(vbCrLf & "           			}else{")
            sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByInstance');")
            sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByInstance($instanceid,$sort);")
            sw.Append(vbCrLf & "           			}")

            sw.Append(vbCrLf & "                         }else{")

            sw.Append(vbCrLf & "                             if(isset($treeid)){")
            sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByTree');")
            sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByTree($treeid,$sort);")
            sw.Append(vbCrLf & "           			}else{")
            sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRows');")
            sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRows($sort);")
            sw.Append(vbCrLf & "           			}")
            sw.Append(vbCrLf & "                         }")
            sw.Append(vbCrLf & "                     }else{")
            sw.Append(vbCrLf & "           			if(isset($treeid)){")
            sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByTree');")
            sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByTree($treeid,$sort);")
            sw.Append(vbCrLf & "           			}else{")
            sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRows');")
            sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRows($sort);")
            sw.Append(vbCrLf & "           			}")
            sw.Append(vbCrLf & "                     }")


            sw.Append(vbCrLf & "           print json_encode($" & p.Name.ToLower & ");")
        ElseIf isroot Then
            sw.Append(vbCrLf & "            $instanceid=$this->input->get('instanceid', FALSE);")
            sw.Append(vbCrLf & "            if(isset($instanceid)){")
            sw.Append(vbCrLf & "                if($instanceid!=''){")
            sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByInstance($instanceid,$sort);")
            sw.Append(vbCrLf & "                }else{")
            sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows($sort);")
            sw.Append(vbCrLf & "                }")
            sw.Append(vbCrLf & "            }else{")
            sw.Append(vbCrLf & "              $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows($sort);")
            sw.Append(vbCrLf & "            }")
            sw.Append(vbCrLf & "            $return = array(")
            sw.Append(vbCrLf & "                'success' =>  TRUE ,")
            sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
            sw.Append(vbCrLf & "            );")

            sw.Append(vbCrLf & "        print json_encode($return);")
        Else
            sw.Append(vbCrLf & "            $parentid=$this->input->get('parentid', FALSE);")
            sw.Append(vbCrLf & "            if(isset($parentid)){")
            sw.Append(vbCrLf & "                if($parentid!=''){")
            sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByParent($parentid,$sort);")
            sw.Append(vbCrLf & "                }else{")
            sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows($sort);")
            sw.Append(vbCrLf & "                }")
            sw.Append(vbCrLf & "            }else{")
            sw.Append(vbCrLf & "              $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows($sort);")
            sw.Append(vbCrLf & "            }")
            sw.Append(vbCrLf & "            $return = array(")
            sw.Append(vbCrLf & "                'success' =>  TRUE ,")
            sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
            sw.Append(vbCrLf & "            );")

            sw.Append(vbCrLf & "        print json_encode($return);")
        End If


        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function getRowsByInstance() {")
        sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "            $group = $this->input->get('group', FALSE); ")
        sw.Append(vbCrLf & "           $sort = $this->input->get('sort', FALSE);")
        sw.Append(vbCrLf & "           if(!$sort && $group) $sort = $group;")
        sw.Append(vbCrLf & "           if(!$sort || $group == $sort) ")
        sw.Append(vbCrLf & "            {")
        sw.Append(vbCrLf & "            	$sort = json_decode($sort);")
        sw.Append(vbCrLf & "            	$sort[] = array('property'=>'" + sortfld.Name.ToLower() + "', 'direction'=>'ASC');")
        sw.Append(vbCrLf & "            	$sort = json_encode($sort);")
        sw.Append(vbCrLf & "            }")

        sw.Append(vbCrLf & "        $InstId  =  $this->input->get_post('instanceid', TRUE);")
        sw.Append(vbCrLf & "        if (strlen($InstId) > 0) {")
        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByInstance($InstId,$sort);")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' =>  TRUE ,")
        sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
        sw.Append(vbCrLf & "            );")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        else {")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => FALSE,")
        sw.Append(vbCrLf & "                'msg'     => 'Need instanceid to query.'")
        sw.Append(vbCrLf & "            );")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        print json_encode($return);")
        sw.Append(vbCrLf & "    }")


        sw.Append(vbCrLf & "    function getRowsByParent() {")
        sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));")

        sw.Append(vbCrLf & "            $group = $this->input->get('group', FALSE); ")
        sw.Append(vbCrLf & "           $sort = $this->input->get('sort', FALSE);")
        sw.Append(vbCrLf & "           if(!$sort && $group) $sort = $group;")
        sw.Append(vbCrLf & "           if(!$sort || $group == $sort) ")
        sw.Append(vbCrLf & "            {")
        sw.Append(vbCrLf & "            	$sort = json_decode($sort);")
        sw.Append(vbCrLf & "            	$sort[] = array('property'=>'" + sortfld.Name.ToLower() + "', 'direction'=>'ASC');")
        sw.Append(vbCrLf & "            	$sort = json_encode($sort);")
        sw.Append(vbCrLf & "            }")

        sw.Append(vbCrLf & "        $ParentId  =  $this->input->get_post('parentid', TRUE);")
        sw.Append(vbCrLf & "        if (strlen($ParentId) > 0) {")
        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByParent($ParentId,$sort);")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => TRUE,")
        sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
        sw.Append(vbCrLf & "            );")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        else {")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => FALSE,")
        sw.Append(vbCrLf & "                'msg'     => 'Need parent parentid to query.'")
        sw.Append(vbCrLf & "            );")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        print json_encode($return);")
        sw.Append(vbCrLf & "    }")



        sw.Append(vbCrLf & "    function deleteRow() {")
        sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "        $tempId  =  $this->input->get_post('" & p.Name.ToLower() & "id', TRUE);")
        sw.Append(vbCrLf & "        if (strlen($tempId) > 0) {")
        sw.Append(vbCrLf & "            $return = $this->m_" & p.Name.ToLower() & "->deleteRow($tempId);")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        else {")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => FALSE,")
        sw.Append(vbCrLf & "                'msg'     => 'No  ID to delete'")
        sw.Append(vbCrLf & "            );")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        print json_encode($return);")
        sw.Append(vbCrLf & "    }")



        sw.Append(vbCrLf & "    private function _loadModels () {")
        sw.Append(vbCrLf & "        $this->load->model('M_" & p.Name.ToLower() & "', 'm_" & p.Name.ToLower() & "');")
        sw.Append(vbCrLf & "    }")
        sw.Append(vbCrLf & "}")


        sw.Append(vbCrLf & "?>")
        Return sw.ToString()
    End Function




    'Private Function PartMake_CIMartController(ByVal p As MTZMetaModel.MTZMetaModel.PART) As String
    '    If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""

    '    Dim isroot As Boolean = False
    '    If TypeName(p.Parent.Parent) = "OBJECTTYPE" Then
    '        isroot = True
    '    End If

    '    Dim sw As StringBuilder
    '    sw = New StringBuilder

    '    sw.Append("<?php")
    '    sw.Append(vbCrLf & "	 class C_mart_" & p.Name.ToLower() & " extends CI_Controller {")

    '    sw.Append(vbCrLf & "    function __construct() {")
    '    sw.Append(vbCrLf & "         parent::__construct();")
    '    sw.Append(vbCrLf & "        $this->_loadModels();")
    '    sw.Append(vbCrLf & "    }")

    '    sw.Append(vbCrLf & "    function getRow() {")
    '    sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRow post : '.json_encode($this->input->post(NULL, FALSE)));")
    '    sw.Append(vbCrLf & "        $empId  =  $this->input->get_post('id', TRUE);")

    '    If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
    '        sw.Append(vbCrLf & "            $treeid  =  $this->input->get_post('treeid', TRUE);")
    '    End If

    '    sw.Append(vbCrLf & "        if (isset($empId)) {")

    '    If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
    '        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $this->m_" & p.Name.ToLower() & "->getRow($empId,$treeid);")
    '    Else
    '        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $this->m_" & p.Name.ToLower() & "->getRow($empId);")
    '    End If

    '    sw.Append(vbCrLf & "            $return = array(")
    '    sw.Append(vbCrLf & "                'success' => true,")
    '    sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower())
    '    sw.Append(vbCrLf & "            );")
    '    sw.Append(vbCrLf & "            print json_encode($return);")
    '    sw.Append(vbCrLf & "        }")
    '    sw.Append(vbCrLf & "    }")




    '    sw.Append(vbCrLf & "    function getRows() {")
    '    sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".getRows post : '.json_encode($this->input->post(NULL, FALSE)));")
    '    sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".getRows get : '.json_encode($this->input->get(NULL, FALSE)));")



    '    If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
    '        sw.Append(vbCrLf & "            $instanceid=$this->input->get('instanceid', FALSE);")
    '        sw.Append(vbCrLf & "           	$treeid=$this->input->get('treeid', FALSE);")

    '        sw.Append(vbCrLf & "                     if(isset($instanceid)){")
    '        sw.Append(vbCrLf & "                         if($instanceid!=''){")
    '        sw.Append(vbCrLf & "           			if(isset($treeid)){")
    '        sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByInstanceTree');")
    '        sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByInstanceTree($instanceid,$treeid);")
    '        sw.Append(vbCrLf & "           			}else{")
    '        sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByInstance');")
    '        sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByInstance($instanceid);")
    '        sw.Append(vbCrLf & "           			}")

    '        sw.Append(vbCrLf & "                         }else{")

    '        sw.Append(vbCrLf & "                             if(isset($treeid)){")
    '        sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByTree');")
    '        sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByTree($treeid);")
    '        sw.Append(vbCrLf & "           			}else{")
    '        sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRows');")
    '        sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRows();")
    '        sw.Append(vbCrLf & "           			}")
    '        sw.Append(vbCrLf & "                         }")
    '        sw.Append(vbCrLf & "                     }else{")
    '        sw.Append(vbCrLf & "           			if(isset($treeid)){")
    '        sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRowsByTree');")
    '        sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRowsByTree($treeid);")
    '        sw.Append(vbCrLf & "           			}else{")
    '        sw.Append(vbCrLf & "           				log_message('debug', '" & p.Name & ".getRows getRows');")
    '        sw.Append(vbCrLf & "           				$" & p.Name.ToLower & "= $this->m_" & p.Name.ToLower & "->getRows();")
    '        sw.Append(vbCrLf & "           			}")
    '        sw.Append(vbCrLf & "                     }")


    '        sw.Append(vbCrLf & "           print json_encode($" & p.Name.ToLower & ");")
    '    ElseIf isroot Then
    '        sw.Append(vbCrLf & "            $instanceid=$this->input->get('instanceid', FALSE);")
    '        sw.Append(vbCrLf & "            if(isset($instanceid)){")
    '        sw.Append(vbCrLf & "                if($instanceid!=''){")
    '        sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByInstance($instanceid);")
    '        sw.Append(vbCrLf & "                }else{")
    '        sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows();")
    '        sw.Append(vbCrLf & "                }")
    '        sw.Append(vbCrLf & "            }else{")
    '        sw.Append(vbCrLf & "              $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows();")
    '        sw.Append(vbCrLf & "            }")
    '        sw.Append(vbCrLf & "            $return = array(")
    '        sw.Append(vbCrLf & "                'success' => TRUE,")
    '        sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
    '        sw.Append(vbCrLf & "            );")

    '        sw.Append(vbCrLf & "        print json_encode($return);")
    '    Else
    '        sw.Append(vbCrLf & "            $parentid=$this->input->get('parentid', FALSE);")
    '        sw.Append(vbCrLf & "            if(isset($parentid)){")
    '        sw.Append(vbCrLf & "                if($parentid!=''){")
    '        sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByParent($parentid);")
    '        sw.Append(vbCrLf & "                }else{")
    '        sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows();")
    '        sw.Append(vbCrLf & "                }")
    '        sw.Append(vbCrLf & "            }else{")
    '        sw.Append(vbCrLf & "              $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows();")
    '        sw.Append(vbCrLf & "            }")
    '        sw.Append(vbCrLf & "            $return = array(")
    '        sw.Append(vbCrLf & "                'success' => TRUE,")
    '        sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
    '        sw.Append(vbCrLf & "            );")

    '        sw.Append(vbCrLf & "        print json_encode($return);")
    '    End If


    '    sw.Append(vbCrLf & "    }")

    '    sw.Append(vbCrLf & "    function getRowsByInstance() {")
    '    sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));")
    '    sw.Append(vbCrLf & "        $InstId  =  $this->input->get_post('instanceid', TRUE);")
    '    sw.Append(vbCrLf & "        if (strlen($InstId) > 0) {")
    '    sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByInstance($InstId);")
    '    sw.Append(vbCrLf & "            $return = array(")
    '    sw.Append(vbCrLf & "                'success' => TRUE,")
    '    sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
    '    sw.Append(vbCrLf & "            );")
    '    sw.Append(vbCrLf & "        }")
    '    sw.Append(vbCrLf & "        else {")
    '    sw.Append(vbCrLf & "            $return = array(")
    '    sw.Append(vbCrLf & "                'success' => FALSE,")
    '    sw.Append(vbCrLf & "                'msg'     => 'Need instanceid to query.'")
    '    sw.Append(vbCrLf & "            );")
    '    sw.Append(vbCrLf & "        }")
    '    sw.Append(vbCrLf & "        print json_encode($return);")
    '    sw.Append(vbCrLf & "    }")


    '    sw.Append(vbCrLf & "    function getRowsByParent() {")
    '    sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));")
    '    sw.Append(vbCrLf & "        $ParentId  =  $this->input->get_post('parentid', TRUE);")
    '    sw.Append(vbCrLf & "        if (strlen($ParentId) > 0) {")
    '    sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByParent($ParentId);")
    '    sw.Append(vbCrLf & "            $return = array(")
    '    sw.Append(vbCrLf & "                'success' => TRUE,")
    '    sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
    '    sw.Append(vbCrLf & "            );")
    '    sw.Append(vbCrLf & "        }")
    '    sw.Append(vbCrLf & "        else {")
    '    sw.Append(vbCrLf & "            $return = array(")
    '    sw.Append(vbCrLf & "                'success' => FALSE,")
    '    sw.Append(vbCrLf & "                'msg'     => 'Need parent parentid to query.'")
    '    sw.Append(vbCrLf & "            );")
    '    sw.Append(vbCrLf & "        }")
    '    sw.Append(vbCrLf & "        print json_encode($return);")
    '    sw.Append(vbCrLf & "    }")


    '    sw.Append(vbCrLf & "    private function _loadModels () {")
    '    sw.Append(vbCrLf & "        $this->load->model('M_mart_" & p.Name.ToLower() & "', 'm_" & p.Name.ToLower() & "');")
    '    sw.Append(vbCrLf & "    }")
    '    sw.Append(vbCrLf & "}")


    '    sw.Append(vbCrLf & "?>")
    '    Return sw.ToString()
    'End Function





    Private Function PartMake_GridJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal objmode As String, ByVal UseMartService As Boolean) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Dim i As Integer


        sw.Append(vbCrLf & "var groupingFeature_" & P.Name.ToLower() & " = Ext.create('Ext.grid.feature.Grouping',{")
        sw.Append(vbCrLf & "groupByText:  'Группировать по этому полю',")
        sw.Append(vbCrLf & "showGroupsText:  'Показать группировку'")
        sw.Append(vbCrLf & "});")

        sw.Append(vbCrLf & "var filterFeature_" & P.Name.ToLower() & " = {")
        sw.Append(vbCrLf & "menuFilterText:  'Фильтр',")
        sw.Append(vbCrLf & "ftype: 'filters',")
        sw.Append(vbCrLf & "local: true ")
        sw.Append(vbCrLf & "};")




        sw.Append(vbCrLf & " var p1;")
        If Not UseMartService Then
            sw.Append(vbCrLf & "    function onDeleteConfirm(selection){")
            sw.Append(vbCrLf & "      if (selection) {")
            sw.Append(vbCrLf & "        Ext.Ajax.request({")
            sw.Append(vbCrLf & "            url:    rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/deleteRow',")
            sw.Append(vbCrLf & "            method:  'POST',")
            sw.Append(vbCrLf & "    		params: { ")
            sw.Append(vbCrLf & "    				" & P.Name.ToLower() & "id: selection.get('" & P.Name.ToLower() & "id')")
            sw.Append(vbCrLf & "    				}")
            sw.Append(vbCrLf & "    	});")
            sw.Append(vbCrLf & "    	p1.store.remove(selection);")
            sw.Append(vbCrLf & "      }")
            sw.Append(vbCrLf & "    };")

            sw.Append(vbCrLf & "    function onDeleteClick(){")
            sw.Append(vbCrLf & "      var selection = p1.getView().getSelectionModel().getSelection()[0];")
            sw.Append(vbCrLf & "      if (selection) {")
            'sw.Append(vbCrLf & "   	  if(CheckOperation('" + P.Name + ".del')!=0){")
            sw.Append(vbCrLf & "   	  if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "        Ext.Msg.show({")
            sw.Append(vbCrLf & "            title:  'Удалить?',")
            sw.Append(vbCrLf & "            msg:    'Удалить строку из базы данных?',")
            sw.Append(vbCrLf & "        	buttons: Ext.Msg.YESNO,")
            sw.Append(vbCrLf & "        	icon:   Ext.MessageBox.QUESTION,")
            sw.Append(vbCrLf & "        	fn: function(btn,text,opt){")
            sw.Append(vbCrLf & "        		if(btn=='yes'){")
            sw.Append(vbCrLf & "        			onDeleteConfirm(opt.selectedRow);")
            sw.Append(vbCrLf & "        	    }")
            sw.Append(vbCrLf & "        	},")
            sw.Append(vbCrLf & "            caller: this,")
            sw.Append(vbCrLf & "            selectedRow: selection")
            sw.Append(vbCrLf & "        });")

            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Удаление строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "      }")
            sw.Append(vbCrLf & "    };")





            sw.Append(vbCrLf & "    function onAddClick(){")
            'sw.Append(vbCrLf & "   	if(CheckOperation('" + P.Name + ".add')!=0){")
            sw.Append(vbCrLf & "   	if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "                var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")

            sw.Append(vbCrLf & "                p1.store.insert(0, new model_" & P.Name.ToLower() & "());")
            sw.Append(vbCrLf & "                record= p1.store.getAt(0);")
            sw.Append(vbCrLf & "                record.set('instanceid',p1.instanceid);")

            sw.Append(vbCrLf & "                edit.getComponent(0).setActiveRecord(record,p1.instanceid);")
            sw.Append(vbCrLf & "                edit.show();")
            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Создание строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "    };")

        End If
        sw.Append(vbCrLf & "    function onRefreshClick(){")
        sw.Append(vbCrLf & "            p1.store.load({params:{instanceid: p1.instanceid}});")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & "    function onEditClick(){")
        sw.Append(vbCrLf & "        var selection = p1.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        'sw.Append(vbCrLf & "   	    if(CheckOperation('" + P.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "   	    if(CheckOperation('" + ot.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "            var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")
        sw.Append(vbCrLf & "            edit.getComponent(0).setActiveRecord(selection,selection.get('instanceid'));")
        sw.Append(vbCrLf & "            edit.show();")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Изменение строк не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & " p1=   new Ext.grid.Panel(")
        sw.Append(vbCrLf & "         {")
        sw.Append(vbCrLf & "        itemId:  id,")
        sw.Append(vbCrLf & "        store:  mystore,")
        'sw.Append(vbCrLf & "        title:'" & P.Caption & "',")
        'sw.Append(vbCrLf & "        height: '550px',")
        sw.Append(vbCrLf & "        width:600,")
        sw.Append(vbCrLf & "        header:false,")
        'sw.Append(vbCrLf & "        flex: 1,")
        sw.Append(vbCrLf & "        layout:'fit',")
        sw.Append(vbCrLf & "        scroll:'both',")
        sw.Append(vbCrLf & "      stateful:stateFulSystem,")
        sw.Append(vbCrLf & "       stateId:  '" & P.Name.ToLower() & objmode & "',")

        sw.Append(vbCrLf & "        iconCls:  'icon-grid',")
        sw.Append(vbCrLf & "        frame: true,")
        sw.Append(vbCrLf & "        instanceid: '',")

        sw.Append(vbCrLf & "        features: [groupingFeature_" & P.Name.ToLower() & ",filterFeature_" & P.Name.ToLower() & "],")



        sw.Append(vbCrLf & "          dockedItems: [{")
        sw.Append(vbCrLf & "                xtype:  'toolbar',")
        sw.Append(vbCrLf & "                items: [")
        If Not UseMartService Then
            sw.Append(vbCrLf & "                {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_add',")
            sw.Append(vbCrLf & "                    text:   'Создать',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowAdd = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onAddClick")

            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
            sw.Append(vbCrLf & "                    text:   'Изменить',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'edit',")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowEdit = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onEditClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_delete',")
            sw.Append(vbCrLf & "                    text:   'Удалить',")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'delete',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowDelete = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                   hidden : true,")
                End If
            End If

            sw.Append(vbCrLf & "                    handler : onDeleteClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
            sw.Append(vbCrLf & "                    text:   'Обновить',")
            sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    handler : onRefreshClick")
            sw.Append(vbCrLf & "                }]")
            sw.Append(vbCrLf & "            }],")
        Else

            sw.Append(vbCrLf & "                {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
            sw.Append(vbCrLf & "                    text:   'Свойства',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'edit',")
            sw.Append(vbCrLf & "                    handler : onEditClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
            sw.Append(vbCrLf & "                    text:   'Обновить',")
            sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    handler : onRefreshClick")
            sw.Append(vbCrLf & "                }]")
            sw.Append(vbCrLf & "            }],")
        End If

        sw.Append(vbCrLf & "        columns: [")

        Dim xtype As String = ""
        Dim isfirst As Boolean

        isfirst = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            If LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, objmode) And Not fld.TheStyle.Contains("hidden") Then



                ft = fld.FieldType

                If ft.Name.ToLower <> "password" Then


                    xtype = "{"


                    If Not isfirst Then
                        sw.Append(vbCrLf & "            ,")
                    End If
                    isfirst = False

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                        If ft.Name.ToLower = "file" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'/output_file.php?ID={" & fld.Name.ToLower & "}&ext={" & fld.Name.ToLower & "_ext}\' target=\'_blank\'>Файл</a>'}")
                        ElseIf ft.Name.ToLower = "url" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'{" & fld.Name.ToLower & "}\' target=\'_blank\'>" & fld.Caption & "</a>'}")
                        ElseIf ft.Name.ToLower = "html" Then
                            sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 200, dataIndex: '" & fld.Name.ToLower() & "', sortable: true,")
                            sw.Append(vbCrLf & " renderer: function(value){var S =new String(value);  S=S.replace(new RegExp('/>','g'),'');  S=S.replace(new RegExp('<','g'),''); S=S.replace(new RegExp('>','g'),''); if(S.length >255) S=S.substr(0,255); return S;}}")

                        Else


                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 200, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If
                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                                'sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',   format:'Y-m-d'}")
                                'If ft.Name.ToLower = "date" Then
                                '    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',   format:'Y-m-d'}"
                                'ElseIf ft.Name.ToLower = "time" Then

                                '    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',   format:'H:i:s'}")
                                'ElseIf ft.Name.ToLower = "datetime" Then

                                '    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:110, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',   format:'Y-m-d H:i:s'}")
                                'ElseIf ft.Name.ToLower = "birthday" Then
                                '    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")
                                'End If

                                If ft.Name.ToLower = "date" Then
                                    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',   renderer:myDateOnlyRenderer }")
                                ElseIf ft.Name.ToLower = "time" Then

                                    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',   renderer:myTimeRenderer }")
                                ElseIf ft.Name.ToLower = "datetime" Then

                                    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:110, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',    renderer:myDateRenderer}")
                                ElseIf ft.Name.ToLower = "birthday" Then
                                    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")
                                End If



                            End If

                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If
                        End If
                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")


                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:80, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:200, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If
                End If
            End If

        Next
        sw.Append(vbCrLf & "        ]")  ' columns



        sw.Append(vbCrLf & "       ,") ' initComponent



        sw.Append(vbCrLf & "    listeners: {")
        sw.Append(vbCrLf & "     render : function(grid){")
        sw.Append(vbCrLf & "                grid.store.on('load', function(store, records, options){")
        sw.Append(vbCrLf & "                        if(store.count() > 0) grid.getSelectionModel().select(0);      ")
        sw.Append(vbCrLf & "                }); ")
        sw.Append(vbCrLf & "         },")
        sw.Append(vbCrLf & "        itemdblclick: function() { ")
        sw.Append(vbCrLf & "    	    onEditClick();")
        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "          itemclick: function(view , record){")
        sw.Append(vbCrLf & "         p1.down('#delete').setDisabled(false);")
        sw.Append(vbCrLf & "         p1.down('#edit').setDisabled(false);")
        sw.Append(vbCrLf & "    },")
        sw.Append(vbCrLf & "    select: function( selmodel, record,  index,  eOpts ){")
        sw.Append(vbCrLf & "        p1.down('#delete').setDisabled(false);")
        sw.Append(vbCrLf & "        p1.down('#edit').setDisabled(false);")
        sw.Append(vbCrLf & "    }, ")
        sw.Append(vbCrLf & "    selectionchange: function(selModel, selections){")
        sw.Append(vbCrLf & "    	 p1.down('#delete').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "    	 p1.down('#edit').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "    }")
        sw.Append(vbCrLf & "    }")


        sw.Append(vbCrLf & "    }")  'Ext.Define_data
        sw.Append(vbCrLf & "    );")  'Ext.Define

        sw.Append(vbCrLf & "return p1;")

        Return sw.ToString()
    End Function



    Private Function PartMake_GridGridJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal objmode As String, ByVal UseMartService As Boolean) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Dim i As Integer

        Dim child As MTZMetaModel.MTZMetaModel.PART
        child = P.PART.Item(1)

        sw.Append(PartMake_GridChildJS(ot, child, objmode, UseMartService))

        sw.Append(vbCrLf & "var groupingFeature_" & P.Name.ToLower() & " = Ext.create('Ext.grid.feature.Grouping',{")
        sw.Append(vbCrLf & "groupByText:  'Группировать по этому полю',")
        sw.Append(vbCrLf & "showGroupsText:  'Показать группировку'")
        'sw.Append(vbCrLf & "groupHeaderTpl:  'Cuisine: {name} ({rows.length} Item{[values.rows.length > 1 ? ""s"" : """"]})'")
        sw.Append(vbCrLf & "});")


        sw.Append(vbCrLf & "var p1;")

        sw.Append(vbCrLf & "    function onDeleteConfirm(selection){")
        sw.Append(vbCrLf & "      if (selection) {")
        sw.Append(vbCrLf & "        Ext.Ajax.request({")
        sw.Append(vbCrLf & "            url:    rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/deleteRow',")
        sw.Append(vbCrLf & "            method:  'POST',")
        sw.Append(vbCrLf & "    		params: { ")
        sw.Append(vbCrLf & "    				" & P.Name.ToLower() & "id: selection.get('" & P.Name.ToLower() & "id')")
        sw.Append(vbCrLf & "    				}")
        sw.Append(vbCrLf & "    	});")
        sw.Append(vbCrLf & "    	p1.store.remove(selection);")
        sw.Append(vbCrLf & "      }")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & "    function onDeleteClick(){")
        sw.Append(vbCrLf & "      var selection = p1.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "      if (selection) {")
        'sw.Append(vbCrLf & "   	  if(CheckOperation('" + P.Name + ".del')!=0){")
        sw.Append(vbCrLf & "   	  if(CheckOperation('" + ot.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "        Ext.Msg.show({")
        sw.Append(vbCrLf & "            title:  'Удалить?',")
        sw.Append(vbCrLf & "            msg:    'Удалить строку из базы данных?',")
        sw.Append(vbCrLf & "        	buttons: Ext.Msg.YESNO,")
        sw.Append(vbCrLf & "            icon:   Ext.window.MessageBox.QUESTION,")
        sw.Append(vbCrLf & "        	fn: function(btn,text,opt){")
        sw.Append(vbCrLf & "        		if(btn=='yes'){")
        sw.Append(vbCrLf & "        			onDeleteConfirm(opt.selectedRow);")
        sw.Append(vbCrLf & "        	    }")
        sw.Append(vbCrLf & "        	},")

        sw.Append(vbCrLf & "            caller: this,")
        sw.Append(vbCrLf & "            selectedRow: selection")
        sw.Append(vbCrLf & "        });")

        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Удаление строк не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")

        sw.Append(vbCrLf & "      }")
        sw.Append(vbCrLf & "    };")





        sw.Append(vbCrLf & "    function onAddClick(){")
        'sw.Append(vbCrLf & "   	if(CheckOperation('" + P.Name + ".add')!=0){")
        sw.Append(vbCrLf & "   	if(CheckOperation('" + ot.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "                var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")

        sw.Append(vbCrLf & "                p1.store.insert(0, new model_" & P.Name.ToLower() & "());")
        sw.Append(vbCrLf & "                record= p1.store.getAt(0);")
        sw.Append(vbCrLf & "                record.set('instanceid',p1.instanceid);")

        sw.Append(vbCrLf & "                edit.getComponent(0).setActiveRecord(record,p1.instanceid);")
        sw.Append(vbCrLf & "                edit.show();")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Создание строк не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")

        sw.Append(vbCrLf & "    };")


        sw.Append(vbCrLf & "    function onRefreshClick(){")
        sw.Append(vbCrLf & "            p1.store.load({params:{instanceid: p1.instanceid}});")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & "    function onEditClick(){")
        sw.Append(vbCrLf & "        var selection = p1.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        'sw.Append(vbCrLf & "   	    if(CheckOperation('" + P.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "   	    if(CheckOperation('" + ot.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "            var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")
        sw.Append(vbCrLf & "            edit.getComponent(0).setActiveRecord(selection,selection.get('instanceid'));")
        sw.Append(vbCrLf & "            edit.show();")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Изменение строк не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & " p1=   new Ext.grid.Panel({")
        sw.Append(vbCrLf & "        itemId: id,")
        sw.Append(vbCrLf & "        store:  mystore,")
        ' sw.Append(vbCrLf & "            title:'" & P.Caption & "',")
        'sw.Append(vbCrLf & "            height: '550px',")
        'sw.Append(vbCrLf & "            flex: 1,")
        'sw.Append(vbCrLf & "        layout:'fit',")
        'sw.Append(vbCrLf & "        iconCls:  'icon-grid',")
        sw.Append(vbCrLf & "        frame: true,")
        'sw.Append(vbCrLf & "        hideHeaders: true,")
        sw.Append(vbCrLf & "        instanceid: '',")
        sw.Append(vbCrLf & "        scroll:'both',")
        sw.Append(vbCrLf & "        autoScroll:true,")
        sw.Append(vbCrLf & "        width:600,")

        sw.Append(vbCrLf & "        features: [groupingFeature_" & P.Name.ToLower() & "],")



        sw.Append(vbCrLf & "          dockedItems: [{")
        sw.Append(vbCrLf & "                xtype:  'toolbar',")
        sw.Append(vbCrLf & "                items: [")

        sw.Append(vbCrLf & "                {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_add',")
        sw.Append(vbCrLf & "                    text:   'Создать',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : onAddClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
        sw.Append(vbCrLf & "                    text:   'Изменить',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    disabled: true,")
        sw.Append(vbCrLf & "                    itemId:  'edit',")
        sw.Append(vbCrLf & "                    handler : onEditClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_delete',")
        sw.Append(vbCrLf & "                    text:   'Удалить',")
        sw.Append(vbCrLf & "                    disabled: true,")
        sw.Append(vbCrLf & "                    itemId:  'delete',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : onDeleteClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
        sw.Append(vbCrLf & "                    text:   'Обновить',")
        sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : onRefreshClick")
        sw.Append(vbCrLf & "                }]")
        sw.Append(vbCrLf & "            }],")

        sw.Append(vbCrLf & "        columns: [")

        Dim xtype As String = ""
        Dim isfirst As Boolean = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            If LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, objmode) And Not fld.TheStyle.Contains("hidden") Then

                ft = fld.FieldType
                If ft.Name.ToLower <> "password" Then
                    xtype = "{"


                    If Not isfirst Then
                        sw.Append(vbCrLf & "            ,")
                    End If
                    isfirst = False

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                        If ft.Name.ToLower = "file" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'/output_file.php?ID={" & fld.Name.ToLower & "}&ext={" & fld.Name.ToLower & "_ext}\' target=\'_blank\'>Файл</a>'}")
                        ElseIf ft.Name.ToLower = "url" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'{" & fld.Name.ToLower & "}\' target=\'_blank\'>" & fld.Caption & "</a>'}")

                        Else
                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 200, dataIndex: '" & fld.Name.ToLower() & "', sortable: true }")

                            End If
                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:80, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If

                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If
                        End If
                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")


                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:200, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If
                End If
            End If
        Next
        sw.Append(vbCrLf & "        ]")  ' columns

        sw.Append(vbCrLf & ",")
        sw.Append(vbCrLf & "	bbar:grid_" + child.Name.ToLower + ", ")



        sw.Append(vbCrLf & "    listeners: {")
        sw.Append(vbCrLf & "        resize: function ( tree, width, height, oldWidth, oldHeight, eOpts ){")
        sw.Append(vbCrLf & "        		grid_" + child.Name.ToLower + ".setHeight( height * 0.5 );")
        sw.Append(vbCrLf & "        },")

        sw.Append(vbCrLf & "        render : function(grid){")
        sw.Append(vbCrLf & "                grid.store.on('load', function(store, records, options){")
        sw.Append(vbCrLf & "                        if(store.count() > 0) grid.getSelectionModel().select(0);      ")
        sw.Append(vbCrLf & "                }); ")
        sw.Append(vbCrLf & "         },")
        sw.Append(vbCrLf & "        itemdblclick: function() { ")
        sw.Append(vbCrLf & "    	    onEditClick();")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        ,itemclick: function(view,record) { ")
        sw.Append(vbCrLf & "           p1.down('#delete').setDisabled(false);")
        sw.Append(vbCrLf & "           p1.down('#edit').setDisabled(false);")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".instanceid=p1.instanceid;")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".parentid=record.get('" + P.Name.ToLower + "id');")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".store.load({params:{ parentid:record.get('" + P.Name.ToLower + "id')} })")

        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "        selectionchange: function(selModel, selections){")
        sw.Append(vbCrLf & "        p1.down('#delete').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "        p1.down('#edit').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "        var selection = selections[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        sw.Append(vbCrLf & "           p1.down('#grd_" + child.Name.ToLower + "').instanceid=p1.instanceid;")
        sw.Append(vbCrLf & "           p1.down('#grd_" + child.Name.ToLower + "').parentid=selection.get('" + P.Name.ToLower + "id');")
        sw.Append(vbCrLf & "           p1.down('#grd_" + child.Name.ToLower + "').store.load({params:{ parentid:selection.get('" + P.Name.ToLower + "id')} })")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "       }")
        sw.Append(vbCrLf & "    }")


        sw.Append(vbCrLf & "    }")  'Ext.Define_data
        sw.Append(vbCrLf & "    );")  'Ext.Define

        sw.Append(vbCrLf & "return p1;")


        Return sw.ToString()
    End Function



    Private Function PartMake_GridChildJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal objmode As String, ByVal UseMartService As Boolean, Optional ByVal bbar As Boolean = True) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Dim i As Integer


        sw.Append(vbCrLf & "var groupingFeature_" & P.Name.ToLower() & " = Ext.create('Ext.grid.feature.Grouping',{")
        sw.Append(vbCrLf & "groupByText:  'Группировать по этому полю',")
        sw.Append(vbCrLf & "showGroupsText:  'Показать группировку'")
        'sw.Append(vbCrLf & "groupHeaderTpl:  'Cuisine: {name} ({rows.length} Item{[values.rows.length > 1 ? ""s"" : """"]})'")
        sw.Append(vbCrLf & "});")


        sw.Append(vbCrLf & "var grid_" & P.Name.ToLower() & ";")

        If Not UseMartService Then
            sw.Append(vbCrLf & "    function ChildOnDeleteConfirm(selection){")
            sw.Append(vbCrLf & "      if (selection) {")
            sw.Append(vbCrLf & "        Ext.Ajax.request({")
            sw.Append(vbCrLf & "            url:    rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/deleteRow',")
            sw.Append(vbCrLf & "            method:  'POST',")
            sw.Append(vbCrLf & "    		params: { ")
            sw.Append(vbCrLf & "    				" & P.Name.ToLower() & "id: selection.get('" & P.Name.ToLower() & "id')")
            sw.Append(vbCrLf & "    				}")
            sw.Append(vbCrLf & "    	});")
            sw.Append(vbCrLf & "    	grid_" & P.Name.ToLower() & ".store.remove(selection);")
            sw.Append(vbCrLf & "      }")
            sw.Append(vbCrLf & "    };")

            sw.Append(vbCrLf & "     function ChildOnDeleteClick(){")
            sw.Append(vbCrLf & "    if( grid_" & P.Name.ToLower() & ".parentid=='{00000000-0000-0000-0000-000000000000}') {return;}")
            sw.Append(vbCrLf & "      var selection = grid_" & P.Name.ToLower() & ".getView().getSelectionModel().getSelection()[0];")
            sw.Append(vbCrLf & "      if (selection) {")
            'sw.Append(vbCrLf & "   	  if(CheckOperation('" + P.Name + ".del')!=0){")
            sw.Append(vbCrLf & "   	  if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "        Ext.Msg.show({")
            sw.Append(vbCrLf & "            title:  'Удалить?',")
            sw.Append(vbCrLf & "            msg:    'Удалить строку из базы данных?',")
            sw.Append(vbCrLf & "        	buttons: Ext.Msg.YESNO,")
            sw.Append(vbCrLf & "            icon:   Ext.window.MessageBox.QUESTION,")
            sw.Append(vbCrLf & "        	fn: function(btn,text,opt){")
            sw.Append(vbCrLf & "        		if(btn=='yes'){")
            sw.Append(vbCrLf & "        			ChildOnDeleteConfirm(opt.selectedRow);")
            sw.Append(vbCrLf & "        	    }")
            sw.Append(vbCrLf & "        	},")

            sw.Append(vbCrLf & "            caller: grid_" & P.Name.ToLower() & ",")
            sw.Append(vbCrLf & "            selectedRow: selection")
            sw.Append(vbCrLf & "        });")

            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Удаление строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "      }")
            sw.Append(vbCrLf & "    };")





            sw.Append(vbCrLf & "    function ChildOnAddClick(){")
            sw.Append(vbCrLf & "    if( grid_" & P.Name.ToLower() & ".parentid=='{00000000-0000-0000-0000-000000000000}') {return;}")
            'sw.Append(vbCrLf & "   	if(CheckOperation('" + P.Name + ".add')!=0){")
            sw.Append(vbCrLf & "   	if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "                var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")

            sw.Append(vbCrLf & "                grid_" & P.Name.ToLower() & ".store.insert(0, new model_" & P.Name.ToLower() & "());")
            sw.Append(vbCrLf & "                record= grid_" & P.Name.ToLower() & ".store.getAt(0);")
            sw.Append(vbCrLf & "                record.set('parentid',grid_" & P.Name.ToLower() & ".parentid);")

            sw.Append(vbCrLf & "                edit.getComponent(0).setActiveRecord(record,grid_" & P.Name.ToLower() & ".instanceid,grid_" & P.Name.ToLower() & ".parentid);")
            sw.Append(vbCrLf & "                edit.show();")
            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Создание строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "    };")
        End If

        sw.Append(vbCrLf & "     function ChildOnRefreshClick(){")
        sw.Append(vbCrLf & "        if( grid_" & P.Name.ToLower() & ".parentid=='{00000000-0000-0000-0000-000000000000}') {return;}")
        sw.Append(vbCrLf & "            grid_" & P.Name.ToLower() & ".store.load({params:{parentid: grid_" & P.Name.ToLower() & ".parentid}});")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & "    function ChildOnEditClick(){")
        sw.Append(vbCrLf & "    if( grid_" & P.Name.ToLower() & ".parentid=='{00000000-0000-0000-0000-000000000000}') {return;}")
        sw.Append(vbCrLf & "        var selection = grid_" & P.Name.ToLower() & ".getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        'sw.Append(vbCrLf & "   	    if(CheckOperation('" + P.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "   	     if(CheckOperation('" + ot.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "            var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")
        sw.Append(vbCrLf & "            edit.getComponent(0).setActiveRecord(selection,grid_" & P.Name.ToLower() & ".instanceid,grid_" & P.Name.ToLower() & ".parentid);")
        sw.Append(vbCrLf & "            edit.show();")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Изменение строк не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & "   grid_" & P.Name.ToLower() & "=")
        sw.Append(vbCrLf & "    new Ext.grid.Panel({")
        sw.Append(vbCrLf & "        itemId:  'grd_" + P.Name.ToLower + "',")
        If bbar Then
            sw.Append(vbCrLf & "        minHeight: 200,")
            sw.Append(vbCrLf & "        maxHeight: 1200,")

        Else
            sw.Append(vbCrLf & "        minWidth: 200,")
            sw.Append(vbCrLf & "        maxWidth: 1700,")

        End If

        sw.Append(vbCrLf & "        iconCls:  'icon-grid',")
        sw.Append(vbCrLf & "        frame: true,")
        sw.Append(vbCrLf & "        parentid: '{00000000-0000-0000-0000-000000000000}',")
        sw.Append(vbCrLf & "        title: '" & P.Caption & "',")
        sw.Append(vbCrLf & "        scroll:'both',")
        sw.Append(vbCrLf & "        stateful:stateFulSystem,")
        sw.Append(vbCrLf & "        stateId:  '" & P.Name.ToLower() & objmode & "',")


        sw.Append(vbCrLf & "        store: {")
        sw.Append(vbCrLf & "        model:'model_" & P.Name.ToLower() & "',")
        sw.Append(vbCrLf & "        autoLoad: false,")
        sw.Append(vbCrLf & "        autoSync: false,")
        sw.Append(vbCrLf & "        proxy: {")
        sw.Append(vbCrLf & "            type:   'ajax',")
        If UseMartService Then
            sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_mart_" & P.Name.ToLower() & "/getRows',")
        Else
            If ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRowsTemp',")
            Else
                sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
            End If

        End If
        sw.Append(vbCrLf & "            reader: {")
        sw.Append(vbCrLf & "                type:   'json'")
        sw.Append(vbCrLf & "                ,root:  'data'")
        sw.Append(vbCrLf & "                ,successProperty:  'success'")
        sw.Append(vbCrLf & "                ,messageProperty:  'msg'")
        sw.Append(vbCrLf & "            },")
        'sw.Append(vbCrLf & "            writer: {")
        'sw.Append(vbCrLf & "                type:   'json',")
        'sw.Append(vbCrLf & "                writeAllFields: true")
        'sw.Append(vbCrLf & "            },")
        sw.Append(vbCrLf & "            listeners: {")
        sw.Append(vbCrLf & "                exception: function(proxy, response, operation){")
        'sw.Append(vbCrLf & "                    Ext.MessageBox.show({")
        'sw.Append(vbCrLf & "                        title: 'REMOTE EXCEPTION',")
        'sw.Append(vbCrLf & "                        msg:    operation.getError(),")
        'sw.Append(vbCrLf & "                        icon : Ext.MessageBox.ERROR,")
        'sw.Append(vbCrLf & "                        buttons : Ext.Msg.OK")
        'sw.Append(vbCrLf & "                    });")
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "            }")



        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "        features: [groupingFeature_" & P.Name.ToLower() & "],")



        sw.Append(vbCrLf & "          dockedItems: [{")
        sw.Append(vbCrLf & "                xtype:  'toolbar',")
        sw.Append(vbCrLf & "                items: [")
        If Not UseMartService Then
            sw.Append(vbCrLf & "                {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_add',")
            sw.Append(vbCrLf & "                    text:   'Создать',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowAdd = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : ChildOnAddClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
            sw.Append(vbCrLf & "                    text:   'Изменить',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'edit',")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowEdit = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : ChildOnEditClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_delete',")
            sw.Append(vbCrLf & "                    text:   'Удалить',")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'delete',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowDelete = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : ChildOnDeleteClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
            sw.Append(vbCrLf & "                    text:   'Обновить',")
            sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    handler : ChildOnRefreshClick")
            sw.Append(vbCrLf & "                }]")
        Else
            sw.Append(vbCrLf & "                {")

            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
            sw.Append(vbCrLf & "                    text:   'Свойства',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'edit',")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowEdit = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : ChildOnEditClick")

            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
            sw.Append(vbCrLf & "                    text:   'Обновить',")
            sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    handler : ChildOnRefreshClick")
            sw.Append(vbCrLf & "                }]")
        End If
        sw.Append(vbCrLf & "            }],")

        sw.Append(vbCrLf & "        columns: [")

        Dim xtype As String = ""
        Dim isfirst As Boolean = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            If LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, objmode) And Not fld.TheStyle.Contains("hidden") Then


                ft = fld.FieldType
                If ft.Name.ToLower <> "password" Then


                    xtype = "{"


                    If Not isfirst Then
                        sw.Append(vbCrLf & "            ,")
                    End If
                    isfirst = False
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                        If ft.Name.ToLower = "file" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'/output_file.php?ID={" & fld.Name.ToLower & "}&ext={" & fld.Name.ToLower & "_ext}\' target=\'_blank\'>Файл</a>'}")
                        ElseIf ft.Name.ToLower = "url" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'{" & fld.Name.ToLower & "}\' target=\'_blank\'>" & fld.Caption & "</a>'}")
                        ElseIf ft.Name.ToLower = "html" Then
                            sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 200, dataIndex: '" & fld.Name.ToLower() & "', sortable: true,")
                            sw.Append(vbCrLf & " renderer: function(value){var S =new String(value);  S=S.replace(new RegExp('/>','g'),'');  S=S.replace(new RegExp('<','g'),''); S=S.replace(new RegExp('>','g'),''); if(S.length >255) S=S.substr(0,255); return S;}}")


                        Else
                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 200, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If
                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                                If ft.Name.ToLower = "date" Then
                                    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',   renderer:myDateOnlyRenderer}")
                                ElseIf ft.Name.ToLower = "time" Then

                                    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',   renderer:myTimeRenderer}")
                                ElseIf ft.Name.ToLower = "datetime" Then

                                    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:110, dataIndex: '" & fld.Name.ToLower() & "', sortable: true, xtype: 'datecolumn',   renderer:myDateRenderer}")
                                ElseIf ft.Name.ToLower = "birthday" Then
                                    sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 90, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")
                                End If

                            End If

                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If
                        End If
                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")


                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:80, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 200, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If
                End If
            End If
        Next
        sw.Append(vbCrLf & "        ],")  ' columns




        sw.Append(vbCrLf & "    listeners: {")
        sw.Append(vbCrLf & "        itemdblclick: function() { ")
        sw.Append(vbCrLf & "    	    ChildOnEditClick();")
        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "          itemclick: function(view , record){")
        sw.Append(vbCrLf & "         grid_" & P.Name.ToLower() & ".down('#delete').setDisabled(false);")
        sw.Append(vbCrLf & "          grid_" & P.Name.ToLower() & ".down('#edit').setDisabled(false);")
        sw.Append(vbCrLf & "    },")
        sw.Append(vbCrLf & "    select: function( selmodel, record,  index,  eOpts ){")
        sw.Append(vbCrLf & "        grid_" & P.Name.ToLower() & ".down('#delete').setDisabled(false);")
        sw.Append(vbCrLf & "        grid_" & P.Name.ToLower() & ".down('#edit').setDisabled(false);")
        sw.Append(vbCrLf & "    }, ")
        sw.Append(vbCrLf & "    selectionchange: function(selModel, selections){")
        sw.Append(vbCrLf & "    	 grid_" & P.Name.ToLower() & ".down('#delete').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "    	 grid_" & P.Name.ToLower() & ".down('#edit').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "    }")
        sw.Append(vbCrLf & "    }") 'listenners


        sw.Append(vbCrLf & "    }")  'Ext.Define_data
        sw.Append(vbCrLf & "    );")  'Ext.Define


        Return sw.ToString()
    End Function

    Private Function PartMake_TreeJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal objmode As String, ByVal UseMartService As Boolean) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Dim i As Integer


        sw.Append(vbCrLf & "var p1;")
        If Not UseMartService Then
            sw.Append(vbCrLf & "    function onDeleteConfirm(selection){")
            sw.Append(vbCrLf & "      if (selection) {")
            sw.Append(vbCrLf & "        Ext.Ajax.request({")
            sw.Append(vbCrLf & "            url:    rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/deleteRow',")
            sw.Append(vbCrLf & "            method:  'POST',")
            sw.Append(vbCrLf & "    		params: { ")
            sw.Append(vbCrLf & "    				" & P.Name.ToLower() & "id: selection.get('" & P.Name.ToLower() & "id')")
            sw.Append(vbCrLf & "    				}")
            sw.Append(vbCrLf & "    	});")
            'sw.Append(vbCrLf & "    	p1.store.remove(selection);")
            sw.Append(vbCrLf & "    	onRefreshClick();")
            sw.Append(vbCrLf & "      }")
            sw.Append(vbCrLf & "    };")

            sw.Append(vbCrLf & "    function onDeleteClick (){")
            sw.Append(vbCrLf & "      var selection = p1.getView().getSelectionModel().getSelection()[0];")
            sw.Append(vbCrLf & "      if (selection) {")
            'sw.Append(vbCrLf & "   	  if(CheckOperation('" + P.Name + ".del')!=0){")
            sw.Append(vbCrLf & "   	if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "        Ext.Msg.show({")
            sw.Append(vbCrLf & "            title:  'Удалить?',")
            sw.Append(vbCrLf & "            msg:    'Удалить строку из базы данных?',")
            sw.Append(vbCrLf & "        	buttons: Ext.Msg.YESNO,")
            sw.Append(vbCrLf & "            icon:   Ext.window.MessageBox.QUESTION,")
            sw.Append(vbCrLf & "        	fn: function(btn,text,opt){")
            sw.Append(vbCrLf & "        		if(btn=='yes'){")
            sw.Append(vbCrLf & "        			onDeleteConfirm(opt.selectedRow);")
            sw.Append(vbCrLf & "        	    }")
            sw.Append(vbCrLf & "        	},")

            sw.Append(vbCrLf & "            caller: this,")
            sw.Append(vbCrLf & "            selectedRow: selection")
            sw.Append(vbCrLf & "        });")

            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Удаление строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "      }")
            sw.Append(vbCrLf & "    };")


            sw.Append(vbCrLf & "     function onAddRootClick(){")
            'sw.Append(vbCrLf & "   	if(CheckOperation('" + P.Name + ".add')!=0){")
            sw.Append(vbCrLf & "   	if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "                var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")
            sw.Append(vbCrLf & "                p1.lasttreeid='{00000000-0000-0000-0000-000000000000}';")
            sw.Append(vbCrLf & "                record=new model_" & P.Name.ToLower() & "();")
            sw.Append(vbCrLf & "                record.set('instanceid',p1.instanceid);")
            sw.Append(vbCrLf & "                record.set('parentrowid',p1.lasttreeid);")
            sw.Append(vbCrLf & "                p1.store.getRootNode().insertChild(0, record);")
            sw.Append(vbCrLf & "                edit.getComponent(0).setActiveRecord(p1,record,p1.instanceid);")
            sw.Append(vbCrLf & "                edit.show();")
            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Создание строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "    };")



            sw.Append(vbCrLf & "    function onAddClick(){")
            'sw.Append(vbCrLf & "   	if(CheckOperation('" + P.Name + ".add')!=0){")
            sw.Append(vbCrLf & "   	if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "               var selection = p1.getView().getSelectionModel().getSelection()[0];")
            sw.Append(vbCrLf & "               if (selection) {")
            sw.Append(vbCrLf & "                    p1.lasttreeid=selection.get('" & P.Name.ToLower() & "id');")
            sw.Append(vbCrLf & "                    record=new model_" & P.Name.ToLower() & "();")
            sw.Append(vbCrLf & "                    record.set('instanceid',p1.instanceid);")
            sw.Append(vbCrLf & "                    record.set('parentrowid',p1.lasttreeid);")
            sw.Append(vbCrLf & "                    p1.store.getNodeById(p1.lasttreeid).insertChild(0, record);")
            sw.Append(vbCrLf & "               }else{")
            sw.Append(vbCrLf & "                    p1.lasttreeid='{00000000-0000-0000-0000-000000000000}';")
            sw.Append(vbCrLf & "                    record=new model_" & P.Name.ToLower() & "();")
            sw.Append(vbCrLf & "                    record.set('instanceid',p1.instanceid);")
            sw.Append(vbCrLf & "                    record.set('parentrowid',p1.lasttreeid);")
            sw.Append(vbCrLf & "                    p1.store.getRootNode().insertChild(0, record);")
            sw.Append(vbCrLf & "               }")

            sw.Append(vbCrLf & "                var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")
            sw.Append(vbCrLf & "                edit.getComponent(0).setActiveRecord(p1,record,p1.instanceid);")
            sw.Append(vbCrLf & "                edit.show();")
            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Создание строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "    };")





        End If

        sw.Append(vbCrLf & "    function onEditClick(){")
        sw.Append(vbCrLf & "        var selection = p1.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        'sw.Append(vbCrLf & "   	    if(CheckOperation('" + P.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "   	    if(CheckOperation('" + ot.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "            var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")
        sw.Append(vbCrLf & "            edit.getComponent(0).setActiveRecord(p1,selection,selection.get('instanceid'));")
        sw.Append(vbCrLf & "            edit.show();")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Изменение строк не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & "    function onRefreshClick(){")
        sw.Append(vbCrLf & "            p1.store.load({params:{instanceid: p1.instanceid}});")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & " p1=   new Ext.tree.Panel({")
        sw.Append(vbCrLf & "        itemId: id,")
        'sw.Append(vbCrLf & "            title:'" & P.Caption & "',")
        'sw.Append(vbCrLf & "            height: '550px',")
        sw.Append(vbCrLf & "            flex: 1,")
        sw.Append(vbCrLf & "        layout:'fit',")
        sw.Append(vbCrLf & "      stateful:stateFulSystem,")
        sw.Append(vbCrLf & "       stateId:  '" & P.Name.ToLower() & objmode & "',")

        sw.Append(vbCrLf & "        iconCls:  'icon-grid',")
        sw.Append(vbCrLf & "        frame: true,")
        sw.Append(vbCrLf & "        instanceid: '{00000000-0000-0000-0000-000000000000}',")


        sw.Append(vbCrLf & "        lasttreeid: '{00000000-0000-0000-0000-000000000000}',")
        sw.Append(vbCrLf & "        rootVisible:false,")
        sw.Append(vbCrLf & "        store: treestore_" & P.Name.ToLower() & ",")



        sw.Append(vbCrLf & "          dockedItems: [{")
        sw.Append(vbCrLf & "                xtype:  'toolbar',")
        sw.Append(vbCrLf & "                items: [")

        If Not UseMartService Then
            sw.Append(vbCrLf & "                {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_add',")
            sw.Append(vbCrLf & "                    text:   'Создать в корне',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowAdd = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onAddRootClick")
            sw.Append(vbCrLf & "                    }, ")

            sw.Append(vbCrLf & "                {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_add',")
            sw.Append(vbCrLf & "                    text:   'Создать',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowAdd = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onAddClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
            sw.Append(vbCrLf & "                    text:   'Изменить',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'edit',")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowEdit = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onEditClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_delete',")
            sw.Append(vbCrLf & "                    text:   'Удалить',")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'delete',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowDelete = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onDeleteClick")
            sw.Append(vbCrLf & "                    }, ")
        Else
            sw.Append(vbCrLf & "                    {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
            sw.Append(vbCrLf & "                    text:   'Свойства',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'edit',")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowEdit = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onEditClick")
            sw.Append(vbCrLf & "                    }, ")
        End If
        sw.Append(vbCrLf & "                              {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
        sw.Append(vbCrLf & "                    text:   'Обновить',")
        sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : onRefreshClick")
        sw.Append(vbCrLf & "                }]")
        sw.Append(vbCrLf & "            }],")

        sw.Append(vbCrLf & "        columns: [")

        Dim xtype As String = ""
        Dim isfirst As Boolean = True
        Dim wi As String

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            If LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, objmode) And Not fld.TheStyle.Contains("hidden") Then
                ft = fld.FieldType
                wi = ""
                If ft.Name.ToLower <> "password" Then
                    xtype = "{"

                    If isfirst Then
                        xtype = "{xtype: 'treecolumn',"
                        wi = "width:400,"
                    End If


                    If Not isfirst Then
                        sw.Append(vbCrLf & "            ,")
                    End If

                    isfirst = False


                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                        If ft.Name.ToLower = "file" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'/output_file.php?ID={" & fld.Name.ToLower & "}&ext={" & fld.Name.ToLower & "_ext}\' target=\'_blank\'>Файл</a>'}")
                        ElseIf ft.Name.ToLower = "url" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'{" & fld.Name.ToLower & "}\' target=\'_blank\'>" & fld.Caption & "</a>'}")
                        ElseIf ft.Name.ToLower = "html" Then
                            sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 200, dataIndex: '" & fld.Name.ToLower() & "', sortable: true,")
                            sw.Append(vbCrLf & " renderer: function(value){var S =new String(value);  S=S.replace(new RegExp('/>','g'),'');  S=S.replace(new RegExp('<','g'),''); S=S.replace(new RegExp('>','g'),''); if(S.length >255) S=S.substr(0,255); return S;}}")


                        Else
                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                                If wi = "" Then
                                    wi = "width: 160,"
                                End If
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """," & wi & " dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If
                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                                If wi = "" Then
                                    wi = "width: 80,"
                                End If
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & " dataIndex: '" & fld.Name.ToLower() & "', sortable: true,renderer:myDateRenderer}")

                            End If

                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                                If wi = "" Then
                                    wi = "width: 80,"
                                End If
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & " dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If
                        End If
                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
                        If wi = "" Then
                            wi = "width: 60,"
                        End If
                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & "dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")


                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        If wi = "" Then
                            wi = "width: 60,"
                        End If
                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & " dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        If wi = "" Then
                            wi = "width: 200,"
                        End If
                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & " dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If
                End If
            End If

        Next
        sw.Append(vbCrLf & "        ],")  ' columns





        sw.Append(vbCrLf & "        onSelectChange: function(selModel, selections){")
        sw.Append(vbCrLf & "        p1.down('#delete').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "        p1.down('#edit').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    listeners: {")
        sw.Append(vbCrLf & "        itemdblclick: function() { ")
        sw.Append(vbCrLf & "    	    onEditClick();")
        sw.Append(vbCrLf & "        }")

        sw.Append(vbCrLf & "        ,itemclick: function() { ")
        sw.Append(vbCrLf & "        p1.down('#delete').setDisabled(false);")
        sw.Append(vbCrLf & "        p1.down('#edit').setDisabled(false);")
        sw.Append(vbCrLf & "        }")

        sw.Append(vbCrLf & "    },")


        sw.Append(vbCrLf & "    }")  'Ext.Define_data
        sw.Append(vbCrLf & "    );")  'Ext.Define


        sw.Append(vbCrLf & "return p1;")
        Return sw.ToString()
    End Function


    Private Function PartMake_TreeGridJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal objmode As String, ByVal UseMartService As Boolean) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Dim i As Integer
        Dim child As MTZMetaModel.MTZMetaModel.PART
        child = P.PART.Item(1)

        sw.Append(PartMake_GridChildJS(ot, child, objmode, UseMartService, False))

        sw.Append(vbCrLf & "var p1;")
        If Not UseMartService Then
            sw.Append(vbCrLf & "    function onDeleteConfirm (selection){")
            sw.Append(vbCrLf & "      if (selection) {")
            sw.Append(vbCrLf & "        Ext.Ajax.request({")
            sw.Append(vbCrLf & "            url:    rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/deleteRow',")
            sw.Append(vbCrLf & "            method:  'POST',")
            sw.Append(vbCrLf & "    		params: { ")
            sw.Append(vbCrLf & "    				" & P.Name.ToLower() & "id: selection.get('" & P.Name.ToLower() & "id')")
            sw.Append(vbCrLf & "    				}")
            sw.Append(vbCrLf & "    	});")
            'sw.Append(vbCrLf & "    	p1.store.remove(selection);")
            sw.Append(vbCrLf & "    	onRefreshClick();")
            sw.Append(vbCrLf & "      }")
            sw.Append(vbCrLf & "    };")

            sw.Append(vbCrLf & "    function onDeleteClick(){")
            sw.Append(vbCrLf & "      var selection = p1.getView().getSelectionModel().getSelection()[0];")
            sw.Append(vbCrLf & "      if (selection) {")
            'sw.Append(vbCrLf & "   	  if(CheckOperation('" + P.Name + ".del')!=0){")
            sw.Append(vbCrLf & "   	    if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "        Ext.Msg.show({")
            sw.Append(vbCrLf & "            title:  'Удалить?',")
            sw.Append(vbCrLf & "            msg:    'Удалить строку из базы данных?',")
            sw.Append(vbCrLf & "        	buttons: Ext.Msg.YESNO,")
            sw.Append(vbCrLf & "            icon:   Ext.window.MessageBox.QUESTION,")
            sw.Append(vbCrLf & "        	fn: function(btn,text,opt){")
            sw.Append(vbCrLf & "        		if(btn=='yes'){")
            sw.Append(vbCrLf & "        			onDeleteConfirm(opt.selectedRow);")
            sw.Append(vbCrLf & "        	    }")
            sw.Append(vbCrLf & "        	},")

            sw.Append(vbCrLf & "            caller: this,")
            sw.Append(vbCrLf & "            selectedRow: selection")
            sw.Append(vbCrLf & "        });")

            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Удаление строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "      }")
            sw.Append(vbCrLf & "    };")


            sw.Append(vbCrLf & "     function onAddRootClick(){")
            'sw.Append(vbCrLf & "   	if(CheckOperation('" + P.Name + ".add')!=0){")
            sw.Append(vbCrLf & "   	if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "                var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")
            sw.Append(vbCrLf & "                p1.lasttreeid='{00000000-0000-0000-0000-000000000000}';")
            sw.Append(vbCrLf & "                record=new model_" & P.Name.ToLower() & "();")
            sw.Append(vbCrLf & "                record.set('instanceid',p1.instanceid);")
            sw.Append(vbCrLf & "                record.set('parentrowid',p1.lasttreeid);")
            sw.Append(vbCrLf & "                p1.store.getRootNode().insertChild(0, record);")
            sw.Append(vbCrLf & "                edit.getComponent(0).setActiveRecord(p1,record,p1.instanceid);")
            sw.Append(vbCrLf & "                edit.show();")
            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Создание строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "    };")



            sw.Append(vbCrLf & "    function onAddClick(){")
            'sw.Append(vbCrLf & "   	if(CheckOperation('" + P.Name + ".add')!=0){")
            sw.Append(vbCrLf & "   	if(CheckOperation('" + ot.Name + ".edit')!=0){")
            sw.Append(vbCrLf & "               var selection = p1.getView().getSelectionModel().getSelection()[0];")
            sw.Append(vbCrLf & "               if (selection) {")
            sw.Append(vbCrLf & "                    p1.lasttreeid=selection.get('" & P.Name.ToLower() & "id');")
            sw.Append(vbCrLf & "                    record=new model_" & P.Name.ToLower() & "();")
            sw.Append(vbCrLf & "                    record.set('instanceid',p1.instanceid);")
            sw.Append(vbCrLf & "                    record.set('parentrowid',p1.lasttreeid);")
            sw.Append(vbCrLf & "                    p1.store.getNodeById(p1.lasttreeid).insertChild(0, record);")
            sw.Append(vbCrLf & "               }else{")
            sw.Append(vbCrLf & "                    p1.lasttreeid='{00000000-0000-0000-0000-000000000000}';")
            sw.Append(vbCrLf & "                    record=new model_" & P.Name.ToLower() & "();")
            sw.Append(vbCrLf & "                    record.set('instanceid',p1.instanceid);")
            sw.Append(vbCrLf & "                    record.set('parentrowid',p1.lasttreeid);")
            sw.Append(vbCrLf & "                    p1.store.getRootNode().insertChild(0, record);")
            sw.Append(vbCrLf & "               }")

            sw.Append(vbCrLf & "                var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")


            sw.Append(vbCrLf & "                record.set('instanceid',p1.instanceid);")

            sw.Append(vbCrLf & "                record.set('parentrowid',p1.lasttreeid);")

            sw.Append(vbCrLf & "                edit.getComponent(0).setActiveRecord(p1,record,p1.instanceid);")
            sw.Append(vbCrLf & "                edit.show();")
            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Контроль прав.',")
            sw.Append(vbCrLf & "                msg:    'Создание строк не разрешено!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")

            sw.Append(vbCrLf & "    };")
        End If

        sw.Append(vbCrLf & "    function onRefreshClick(){")
        sw.Append(vbCrLf & "            p1.store.load({params:{instanceid: p1.instanceid}});")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & "    function onEditClick(){")
        sw.Append(vbCrLf & "        var selection = p1.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        'sw.Append(vbCrLf & "   	    if(CheckOperation('" + P.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "   	if(CheckOperation('" + ot.Name + ".edit')!=0){")
        sw.Append(vbCrLf & "            var edit = Ext.create('EditWindow_" & P.Name.ToLower() & objmode & "');")
        sw.Append(vbCrLf & "            edit.getComponent(0).setActiveRecord(p1,selection,selection.get('instanceid'));")
        sw.Append(vbCrLf & "            edit.show();")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Изменение строк не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    };")

        sw.Append(vbCrLf & "p1=    new Ext.tree.Panel({")
        sw.Append(vbCrLf & "        itemId:id,")
        'sw.Append(vbCrLf & "        height: '550px',")
        'sw.Append(vbCrLf & "        flex: 1,")
        'sw.Append(vbCrLf & "        layout:'fit',")
        sw.Append(vbCrLf & "        autoScroll:true,")
        'sw.Append(vbCrLf & "        hideHeaders: true,")
        sw.Append(vbCrLf & "        width:600,")
        'sw.Append(vbCrLf & "        iconCls:  'icon-grid',")
        sw.Append(vbCrLf & "        frame: true,")
        sw.Append(vbCrLf & "        instanceid: '{00000000-0000-0000-0000-000000000000}',")
        'sw.Append(vbCrLf & "        title: """ & P.Caption & """,")

        sw.Append(vbCrLf & "        lasttreeid: '{00000000-0000-0000-0000-000000000000}',")
        sw.Append(vbCrLf & "        rootVisible:false,")
        If UseMartService Then
            sw.Append(vbCrLf & "        store: treestore_mart_" & P.Name.ToLower() & ",")
        Else
            sw.Append(vbCrLf & "        store: treestore_" & P.Name.ToLower() & ",")
        End If





        sw.Append(vbCrLf & "          dockedItems: [{")
        sw.Append(vbCrLf & "                xtype:  'toolbar',")
        sw.Append(vbCrLf & "                items: [")
        If Not UseMartService Then
            sw.Append(vbCrLf & "                {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_add',")
            sw.Append(vbCrLf & "                    text:   'Создать в корне',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowAdd = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onAddRootClick")


            sw.Append(vbCrLf & "                    }, ")

            sw.Append(vbCrLf & "                {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_add',")
            sw.Append(vbCrLf & "                    text:   'Создать',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowAdd = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onAddClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
            sw.Append(vbCrLf & "                    text:   'Изменить',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowEdit = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'edit',")
            sw.Append(vbCrLf & "                    handler : onEditClick")
            sw.Append(vbCrLf & "                    }, {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_delete',")
            sw.Append(vbCrLf & "                    text:   'Удалить',")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'delete',")
            sw.Append(vbCrLf & "                    scope:  this,")
            If Not LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode) Is Nothing Then
                If LATIR2Framework.ObjectHelper.GetPartRestriction(P, objmode).AllowDelete = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & "                hidden : true,")
                End If
            End If
            sw.Append(vbCrLf & "                    handler : onDeleteClick")
            sw.Append(vbCrLf & "                    }, {")
        Else
            sw.Append(vbCrLf & "                    {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
            sw.Append(vbCrLf & "                    text:   'Свойства',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    disabled: true,")
            sw.Append(vbCrLf & "                    itemId:  'edit',")
            sw.Append(vbCrLf & "                    handler : onEditClick")
            sw.Append(vbCrLf & "                    }, {")
        End If

        sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
        sw.Append(vbCrLf & "                    text:   'Обновить',")
        sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : onRefreshClick")
        sw.Append(vbCrLf & "                }]")
        sw.Append(vbCrLf & "            }],")

        sw.Append(vbCrLf & "        columns: [")

        Dim xtype As String = ""
        Dim isfirst As Boolean = True
        Dim wi As String
        For i = 1 To P.FIELD.Count

            fld = P.FIELD.Item(i)

            If LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, objmode) And Not fld.TheStyle.Contains("hidden") Then
                ft = fld.FieldType
                wi = ""
                If ft.Name.ToLower <> "password" Then

                    xtype = "{"

                    If isfirst Then
                        xtype = "{xtype: 'treecolumn',"
                        wi = "width: 450,"
                    End If


                    If Not isfirst Then
                        sw.Append(vbCrLf & "            ,")
                    End If
                    isfirst = False
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                        If ft.Name.ToLower = "file" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'/output_file.php?ID={" & fld.Name.ToLower & "}&ext={" & fld.Name.ToLower & "_ext}\' target=\'_blank\'>Файл</a>'}")
                        ElseIf ft.Name.ToLower = "url" Then
                            sw.Append(vbCrLf & "{ text     : '" & fld.Caption & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                            sw.Append(vbCrLf & "tpl:'<a href=\'{" & fld.Name.ToLower & "}\' target=\'_blank\'>" & fld.Caption & "</a>'}")
                        ElseIf ft.Name.ToLower = "html" Then
                            sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 200, dataIndex: '" & fld.Name.ToLower() & "', sortable: true,")
                            sw.Append(vbCrLf & " renderer: function(value){var S =new String(value);  S=S.replace(new RegExp('/>','g'),'');  S=S.replace(new RegExp('<','g'),''); S=S.replace(new RegExp('>','g'),''); if(S.length >255) S=S.substr(0,255); return S;}}")


                        Else
                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                                If wi = "" Then
                                    wi = "width: 160,"
                                End If
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """," & wi & " dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If
                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                                If wi = "" Then
                                    wi = "width: 80,"
                                End If
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & " dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If

                            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                                If wi = "" Then
                                    wi = "width: 80,"
                                End If
                                sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & " dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                            End If
                        End If
                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
                        If wi = "" Then
                            wi = "width: 60,"
                        End If
                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & "dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")


                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        If wi = "" Then
                            wi = "width: 60,"
                        End If
                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & " dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        If wi = "" Then
                            wi = "width: 200,"
                        End If
                        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, " & wi & " dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    End If

                    'If ft.Name.ToLower <> "password" Then

                    '    xtype = "{"

                    '    If isfirst Then
                    '        xtype = "{xtype: 'treecolumn',"
                    '    End If


                    '    If Not isfirst Then
                    '        sw.Append(vbCrLf & "            ,")
                    '    End If
                    '    isfirst = False

                    '    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                    '        If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    '            sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width: 120, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                    '        End If
                    '        If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    '            sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:80, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                    '        End If

                    '        If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    '            sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                    '        End If
                    '    End If

                    '    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                    '        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")


                    '    End If

                    '    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                    '        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    '    End If

                    '    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                    '        sw.Append(vbCrLf & xtype & "text: """ & fld.Caption & """, width:100, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

                    '    End If
                End If
            End If

        Next
        sw.Append(vbCrLf & "        ]")  ' columns
        sw.Append(vbCrLf & ",")
        sw.Append(vbCrLf & "	rbar:grid_" + child.Name.ToLower + " ")


        sw.Append(vbCrLf & "       ,")

        'sw.Append(vbCrLf & "        onSelectChange: function(selModel, selections){")
        'sw.Append(vbCrLf & "          p1.down('#delete').setDisabled(selections.length === 0);")
        'sw.Append(vbCrLf & "          p1.down('#edit').setDisabled(selections.length === 0);")
        'sw.Append(vbCrLf & "        },")

        sw.Append(vbCrLf & "        listeners: {")
        sw.Append(vbCrLf & "        resize: function ( tree, width, height, oldWidth, oldHeight, eOpts ){")
        sw.Append(vbCrLf & "        		grid_" + child.Name.ToLower + ".setWidth( width * 0.6 );")
        sw.Append(vbCrLf & "        },")

        sw.Append(vbCrLf & "        itemdblclick: function() { ")
        sw.Append(vbCrLf & "    	    onEditClick();")
        sw.Append(vbCrLf & "        }")

        sw.Append(vbCrLf & "        ,itemclick: function(view,record) { ")
        sw.Append(vbCrLf & "           p1.down('#delete').setDisabled(false);")
        sw.Append(vbCrLf & "           p1.down('#edit').setDisabled(false);")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".instanceid=p1.instanceid;")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".parentid=record.get('id');")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".store.load({params:{ parentid:record.get('id')} })")

        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "        select: function(view,record) { ")
        sw.Append(vbCrLf & "           p1.down('#delete').setDisabled(false);")
        sw.Append(vbCrLf & "           p1.down('#edit').setDisabled(false);")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".instanceid=p1.instanceid;")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".parentid=record.get('id');")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".store.load({params:{ parentid:record.get('id')} })")

        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "        selectionchange: function(selModel, selections){")
        sw.Append(vbCrLf & "        p1.down('#delete').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "        p1.down('#edit').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "        var selection = selections[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".instanceid=p1.instanceid;")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".parentid=selection.get('id');")
        sw.Append(vbCrLf & "           grid_" + child.Name.ToLower + ".store.load({params:{ parentid:selection.get('id')} })")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "       }")


        sw.Append(vbCrLf & "      }") ' listenners

        sw.Append(vbCrLf & "    }")  'Ext.Define_data
        sw.Append(vbCrLf & "    );")  'Ext.Define

        sw.Append(vbCrLf & "return p1;")

        Return sw.ToString()
    End Function


    Private Function PartMake_InterfaceJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal objmode As String, ByVal UseMartService As Boolean, isMain As Boolean) As String

        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""

        Dim itype As LATIR2Framework.ObjectHelper.InterfaceType
        Dim s As String
        If isMain Then
            s = vbCrLf & "function DefineInterface_" & P.Name.ToLower() & "_" & objmode & "(id,mystore,selection){" & vbCrLf
            itype = LATIR2Framework.ObjectHelper.AnalyzeInterfaceForGUI(P, "")
        Else
            s = vbCrLf & "function DefineInterface_" & P.Name.ToLower() & "_" & objmode & "(id,mystore){" & vbCrLf
            itype = LATIR2Framework.ObjectHelper.AnalyzeInterfaceForGUI(P, objmode)
        End If

        Dim t As String
        t = vbCrLf & "function DefineInterface_" & P.Name.ToLower() & "_" & objmode & "(id,treestore_" & P.Name.ToLower() & "){" & vbCrLf


        Select Case itype
            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypePanel

                Dim tabcol As Collection
                Dim tn As String
                tabcol = New Collection
                P.FIELD.Sort = "sequence"

                For i = 1 To P.FIELD.Count
                    If LATIR2Framework.ObjectHelper.IsFieldPresent(P, P.FIELD.Item(i).ID.ToString, objmode) And Not P.FIELD.Item(i).TheStyle.Contains("hidden") Then
                        If P.FIELD.Item(i).TabName <> "" Then
                            tn = P.FIELD.Item(i).TabName
                            Try
                                tabcol.Add(tn, tn)
                            Catch ex As Exception
                                ' non unique
                            End Try
                        End If


                    End If
                Next
                If tabcol.Count = 0 Then
                    Return s & PartMake_PlaneJS(ot, P, objmode, UseMartService, isMain) & vbCrLf & "};"
                Else
                    Dim s1 As String
                    s1 = s & PartMake_PlaneJS(ot, P, objmode, UseMartService, isMain) & vbCrLf & "};"
                    For i = 1 To tabcol.Count
                        s = vbCrLf & "function DefineInterface_" & P.Name.ToLower() & "_" & objmode & "_tab" & i.ToString & "(id,mystore){" & vbCrLf
                        s1 = s1 & vbCrLf & s & PartMake_PlaneJS(ot, P, objmode, UseMartService, isMain, tabcol.Item(i), "_tab" & i.ToString) & vbCrLf & "};"
                    Next
                    Return s1
                End If






            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeGrid
                Return s & PartMake_GridJS(ot, P, objmode, UseMartService) & vbCrLf & "};"

            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeTree
                Return t & PartMake_TreeJS(ot, P, objmode, UseMartService) & vbCrLf & "};"
            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeTreeGrid
                Return t & PartMake_TreeGridJS(ot, P, objmode, UseMartService) & vbCrLf & "};"
            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeGridGrid
                Return s & PartMake_GridGridJS(ot, P, objmode, UseMartService) & vbCrLf & "};"
            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeCommon
                Return s & PartMake_GridJS(ot, P, objmode, UseMartService) & vbCrLf & "};"

        End Select

        Return s & vbCrLf & "};"



    End Function

    Private Function PartMake_GenStores(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer


        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & PartMake_JSModelAndStore(P))
            sw.Append(vbCrLf & PartMake_ComboStore(P))

            sw.Append(PartMake_GenStores(P.PART))

        Next
        Return sw.ToString()

    End Function





    Private Function PartMake_FormPanelJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal mode As String, ByVal UseMartService As Boolean) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim defmode As String = ""
        Dim chkmode As String = mode
        Dim hasmore As Boolean = False


        Dim isroot As Boolean = False
        If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
            isroot = True
        End If

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim i As Integer
        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).DefaultMode = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                defmode = ot.OBJECTMODE.Item(i).Name
            End If

        Next



        If mode = "" Then chkmode = defmode



        ' Dim colsize As String
        Dim maxcol As Integer
        Dim sposY As Integer = 0
        Dim sheight As Integer = 0
        Dim ydelta As Integer = 46
        Dim colW As Integer = 250
        Dim fsdelta As Integer = 40
        Dim nofsdelta As Integer = 30
        Dim ydeltaArea As Integer = 90
        Dim fldW As Integer = 220
        Dim labelWidth As Integer = 120


        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
            colW = 250
            fldW = 220
            maxcol = 3
        Else
            colW = 750
            fldW = 740
            maxcol = 1
        End If

        Dim posX As Integer = 5, posY As Integer = 0

        sw.Append(vbCrLf & "Ext.define('Form_" & P.Name.ToLower() & mode & "', {")
        sw.Append(vbCrLf & "extend:  'Ext.form.Panel',")
        sw.Append(vbCrLf & "alias: 'widget.f_" & P.Name.ToLower() & mode & "',")

        sw.Append(vbCrLf & "initComponent: function(){")
        sw.Append(vbCrLf & "    this.addEvents('create');")
        sw.Append(vbCrLf & "    Ext.apply(this,{")
        sw.Append(vbCrLf & "        activeRecord: null,")
        'sw.Append(vbCrLf & "        autoScroll: true,")

        ' sw.Append(vbCrLf & "        layout: 'accordion',")
        sw.Append(vbCrLf & "        defaultType:  'textfield',")


        Dim col As Collection
        Dim fg As String
        Dim HasUnGroupedField As Boolean = False
        Dim j As Integer
        Dim FirstField As Boolean


        col = New Collection

        P.FIELD.Sort = "sequence"

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, chkmode) And Not fld.TheStyle.Contains("hidden") Then
                If fld.FieldGroupBox <> "" Then
                    fg = fld.FieldGroupBox
                    Try
                        col.Add(fg, fg)
                    Catch ex As Exception
                        ' non unique
                    End Try
                Else
                    HasUnGroupedField = True
                End If
            End If
        Next
        Dim cnt As Integer
        cnt = col.Count
        If HasUnGroupedField Then
            cnt = cnt + 1
        End If

        If (HasUnGroupedField And col.Count > 0) Or (HasUnGroupedField = False And col.Count > 1) Then
            sw.Append(vbCrLf & "        id:'" + P.Name.ToLower() + "',")
        End If

        'sw.Append(vbCrLf & "        y: " + sposY.ToString + ", ")
        sw.Append(vbCrLf & "        x: 0, ")
        sw.Append(vbCrLf & "        fieldDefaults: {")
        sw.Append(vbCrLf & "         labelAlign:  'top' //,")
        ' sw.Append(vbCrLf & "         labelWidth: "+labelWidth.ToString)
        sw.Append(vbCrLf & "        },")

        sw.Append(vbCrLf & "        items: [")
        Dim IsFieldPresent As Boolean
        Dim IsFieldReadonly As Boolean

        cnt = 0
        If HasUnGroupedField Then

            sw.Append(vbCrLf & "        { ")
            sw.Append(vbCrLf & "        xtype:'panel', ")   'fieldset
            sw.Append(vbCrLf & "        closable:false,")
            'sw.Append(vbCrLf & "        collapsible:true,")
            'sw.Append(vbCrLf & "        titleCollapse : true,")
            sw.Append(vbCrLf & "        title:'',")
            sw.Append(vbCrLf & "        preventHeader:true,")


            sw.Append(vbCrLf & "        id:'" + P.Name.ToLower() + "-" + cnt.ToString() + "',")
            cnt += 1
            sw.Append(vbCrLf & "        layout:'absolute', ")
            sw.Append(vbCrLf & "        border:false, ")
            posX = 5
            posY = 0
            FirstField = True
            P.FIELD.Sort = "sequence"
            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)
                ft = fld.FieldType


                If fld.FieldGroupBox = "" Then
                    IsFieldPresent = LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, chkmode) And Not fld.TheStyle.Contains("hidden")
                    If IsFieldPresent Then

                        IsFieldReadonly = LATIR2Framework.ObjectHelper.IsFieldReadOnly(P, fld.ID.ToString, chkmode)

                        If Not FirstField Then
                            sw.Append(vbCrLf & ",")
                        End If

                        If FirstField Then

                            If fld.TheStyle.Contains("col3") Then
                                maxcol = 3
                                colW = 250
                                fldW = 245
                                labelWidth = 110
                            End If
                            If fld.TheStyle.Contains("col2") Then
                                maxcol = 2
                                colW = 375
                                fldW = 370
                                labelWidth = 140
                            End If

                            If fld.TheStyle.Contains("col1") Then
                                maxcol = 1
                                colW = 750
                                fldW = 740
                                labelWidth = 150
                            End If


                            sw.Append(vbCrLf & "        items: [")
                        End If



                        sw.Append(vbCrLf & "{")

                        If fld.TheStyle.Contains("area2") Then

                            sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - 10).ToString + ",")
                            sw.Append(vbCrLf & "        width: " + (maxcol * colW - 10).ToString + ",")
                            If posX <> 5 Then
                                posY += ydelta
                                posX = 5
                            End If
                            sw.Append(vbCrLf & "        xtype: 'textarea', ")
                            sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                            sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                            sw.Append(vbCrLf & "        height: " + (ydeltaArea * 3 - 10).ToString + ", ")

                            sheight = posY + ydeltaArea * 3 + nofsdelta
                            posY += ydeltaArea * 3
                            posX = 5
                        ElseIf fld.TheStyle.Contains("area") Then

                            sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - 10).ToString + ",")
                            sw.Append(vbCrLf & "        width: " + (maxcol * colW - 10).ToString + ",")
                            If posX <> 5 Then
                                posY += ydelta
                                posX = 5
                            End If
                            sw.Append(vbCrLf & "        xtype: 'textarea', ")
                            sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                            sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                            sw.Append(vbCrLf & "        height: " + (ydeltaArea - 10).ToString + ", ")

                            sheight = posY + ydeltaArea + nofsdelta
                            posY += ydeltaArea
                            posX = 5
                        ElseIf fld.TheStyle.Contains("longtext") Then
                            sw.Append(vbCrLf & "        minWidth: " + ((maxcol) * colW - 10).ToString + ",")
                            If posX <> 5 Then
                                posY += ydelta
                                posX = 5
                            End If
                            sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                            sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")


                            sheight = posY + ydelta + nofsdelta

                            posY += ydelta
                            posX = 5

                        ElseIf fld.TheStyle.Contains("flex") Then
                            sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - posX - 10).ToString + ",")
                            sw.Append(vbCrLf & "        width: " + (maxcol * colW - posX - 10).ToString + ",")
                            sw.Append(vbCrLf & "        maxWidth: " + (maxcol * colW - posX - 10).ToString + ",")
                            sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                            sw.Append(vbCrLf & "        y: " + (posY).ToString + ", ")

                            sheight = posY + ydelta + nofsdelta
                            posY += ydelta
                            posX = 5

                        ElseIf ft.Name = "Boolean" Then
                            sw.Append(vbCrLf & "        minWidth: " + fldW.ToString + ",")
                            sw.Append(vbCrLf & "        width: " + fldW.ToString + ",")
                            sw.Append(vbCrLf & "        maxWidth: " + fldW.ToString + ",")
                            sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                            sw.Append(vbCrLf & "        y: " + (posY).ToString + ", ")

                            sheight = posY + ydelta + nofsdelta
                            posX += colW
                            If posX > maxcol * colW Then
                                posY += ydelta
                                posX = 5
                            End If
                        Else

                            sw.Append(vbCrLf & "        minWidth: " + fldW.ToString + ",")
                            sw.Append(vbCrLf & "        width: " + fldW.ToString + ",")
                            sw.Append(vbCrLf & "        maxWidth: " + fldW.ToString + ",")
                            sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                            sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")

                            sheight = posY + ydelta + nofsdelta
                            posX += colW
                            If posX > maxcol * colW Then
                                posY += ydelta
                                posX = 5
                            End If
                        End If

                        sw.Append(vbCrLf & Tool_MakeField(fld, IsFieldReadonly, mode))
                        sw.Append(vbCrLf & "       ,labelWidth: " + labelWidth.ToString)
                        sw.Append(vbCrLf & "}")

                        If ft.Name.ToLower = "file" Then
                            sw.Append(vbCrLf & ",{")
                            sw.Append(vbCrLf & "xtype:  'hidden',")
                            sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                            sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                            sw.Append(vbCrLf & "},{")
                            sw.Append(vbCrLf & "xtype:  'hidden',")
                            sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_ext',")
                            sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_ext',")
                            sw.Append(vbCrLf & "}")
                        End If


                        FirstField = False
                    Else

                        If FirstField Then
                            sw.Append(vbCrLf & "        items: [")
                        End If
                        If Not FirstField Then
                            sw.Append(vbCrLf & ",")
                        End If
                        sw.Append(vbCrLf & "{")
                        sw.Append(vbCrLf & "xtype:  'hidden',")
                        sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                        sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "'")
                        sw.Append(vbCrLf & "}")
                        FirstField = False
                    End If


                End If


            Next
            sw.Append(vbCrLf & "       ], width: " + (maxcol * colW + 20).ToString + ",")
            sw.Append(vbCrLf & "       height: " + sheight.ToString + " ")
            sw.Append(vbCrLf & "        }")
            sposY += sheight + 5
            sheight = 0
        End If

        If HasUnGroupedField And col.Count > 0 Then
            sw.Append(vbCrLf & ",")
        End If




        For j = 1 To col.Count
            fg = col.Item(j)

            If j > 1 Then
                sw.Append(vbCrLf & ",")
            End If

            Dim substPanel As String
            Dim substThisPanel As Boolean

            substThisPanel = False
            substPanel = ""

            '  ищем нет ли подменяющей панели
            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)
                ft = fld.FieldType
                If fld.FieldGroupBox = fg Then
                    IsFieldPresent = LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, mode) And Not fld.TheStyle.Contains("hidden")
                    If IsFieldPresent Then
                        If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy And ft.Name = "Panel" Then
                            substThisPanel = True

                            If fld.theNameClass <> "" Then
                                substPanel = fld.theNameClass + "(this)"
                            Else
                                substPanel = fld.Name
                            End If
                            Exit For
                        End If
                    End If
                End If
            Next


            If Not substThisPanel Then

                posX = 5
                posY = 0

                FirstField = True
                P.FIELD.Sort = "sequence"

                For i = 1 To P.FIELD.Count
                    fld = P.FIELD.Item(i)
                    ft = fld.FieldType

                    If fld.FieldGroupBox = fg Then
                        IsFieldPresent = LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, chkmode) And Not fld.TheStyle.Contains("hidden")

                        If Not FirstField Then
                            sw.Append(vbCrLf & ",")
                        Else


                            If fld.TheStyle.Contains("col3") Then
                                maxcol = 3
                                colW = 250
                                fldW = 245
                                labelWidth = 110
                            End If
                            If fld.TheStyle.Contains("col2") Then
                                maxcol = 2
                                colW = 375
                                fldW = 370
                                labelWidth = 140
                            End If

                            If fld.TheStyle.Contains("col1") Then
                                maxcol = 1
                                colW = 750
                                fldW = 740
                                labelWidth = 150
                            End If
                            sw.Append(vbCrLf & "        { ")
                            sw.Append(vbCrLf & "        xtype:'panel', ")  'fieldset
                            sw.Append(vbCrLf & "        id:'" + P.Name.ToLower() + "-" + cnt.ToString() + "',")
                            cnt += 1
                            sw.Append(vbCrLf & "        title:      '" & fg & "',")
                            sw.Append(vbCrLf & "        defaultType:  'textfield',")

                            sw.Append(vbCrLf & "        closable:false,")
                            sw.Append(vbCrLf & "        collapsible:true,")
                            If fld.TheStyle.Contains("expandgroup") Then
                                sw.Append(vbCrLf & "        collapsed:false,")
                            Else
                                If j > 2 Then
                                    sw.Append(vbCrLf & "        collapsed:true,")
                                End If
                            End If
                            sw.Append(vbCrLf & "        titleCollapse : true,")
                            sw.Append(vbCrLf & "        layout:'absolute', ")
                            'sw.Append(vbCrLf & "        y: " + sposY.ToString + ", ")
                            sw.Append(vbCrLf & "        x: 0, ")
                            sw.Append(vbCrLf & "            items: [")
                        End If





                        If IsFieldPresent Then
                            IsFieldReadonly = LATIR2Framework.ObjectHelper.IsFieldReadOnly(P, fld.ID.ToString, chkmode)

                            sw.Append(vbCrLf & "{")

                            If fld.TheStyle.Contains("area2") Then
                                sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - 10).ToString + ",")
                                sw.Append(vbCrLf & "        maxWidth: " + (maxcol * colW - 10).ToString + ",")
                                sw.Append(vbCrLf & "        width: " + (maxcol * colW - 10).ToString + ",")
                                If posX <> 5 Then
                                    posY += ydelta
                                    posX = 5
                                End If
                                sw.Append(vbCrLf & "        xtype: 'textarea', ")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                                sw.Append(vbCrLf & "        height: " + (ydeltaArea * 3 - 10).ToString + ", ")
                                sheight = posY + ydeltaArea * 3 + fsdelta
                                posY += ydeltaArea * 3
                                posX = 5
                            ElseIf fld.TheStyle.Contains("area") Then

                                sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - 10).ToString + ",")
                                sw.Append(vbCrLf & "        maxWidth: " + (maxcol * colW - 10).ToString + ",")
                                sw.Append(vbCrLf & "        width: " + (maxcol * colW - 10).ToString + ",")
                                If posX <> 5 Then
                                    posY += ydelta
                                    posX = 5
                                End If
                                sw.Append(vbCrLf & "        xtype: 'textarea', ")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                                sw.Append(vbCrLf & "        height: " + (ydeltaArea - 10).ToString + ", ")
                                sheight = posY + ydeltaArea + fsdelta
                                posY += ydeltaArea
                                posX = 5
                            ElseIf fld.TheStyle.Contains("longtext") Then
                                sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - 10).ToString + ",")
                                sw.Append(vbCrLf & "        maxWidth: " + (maxcol * colW - 10).ToString + ",")
                                sw.Append(vbCrLf & "        width: " + (maxcol * colW - 10).ToString + ",")
                                If posX <> 5 Then
                                    posY += ydelta
                                    posX = 5
                                End If
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")

                                sheight = posY + ydelta + fsdelta
                                posY += ydelta
                                posX = 5
                            ElseIf fld.TheStyle.Contains("flex") Then
                                sw.Append(vbCrLf & "        /* flex_field */ ")
                                sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - posX).ToString + ",")
                                sw.Append(vbCrLf & "        width: " + (maxcol * colW - posX).ToString + ",")
                                sw.Append(vbCrLf & "        maxWidth: " + (maxcol * colW - posX).ToString + ",")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + (posY).ToString + ", ")
                                sheight = posY + ydelta + fsdelta
                                posY += ydelta
                                posX = 5
                            ElseIf ft.Name = "Boolean" Then
                                sw.Append(vbCrLf & "        minWidth: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        width: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        maxWidth: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + (posY).ToString + ", ")
                                sheight = posY + ydelta + fsdelta
                                posX += colW
                                If posX > maxcol * colW Then
                                    posY += ydelta
                                    posX = 5
                                End If
                            Else

                                sw.Append(vbCrLf & "        minWidth: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        width: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        maxWidth: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                                sheight = posY + ydelta + fsdelta
                                posX += colW
                                If posX > maxcol * colW Then
                                    posY += ydelta
                                    posX = 5
                                End If
                            End If


                            sw.Append(vbCrLf & Tool_MakeField(fld, IsFieldReadonly, mode))
                            sw.Append(vbCrLf & "       ,labelWidth: " + labelWidth.ToString)
                            sw.Append(vbCrLf & "}")

                            If ft.Name.ToLower = "file" Then
                                sw.Append(vbCrLf & ",{")
                                sw.Append(vbCrLf & "xtype:  'hidden',")
                                sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                                sw.Append(vbCrLf & "},{")
                                sw.Append(vbCrLf & "xtype:  'hidden',")
                                sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_ext',")
                                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_ext',")
                                sw.Append(vbCrLf & "}")
                            End If

                            FirstField = False
                        Else
                            'If FirstField Then
                            '    sw.Append(vbCrLf & "        items: [")
                            'End If
                            If Not FirstField Then
                                sw.Append(vbCrLf & ",")
                            End If
                            sw.Append(vbCrLf & "{")
                            sw.Append(vbCrLf & "          xtype:  'hidden',")
                            sw.Append(vbCrLf & "          name:   '" & fld.Name.ToLower() & "',")
                            sw.Append(vbCrLf & "          fieldLabel:  '" & fld.Caption & "'")

                            sw.Append(vbCrLf & "}")
                            FirstField = False
                        End If
                    End If
                Next
                sw.Append(vbCrLf & "       ], width: " + (maxcol * colW + 10).ToString + ",")
                sw.Append(vbCrLf & "       height: " + sheight.ToString + " ")
                sw.Append(vbCrLf & "        } //group")
                sposY += sheight + 5
                sheight = 0
            Else
                sw.Append(vbCrLf & substPanel)
            End If

        Next

        sw.Append(vbCrLf & "          ],//items = part panel") 'items



        sw.Append(vbCrLf & "        instanceid:'',")
        sw.Append(vbCrLf & "        dockedItems: [{")
        sw.Append(vbCrLf & "            xtype:  'toolbar',")
        sw.Append(vbCrLf & "            dock:   'bottom',")
        sw.Append(vbCrLf & "            ui:     'footer',")
        sw.Append(vbCrLf & "                items: ['->', {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-accept',")
        sw.Append(vbCrLf & "                    itemId:  'save',")
        sw.Append(vbCrLf & "                    text:   'Сохранить',")
        sw.Append(vbCrLf & "                    disabled: true,")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onSave")
        sw.Append(vbCrLf & "                }")
        If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then

            sw.Append(vbCrLf & "               , {")
            sw.Append(vbCrLf & "                    iconCls:  'icon-cancel',")
            sw.Append(vbCrLf & "                    text:   'Закрыть',")
            sw.Append(vbCrLf & "                    scope:  this,")
            sw.Append(vbCrLf & "                    handler : this.onReset")
            sw.Append(vbCrLf & "                }")
        End If

        sw.Append(vbCrLf & "              ]")
        sw.Append(vbCrLf & "            }] // dockedItems") 'dockedItems
        sw.Append(vbCrLf & "        }); //Ext.apply") 'Ext.apply
        sw.Append(vbCrLf & "        this.callParent();")
        sw.Append(vbCrLf & "    }, //initComponent ") 'initComponent
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "    setActiveRecord: function(tree,record,instid){")
            sw.Append(vbCrLf & "    this.tree=tree;")
        ElseIf isroot Then
            sw.Append(vbCrLf & "    setActiveRecord: function(record,instid){")
        Else

            sw.Append(vbCrLf & "    setActiveRecord: function(record,instid,parentid){")
        End If

        sw.Append(vbCrLf & "        this.activeRecord = record;")
        If isroot Then
            sw.Append(vbCrLf & "        this.instanceid = instid;")
        Else
            sw.Append(vbCrLf & "        this.instanceid = instid;")
            sw.Append(vbCrLf & "        this.parentid = parentid;")
        End If

        sw.Append(vbCrLf & "        if (record) {")
        sw.Append(vbCrLf & "            this.down('#save').enable();")
        sw.Append(vbCrLf & "            this.getForm().loadRecord(record);")
        sw.Append(vbCrLf & "        } else {")
        sw.Append(vbCrLf & "            this.down('#save').disable();")
        sw.Append(vbCrLf & "            this.getForm().reset();")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onSave: function(){")
        sw.Append(vbCrLf & "        var active = this.activeRecord,")
        sw.Append(vbCrLf & "            form = this.getForm();")

        sw.Append(vbCrLf & "        if (!active) {")
        sw.Append(vbCrLf & "            return;")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        if (form.isValid()) {")

        '''''''''' save data from fields to model row
        sw.Append(vbCrLf & "            form.updateRecord(active);")
        sw.Append(vbCrLf & "            // combobox patch")
        sw.Append(vbCrLf & "            // var form_values = form.getValues(); var field_name = '';  for(field_name in form_values){active.set(field_name, form_values[field_name]);}")

        If Not UseMartService Then
            ''''''''''''''''''''''''''''' submit changes directly 
            sw.Append(vbCrLf & "        	StatusDB('Сохранение данных');")



            Dim hasFiles As Boolean
            hasFiles = False
            P.FIELD.Sort = "sequence"
            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)
                ft = fld.FieldType
                If ft.Name.ToLower = "file" Then
                    hasFiles = True
                    Exit For
                End If
            Next


            'If hasFiles Then

            'sw.Append(vbCrLf & "            form.submit({")
            'sw.Append(vbCrLf & "                url: rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/setRow',")
            'sw.Append(vbCrLf & "                method:  'POST',")
            'sw.Append(vbCrLf & "                params: { ")
            'If isroot Then
            '    sw.Append(vbCrLf & "                    instanceid: this.instanceid")
            'Else
            '    sw.Append(vbCrLf & "                    instanceid: this.instanceid,")
            '    sw.Append(vbCrLf & "                    parentid: this.parentid")
            'End If

            'sw.Append(vbCrLf & "                    ," & P.Name.ToLower() & "id: active.get('" & P.Name.ToLower() & "id')")
            'If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            '    sw.Append(vbCrLf & "                    ,treeid: active.get('parentrowid')")
            'End If


            'P.FIELD.Sort = "sequence"
            'For i = 1 To P.FIELD.Count
            '    fld = P.FIELD.Item(i)
            '    ft = fld.FieldType
            '    If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
            '        If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
            '            sw.Append(vbCrLf & "                    ," & fld.Name.ToLower() & ": active.get('" & fld.Name.ToLower() & "') ")
            '        End If

            '    End If
            'Next
            'sw.Append(vbCrLf & "                }")
            'sw.Append(vbCrLf & "                , success: function(){")
            'sw.Append(vbCrLf & "        		    StatusReady('Изменения сохранены');")
            'If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
            '    sw.Append(vbCrLf & "                active.store.load();")
            '    sw.Append(vbCrLf & "                form.owner.ownerCt.close();")

            'End If
            'sw.Append(vbCrLf & "                 }")
            'sw.Append(vbCrLf & "                , failure: function(response){")
            'sw.Append(vbCrLf & "        		    StatusReady('Ошибка сохранения данных');")
            'sw.Append(vbCrLf & "                 }")
            'sw.Append(vbCrLf & "            });   // end submit ")

            'Else ' has no files 

            '//////////////////////// old style (no file support )
            sw.Append(vbCrLf & "            Ext.Ajax.request({")
            sw.Append(vbCrLf & "                url: rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/setRow',")
            sw.Append(vbCrLf & "                method:  'POST',")
            sw.Append(vbCrLf & "                params: { ")
            If isroot Then
                sw.Append(vbCrLf & "                    instanceid: this.instanceid")
            Else
                sw.Append(vbCrLf & "                    instanceid: this.instanceid,")
                sw.Append(vbCrLf & "                    parentid: this.parentid")
            End If

            sw.Append(vbCrLf & "                    ," & P.Name.ToLower() & "id: active.get('" & P.Name.ToLower() & "id')")
            If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                sw.Append(vbCrLf & "                    ,treeid: active.get('parentrowid')")
            End If
            P.FIELD.Sort = "sequence"
            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)
                ft = fld.FieldType
                If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                        'sw.Append(vbCrLf & "                    ," & fld.Name.ToLower() & ": active.get('" & fld.Name.ToLower() & "').toLocaleFormat('%Y-%m-%d %H:%M:%S') ")
                        sw.Append(vbCrLf & "                    ," & fld.Name.ToLower() & ":function() { if(active.get('" & fld.Name.ToLower() & "')) return active.get('" & fld.Name.ToLower() & "').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()")
                    Else
                        sw.Append(vbCrLf & "                    ," & fld.Name.ToLower() & ": active.get('" & fld.Name.ToLower() & "') ")
                    End If
                    'sw.Append(vbCrLf & "                    ," & fld.Name.ToLower() & ": active.get('" & fld.Name.ToLower() & "') ")
                End If
            Next
            sw.Append(vbCrLf & "                }")
            sw.Append(vbCrLf & "                , success: function(response){")
            sw.Append(vbCrLf & "                var text = response.responseText;")
            sw.Append(vbCrLf & "                var res =Ext.decode(text);")
            sw.Append(vbCrLf & "	            if(res.success==false){")
            sw.Append(vbCrLf & "	       	        Ext.MessageBox.show({")
            sw.Append(vbCrLf & "	       		        title:  'Ошибка',")
            sw.Append(vbCrLf & "	       		        msg:    res.msg,")
            sw.Append(vbCrLf & "	       		        buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "	       		        icon:   Ext.MessageBox.ERROR")
            sw.Append(vbCrLf & "	       	            });")
            sw.Append(vbCrLf & "        		    StatusErr( 'Ошибка. '+res.msg);")
            sw.Append(vbCrLf & "	            }else{")
            sw.Append(vbCrLf & "                    if(active.get('" & P.Name.ToLower() & "id')==''){")
            If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                sw.Append(vbCrLf & "               			active.set('id',res.data['" & P.Name.ToLower() & "id']);")
            End If
            sw.Append(vbCrLf & "               			active.set('" & P.Name.ToLower() & "id',res.data['" & P.Name.ToLower() & "id']);")
            sw.Append(vbCrLf & "                    }")
            sw.Append(vbCrLf & "        		    StatusReady('Изменения сохранены');")
            If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                sw.Append(vbCrLf & "                form.owner.ownerCt.close();")
            End If
            sw.Append(vbCrLf & "                }")
            sw.Append(vbCrLf & "              }")
            sw.Append(vbCrLf & "            });")
        End If

        'End If


        'If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
        '    sw.Append(vbCrLf & "             this.ownerCt.close();")
        '    'sw.Append(vbCrLf & "             this.ownerCt.destroy();")
        'End If

        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Ошибка',")
        sw.Append(vbCrLf & "                msg:    'Не все обязательные поля заполнены!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "                icon:   Ext.MessageBox.ERROR")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")

        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onReset: function(){")

        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "        if(this.activeRecord.get('" + P.Name.ToLower + "id')==''){")
            sw.Append(vbCrLf & "        	ts =this.tree.store;")
            sw.Append(vbCrLf & "        	ts.getRootNode().removeAll();")
            sw.Append(vbCrLf & "        	ts.load();")
            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "        this.setActiveRecord(null,null,null);")
        Else
            sw.Append(vbCrLf & "        if(this.activeRecord.get('" + P.Name.ToLower + "id')==''){")
            sw.Append(vbCrLf & "                this.activeRecord.store.reload();")
            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "        this.setActiveRecord(null,null);")

        End If

        sw.Append(vbCrLf & "        this.ownerCt.close();")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "}); // 'Ext.Define") 'Ext.Define


        sw.Append(vbCrLf)
        '''''''''''''''''''' define modal edit window 



        sw.Append(vbCrLf & "Ext.define('EditWindow_" & P.Name.ToLower() & mode & "', {")
        sw.Append(vbCrLf & "    extend:  'Ext.window.Window',")
        sw.Append(vbCrLf & "    maxHeight: " + (sposY + 100).ToString + ",")
        sw.Append(vbCrLf & "    maxWidth: 900,")
        sw.Append(vbCrLf & "    autoScroll:true,")

        sw.Append(vbCrLf & "    minWidth: " + (maxcol * colW).ToString() + ",")
        sw.Append(vbCrLf & "    width: " + (maxcol * colW + 50).ToString() + ",")
        If sposY + 70 > 670 Then
            sw.Append(vbCrLf & "    minHeight:670,")
            sw.Append(vbCrLf & "    height:670,")

        Else
            sw.Append(vbCrLf & "    minHeight:" + (sposY + 70).ToString + ",")
            sw.Append(vbCrLf & "    height:" + (sposY + 70).ToString + ",")
        End If
        sw.Append(vbCrLf & "    constrainHeader :true,")
        sw.Append(vbCrLf & "    layout:  'absolute',")
        sw.Append(vbCrLf & "    autoShow: true,")
        sw.Append(vbCrLf & "    modal: true,")
        sw.Append(vbCrLf & "    closable: false,")
        sw.Append(vbCrLf & "    closeAction: 'destroy',")
        sw.Append(vbCrLf & "    iconCls:  'icon-application_form',")
        sw.Append(vbCrLf & "    title:  '" & P.Caption() & "',")
        sw.Append(vbCrLf & "    items:[{")
        sw.Append(vbCrLf & "        xtype:  'f_" & P.Name.ToLower() & mode & "'")
        sw.Append(vbCrLf & "	}]")
        sw.Append(vbCrLf & "	});")



        'If mode = "" Then
        For i = 1 To P.PART.Count
            sw.Append(vbCrLf & PartMake_FormPanelJS(ot, P.PART.Item(i), mode, UseMartService))
        Next
        'End If




        Return sw.ToString()

    End Function


    Private Function PartMake_PlaneJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART, ByVal objmode As String, ByVal UseMartService As Boolean, ByVal isMain As Boolean, Optional ByVal TabName As String = "", Optional ByVal tabpostfix As String = "") As String

        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim mode As String = objmode



        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim i As Integer
        If mode = "" Then
            For i = 1 To ot.OBJECTMODE.Count
                If ot.OBJECTMODE.Item(i).DefaultMode = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    mode = ot.OBJECTMODE.Item(i).Name
                End If
            Next
        End If
        'Dim colsize As String = "33%"
        Dim sposY As Integer = 0
        Dim sheight As Integer = 0   ' суммарный размер панели
        Dim ydelta As Integer = 30   ' размер поля + зазор  по сути шаг между полями
        Dim ydeltaArea As Integer = 90
        Dim fsdelta As Integer = 35  '  зазор на шапку панели  если есть fieldset
        Dim fsdeltaBlank As Integer = 20  '  зазор на шапку панели  если нет fieldset
        Dim wasCR As Boolean = False

        'Dim maxcol As Integer = 3
        'Dim colW As Integer = 250
        'Dim fldW As Integer = 245
        'Dim labelWidth As Integer =110

        Dim maxcol As Integer = 2
        Dim colW As Integer = 370
        Dim fldW As Integer = 365
        Dim labelWidth As Integer = 140





        Dim tabcol As Collection
        Dim col As Collection
        Dim fg As String

        Dim HasUnGroupedField As Boolean = False
        Dim j As Integer
        Dim FirstField As Boolean

        tabcol = New Collection
        col = New Collection

        P.FIELD.Sort = "sequence"

        For i = 1 To P.FIELD.Count
            If LATIR2Framework.ObjectHelper.IsFieldPresent(P, P.FIELD.Item(i).ID.ToString, mode) And Not P.FIELD.Item(i).TheStyle.Contains("hidden") Then
                If P.FIELD.Item(i).TabName & "" = TabName Then
                    If P.FIELD.Item(i).FieldGroupBox <> "" Then
                        fg = P.FIELD.Item(i).FieldGroupBox
                        Try
                            col.Add(fg, fg)
                        Catch ex As Exception
                            ' non unique
                        End Try
                    Else
                        HasUnGroupedField = True
                    End If
                End If
            End If
        Next



        Dim posX As Integer = 5, posY As Integer = 5


        sw.Append(vbCrLf & "var p1 ; ")
        sw.Append(vbCrLf & "var p1_saved=false;")
        sw.Append(vbCrLf & "var p1_valid=false;")

        If Not UseMartService Then


            sw.Append(vbCrLf & "     function onSave(close_after_save,callaftersave){")
            sw.Append(vbCrLf & "        var active = p1.activeRecord,")
            sw.Append(vbCrLf & "        form = p1.getForm();")

            sw.Append(vbCrLf & "        if (!active) {")
            sw.Append(vbCrLf & "            return;")
            sw.Append(vbCrLf & "        }")



            sw.Append(vbCrLf & "        if (form.isValid()) {")

            '''''''''' save data from fields to model row
            sw.Append(vbCrLf & "            form.updateRecord(active);")
            sw.Append(vbCrLf & "            // combobox patch")
            sw.Append(vbCrLf & "            // var form_values = form.getValues(); var field_name = '';  for(field_name in form_values){active.set(field_name, form_values[field_name]);}")

            If TabName = "" Then
                ''''''''''''''''''''''''''''' submit changes directly 
                sw.Append(vbCrLf & "        	StatusDB('Сохранение данных');")
                sw.Append(vbCrLf & "            Ext.Ajax.request({")
                sw.Append(vbCrLf & "                url: rootURL+'" & basepath & "c_" & P.Name.ToLower() & "/setRow',")
                sw.Append(vbCrLf & "                method:  'POST',")
                sw.Append(vbCrLf & "                params: { ")
                sw.Append(vbCrLf & "                    instanceid: p1.instanceid")
                sw.Append(vbCrLf & "                    ," & P.Name.ToLower() & "id: active.get('" & P.Name.ToLower() & "id')")
                If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                    sw.Append(vbCrLf & "                    ,treeid: active.get('parentrowid')")
                End If
                P.FIELD.Sort = "sequence"
                For i = 1 To P.FIELD.Count
                    fld = P.FIELD.Item(i)
                    ft = fld.FieldType
                    If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                        sw.Append(vbCrLf & "                    ," & fld.Name.ToLower() & ": active.get('" & fld.Name.ToLower() & "') ")
                    End If
                Next
                sw.Append(vbCrLf & "                }")
                sw.Append(vbCrLf & "                , success: function(response){")
                sw.Append(vbCrLf & "                var text = response.responseText;")
                sw.Append(vbCrLf & "                var res =Ext.decode(text);")
                sw.Append(vbCrLf & "	            if(res.success==false){")
                sw.Append(vbCrLf & "	       	        Ext.MessageBox.show({")
                sw.Append(vbCrLf & "	       		        title:  'Ошибка',")
                sw.Append(vbCrLf & "	       		        msg:    res.msg,")
                sw.Append(vbCrLf & "	       		        buttons: Ext.MessageBox.OK,")
                sw.Append(vbCrLf & "	       		        icon:   Ext.MessageBox.ERROR")
                sw.Append(vbCrLf & "	       	            });")
                sw.Append(vbCrLf & "        		        StatusErr('Ошибка. '+res.msg);")
                sw.Append(vbCrLf & "                        p1_saved=false;")
                sw.Append(vbCrLf & "	            }else{")
                sw.Append(vbCrLf & "                    if(active.get('" & P.Name.ToLower() & "id')==''){")
                sw.Append(vbCrLf & "               			active.set('" & P.Name.ToLower() & "id',res.data['" & P.Name.ToLower() & "id']);")
                sw.Append(vbCrLf & "                    }")
                sw.Append(vbCrLf & "        		   /* Ext.MessageBox.show({")
                sw.Append(vbCrLf & "                        title:  'Подтверждение',")
                sw.Append(vbCrLf & "                        msg:    'Изменения сохранены',")
                sw.Append(vbCrLf & "                        buttons: Ext.MessageBox.OK,")
                sw.Append(vbCrLf & "                        icon:   Ext.MessageBox.INFO")
                sw.Append(vbCrLf & "        		    }); */")
                sw.Append(vbCrLf & "        		    StatusReady('Изменения сохранены');")
                sw.Append(vbCrLf & "                    p1_saved=true;")

                sw.Append(vbCrLf & "                   if(selection){")
                sw.Append(vbCrLf & "                     Ext.Ajax.request({")
                sw.Append(vbCrLf & "                        url: rootURL+'index.php/c_v_auto" & P.Name.ToLower() & "/getRows?&filter=[{""property"":""" & P.Name.ToLower() & "id"",""value"":""'+ active.get('" & P.Name.ToLower() & "id') + '""}]',")
                sw.Append(vbCrLf & "                        method:     'GET',")
                sw.Append(vbCrLf & "                        success: function(response){")
                sw.Append(vbCrLf & "                            var data = Ext.decode(response.responseText);")
                sw.Append(vbCrLf & "                            selection.set(data.rows[0]);")
                sw.Append(vbCrLf & "                            selection.commit();")
                sw.Append(vbCrLf & "                        }")
                sw.Append(vbCrLf & "                     });")
                sw.Append(vbCrLf & "                   }")

                sw.Append(vbCrLf & "                    if (close_after_save) { if (typeof(callaftersave) == 'function') callaftersave();  p1.up('window').close(); }")
                sw.Append(vbCrLf & "                }")
                sw.Append(vbCrLf & "              }")


                sw.Append(vbCrLf & "            });")
            End If  ' TabName =""
            sw.Append(vbCrLf & "        }else{")
            sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
            sw.Append(vbCrLf & "                title:  'Ошибка',")
            sw.Append(vbCrLf & "                msg:    'Не все обязательные поля заполнены!',")
            sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
            sw.Append(vbCrLf & "                icon:   Ext.MessageBox.ERROR")
            sw.Append(vbCrLf & "        		});")
            sw.Append(vbCrLf & "        }")
            sw.Append(vbCrLf & "    };")

            sw.Append(vbCrLf & "     function onSave1(aftersave){onSave(false,aftersave);}")
            sw.Append(vbCrLf & "     function onSave2(aftersave){onSave(true,aftersave);}")
        End If

        sw.Append(vbCrLf & "    function onReset(){")
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "        p1.setActiveRecord(null,null,null);")
        Else
            sw.Append(vbCrLf & "        p1.setActiveRecord(null,null);")
        End If

        'sw.Append(vbCrLf & "        this.ownerCt.close();")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "p1=new Ext.form.Panel(")

        sw.Append(vbCrLf & "{")
        sw.Append(vbCrLf & "            itemId: id+'" + tabpostfix + "',")
        sw.Append(vbCrLf & "            autoScroll:true,")
        sw.Append(vbCrLf & "            border:0, bodyPadding: 5,")
        'sw.Append(vbCrLf & "            layout: 'accordion',")
        'sw.Append(vbCrLf & "            flex: 1,")
        sw.Append(vbCrLf & "            activeRecord: null,")

        If isMain And TabName = "" Then
            sw.Append(vbCrLf & "            selection: selection,")
        Else
            sw.Append(vbCrLf & "            selection: null,")
        End If


        sw.Append(vbCrLf & "            defaultType:  'textfield',")
        sw.Append(vbCrLf & "            doSave: onSave2,")

        sw.Append(vbCrLf & "            canClose: function(){")
        sw.Append(vbCrLf & "            	if( p1_valid){")
        sw.Append(vbCrLf & "            		if(! p1.getForm().isValid()  ) return true;")
        sw.Append(vbCrLf & "            		return true ;")
        sw.Append(vbCrLf & "            	}else{")
        sw.Append(vbCrLf & "            		if(! p1.getForm().isValid()  ) return false;")
        sw.Append(vbCrLf & "            		if(p1_saved) return  true;")
        sw.Append(vbCrLf & "            		return false;")
        sw.Append(vbCrLf & "            	}")
        sw.Append(vbCrLf & "            },")



        Dim cnt As Integer
        cnt = col.Count
        If HasUnGroupedField Then
            cnt = cnt + 1
        End If

        If (HasUnGroupedField And col.Count > 0) Or (HasUnGroupedField = False And col.Count > 1) Then
            sw.Append(vbCrLf & "        id:'" + P.Name.ToLower() + tabpostfix + "',")
        End If


        sw.Append(vbCrLf & "        fieldDefaults: {")
        sw.Append(vbCrLf & "         labelAlign:  'right',")
        'sw.Append(vbCrLf & "         labelAlign:  'top'//,")
        sw.Append(vbCrLf & "         labelWidth: 110")

        sw.Append(vbCrLf & "        },")

        sw.Append(vbCrLf & "        items: [")
        Dim IsFieldPresent As Boolean
        Dim IsFieldReadonly As Boolean

        cnt = 0
        If HasUnGroupedField Then
            posX = 5
            posY = 5
            wasCR = False
            sw.Append(vbCrLf & "        { ")
            sw.Append(vbCrLf & "        xtype:'fieldset', ") 'fieldset
            sw.Append(vbCrLf & "        anchor:     '100%',")
            'sw.Append(vbCrLf & "        closable:false,")
            'sw.Append(vbCrLf & "        collapsible:true,")
            'sw.Append(vbCrLf & "        titleCollapse : true,")
            sw.Append(vbCrLf & "        id:'" + P.Name.ToLower() + tabpostfix + "-" + cnt.ToString() + "',")
            cnt += 1
            'sw.Append(vbCrLf & "        y: " + sposY.ToString + ", ")
            sw.Append(vbCrLf & "        x: 0, ")
            sw.Append(vbCrLf & "        border:1, ")
            sw.Append(vbCrLf & "        layout:'absolute', ")



            FirstField = True
            Dim fcontainer As Integer
            P.FIELD.Sort = "sequence"
            fcontainer = 0
            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)
                ft = fld.FieldType

                If P.FIELD.Item(i).TabName & "" = TabName Then
                    If fld.FieldGroupBox = "" Then
                        IsFieldPresent = LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, mode) And Not fld.TheStyle.Contains("hidden")
                        If IsFieldPresent Then

                            IsFieldReadonly = LATIR2Framework.ObjectHelper.IsFieldReadOnly(P, fld.ID.ToString, mode)

                            If Not FirstField Then
                                sw.Append(vbCrLf & ",")
                            End If

                            If FirstField Then

                                If fld.TheStyle.Contains("col3") Then
                                    maxcol = 3
                                    colW = 247
                                    fldW = 243
                                    labelWidth = 110
                                End If
                                If fld.TheStyle.Contains("col2") Then
                                    maxcol = 2
                                    colW = 370
                                    fldW = 365
                                    labelWidth = 140
                                End If

                                If fld.TheStyle.Contains("col1") Then
                                    maxcol = 1
                                    colW = 740
                                    fldW = 740
                                    labelWidth = 150
                                End If


                                sw.Append(vbCrLf & "        items: [")
                            End If

                            sw.Append(vbCrLf & "{")


                            If fld.TheStyle.Contains("area2") Then

                                sw.Append(vbCrLf & "        minWidth: " + ((maxcol) * colW - 20).ToString + ",")
                                If posX <> 5 Then
                                    posY += ydelta
                                    posX = 5
                                End If

                                sw.Append(vbCrLf & "        xtype: 'textarea', ")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                                sw.Append(vbCrLf & "        height: " + (ydeltaArea * 3 - 20).ToString + ", ")
                                sheight = posY + ydeltaArea * 3 - 10 + fsdeltaBlank

                                posY += ydeltaArea * 3 - 10
                                posX = 5

                            ElseIf fld.TheStyle.Contains("area") Or ft.Name.ToLower = "memo" Then

                                sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - 20).ToString + ",")
                                If posX <> 5 Then
                                    posY += ydelta
                                    posX = 5
                                End If
                                sw.Append(vbCrLf & "        xtype: 'textarea', ")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                                sw.Append(vbCrLf & "        height: " + (ydeltaArea - 10).ToString + ", ")
                                sheight = posY + ydeltaArea + fsdeltaBlank
                                posY += ydeltaArea
                                posX = 5
                            ElseIf fld.TheStyle.Contains("longtext") Then
                                sw.Append(vbCrLf & "        minWidth: " + ((maxcol) * colW - 20).ToString + ",")
                                If posX <> 5 Then
                                    posY += ydelta
                                    posX = 5
                                End If
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")

                                sheight = posY + ydelta + fsdeltaBlank

                                posY += ydelta
                                posX = 5
                            ElseIf fld.TheStyle.Contains("flex") Then
                                sw.Append(vbCrLf & "        /* flex_field */ ")
                                sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - posX).ToString + ",")
                                sw.Append(vbCrLf & "        width: " + (maxcol * colW - posX).ToString + ",")
                                sw.Append(vbCrLf & "        maxWidth: " + (maxcol * colW - posX).ToString + ",")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + (posY).ToString + ", ")
                                sheight = posY + ydelta + fsdeltaBlank
                                posY += ydelta
                                posX = 5

                            ElseIf ft.Name = "Boolean" Then
                                sw.Append(vbCrLf & "        minWidth: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        width: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        maxWidth: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + (posY).ToString + ", ")
                                sheight = posY + ydelta + fsdeltaBlank
                                posX += colW
                                If posX > maxcol * colW Then
                                    posY += ydelta
                                    posX = 5
                                End If
                            Else

                                sw.Append(vbCrLf & "        minWidth: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        width: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        maxWidth: " + fldW.ToString + ",")
                                sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                                sheight = posY + ydelta + fsdeltaBlank
                                posX += colW
                                If posX > maxcol * colW Then
                                    posY += ydelta
                                    posX = 5
                                End If
                            End If

                            If fld.TheStyle.Contains("phone") Then
                                sw.Append(vbCrLf & "plugins: [new Ext.ux.InputTextMask('9(999)999-99-99')], ")
                            End If

                            If fld.TheStyle.Contains("lock") Then
                                sw.Append(vbCrLf & "        beforeLabelTextTpl:'<img src=""/resources/icons/lock.png"" style=""height:16px;width:16px;border:0;""/>&nbsp;&nbsp;',")
                            End If
                            sw.Append(vbCrLf & "labelWidth:" + labelWidth.ToString() + ",")
                            sw.Append(vbCrLf & Tool_MakeField(fld, IsFieldReadonly, mode))

                            sw.Append(vbCrLf & "}")
                            FirstField = False
                        Else
                            If FirstField Then
                                sw.Append(vbCrLf & "        items: [")
                            End If
                            If Not FirstField Then
                                sw.Append(vbCrLf & ",")
                            End If
                            sw.Append(vbCrLf & "{")
                            sw.Append(vbCrLf & "xtype:  'hidden',")
                            sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                            sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "'")
                            sw.Append(vbCrLf & "}")
                            FirstField = False
                        End If

                        If fld.TheStyle.Contains("space") Then

                            posY += ydelta * 1.5
                            posX = 5

                        End If
                        If fld.TheStyle.Contains("newline") Then

                            posY += ydelta
                            posX = 5

                        End If

                    End If
                End If
            Next


            sw.Append(vbCrLf & "       ],") ' width: " + (maxcol * colW + 15).ToString + ",")
            sw.Append(vbCrLf & "       height: " + sheight.ToString + " ")
            sw.Append(vbCrLf & "        }")
            sposY += sheight + 5
            sheight = 0
        End If

        If HasUnGroupedField And col.Count > 0 Then
            sw.Append(vbCrLf & ",")

        End If

        For j = 1 To col.Count
            fg = col.Item(j)

            If j > 1 Then
                sw.Append(vbCrLf & ",")
            End If
            Dim substPanel As String
            Dim substThisPanel As Boolean


            substThisPanel = False
            substPanel = ""

            '  ищем нет ли подменяющей панели
            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)
                ft = fld.FieldType
                If P.FIELD.Item(i).TabName & "" = TabName Then
                    If fld.FieldGroupBox = fg Then
                        IsFieldPresent = LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, mode) And Not fld.TheStyle.Contains("hidden")
                        If IsFieldPresent Then
                            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy And ft.Name = "Panel" Then
                                substThisPanel = True
                                If fld.theNameClass <> "" Then
                                    substPanel = fld.theNameClass + "(p1)"
                                Else
                                    substPanel = fld.Name
                                End If
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next


            If Not substThisPanel Then

                FirstField = True
                P.FIELD.Sort = "sequence"

                For i = 1 To P.FIELD.Count
                    fld = P.FIELD.Item(i)
                    ft = fld.FieldType
                    If P.FIELD.Item(i).TabName & "" = TabName Then
                        If fld.FieldGroupBox = fg Then
                            IsFieldPresent = LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, mode) And Not fld.TheStyle.Contains("hidden")

                            If FirstField Then
                                If fld.TheStyle.Contains("col3") Then
                                    maxcol = 3
                                    colW = 250
                                    fldW = 245
                                    labelWidth = 110
                                End If
                                If fld.TheStyle.Contains("col2") Then
                                    maxcol = 2
                                    colW = 375
                                    fldW = 370
                                    labelWidth = 140
                                End If

                                If fld.TheStyle.Contains("col1") Then
                                    maxcol = 1
                                    colW = 750
                                    fldW = 750
                                    labelWidth = 150
                                End If


                                posX = 5
                                posY = 5
                                sw.Append(vbCrLf & "        { ")

                                sw.Append(vbCrLf & "        xtype:'fieldset', ") 'fieldset
                                sw.Append(vbCrLf & "        anchor: '100%',")




                                'sw.Append(vbCrLf & "        closable:false,")
                                'sw.Append(vbCrLf & "        collapsible:false,")
                                'sw.Append(vbCrLf & "        unstyled: true,")
                                'sw.Append(vbCrLf & "        border:false,")


                                'If fld.TheStyle.Contains("expandgroup") Then
                                '    sw.Append(vbCrLf & "        collapsed:false,")
                                'Else
                                '    If j > 2 Then
                                '        sw.Append(vbCrLf & "        collapsed:true,")
                                '    End If
                                'End If

                                'sw.Append(vbCrLf & "        titleCollapse : true,")
                                'sw.Append(vbCrLf & "        y: " + sposY.ToString + ", ")
                                sw.Append(vbCrLf & "        x: 0, ")
                                sw.Append(vbCrLf & "        layout:'absolute', ")
                                sw.Append(vbCrLf & "        id:'" + P.Name.ToLower() + tabpostfix + "_" + cnt.ToString() + "',")
                                cnt += 1
                                If fld.TheStyle.Contains("fslck") Then
                                    sw.Append(vbCrLf & "       title:'<img src=""/resources/icons/lock.png"" style=""height:16px;width:16px;border:0;""/>&nbsp;&nbsp;" + fg + "',")
                                Else
                                    sw.Append(vbCrLf & "        title:      '" & fg & "',")
                                End If


                                sw.Append(vbCrLf & "        defaultType:  'textfield',")

                                sw.Append(vbCrLf & "            items: [")
                            End If


                            If IsFieldPresent Then

                                IsFieldReadonly = LATIR2Framework.ObjectHelper.IsFieldReadOnly(P, fld.ID.ToString, mode)
                                If Not FirstField Then
                                    sw.Append(vbCrLf & ",")
                                End If
                                sw.Append(vbCrLf & "{")
                                If fld.TheStyle.Contains("area2") Then

                                    sw.Append(vbCrLf & "        minWidth: " + ((maxcol) * colW - 20).ToString + ",")
                                    If posX <> 5 Then
                                        posY += ydelta
                                        posX = 5
                                    End If

                                    sw.Append(vbCrLf & "        xtype: 'textarea', ")
                                    sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                    sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                                    sw.Append(vbCrLf & "        height: " + (ydeltaArea * 2 - 10).ToString + ", ")
                                    sheight = posY + ydeltaArea * 2 + fsdelta

                                    posY += ydeltaArea * 2
                                    posX = 5

                                ElseIf fld.TheStyle.Contains("area") Or ft.Name.ToLower() = "memo" Then

                                    sw.Append(vbCrLf & "        minWidth: " + ((maxcol) * colW - 20).ToString + ",")
                                    If posX <> 5 Then
                                        posY += ydelta
                                        posX = 5
                                    End If

                                    sw.Append(vbCrLf & "        xtype: 'textarea', ")
                                    sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                    sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                                    sw.Append(vbCrLf & "        height: " + (ydeltaArea - 10).ToString + ", ")
                                    sheight = posY + ydeltaArea + fsdelta

                                    posY += ydeltaArea
                                    posX = 5
                                ElseIf fld.TheStyle.Contains("longtext") Then
                                    sw.Append(vbCrLf & "        minWidth: " + ((maxcol) * colW - 20).ToString + ",")
                                    If posX <> 5 Then
                                        posY += ydelta
                                        posX = 5
                                    End If
                                    sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                    sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")

                                    sheight = posY + ydelta + fsdelta

                                    posY += ydelta
                                    posX = 5
                                ElseIf fld.TheStyle.Contains("flex") Then
                                    sw.Append(vbCrLf & "        /* flex_field */ ")
                                    sw.Append(vbCrLf & "        minWidth: " + (maxcol * colW - posX).ToString + ",")
                                    sw.Append(vbCrLf & "        width: " + (maxcol * colW - posX).ToString + ",")
                                    sw.Append(vbCrLf & "        maxWidth: " + (maxcol * colW - posX).ToString + ",")
                                    sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                    sw.Append(vbCrLf & "        y: " + (posY).ToString + ", ")
                                    sheight = posY + ydelta + fsdelta
                                    posY += ydelta
                                    posX = 5

                                ElseIf ft.Name = "Boolean" Then
                                    sw.Append(vbCrLf & "        minWidth: " + fldW.ToString + ",")
                                    sw.Append(vbCrLf & "        width: " + fldW.ToString + ",")
                                    sw.Append(vbCrLf & "        maxWidth: " + fldW.ToString + ",")
                                    sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                    sw.Append(vbCrLf & "        y: " + (posY).ToString + ", ")
                                    sheight = posY + ydelta + fsdelta
                                    posX += colW
                                    If posX > maxcol * colW Then
                                        posY += ydelta
                                        posX = 5
                                    End If
                                Else
                                    sw.Append(vbCrLf & "        minWidth: " + fldW.ToString + ",")
                                    sw.Append(vbCrLf & "        width: " + fldW.ToString + ",")
                                    sw.Append(vbCrLf & "        maxWidth: " + fldW.ToString + ",")

                                    sw.Append(vbCrLf & "        x: " + posX.ToString + ", ")
                                    sw.Append(vbCrLf & "        y: " + posY.ToString + ", ")
                                    sheight = posY + ydelta + fsdelta
                                    posX += colW
                                    If posX > maxcol * colW Then
                                        posY += ydelta
                                        posX = 5
                                    End If
                                End If
                                If fld.TheStyle.Contains("phone") Then
                                    sw.Append(vbCrLf & "plugins: [new Ext.ux.InputTextMask('9(999)999-99-99')], ")
                                End If

                                If fld.TheStyle.Contains("lock") Then
                                    sw.Append(vbCrLf & "        beforeLabelTextTpl:'<img src=""/resources/icons/lock.png"" style=""height:16px;width:16px;border:0;""/>&nbsp;&nbsp;',")
                                End If

                                sw.Append(vbCrLf & "labelWidth:" + labelWidth.ToString() + ",")
                                sw.Append(vbCrLf & Tool_MakeField(fld, IsFieldReadonly, mode))
                                sw.Append(vbCrLf & "}")


                            Else
                                If FirstField Then
                                    sw.Append(vbCrLf & "        items: [")
                                End If
                                If Not FirstField Then
                                    sw.Append(vbCrLf & ",")
                                End If
                                sw.Append(vbCrLf & "{")
                                sw.Append(vbCrLf & "xtype:  'hidden',")
                                sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                                sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "'")
                                sw.Append(vbCrLf & "}")

                            End If
                            FirstField = False

                            If fld.TheStyle.Contains("space") Then
                                posY += ydelta * 1.5
                                posX = 5
                            End If
                            If fld.TheStyle.Contains("newline") Then

                                posY += ydelta
                                posX = 5
                            End If

                        End If
                    End If

                Next
                sw.Append(vbCrLf & "       ], ") 'width: " + (maxcol * colW + 15).ToString + ",")
                sw.Append(vbCrLf & "       height: " + (sheight).ToString + " ")
                sw.Append(vbCrLf & "        } // group")
                sposY += sheight + 5
                sheight = 0
            Else
                sw.Append(vbCrLf & substPanel)
            End If

        Next

        sw.Append(vbCrLf & "          ],//items = part panel") 'items



        sw.Append(vbCrLf & "        instanceid:''")

        'If Not UseMartService And ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
        '    sw.Append(vbCrLf & "        ,dockedItems: [{")
        '    sw.Append(vbCrLf & "            xtype:  'toolbar',")
        '    sw.Append(vbCrLf & "            dock:   'bottom',")
        '    sw.Append(vbCrLf & "            ui:     'footer',")
        '    sw.Append(vbCrLf & "                items: ['->', {")
        '    sw.Append(vbCrLf & "                    iconCls:  'icon-accept',")
        '    sw.Append(vbCrLf & "                    itemId:  'save',")
        '    sw.Append(vbCrLf & "                    text:   'Сохранить',")
        '    sw.Append(vbCrLf & "                    disabled:true,")
        '    sw.Append(vbCrLf & "                    scope:  this,")
        '    sw.Append(vbCrLf & "                    handler : onSave1")
        '    sw.Append(vbCrLf & "                }")
        '    If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then

        '        sw.Append(vbCrLf & "               , {")
        '        sw.Append(vbCrLf & "                    iconCls:  'icon-cancel',")
        '        sw.Append(vbCrLf & "                    text:   'Закрыть',")
        '        sw.Append(vbCrLf & "                    scope:  this,")
        '        sw.Append(vbCrLf & "                    handler : onReset")
        '        sw.Append(vbCrLf & "                }")
        '    Else
        '        sw.Append(vbCrLf & "               , {")
        '        sw.Append(vbCrLf & "                    iconCls:  'icon-application_put',")
        '        sw.Append(vbCrLf & "                    text:   'Сохранить и Закрыть',")
        '        sw.Append(vbCrLf & "                    scope:  this,")
        '        sw.Append(vbCrLf & "                    handler : onSave2")
        '        sw.Append(vbCrLf & "                }")
        '    End If

        '    sw.Append(vbCrLf & "              ]")
        '    sw.Append(vbCrLf & "            }] // dockedItems") 'dockedItems
        'End If

        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            sw.Append(vbCrLf & "    ,setActiveRecord: function(tree,record,instid){")
            sw.Append(vbCrLf & "    p1.tree=tree;")
        Else
            sw.Append(vbCrLf & "    ,setActiveRecord: function(record,instid){")
        End If

        sw.Append(vbCrLf & "        p1.activeRecord = record;")
        sw.Append(vbCrLf & "        p1.instanceid = instid;")
        sw.Append(vbCrLf & "        if (record) {")
        'If Not UseMartService And ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
        '    sw.Append(vbCrLf & "            p1.down('#save').enable();")
        'End If
        sw.Append(vbCrLf & "            p1.getForm().loadRecord(record);")
        sw.Append(vbCrLf & "            p1_valid =p1.getForm().isValid();")
        sw.Append(vbCrLf & "        } else {")
        'If Not UseMartService And ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
        '    sw.Append(vbCrLf & "            p1.down('#save').disable();")
        'End If
        sw.Append(vbCrLf & "            p1.getForm().reset();")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    }")



        sw.Append(vbCrLf & "}); // 'Ext.Define") 'Ext.Define


        sw.Append(vbCrLf)
        sw.Append(vbCrLf & "return p1;")
        Return sw.ToString()

    End Function

    Private Function Tool_MakeField(ByVal fld As MTZMetaModel.MTZMetaModel.FIELD, ByVal FldReadOnly As Boolean, ByVal mode As String) As String

        Dim sw As StringBuilder
        sw = New StringBuilder
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = fld.FieldType

        Dim iSMandatory As Boolean
        iSMandatory = LATIR2Framework.ObjectHelper.IsFieldMandatory(fld.Parent.Parent, fld.ID, mode)

        Dim hasInterval As Boolean = False

        If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS Then
            If ft.Name.ToLower() = "customcontrol" Then
                If FldReadOnly Then
                    sw.Append(vbCrLf & "enabled: false,")

                End If
                sw.Append(vbCrLf & "xtype:  '" & fld.theNameClass & "',")
                sw.Append(vbCrLf & "name:  '" & fld.Name.ToLower() & "',")
                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                If Trim(fld.Caption) = "" Then
                    sw.Append(vbCrLf & "hideLabel: true,")
                Else
                    sw.Append(vbCrLf & "text:  '" & fld.Caption & "',")
                End If


                'sw.Append(vbCrLf & "labelWidth:  110,")   ' Semeon's controls dosen't read default labelWidth, set it directly !
            ElseIf ft.Name.ToLower() = "button" Then
                If FldReadOnly Then
                    sw.Append(vbCrLf & "enabled: false,")

                End If
                sw.Append(vbCrLf & "xtype:  'button',")
                sw.Append(vbCrLf & " handler:function(){")
                sw.Append(vbCrLf & fld.theNameClass + "(this);")
                sw.Append(vbCrLf & "},")
                sw.Append(vbCrLf & "name:  '" & fld.Name.ToLower() & "',")
                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                If Trim(fld.Caption) = "" Then
                    sw.Append(vbCrLf & "hideLabel: true,")
                Else
                    sw.Append(vbCrLf & "text:  '" & fld.Caption & "',")
                End If
            ElseIf ft.Name.ToLower() = "masterstring" Then
                If FldReadOnly Then
                    sw.Append(vbCrLf & "hideTrigger: true,")

                End If
                sw.Append(vbCrLf & "xtype:  'trigger',")
                sw.Append(vbCrLf & "editable: false,")
                sw.Append(vbCrLf & " onTriggerClick: function() {")
                sw.Append(vbCrLf & " " + fld.theNameClass + "(this);")
                sw.Append(vbCrLf & "},")
                sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")

                If Trim(fld.Caption) = "" Then
                    sw.Append(vbCrLf & "hideLabel: true,")
                Else
                    sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                End If
            ElseIf ft.Name.ToLower() = "file" Then




                sw.Append(vbCrLf & "xtype:  'filefield',")
                If FldReadOnly Then
                    If fld.TheStyle.Contains("readonly") Then
                        sw.Append(vbCrLf & "       cls:'x-item-readonly',")
                    End If
                    sw.Append(vbCrLf & "hideTrigger: true,")
                    sw.Append(vbCrLf & "editable: false,")
                End If
                sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_fu',")
                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_fu',")
                sw.Append(vbCrLf & "buttonText:'Выбрать',")
                sw.Append(vbCrLf & "buttonConfig: {")
                sw.Append(vbCrLf & "    iconCls:'icon-iu_upload'")
                sw.Append(vbCrLf & "		},")
                If Trim(fld.Caption) = "" Then
                    sw.Append(vbCrLf & "hideLabel: true,")
                Else
                    sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                End If

            ElseIf ft.Name.ToLower() = "html" Then
                sw.Append(vbCrLf & "xtype:  'htmleditor',")
                If FldReadOnly Then
                    If fld.TheStyle.Contains("readonly") Then
                        sw.Append(vbCrLf & "       cls:'x-item-readonly',")
                        sw.Append(vbCrLf & "       disabled:true,")
                    End If
                End If
                sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                If Trim(fld.Caption) = "" Then
                    sw.Append(vbCrLf & "hideLabel: true,")
                Else
                    sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                End If

            ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                'If ft.Name = "Boolean" Then

                '    sw.Append(vbCrLf & "xtype:          'checkboxfield',")

                '    If FldReadOnly Then
                '        If fld.TheStyle.Contains("readonly") Then
                '            sw.Append(vbCrLf & "       cls:'x-item-readonly',")
                '        End If
                '        sw.Append(vbCrLf & "readOnly: true,")
                '        sw.Append(vbCrLf & "editable: false,")
                '        sw.Append(vbCrLf & "disabled: true,")
                '    End If
                '    sw.Append(vbCrLf & "listeners:{")
                '    sw.Append(vbCrLf & "    change:function( cb, newValue, oldValue, eOpts ){")
                '    sw.Append(vbCrLf & "		if(newValue){")
                '    sw.Append(vbCrLf & "		    cb.up('form' ).activeRecord.set('" & fld.Name.ToLower() & "',-1 );")
                '    sw.Append(vbCrLf & "		}else{")
                '    sw.Append(vbCrLf & "		    cb.up('form' ).activeRecord.set('" & fld.Name.ToLower() & "',0 );")
                '    sw.Append(vbCrLf & "		}")
                '    sw.Append(vbCrLf & "    }")
                '    sw.Append(vbCrLf & "},")
                '    sw.Append(vbCrLf & "uncheckedValue: 'нет',")
                '    sw.Append(vbCrLf & "inputValue:    'да',")


                '    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_grid',")
                '    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_grid',")
                '    If Trim(fld.Caption) = "" Then
                '        sw.Append(vbCrLf & "hideLabel: true,")
                '    Else
                '        sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                '    End If
                '    sw.Append(vbCrLf & "labelSeparator:'',")
                '    'sw.Append(vbCrLf & "boxLabelAlign:  'before',")

                'Else
                sw.Append(vbCrLf & "xtype:          'combobox',")
                sw.Append(vbCrLf & "editable: false,")
                If FldReadOnly Then
                    If fld.TheStyle.Contains("readonly") Then
                        sw.Append(vbCrLf & "       cls:'x-item-readonly',")
                    End If
                    sw.Append(vbCrLf & "readOnly: true,")
                    sw.Append(vbCrLf & "hideTrigger: true,")
                Else
                    If Not iSMandatory Then 'fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                        sw.Append(vbCrLf & "trigger1Cls:        'x-form-clear-trigger', ")
                        sw.Append(vbCrLf & "trigger2Cls:        'x-form-select-trigger', ")
                        sw.Append(vbCrLf & "hideTrigger1:false, ")
                        sw.Append(vbCrLf & "hideTrigger2:false, ")
                        sw.Append(vbCrLf & "onTrigger1Click : function(){")
                        sw.Append(vbCrLf & "		this.collapse();")
                        sw.Append(vbCrLf & "		this.clearValue();")
                        sw.Append(vbCrLf & "},")
                        sw.Append(vbCrLf & "onTrigger2Click : function(){ ")
                        sw.Append(vbCrLf & "		if(this.isExpanded) {")
                        sw.Append(vbCrLf & "			this.collapse(); ")
                        sw.Append(vbCrLf & "		}else{ ")
                        'sw.Append(vbCrLf & "			if(this.store.count(false)==0) this.store.load();")
                        sw.Append(vbCrLf & "			this.expand();")
                        sw.Append(vbCrLf & "		}")
                        sw.Append(vbCrLf & "},")
                    End If

                End If
                sw.Append(vbCrLf & "store: enum_" & ft.Name & ",")
                sw.Append(vbCrLf & "valueField:     'name',")
                sw.Append(vbCrLf & "displayField:   'name',")
                sw.Append(vbCrLf & "typeAhead: true,")
                sw.Append(vbCrLf & "queryMode:      'local',")
                sw.Append(vbCrLf & "emptyText:      '',")
                sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_grid',")
                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_grid',")
                sw.Append(vbCrLf & "listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('" & fld.Name.ToLower() & "', records[0].get('value'));}  },")
                If Trim(fld.Caption) = "" Then
                    sw.Append(vbCrLf & "hideLabel: true,")
                Else
                    sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                End If
                'End If

            Else
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then

                    If ft.Name.ToLower() = "password" Then
                        sw.Append(vbCrLf & "xtype:  'textfield',")
                        sw.Append(vbCrLf & "inputType:  'password',")
                        sw.Append(vbCrLf & "value:  '',")
                        sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                        sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                        If Trim(fld.Caption) = "" Then
                            sw.Append(vbCrLf & "hideLabel: true,")
                        Else
                            sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                        End If

                    ElseIf ft.Name.ToLower() = "memo" Then
                        sw.Append(vbCrLf & "xtype:  'textarea',")  'textareafield
                        sw.Append(vbCrLf & "value:  '',")
                        sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                        sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                        If Trim(fld.Caption) = "" Then
                            sw.Append(vbCrLf & "hideLabel: true,")
                        Else
                            sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                        End If

                    Else
                        If Not fld.TheStyle.Contains("area") Then
                            sw.Append(vbCrLf & "xtype:  'textfield',")
                        End If
                        sw.Append(vbCrLf & "value:  '',")
                        sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                        sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                        If Trim(fld.Caption) = "" Then
                            sw.Append(vbCrLf & "hideLabel: true,")
                        Else
                            sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                        End If

                    End If

                    If FldReadOnly Then
                        sw.Append(vbCrLf & "editable: false,")
                        sw.Append(vbCrLf & "readOnly: true,")
                        If fld.TheStyle.Contains("readonly") Then

                            sw.Append(vbCrLf & "cls:'x-item-readonly',")
                        End If
                    End If
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                    sw.Append(vbCrLf & "xtype:  'datefield',")

                    If ft.Name.ToLower = "date" Then
                        sw.Append(vbCrLf & "format:'d/m/Y',")
                        sw.Append(vbCrLf & "submitFormat:'Y-m-d H:i:s',")
                    ElseIf ft.Name.ToLower = "time" Then
                        sw.Append(vbCrLf & "format:'H:i:s',")
                        sw.Append(vbCrLf & "submitFormat:'Y-m-d H:i:s',")
                    ElseIf ft.Name.ToLower = "datetime" Then
                        sw.Append(vbCrLf & "format:'d/m/Y H:i:s',")
                        sw.Append(vbCrLf & "submitFormat:'Y-m-d H:i:s',")
                    ElseIf ft.Name.ToLower = "birthday" Then
                        sw.Append(vbCrLf & "format:'F, d',")
                        sw.Append(vbCrLf & "submitFormat:'F, d',")
                    End If


                    If FldReadOnly Then
                        sw.Append(vbCrLf & "hideTrigger: true,")
                        sw.Append(vbCrLf & "editable: false,")
                        sw.Append(vbCrLf & "readOnly: true,")
                        If fld.TheStyle.Contains("readonly") Then
                            sw.Append(vbCrLf & "cls:'x-item-readonly',")
                        End If
                    End If
                    sw.Append(vbCrLf & "value:  '',")
                    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                    If Trim(fld.Caption) = "" Then
                        sw.Append(vbCrLf & "hideLabel: true,")
                    Else
                        sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                    End If
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    sw.Append(vbCrLf & "xtype:  'numberfield',")
                    If FldReadOnly Then
                        sw.Append(vbCrLf & "editable: false,")
                        sw.Append(vbCrLf & "spinDownEnabled: false,")
                        sw.Append(vbCrLf & "spinUpEnabled: false,")
                        sw.Append(vbCrLf & "readOnly: true,")
                        If fld.TheStyle.Contains("readonly") Then
                            sw.Append(vbCrLf & "cls:'x-item-readonly',")
                        End If
                    End If

                    If fld.TheComment.Contains("minValue") Or fld.TheComment.Contains("maxValue") Then
                        sw.Append(vbCrLf & fld.TheComment)
                        hasInterval = True
                    End If

                    sw.Append(vbCrLf & "value:  '0',")
                    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                    If Trim(fld.Caption) = "" Then
                        sw.Append(vbCrLf & "hideLabel: true,")
                    Else
                        sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                    End If
                End If
            End If

        ElseIf fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
            Dim refP As MTZMetaModel.MTZMetaModel.PART
            refP = fld.RefToPart
            If Not refP Is Nothing Then

                If ft.Name.ToLower() = "multiref" Then
                    'sw.Append(vbCrLf & "xtype:  'PVE.form.ComboGrid',")
                    sw.Append(vbCrLf & "xtype:  'combobox',")
                    If FldReadOnly Then
                        sw.Append(vbCrLf & "hideTrigger: true,")
                        sw.Append(vbCrLf & "readOnly: true,")
                        sw.Append(vbCrLf & "editable: false,")
                        If fld.TheStyle.Contains("readonly") Then
                            sw.Append(vbCrLf & "       cls:'x-item-readonly',")
                        End If
                        sw.Append(vbCrLf & "multiSelect : true,")
                        sw.Append(vbCrLf & "delimiter:',', ")
                        'sw.Append(vbCrLf & "         listConfig: {")
                        'sw.Append(vbCrLf & "            columns: [")
                        'sw.Append(vbCrLf & "                {")
                        'sw.Append(vbCrLf & "                    header:'" & refP.Caption & "',")
                        'sw.Append(vbCrLf & "                    dataIndex:'brief',")
                        'sw.Append(vbCrLf & "		            width: 200")
                        'sw.Append(vbCrLf & "		        }")
                        'sw.Append(vbCrLf & "	        ]")
                        'sw.Append(vbCrLf & "	    },")
                    Else
                        'sw.Append(vbCrLf & "xtype:  'PVE.form.ComboGrid',")
                        sw.Append(vbCrLf & "multiSelect : true,")
                        sw.Append(vbCrLf & "delimiter:',', ")
                        'sw.Append(vbCrLf & "         listConfig: {")
                        'sw.Append(vbCrLf & "            columns: [")
                        'sw.Append(vbCrLf & "                {")
                        'sw.Append(vbCrLf & "                    header:'" & refP.Caption & "',")
                        'sw.Append(vbCrLf & "                    dataIndex:'brief',")
                        'sw.Append(vbCrLf & "		            width: 200")
                        'sw.Append(vbCrLf & "		        }")
                        'sw.Append(vbCrLf & "	        ]")
                        'sw.Append(vbCrLf & "	    },")

                        If Not iSMandatory Then 'fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            sw.Append(vbCrLf & "trigger1Cls:        'x-form-clear-trigger', ")
                            sw.Append(vbCrLf & "trigger2Cls:        'x-form-select-trigger', ")
                            sw.Append(vbCrLf & "hideTrigger1:false, ")
                            sw.Append(vbCrLf & "hideTrigger2:false, ")
                            sw.Append(vbCrLf & "onTrigger1Click : function(){")
                            sw.Append(vbCrLf & "		this.collapse();")
                            sw.Append(vbCrLf & "		this.clearValue();")
                            sw.Append(vbCrLf & "		this.up('form' ).activeRecord.set('" & fld.Name.ToLower() & "',null );")
                            sw.Append(vbCrLf & "},")
                            sw.Append(vbCrLf & "onTrigger2Click : function(){ ")
                            sw.Append(vbCrLf & "		if(this.isExpanded) {")
                            sw.Append(vbCrLf & "			this.collapse(); ")
                            sw.Append(vbCrLf & "		}else{ ")
                            sw.Append(vbCrLf & "			if(this.store.count(false)==0) this.store.load();")
                            sw.Append(vbCrLf & "			var cv = new String(this.getValue()); ")
                            sw.Append(vbCrLf & "			var arrayOfStrings = cv.split(',');")
                            sw.Append(vbCrLf & "			this.setValue(arrayOfStrings);")
                            sw.Append(vbCrLf & "			this.expand();")
                            sw.Append(vbCrLf & "		}")
                            sw.Append(vbCrLf & "},")
                        End If
                        If fld.TheStyle.Contains("textfind") Then
                            sw.Append(vbCrLf & "editable: true,")
                            sw.Append(vbCrLf & "enableRegEx: true,")
                            sw.Append(vbCrLf & "queryMode:'local',")
                        Else
                            sw.Append(vbCrLf & "editable: false,")
                        End If


                        sw.Append(vbCrLf & "listeners:{  ")
                        sw.Append(vbCrLf & "select: function ( combo, records, eOpts ) {  ")
                        sw.Append(vbCrLf & "        var ids=''; ")
                        sw.Append(vbCrLf & "        for(i=0;i<records.length;i++)  ")
                        sw.Append(vbCrLf & "        {")
                        sw.Append(vbCrLf & "	        if(ids!=''){")
                        sw.Append(vbCrLf & "		        ids=ids+';';")
                        sw.Append(vbCrLf & "	        }")
                        sw.Append(vbCrLf & "	        ids=ids+records[i].get('id');")
                        sw.Append(vbCrLf & "        }")
                        sw.Append(vbCrLf & "        combo.up('form' ).activeRecord.set('" & fld.Name.ToLower() & "', ids   );}  ")
                        sw.Append(vbCrLf & ",focus: function()   {  if(this.store.count(false)==0) this.store.load();  } ")
                        sw.Append(vbCrLf & "},")
                    End If


                    sw.Append(vbCrLf & "store: cmbstore_" + refP.Name.ToLower() + ",")
                    sw.Append(vbCrLf & "valueField:     'brief',")
                    sw.Append(vbCrLf & "displayField:   'brief',")
                    sw.Append(vbCrLf & "typeAhead: true,")
                    'sw.Append(vbCrLf & "queryMode:      'local',")
                    sw.Append(vbCrLf & "emptyText:      '',")
                    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_grid',")
                    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_grid',")
                    sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                    ' sw.Append(vbCrLf & "listeners:{  change: function( obj, newValue, oldValue, eOpts ) { if(newValue){p1.activeRecord.set('" & fld.Name.ToLower() & "', newValue);}}},")


                Else ' no multiref
                    sw.Append(vbCrLf & "xtype:  'combobox',")
                    If FldReadOnly Then
                        sw.Append(vbCrLf & "hideTrigger: true,")
                        sw.Append(vbCrLf & "editable: false,")
                        sw.Append(vbCrLf & "readOnly: true,")
                        If fld.TheStyle.Contains("readonly") Then
                            sw.Append(vbCrLf & "       cls:'x-item-readonly',")
                        End If

                    Else

                        If Not iSMandatory Then 'fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            sw.Append(vbCrLf & "trigger1Cls:        'x-form-clear-trigger', ")
                            sw.Append(vbCrLf & "trigger2Cls:        'x-form-select-trigger', ")
                            sw.Append(vbCrLf & "hideTrigger1:false, ")
                            sw.Append(vbCrLf & "hideTrigger2:false, ")
                            sw.Append(vbCrLf & "onTrigger1Click : function(){")
                            sw.Append(vbCrLf & "		this.collapse();")
                            sw.Append(vbCrLf & "		this.clearValue();")
                            sw.Append(vbCrLf & "		this.up('form' ).activeRecord.set('" & fld.Name.ToLower() & "',null );")
                            sw.Append(vbCrLf & "},")
                            sw.Append(vbCrLf & "onTrigger2Click : function(){ ")
                            sw.Append(vbCrLf & "		if(this.isExpanded) {")
                            sw.Append(vbCrLf & "			this.collapse(); ")
                            sw.Append(vbCrLf & "		}else{ ")
                            sw.Append(vbCrLf & "			if(this.store.count(false)==0) this.store.load();")
                            sw.Append(vbCrLf & "			this.expand();")
                            sw.Append(vbCrLf & "		}")
                            sw.Append(vbCrLf & "},")
                            If fld.TheStyle.Contains("addbtn") Then
                                sw.Append(vbCrLf & "trigger3Cls:        'x-form-add-trigger', ")
                                sw.Append(vbCrLf & "hideTrigger3:false, ")
                                sw.Append(vbCrLf & "onTrigger3Click : function(){ ")
                                sw.Append(vbCrLf & fld.theNameClass & "(this); ")
                                sw.Append(vbCrLf & "},")
                            End If
                        Else
                            sw.Append(vbCrLf & "trigger1Cls:        'x-form-select-trigger', ")
                            sw.Append(vbCrLf & "hideTrigger1:false, ")
                            sw.Append(vbCrLf & "onTrigger1Click : function(){ ")
                            sw.Append(vbCrLf & "		if(this.isExpanded) {")
                            sw.Append(vbCrLf & "			this.collapse(); ")
                            sw.Append(vbCrLf & "		}else{ ")
                            sw.Append(vbCrLf & "			if(this.store.count(false)==0) this.store.load();")
                            sw.Append(vbCrLf & "			this.expand();")
                            sw.Append(vbCrLf & "		}")
                            sw.Append(vbCrLf & "},")
                            If fld.TheStyle.Contains("addbtn") Then
                                sw.Append(vbCrLf & "trigger2Cls:        'x-form-add-trigger', ")
                                sw.Append(vbCrLf & "hideTrigger2:false, ")
                                sw.Append(vbCrLf & "onTrigger2Click : function(){ ")
                                sw.Append(vbCrLf & fld.theNameClass & "(this); ")
                                sw.Append(vbCrLf & "},")
                            End If
                        End If

                        If fld.TheStyle.Contains("textfind") Then
                            sw.Append(vbCrLf & "editable: true,")
                            sw.Append(vbCrLf & "enableRegEx: true,")
                            sw.Append(vbCrLf & "queryMode:'local',")
                            sw.Append(vbCrLf & "listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('" & fld.Name.ToLower() & "', records[0].get('id'));} ,focus: function()   {  this.store.load();  } },")
                        Else
                            sw.Append(vbCrLf & "editable: false,")
                            sw.Append(vbCrLf & "listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('" & fld.Name.ToLower() & "', records[0].get('id'));}  },")
                        End If

                    End If




                    sw.Append(vbCrLf & "store: cmbstore_" + refP.Name.ToLower() + ",")
                    sw.Append(vbCrLf & "valueField:     'brief',")
                    sw.Append(vbCrLf & "displayField:   'brief',")
                    sw.Append(vbCrLf & "typeAhead: true,")
                    'sw.Append(vbCrLf & "queryMode:      'local',")
                    sw.Append(vbCrLf & "emptyText:      '',")
                    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_grid',")
                    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_grid',")
                    sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                    'sw.Append(vbCrLf & "listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('" & fld.Name.ToLower() & "', records[0].get('id'));}  },")


                End If
            End If

        Else

            If FldReadOnly Then
                sw.Append(vbCrLf & "hideTrigger: true,")
                sw.Append(vbCrLf & "readOnly: true,")
                If fld.TheStyle.Contains("readonly") Then
                    sw.Append(vbCrLf & "       cls:'x-item-readonly',")
                End If
            End If
            sw.Append(vbCrLf & "xtype:  'trigger',")
            sw.Append(vbCrLf & "editable: false,")
            sw.Append(vbCrLf & " onTriggerClick: function() {")
            sw.Append(vbCrLf & " alert('ref : object');")
            sw.Append(vbCrLf & "},")
            sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_grid',")
            sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_grid',")
            sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
        End If

        If iSMandatory Then 'fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
            If Not FldReadOnly Then
                sw.Append(vbCrLf & "labelClsExtra:'x-item-mandatory',")
            End If
            sw.Append(vbCrLf & "allowBlank:false")
        Else
            If hasInterval Then
                sw.Append(vbCrLf & "allowBlank:false")
            Else
                sw.Append(vbCrLf & "allowBlank:true")
            End If

        End If

        Return sw.ToString()
    End Function



    Private Function Tool_MakeFilterField(ByVal fld As MTZFltr.MTZFltr.FileterField) As String

        Dim sw As StringBuilder
        sw = New StringBuilder
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = fld.FieldType
        Dim hasInterval As Boolean = False

        If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                'If ft.Name = "Boolean" Then
                '    sw.Append(vbCrLf & "xtype:          'checkboxfield',")
                '    sw.Append(vbCrLf & "uncheckedValue: 0,")
                '    sw.Append(vbCrLf & "inputValue:    -1,")
                '    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                '    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                '    sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                '    'sw.Append(vbCrLf & "emptyText:      '" & fld.Caption & "',")
                '    'sw.Append(vbCrLf & "hideLabel:  true,")
                '    sw.Append(vbCrLf & "labelSeparator:'',")
                'Else
                sw.Append(vbCrLf & "xtype:          'combobox',")
                sw.Append(vbCrLf & "editable: false,")
                sw.Append(vbCrLf & "trigger1Cls:        'x-form-clear-trigger', ")
                sw.Append(vbCrLf & "trigger2Cls:        'x-form-select-trigger', ")
                sw.Append(vbCrLf & "hideTrigger1:false, ")
                sw.Append(vbCrLf & "hideTrigger2:false, ")
                sw.Append(vbCrLf & "onTrigger1Click : function(){")
                sw.Append(vbCrLf & "		this.collapse();")
                sw.Append(vbCrLf & "		this.clearValue();")
                sw.Append(vbCrLf & "},")
                sw.Append(vbCrLf & "onTrigger2Click : function(){ ")
                sw.Append(vbCrLf & "		if(this.isExpanded) {")
                sw.Append(vbCrLf & "			this.collapse(); ")
                sw.Append(vbCrLf & "		}else{ ")
                'sw.Append(vbCrLf & "			if(this.store.count(false)==0) this.store.load();")
                sw.Append(vbCrLf & "			this.expand();")
                sw.Append(vbCrLf & "		}")
                sw.Append(vbCrLf & "},")


                sw.Append(vbCrLf & "store: enum_" & ft.Name & ",")
                sw.Append(vbCrLf & "valueField:     'value',")
                sw.Append(vbCrLf & "displayField:   'name',")
                sw.Append(vbCrLf & "typeAhead: true,")
                sw.Append(vbCrLf & "queryMode:      'local',")
                sw.Append(vbCrLf & "emptyText:      '',")
                sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_val',")
                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_val',")
                sw.Append(vbCrLf & "fieldLabel:  '',")
                sw.Append(vbCrLf & "emptyText:      '" & fld.Caption & "',")
                sw.Append(vbCrLf & "hideLabel:  true,")
                sw.Append(vbCrLf & "listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: '" & fld.Caption & "'});}}")
                'End If

            ElseIf ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then

                If ft.Name.ToLower() = "memo" Then
                    sw.Append(vbCrLf & "xtype:  'textfield',")  'textareafield
                    sw.Append(vbCrLf & "value:  '',")
                    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                    sw.Append(vbCrLf & "fieldLabel:  '',")
                    sw.Append(vbCrLf & "emptyText:      '" & fld.Caption & "',")
                    sw.Append(vbCrLf & "hideLabel:  true,")
                    sw.Append(vbCrLf & "listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: '" & fld.Caption & "'});}}")

                Else

                    sw.Append(vbCrLf & "value:  '',")
                    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                    sw.Append(vbCrLf & "fieldLabel:  '',")
                    sw.Append(vbCrLf & "emptyText:      '" & fld.Caption & "',")
                    sw.Append(vbCrLf & "hideLabel:  true,")
                    sw.Append(vbCrLf & "listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: '" & fld.Caption & "'});}}")

                End If

            ElseIf ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                If ft.Name.ToLower = "date" Then
                    sw.Append(vbCrLf & "xtype:  'datefield',")
                    sw.Append(vbCrLf & "format:'d/m/Y',")
                    sw.Append(vbCrLf & "submitFormat:'Y-m-d H:i:s',")
                ElseIf ft.Name.ToLower = "time" Then
                    sw.Append(vbCrLf & "xtype:  'datefield',")
                    sw.Append(vbCrLf & "format:'H:i:s',")
                    sw.Append(vbCrLf & "submitFormat:'Y-m-d H:i:s',")
                ElseIf ft.Name.ToLower = "datetime" Then
                    sw.Append(vbCrLf & "xtype:  'datefield',")
                    sw.Append(vbCrLf & "format:'d/m/Y H:i:s',")
                    sw.Append(vbCrLf & "submitFormat:'Y-m-d H:i:s',")
                ElseIf ft.Name.ToLower = "birthday" Then
                    sw.Append(vbCrLf & "xtype:  'datefield',")
                    sw.Append(vbCrLf & "format:'F',")
                    sw.Append(vbCrLf & "submitFormat:'F',")
                End If
                sw.Append(vbCrLf & "value:  '',")
                sw.Append(vbCrLf & "name:  '" & fld.Name.ToLower() & "',")
                sw.Append(vbCrLf & "itemId: '" & fld.Name.ToLower() & "',")
                sw.Append(vbCrLf & "fieldLabel: '" & fld.Caption & "',")
                sw.Append(vbCrLf & "emptyText:'не задано',")
                sw.Append(vbCrLf & "submitEmptyText: false,")
                'sw.Append(vbCrLf & "hideLabel:  true,")
                sw.Append(vbCrLf & "listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: '" & fld.Caption & "'});}}")
            ElseIf ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                sw.Append(vbCrLf & "xtype:  'numberfield',")


                'If fld.TheComment.Contains("minValue") Or fld.TheComment.Contains("maxValue") Then
                '    sw.Append(vbCrLf & fld.TheComment)
                '    hasInterval = True
                'End If

                sw.Append(vbCrLf & "value:  '0',")
                sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "',")
                sw.Append(vbCrLf & "emptyText:      'не задано',")
                sw.Append(vbCrLf & "submitEmptyText: false,")
                'sw.Append(vbCrLf & "hideLabel:  true,")
                sw.Append(vbCrLf & "listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: '" & fld.Caption & "'});}}")
            End If

        Else

            Dim refP As MTZMetaModel.MTZMetaModel.PART
            refP = fld.RefToPart
            If Not refP Is Nothing Then

                If ft.Name.ToLower() = "multiref" Then
                    sw.Append(vbCrLf & "trigger1Cls:        'x-form-clear-trigger', ")
                    sw.Append(vbCrLf & "trigger2Cls:        'x-form-select-trigger', ")
                    sw.Append(vbCrLf & "hideTrigger1:false, ")
                    sw.Append(vbCrLf & "hideTrigger2:false, ")
                    sw.Append(vbCrLf & "onTrigger1Click : function(){")
                    sw.Append(vbCrLf & "		this.collapse();")
                    sw.Append(vbCrLf & "		this.clearValue();")
                    sw.Append(vbCrLf & "},")
                    sw.Append(vbCrLf & "onTrigger2Click : function(){ ")
                    sw.Append(vbCrLf & "		if(this.isExpanded) {")
                    sw.Append(vbCrLf & "			this.collapse(); ")
                    sw.Append(vbCrLf & "		}else{ ")
                    sw.Append(vbCrLf & "			if(this.store.count(false)==0) this.store.load();")
                    sw.Append(vbCrLf & "			this.expand();")
                    sw.Append(vbCrLf & "		}")
                    sw.Append(vbCrLf & "},")

                    sw.Append(vbCrLf & "editable: true,")
                    sw.Append(vbCrLf & "enableRegEx: true,")
                    sw.Append(vbCrLf & "queryMode:'local',")
                    sw.Append(vbCrLf & "listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: '" & fld.Caption & "'});} },")

                    sw.Append(vbCrLf & "xtype:  'combobox',")
                    sw.Append(vbCrLf & "store: cmbstore_" + refP.Name.ToLower() + ",")
                    sw.Append(vbCrLf & "valueField:     'brief',")
                    sw.Append(vbCrLf & "displayField:   'brief',")
                    sw.Append(vbCrLf & "typeAhead: true,")
                    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
                    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "',")
                    sw.Append(vbCrLf & "fieldLabel:  '',")
                    sw.Append(vbCrLf & "emptyText:      '" & fld.Caption & "',")
                    sw.Append(vbCrLf & "hideLabel:  true")

                    'sw.Append(vbCrLf & "trigger1Cls:        'x-form-clear-trigger', ")
                    'sw.Append(vbCrLf & "trigger2Cls:        'x-form-select-trigger', ")
                    'sw.Append(vbCrLf & "hideTrigger1:false, ")
                    'sw.Append(vbCrLf & "hideTrigger2:false, ")
                    'sw.Append(vbCrLf & "onTrigger1Click : function(){")
                    'sw.Append(vbCrLf & "		this.collapse();")
                    'sw.Append(vbCrLf & "		this.clearValue();")
                    'sw.Append(vbCrLf & "},")
                    'sw.Append(vbCrLf & "onTrigger2Click : function(){ ")
                    'sw.Append(vbCrLf & "		if(this.isExpanded) {")
                    'sw.Append(vbCrLf & "			this.collapse(); ")
                    'sw.Append(vbCrLf & "		}else{ ")
                    'sw.Append(vbCrLf & "			if(this.store.count(false)==0) this.store.load();")
                    'sw.Append(vbCrLf & "			this.expand();")
                    'sw.Append(vbCrLf & "		}")
                    'sw.Append(vbCrLf & "},")
                    'sw.Append(vbCrLf & "editable: true,")
                    'sw.Append(vbCrLf & "enableRegEx: true,")
                    'sw.Append(vbCrLf & "queryMode:'local',")
                    'sw.Append(vbCrLf & "listeners:{   focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: '" & fld.Caption & "'});}},")
                    'sw.Append(vbCrLf & "xtype:  'PVE.form.ComboGrid',")
                    'sw.Append(vbCrLf & "store: cmbstore_" + refP.Name.ToLower() + ",")
                    'sw.Append(vbCrLf & "valueField:     'id',")
                    'sw.Append(vbCrLf & "displayField:   'brief',")
                    'sw.Append(vbCrLf & "typeAhead: true,")
                    'sw.Append(vbCrLf & "queryMode:      'local',")
                    'sw.Append(vbCrLf & "multiSelect : true,")
                    'sw.Append(vbCrLf & "delimiter:          ' ', ")
                    'sw.Append(vbCrLf & "         listConfig: {")
                    'sw.Append(vbCrLf & "            columns: [")
                    'sw.Append(vbCrLf & "                {")
                    'sw.Append(vbCrLf & "                    header:'" & refP.Caption & "',")
                    'sw.Append(vbCrLf & "                    dataIndex:'brief',")
                    'sw.Append(vbCrLf & "		            width: 200")
                    'sw.Append(vbCrLf & "		        }")
                    'sw.Append(vbCrLf & "	        ]")
                    'sw.Append(vbCrLf & "	    },")

                    'sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_id',")
                    'sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_id',")
                    'sw.Append(vbCrLf & "fieldLabel:  '',")
                    'sw.Append(vbCrLf & "emptyText:      '" & fld.Caption & "',")
                    'sw.Append(vbCrLf & "hideLabel:  true")


                Else

                    sw.Append(vbCrLf & "trigger1Cls:        'x-form-clear-trigger', ")
                    sw.Append(vbCrLf & "trigger2Cls:        'x-form-select-trigger', ")
                    sw.Append(vbCrLf & "hideTrigger1:false, ")
                    sw.Append(vbCrLf & "hideTrigger2:false, ")
                    sw.Append(vbCrLf & "onTrigger1Click : function(){")
                    sw.Append(vbCrLf & "		this.collapse();")
                    sw.Append(vbCrLf & "		this.clearValue();")
                    sw.Append(vbCrLf & "},")
                    sw.Append(vbCrLf & "onTrigger2Click : function(){ ")
                    sw.Append(vbCrLf & "		if(this.isExpanded) {")
                    sw.Append(vbCrLf & "			this.collapse(); ")
                    sw.Append(vbCrLf & "		}else{ ")
                    sw.Append(vbCrLf & "			if(this.store.count(false)==0) this.store.load();")
                    sw.Append(vbCrLf & "			this.expand();")
                    sw.Append(vbCrLf & "		}")
                    sw.Append(vbCrLf & "},")

                    sw.Append(vbCrLf & "editable: true,")
                    sw.Append(vbCrLf & "enableRegEx: true,")
                    sw.Append(vbCrLf & "queryMode:'local',")
                    sw.Append(vbCrLf & "listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: '" & fld.Caption & "'});} },")

                    sw.Append(vbCrLf & "xtype:  'combobox',")
                    sw.Append(vbCrLf & "store: cmbstore_" + refP.Name.ToLower() + ",")
                    sw.Append(vbCrLf & "valueField:     'id',")
                    sw.Append(vbCrLf & "displayField:   'brief',")
                    sw.Append(vbCrLf & "typeAhead: true,")
                    sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "_id',")
                    sw.Append(vbCrLf & "itemId:   '" & fld.Name.ToLower() & "_id',")
                    sw.Append(vbCrLf & "fieldLabel:  '',")
                    sw.Append(vbCrLf & "emptyText:      '" & fld.Caption & "',")
                    sw.Append(vbCrLf & "hideLabel:  true")


                End If
            End If

        End If

        Return sw.ToString()
    End Function


    Private Function JournalMake_PHPModel(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String

        If Jrnl Is Nothing Then
            Return ""
        End If
        Dim sw As StringBuilder
        sw = New StringBuilder

        Dim i As Integer


        Dim flist As String
        flist = "instanceid,id"

        Dim part As MTZMetaModel.MTZMetaModel.PART
        Dim otype As MTZMetaModel.MTZMetaModel.OBJECTTYPE


        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim p As MTZJrnl.MTZJrnl.Journal
        p = Jrnl.Journal.Item(1)
        'pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)

        Dim va As String
        va = Jrnl.JournalSrc.Item(1).ViewAlias
        Dim vrs As DataTable
        vrs = Manager.Session.GetData("select " + Manager.Session.GetProvider.ID2Base("partviewid") + " from partview where the_alias='" + va + "'")
        If vrs.Rows.Count = 0 Then Return ""
        pv = model.FindRowObject("PartView", New Guid(vrs.Rows(0)("partviewid").ToString))

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If
        part = pv.Parent.Parent
        Dim tmppart As MTZMetaModel.MTZMetaModel.PART
        tmppart = part
        While TypeName(part.Parent.Parent) <> "OBJECTTYPE"
            tmppart = part.Parent.Parent

        End While
        otype = tmppart.Parent.Parent
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        For i = 1 To Jrnl.JournalColumn.Count
            For j = 1 To pv.ViewColumn.Count
                If pv.ViewColumn.Item(j).the_Alias.ToLower() = Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower() Then
                    fld = pv.ViewColumn.Item(j).Field
                    ft = fld.FieldType
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        If ft.Name.ToLower = "date" Then
                            flist = flist & ",DATE_FORMAT(" & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower & ",\'%Y-%m-%d\') " & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower
                        ElseIf ft.Name.ToLower = "time" Then
                            flist = flist & ",DATE_FORMAT(" & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower & ",\' %H:%i:%s\') " & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower
                        ElseIf ft.Name.ToLower = "datetime" Then
                            flist = flist & ",DATE_FORMAT(" & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower & ",\'%Y-%m-%d %H:%i:%s\') " & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower
                        ElseIf ft.Name.ToLower = "birthday" Then
                            flist = flist & "," & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower & " "
                        End If


                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                        flist = flist & "," & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower
                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                        flist = flist & "," & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower
                    End If
                End If
            Next

        Next




        sw.Append(vbCrLf & "<?php")

        sw.Append(vbCrLf & "class  M_v_" & pv.the_Alias.ToLower() & " extends CI_Model {")
        sw.Append(vbCrLf & "    public function  __construct()")
        sw.Append(vbCrLf & "    {")
        sw.Append(vbCrLf & "         parent::__construct();")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function newRow($objtype,$name)  {")
        sw.Append(vbCrLf & "               $id = $this->jservice->get(array('Action'=>'NewGuid'));")
        sw.Append(vbCrLf & "               $this->jservice->get(array('Action'=>'NewDocument', 'TypeName'=>'" + otype.Name + "', 'DocumentID'=>$id, 'DocumentCaption'=>$name));")
        sw.Append(vbCrLf & "               $rowid = $this->jservice->get(array('Action'=>'NewGuid'));")
        sw.Append(vbCrLf & "               $this->jservice->get(array('Action'=>'NewRow', 'PartName'=>'" & part.Name.ToLower() & "', 'RowID'=>$rowid, 'DocumentID'=>$id));")

        sw.Append(vbCrLf & "                if ($id) {")
        sw.Append(vbCrLf & "                    return array('success'=>TRUE, 'data' => $id, 'rowid'=>$rowid);")
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "                else {")
        sw.Append(vbCrLf & "                    $return= array('success'=>FALSE, 'msg' => 'Error while create new id');")
        sw.Append(vbCrLf & "				    return $return;")
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "    }")



        If otype.UseArchiving = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "      function getRowsSL($offset,$limit, $sort = array(), $filter = null, $archived=0){")
        Else
            sw.Append(vbCrLf & "      function getRowsSL($offset,$limit, $sort = array(), $filter = null){")

        End If


        sw.Append(vbCrLf & "        $filter = (array)json_decode($filter);")
        sw.Append(vbCrLf & "       	$cond ='';")
        sw.Append(vbCrLf & "        $whereclause = '';")
        sw.Append(vbCrLf & "    try{")
        sw.Append(vbCrLf & "	    foreach($filter as $obj) {")
        sw.Append(vbCrLf & "		    $tmp = json_decode($obj->value);")
        sw.Append(vbCrLf & "		    if(is_array($tmp)) $obj->value = $tmp;	")
        sw.Append(vbCrLf & "		    switch($obj->property) {")

        sw.Append(vbCrLf & "			    //case 'value':")
        sw.Append(vbCrLf & "			    	//$cond = '';")
        sw.Append(vbCrLf & "			    	//break;")


        Dim favstr As String
        favstr = ""
        If Jrnl.Journal.Item(1).UseFavorites = MTZJrnl.MTZJrnl.enumBoolean.Boolean_Da Then
            favstr = ", 'favorites'=>1"
        End If
        For i = 1 To Jrnl.JournalColumn.Count
            For j = 1 To pv.ViewColumn.Count
                If pv.ViewColumn.Item(j).the_Alias.ToLower() = Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower() Then
                    fld = pv.ViewColumn.Item(j).Field
                    ft = fld.FieldType
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                        sw.Append(vbCrLf & "			  case '" & pv.ViewColumn.Item(j).the_Alias.ToLower() & "_le':")
                        sw.Append(vbCrLf & "			  $cond = '" & pv.ViewColumn.Item(j).the_Alias.ToLower() & "<=""'.$obj->value.'""';")
                        sw.Append(vbCrLf & "			  break;")
                        sw.Append(vbCrLf & "			  case '" & pv.ViewColumn.Item(j).the_Alias.ToLower() & "_ge':")
                        sw.Append(vbCrLf & "			  $cond = '" & pv.ViewColumn.Item(j).the_Alias.ToLower() & ">=""'.$obj->value.'""';")
                        sw.Append(vbCrLf & "			  break;")
                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                        sw.Append(vbCrLf & "			  case '" & pv.ViewColumn.Item(j).the_Alias.ToLower() & "_le':")
                        sw.Append(vbCrLf & "			  $cond = '" & pv.ViewColumn.Item(j).the_Alias.ToLower() & "<='.$obj->value;")
                        sw.Append(vbCrLf & "			  break;")
                        sw.Append(vbCrLf & "			  case '" & pv.ViewColumn.Item(j).the_Alias.ToLower() & "_ge':")
                        sw.Append(vbCrLf & "			  $cond = '" & pv.ViewColumn.Item(j).the_Alias.ToLower() & ">='.$obj->value;")
                        sw.Append(vbCrLf & "			  break;")
                    End If

                End If
            Next

        Next

        sw.Append(vbCrLf & "		    	default:")
        sw.Append(vbCrLf & "			    	if(isset($obj->value))")
        sw.Append(vbCrLf & "			    	{")
        sw.Append(vbCrLf & "			    		if(is_array($obj->value))")
        sw.Append(vbCrLf & "				    	{")
        sw.Append(vbCrLf & "				    		$cond = $obj->property . ' IN (""' . implode('"", ""',$obj->value).'"") ';")
        sw.Append(vbCrLf & "				    		//echo $cond;")
        sw.Append(vbCrLf & "					    }else")
        sw.Append(vbCrLf & "					    {")
        sw.Append(vbCrLf & "					    	$cond = $obj->property . ' LIKE ""%' . $obj->value . '%""';")
        sw.Append(vbCrLf & "					    }")
        sw.Append(vbCrLf & "				    }else{")
        sw.Append(vbCrLf & "				        $cond='1=1';")
        sw.Append(vbCrLf & "				    }")

        sw.Append(vbCrLf & "		    }")
        sw.Append(vbCrLf & "		    $whereclause .= (empty($whereclause)) ? $cond : ' AND ' . $cond;")

        sw.Append(vbCrLf & "	    }")
        sw.Append(vbCrLf & "    }catch(Exception $e) {")
        sw.Append(vbCrLf & "	    log_message('error','Exception: '. $e->getMessage());")
        sw.Append(vbCrLf & "    }")
        If otype.UseArchiving = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "	 if (isset($offset) && isset($limit)) {")
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_" & pv.the_Alias.ToLower() & "','FieldList'=>'" & flist & "','Sort'=>$sort, 'WhereClause' => $whereclause,'Limit'=>$limit,'Offset'=>$offset" & favstr & ",'archived'=>$archived));")
            sw.Append(vbCrLf & "	} else {")
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_" & pv.the_Alias.ToLower() & "','FieldList'=>'" & flist & "','Sort'=>$sort, 'WhereClause' => $whereclause" & favstr & "));")
            sw.Append(vbCrLf & "	}")
            sw.Append(vbCrLf & "	$root = new stdClass();")
            sw.Append(vbCrLf & "	$root->total = $this->jservice->get(array('Action' => 'CountView', 'ViewName' => 'v_" & pv.the_Alias.ToLower() & "','FieldList'=>'" & flist & "', 'WhereClause' => $whereclause" & favstr & ",'archived'=>$archived));")

        Else


            sw.Append(vbCrLf & "	 if (isset($offset) && isset($limit)) {")
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_" & pv.the_Alias.ToLower() & "','FieldList'=>'" & flist & "','Sort'=>$sort, 'WhereClause' => $whereclause,'Limit'=>$limit,'Offset'=>$offset" & favstr & "));")
            sw.Append(vbCrLf & "	} else {")
            sw.Append(vbCrLf & "	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_" & pv.the_Alias.ToLower() & "','FieldList'=>'" & flist & "','Sort'=>$sort, 'WhereClause' => $whereclause" & favstr & "));")
            sw.Append(vbCrLf & "	}")
            sw.Append(vbCrLf & "	$root = new stdClass();")
            sw.Append(vbCrLf & "	$root->total = $this->jservice->get(array('Action' => 'CountView', 'ViewName' => 'v_" & pv.the_Alias.ToLower() & "','FieldList'=>'" & flist & "', 'WhereClause' => $whereclause" & favstr & "));")
        End If
        sw.Append(vbCrLf & "	$root->success = true;")
        sw.Append(vbCrLf & "	$root->rows = $res;")
        sw.Append(vbCrLf & "	return $root;")
        sw.Append(vbCrLf & "}")



        sw.Append(vbCrLf & "    function deleteRow($id = null) {")

        If otype.UseArchiving = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
            sw.Append(vbCrLf & "	    $this->jservice->get(array('Action'=>'DeleteDocument', 'TypeName'=>'" & otype.Name.ToLower & "', 'DocumentID'=>$id));")
        Else
            sw.Append(vbCrLf & "	    $this->jservice->get(array('Action'=>'ArchiveDocument', 'TypeName'=>'" & otype.Name.ToLower & "', 'DocumentID'=>$id));")

        End If

        sw.Append(vbCrLf & "	    $return = array('success' => true);")
        sw.Append(vbCrLf & "	    return $return;")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "}")
        sw.Append(vbCrLf & "?>")



        Return sw.ToString()
    End Function

    Private Function JournalMake_PHPController(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String


        If Jrnl Is Nothing Then
            Return ""
        End If
        Dim sw As StringBuilder
        sw = New StringBuilder

        Dim i As Integer


        Dim flist As String
        flist = "instanceid,id"

    
        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim p As MTZJrnl.MTZJrnl.Journal
        p = Jrnl.Journal.Item(1)
        'pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)
        Dim va As String
        va = Jrnl.JournalSrc.Item(1).ViewAlias
        Dim vrs As DataTable
        vrs = Manager.Session.GetData("select " + Manager.Session.GetProvider.ID2Base("partviewid") + " from partview where the_alias='" + va + "'")
        If vrs.Rows.Count = 0 Then Return ""
        pv = model.FindRowObject("PartView", New Guid(vrs.Rows(0)("partviewid").ToString))

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If
        Dim part As MTZMetaModel.MTZMetaModel.PART
        Dim otype As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        part = pv.Parent.Parent
        Dim tmppart As MTZMetaModel.MTZMetaModel.PART
        tmppart = part
        While TypeName(part.Parent.Parent) <> "OBJECTTYPE"
            tmppart = part.Parent.Parent

        End While
        otype = tmppart.Parent.Parent

        sw.Append(vbCrLf & "    <?php")
        sw.Append(vbCrLf & "	 class C_v_" & pv.the_Alias.ToLower() & " extends CI_Controller {")

        sw.Append(vbCrLf & "    function __construct() {")
        sw.Append(vbCrLf & "         parent::__construct();")
        sw.Append(vbCrLf & "        $this->_loadModels();")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function newRow() {")
        sw.Append(vbCrLf & "            log_message('debug', '" & pv.the_Alias & ".newRow post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "            $name  =  $this->input->get_post('name', TRUE);")
        sw.Append(vbCrLf & "            $objtype  =  $this->input->get_post('objtype', TRUE);")
        sw.Append(vbCrLf & "            $" & pv.the_Alias.ToLower() & "= $this->m_v_" & pv.the_Alias.ToLower() & "->newRow($name,$objtype);")
        sw.Append(vbCrLf & "            $return = $" & pv.the_Alias.ToLower() & ";")
        sw.Append(vbCrLf & "            print json_encode($return);")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function getRows() {")
        sw.Append(vbCrLf & "            log_message('debug', '" & pv.the_Alias & ".getRows post : '.json_encode($this->input->post(NULL, FALSE)));")

        If otype.UseArchiving = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "      $archived=$this->input->get('archived', FALSE);")
            sw.Append(vbCrLf & "      if(!$archived ) $archived=0; ")
        End If

        sw.Append(vbCrLf & "           $start=$this->input->get('start', FALSE);")
        sw.Append(vbCrLf & "           $limit=$this->input->get('limit', FALSE);")


        sw.Append(vbCrLf & "       $group = $this->input->get('group', FALSE);  ")
        sw.Append(vbCrLf & "      $sort = $this->input->get('sort', FALSE);")
        sw.Append(vbCrLf & "      if(!$sort && $group) $sort = $group;")
        sw.Append(vbCrLf & "      if(!$sort || $group == $sort) ")
        sw.Append(vbCrLf & "          {")
        sw.Append(vbCrLf & "              $sort = json_decode($sort);")
        sw.Append(vbCrLf & "              //$sort[] = array('property'=>'field_name', 'direction'=>'ASC');")
        sw.Append(vbCrLf & "              $sort = json_encode($sort);")
        sw.Append(vbCrLf & "          }")
        sw.Append(vbCrLf & "          $filter = $this->input->get('filter', FALSE);")

        If otype.UseArchiving = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "           $" & pv.the_Alias.ToLower() & "= $this->m_v_" & pv.the_Alias.ToLower() & "->getRowsSL($start,$limit,$sort,$filter,$archived);")
        Else
            sw.Append(vbCrLf & "           $" & pv.the_Alias.ToLower() & "= $this->m_v_" & pv.the_Alias.ToLower() & "->getRowsSL($start,$limit,$sort,$filter);")
        End If

        sw.Append(vbCrLf & "           print json_encode($" & pv.the_Alias.ToLower() & ");")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function deleteRow() {")
        sw.Append(vbCrLf & "        log_message('debug', '" & pv.the_Alias & ".deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "        $tempId  =  $this->input->get_post('instanceid', TRUE);")
        sw.Append(vbCrLf & "        if (strlen($tempId) > 0) {")
        sw.Append(vbCrLf & "            $return = $this->m_v_" & pv.the_Alias.ToLower() & "->deleteRow($tempId);")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        else {")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => FALSE,")
        sw.Append(vbCrLf & "                'msg'     => 'No  ID to delete'")
        sw.Append(vbCrLf & "            );")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        print json_encode($return);")
        sw.Append(vbCrLf & "    }")



        sw.Append(vbCrLf & "    private function _loadModels () {")
        sw.Append(vbCrLf & "        $this->load->model('M_v_" & pv.the_Alias.ToLower() & "', 'm_v_" & pv.the_Alias.ToLower() & "');")
        sw.Append(vbCrLf & "    }")
        sw.Append(vbCrLf & "}")
        Return sw.ToString()
    End Function

    Private Function JournalMake_JSModel(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String
        Dim sw As StringBuilder
        sw = New StringBuilder

        Dim i As Integer


        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW
        Dim prt As MTZMetaModel.MTZMetaModel.PART
        Dim p As MTZJrnl.MTZJrnl.Journal
        p = Jrnl.Journal.Item(1)
        'pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)

        Dim va As String
        va = Jrnl.JournalSrc.Item(1).ViewAlias
        Dim vrs As DataTable
        vrs = Manager.Session.GetData("select " + Manager.Session.GetProvider.ID2Base("partviewid") + " from partview where the_alias='" + va + "'")
        If vrs.Rows.Count = 0 Then Return ""
        pv = model.FindRowObject("PartView", New Guid(vrs.Rows(0)("partviewid").ToString))

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If

        Dim j As Integer
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        prt = pv.Parent.Parent

        sw.Append(vbCrLf & " Ext.define('model_v_" & pv.the_Alias.ToLower() & "',{")
        sw.Append(vbCrLf & "            extend:'Ext.data.Model',")
        sw.Append(vbCrLf & "        fields: [")
        sw.Append(vbCrLf & "            {name: 'instanceid',type: 'string'}")
        sw.Append(vbCrLf & "            ,{name: 'id',type: 'string'}")

        If p.UseFavorites = MTZJrnl.MTZJrnl.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "            ,{name: 'isfavorite',type: 'bool'}")
        End If



        For i = 1 To Jrnl.JournalColumn.Count
            For j = 1 To pv.ViewColumn.Count
                If pv.ViewColumn.Item(j).the_Alias.ToLower() = Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower() Then
                    fld = pv.ViewColumn.Item(j).Field
                    ft = fld.FieldType
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                        sw.Append(vbCrLf & "            ,{name:'" & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower() & "', type: 'string'}")
                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                        sw.Append(vbCrLf & "            ,{name:'" & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower() & "', type: 'number'}")
                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                        sw.Append(vbCrLf & "            ,{name:'" & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower() & "', type: 'string'}")
                    End If
                End If
            Next

        Next
        sw.Append(vbCrLf & "        ]")
        sw.Append(vbCrLf & "    });")
        Return sw.ToString()
    End Function

    Private Function JournalMake_JSStore(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String
        Dim sw As StringBuilder
        sw = New StringBuilder

        Dim i As Integer


        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim p As MTZJrnl.MTZJrnl.Journal
        p = Jrnl.Journal.Item(1)
        ' pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)

        Dim va As String
        va = Jrnl.JournalSrc.Item(1).ViewAlias
        Dim vrs As DataTable
        vrs = Manager.Session.GetData("select " + Manager.Session.GetProvider.ID2Base("partviewid") + " from partview where the_alias='" + va + "'")
        If vrs.Rows.Count = 0 Then Return ""
        pv = model.FindRowObject("PartView", New Guid(vrs.Rows(0)("partviewid").ToString))

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If
        Dim part As MTZMetaModel.MTZMetaModel.PART
        Dim otype As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        part = pv.Parent.Parent
        Dim tmppart As MTZMetaModel.MTZMetaModel.PART
        tmppart = part
        While TypeName(part.Parent.Parent) <> "OBJECTTYPE"
            tmppart = part.Parent.Parent

        End While
        otype = tmppart.Parent.Parent

        sw.Append(vbCrLf & "    var store_v_" & pv.the_Alias.ToLower() & " = Ext.create('Ext.data.Store', {")
        sw.Append(vbCrLf & "        model:'model_v_" & pv.the_Alias.ToLower() & "',")
        sw.Append(vbCrLf & "        autoLoad: false,")
        sw.Append(vbCrLf & "        autoSync: false,")
        sw.Append(vbCrLf & "        remoteSort: true,")
        sw.Append(vbCrLf & "        remoteFilter:true,")
        sw.Append(vbCrLf & "        pageSize : 30,")
        sw.Append(vbCrLf & "        proxy: {")
        sw.Append(vbCrLf & "            type:   'ajax',")
        sw.Append(vbCrLf & "                url:   rootURL+'" & basepath & "c_v_" & pv.the_Alias.ToLower() & "/getRows',")

        If otype.UseArchiving = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "            extraParams: {archived:0}, ")
        End If
        sw.Append(vbCrLf & "            reader: {")
        sw.Append(vbCrLf & "                type:   'json'")
        sw.Append(vbCrLf & "                ,root:  'rows'")
        sw.Append(vbCrLf & "                ,totalProperty: 'total'")
        sw.Append(vbCrLf & "                ,successProperty:  'success'")
        sw.Append(vbCrLf & "                ,messageProperty:  'msg'")
        sw.Append(vbCrLf & "            },")
        'sw.Append(vbCrLf & "            writer: {")
        'sw.Append(vbCrLf & "                type:   'json',")
        'sw.Append(vbCrLf & "                writeAllFields: true")
        'sw.Append(vbCrLf & "            },")
        sw.Append(vbCrLf & "            listeners: {")
        sw.Append(vbCrLf & "                exception: function(proxy, response, operation){")
        sw.Append(vbCrLf & "                    Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                        title: 'REMOTE EXCEPTION',")
        sw.Append(vbCrLf & "                        msg:    operation.getError(),")
        sw.Append(vbCrLf & "                        icon : Ext.MessageBox.ERROR,")
        sw.Append(vbCrLf & "                        buttons : Ext.Msg.OK")
        sw.Append(vbCrLf & "                    });")
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "            }")



        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    });")

        Return sw.ToString()
    End Function

    Private Function JournalMake_Filter(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String

        Dim fltr As MTZFltr.MTZFltr.Application = Nothing

        Dim dt As DataTable
        dt = Manager.Session.GetData("select " + Manager.Session.GetProvider().InstanceFieldList() + " from instance where objtype='mtzfltr' and name='" + Jrnl.Name + "'")

        If dt.Rows.Count > 0 Then

            fltr = CType(Manager.GetInstanceObject(New Guid(dt.Rows(0)("instanceid").ToString())), MTZFltr.MTZFltr.Application)
        End If
        Dim sw As StringBuilder
        sw = New StringBuilder
        If Not fltr Is Nothing Then

            sw.Append(vbCrLf & ", rbar:")
            sw.Append(vbCrLf & "                [")
            sw.Append(vbCrLf & "                {")
            sw.Append(vbCrLf & "                    xtype:  'form',")
            sw.Append(vbCrLf & "                    title:  'Фильтры',")
            sw.Append(vbCrLf & "                    iconCls:  'icon-find',")
            sw.Append(vbCrLf & "                    flex:1,")
            sw.Append(vbCrLf & "					collapsible:true,")
            sw.Append(vbCrLf & "                    collapseDirection:  'right',")
            sw.Append(vbCrLf & "					animCollapse: false, ")
            sw.Append(vbCrLf & "					titleCollapse:true,")
            sw.Append(vbCrLf & "					bodyPadding:5,")
            sw.Append(vbCrLf & "					width:200,")
            sw.Append(vbCrLf & "					minWidth:200,")
            sw.Append(vbCrLf & "					autoScroll:true,")
            sw.Append(vbCrLf & "                    buttonAlign:  'center',")
            sw.Append(vbCrLf & "					layout: {")
            sw.Append(vbCrLf & "                    type:   'vbox',")
            sw.Append(vbCrLf & "                    align:  'stretch'")
            sw.Append(vbCrLf & "				},")
            sw.Append(vbCrLf & "                defaultType:  'textfield',")
            sw.Append(vbCrLf & "				items: [")

            ' filter field


            Dim fg As MTZFltr.MTZFltr.FilterFieldGroup
            Dim fld As MTZFltr.MTZFltr.FileterField
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
            Dim j As Integer
            Dim FirstField As Boolean = True
            fltr.FilterFieldGroup.Sort = "sequence"
            For i = 1 To fltr.FilterFieldGroup.Count
                fg = fltr.FilterFieldGroup.Item(i)
                fg.FileterField.Sort = "sequence"
                For j = 1 To fg.FileterField.Count
                    fld = fg.FileterField.Item(j)
                    ft = CType(fld.FieldType, MTZMetaModel.MTZMetaModel.FIELDTYPE)

                    If Not FirstField Then
                        sw.Append(vbCrLf & ",")
                    End If
                    sw.Append(vbCrLf & "{")
                    sw.Append(vbCrLf & Tool_MakeFilterField(fld))
                    sw.Append(vbCrLf & "}")
                    FirstField = False
                Next
            Next

            sw.Append(vbCrLf & "					],")

            If Jrnl.Journal.Item(1).UseFavorites = MTZJrnl.MTZJrnl.enumBoolean.Boolean_Da Then
                sw.Append(vbCrLf & "					resetFavorites: function()")
                sw.Append(vbCrLf & "                    {")
                sw.Append(vbCrLf & "                        Ext.Ajax.request({")
                sw.Append(vbCrLf & "                            url: rootURL+'index.php/app2/resetFavorite',")
                sw.Append(vbCrLf & "                            method:  'POST',")
                sw.Append(vbCrLf & "                            params: { ")
                sw.Append(vbCrLf & "                                type: '" & Jrnl.Name & "'")
                sw.Append(vbCrLf & "                            }")
                sw.Append(vbCrLf & "                        });")
                sw.Append(vbCrLf & "                    },")
            End If

            sw.Append(vbCrLf & "                    buttons: ")
            sw.Append(vbCrLf & "                    [")
            sw.Append(vbCrLf & "                        {")
            sw.Append(vbCrLf & "                            text: 'Найти',")
            sw.Append(vbCrLf & "							iconCls:'icon-find',")
            sw.Append(vbCrLf & "                            formBind: true, ")
            sw.Append(vbCrLf & "                            disabled: false,")
            sw.Append(vbCrLf & "                            grid: this,")
            sw.Append(vbCrLf & "                            handler: function() {")

            If Jrnl.Journal.Item(1).UseFavorites = MTZJrnl.MTZJrnl.enumBoolean.Boolean_Da Then
                sw.Append(vbCrLf & "                                this.up('form').resetFavorites();")
            End If

            sw.Append(vbCrLf & "                                var user_input =this.up('form').getForm().getValues(false,true);")
            sw.Append(vbCrLf & "                                var filters = new Array();")
            sw.Append(vbCrLf & "								if(this.grid.default_filter != null){")
            sw.Append(vbCrLf & "									for (var i=0; i< this.grid.default_filter.length;i++) {")
            sw.Append(vbCrLf & "										var kv=this.grid.default_filter[i];")
            sw.Append(vbCrLf & "										filters.push({property: kv.key, value: kv.value});")
            sw.Append(vbCrLf & "									}")
            sw.Append(vbCrLf & "								}")
            sw.Append(vbCrLf & "                                for (var key in user_input) {")
            sw.Append(vbCrLf & "                                    filters.push({property: key, value: user_input[key]});")
            sw.Append(vbCrLf & "                                }")
            sw.Append(vbCrLf & "                                if (this.grid.store.filters.length>0) ")
            sw.Append(vbCrLf & "                                    this.grid.store.filters.clear();")
            sw.Append(vbCrLf & "                                if (filters.length>0) ")
            sw.Append(vbCrLf & "                                    this.grid.store.filter(filters); ")
            sw.Append(vbCrLf & "                                else ")
            sw.Append(vbCrLf & "								   this.grid.store.load();")
            sw.Append(vbCrLf & "                            }")
            sw.Append(vbCrLf & "                        }, {")
            sw.Append(vbCrLf & "							text: 'Сбросить',")
            sw.Append(vbCrLf & "							iconCls:'icon-cancel',")
            sw.Append(vbCrLf & "                            grid: this,")
            sw.Append(vbCrLf & "                            handler: function() {")
            If Jrnl.Journal.Item(1).UseFavorites = MTZJrnl.MTZJrnl.enumBoolean.Boolean_Da Then
                sw.Append(vbCrLf & "                                this.up('form').resetFavorites();")
            End If


            sw.Append(vbCrLf & "                                this.up('form').getForm().reset();")
            sw.Append(vbCrLf & "								var filters = new Array();")
            sw.Append(vbCrLf & "                                if(this.grid.default_filter!=null){")
            sw.Append(vbCrLf & "									for (var i=0; i< this.grid.default_filter.length;i++) {")
            sw.Append(vbCrLf & "										var kv=this.grid.default_filter[i];")
            sw.Append(vbCrLf & "										filters.push({property: kv.key, value: kv.value});")
            sw.Append(vbCrLf & "									}")
            sw.Append(vbCrLf & "								}")
            sw.Append(vbCrLf & "                                if (this.grid.store.filters.length>0) ")
            sw.Append(vbCrLf & "                                    this.grid.store.filters.clear();")
            sw.Append(vbCrLf & "                                if (filters.length>0) ")
            sw.Append(vbCrLf & "                                    this.grid.store.filter(filters); ")
            sw.Append(vbCrLf & "                                else ")
            sw.Append(vbCrLf & "								   this.grid.store.load();")

            sw.Append(vbCrLf & "                            }")
            sw.Append(vbCrLf & "                        }")
            sw.Append(vbCrLf & "                    ]")
            sw.Append(vbCrLf & "                }")
            sw.Append(vbCrLf & "            ]//rbar")

        End If

        Return sw.ToString()
    End Function

    Private Function JournalMake_JSGrid(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String
        Dim sw As StringBuilder
        sw = New StringBuilder

        Dim i As Integer

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim p As MTZJrnl.MTZJrnl.Journal
        p = Jrnl.Journal.Item(1)
        'pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)
        Dim va As String
        va = Jrnl.JournalSrc.Item(1).ViewAlias
        Dim vrs As DataTable
        vrs = Manager.Session.GetData("select " + Manager.Session.GetProvider.ID2Base("partviewid") + " from partview where the_alias='" + va + "'")
        If vrs.Rows.Count = 0 Then Return ""
        pv = model.FindRowObject("PartView", New Guid(vrs.Rows(0)("partviewid").ToString))

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If

        Dim saveall As Boolean
        Try
            ot = pv.Parent.Parent.Parent.Parent
            saveall = ot.CommitFullObject = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
        Catch ex As Exception
            ot = Nothing
            saveall = False
        End Try


        sw.Append(vbCrLf & "var groupingFeature_" & pv.the_Alias.ToLower() & " = Ext.create('Ext.grid.feature.Grouping',{")
        sw.Append(vbCrLf & "groupByText:  'Группировать по этому полю',")
        sw.Append(vbCrLf & "showGroupsText:  'Показать группировку'")
        sw.Append(vbCrLf & "});")
        sw.Append(vbCrLf & "var interval_" & pv.the_Alias.ToLower() & ";")

        sw.Append(vbCrLf & "Ext.define('grid_" & pv.the_Alias.ToLower() & "', {")
        sw.Append(vbCrLf & "    extend:  'Ext.grid.Panel',")
        sw.Append(vbCrLf & "    alias: 'widget.g_v_" & pv.the_Alias.ToLower() & "',")

        sw.Append(vbCrLf & "    requires: [")
        sw.Append(vbCrLf & "        'Ext.grid.*',")
        sw.Append(vbCrLf & "        'Ext.form.field.Text',")
        sw.Append(vbCrLf & "        'Ext.toolbar.TextItem'")
        sw.Append(vbCrLf & "    ],")

        sw.Append(vbCrLf & "    initComponent: function(){")
        sw.Append(vbCrLf & "        Ext.apply(this, {")

        'If p.jrnlIconCls <> "" Then
        '    sw.Append(vbCrLf & " //       iconCls:  '" & p.jrnlIconCls & "',")
        'Else
        '    sw.Append(vbCrLf & "   //     iconCls:  'icon-grid',")
        'End If
        'sw.Append(vbCrLf & "       // title: """ & p.Name & """,")


        sw.Append(vbCrLf & "        frame: false,")
        sw.Append(vbCrLf & "        store: store_v_" & pv.the_Alias.ToLower() & ",")
        sw.Append(vbCrLf & "        features: [groupingFeature_" & pv.the_Alias.ToLower() & "],")
        sw.Append(vbCrLf & "        defaultDockWeights : { top: 7, bottom: 5, left: 1, right: 3 },")
        sw.Append(vbCrLf & "        viewConfig: {               enableTextSelection: true        },")
        sw.Append(vbCrLf & "        dockedItems: [{")
        sw.Append(vbCrLf & "                xtype:  'toolbar',")
        sw.Append(vbCrLf & "                     items: [{")
        sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_add',")
        sw.Append(vbCrLf & "                    text:   'Создать',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onAddClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
        sw.Append(vbCrLf & "                    text:   'Изменить',")
        sw.Append(vbCrLf & "                    itemId:  'edit',")
        sw.Append(vbCrLf & "                    disabled: true,")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onEditClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_delete',")
        sw.Append(vbCrLf & "                    text:   'Удалить',")
        sw.Append(vbCrLf & "                    disabled: true,")
        sw.Append(vbCrLf & "                    itemId:  'delete',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onDeleteClick")
        sw.Append(vbCrLf & "                    }, {")
        'sw.Append(vbCrLf & "                    iconCls:  'icon-find',")
        'sw.Append(vbCrLf & "                    text:   'Поиск',")
        'sw.Append(vbCrLf & "                    disabled: true,")
        'sw.Append(vbCrLf & "                    itemId:  'find',")
        'sw.Append(vbCrLf & "                    scope:  this,")
        'sw.Append(vbCrLf & "                    handler : this.onFindClick")
        'sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
        sw.Append(vbCrLf & "                    text:   'Обновить',")
        sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onRefreshClick")
        sw.Append(vbCrLf & "                   } , {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-page_excel',")
        sw.Append(vbCrLf & "                    text:   'Экспорт',")
        sw.Append(vbCrLf & "                    itemId:  'bExport',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler: this.onExportClick")
        sw.Append(vbCrLf & "                }]")
        sw.Append(vbCrLf & "            }],")

        sw.Append(vbCrLf & "        columns: [")

        If p.UseFavorites = MTZJrnl.MTZJrnl.enumBoolean.Boolean_Da Then
            sw.Append(vbCrLf & "                    {")
            sw.Append(vbCrLf & "                      xtype:  'checkcolumn',")
            sw.Append(vbCrLf & "                      width: 30,")
            sw.Append(vbCrLf & "                      dataIndex:  'isfavorite',")
            sw.Append(vbCrLf & "						fixed: true,")
            sw.Append(vbCrLf & "						menuDisabled: true,")
            sw.Append(vbCrLf & "						sortable: false,")
            sw.Append(vbCrLf & "                      listeners:")
            sw.Append(vbCrLf & "                        {")
            sw.Append(vbCrLf & "                            checkchange: function( cell, rowIndex, checked, eOpts )")
            sw.Append(vbCrLf & "                            {")
            sw.Append(vbCrLf & "                                var record = cell.up('grid').getStore().getAt(rowIndex);")
            sw.Append(vbCrLf & "                                var value = 0;")
            sw.Append(vbCrLf & "                                if(checked) value = 1;")

            sw.Append(vbCrLf & "                                Ext.Ajax.request({")
            sw.Append(vbCrLf & "                                    url: rootURL+'index.php/app2/setFavorite',")
            sw.Append(vbCrLf & "                                      method:     'POST',")
            sw.Append(vbCrLf & "                                    params: { ")
            sw.Append(vbCrLf & "                                        instanceid: record.get('instanceid'),")
            sw.Append(vbCrLf & "                                      value:value")
            sw.Append(vbCrLf & "                                    },")
            sw.Append(vbCrLf & "                                    success: function(response, opts) ")
            sw.Append(vbCrLf & "                                    {")
            sw.Append(vbCrLf & "                                        record.commit();")
            sw.Append(vbCrLf & "                                    }")
            sw.Append(vbCrLf & "                                });")
            sw.Append(vbCrLf & "                            }")
            sw.Append(vbCrLf & "                        }")
            sw.Append(vbCrLf & "                    },")
        End If

        Jrnl.JournalColumn.Sort = "sequence"

        Dim jc As MTZJrnl.MTZJrnl.JournalColumn
        Dim wi As Integer
        For i = 1 To Jrnl.JournalColumn.Count
            jc = Jrnl.JournalColumn.Item(i)


            If i > 1 Then
                sw.Append(vbCrLf & "            ,")
            End If
            If Jrnl.JournalColumn.Count = 1 Then
                wi = 800
            Else
                wi = 800 / Jrnl.JournalColumn.Count
                If wi < 120 Then
                    wi = 120
                End If
            End If

            Dim fld As MTZMetaModel.MTZMetaModel.FIELD
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
            fld = Nothing
            ft = Nothing
            For ii = 1 To pv.ViewColumn.Count

                If pv.ViewColumn.Item(ii).the_Alias.ToLower() = jc.JColumnSource.Item(1).ViewField.ToLower() Then
                    fld = pv.ViewColumn.Item(ii).Field
                    ft = fld.FieldType
                    Exit For
                End If



            Next

            If Not ft Is Nothing Then
                If ft.Name.ToLower = "file" Then
                    sw.Append(vbCrLf & "{ text     : '" & jc.name & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                    sw.Append(vbCrLf & "tpl:'<a href=\'/output_file.php?ID={" & jc.JColumnSource.Item(1).ViewField.ToLower() & "}&ext={" & jc.JColumnSource.Item(1).ViewField.ToLower() & "_ext}\' target=\'_blank\'>Файл</a>'}")
                ElseIf ft.Name.ToLower = "url" Then
                    sw.Append(vbCrLf & "{ text     : '" & jc.name & "', xtype: 'templatecolumn',  align:'right',width    : 90,	sortable : false,")
                    sw.Append(vbCrLf & "tpl:'<a href=\'{" & jc.JColumnSource.Item(1).ViewField.ToLower() & "}\' target=\'_blank\'>" & jc.name & "</a>'}")
                ElseIf ft.Name.ToLower = "html" Then
                    sw.Append(vbCrLf & "{text: """ & jc.name & """, width: 200, dataIndex: '" & jc.JColumnSource.Item(1).ViewField.ToLower() & "', sortable: true,")
                    sw.Append(vbCrLf & " renderer: function(value){var S =new String(value);  S=S.replace(new RegExp('/>','g'),'');  S=S.replace(new RegExp('<','g'),''); S=S.replace(new RegExp('>','g'),''); if(S.length >255) S=S.substr(0,255); return S;}}")

                Else
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                        sw.Append(vbCrLf & "            {text: """ & jc.name & """, width:" & wi.ToString & ", dataIndex: '" & jc.JColumnSource.Item(1).ViewField.ToLower() & "', sortable: true,renderer:myDateRenderer}")
                    Else
                        sw.Append(vbCrLf & "            {text: """ & jc.name & """, width:" & wi.ToString & ", dataIndex: '" & jc.JColumnSource.Item(1).ViewField.ToLower() & "', sortable: true}")
                    End If

                End If
            Else
                sw.Append(vbCrLf & "            {text: """ & jc.name & """, width:" & wi.ToString & ", dataIndex: '" & jc.JColumnSource.Item(1).ViewField.ToLower() & "', sortable: true}")
            End If

        Next
        sw.Append(vbCrLf & "        ]")  ' columns

        sw.Append(vbCrLf & "        ,")


        sw.Append(vbCrLf & "        bbar: Ext.create('Ext.PagingToolbar', {")
        sw.Append(vbCrLf & "        store: store_v_" & pv.the_Alias.ToLower() & ",")
        sw.Append(vbCrLf & "        displayInfo: true,")
        sw.Append(vbCrLf & "        displayMsg:  'Показаны строки с {0} по {1} из {2}',")
        sw.Append(vbCrLf & "        emptyMsg: 'нет данных'")
        sw.Append(vbCrLf & "        ")
        sw.Append(vbCrLf & "        })")


        sw.Append(vbCrLf & JournalMake_Filter(Jrnl))


        sw.Append(vbCrLf & "        }")  ' Ext.apply_data
        sw.Append(vbCrLf & "        );")  ' Ext.apply

        sw.Append(vbCrLf & "        this.callParent();")
        sw.Append(vbCrLf & "        this.getSelectionModel().on('selectionchange', this.onSelectChange, this);")
        sw.Append(vbCrLf & "        this.store.load()")
        sw.Append(vbCrLf & "       },") ' initComponent

        sw.Append(vbCrLf & "        onSelectChange: function(selModel, selections){")
        sw.Append(vbCrLf & "        this.down('#delete').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "        this.down('#edit').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "    },")



        sw.Append(vbCrLf & "    listeners: {")
        sw.Append(vbCrLf & "        itemdblclick: function() { ")
        sw.Append(vbCrLf & "    	    this.onEditClick();")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        ,")
        sw.Append(vbCrLf & "        	added:function(){")
        sw.Append(vbCrLf & "        			//interval_" & pv.the_Alias.ToLower() & "= setInterval(function() {  ")
        sw.Append(vbCrLf & "        			//	store_v_" & pv.the_Alias.ToLower() & ".load();")
        sw.Append(vbCrLf & "        			//}, 60000);")
        sw.Append(vbCrLf & "        		}")
        sw.Append(vbCrLf & "        	,")
        sw.Append(vbCrLf & "        	destroy:function(){")
        sw.Append(vbCrLf & "        		//clearInterval(interval_" & pv.the_Alias.ToLower() & ");")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    },")


        sw.Append(vbCrLf & "    onDeleteConfirm:function(selection){")
        sw.Append(vbCrLf & "      if (selection) {")
        sw.Append(vbCrLf & "        Ext.Ajax.request({")
        sw.Append(vbCrLf & "            url:    rootURL+'" & basepath & "c_v_" & pv.the_Alias.ToLower() & "/deleteRow',")
        sw.Append(vbCrLf & "            method:  'POST',")
        sw.Append(vbCrLf & "    		params: { ")
        sw.Append(vbCrLf & "    				instanceid: selection.get('instanceid')")
        sw.Append(vbCrLf & "    				}")
        sw.Append(vbCrLf & "    	});")
        sw.Append(vbCrLf & "    	this.store.remove(selection);")
        sw.Append(vbCrLf & "      }")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onDeleteClick: function(){")
        sw.Append(vbCrLf & "      var selection = this.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "      if (selection) {")
        'sw.Append(vbCrLf & "   	  if(CheckOperation('" + Jrnl.Name + ".del')!=0){")
        sw.Append(vbCrLf & "   	    if(CheckOperation('" + Jrnl.Name + ".edit')!=0 && OTAllowDelete('" + Jrnl.Name + "')){")
        sw.Append(vbCrLf & "        Ext.Msg.show({")
        sw.Append(vbCrLf & "            title:  'Удалить?',")
        sw.Append(vbCrLf & "            msg:    'Удалить строку из базы данных?',")
        sw.Append(vbCrLf & "        	buttons: Ext.Msg.YESNO,")
        sw.Append(vbCrLf & "        	icon:   Ext.MessageBox.QUESTION,")
        sw.Append(vbCrLf & "        	fn: function(btn,text,opt){")
        sw.Append(vbCrLf & "        		if(btn=='yes'){")
        sw.Append(vbCrLf & "        			opt.caller.onDeleteConfirm(opt.selectedRow);")
        sw.Append(vbCrLf & "        	    }")
        sw.Append(vbCrLf & "        	},")
        sw.Append(vbCrLf & "            caller: this,")
        sw.Append(vbCrLf & "            selectedRow: selection")
        sw.Append(vbCrLf & "        });")

        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Удаление объектов не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "      }")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onAddClick: function(){")
        ''''''''''''''''''''''''''''' submit Add 
        'sw.Append(vbCrLf & "   	if(CheckOperation('" + Jrnl.Name + ".add')!=0){")
        sw.Append(vbCrLf & "   	    if(CheckOperation('" + Jrnl.Name + ".edit')!=0 && OTAllowAdd('" + Jrnl.Name + "')){")
        sw.Append(vbCrLf & "            Ext.Ajax.request({")
        sw.Append(vbCrLf & "                url: rootURL+'" & basepath & "c_v_" & pv.the_Alias.ToLower() & "/newRow',")
        sw.Append(vbCrLf & "                method:  'POST',")
        sw.Append(vbCrLf & "                params: { ")
        sw.Append(vbCrLf & "                },")
        sw.Append(vbCrLf & "                success: function(response){")
        sw.Append(vbCrLf & "                var text = response.responseText;")
        sw.Append(vbCrLf & "                var res =Ext.decode(text);")
        'If saveall Then
        sw.Append(vbCrLf & "                var edit = Ext.create('iu.windowObjects');")
        sw.Append(vbCrLf & "                edit.prefix='c_v_" + pv.the_Alias.ToLower() + "';")
        If Not ot Is Nothing Then
            sw.Append(vbCrLf & "                edit.setTitle('Создание документа:" + ot.the_Comment + "') ;")
        Else
            sw.Append(vbCrLf & "                edit.setTitle('Создание документа') ;")
        End If
        'Else
        'sw.Append(vbCrLf & "                var edit = Ext.create('ObjectWindow_" & Jrnl.Name.ToLower() & "');")
        'End If
        ' sw.Append(vbCrLf & "                var p=" & Jrnl.Name & "_Panel_( res.data, false,null ) ;")
        sw.Append(vbCrLf & "                var p=eval('" & Jrnl.Name & "_Panel_'+OTAddMode('" & Jrnl.Name & "')+'( res.data, false,null )') ;")
        sw.Append(vbCrLf & "                edit.add(p);")
        sw.Append(vbCrLf & "                edit.show();")
        sw.Append(vbCrLf & "                }")

        sw.Append(vbCrLf & "            });")
        sw.Append(vbCrLf & "            this.store.load();")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Создание объектов не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    },")


        sw.Append(vbCrLf & "    onEditClick: function(){")
        sw.Append(vbCrLf & "        var selection = this.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        sw.Append(vbCrLf & "   	    if(CheckOperation('" + Jrnl.Name + ".edit')!=0 ){")
        'If saveall Then
        sw.Append(vbCrLf & "                var edit = Ext.create('iu.windowObjects');")
        sw.Append(vbCrLf & "                edit.prefix='c_v_" + pv.the_Alias.ToLower() + "';")
        If Not ot Is Nothing Then
            sw.Append(vbCrLf & "                edit.setTitle('Редактирование документа: " + ot.the_Comment + "') ;")
        Else
            sw.Append(vbCrLf & "                edit.setTitle('Редактирование документа') ;")
        End If
        'Else
        'sw.Append(vbCrLf & "                var edit = Ext.create('ObjectWindow_" & Jrnl.Name.ToLower() & "');")
        'End If
        sw.Append(vbCrLf & "            var p=eval('" & Jrnl.Name & "_Panel_'+OTEditMode('" & Jrnl.Name & "')+'( selection.get(\'instanceid\'), false, selection )') ;")
        'sw.Append(vbCrLf & "            var p=" & Jrnl.Name & "_Panel_( selection.get('instanceid'), false, selection ) ;")
        sw.Append(vbCrLf & "            edit.add(p);")
        sw.Append(vbCrLf & "            edit.show();")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "        		Ext.MessageBox.show({")
        sw.Append(vbCrLf & "                title:  'Контроль прав.',")
        sw.Append(vbCrLf & "                msg:    'Изменение объектов не разрешено!',")
        sw.Append(vbCrLf & "                buttons: Ext.MessageBox.OK,")
        sw.Append(vbCrLf & "               icon:   Ext.MessageBox.WARNING")
        sw.Append(vbCrLf & "        		});")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "        }")

        sw.Append(vbCrLf & "    },")
        'sw.Append(vbCrLf & "    onFindClick: function(){")
        'sw.Append(vbCrLf & "            alert('find condition window. todo');")
        'sw.Append(vbCrLf & "    },")
        sw.Append(vbCrLf & "    onRefreshClick: function(){")
        sw.Append(vbCrLf & "             this.store.load();")
        sw.Append(vbCrLf & "    }")
        sw.Append(vbCrLf & "    ,")
        sw.Append(vbCrLf & "     onExportClick: function(){ ")
        sw.Append(vbCrLf & "         	var config= {title:this.title, columns:this.columns };")
        sw.Append(vbCrLf & "    	var workbook = new Workbook(config);")
        sw.Append(vbCrLf & "    workbook.addWorksheet(this.store, config );")
        sw.Append(vbCrLf & "    var x= workbook.render();")
        sw.Append(vbCrLf & "    window.open( 'data:application/vnd.ms-excel;base64,' + Base64.encode(x),'_blank');")
        sw.Append(vbCrLf & "     }")

        sw.Append(vbCrLf & "    }")  'Ext.Define_data
        sw.Append(vbCrLf & "    );")  'Ext.Define

        sw.Append(vbCrLf & "Ext.require([")
        sw.Append(vbCrLf & "'Ext.form.*'")
        sw.Append(vbCrLf & "]);")

        sw.Append(vbCrLf & "function " & Jrnl.Name & "_Jrnl(){ " & vbCrLf)

        sw.Append(vbCrLf & "  var " & Jrnl.Name & "= Ext.create('Ext.form.Panel', {")
        sw.Append(vbCrLf & "       closable: true,")
        sw.Append(vbCrLf & "       id:     '" & Jrnl.Name.ToLower() & "_jrnl',")
        sw.Append(vbCrLf & "       title: '" & p.Name & "',")
        'sw.Append(vbCrLf & "       bodyStyle:'padding:1px',")
        'sw.Append(vbCrLf & "      width: 640,")
        sw.Append(vbCrLf & "      layout: 'fit',")
        sw.Append(vbCrLf & "      flex: 1,")
        sw.Append(vbCrLf & "      fieldDefaults: {")
        sw.Append(vbCrLf & "         labelAlign:             'top',")
        sw.Append(vbCrLf & "          msgTarget:             'side'")
        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "        defaults: {")
        sw.Append(vbCrLf & "        anchor:'100%'")
        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "")
        sw.Append(vbCrLf & "        items: [{")
        sw.Append(vbCrLf & "            itemId:'gr_" & pv.the_Alias.ToLower() & "',")
        sw.Append(vbCrLf & "            xtype:'g_v_" & pv.the_Alias.ToLower() & "',")
        'sw.Append(vbCrLf & "            height: '100%',")
        sw.Append(vbCrLf & "            stateful: stateFulSystem,")
        sw.Append(vbCrLf & "            stateId:'j_v_" & pv.the_Alias.ToLower() & "',")
        sw.Append(vbCrLf & "            layout: 'fit',")
        sw.Append(vbCrLf & "            flex: 1,")

        sw.Append(vbCrLf & "            store: store_v_" & pv.the_Alias.ToLower())
        sw.Append(vbCrLf & "    }] // tabpanel")
        sw.Append(vbCrLf & "    }); //Ext.Create")
        sw.Append(vbCrLf & "    return " & Jrnl.Name & ";")
        sw.Append(vbCrLf & "}")



        sw.Append(vbCrLf & "Ext.define('ObjectWindow_" & Jrnl.Name.ToLower() & "', {")
        sw.Append(vbCrLf & "    extend:  'Ext.window.Window',")
        sw.Append(vbCrLf & "    maxHeight: 620,")
        sw.Append(vbCrLf & "    minHeight: 620,")
        sw.Append(vbCrLf & "    minWidth: 800,")
        sw.Append(vbCrLf & "    maxWidth: 1024,")
        sw.Append(vbCrLf & "    constrainHeader :true,")
        sw.Append(vbCrLf & "    layout:  'fit',")
        sw.Append(vbCrLf & "    autoShow: true,")
        sw.Append(vbCrLf & "    closeAction: 'destroy',")
        sw.Append(vbCrLf & "    modal: true,")
        If p.jrnlIconCls <> "" Then
            sw.Append(vbCrLf & "    iconCls:  '" & p.jrnlIconCls & "',")
        Else
            sw.Append(vbCrLf & "    iconCls:  'icon-application_form',")
        End If
        sw.Append(vbCrLf & "    title:  '" & p.Name & "',")
        sw.Append(vbCrLf & "    items:[ ]")
        sw.Append(vbCrLf & "	});")


        Return sw.ToString()
    End Function


    'Private Function GenAlterbase(ByVal Jid As Guid) As String
    '    Dim JJJ As MTZJrnl.MTZJrnl.Application
    '    JJJ = Manager.GetInstanceObject(Jid)
    '    If JJJ Is Nothing Then
    '        MsgBox("Journal unknown " + Jid.ToString)
    '        Return ""
    '    End If


    '    Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW
    '    Dim prt As MTZMetaModel.MTZMetaModel.PART

    '    Dim p As MTZJrnl.MTZJrnl.Journal
    '    p = JJJ.Journal.Item(1)
    '    pv = model.FindRowObject("PartView", JJJ.JournalSrc.Item(1).PartView)

    '    If p Is Nothing Or pv Is Nothing Then
    '        Return ""
    '    End If

    '    prt = pv.Parent.Parent
    '    Dim sw As StringBuilder
    '    sw = New StringBuilder



    '    sw.Append(vbCrLf & "--drop store table " & pv.the_Alias.ToLower() & "")
    '    sw.Append(vbCrLf & "        drop table x_" & pv.the_Alias.ToLower() & "")
    '    sw.Append(vbCrLf & "                go")


    '    sw.Append(vbCrLf & "-- create store table")
    '    sw.Append(vbCrLf & "        select * into x_" & pv.the_Alias.ToLower() & " from v_" & pv.the_Alias.ToLower() & " ")

    '    sw.Append(vbCrLf & "-- drop trigger")
    '    sw.Append(vbCrLf & "        drop trigger " & prt.Name.ToLower() & "_trigger")
    '    sw.Append(vbCrLf & "        go")

    '    sw.Append(vbCrLf & "--create trigger")
    '    sw.Append(vbCrLf & "        create trigger " & prt.Name.ToLower() & "_trigger on dbo." & prt.Name.ToLower() & " after insert, update, delete")
    '    sw.Append(vbCrLf & "        as")
    '    sw.Append(vbCrLf & "        begin")
    '    sw.Append(vbCrLf & "        delete from x_" & pv.the_Alias.ToLower() & " where id in (select " & prt.Name.ToLower() & "id from deleted);")
    '    sw.Append(vbCrLf & "        insert into x_" & pv.the_Alias.ToLower() & " select * from v_" & pv.the_Alias.ToLower() & " where  id in (select " & prt.Name.ToLower() & "id from inserted);")
    '    sw.Append(vbCrLf & "        end;")
    '    sw.Append(vbCrLf & "        go")

    '    Return sw.ToString()

    'End Function

    Private Sub JournalMaker(ByVal Jid As Guid)
        Dim JJJ As MTZJrnl.MTZJrnl.Application
        JJJ = Manager.GetInstanceObject(Jid)
        If JJJ Is Nothing Then
            MsgBox("Journal unknown " + Jid.ToString)
            Exit Sub
        End If


        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim p As MTZJrnl.MTZJrnl.Journal
        p = JJJ.Journal.Item(1)
        If p Is Nothing Then
            MsgBox("Journal haz no header " + Jid.ToString)
            Exit Sub
        End If

        If JJJ.JournalSrc.Count = 0 Then
            MsgBox("Journal haz no sources " + Jid.ToString + " > " + p.Name)
            Exit Sub
        End If

        Dim va As String
        va = JJJ.JournalSrc.Item(1).ViewAlias
        Dim vrs As DataTable
        vrs = Manager.Session.GetData("select " + Manager.Session.GetProvider.ID2Base("partviewid") + " from partview where the_alias='" + va + "'")
        If vrs.Rows.Count = 0 Then Exit Sub
        pv = model.FindRowObject("PartView", New Guid(vrs.Rows(0)("partviewid").ToString))

        If p Is Nothing Or pv Is Nothing Then
            Return
        End If

        ' make journal PHP model
        Tool_WriteFile(JournalMake_PHPModel(JJJ), textBoxOutPutFolder.Text & "models\", "m_v_" & pv.the_Alias.ToLower() & ".php")

        ' make journal PHP controller
        Tool_WriteFile(JournalMake_PHPController(JJJ), textBoxOutPutFolder.Text & "controllers\", "c_v_" & pv.the_Alias.ToLower() & ".php")

        ' make journal JS model
        Tool_WriteFile(JournalMake_JSModel(JJJ) & vbCrLf & JournalMake_JSStore(JJJ), textBoxOutPutFolder.Text & "_js\", "s_v_" & pv.the_Alias.ToLower() & ".js")


        ' make journal grid
        Tool_WriteFile(JournalMake_JSGrid(JJJ), textBoxOutPutFolder.Text & "_js\", "j_v_" & pv.the_Alias.ToLower() & ".js")


        ' make jurnal filter ???


    End Sub

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        Dim i As Integer
        Dim ti As tmpInst
        Dim sw As StringBuilder

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        Dim om As MTZMetaModel.MTZMetaModel.OBJECTMODE


        pb.Minimum = 0
        pb.Maximum = model.OBJECTTYPE.Count
        pb.Value = 0
        pb.Visible = True

        Me.Text = "Generating stores"
        Application.DoEvents()
        sw = New StringBuilder
        'sw.Append(vbCrLf & Combo_Load())

        For i = 1 To model.OBJECTTYPE.Count
            ot = model.OBJECTTYPE.Item(i)
            sw.Append(PartMake_GenStores(ot.PART))
            pb.Value = i
            Application.DoEvents()
        Next
        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "_js\", "models.js")

        Me.Text = "Generating enums"
        Application.DoEvents()
        Tool_WriteFile(SysMake_enumStore, textBoxOutPutFolder.Text & "_js\", "enums.js")


        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = chkObjType.CheckedItems.Count
        Me.Text = "Generating types"
        Application.DoEvents()

        sw = New StringBuilder
        pb.Visible = True
        For i = 0 To chkObjType.CheckedItems.Count - 1
            pb.Value = i + 1
            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)


            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            Dim j As Integer
            For j = 1 To ot.OBJECTMODE.Count
                'If ot.OBJECTMODE.Item(j).TheComment = "martservice" Then
                '    TypeMaker(ti.ID, ot.OBJECTMODE.Item(j).Name, True)
                'Else
                TypeMaker(ti.ID, ot.OBJECTMODE.Item(j).Name, False)
                'End If

            Next
            TypeMaker(ti.ID, "", False)

            'If chkMartImport.Checked Then
            '    sw.Append(TypeMartImport(ot))
            'End If
        Next
        ti = Nothing
        'If sw.ToString <> "" Then
        '    Tool_WriteFile(sw.ToString, textBoxOutPutFolder.Text, "MartIpmort.php")
        'End If

        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = chkJournals.CheckedItems.Count
        Me.Text = "Generating journals"
        Application.DoEvents()
        pb.Visible = True
        For i = 0 To chkJournals.CheckedItems.Count - 1
            pb.Value = i + 1
            Application.DoEvents()
            ti = chkJournals.CheckedItems(i)
            JournalMaker(ti.ID)
        Next


        If chkMenu.Checked Then
            Me.Text = "Generating menus"
            Application.DoEvents()
            Tool_WriteFile(SysMake_Menu(), textBoxOutPutFolder.Text & "_js\", "menu.js")
        End If


        If chkInc.Checked Then
            Me.Text = "Generating include file"
            Application.DoEvents()
            Tool_WriteFile(SysMake_Include(), textBoxOutPutFolder.Text & "views\", "inc.php")
        End If

        MsgBox("Генерация кода завершена")
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        Dim i As Integer
        For i = 0 To chkObjType.Items.Count - 1
            chkObjType.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub cmdClearAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearAll.Click
        Dim i As Integer
        For i = 0 To chkObjType.Items.Count - 1
            chkObjType.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub cmdJSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdJSelectAll.Click
        Dim i As Integer
        For i = 0 To chkJournals.Items.Count - 1
            chkJournals.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub cmdJClearAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdJClearAll.Click
        Dim i As Integer
        For i = 0 To chkJournals.Items.Count - 1
            chkJournals.SetItemChecked(i, False)
        Next
    End Sub

   
    Private Sub chkObjType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles chkObjType.SelectedIndexChanged

    End Sub

    Private Sub chkJournals_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles chkJournals.SelectedIndexChanged

    End Sub
End Class