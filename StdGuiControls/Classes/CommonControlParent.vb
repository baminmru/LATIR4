Public Class CommonControlParent
    Inherits System.Windows.Forms.UserControl

#Region "Declarations"
    Protected mGUIManager As LATIR2GuiManager.LATIRGuiManager
    Protected mPartName As String
    Private mLabelCaption As Label
    Private mLabelPanel As Panel
#End Region

#Region "Attach, inits"
    Public Function GuiManager() As LATIR2GuiManager.LATIRGuiManager
        GuiManager = mGUIManager
    End Function

    Public Overridable Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal partName As String, ByVal MasterControlCaption As String, ByVal ChildControlCaption As String)
        mGUIManager = gm
        mPartName = partName
        Caption = MasterControlCaption
    End Sub

    Public Property LabelCaption() As Label
        Get
            Return mLabelCaption
        End Get
        Set(ByVal Value As Label)
            mLabelCaption = Value
            If (Not mLabelCaption Is Nothing) Then
                If (Not mLabelCaption.Parent Is Nothing) Then
                    If (TypeOf (mLabelCaption.Parent) Is Panel) Then
                        mLabelPanel = mLabelCaption.Parent
                    End If
                End If
            End If
        End Set
    End Property

    Public Property Caption() As String
        Get
            If (Not LabelCaption Is Nothing) Then
                Return LabelCaption.Text
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal Value As String)
            If (Not Value Is Nothing) Then
                Value = Value.Trim()
                If Value <> String.Empty Then
                    LabelCaption.Text = Value
                    If (Not mLabelPanel Is Nothing) Then
                        mLabelPanel.Visible = True
                    End If
                    LabelCaption.Visible = True
                Else
                    If (Not LabelCaption Is Nothing) Then
                        LabelCaption.Text = String.Empty
                        LabelCaption.Visible = False
                    End If
                    If (Not mLabelPanel Is Nothing) Then
                        mLabelPanel.Visible = False
                    End If
                End If
            End If
        End Set
    End Property

    Protected ReadOnly Property PartName() As String
        Get
            Return mPartName
        End Get
    End Property

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'CommonControlParent
        '
        Me.Name = "CommonControlParent"
        Me.ResumeLayout(False)

    End Sub
#End Region

End Class
