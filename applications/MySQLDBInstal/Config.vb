Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Text
Imports System.IO

Friend Class Form1
	Inherits System.Windows.Forms.Form
    Private sOut As StringBuilder
	Private Path As String
    Private GenResp As LATIRGenerator.Response
    Private GenPrj As LATIRGenerator.ProjectHolder
	Private iListIndex As Integer
	Private bDontClear As Boolean
	Private DS As DataSource
	Private Log As String
	
	
	Dim n As String
	Dim cnt As Integer
	Dim i As Object
	Dim inClick As Boolean
	

	
	
	
	Private Sub cmdDataPath_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDataPath.Click

		DlgOpen.Title = "Выберите файл с данными"
	
		DlgOpen.CheckFileExists = True
		DlgOpen.CheckPathExists = True
	
        DlgOpen.ShowReadOnly = False
		DlgOpen.DereferenceLinks = False

        DlgOpen.Filter = "XML файлы (*.xml)|*.xml"
		
		DlgOpen.FileName = ""
		
		DlgOpen.ShowDialog()
		
		If DlgOpen.FileName > "" Then
			txtData.Text = DlgOpen.FileName
		End If
		
		
	End Sub
	
    Private Sub execBlock(ByRef b As LATIRGenerator.BlockHolder, ByRef modulename As String)
        Dim s As String
        Dim lines() As String
        Dim i As Integer
        lines = Split(b.BlockCode, vbCrLf, , CompareMethod.Text)
        s = ""
        pb.Minimum = LBound(lines)
        pb.Maximum = UBound(lines)
        pb.Value = LBound(lines)
        pb.Visible = True
        For i = LBound(lines) To UBound(lines)
            pb.Value = i
            lblmsg.Text = i.ToString + " (" + UBound(lines).ToString + ")"
            Application.DoEvents()
            If UCase(Trim(lines(i))) = "GO" Then

                If Trim(s) <> "" Then
                    Try
                        If Not chkNoExec.Checked Then
                            DS.Execute(s)
                            If DS.LastMessage <> "" Then
                                lblmsg.Text = DS.LastMessage
                                Application.DoEvents()
                            End If
                        End If
                       
                        Debug.Print(s)
                        sOut.AppendLine(s)
                        sOut.AppendLine("$$")

                    Catch ex As Exception
                        txtLog.Text = txtLog.Text & vbCrLf & b.BlockName & ":" & modulename & vbCrLf & s & vbCrLf & "------------------------" & vbCrLf & ex.Message
                        Debug.Print(s)
                        Debug.Print(ex.Message)
                        s = ""
                    End Try
                    System.Windows.Forms.Application.DoEvents()

                End If
                s = ""
             
            Else
                s = s & vbCrLf & lines(i)
            End If

        Next
        pb.Visible = False


    End Sub



    Private Sub cmdGo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGo.Click

        If txtData.Text = "" Then Exit Sub
        sOut = New StringBuilder
        sOut.AppendLine("DELIMITER $$")
        txtLog.Text = ""
        lstBlocks.Items.Clear()

        Dim srv As String
        srv = GetSetting("MYSQLDBInstall", "setup", "servers", "")
        If Not srv.Contains(txtServer.Text) Then
            If srv <> "" Then
                srv = srv & ";"
            End If
            srv = srv & txtServer.Text
            SaveSetting("MYSQLDBInstall", "setup", "servers", srv)
        End If

        If Not chkNoExec.Checked Then
            DS = New DataSource
            DS.Server = txtServer.Text
          

            DS.DataBaseName = txtDatabase.Text
            DS.UserName = txtLogin.Text
            DS.Password = txtPassword.Text
            DS.Integrated = False
            If Not DS.ServerLogIn Then
                MsgBox("Не удается подключиться к MySQL", MsgBoxStyle.Critical)
                'UPGRADE_NOTE: Object DS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                DS = Nothing
                Exit Sub
            End If
        End If


        GenResp = New LATIRGenerator.Response
        GenPrj = GenResp.Project
        GenPrj.Load(txtData.Text)

        On Error Resume Next

        Dim i, j As Integer
        For i = 1 To GenPrj.Modules.Count
            For j = 1 To GenPrj.Modules.Item(i).Blocks.Count
                lstBlocks.Items.Add(GenPrj.Modules.Item(i).ModuleName & ":" & GenPrj.Modules.Item(i).Blocks.Item(j).BlockName)
            Next
        Next
        Dim k As Integer
        k = 0
        For i = 1 To GenPrj.Modules.Count
            For j = 1 To GenPrj.Modules.Item(i).Blocks.Count
                'If lstBlocks.Selected(k) = True Then
                execBlock(GenPrj.Modules.Item(i).Blocks.Item(j), (GenPrj.Modules.Item(i).ModuleName))
                lstBlocks.SetItemChecked(k, True)
                k = k + 1
            Next
        Next


        Dim outfile As StreamWriter = New StreamWriter(txtData.Text + "_out.txt")

        outfile.Write(sOut.ToString())

        outfile.Close()

        If chkNoExec.Checked Then

            MsgBox("Формирование скрипта завершено. Файл:" + vbCrLf + txtData.Text + "_out.txt", MsgBoxStyle.Information)


        Else
            If txtLog.Text = "" Then
                MsgBox("Создание базы данных завершено", MsgBoxStyle.Information)
            Else
                MsgBox("Создание базы данных завершено с ошибками", MsgBoxStyle.Critical)
            End If
        End If
        DS = Nothing

        GenResp = Nothing

        GenPrj = Nothing
    End Sub
	
	
	
	
   

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim srv As String
        srv = GetSetting("MYSQLDBInstall", "setup", "servers", "localhost;176.9.120.145")
        Dim s() As String
        s = srv.Split(";")
        Dim i As Integer
        For i = s.GetLowerBound(0) To s.GetUpperBound(0)
            txtServer.Items.Add(s(i))
        Next


    End Sub

    Private Sub lblmsg_Click(sender As System.Object, e As System.EventArgs) Handles lblmsg.Click

    End Sub

    Private Sub cmdClearList_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearList.Click
        SaveSetting("MYSQLDBInstall", "setup", "servers", "localhost")
    End Sub
End Class