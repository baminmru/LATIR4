Imports System.IO
Imports System.Collections.Generic

Public Class GaleryItem
    Public ID As Guid
    Public FilePath As String
    Public Name As String
    Public PrcValue As Integer
    Public PrcVisible As Boolean
    Public Tag As Object        ' additional data
    Public CustomInfo As String       ' text for custom use
End Class

Public Class ImageGallery

    Public Event ImageClick(ByRef Item As GaleryItem)
    Public Event ImageDoubleClick(ByRef Item As GaleryItem)

    Private mpGap As Integer = 10
    Private mPicWidth As Integer = 180
    Private mPicHeight As Integer = 160

    Dim CtrlWidth As Integer
    Dim CtrlHeight As Integer
    Dim XLocation As Integer
    Dim YLocation As Integer

    Dim inResize As Boolean = False




    Private Sub ImgGalery_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If inResize Then Exit Sub
        inResize = True
        CtrlHeight = Me.Height
        CtrlWidth = Me.Width


        ArrangeItems()


        inResize = False
    End Sub
    Private _Directory_Path As String
    Public Property Directorypath() As String
        Get
            Return _Directory_Path
        End Get
        Set(ByVal value As String)

            _Directory_Path = value

        End Set
    End Property


    Public Property PicWidth() As String
        Get
            Return mPicWidth
        End Get
        Set(ByVal value As String)

            mPicWidth = value
            If mPicWidth < 32 Then mPicWidth = 32
            'If mPicWidth > Me.ClientSize.Width / 3 Then
            '    mPicWidth = Me.ClientSize.Width / 3
            'End If
            ArrangeItems()
        End Set
    End Property





    Public Property PicHeight() As String
        Get
            Return mPicHeight
        End Get
        Set(ByVal value As String)

            mPicHeight = value
            If mPicHeight < 32 Then mPicHeight = 32
            'If mPicHeight > Me.ClientSize.Height / 3 Then
            '    mPicHeight = Me.ClientSize.Height / 3
            'End If

            ArrangeItems()
        End Set
    End Property


    Public Property PGap() As String
        Get
            Return mpGap
        End Get
        Set(ByVal value As String)

            mpGap = value
            If mpGap < 5 Then mPicHeight = 5
            If mpGap > 64 Then
                mpGap = 64
            End If

            ArrangeItems()
        End Set
    End Property


    Private mTextColor As Color = Color.Blue
    Public Property TextColor() As Color
        Get
            Return mTextColor
        End Get
        Set(ByVal value As Color)

            mTextColor = value

            ArrangeItems()
        End Set
    End Property

    Dim picIndex As Integer = 0

    Private Sub DrawPictureBox(ByVal _filename As String, ByVal _displayname As String, ByVal ID As Guid, ByVal GaugeVisible As Boolean, Optional ByVal prcVal As Integer = -1)
        Dim gp As gPic.GaugePicture
        gp = New gPic.GaugePicture()
        With gp.Data
            .ID = ID
            .FilePath = _filename
            .Name = _displayname
            .PrcValue = prcVal
        End With

        gp.Name = "GaugePicture" & picIndex
        gp.Size = New System.Drawing.Size(PicWidth, PicHeight)
        gp.TabStop = False
        gp.BorderStyle = BorderStyle.Fixed3D
        gp.TabIndex = picIndex
        gp.Location = New System.Drawing.Point(XLocation, YLocation)
        XLocation = XLocation + PicWidth + pGap
        If XLocation + PicWidth >= CtrlWidth Then
            XLocation = pGap
            YLocation = YLocation + PicHeight + pGap
        End If

        picIndex += 1

        gp.gName.Text = _displayname
        Me.ToolTip1.SetToolTip(gp, _displayname)
        Me.ToolTip1.SetToolTip(gp.gPicture, _displayname)

        AddHandler gp.MouseEnter, AddressOf Pic1_MouseEnter
        AddHandler gp.MouseLeave, AddressOf Pic1_MouseLeave
        AddHandler gp.Click, AddressOf Pic1_Click
        AddHandler gp.DoubleClick, AddressOf Pic1_DoubleClick

        Me.Controls.Add(gp)
        If GaugeVisible Then
            gp.gPBar.Visible = True
            gp.gPBar.Maximum = 100
            gp.gPBar.Minimum = 0
            If prcVal = -1 Then
                Dim r As Random
                r = New Random
                gp.gPBar.Value = r.Next Mod 101

            Else
                gp.gPBar.Value = prcVal Mod 101
            End If

            Me.ToolTip1.SetToolTip(gp.gPBar, gp.gPBar.Value.ToString() + "%")
        Else
            gp.gPBar.Visible = False
        End If

        gp.gPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        gp.gPicture.Image = Image.FromFile(_filename)


    End Sub




    Private Sub DrawPictureBox(ByRef _gi As GaleryItem)
        Dim gp As gPic.GaugePicture
        gp = New gPic.GaugePicture()
        gp.Data = _gi

        gp.Name = "GaugePicture" & picIndex
        gp.Size = New System.Drawing.Size(PicWidth, PicHeight)
        gp.TabStop = False
        gp.BorderStyle = BorderStyle.Fixed3D
        gp.TabIndex = picIndex
        gp.Location = New System.Drawing.Point(XLocation, YLocation)
        XLocation = XLocation + PicWidth + PGap
        If XLocation + PicWidth >= CtrlWidth Then
            XLocation = PGap
            YLocation = YLocation + PicHeight + PGap
        End If

        picIndex += 1

        gp.gName.Text = _gi.Name
        Me.ToolTip1.SetToolTip(gp, _gi.Name)
        Me.ToolTip1.SetToolTip(gp.gPicture, _gi.Name)

        AddHandler gp.MouseEnter, AddressOf Pic1_MouseEnter
        AddHandler gp.MouseLeave, AddressOf Pic1_MouseLeave
        AddHandler gp.Click, AddressOf Pic1_Click
        AddHandler gp.DoubleClick, AddressOf Pic1_DoubleClick

        Me.Controls.Add(gp)
        If _gi.PrcVisible Then
            gp.gPBar.Visible = True
            gp.gPBar.Maximum = 100
            gp.gPBar.Minimum = 0
            If _gi.PrcValue >= 0 And _gi.PrcValue <= 100 Then
                gp.gPBar.Value = _gi.PrcValue
            End If

            Me.ToolTip1.SetToolTip(gp.gPBar, gp.gPBar.Value.ToString() + "%")
        Else
            gp.gPBar.Visible = False
        End If

        gp.gPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        If gp.gPicture.Image IsNot Nothing Then
            gp.gPicture.Image.Dispose()
        End If
        If File.Exists(_gi.FilePath) Then
            gp.gPicture.Image = Image.FromFile(_gi.FilePath)
        Else
            ' MsgBox("Файл отсутствует:" & _gi.FilePath)

        End If



    End Sub


    Private Sub UpdatePictureBox(gp As gPic.GaugePicture, gi As GaleryItem)
        Me.ToolTip1.SetToolTip(gp, gi.Name)
        Me.ToolTip1.SetToolTip(gp.gPicture, gi.Name)
        gp.GName.Text = gi.Name
        If gi.PrcValue >= 0 And gi.PrcValue <= 100 Then
            gp.gPBar.Value = gi.PrcValue
        End If


    End Sub

    Private gItems As List(Of GaleryItem)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.AutoScaleMode = AutoScaleMode.None
    End Sub

    Public Sub CreateGallery(ByVal ImagePath As String, Optional UseGauge As Boolean = False)
        Directorypath = ImagePath
        If Directorypath IsNot Nothing Then
            If IO.Directory.Exists(Directorypath) Then
                gItems = New List(Of GaleryItem)
                Dim gi As GaleryItem
                Dim di As New IO.DirectoryInfo(Directorypath)
                Dim diar1 As IO.FileInfo() = di.GetFiles("*.jpg").Concat(di.GetFiles("*.bmp")).Concat(di.GetFiles("*.png")).Concat(di.GetFiles("*.gif")).ToArray
                Dim dra As IO.FileInfo
                For Each dra In diar1
                    gi = New GaleryItem
                    gi.ID = Guid.NewGuid
                    gi.FilePath = dra.FullName
                    gi.Name = dra.Name
                    gi.PrcVisible = UseGauge
                    gi.PrcValue = 0
                    gItems.Add(gi)

                Next
                DrawItems(gItems)
            End If
        End If

    End Sub



    Public Sub DrawItems(gi As List(Of GaleryItem))
        If gItems Is Nothing Then
            gItems = gi
        Else
            If Not gItems.Equals(gi) Then
                gItems = gi
            End If
        End If


        picIndex = 0
        RemoveControls()
        XLocation = PGap
        YLocation = PGap

        Dim git As GaleryItem
        For Each git In gi
            'DrawPictureBox(git.FilePath, git.Name, git.ID, git.PrcVisible, git.PrcValue)
            DrawPictureBox(git)
        Next

    End Sub



    Public Sub ArrangeItems()
        Dim gp As gPic.GaugePicture

        XLocation = PGap
        YLocation = PGap
        Me.Visible = False
        For Each gp In Me.Controls
            gp.gName.ForeColor = TextColor
            gp.Location = New System.Drawing.Point(XLocation, YLocation)
            gp.Size = New System.Drawing.Size(PicWidth, PicHeight)
            XLocation = XLocation + PicWidth + PGap
            If XLocation + PicWidth >= CtrlWidth Then
                XLocation = PGap
                YLocation = YLocation + PicHeight + PGap
            End If

        Next
        Me.Visible = True

    End Sub




    Private Sub Pic1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pic As gPic.GaugePicture
        Pic = sender

    End Sub
    Private Sub Pic1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pic As gPic.GaugePicture
        Pic = sender

    End Sub


    Private Sub Pic1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pic As gPic.GaugePicture
        Pic = sender
        RaiseEvent ImageClick(Pic.Data)
        UpdatePictureBox(Pic, Pic.Data)

    End Sub

    Private Sub Pic1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pic As gPic.GaugePicture
        Pic = sender
        'MsgBox("DoubleClick: " & Pic.ID.ToString() & " (" & Pic.Name & ")")
        RaiseEvent ImageDoubleClick(Pic.Data)
        UpdatePictureBox(Pic, Pic.Data)
    End Sub

    Private Sub RemoveControls()
        Dim gpic As GaugePicture
        Dim c As Control
        For Each c In Me.Controls
            Try
                gpic = c
                If gpic.gPicture.Image IsNot Nothing Then
                    gpic.gPicture.Image.Dispose()
                End If
            Catch ex As Exception

            End Try

        Next
        Me.Controls.Clear()
    End Sub

    Protected Overrides Sub Finalize()
        RemoveControls()
        MyBase.Finalize()
    End Sub
End Class
