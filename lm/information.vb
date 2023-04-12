Imports MySql.Data.MySqlClient
Public Class information
    Public id
    Private Sub information_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim name, email, pass, i


        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "Select * From user where userid='" & id & "' ;"
        '"SELECT * From mything where userid='" & userid & "';"

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
                'DataGridView1.DataSource = BindingSource1

                i = 0

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    'id = dataReader(0).ToString
                    email = dataReader(1).ToString
                    name = dataReader(2).ToString
                    pass = dataReader(3).ToString
                    i = i + 1
                Loop
                dataReader.Close()

                'MsgBox(i)

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

            TextBox1.Text = id.ToString
            TextBox2.Text = email.ToString
            TextBox3.Text = name.ToString



        End Using

    End Sub

    Private Sub revise_Click(sender As Object, e As EventArgs) Handles revise.Click

        TextBox2.Enabled = True
        TextBox3.Enabled = True

        Button1.Visible = True
    End Sub

    'Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    '    Dim name, email, id, pass, i

    '    email = TextBox2.Text
    '    name = TextBox3.Text

    '    Dim ConString As New MySqlConnectionStringBuilder
    '    ConString.Database = "lifemanager" '資料庫名稱為lifemanager
    '    ConString.Server = "127.0.0.1" '資料庫的IP位置
    '    ConString.UserID = "user" '資料庫使用者
    '    ConString.Password = "12345678" '資料庫使用者密碼
    '    ConString.SslMode = MySqlSslMode.None
    '    ConString.AllowZeroDateTime = True

    '    '建立查詢字串
    '    Dim QueryString As String = "Select * From user where userid='" & login.id & "' ;"
    '    '"SELECT * From mything where userid='" & userid & "';"

    '    '建立資料庫連線物件
    '    Using Connection As New MySqlConnection(ConString.ToString)
    '        '建立送入查詢字串物件
    '        Dim MyCommand As MySqlCommand = Connection.CreateCommand()
    '        MyCommand.CommandText = QueryString

    '        Try
    '            '開啟資料庫連線
    '            Connection.Open()

    '            '建立資料表橋接器
    '            Dim Adapter As New MySqlDataAdapter()
    '            '送出給MySql Server 執行的 SQL 指令
    '            Adapter.SelectCommand = MyCommand

    '            Dim qs1 As String = "update user set email='" & email & "',name='" & name & "' where userid='" & login.id & "';"
    '            'INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
    '            Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
    '            cmd.ExecuteNonQuery()

    '            'DataSet可以存放多個表格資料，把資料放到 DataSet1 的第一個表格
    '            Adapter.Fill(DataSet1.Tables(0))

    '            '如果程式操作期間有對DataSet1中的任何資料做修改且需要更新資料庫，則可利用 update 方法把資料送回MySql Server
    '            'Adapter.Update(DataSet1)

    '            '設定繫結資料來源
    '            BindingSource1.DataSource = DataSet1
    '            '設定有繫結作用的資料來源中的哪個表格
    '            BindingSource1.DataMember = DataSet1.Tables(0).ToString
    '            'DataGridView1.DataSource = BindingSource1

    '            i = 0

    '            Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
    '            Do While dataReader.Read()
    '                id = dataReader(0).ToString
    '                email = dataReader(1).ToString
    '                name = dataReader(2).ToString
    '                pass = dataReader(3).ToString
    '                i = i + 1
    '            Loop
    '            dataReader.Close()

    '            'MsgBox(i)

    '        Catch ex As Exception
    '            MsgBox(ex.Message)

    '        Finally
    '            Connection.Close()
    '        End Try

    '        TextBox1.Text = id.ToString
    '        TextBox2.Text = email.ToString
    '        TextBox3.Text = name.ToString

    '        TextBox2.Enabled = False
    '        TextBox3.Enabled = False

    '        PictureBox4.Visible = False
    '    End Using
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        memo.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim name, email, pass, i

        email = TextBox2.Text
        name = TextBox3.Text

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "Select * From user where userid='" & login.id & "' ;"
        '"SELECT * From mything where userid='" & userid & "';"

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

                Dim qs1 As String = "update user set email='" & email & "',name='" & name & "' where userid='" & id & "';"
                'INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
                Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                cmd.ExecuteNonQuery()

                'DataSet可以存放多個表格資料，把資料放到 DataSet1 的第一個表格
                Adapter.Fill(DataSet1.Tables(0))

                '如果程式操作期間有對DataSet1中的任何資料做修改且需要更新資料庫，則可利用 update 方法把資料送回MySql Server
                'Adapter.Update(DataSet1)

                '設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(0).ToString
                'DataGridView1.DataSource = BindingSource1

                i = 0

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    id = dataReader(0).ToString
                    email = dataReader(1).ToString
                    name = dataReader(2).ToString
                    pass = dataReader(3).ToString
                    i = i + 1
                Loop
                dataReader.Close()

                'MsgBox(i)

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

            TextBox1.Text = id.ToString
            TextBox2.Text = email.ToString
            TextBox3.Text = name.ToString

            memo.Label3.Text = "歡迎回來!" & vbCrLf & vbCrLf & "我的主人   " & (name) & vbCrLf & vbCrLf & "請問你想看什麼呢?"

            TextBox2.Enabled = False
            TextBox3.Enabled = False

            Button1.Visible = False
        End Using
    End Sub
    Private Sub 結束工作ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 結束工作ToolStripMenuItem.Click
        Environment.Exit(Environment.ExitCode)
        Application.Exit()
    End Sub
    'Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
    '    e.Cancel = True

    '    Me.components = New System.ComponentModel.Container
    '    Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
    '    NotifyIcon1.Icon = My.Resources.小管家_去背板
    '    NotifyIcon1.Visible = True
    '    Me.Visible = False
    '    NotifyIcon1.ContextMenuStrip = ContextMenuStrip1
    'End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        NotifyIcon1.Visible = False
        Me.Show()
        ' Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class