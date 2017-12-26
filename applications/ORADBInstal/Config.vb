Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports Oracle.ManagedDataAccess.Client



Friend Class Form1
	Inherits System.Windows.Forms.Form
	
	Private Path As String
    'Private xdom As MSXML2.DOMDocument
    'Private e As MSXML2.IXMLDOMElement
	'UPGRADE_WARNING: Arrays in structure GenResp may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Private GenResp As LATIRGenerator.Response
    Private GenPrj As LATIRGenerator.ProjectHolder
	Private iListIndex As Integer
	Private bDontClear As Boolean
    Private DS As oraDB
    Private Log As String
    Private sOut As StringBuilder

    Dim n As String
	Dim cnt As Integer
	Dim i As Object
	Dim inClick As Boolean








    Private Sub cmdDataPath_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDataPath.Click
		Dim Path As String
		
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
            If UCase(Trim(lines(i))) = "/" Or i = UBound(lines) Then
                Try
                    If Trim(s) <> "" Then
                        sOut.AppendLine(s)
                        sOut.AppendLine("$$")


                        If DS.QueryExec(s) Then
                            System.Windows.Forms.Application.DoEvents()
                        Else
                            txtLog.Text = txtLog.Text & vbCrLf & b.BlockName & ":" & modulename & vbCrLf & s & vbCrLf & "------------------------" & vbCrLf & DS.lastError

                        End If
                    End If

                Catch ex As Exception
                    txtLog.Text = txtLog.Text & vbCrLf & b.BlockName & ":" & modulename & vbCrLf & s & vbCrLf & "------------------------" & vbCrLf & ex.Message

                End Try

                s = ""

            Else
                s = s & vbCrLf & lines(i)
            End If
cont:
        Next
        pb.Visible = False


    End Sub



    Private Sub cmdGo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGo.Click


        If txtData.Text = "" Then Exit Sub
        sOut = New StringBuilder
        txtLog.Text = ""
        lstBlocks.Items.Clear()
        DS = New oraDB


        If Not DS.Init(txtServer.Text, txtLogin.Text, txtPassword.Text) Then
            MsgBox("Не удается подключиться к ORACLE Server", MsgBoxStyle.Critical)
            DS = Nothing
            Exit Sub
        End If
        SaveSetting("LATIR4", "ORADBINSTALL", "LASTSRV", txtServer.Text)
        Dim cmd As OracleCommand
        cmd = New OracleCommand
        cmd.Connection = CType(DS.dbconnect, OracleConnection)
        cmd.CommandText = "ALTER SESSION SET NLS_COMP=LINGUISTIC"
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        cmd = New OracleCommand
        cmd.Connection = CType(DS.dbconnect, OracleConnection)
        cmd.CommandText = "ALTER SESSION SET NLS_SORT=BINARY_CI"
        cmd.ExecuteNonQuery()
        cmd.Dispose()


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

        If txtLog.Text = "" Then
            MsgBox("Создание базы данных завершено", MsgBoxStyle.Information)
        Else
            MsgBox("Создание базы данных завершено с ошибками", MsgBoxStyle.Critical)
        End If
        DS = Nothing
        GenResp = Nothing
        GenPrj = Nothing
    End Sub
	
	Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		inClick = True
        txtLogin.Text = ""
        txtPassword.Text = ""
        txtServer.Text = GetSetting("LATIR4", "ORADBINSTALL", "LASTSRV", "//localhost/ora")
        Call DisableInvisibleControls()
		inClick = False
	End Sub





    Private Function CheckFolder(ByRef Path As String) As Boolean
		Dim FSO As Object
		
		FSO = CreateObject("Scripting.FileSystemObject")

        If Not FSO.FolderExists(Path) Then
            Call MsgBox("Указанный каталог не существует", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, My.Application.Info.Title)
            CheckFolder = False
        Else
            CheckFolder = True
		End If

        FSO = Nothing
    End Function
	
	Private Function CheckFile(ByRef Path As String) As Boolean
		Dim FSO As Object
		
		FSO = CreateObject("Scripting.FileSystemObject")

        If Not FSO.FileExists(Path) Then
            Call MsgBox("Указанный файл не существует", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, My.Application.Info.Title)
            CheckFile = False
        Else
            CheckFile = True
		End If

        FSO = Nothing
    End Function
	
	
	
	
	Private Sub cmdCancel_Click()
		Me.Close()
		End
	End Sub
	
	Private Sub cmdOK_Click()
		Me.Close()
		End
	End Sub
	
	
	Private Sub DisableInvisibleControls()
		Dim i As Integer
		Dim RealLeft As Integer
		Dim RealTop As Integer
		Dim ContainerControl As Object
		Dim CurrentControl As Object
		Dim TypeNameContainer As String

        For i = 1 To Me.Controls.Count()
            On Error Resume Next
            ' Определим реальные координаты относительно высоту и лево
            CurrentControl = CType(Me.Controls(i), Object)
            RealLeft = CurrentControl.Left
            RealTop = CurrentControl.Top
            ContainerControl = CurrentControl.Container
            TypeNameContainer = UCase(TypeName(ContainerControl))
            If (TypeNameContainer <> "NOTHING") Then
                While TypeNameContainer <> UCase(TypeName(Me)) And (RealLeft >= 0 And RealTop >= 0)
                    RealLeft = RealLeft + ContainerControl.Left
                    RealTop = RealTop + ContainerControl.Top
                    ContainerControl = ContainerControl.Container
                    TypeNameContainer = UCase(TypeName(ContainerControl))
                    If (ContainerControl Is ContainerControl.Container) Then
                        GoTo Wexit
                    End If
                End While
Wexit:
                If (RealLeft < 0) Or (RealTop < 0) Then
                    CurrentControl.TabStop = False
                Else
                    CurrentControl.TabStop = True
                End If
            End If
        Next
    End Sub

    Private Sub frameRight_Enter(sender As Object, e As EventArgs) Handles frameRight.Enter

    End Sub
End Class