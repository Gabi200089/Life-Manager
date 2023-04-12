Imports MySql.Data.MySqlClient
Public Class register
    Public nuser, npass, nuseremail
    Dim x As Integer
    Dim count As Integer

    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label2.BackColor = Color.FromArgb(248, 248, 202)
        Label3.BackColor = Color.FromArgb(248, 248, 202)
        Label4.BackColor = Color.FromArgb(248, 248, 202)
        account.BackColor = Color.FromArgb(248, 248, 202)
        seePassword.BackColor = Color.FromArgb(248, 248, 202)
        Label6.BackColor = Color.FromArgb(248, 248, 202)
        Label8.BackColor = Color.FromArgb(248, 248, 202)
        Label9.BackColor = Color.FromArgb(248, 248, 202)
        'Label5.BackColor = Color.FromArgb(248, 248, 202)
        'Label7.BackColor = Color.FromArgb(248, 248, 202)
        Button1.BackColor = Color.FromArgb(248, 248, 202)
        Button2.BackColor = Color.FromArgb(248, 248, 202)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox3.Visible = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim b As Boolean
        Dim emailrevise As String
        Dim repeat = 1
        Dim nuseremail


        b = TextBox1.Text.Contains("@") And TextBox1.Text.Contains(".com")
        If b = True Then
            nuseremail = TextBox1.Text
            nuser = TextBox2.Text
            npass = passwordTextBox.Text
        Else
            MsgBox("email格式錯誤喔> <|||",, "提示訊息")
            TextBox1.Text = ""
            TextBox2.Text = ""
            passwordTextBox.Text = ""
            Exit Sub
        End If

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From User where email='" & nuseremail & "';"
        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString

            Try
                '開啟資料庫連線
                Connection.Open()

                '建立資料表橋接器
                Dim Adapter As New MySqlDataAdapter()
                '送出給MySql Server 執行的 SQL 指令
                Adapter.SelectCommand = MyCommand

                'DataSet可以存放多個表格資料，把資料放到 DataSet1 的第一個表格
                Adapter.Fill(DataSet1.Tables(0))

                '如果程式操作期間有對DataSet1中的任何資料做修改且需要更新資料庫，則可利用 update 方法把資料送回MySql Server
                'Adapter.Update(DataSet1)

                '設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(0).ToString

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    If nuseremail = dataReader(1) Then
                        MsgBox("此信箱已註冊過，請重新輸入信箱")
                        repeat = 0
                        Exit Do
                    End If

                Loop
                dataReader.Close()

                If repeat = 0 Then
                    TextBox1.Clear()
                    TextBox2.Clear()
                    passwordTextBox.Clear()
                ElseIf repeat = 1 Then

                    Dim qs1 As String = "insert into user(email,name,password)values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & passwordTextBox.Text & "');"
                    Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                    MsgBox("恭喜你註冊成功，請重新登入",, "註冊資訊")
                    TextBox1.Clear()
                    TextBox2.Clear()
                    passwordTextBox.Clear()
                    cmd.ExecuteNonQuery()
                    Me.Close()
                    start.Show()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        passwordTextBox.Text = ""
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If TextBox2.Text.Length > 10 Then
            MsgBox("用戶名稱超過十個字喔!",, "提示訊息")
            TextBox2.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub passwordTextBox_TextChanged(sender As Object, e As EventArgs) Handles passwordTextBox.TextChanged
        If passwordTextBox.Text.Length > 10 Then
            MsgBox("密碼長度要在十個字元以內喔> <|||!",, "提示訊息")
            passwordTextBox.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        passwordTextBox.PasswordChar = "*"
        seePassword.Image = My.Resources.unlock '點一下隱藏密碼
        Label9.Text = "顯示密碼"
        count = 0
        PictureBox3.Visible = True
        start.Show()
        Me.Hide()
    End Sub

    Private Sub seePassword_Click(sender As Object, e As EventArgs) Handles seePassword.Click
        If count = 0 Then
            passwordTextBox.PasswordChar = ""
            seePassword.Image = My.Resources.padlock '點一下顯示密碼
            Label9.Text = "隱藏密碼"
            'passwordTextBox.Text = seepw '顯示密碼
            count += 1
        Else
            passwordTextBox.PasswordChar = "*"
            seePassword.Image = My.Resources.unlock '點一下隱藏密碼
            Label9.Text = "顯示密碼"
            count -= 1
        End If
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
End Class