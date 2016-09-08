Public Class ExtentionControl
    Inherits System.Windows.Forms.UserControl

#Region "Declarations"
    Protected mGUIManager As LATIR2GuiManager.LATIRGuiManager
    Protected mDocItem As LATIR2.Document.Doc_Base
    Protected mAllowEdit As Boolean
    Protected mAllowAdd As Boolean
    Protected mAllowDel As Boolean
    Protected mChanged As Boolean
    Protected mOK As Boolean
#End Region

#Region "Events"
    Public Event Changed()
#End Region

    Public Function GuiManager() As LATIR2GuiManager.LATIRGuiManager
        GuiManager = mGUIManager
    End Function

    Public Function DocItem() As LATIR2.Document.Doc_Base
        DocItem = mDocItem
    End Function

    Public Overridable Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByRef DocItem As LATIR2.Document.Doc_Base, ByVal AllowEdit As Boolean, ByVal AllowAdd As Boolean, ByVal AllowDel As Boolean)
        mGUIManager = gm
        mDocItem = DocItem

        mAllowEdit = AllowEdit
        mAllowAdd = AllowAdd
        mAllowDel = AllowDel

        InitializeComponent()
        InitOnAttach()
        mOK = True
        mChanged = False
    End Sub

    Public Function AllowEdit() As Boolean
        Return mAllowEdit
    End Function
    Public Function AllowAdd() As Boolean
        Return mAllowEdit
    End Function
    Public Function AllowDel() As Boolean
        Return mAllowEdit
    End Function

    Public Overridable Sub SetupFromObject(ByVal SetupObjectID As System.Guid)
        ' do nothing
    End Sub

    Protected Overridable Sub InitOnAttach()

    End Sub

    Public Overridable Function IsOK() As Boolean
        Return mOK
    End Function

    Public Overridable Function Verify(ByVal NoError As Boolean) As Boolean
        Return True
    End Function


    Public Overridable Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean
        If Not (AllowEdit() Or AllowAdd() Or AllowDel()) Then
            Return True
        End If

        If Not IsChanged() Then
            Return True
        End If

        If Not IsOK() Then
            mOK = Verify(NoError)
        End If

        If IsOK() Then
            If Not Sielent Then
                If MsgBox("Cохранить изменения?", MsgBoxStyle.YesNo, "Сохранение данных") = MsgBoxResult.Yes Then
                    If SaveData(NoError) Then
                        mChanged = False
                        Return True
                    Else
                        Return False
                    End If
                End If
            Else
                If SaveData(NoError) Then
                    mChanged = False
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If

    End Function

    Protected Overridable Function SaveData(ByVal NoError As Boolean) As Boolean
        Return True
    End Function

    Public Function IsChanged() As Boolean
        Return mChanged
    End Function

    Protected Sub DataChanged()
        mChanged = True
        mOK = False
        RaiseEvent Changed()
    End Sub

    Protected Sub Refreshed()
        mChanged = False
        mOK = True
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ExtentionControl
        '
        Me.Name = "ExtentionControl"
        Me.Size = New System.Drawing.Size(582, 361)
        Me.ResumeLayout(False)
    End Sub

End Class
