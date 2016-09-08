Imports LATIR2

Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing


Public Class LATIRGuiManager
    Private mUserName As String
    Private mManager As LATIR2.Manager
    Dim mOpenGUI As LoadedGUIs

    Dim mCurSite As String
    Dim mTempFiles As Collection
    Private GetObjCnt As Long
    Public DLLPath As String

    Public Function UserName() As String
        UserName = mUserName
    End Function

    Public Function Attach(ByVal Manager As LATIR2.Manager) As Boolean
        mManager = Manager
    End Function

    Public Function Manager() As LATIR2.Manager
        If mManager Is Nothing Then
            mManager = New LATIR2.Manager
        End If
        Manager = mManager
    End Function

    Public Function Login(Optional ByRef UserName As String = "", Optional ByRef UserSiteName As String = "") As Boolean
        Dim f As frmLogin
        Login = False
        f = New frmLogin
again:
        f.Manager = Manager()
        f.txtUser.Text = UserName
        f.PreviousSiteName = UserSiteName
        f.cmbProfile.SelectedItem = UserSiteName
        If f.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Manager.Site = f.cmbProfile.Text
            If Manager.Session.Login(f.txtUser.Text, f.txtPassword.Text) <> True Then
                GoTo again
            End If
            mUserName = f.txtUser.Text
            UserName = f.txtUser.Text
            UserSiteName = f.cmbProfile.Text
            f = Nothing
            Login = True
            Exit Function
        End If
        Login = False
    End Function

    Public Function GetReferenceDialog(ByVal PartName As String, ByVal Filter As String, ByVal InstanceID As System.Guid, ByRef ID As System.Guid, ByRef Brief As String) As Boolean
        Dim f As frmRefDialog
        f = New frmRefDialog
        If InstanceID.Equals(System.Guid.Empty) Then
            f.Attach(Me, PartName, Filter)
        Else
            f.InstanceID = InstanceID
            f.Attach(Me, PartName, Filter)
        End If

        If f.ShowDialog = DialogResult.OK Then
            ID = f.ID
            Brief = f.Brief
            f = Nothing
            Return True
        End If
        f = Nothing
        Return False
    End Function

    Public Function GetObjectDialog(ByVal TypeName As String, ByVal Filter As String, ByRef ID As System.Guid, ByRef Brief As String) As Boolean
        Dim f As frmObjectDialog
        f = New frmObjectDialog
        f.Attach(Me, TypeName, Filter)
        If f.ShowDialog = DialogResult.OK Then
            ID = f.ID
            Brief = f.Brief
            f = Nothing
            Return True
        End If
        f = Nothing
        Return False
    End Function

    Public Function GetTypeGUI(ByVal TypeName As String, Optional ByVal Root As String = "") As Doc_GUIBase
        Dim lgui As LoadedGUI
        If mOpenGUI Is Nothing Then
            mOpenGUI = New LoadedGUIs
        End If
        lgui = mOpenGUI.Item(TypeName)
        If lgui Is Nothing Then
            lgui = mOpenGUI.Add(TypeName)
            lgui.GUI = GetDoc(TypeName, Root)
            If (Not lgui.GUI Is Nothing) Then
                lgui.GUI.Attach(Me)
            End If
        End If
        Return lgui.GUI
    End Function

    Private Function CreateDLLName(ByVal Path As String, ByVal name As String) As String
        Dim result As String = String.Empty
        If Path <> String.Empty Then
            If (Not Path.EndsWith("\")) Then
                Path += "\"
            End If
            result = Path + name + "GUI.dll"
            If (Not File.Exists(result)) Then
                result = String.Empty
            End If
        End If
        Return result
    End Function

    Protected Function GetDoc(ByVal name As String, Optional ByVal Root As String = "") As Doc_GUIBase

        Dim funcAssembly As Doc_GUIBase = Nothing
        Dim asm As System.Reflection.Assembly = Nothing

        Try
            Dim FileName As String = CreateDLLName(DLLPath, name)
            If FileName <> String.Empty Then
                Try
                    asm = System.Reflection.Assembly.LoadFrom(FileName)
                Catch ex As Exception

                End Try
            End If
            If asm Is Nothing Then
                FileName = CreateDLLName(Root, name)
                If FileName <> String.Empty Then
                    Try
                        asm = System.Reflection.Assembly.LoadFrom(FileName)
                    Catch ex As Exception
                    End Try
                End If
            End If
            If asm Is Nothing Then
                Try
                    Dim tempName As String = String.Empty
                    tempName = Me.GetType().Assembly.Location
                    tempName = tempName.Substring(0, tempName.LastIndexOf("\"))
                    FileName = CreateDLLName(tempName, name)
                    If (FileName <> String.Empty) Then
                        asm = System.Reflection.Assembly.LoadFrom(FileName)
                    End If
                Catch ex As System.Exception
                    Try
                        asm = System.Reflection.Assembly.LoadFrom(name & "gui.dll")
                    Catch e1 As System.Exception
                        Try
                            funcAssembly = CType(System.Activator.CreateInstance(name & "GUI", "GUI").Unwrap(), Doc_GUIBase)
                        Catch e2 As System.Exception
                            Return Nothing
                        End Try

                    End Try
                End Try
            End If
            If (funcAssembly Is Nothing) Then
                Dim obj As Object = Nothing
                Try
                    obj = asm.CreateInstance(name & "GUI.GUI")
                Catch
                End Try
                If (obj Is Nothing) Then
                    Try
                        obj = asm.CreateInstance(name & ".GUI")
                    Catch
                    End Try
                End If
                If (obj Is Nothing) Then
                    Try
                        obj = asm.CreateInstance("GUI")
                    Catch
                    End Try
                End If
                If (Not obj Is Nothing) Then
                    funcAssembly = CType(obj, Doc_GUIBase)
                End If
            End If
        Catch
        End Try
        Return funcAssembly
    End Function


    Public Sub RegisterGUI(ByRef GUIClass As Doc_GUIBase, ByVal TypeName As String)
        Dim lgui As LoadedGUI
        If mOpenGUI Is Nothing Then
            mOpenGUI = New LoadedGUIs
        End If
        lgui = mOpenGUI.Item(TypeName)
        If lgui Is Nothing Then
            lgui = mOpenGUI.Add(TypeName)
            lgui.GUI = GUIClass
            GUIClass.Attach(Me)
        End If
    End Sub

    Public Function ShowEditForm(ByVal Mode As String, ByRef RowItem As LATIR2.Document.DocRow_Base) As Boolean
        Dim TypeName As String
        Dim bgui As Doc_GUIBase
        TypeName = Manager.Session.TableToType(RowItem.PartName())
        bgui = GetTypeGUI(TypeName)
        bgui.ShowPartEditForm(Mode, RowItem)
    End Function

    Public Shared Sub ScaleForm(ByRef Frm As Form)

        Dim sizefOld As SizeF = Frm.GetAutoScaleSize(Frm.Font)
        Dim MyScale As Integer
        MyScale = Integer.Parse(GetSetting("LATIR4", "CFG", "SCALE", "10"))
        Frm.Font = New Font(Frm.Font.FontFamily, MyScale)
        Dim sizefNew As SizeF = Frm.GetAutoScaleSize(Frm.Font)
        Frm.Scale(sizefNew.Width / sizefOld.Width, sizefNew.Height / sizefOld.Height)


        Frm.StartPosition = FormStartPosition.Manual

        If Frm.Width > Screen.GetWorkingArea(New Point(Frm.Top, Frm.Left)).Width Then Frm.Width = Screen.GetWorkingArea(New Point(Frm.Top, Frm.Left)).Width
        If Frm.Height > Screen.GetWorkingArea(New Point(Frm.Top, Frm.Left)).Height Then Frm.Height = Screen.GetWorkingArea(New Point(Frm.Top, Frm.Left)).Height

        Frm.Left = (Screen.GetWorkingArea(New Point(Frm.Top, Frm.Left)).Width - Frm.Width) / 2
        Frm.Top = (Screen.GetWorkingArea(New Point(Frm.Top, Frm.Left)).Height - Frm.Height) / 2
        If Frm.Left < 0 Then Frm.Left = 0
        If Frm.Top < 0 Then Frm.Top = 0
    End Sub

End Class
