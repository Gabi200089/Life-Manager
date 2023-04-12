Public Class start
    Dim i As Integer = 0
    Private Sub start_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Dim frm1 = New login
        'frm1.Show()
        login.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim frm1 = New register
        'frm1.Show()
        register.Show()
        Me.Hide()
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i = i + 1
        If i > 5 Then
            i = 5
            Timer1.Enabled = False
        End If
        PictureBox1.Image = Image.FromFile((Application.StartupPath & "\開門\老劉開門" & i & ".png"))
    End Sub


End Class