Imports System.IO
Imports System.Text


Public Class ExtJSMaker

    Private basepath As String = "index.php/"
    Private Sub ExtJSMaker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer
        Dim ti As tmpInst
        For i = 1 To model.OBJECTTYPE.Count
            ti = New tmpInst()
            ti.ID = model.OBJECTTYPE.Item(i).ID
            ti.Name = model.OBJECTTYPE.Item(i).the_Comment
            ti.ObjType = model.OBJECTTYPE.Item(i).Name
            chkObjType.Items.Add(ti, False)
        Next

        Dim dt As DataTable
        dt = Manager.Session.GetData("select * from instance where objtype ='mtzjrnl'")
        For i = 0 To dt.Rows.Count - 1
            ti = New tmpInst()
            ti.ID = dt.Rows(i)("instanceid")
            ti.Name = dt.Rows(i)("name")
            ti.ObjType = ""
            chkJournals.Items.Add(ti, False)
        Next

    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        folderBrowserDialogProjectOutput.SelectedPath = textBoxOutPutFolder.Text
        folderBrowserDialogProjectOutput.ShowDialog()
        textBoxOutPutFolder.Text = folderBrowserDialogProjectOutput.SelectedPath
        If Not textBoxOutPutFolder.Text.EndsWith("\") Then
            textBoxOutPutFolder.Text += "\"
        End If
    End Sub



    Private Function MakeMenu() As String
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
            ti = chkJournals.CheckedItems(i)

            JJJ = Manager.GetInstanceObject(Ti.id)
            If Not JJJ Is Nothing Then

                p = JJJ.Journal.Item(1)
                pv = model.FindRowObject("PartView", JJJ.JournalSrc.Item(1).PartView)

                If Not p Is Nothing Then


                    sw.Append(vbCrLf & "      var action" & JJJ.Name & " = Ext.create('Ext.Action', {")
                    sw.Append(vbCrLf & "     text:           '" & p.Name & "',")
                    sw.Append(vbCrLf & "     iconCls:        'icon-application_view_list',")
                    sw.Append(vbCrLf & "             handler: function(){")
                    sw.Append(vbCrLf & "                 cPanel.add(" & JJJ.Name & "_Jrnl());")
                    sw.Append(vbCrLf & "             }")
                    sw.Append(vbCrLf & "         });")

                End If
            End If

        Next
        Return sw.ToString()
    End Function


    Private Sub GenType(ByVal ID As Guid)

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim P As MTZMetaModel.MTZMetaModel.PART
        ot = model.OBJECTTYPE.Item(ID.ToString())

        Dim i As Integer
        Dim sw As StringBuilder
        sw = New StringBuilder


        sw.Append(vbCrLf & "Ext.require([")
        sw.Append(vbCrLf & "'Ext.form.*'")
        sw.Append(vbCrLf & "]);")

        Dim xout As String
        ot.PART.Sort = "sequence"
        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            sw.Append(vbCrLf & MakePartGridJS(ot, P))
            sw.Append(vbCrLf & MakeFormPanelJS(ot, P))

            xout = MakeCIModel(P)
            MakeProjectFile(xout, textBoxOutPutFolder.Text & "models\", "m_" & P.Name.ToLower() & ".php")
            xout = MakeCIController(P)
            MakeProjectFile(xout, textBoxOutPutFolder.Text & "controllers\", "c_" & P.Name.ToLower() & ".php")

        Next
        sw.Append(vbCrLf & "  " & ot.Name & "= null;")
        sw.Append(vbCrLf & "function " & ot.Name & "_Panel(objectID,   RootPanel){ " & vbCrLf)


        '  добавляем комбобох для выбора вкладки
        If ot.PART.Count > 10 Then

            sw.Append(vbCrLf & "	var store_" + ot.Name.ToLower + "_parts = Ext.create('Ext.data.ArrayStore', {")
            sw.Append(vbCrLf & "fields: ['name','tabname'		],")
            sw.Append(vbCrLf & "data : [")

            For i = 1 To ot.PART.Count
                P = ot.PART.Item(i)
                If i > 1 Then
                    sw.Append(vbCrLf & ",")
                End If
                sw.Append(vbCrLf & "	['" + P.Caption + "', 'tab_" + P.Name.ToLower() + "']")
            Next

            sw.Append(vbCrLf & "]")
            sw.Append(vbCrLf & "});")
        End If



        sw.Append(vbCrLf & "     " & ot.Name & "= Ext.create('Ext.form.Panel', {")
        'sw.Append(vbCrLf & "       bodyStyle:'padding:5px',")
        sw.Append(vbCrLf & "      width: 640,")
        sw.Append(vbCrLf & "      fieldDefaults: {")
        sw.Append(vbCrLf & "         labelAlign:             'top',")
        sw.Append(vbCrLf & "          msgTarget:             'side'")
        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "        defaults: {")
        sw.Append(vbCrLf & "        anchor:'100%'")
        sw.Append(vbCrLf & "        },")
        sw.Append(vbCrLf & "")

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
            sw.Append(vbCrLf & "								var tabpanel=B2D.getComponent('tabs_" + ot.Name.ToLower() + "');")
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
        sw.Append(vbCrLf & "            height:580,")
        sw.Append(vbCrLf & "            tabPosition:'bottom',")
        'sw.Append(vbCrLf & "            defaults:{bodyStyle:'padding:10px'},")
        sw.Append(vbCrLf & "            items:[   // tabs")

        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            If i > 1 Then
                sw.Append(vbCrLf & ",")
            End If
            sw.Append(vbCrLf & "            { // begin part tab")
            sw.Append(vbCrLf & "            xtype:'panel',")
            sw.Append(vbCrLf & "            title: '" & P.Caption & "',")
            sw.Append(vbCrLf & "            itemId:'tab_" & P.Name.ToLower() & "',")
            sw.Append(vbCrLf & "            items:[ // panel on tab ")


            If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                sw.Append(vbCrLf & "{")
                sw.Append(vbCrLf & "            itemId:'frm_" & P.Name.ToLower() & "',")
                sw.Append(vbCrLf & "            xtype:'f_" & P.Name.ToLower() & "',")
                sw.Append(vbCrLf & "            autoScroll:true,")
                sw.Append(vbCrLf & "            height: 550,")
                sw.Append(vbCrLf & "            margins:'0 0 10 0'")
                sw.Append(vbCrLf & "} ")
            Else
                sw.Append(vbCrLf & "{")
                sw.Append(vbCrLf & "            itemId:'gr_" & P.Name.ToLower() & "',")
                sw.Append(vbCrLf & "            xtype:'g_" & P.Name.ToLower() & "',")
                sw.Append(vbCrLf & "            title:'" & P.Caption & "',")
                sw.Append(vbCrLf & "            height: 550,")
                sw.Append(vbCrLf & "            flex: 1,")
                sw.Append(vbCrLf & "            store: store_" & P.Name.ToLower())
                sw.Append(vbCrLf & "}")
            End If

            sw.Append(vbCrLf & "        ] // panel on tab  form or grid")

            sw.Append(vbCrLf & "      } // end tab")
        Next

        sw.Append(vbCrLf & "    ] // bottom tabs")

        '' plugin !!!
        'sw.Append(vbCrLf & "   ,plugins: [{")
        'sw.Append(vbCrLf & "   ptype:  'tabscrollermenu',")
        'sw.Append(vbCrLf & "   maxText  : 60,")
        'sw.Append(vbCrLf & "   pageSize : 10")
        'sw.Append(vbCrLf & "   }]")

        sw.Append(vbCrLf & "    }] // tabpanel")
        sw.Append(vbCrLf & "    }); //Ext.Create")

        sw.Append(vbCrLf & "    if(RootPanel==true){")
        sw.Append(vbCrLf & "       " & ot.Name & ".closable= true;")
        sw.Append(vbCrLf & "       " & ot.Name & ".title= '" & ot.the_Comment & "';")
        sw.Append(vbCrLf & "    }else{")
        sw.Append(vbCrLf & "       " & ot.Name & ".closable= false;")
        sw.Append(vbCrLf & "       " & ot.Name & ".title= '';")
        sw.Append(vbCrLf & "       " & ot.Name & ".frame= false;")


        sw.Append(vbCrLf & "    }")

        '''' load data to store
        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)

            If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                sw.Append(vbCrLf & "   store_" & P.Name.ToLower() & ".on('load', function() {")

                sw.Append(vbCrLf & "        if(store_" & P.Name.ToLower() & ".count()==0){")
                sw.Append(vbCrLf & "            store_" & P.Name.ToLower() & ".insert(0, new model_" & P.Name.ToLower() & "());")
                sw.Append(vbCrLf & "        }")
                sw.Append(vbCrLf & "        record= store_" & P.Name.ToLower() & ".getAt(0);")
                sw.Append(vbCrLf & "        record['instanceid']=objectID;")


                sw.Append(vbCrLf & "   " & ot.Name & ".getComponent('tabs_" & ot.Name.ToLower() & "').getComponent('tab_" & P.Name.ToLower() & "').getComponent('frm_" & P.Name.ToLower() & "').setActiveRecord(record,objectID);	")
                sw.Append(vbCrLf & "   });")
            Else
                sw.Append(vbCrLf & "   " & ot.Name & ".getComponent('tabs_" & ot.Name.ToLower() & "').getComponent('tab_" & P.Name.ToLower() & "').getComponent('gr_" & P.Name.ToLower() & "').instanceid=objectID;	")
            End If

            sw.Append(vbCrLf & "       store_" & P.Name.ToLower() & ".load( {params:{ instanceid:objectID} });")
        Next

        sw.Append(vbCrLf & "    return " & ot.Name & ";")
        sw.Append(vbCrLf & "}")

        MakeProjectFile(sw.ToString(), textBoxOutPutFolder.Text & "_js\", ot.Name.ToLower() & ".js")


    End Sub

    Private Sub MakeProjectFile(ByVal s As String, ByVal path As String, ByVal fname As String)
        Dim p As String
        p = path
        If Not p.EndsWith("\") Then
            p += "\"
        End If
        File.WriteAllText(p & fname, s, System.Text.Encoding.UTF8)
    End Sub

    Private Function enumStore() As String
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


   

    Private Function Model_And_Store(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Dim i As Integer




        sw.Append(vbCrLf & " Ext.define('model_" & P.Name.ToLower() & "',{")
        sw.Append(vbCrLf & "            extend:'Ext.data.Model',")
        sw.Append(vbCrLf & "        fields: [")
        sw.Append(vbCrLf & "            {name: '" & P.Name.ToLower() & "id',type: 'string'}")
        sw.Append(vbCrLf & "            ,{name: 'instanceid',type: 'string'}")
        sw.Append(vbCrLf & "            ,{name: 'brief',type: 'string'}")
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                If ft.Name.ToLower = "file" Then
                    sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'string'}")
                    sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "_ext', type: 'string'}")
                Else
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'string'}")

                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'date'}")

                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                        sw.Append(vbCrLf & "            ,{name:'" & fld.Name.ToLower() & "', type: 'number'}")

                    End If
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

        sw.Append(vbCrLf & "    var store_" & P.Name.ToLower() & " = Ext.create('Ext.data.Store', {")
        sw.Append(vbCrLf & "        model:'model_" & P.Name.ToLower() & "',")
        sw.Append(vbCrLf & "        autoLoad: false,")
        sw.Append(vbCrLf & "        autoSync: false,")
        sw.Append(vbCrLf & "        proxy: {")
        sw.Append(vbCrLf & "            type:   'ajax',")
        sw.Append(vbCrLf & "                url:   '" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
        'sw.Append(vbCrLf & "            api: {")
        'sw.Append(vbCrLf & "                read:   '" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
        'sw.Append(vbCrLf & "                create:  '" & basepath & "c_" & P.Name.ToLower() & "/newRow',")
        'sw.Append(vbCrLf & "                update:  '" & basepath & "c_" & P.Name.ToLower() & "/setRow',")
        'sw.Append(vbCrLf & "                destroy:  '" & basepath & "c_" & P.Name.ToLower() & "/deleteRow'")
        'sw.Append(vbCrLf & "            },")
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




    Private Function Combo_Store(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim dt As DataTable
        dt = Manager.Session.GetData("select count(*) as cnt from field where reftopart='" & P.ID.ToString() & "'")
        If dt.Rows(0)("cnt") > 0 Then

            sw.Append(vbCrLf & " Ext.define('cmbmodel_" & P.Name.ToLower() & "',{")
            sw.Append(vbCrLf & "            extend:'Ext.data.Model',")
            sw.Append(vbCrLf & "        fields: [")
            sw.Append(vbCrLf & "            {name: '" & P.Name.ToLower() & "id',type: 'string'}")
            sw.Append(vbCrLf & "            ,{name: 'brief',type: 'string'}")
            sw.Append(vbCrLf & "        ]")
            sw.Append(vbCrLf & "    });")

            sw.Append(vbCrLf & "    var cmbstore_" & P.Name.ToLower() & " = Ext.create('Ext.data.Store', {")
            sw.Append(vbCrLf & "        model:'cmbmodel_" & P.Name.ToLower() & "',")
            sw.Append(vbCrLf & "        autoLoad: false,")
            sw.Append(vbCrLf & "        autoSync: false,")
            sw.Append(vbCrLf & "        proxy: {")
            sw.Append(vbCrLf & "            type:   'ajax',")
            sw.Append(vbCrLf & "                url:   '" & basepath & "c_" & P.Name.ToLower() & "/getRows',")
            sw.Append(vbCrLf & "            reader: {")
            sw.Append(vbCrLf & "                type:   'json'")
            sw.Append(vbCrLf & "                ,root:  'data'")
            sw.Append(vbCrLf & "                ,successProperty:  'success'")
            sw.Append(vbCrLf & "                ,messageProperty:  'msg'")
            sw.Append(vbCrLf & "            }")
            sw.Append(vbCrLf & "        },")
            sw.Append(vbCrLf & "       listeners: {")
            sw.Append(vbCrLf & "       'load': function(){combo_StoreLoaded =true;},")
            sw.Append(vbCrLf & "       }")
            sw.Append(vbCrLf & "    });")
            sw.Append(vbCrLf & "    combo_Stores.push(cmbstore_" & P.Name.ToLower() & ");")
        End If

        Return sw.ToString()

    End Function


    'Private Function Combo_Load() As String
    '    Dim sw As StringBuilder
    '    sw = New StringBuilder()
    '    sw.Append(vbCrLf & "    var combo_timeout_id=null;")
    '    sw.Append(vbCrLf & "    var combo_StoreLoaded=false;")
    '    sw.Append(vbCrLf & "    var combo_Waiter=0;")
    '    sw.Append(vbCrLf & "    var combo_Index=0;")
    '    sw.Append(vbCrLf & "    var combo_Stores=new Array();")

    '    sw.Append(vbCrLf & "    function combo_LoadAll() {")
    '    sw.Append(vbCrLf & "        combo_Index=0;")
    '    sw.Append(vbCrLf & "        combo_Waiter=0;")
    '    sw.Append(vbCrLf & "        combo_StoreLoaded=false;")
    '    sw.Append(vbCrLf & "        combo_Stores[combo_Index].load();")
    '    sw.Append(vbCrLf & "        combo_timeout_id= setTimeout(combo_wait, 100);")
    '    sw.Append(vbCrLf & "   }")
    '    sw.Append(vbCrLf & "    function combo_LoadNext() {")
    '    sw.Append(vbCrLf & "            if(combo_Index<combo_Stores.length){")
    '    sw.Append(vbCrLf & "              combo_Index=+1;")
    '    sw.Append(vbCrLf & "              combo_Waiter=0;")
    '    sw.Append(vbCrLf & "              combo_StoreLoaded=false;")
    '    sw.Append(vbCrLf & "              combo_Stores[combo_Index].load();")
    '    sw.Append(vbCrLf & "              combo_timeout_id= setTimeout(combo_wait, 100);")
    '    sw.Append(vbCrLf & "           } ")
    '    sw.Append(vbCrLf & "   }")

    '    sw.Append(vbCrLf & "    function combo_wait() {")
    '    sw.Append(vbCrLf & "      if(combo_StoreLoaded){ ")
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
   


    Private Function MakePartXML(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        Dim sout As String = ""
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim i As Integer, j As Integer
        Dim rs As DataTable

        sout = "<?xml version=""1.0"" encoding=""UTF-8""?><rows>"
        rs = Manager.Session.GetData("select * from " & P.Name.ToLower())

        For i = 0 To rs.Rows.Count - 1

            sout = sout & vbCrLf & "<row>"
            sout = sout & vbCrLf & "<ID>" & rs.Rows(i)(P.Name & "ID").ToString() & "</ID>"

            For j = 1 To P.FIELD.Count
                fld = P.FIELD.Item(j)

                sout = sout & vbCrLf & "<" & fld.Name.ToLower() & ">" & rs.Rows(i)(fld.Name).ToString() & "</" & fld.Name.ToLower() & ">"

            Next
            sout = sout & vbCrLf & "</row>"
        Next

        sout = sout & vbCrLf & "</rows>"
        MakePartXML = sout
    End Function

    Private Function MakeCIModel(ByVal p As MTZMetaModel.MTZMetaModel.PART) As String
        Dim sw As StringBuilder
        sw = New StringBuilder
        Dim j As Integer
        Dim i As Integer
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim flist As String = p.Name.ToLower() & "id,instanceid"
        flist = flist & "," & "dbo." & p.Name & "_BRIEF_F(B2G(" & p.Name.ToLower() & "id) , NULL) AS brief"


        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    flist = flist & "," & fld.Name.ToLower()
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    flist = flist & ",convert(varchar(50)," & fld.Name.ToLower() & ",126) " & fld.Name.ToLower()
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    flist = flist & "," & fld.Name.ToLower()
                End If
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
                flist = flist & "," & fld.Name.ToLower()
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                flist = flist & "," & fld.Name.ToLower()

                flist = flist & "," & " case " & fld.Name.ToLower() & vbCrLf
                For i = 1 To ft.ENUMITEM.Count
                    flist = flist & vbCrLf & " when " & ft.ENUMITEM.Item(i).NameValue.ToString() & " then \'" & ft.ENUMITEM.Item(i).Name & "\'"
                Next
                flist = flist & vbCrLf & "End"
                flist = flist & " as " & fld.Name.ToLower() & "_grid"

            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                flist = flist & "," & fld.Name.ToLower()

                If ft.Name.ToLower() = "multiref" Then
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        flist = flist & "," & "dbo." & fld.RefToPart.PartName & "_MREF_F(" & fld.Name.ToLower() & ", NULL)"
                        flist = flist & " as " & fld.Name.ToLower() & "_grid"
                    End If
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        flist = flist & "," & "dbo.INSTANCE_MREF_F(" & fld.Name.ToLower() & ", NULL)"
                        flist = flist & " as " & fld.Name.ToLower() & "_grid"
                    End If
                Else
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        flist = flist & "," & "dbo." & fld.RefToPart.PartName & "_BRIEF_F(B2G(" & fld.Name.ToLower() & "), NULL)"
                        flist = flist & " as " & fld.Name.ToLower() & "_grid"
                    End If
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        flist = flist & "," & "dbo.INSTANCE_BRIEF_F(B2G(" & fld.Name.ToLower() & "), NULL)"
                        flist = flist & " as " & fld.Name.ToLower() & "_grid"
                    End If
                End If



            End If


        Next


        sw.Append(vbCrLf & "<?php")

        sw.Append(vbCrLf & "class  M_" & p.Name.ToLower() & " extends CI_Model {")
        sw.Append(vbCrLf & "    public function  __construct()")
        sw.Append(vbCrLf & "    {")
        sw.Append(vbCrLf & "         parent::__construct();")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function getRow($empId) {")
        sw.Append(vbCrLf & "        if ($empId) {")
        sw.Append(vbCrLf & "            $rows = $this->db->query(' select * from " & p.Name.ToLower() & " where " & p.Name.ToLower() & "id=\''.$empId.'\'')->result();")
        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $rows[0];")
        'sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "->success = true;")
        sw.Append(vbCrLf & "            return $" & p.Name.ToLower() & ";")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "            $return= array('success' => FALSE, 'msg' => 'No Row ID for retrive data');")
        sw.Append(vbCrLf & "			return $return;")
        sw.Append(vbCrLf & "	    }")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function setRow($data)  {")
        sw.Append(vbCrLf & "        if ($data) {")
        sw.Append(vbCrLf & "            if (is_object($data)) {")
        'sw.Append(vbCrLf & "                foreach($data as $key => $value) {")
        'sw.Append(vbCrLf & "            	    if($value=='')  $value=null;")
        'sw.Append(vbCrLf & "                }")
        'sw.Append(vbCrLf & "                log_message('debug', '" & p.Name & ".model.setRow : '.json_encode($data));")
        'sw.Append(vbCrLf & "                $this->db->set($data);")
        'sw.Append(vbCrLf & "                $this->db->where('" & p.Name.ToLower() & "id', $data->" & p.Name.ToLower() & "id);")
        'sw.Append(vbCrLf & "                $this->db->update('" & p.Name.ToLower() & "');")






        sw.Append("$q= 'update  " & p.Name & " set ChangeStamp=GetDate()';")

        sw.Append(vbCrLf & "if( property_exists($data,'instanceid')){")
        sw.Append(vbCrLf & " if( $data->instanceid!=NULL){")
        sw.Append(vbCrLf & "  if( $data->instanceid!=''){")
        sw.Append(vbCrLf & "    $q=$q.',instanceid=\''.$data->instanceid.'\'';")
        sw.Append(vbCrLf & "  }}}")

        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then

                    sw.Append(vbCrLf & "if( property_exists($data,'" & fld.Name.ToLower() & "')){")
                    sw.Append(vbCrLf & "  if( $data->" & fld.Name.ToLower() & "!=NULL){")
                    sw.Append(vbCrLf & "     $q=$q.'," & fld.Name.ToLower() & "=\''.$data->" & fld.Name.ToLower() & ".'\'';")
                    sw.Append(vbCrLf & "    }else{")
                    sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=NULL';")
                    sw.Append(vbCrLf & "  }}")
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    sw.Append(vbCrLf & "if( property_exists($data,'" & fld.Name.ToLower() & "')){")
                    sw.Append(vbCrLf & " if( $data->" & fld.Name.ToLower() & "!=NULL){")
                    sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=convert(datetime,\''.$data->" & fld.Name.ToLower() & ".'\',126)';")
                    sw.Append(vbCrLf & "    }else{")
                    sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=NULL';")
                    sw.Append(vbCrLf & "  }}")
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    sw.Append(vbCrLf & "if( property_exists($data,'" & fld.Name.ToLower() & "')){")
                    sw.Append(vbCrLf & " if( $data->" & fld.Name.ToLower() & "!=NULL){")
                    sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "='.$data->" & fld.Name.ToLower() & ";")
                    sw.Append(vbCrLf & "  }}")
                End If
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
                sw.Append(vbCrLf & "if( property_exists($data,'" & fld.Name.ToLower() & "')){")
                sw.Append(vbCrLf & " if( $data->" & fld.Name.ToLower() & "!=NULL){")
                sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "='.$data->" & fld.Name.ToLower() & ";")
                sw.Append(vbCrLf & "  }}")
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                sw.Append(vbCrLf & "if( property_exists($data,'" & fld.Name.ToLower() & "')){")
                sw.Append(vbCrLf & " if( $data->" & fld.Name.ToLower() & "!=NULL){")
                sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "='.$data->" & fld.Name.ToLower() & ";")
                sw.Append(vbCrLf & "  }}")


            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                sw.Append(vbCrLf & "if( property_exists($data,'" & fld.Name.ToLower() & "')){")
                sw.Append(vbCrLf & " if( $data->" & fld.Name.ToLower() & "!=NULL){")
                sw.Append(vbCrLf & "  if( $data->" & fld.Name.ToLower() & "!=''){")
                sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=\''.$data->" & fld.Name.ToLower() & ".'\'';")
                sw.Append(vbCrLf & "    }else{")
                sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=NULL';")
                sw.Append(vbCrLf & "  }}}")

            End If


        Next

        sw.Append(vbCrLf & "                $q=$q.' where  " & p.Name & "ID = \''.$data->" & p.Name.ToLower() & "id.'\'';")
        sw.Append(vbCrLf & "                $this->db->query($q);")
        sw.Append(vbCrLf & "                return $this->getRow($data->id);")
        sw.Append(vbCrLf & "            }")
        sw.Append(vbCrLf & "            else if (isset($data['" & p.Name.ToLower() & "id']) ) {")
        sw.Append(vbCrLf & "                if ($data['" & p.Name.ToLower() & "id']=='' ) {")
        sw.Append(vbCrLf & "                    $rows=$this->db->query('select top 1 newid() as id from sysobjects')->result();")
        sw.Append(vbCrLf & "                    $row=$rows[0];")
        sw.Append(vbCrLf & "                    $id = $row->id;")
        sw.Append(vbCrLf & "                    $data['" & p.Name.ToLower() & "id']=$id;")
        sw.Append(vbCrLf & "                    $this->db->query('insert into " & p.Name.ToLower() & "(" & p.Name.ToLower() & "id) values(\''.$id.'\')');")
        sw.Append(vbCrLf & "                }")


        sw.Append("$q= 'update  " & p.Name & " set ChangeStamp=GetDate()';")

        sw.Append(vbCrLf & "if( array_key_exists('instanceid',$data)){")
        sw.Append(vbCrLf & " if( $data['instanceid']!=NULL){")
        sw.Append(vbCrLf & "  if( $data['instanceid']!=''){")
        sw.Append(vbCrLf & "    $q=$q.',instanceid=\''.$data['instanceid'].'\'';")
        sw.Append(vbCrLf & "  }}}")

        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    '
                    sw.Append(vbCrLf & "if( array_key_exists('" & fld.Name.ToLower() & "',$data)){")
                    sw.Append(vbCrLf & "  if( $data['" & fld.Name.ToLower() & "']!=NULL){")
                    sw.Append(vbCrLf & "     $q=$q.'," & fld.Name.ToLower() & "=\''.$data['" & fld.Name.ToLower() & "'].'\'';")
                    sw.Append(vbCrLf & "    }else{")
                    sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=NULL';")
                    sw.Append(vbCrLf & "  }}")
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    sw.Append(vbCrLf & "if( array_key_exists('" & fld.Name.ToLower() & "',$data)){")
                    sw.Append(vbCrLf & " if( $data['" & fld.Name.ToLower() & "']!=NULL){")
                    sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=convert(datetime,\''.$data['" & fld.Name.ToLower() & "'].'\',126)';")
                    sw.Append(vbCrLf & "    }else{")
                    sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=NULL';")
                    sw.Append(vbCrLf & "  }}")
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    sw.Append(vbCrLf & "if( array_key_exists('" & fld.Name.ToLower() & "',$data)){")
                    sw.Append(vbCrLf & " if( $data['" & fld.Name.ToLower() & "']!=NULL){")
                    sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "='.$data['" & fld.Name.ToLower() & "'];")
                    sw.Append(vbCrLf & "  }}")
                End If
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
                sw.Append(vbCrLf & "if( array_key_exists('" & fld.Name.ToLower() & "',$data)){")
                sw.Append(vbCrLf & " if( $data['" & fld.Name.ToLower() & "']!=NULL){")
                sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "='.$data['" & fld.Name.ToLower() & "'];")
                sw.Append(vbCrLf & "  }}")
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                sw.Append(vbCrLf & "if( array_key_exists('" & fld.Name.ToLower() & "',$data)){")
                sw.Append(vbCrLf & " if( $data['" & fld.Name.ToLower() & "']!=NULL){")
                sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "='.$data['" & fld.Name.ToLower() & "'];")
                sw.Append(vbCrLf & "  }}")


            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                sw.Append(vbCrLf & "if( array_key_exists('" & fld.Name.ToLower() & "',$data)){")
                sw.Append(vbCrLf & " if( $data['" & fld.Name.ToLower() & "']!=NULL){")
                sw.Append(vbCrLf & "  if( $data['" & fld.Name.ToLower() & "']!=''){")
                sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=\''.$data['" & fld.Name.ToLower() & "'].'\'';")
                sw.Append(vbCrLf & "    }else{")
                sw.Append(vbCrLf & "    $q=$q.'," & fld.Name.ToLower() & "=NULL';")
                sw.Append(vbCrLf & "  }}}")

            End If


        Next



        'sw.Append(vbCrLf & "                foreach($data as $value) {")
        'sw.Append(vbCrLf & "            	    if($value=='')  $value=null;")
        'sw.Append(vbCrLf & "                }")
        'sw.Append(vbCrLf & "                log_message('debug', '" & p.Name & ".model.setRow : '.json_encode($data));")
        'sw.Append(vbCrLf & "                $this->db->set($data);")
        'sw.Append(vbCrLf & "                $this->db->where('" & p.Name.ToLower() & "id', $data['" & p.Name.ToLower() & "id']);")
        'sw.Append(vbCrLf & "                $this->db->update('" & p.Name.ToLower() & "');")
        sw.Append(vbCrLf & "                $q=$q.' where  " & p.Name & "ID = \''.$data['" & p.Name.ToLower() & "id'].'\'';")
        sw.Append(vbCrLf & "                log_message('debug', '" & p.Name & ".model.setRow : '.$q);")
        sw.Append(vbCrLf & "                $this->db->query($q);")
        sw.Append(vbCrLf & "                return $this->getRow($data['" & p.Name.ToLower() & "id']);")
        sw.Append(vbCrLf & "            }")

        sw.Append(vbCrLf & "       } else {")
        sw.Append(vbCrLf & "          $return= array('success'=>FALSE, 'msg' => 'No data to store on server');")
        sw.Append(vbCrLf & "		  return $return;")
        sw.Append(vbCrLf & "       }")

        sw.Append(vbCrLf & "    }")


        sw.Append(vbCrLf & "    function newRow($instanceid)  {")
        sw.Append(vbCrLf & "                $rows=$this->db->query('select top 1 newid() as id from sysobjects')->result();")
        sw.Append(vbCrLf & "                $row=$rows[0];")
        sw.Append(vbCrLf & "                $id = $row->id;")
        sw.Append(vbCrLf & "                $this->db->set(array('" & p.Name.ToLower() & "id'=>$id,'instanceid'=>$instanceid));")
        sw.Append(vbCrLf & "                $this->db->insert('" & p.Name.ToLower() & "');")
        sw.Append(vbCrLf & "                if ($id) {")
        sw.Append(vbCrLf & "                    return array('success'=>TRUE, 'data' => $id);")
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "                else {")
        sw.Append(vbCrLf & "                    $return= array('success'=>FALSE, 'msg' => 'Error while create new id');")
        sw.Append(vbCrLf & "				    return $return;")
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "    }")


        sw.Append(vbCrLf & "    function getRows()")
        sw.Append(vbCrLf & "		{")
        sw.Append(vbCrLf & "            $query = $this->db->query(' select  top 500 " & flist & " from " & p.Name.ToLower() & "');")
        sw.Append(vbCrLf & "			if ($query->num_rows() == 0)")
        sw.Append(vbCrLf & "			{")
        sw.Append(vbCrLf & "                 $return= array('success'=>FALSE, 'msg' => 'No data found');")
        sw.Append(vbCrLf & "				return $return;")
        sw.Append(vbCrLf & "			}else{")
        sw.Append(vbCrLf & "				return $query->result();")
        sw.Append(vbCrLf & "			}")
        sw.Append(vbCrLf & "		}")

        sw.Append(vbCrLf & "    function getRowsByInstance($id)")
        sw.Append(vbCrLf & "		{")
        sw.Append(vbCrLf & "            $query = $this->db->query(' select top 100 " & flist & " from " & p.Name.ToLower() & " where instanceid=\''.$id.'\'');")
        sw.Append(vbCrLf & "			if ($query->num_rows() == 0)")
        sw.Append(vbCrLf & "			{")
        sw.Append(vbCrLf & "                $return= array('success'=>FALSE, 'msg' => 'No data found');")
        sw.Append(vbCrLf & "				return $return;")
        sw.Append(vbCrLf & "			}else{")
        sw.Append(vbCrLf & "				return $query->result();")
        sw.Append(vbCrLf & "			}")
        sw.Append(vbCrLf & "		}")

        sw.Append(vbCrLf & "    function getRowsByParent($id)")
        sw.Append(vbCrLf & "		{")
        sw.Append(vbCrLf & "            $query = $this->db->query(' select top 100 " & flist & " from " & p.Name.ToLower() & " where parentstructrowid=\''.$id.'\'');")
        sw.Append(vbCrLf & "			if ($query->num_rows() == 0)")
        sw.Append(vbCrLf & "			{")
        sw.Append(vbCrLf & "                    $return= array('success'=>FALSE, 'msg' => 'No data found');")
        sw.Append(vbCrLf & "				return $return;")
        sw.Append(vbCrLf & "			}else{")
        sw.Append(vbCrLf & "				return $query->result();")
        sw.Append(vbCrLf & "			}")
        sw.Append(vbCrLf & "		}")


        sw.Append(vbCrLf & "    function deleteRow($id = null) {")
        sw.Append(vbCrLf & "        if ($id) {")
        sw.Append(vbCrLf & "          $this->db->where('" & p.Name.ToLower() & "id', $id);")
        sw.Append(vbCrLf & "          $this->db->delete('" & p.Name.ToLower() & "');")
        sw.Append(vbCrLf & "          $return=array('success'=>TRUE);")
        sw.Append(vbCrLf & "		  return $return;")
        sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "          $return= array('success'=>FALSE, 'msg' => 'No ID for delete');")
        sw.Append(vbCrLf & "		  return $return;")
        sw.Append(vbCrLf & "	    }")

        sw.Append(vbCrLf & "    }")






        sw.Append(vbCrLf & "}")
        sw.Append(vbCrLf & "?>")




        Return sw.ToString()
    End Function


    Private Function MakeCIController(ByVal p As MTZMetaModel.MTZMetaModel.PART) As String
        Dim sw As StringBuilder
        sw = New StringBuilder



        sw.Append(vbCrLf & "    <?php")
        sw.Append(vbCrLf & "	 class C_" & p.Name.ToLower() & " extends CI_Controller {")

        sw.Append(vbCrLf & "    function __construct() {")
        sw.Append(vbCrLf & "         parent::__construct();")
        sw.Append(vbCrLf & "        $this->_loadModels();")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function getRow() {")
        sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRow post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "        $empId  =  $this->input->get_post('id', TRUE);")
        sw.Append(vbCrLf & "        if (isset($empId)) {")
        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $this->m_" & p.Name.ToLower() & "->getRow($empId);")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => true,")
        sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower())
        sw.Append(vbCrLf & "            );")
        sw.Append(vbCrLf & "            print json_encode($return);")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    }")


        sw.Append(vbCrLf & "    function setRow() {")
        sw.Append(vbCrLf & "          log_message('debug', '" & p.Name & ".setRow post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "          log_message('debug', '" & p.Name & ".getRows get : '.json_encode($this->input->get(NULL, FALSE)));")
        'sw.Append(vbCrLf & "          $row =  $this->input->get_post('postdata', TRUE);")
        'sw.Append(vbCrLf & "          $field = explode(';', $row);")
        sw.Append(vbCrLf & "          $data = array(")
        sw.Append(vbCrLf & "                '" & p.Name.ToLower() & "id' =>  $this->input->get_post('" & p.Name.ToLower() & "id', TRUE)")
        sw.Append(vbCrLf & "                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)")
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim j As Integer
        p.FIELD.Sort = "sequence"
        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            'sw.Append(vbCrLf & ",'" & fld.Name.ToLower() & "' =>  $field[" & j.ToString() & "]")
            sw.Append(vbCrLf & ",'" & fld.Name.ToLower() & "' =>   $this->input->get_post('" & fld.Name.ToLower() & "', TRUE)")
        Next

        sw.Append(vbCrLf & "            );")
        'sw.Append(vbCrLf & "            log_message('debug', 'setRow params : '.json_encode($data));")

        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & " = $this->m_" & p.Name.ToLower() & "->setRow($data);")

        'sw.Append(vbCrLf & "            $return = array(")
        'sw.Append(vbCrLf & "                'success' => (isset($" & p.Name.ToLower() & ")) ? TRUE : FALSE,")
        'sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
        'sw.Append(vbCrLf & "            );")
        'sw.Append(vbCrLf & "            log_message('debug', 'setRow return : '.json_encode($return));")
        sw.Append(vbCrLf & "            print json_encode($" & p.Name.ToLower() & ");")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function newRow() {")
        sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".newRow post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "            $instanceid=$this->input->post('instanceid', FALSE);")
        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->newRow($instanceid);")
        sw.Append(vbCrLf & "            $return = $" & p.Name.ToLower() & ";")
        sw.Append(vbCrLf & "            print json_encode($return);")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function getRows() {")
        sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".getRows post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "            log_message('debug', '" & p.Name & ".getRows get : '.json_encode($this->input->get(NULL, FALSE)));")
        sw.Append(vbCrLf & "            $instanceid=$this->input->get('instanceid', FALSE);")
        sw.Append(vbCrLf & "            if(isset($instanceid)){")
        sw.Append(vbCrLf & "                if($instanceid!=''){")
        sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByInstance($instanceid);")
        sw.Append(vbCrLf & "                }else{")
        sw.Append(vbCrLf & "                    $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows();")
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "            }else{")
        sw.Append(vbCrLf & "              $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRows();")
        sw.Append(vbCrLf & "            }")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => (isset($" & p.Name.ToLower() & ")) ? TRUE : FALSE,")
        sw.Append(vbCrLf & "                'data'    => $" & p.Name.ToLower() & "")
        sw.Append(vbCrLf & "            );")

        sw.Append(vbCrLf & "        print json_encode($return);")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function getRowsByInstance() {")
        sw.Append(vbCrLf & "        log_message('debug', '" & p.Name & ".getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));")
        sw.Append(vbCrLf & "        $InstId  =  $this->input->get_post('instanceid', TRUE);")
        sw.Append(vbCrLf & "        if (strlen($InstId) > 0) {")
        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByInstance($InstId);")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => (isset($" & p.Name.ToLower() & ")) ? TRUE : FALSE,")
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
        sw.Append(vbCrLf & "        $ParentId  =  $this->input->get_post('parentid', TRUE);")
        sw.Append(vbCrLf & "        if (strlen($ParentId) > 0) {")
        sw.Append(vbCrLf & "            $" & p.Name.ToLower() & "= $this->m_" & p.Name.ToLower() & "->getRowsByParent($ParentId);")
        sw.Append(vbCrLf & "            $return = array(")
        sw.Append(vbCrLf & "                'success' => (isset($" & p.Name.ToLower() & ")) ? TRUE : FALSE,")
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





    Private Function MakeCheckBoxList(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        Dim sout As String = ""
        'Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim i As Integer ', j As Integer
        Dim rs As DataTable

        sout = ""
        rs = Manager.Session.GetData("select * from " & P.Name.ToLower())

        For i = 0 To rs.Rows.Count - 1
            If i > 0 Then
                sout = sout & vbCrLf & ","
            End If
            sout = sout & vbCrLf & "{boxLabel: '" & rs.Rows(i)(P.FIELD.Item(1).Name).ToString() & "', name: '" & P.Name.ToLower() & "_" & i.ToString() & "', inputValue:'" & rs.Rows(i)(P.Name & "ID").ToString() & "'}"
        Next


        Return sout
    End Function


    Private Function MakePartGridJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART) As String

        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Dim i As Integer

        sw.Append(vbCrLf & "var groupingFeature_" & P.Name.ToLower() & " = Ext.create('Ext.grid.feature.Grouping',{")
        'sw.Append(vbCrLf & "groupHeaderTpl:  'Cuisine: {name} ({rows.length} Item{[values.rows.length > 1 ? ""s"" : """"]})'")
        sw.Append(vbCrLf & "});")

        sw.Append(vbCrLf & "Ext.define('grid_" & P.Name.ToLower() & "', {")
        sw.Append(vbCrLf & "    extend:  'Ext.grid.Panel',")
        sw.Append(vbCrLf & "    alias: 'widget.g_" & P.Name.ToLower() & "',")

        sw.Append(vbCrLf & "    requires: [")
        sw.Append(vbCrLf & "        'Ext.grid.*',")
        sw.Append(vbCrLf & "        'Ext.form.field.Text',")
        sw.Append(vbCrLf & "        'Ext.toolbar.TextItem'")
        sw.Append(vbCrLf & "    ],")

        sw.Append(vbCrLf & "    initComponent: function(){")
        sw.Append(vbCrLf & "        Ext.apply(this, {")
        sw.Append(vbCrLf & "        iconCls:  'icon-grid',")
        sw.Append(vbCrLf & "        frame: true,")
        sw.Append(vbCrLf & "        instanceid: '',")
        sw.Append(vbCrLf & "        title: """ & P.Caption & """,")
        sw.Append(vbCrLf & "        store: store_" & P.Name.ToLower() & ",")
        sw.Append(vbCrLf & "        features: [groupingFeature_" & P.Name.ToLower() & "],")


        sw.Append(vbCrLf & "          dockedItems: [{")
        sw.Append(vbCrLf & "                xtype:  'toolbar',")
        sw.Append(vbCrLf & "                items: [{")
        sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_add',")
        sw.Append(vbCrLf & "                    text:   'Создать',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onAddClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_edit',")
        sw.Append(vbCrLf & "                    text:   'Изменить',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    disabled: true,")
        sw.Append(vbCrLf & "                    itemId:  'edit',")
        sw.Append(vbCrLf & "                    handler : this.onEditClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-application_form_delete',")
        sw.Append(vbCrLf & "                    text:   'Удалить',")
        sw.Append(vbCrLf & "                    disabled: true,")
        sw.Append(vbCrLf & "                    itemId:  'delete',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onDeleteClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-find',")
        sw.Append(vbCrLf & "                    text:   'Поиск',")
        sw.Append(vbCrLf & "                    itemId:  'find',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onFindClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
        sw.Append(vbCrLf & "                    text:   'Обновить',")
        sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onRefreshClick")
        sw.Append(vbCrLf & "                }]")
        sw.Append(vbCrLf & "            }],")

        sw.Append(vbCrLf & "        columns: [")

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)

            If i > 1 Then
                sw.Append(vbCrLf & "            ,")
            End If
            ft = fld.FieldType
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    sw.Append(vbCrLf & "            {text: """ & fld.Caption & """, width: 120, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    sw.Append(vbCrLf & "            {text: """ & fld.Caption & """, width:80, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    sw.Append(vbCrLf & "            {text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")

                End If
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                sw.Append(vbCrLf & "            {text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "', sortable: true}")


            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                sw.Append(vbCrLf & "            {text: """ & fld.Caption & """, width:60, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                sw.Append(vbCrLf & "            {text: """ & fld.Caption & """, width:100, dataIndex: '" & fld.Name.ToLower() & "_grid', sortable: true}")

            End If


        Next
        sw.Append(vbCrLf & "        ]")  ' columns

        'sw.Append(vbCrLf & "        ,")
        'sw.Append(vbCrLf & "        bbar: Ext.create('Ext.PagingToolbar', {")
        'sw.Append(vbCrLf & "        store: store_" & P.Name.ToLower() & ",")
        'sw.Append(vbCrLf & "        displayInfo: true,")
        'sw.Append(vbCrLf & "        displayMsg:  'Показаны строки с {0} по {1} из {2}',")
        'sw.Append(vbCrLf & "        emptyMsg: 'нет данных',")
        'sw.Append(vbCrLf & "        ")
        'sw.Append(vbCrLf & "        })")

        sw.Append(vbCrLf & "        }")  ' Ext.apply_data
        sw.Append(vbCrLf & "        );")  ' Ext.apply

        sw.Append(vbCrLf & "        this.callParent();")
        sw.Append(vbCrLf & "        this.getSelectionModel().on('selectionchange', this.onSelectChange, this);")
        sw.Append(vbCrLf & "       },") ' initComponent

        sw.Append(vbCrLf & "        onSelectChange: function(selModel, selections){")
        sw.Append(vbCrLf & "        this.down('#delete').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "        this.down('#edit').setDisabled(selections.length === 0);")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    listeners: {")
        sw.Append(vbCrLf & "        itemdblclick: function() { ")
        sw.Append(vbCrLf & "    	    this.onEditClick();")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onSync: function(){")
        sw.Append(vbCrLf & "        this.store.sync();")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onDeleteConfirm:function(selection){")
        sw.Append(vbCrLf & "      if (selection) {")
        sw.Append(vbCrLf & "        Ext.Ajax.request({")
        sw.Append(vbCrLf & "            url:    '" & basepath & "c_" & P.Name.ToLower() & "/deleteRow',")
        sw.Append(vbCrLf & "            method:  'POST',")
        sw.Append(vbCrLf & "    		params: { ")
        sw.Append(vbCrLf & "    				" & P.Name.ToLower() & "id: selection.get('" & P.Name.ToLower() & "id')")
        sw.Append(vbCrLf & "    				}")
        sw.Append(vbCrLf & "    	});")
        sw.Append(vbCrLf & "    	this.store.remove(selection);")
        sw.Append(vbCrLf & "      }")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onDeleteClick: function(){")
        sw.Append(vbCrLf & "      var selection = this.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "      if (selection) {")

        sw.Append(vbCrLf & "        Ext.Msg.show({")
        sw.Append(vbCrLf & "            title:  'Удалить?',")
        sw.Append(vbCrLf & "            msg:    'Удалить строку из базы данных?',")
        sw.Append(vbCrLf & "        	buttons: Ext.Msg.YESNO,")
        sw.Append(vbCrLf & "        	fn: function(btn,text,opt){")
        sw.Append(vbCrLf & "        		if(btn=='yes'){")
        sw.Append(vbCrLf & "        			opt.caller.onDeleteConfirm(opt.selectedRow);")
        sw.Append(vbCrLf & "        	    }")
        sw.Append(vbCrLf & "        	},")
        sw.Append(vbCrLf & "            icon:   Ext.window.MessageBox.QUESTION,")
        sw.Append(vbCrLf & "            caller: this,")
        sw.Append(vbCrLf & "            selectedRow: selection")
        sw.Append(vbCrLf & "        });")
        sw.Append(vbCrLf & "      }")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onAddClick: function(){")
        ''''''''''''''''''''''''''''' submit Add 
        'sw.Append(vbCrLf & "            Ext.Ajax.request({")
        'sw.Append(vbCrLf & "                url: '" & basepath & "c_" & P.Name.ToLower() & "/newRow',")
        'sw.Append(vbCrLf & "                method:  'POST',")
        'sw.Append(vbCrLf & "                params: { ")
        'sw.Append(vbCrLf & "    				instanceid: this.instanceid")
        'sw.Append(vbCrLf & "                },")
        'sw.Append(vbCrLf & "                success: function(response){")
        'sw.Append(vbCrLf & "                var text = response.responseText;")
        'sw.Append(vbCrLf & "                var res =Ext.decode(text);")
        sw.Append(vbCrLf & "                var edit = Ext.create('EditWindow_" & P.Name.ToLower() & "');")

        sw.Append(vbCrLf & "                store_" & P.Name.ToLower() & ".insert(0, new model_" & P.Name.ToLower() & "());")

        sw.Append(vbCrLf & "                record= store_" & P.Name.ToLower() & ".getAt(0);")
        sw.Append(vbCrLf & "                record['instanceid']=this.instanceid;")
        'sw.Append(vbCrLf & "                record['" & P.Name.ToLower() & "id']=res.data;")
        sw.Append(vbCrLf & "                edit.getComponent(0).setActiveRecord(record,this.instanceid);")
        sw.Append(vbCrLf & "                edit.show();")
        'sw.Append(vbCrLf & "                }")
        'sw.Append(vbCrLf & "            });")
        'sw.Append(vbCrLf & "            this.store.load({params:{instanceid: this.instanceid}});")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onFindClick: function(){")
        sw.Append(vbCrLf & "            alert('find condition window. todo');")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onRefreshClick: function(){")
        sw.Append(vbCrLf & "            this.store.load({params:{instanceid: this.instanceid}});")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onEditClick: function(){")
        sw.Append(vbCrLf & "        var selection = this.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        sw.Append(vbCrLf & "            var edit = Ext.create('EditWindow_" & P.Name.ToLower() & "');")
        sw.Append(vbCrLf & "            edit.getComponent(0).setActiveRecord(selection,selection.get('instanceid'));")
        sw.Append(vbCrLf & "            edit.show();")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    }")
        sw.Append(vbCrLf & "    }")  'Ext.Define_data
        sw.Append(vbCrLf & "    );")  'Ext.Define



        Return sw.ToString()
    End Function

    Private Function GenStores(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer


        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            sw.Append(vbCrLf & Model_And_Store(P))

        Next

        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            sw.Append(vbCrLf & Combo_Store(P))

        Next
        Return sw.ToString()

    End Function
    Private Function MakeFormPanelJS(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()

        Dim mode As String = ""



        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim i As Integer
        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).DefaultMode = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                mode = ot.OBJECTMODE.Item(i).Name
            End If
        Next

        sw.Append(vbCrLf & "Ext.define('Form_" & P.Name.ToLower() & "', {")
        sw.Append(vbCrLf & "extend:  'Ext.form.Panel',")
        sw.Append(vbCrLf & "alias: 'widget.f_" & P.Name.ToLower() & "',")

        sw.Append(vbCrLf & "initComponent: function(){")
        sw.Append(vbCrLf & "    this.addEvents('create');")

        sw.Append(vbCrLf & "    Ext.apply(this,{")
        sw.Append(vbCrLf & "        activeRecord: null,")
        'sw.Append(vbCrLf & "        iconCls: 'icon-application_form',")
        'sw.Append(vbCrLf & "        frame: true,")
        ' sw.Append(vbCrLf & "        title:  '" & P.Caption & "',")
        sw.Append(vbCrLf & "        defaultType:  'textfield',")
        'sw.Append(vbCrLf & "        bodyPadding: 2,")


        Dim col As Collection
        Dim fg As String
        Dim HasUnGroupedField As Boolean = False
        Dim j As Integer
        Dim FirstField As Boolean


        col = New Collection

        P.FIELD.Sort = "sequence"

        For i = 1 To P.FIELD.Count
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
        Next
        Dim cnt As Integer
        cnt = col.Count
        If HasUnGroupedField Then
            cnt = cnt + 1
        End If

        If (HasUnGroupedField And col.Count > 0) Or (HasUnGroupedField = False And col.Count > 1) Then
            ' sw.Append(vbCrLf & "        layout:'accordion',")
            sw.Append(vbCrLf & "        layout:'card',")
            sw.Append(vbCrLf & "        id:'" + P.Name.ToLower() + "',")
            sw.Append(vbCrLf & "        		bbar: ['->', {")
            sw.Append(vbCrLf & "                id:'" + P.Name.ToLower() + "-prev',")
            sw.Append(vbCrLf & "                text:'&laquo; Ранее',")
            sw.Append(vbCrLf & "        			handler: Ext.Function.bind(cardNav, this, ['" + P.Name.ToLower() + "',-1," + cnt.ToString + "]),")
            sw.Append(vbCrLf & "                    disabled: true")
            sw.Append(vbCrLf & "        			},{")
            sw.Append(vbCrLf & "                id:'" + P.Name.ToLower() + "-next',")
            sw.Append(vbCrLf & "                text:'Далее &raquo;',")
            sw.Append(vbCrLf & "        			 handler: Ext.Function.bind(cardNav, this, ['" + P.Name.ToLower() + "',1," + cnt.ToString + "])")
            sw.Append(vbCrLf & "        		}],")

        Else
            sw.Append(vbCrLf & "        layout:'fit',")
        End If


        sw.Append(vbCrLf & "        fieldDefaults: {")
        sw.Append(vbCrLf & "         labelAlign:  'right',")
        sw.Append(vbCrLf & "         labelWidth: 80")
        sw.Append(vbCrLf & "        },")

        sw.Append(vbCrLf & "        items: [")
        Dim IsFieldPresent As Boolean
        Dim IsFieldReadonly As Boolean

        cnt = 0
        If HasUnGroupedField Then

            sw.Append(vbCrLf & "        { ")
            sw.Append(vbCrLf & "        xtype:'panel', ")
            sw.Append(vbCrLf & "        id:'" + P.Name.ToLower() + "-" + cnt.ToString() + "',")
            cnt += 1
            'sw.Append(vbCrLf & "        collapsed:false, ")
            sw.Append(vbCrLf & "        layout:'column', ")
            sw.Append(vbCrLf & "        anchor: '100%', ")

            sw.Append(vbCrLf & "        items: [")
            FirstField = True
            P.FIELD.Sort = "sequence"
            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)



                If fld.FieldGroupBox = "" Then
                    IsFieldPresent = LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, mode)
                    If IsFieldPresent Then

                        IsFieldReadonly = LATIR2Framework.ObjectHelper.IsFieldReadOnly(P, fld.ID.ToString, mode)

                        If Not FirstField Then
                            sw.Append(vbCrLf & ",")
                        End If

                        sw.Append(vbCrLf & "{")

                        If IsFieldReadonly Then
                            sw.Append(vbCrLf & "        readOnly: true, ")

                        End If

                        sw.Append(vbCrLf & "        columnWidth: .25, ")
                        sw.Append(vbCrLf & MakeFld(fld, IsFieldReadonly))

                        sw.Append(vbCrLf & "}")
                        FirstField = False
                    Else
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
            sw.Append(vbCrLf & "        ]}")
        End If

        If HasUnGroupedField And col.Count > 0 Then
            sw.Append(vbCrLf & ",")
        End If

        For j = 1 To col.Count
            fg = col.Item(j)

            If j > 1 Then
                sw.Append(vbCrLf & ",")
            End If

            sw.Append(vbCrLf & "        { ")
            sw.Append(vbCrLf & "        xtype:'panel', ")
            sw.Append(vbCrLf & "        layout:'column', ")





            'If j = 1 And HasUnGroupedField = False Then
            '    sw.Append(vbCrLf & "        collapsed:false, ")
            'Else
            '    sw.Append(vbCrLf & "        collapsed:true, ")
            'End If
            sw.Append(vbCrLf & "        id:'" + P.Name.ToLower() + "-" + cnt.ToString() + "',")
            cnt += 1
            sw.Append(vbCrLf & "title:      '" & fg & "',")

            sw.Append(vbCrLf & "defaultType:  'textfield',")
            'sw.Append(vbCrLf & "            defaults: {")
            'sw.Append(vbCrLf & "                width: 210")

            'sw.Append(vbCrLf & "            },")
            sw.Append(vbCrLf & "            items: [")
            FirstField = True
            P.FIELD.Sort = "sequence"

            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)

                If fld.FieldGroupBox = fg Then
                    IsFieldPresent = LATIR2Framework.ObjectHelper.IsFieldPresent(P, fld.ID.ToString, mode)
                    If IsFieldPresent Then
                        IsFieldReadonly = LATIR2Framework.ObjectHelper.IsFieldReadOnly(P, fld.ID.ToString, mode)
                        If Not FirstField Then
                            sw.Append(vbCrLf & ",")
                        End If
                        sw.Append(vbCrLf & "{")
                        sw.Append(vbCrLf & "                columnWidth: .25, ")
                        sw.Append(vbCrLf & MakeFld(fld, IsFieldReadonly))
                        sw.Append(vbCrLf & "}")
                        FirstField = False
                    Else
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
            sw.Append(vbCrLf & "            ]} // group panel")
        Next

        sw.Append(vbCrLf & "          ],//items = accordion panel") 'items



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
            sw.Append(vbCrLf & "                    iconCls:  'icon-reset',")
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
        sw.Append(vbCrLf & "    setActiveRecord: function(record,instid){")
        sw.Append(vbCrLf & "        this.activeRecord = record;")
        sw.Append(vbCrLf & "        this.instanceid = instid;")
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

        ''''''''''''''''''''''''''''' submit changes directly 
        sw.Append(vbCrLf & "            Ext.Ajax.request({")
        sw.Append(vbCrLf & "                url: '" & basepath & "c_" & P.Name.ToLower() & "/setRow',")
        sw.Append(vbCrLf & "                method:  'POST',")
        sw.Append(vbCrLf & "                params: { ")
        sw.Append(vbCrLf & "                    instanceid: this.instanceid")
        sw.Append(vbCrLf & "                    ," & P.Name.ToLower() & "id: active.get('" & P.Name.ToLower() & "id')")
        P.FIELD.Sort = "sequence"
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            sw.Append(vbCrLf & "                    ," & fld.Name.ToLower() & ": active.get('" & fld.Name.ToLower() & "') ")
        Next
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "                , success: function(response){")
        sw.Append(vbCrLf & "                var text = response.responseText;")
        sw.Append(vbCrLf & "                var res =Ext.decode(text);")
        sw.Append(vbCrLf & "               if(active.get('" & P.Name.ToLower() & "id')==''){")
        sw.Append(vbCrLf & "               			active.set('" & P.Name.ToLower() & "id',res['" & P.Name.ToLower() & "id']);")
        sw.Append(vbCrLf & "               }")
        sw.Append(vbCrLf & "              }")
        sw.Append(vbCrLf & "            });")

        If P.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
            sw.Append(vbCrLf & "             this.ownerCt.close();")
            'sw.Append(vbCrLf & "             this.ownerCt.destroy();")
        End If

        sw.Append(vbCrLf & "        }")

        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onReset: function(){")
        sw.Append(vbCrLf & "        this.setActiveRecord(null);")
        sw.Append(vbCrLf & "        this.ownerCt.close();")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "}); // 'Ext.Define") 'Ext.Define


        sw.Append(vbCrLf)
        '''''''''''''''''''' define modal edit window 

        sw.Append(vbCrLf & "Ext.define('EditWindow_" & P.Name.ToLower() & "', {")
        sw.Append(vbCrLf & "    extend:  'Ext.window.Window',")
        sw.Append(vbCrLf & "    height: 250,")
        sw.Append(vbCrLf & "    width: 600,")
        sw.Append(vbCrLf & "    layout:  'fit',")
        sw.Append(vbCrLf & "    autoShow: true,")
        sw.Append(vbCrLf & "    modal: true,")
        sw.Append(vbCrLf & "    closeAction: 'destroy',")
        sw.Append(vbCrLf & "    iconCls:  'icon-application_form',")
        sw.Append(vbCrLf & "    title:  '" & P.Caption() & "',")
        sw.Append(vbCrLf & "    items:[{")
        sw.Append(vbCrLf & "        xtype:  'f_" & P.Name.ToLower() & "'")
        sw.Append(vbCrLf & "	}]")
        sw.Append(vbCrLf & "	});")

        Return sw.ToString()

    End Function


    Private Function MakeFld(ByVal fld As MTZMetaModel.MTZMetaModel.FIELD, ByVal FldReadOnly As Boolean) As String

        Dim sw As StringBuilder
        sw = New StringBuilder
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = fld.FieldType

        If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS Then

            If ft.Name.ToLower() = "masterstring" Then
                If FldReadOnly Then
                    sw.Append(vbCrLf & "hideTrigger: true,")
                End If
                sw.Append(vbCrLf & "xtype:  'trigger',")
                sw.Append(vbCrLf & "editable: false,")
                sw.Append(vbCrLf & " onTriggerClick: function() {")
                'sw.Append(vbCrLf & "  Ext.Msg.alert('Status', 'You clicked masterstring field!');")
                sw.Append(vbCrLf & " showAddrWin(this);")
                sw.Append(vbCrLf & "},")


            ElseIf ft.Name.ToLower() = "file" Then
                sw.Append(vbCrLf & "xtype:  'filefield',")
                If FldReadOnly Then
                    sw.Append(vbCrLf & "hideTrigger: true,")
                End If
            ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then


                sw.Append(vbCrLf & "xtype:          'combobox',")
                If FldReadOnly Then
                    sw.Append(vbCrLf & "hideTrigger: true,")
                End If
                sw.Append(vbCrLf & "store: enum_" & ft.Name & ",")
                sw.Append(vbCrLf & "valueField:     'value',")
                sw.Append(vbCrLf & "displayField:   'name',")
                sw.Append(vbCrLf & "typeAhead: true,")
                sw.Append(vbCrLf & "queryMode:      'local',")
                sw.Append(vbCrLf & "emptyText:      '',")

                'sw.Append(vbCrLf & "xtype:                      'radiogroup',")
                'sw.Append(vbCrLf & "            items: [")

                'Dim k As Integer
                'For k = 1 To ft.ENUMITEM.Count
                '    If k > 1 Then
                '        sw.Append(vbCrLf & "              ,")
                '    End If

                '    sw.Append(vbCrLf & "                {boxLabel: '" & ft.ENUMITEM.Item(k).Name & "', name: '" & fld.Name.ToLower() & "', inputValue: " & ft.ENUMITEM.Item(k).NameValue.ToString() & "}")
                'Next


                'sw.Append(vbCrLf & "            ],")

            Else


                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then

                    If ft.Name.ToLower() = "password" Then
                        sw.Append(vbCrLf & "xtype:  'textfield',")
                        sw.Append(vbCrLf & "inputType:  'password',")
                        sw.Append(vbCrLf & "value:  '',")
                    ElseIf ft.Name.ToLower() = "memo" Then
                        sw.Append(vbCrLf & "xtype:  'textareafield',")
                        sw.Append(vbCrLf & "value:  '',")
                    Else
                        sw.Append(vbCrLf & "xtype:  'textfield',")
                        sw.Append(vbCrLf & "value:  '',")
                    End If


                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    sw.Append(vbCrLf & "xtype:  'datefield',")
                    If FldReadOnly Then
                        sw.Append(vbCrLf & "hideTrigger: true,")
                    End If
                    sw.Append(vbCrLf & "value:  '',")
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    sw.Append(vbCrLf & "xtype:  'numberfield',")
                    If FldReadOnly Then
                        sw.Append(vbCrLf & "hideTrigger: true,")
                    End If
                    sw.Append(vbCrLf & "value:  '0',")
                End If
            End If

        ElseIf fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
            Dim refP As MTZMetaModel.MTZMetaModel.PART
            refP = fld.RefToPart
            Dim ff As Integer
            Dim fi As Integer
            If Not refP Is Nothing Then
                fi = 1
                For ff = 1 To refP.FIELD.Count
                    If refP.FIELD.Item(ff).IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                        fi = ff
                        Exit For
                    End If
                Next
                If ft.Name.ToLower() = "multiref" Then




                    sw.Append(vbCrLf & "xtype:          'boxselect',")
                    If FldReadOnly Then
                        sw.Append(vbCrLf & "hideTrigger: true,")
                    End If
                    sw.Append(vbCrLf & "store: cmbstore_" & refP.Name.ToLower() & ",")
                    sw.Append(vbCrLf & "valueField:     '" & refP.Name.ToLower() & "id',")

                    sw.Append(vbCrLf & "displayField:   'brief',")
                    sw.Append(vbCrLf & " multiSelect: true,")
                    'sw.Append(vbCrLf & "delimiter: ';',")
                    'sw.Append(vbCrLf & "typeAhead: true,")
                    sw.Append(vbCrLf & "queryMode:      'local',")
                    'sw.Append(vbCrLf & "triggerAction:      'all',")
                    'sw.Append(vbCrLf & "lastQuery:          '',")

                    sw.Append(vbCrLf & "emptyText:      '',")

                Else
                    sw.Append(vbCrLf & "xtype:          'boxselect',")
                    If FldReadOnly Then
                        sw.Append(vbCrLf & "hideTrigger: true,")
                    End If
                    sw.Append(vbCrLf & "store: cmbstore_" & refP.Name.ToLower() & ",")
                    sw.Append(vbCrLf & "valueField:     '" & refP.Name.ToLower() & "id',")
                    sw.Append(vbCrLf & "displayField:   'brief',")
                    sw.Append(vbCrLf & "typeAhead: true,")
                    sw.Append(vbCrLf & "queryMode:      'local',")
                    'sw.Append(vbCrLf & "triggerAction:      'all',")
                    'sw.Append(vbCrLf & "lastQuery:          '',")
                    sw.Append(vbCrLf & "emptyText:      '',")
                End If
            End If

        Else


            sw.Append(vbCrLf & "xtype:  'textfield',")
            sw.Append(vbCrLf & "value:  'todo - refernce to object',")
        End If


        If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
            sw.Append(vbCrLf & "allowBlank:false,")
        Else
            sw.Append(vbCrLf & "allowBlank:true,")
        End If

        sw.Append(vbCrLf & "name:   '" & fld.Name.ToLower() & "',")
        sw.Append(vbCrLf & "fieldLabel:  '" & fld.Caption & "'")




        Return sw.ToString()
    End Function


    Private Function MakeJPHPModel(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String

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
        pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If


        For i = 1 To Jrnl.JournalColumn.Count
            ' formatting date column for journal
            If Jrnl.JournalColumn.Item(i).ColSort = MTZJrnl.MTZJrnl.enumColumnSortType.ColumnSortType_As_Date Then
                flist = flist & ",convert(varchar(100)," & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower & ",111) " & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower
            Else
                flist = flist & "," & Jrnl.JournalColumn.Item(i).JColumnSource.Item(1).ViewField.ToLower
            End If

        Next

        sw.Append(vbCrLf & "<?php")

        sw.Append(vbCrLf & "class  M_v_" & pv.the_Alias.ToLower() & " extends CI_Model {")
        sw.Append(vbCrLf & "    public function  __construct()")
        sw.Append(vbCrLf & "    {")
        sw.Append(vbCrLf & "         parent::__construct();")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "    function newRow($objtype,$name)  {")
        sw.Append(vbCrLf & "                $rows=$this->db->query('select top 1 newid() as id from sysobjects')->result();")
        sw.Append(vbCrLf & "                $row=$rows[0];")
        sw.Append(vbCrLf & "                $id = $row->id;")
        sw.Append(vbCrLf & "                $this->db->set(array('instanceid'=>$id));")
        sw.Append(vbCrLf & "                $this->db->set(array('name'=>$name));")
        sw.Append(vbCrLf & "                $this->db->set(array('objtype'=>$objtype));")
        sw.Append(vbCrLf & "                $this->db->insert('instance');")
        sw.Append(vbCrLf & "                if ($id) {")
        sw.Append(vbCrLf & "                    return array('success'=>TRUE, 'data' => $id);")
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "                else {")
        sw.Append(vbCrLf & "                    $return= array('success'=>FALSE, 'msg' => 'Error while create new id');")
        sw.Append(vbCrLf & "				    return $return;")
        sw.Append(vbCrLf & "                }")
        sw.Append(vbCrLf & "    }")


        sw.Append(vbCrLf & "    function getRows()")
        sw.Append(vbCrLf & "		{")
        sw.Append(vbCrLf & "            $query = $this->db->query(' select " & flist & " from x_" & pv.the_Alias.ToLower() & "');")
        sw.Append(vbCrLf & "			if ($query->num_rows() == 0)")
        sw.Append(vbCrLf & "			{")
        sw.Append(vbCrLf & "                 $return= array('success'=>FALSE, 'msg' => 'No data found');")
        sw.Append(vbCrLf & "				return $return;")
        sw.Append(vbCrLf & "			}else{")
        sw.Append(vbCrLf & "				return $query->result();")
        sw.Append(vbCrLf & "			}")
        sw.Append(vbCrLf & "		}")


        sw.Append(vbCrLf & "      function getRowsSL($offset,$limit)")
        sw.Append(vbCrLf & "{")
        sw.Append(vbCrLf & "	$sql1='select count(*) as  total  from x_" & pv.the_Alias.ToLower() & "';")
        sw.Append(vbCrLf & "	$sql='select " & flist & " from x_" & pv.the_Alias.ToLower() & "';")
        sw.Append(vbCrLf & "	$cn=$this->db->db_pconnect(true);")
        sw.Append(vbCrLf & "	$stmt= sqlsrv_query( $cn, $sql1, array(), array( 'Scrollable' => 'static' ));")

        sw.Append(vbCrLf & "	if($row=sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC)){")
        sw.Append(vbCrLf & "		$root->total=$row['total'];")
        sw.Append(vbCrLf & "		$root->sucess=true;")
        sw.Append(vbCrLf & "	}else{")
        sw.Append(vbCrLf & "		$root->total=0;")
        sw.Append(vbCrLf & "		$root->sucess=false;")
        sw.Append(vbCrLf & "	}")

        sw.Append(vbCrLf & "	sqlsrv_free_stmt( $stmt);")

        sw.Append(vbCrLf & "	$stmt= sqlsrv_query( $cn, $sql, array(), array( 'Scrollable' => 'static' ));")
        sw.Append(vbCrLf & "	$result=array();")
        sw.Append(vbCrLf & "	if($row=sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC,SQLSRV_SCROLL_ABSOLUTE,$offset)){")
        sw.Append(vbCrLf & "		$cnt=1;")
        sw.Append(vbCrLf & "		$result[]=$row;")
        sw.Append(vbCrLf & "		while(  $cnt<$limit)")
        sw.Append(vbCrLf & "		{")
        sw.Append(vbCrLf & "		  $cnt=$cnt+1;")
        sw.Append(vbCrLf & "		  if ($row = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC,SQLSRV_SCROLL_NEXT)){")
        sw.Append(vbCrLf & "			$result[]=$row;")
        sw.Append(vbCrLf & "			log_message('debug',$row['id']);")
        sw.Append(vbCrLf & "		  }else{")
        sw.Append(vbCrLf & "		    $root->sucess=false;")
        sw.Append(vbCrLf & "			break;")
        sw.Append(vbCrLf & "		  }")
        sw.Append(vbCrLf & "		}")
        sw.Append(vbCrLf & "	}else{")
        sw.Append(vbCrLf & "	}")
        sw.Append(vbCrLf & "	sqlsrv_free_stmt( $stmt);")
        sw.Append(vbCrLf & "	sqlsrv_close( $cn);")
        sw.Append(vbCrLf & "	$root->rows=$result;")
        sw.Append(vbCrLf & "	return $root;")

        sw.Append(vbCrLf & "}")

        sw.Append(vbCrLf & "    function deleteRow($id = null) {")
        'sw.Append(vbCrLf & "        if ($id) {")
        'sw.Append(vbCrLf & "          $this->db->where('" & p.Name.ToLower() & "id', $id);")
        'sw.Append(vbCrLf & "          $this->db->delete('" & p.Name.ToLower() & "');")
        'sw.Append(vbCrLf & "          $return=array('success'=>TRUE);")
        'sw.Append(vbCrLf & "		  return $return;")
        'sw.Append(vbCrLf & "        }else{")
        sw.Append(vbCrLf & "          $return= array('success'=>FALSE, 'msg' => 'No ID for delete');")
        sw.Append(vbCrLf & "		  return $return;")
        'sw.Append(vbCrLf & "	    }")
        sw.Append(vbCrLf & "    }")

        sw.Append(vbCrLf & "}")
        sw.Append(vbCrLf & "?>")



        Return sw.ToString()
    End Function

    Private Function MakeJPHPController(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String


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
        pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If


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

        'sw.Append(vbCrLf & "            $" & pv.the_Alias.ToLower() & "= $this->m_v_" & pv.the_Alias.ToLower() & "->getRows();")
        'sw.Append(vbCrLf & "            $return = array(")
        'sw.Append(vbCrLf & "                'success' => (isset($" & pv.the_Alias.ToLower() & ")) ? TRUE : FALSE,")
        'sw.Append(vbCrLf & "                'data'    => $" & pv.the_Alias.ToLower() & "")
        'sw.Append(vbCrLf & "            );")
        'sw.Append(vbCrLf & "        print json_encode($return);")

        sw.Append(vbCrLf & "           $start=$this->input->get('start', FALSE);")
        sw.Append(vbCrLf & "           $limit=$this->input->get('limit', FALSE);")
        sw.Append(vbCrLf & "           $" & pv.the_Alias.ToLower() & "= $this->m_v_" & pv.the_Alias.ToLower() & "->getRowsSL($start,$limit);")
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

    Private Function MakeJ_JSModel(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String
        Dim sw As StringBuilder
        sw = New StringBuilder

        Dim i As Integer


        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW
        Dim prt As MTZMetaModel.MTZMetaModel.PART
        Dim p As MTZJrnl.MTZJrnl.Journal
        p = Jrnl.Journal.Item(1)
        pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)

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

    Private Function MakeJ_JSStore(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String
        Dim sw As StringBuilder
        sw = New StringBuilder

        Dim i As Integer


        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim p As MTZJrnl.MTZJrnl.Journal
        p = Jrnl.Journal.Item(1)
        pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If


        sw.Append(vbCrLf & "    var store_v_" & pv.the_Alias.ToLower() & " = Ext.create('Ext.data.Store', {")
        sw.Append(vbCrLf & "        model:'model_v_" & pv.the_Alias.ToLower() & "',")
        sw.Append(vbCrLf & "        autoLoad: false,")
        sw.Append(vbCrLf & "        autoSync: false,")
        sw.Append(vbCrLf & "        proxy: {")
        sw.Append(vbCrLf & "            type:   'ajax',")
        sw.Append(vbCrLf & "                url:   '" & basepath & "c_v_" & pv.the_Alias.ToLower() & "/getRows',")
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


    Private Function MakeJ_JSGrid(ByVal Jrnl As MTZJrnl.MTZJrnl.Application) As String
        Dim sw As StringBuilder
        sw = New StringBuilder

        Dim i As Integer


        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim p As MTZJrnl.MTZJrnl.Journal
        p = Jrnl.Journal.Item(1)
        pv = model.FindRowObject("PartView", Jrnl.JournalSrc.Item(1).PartView)

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If

        sw.Append(vbCrLf & "var groupingFeature_" & pv.the_Alias.ToLower() & " = Ext.create('Ext.grid.feature.Grouping',{")
        sw.Append(vbCrLf & "});")

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
        sw.Append(vbCrLf & "        iconCls:  'icon-grid',")
        sw.Append(vbCrLf & "        frame: true,")
        sw.Append(vbCrLf & "        title: """ & p.Name & """,")
        sw.Append(vbCrLf & "        store: store_v_" & pv.the_Alias.ToLower() & ",")
        sw.Append(vbCrLf & "        features: [groupingFeature_" & pv.the_Alias.ToLower() & "],")


        sw.Append(vbCrLf & "          dockedItems: [{")
        sw.Append(vbCrLf & "                xtype:  'toolbar',")
        sw.Append(vbCrLf & "                items: [{")
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
        sw.Append(vbCrLf & "                    iconCls:  'icon-find',")
        sw.Append(vbCrLf & "                    text:   'Поиск',")
        sw.Append(vbCrLf & "                    disabled: true,")
        sw.Append(vbCrLf & "                    itemId:  'find',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onFindClick")
        sw.Append(vbCrLf & "                    }, {")
        sw.Append(vbCrLf & "                    iconCls:  'icon-table_refresh',")
        sw.Append(vbCrLf & "                    text:   'Обновить',")
        sw.Append(vbCrLf & "                    itemId:  'bRefresh',")
        sw.Append(vbCrLf & "                    scope:  this,")
        sw.Append(vbCrLf & "                    handler : this.onRefreshClick")
        sw.Append(vbCrLf & "                }]")
        sw.Append(vbCrLf & "            }],")

        sw.Append(vbCrLf & "        columns: [")

        Jrnl.JournalColumn.Sort = "sequence"

        Dim jc As MTZJrnl.MTZJrnl.JournalColumn
        For i = 1 To Jrnl.JournalColumn.Count
            jc = Jrnl.JournalColumn.Item(i)


            If i > 1 Then
                sw.Append(vbCrLf & "            ,")
            End If

            sw.Append(vbCrLf & "            {text: """ & jc.name & """, width:70, dataIndex: '" & jc.JColumnSource.Item(1).ViewField.ToLower() & "', sortable: true}")

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
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onSync: function(){")
        sw.Append(vbCrLf & "        this.store.sync();")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onDeleteConfirm:function(selection){")
        sw.Append(vbCrLf & "      if (selection) {")
        sw.Append(vbCrLf & "        Ext.Ajax.request({")
        sw.Append(vbCrLf & "            url:    '" & basepath & "c_" & pv.the_Alias.ToLower() & "/deleteRow',")
        sw.Append(vbCrLf & "            method:  'POST',")
        sw.Append(vbCrLf & "    		params: { ")
        sw.Append(vbCrLf & "    				" & pv.the_Alias.ToLower() & "id: selection.get('" & pv.the_Alias.ToLower() & "id')")
        sw.Append(vbCrLf & "    				}")
        sw.Append(vbCrLf & "    	});")
        sw.Append(vbCrLf & "    	this.store.remove(selection);")
        sw.Append(vbCrLf & "      }")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onDeleteClick: function(){")
        sw.Append(vbCrLf & "      var selection = this.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "      if (selection) {")

        sw.Append(vbCrLf & "        Ext.Msg.show({")
        sw.Append(vbCrLf & "            title:  'Удалить?',")
        sw.Append(vbCrLf & "            msg:    'Удалить строку из базы данных?',")
        sw.Append(vbCrLf & "        	buttons: Ext.Msg.YESNO,")
        sw.Append(vbCrLf & "        	fn: function(btn,text,opt){")
        sw.Append(vbCrLf & "        		if(btn=='yes'){")
        sw.Append(vbCrLf & "        			opt.caller.onDeleteConfirm(opt.selectedRow);")
        sw.Append(vbCrLf & "        	    }")
        sw.Append(vbCrLf & "        	},")
        sw.Append(vbCrLf & "            icon:   Ext.window.MessageBox.QUESTION,")
        sw.Append(vbCrLf & "            caller: this,")
        sw.Append(vbCrLf & "            selectedRow: selection")
        sw.Append(vbCrLf & "        });")
        sw.Append(vbCrLf & "      }")
        sw.Append(vbCrLf & "    },")

        sw.Append(vbCrLf & "    onAddClick: function(){")
        ''''''''''''''''''''''''''''' submit Add 
        sw.Append(vbCrLf & "            Ext.Ajax.request({")
        sw.Append(vbCrLf & "                url: '" & basepath & "c_v_" & pv.the_Alias.ToLower() & "/newRow',")
        sw.Append(vbCrLf & "                method:  'POST',")
        sw.Append(vbCrLf & "                params: { ")
        sw.Append(vbCrLf & "                },")
        sw.Append(vbCrLf & "                success: function(response){")
        sw.Append(vbCrLf & "                var text = response.responseText;")
        sw.Append(vbCrLf & "                var res =Ext.decode(text);")
        sw.Append(vbCrLf & "                var edit = Ext.create('ObjectWindow_" & Jrnl.Name.ToLower() & "');")
        sw.Append(vbCrLf & "                var p=" & Jrnl.Name & "_Panel( res.data, false ) ;")
        sw.Append(vbCrLf & "                edit.add(p);")
        sw.Append(vbCrLf & "                edit.show();")
        sw.Append(vbCrLf & "                }")

        sw.Append(vbCrLf & "            });")
        sw.Append(vbCrLf & "            this.store.load();")
        sw.Append(vbCrLf & "    },")


        sw.Append(vbCrLf & "    onEditClick: function(){")
        sw.Append(vbCrLf & "        var selection = this.getView().getSelectionModel().getSelection()[0];")
        sw.Append(vbCrLf & "        if (selection) {")
        sw.Append(vbCrLf & "            //alert(""Edit " & p.Name & """);")
        sw.Append(vbCrLf & "            var edit = Ext.create('ObjectWindow_" & Jrnl.Name.ToLower() & "');")
        sw.Append(vbCrLf & "            var p=" & Jrnl.Name & "_Panel( selection.get('instanceid'), false ) ;")
        sw.Append(vbCrLf & "            edit.add(p);")
        sw.Append(vbCrLf & "            edit.show();")
        sw.Append(vbCrLf & "        }")
        sw.Append(vbCrLf & "    },")
        sw.Append(vbCrLf & "    onFindClick: function(){")
        sw.Append(vbCrLf & "            alert('find condition window. todo');")
        sw.Append(vbCrLf & "    },")
        sw.Append(vbCrLf & "    onRefreshClick: function(){")
        sw.Append(vbCrLf & "             this.store.load();")
        sw.Append(vbCrLf & "    }")

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
        ' sw.Append(vbCrLf & "            height: 550,")
        sw.Append(vbCrLf & "            flex: 1,")

        sw.Append(vbCrLf & "            store: store_v_" & pv.the_Alias.ToLower())
        sw.Append(vbCrLf & "    }] // tabpanel")
        sw.Append(vbCrLf & "    }); //Ext.Create")
        sw.Append(vbCrLf & "    return " & Jrnl.Name & ";")
        sw.Append(vbCrLf & "}")



        sw.Append(vbCrLf & "Ext.define('ObjectWindow_" & Jrnl.Name.ToLower() & "', {")
        sw.Append(vbCrLf & "    extend:  'Ext.window.Window',")
        sw.Append(vbCrLf & "    height: 640,")
        sw.Append(vbCrLf & "    width: 1024,")
        sw.Append(vbCrLf & "    minHeight: 500,")
        sw.Append(vbCrLf & "    minWidth: 600,")
        sw.Append(vbCrLf & "    x: 50,")
        sw.Append(vbCrLf & "    y: 3,")
        sw.Append(vbCrLf & "    layout:  'fit',")
        sw.Append(vbCrLf & "    autoShow: true,")
        sw.Append(vbCrLf & "    closeAction: 'destroy',")
        sw.Append(vbCrLf & "    modal: true,")
        sw.Append(vbCrLf & "    iconCls:  'icon-application_form',")
        sw.Append(vbCrLf & "    title:  '" & p.Name & "',")
        sw.Append(vbCrLf & "    items:[ ]")
        sw.Append(vbCrLf & "	});")


        Return sw.ToString()
    End Function


    Private Function GenAlterbase(ByVal Jid As Guid) As String
        Dim JJJ As MTZJrnl.MTZJrnl.Application
        JJJ = Manager.GetInstanceObject(Jid)
        If JJJ Is Nothing Then
            MsgBox("Journal unknown " + Jid.ToString)
            Return ""
        End If


        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW
        Dim prt As MTZMetaModel.MTZMetaModel.PART

        Dim p As MTZJrnl.MTZJrnl.Journal
        p = JJJ.Journal.Item(1)
        pv = model.FindRowObject("PartView", JJJ.JournalSrc.Item(1).PartView)

        If p Is Nothing Or pv Is Nothing Then
            Return ""
        End If

        prt = pv.Parent.Parent
        Dim sw As StringBuilder
        sw = New StringBuilder



        sw.Append(vbCrLf & "--drop store table " & pv.the_Alias.ToLower() & "")
        sw.Append(vbCrLf & "        drop table x_" & pv.the_Alias.ToLower() & "")
        sw.Append(vbCrLf & "                go")


        sw.Append(vbCrLf & "-- create store table")
        sw.Append(vbCrLf & "        select * into x_" & pv.the_Alias.ToLower() & " from v_" & pv.the_Alias.ToLower() & " ")

        sw.Append(vbCrLf & "-- drop trigger")
        sw.Append(vbCrLf & "        drop trigger " & prt.Name.ToLower() & "_trigger")
        sw.Append(vbCrLf & "        go")

        sw.Append(vbCrLf & "--create trigger")
        sw.Append(vbCrLf & "        create trigger " & prt.Name.ToLower() & "_trigger on dbo." & prt.Name.ToLower() & " after insert, update, delete")
        sw.Append(vbCrLf & "        as")
        sw.Append(vbCrLf & "        begin")
        sw.Append(vbCrLf & "        delete from x_" & pv.the_Alias.ToLower() & " where id in (select " & prt.Name.ToLower() & "id from deleted);")
        sw.Append(vbCrLf & "        insert into x_" & pv.the_Alias.ToLower() & " select * from v_" & pv.the_Alias.ToLower() & " where  id in (select " & prt.Name.ToLower() & "id from inserted);")
        sw.Append(vbCrLf & "        end;")
        sw.Append(vbCrLf & "        go")

        Return sw.ToString()

    End Function

    Private Sub GenJournal(ByVal Jid As Guid)
        Dim JJJ As MTZJrnl.MTZJrnl.Application
        JJJ = Manager.GetInstanceObject(Jid)
        If JJJ Is Nothing Then
            MsgBox("Journal unknown " + Jid.ToString)
            Exit Sub
        End If


        Dim pv As MTZMetaModel.MTZMetaModel.PARTVIEW

        Dim p As MTZJrnl.MTZJrnl.Journal
        p = JJJ.Journal.Item(1)
        pv = model.FindRowObject("PartView", JJJ.JournalSrc.Item(1).PartView)

        If p Is Nothing Or pv Is Nothing Then
            Return
        End If

        ' make journal PHP model
        MakeProjectFile(MakeJPHPModel(JJJ), textBoxOutPutFolder.Text & "models\", "m_v_" & pv.the_Alias.ToLower() & ".php")

        ' make journal PHP controller
        MakeProjectFile(MakeJPHPController(JJJ), textBoxOutPutFolder.Text & "controllers\", "c_v_" & pv.the_Alias.ToLower() & ".php")

        ' make journal JS model
        MakeProjectFile(MakeJ_JSModel(JJJ) & vbCrLf & MakeJ_JSStore(JJJ), textBoxOutPutFolder.Text & "_js\", "s_v_" & pv.the_Alias.ToLower() & ".js")


        ' make journal grid
        MakeProjectFile(MakeJ_JSGrid(JJJ), textBoxOutPutFolder.Text & "_js\", "j_v_" & pv.the_Alias.ToLower() & ".js")


        ' make jurnal filter ???


    End Sub

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        Dim i As Integer
        Dim ti As tmpInst
        Dim sw As StringBuilder





        pb.Minimum = 0
        pb.Maximum = model.OBJECTTYPE.Count
        pb.Value = 0
        pb.Visible = True

        Me.Text = "Generating stores"
        Application.DoEvents()
        sw = New StringBuilder
        'sw.Append(vbCrLf & Combo_Load())

        For i = 1 To model.OBJECTTYPE.Count
            sw.Append(GenStores(model.OBJECTTYPE.Item(i)))
            pb.Value = i
        Next
        MakeProjectFile(sw.ToString(), textBoxOutPutFolder.Text & "_js\", "models.js")

        Me.Text = "Generating enums"
        Application.DoEvents()
        MakeProjectFile(enumStore, textBoxOutPutFolder.Text & "_js\", "enums.js")


        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = chkObjType.CheckedItems.Count
        Me.Text = "Generating types"
        Application.DoEvents()

        pb.Visible = True
        For i = 0 To chkObjType.CheckedItems.Count - 1
            pb.Value = i + 1
            ti = chkObjType.CheckedItems(i)
            GenType(ti.ID)
        Next
        ti = Nothing

        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = chkJournals.CheckedItems.Count
        Me.Text = "Generating journals"
        Application.DoEvents()
        pb.Visible = True
        For i = 0 To chkJournals.CheckedItems.Count - 1
            pb.Value = i + 1
            ti = chkJournals.CheckedItems(i)
            GenJournal(ti.ID)
        Next

        If chkAlterBase.Checked Then
            pb.Minimum = 0
            pb.Value = 0
            pb.Maximum = chkJournals.CheckedItems.Count
            Me.Text = "Generating alterbase"

            sw = New StringBuilder
            Application.DoEvents()
            pb.Visible = True
            For i = 0 To chkJournals.CheckedItems.Count - 1
                pb.Value = i + 1
                ti = chkJournals.CheckedItems(i)
                sw.Append(vbCrLf & GenAlterbase(ti.ID))
                MakeProjectFile(sw.ToString, textBoxOutPutFolder.Text, "alterbase.sql")
            Next
        End If

        If chkMenu.Checked Then
            Me.Text = "Generating menus"
            Application.DoEvents()
            MakeProjectFile(MakeMenu(), textBoxOutPutFolder.Text & "_js\", "menu.js")
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
            chkJournals.SetItemChecked(i, True)
        Next
    End Sub
End Class