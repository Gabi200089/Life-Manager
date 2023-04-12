Public Class memo
    Dim timestr As String
    Dim notestr As String
    Dim Thismomentstr As String
    Dim Thismoment As Date
    Private Sub memo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(login.id & "123")
        'MsgBox(login.name & "123")
        'MsgBox(Name)
        ' MsgBox(login.name)
        information.id = login.id
        mything.id = login.id
        'Label3.Text = "歡迎回來!" & vbCrLf & vbCrLf & "我的主人   " & (login.name) & vbCrLf & vbCrLf & "請問你想看什麼呢?"

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, PictureBox3.Click
        memorandum.Show()
        Me.Hide()
    End Sub

    Private Sub shopping_list_Click(sender As Object, e As EventArgs) Handles shopping_list.Click, PictureBox5.Click
        shoppinglist.Show()
        Me.Hide()
    End Sub

    Private Sub my_thing_Click(sender As Object, e As EventArgs) Handles my_thing.Click, PictureBox4.Click
        mything.Show()
        Me.Hide()
    End Sub

    Private Sub member_data_Click(sender As Object, e As EventArgs) Handles member_data.Click
        information.Show()
        Me.Hide()
    End Sub

    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        login.Close()
        Me.Close()
        start.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'timestr = TextBox1.Text
        'notestr = TextBox2.Text
    End Sub
    Private Sub 結束工作ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 結束工作ToolStripMenuItem.Click
        Environment.Exit(Environment.ExitCode)
        Application.Exit()
    End Sub
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        e.Cancel = True

        Me.components = New System.ComponentModel.Container
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        NotifyIcon1.Icon = My.Resources.小管家_去背板
        NotifyIcon1.Visible = True
        Me.Visible = False
        NotifyIcon1.ContextMenuStrip = ContextMenuStrip1
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        NotifyIcon1.Visible = False
        Me.Show()
        ' Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    'Private Sub forever_Tick(sender As Object, e As EventArgs) Handles forever.Tick
    '    ThisMoment = Now
    '    Thismomentstr = Format(Now(), "YYYY/MM/DD H:MM")
    '    If Thismomentstr = timestr Then
    '        forever.Enabled = False
    '        NotifyIcon1.Visible = True
    '        NotifyIcon1.ShowBalloonTip(5000, "提醒!!!", notestr, ToolTipIcon.Info) '專注輔助不可以開!!!!!!!!
    '    End If
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'Panel2.Show()
    End Sub
End Class