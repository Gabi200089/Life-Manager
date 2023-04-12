Imports MySql.Data.MySqlClient
Public Class shoppinglist
    Dim tid(1000) As Integer

    Public Sub shoppinglist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newlist()
    End Sub
    '   Dim         Dim name(1000) As String
    Dim amount(1000) As Integer

    Private Function newlist()
        Dim i As Integer = 0
        Dim j = 0
        Dim name(1000) As String
        Dim amount(1000) As Integer
        Dim title(1) As Label

        title(0) = New Label
        title(0).Size = New Size(56, 28)
        title(0).Location = New Point(73, 12)
        title(0).Text = "名稱"
        title(0).BackColor = BackColor.White
        title(0).Font = New Font("微軟正黑體", 16, FontStyle.Bold)
        title(0).Visible = True

        title(1) = New Label
        title(1).Size = New Size(56, 28)
        title(1).Location = New Point(183, 12)
        title(1).Text = "數量"
        title(1).BackColor = BackColor.White
        title(1).Font = New Font("微軟正黑體", 16, FontStyle.Bold)
        title(1).Visible = True

        Me.Panel1.Controls.Add(title(0))
        Me.Panel1.Controls.Add(title(1))

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "Select * From shoppinglist where userid='" & login.id & "' ;"
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



                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    name(i) = dataReader(2).ToString
                    amount(i) = dataReader(3).ToString
                    tid(i) = dataReader(0).ToString
                    i = i + 1
                Loop
                dataReader.Close()

                'MsgBox(i)

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

        End Using

        'MsgBox(i)

        Dim na(i) As CheckBox
        Dim aa(i) As Label   '建立按鈕矩陣並將矩陣實體化
        Dim p(i) As Button


        For j = 0 To i - 1
            na(j) = New CheckBox
            aa(j) = New Label
            p(j) = New Button

            'checkbox
            na(j).Text = name(j)
            na(j).Width = 50
            na(j).Top = 50 + na(j).Height * j * 1.5
            na(j).Left = 60
            na(j).Font = New Font("微軟正黑體", 14)
            na(j).AutoSize = True
            na(j).Tag = j

            '數量
            aa(j).AutoSize = True
            aa(j).Text = amount(j)
            aa(j).Top = 51 + na(j).Height * j * 1.5
            aa(j).Left = 200
            aa(j).Font = New Font("微軟正黑體", 14)

            '修改
            p(j).BackColor = Color.Transparent
            p(j).Height = 15
            p(j).Width = 15
            p(j).Top = 55 + na(j).Height * j * 1.5
            p(j).Left = 255
            p(j).BackgroundImage = My.Resources.edit
            p(j).FlatStyle = FlatStyle.Flat
            p(j).BackgroundImageLayout = ImageLayout.Stretch
            p(j).FlatAppearance.BorderSize = 0
            p(j).FlatAppearance.MouseDownBackColor = Color.SandyBrown
            p(j).FlatAppearance.MouseOverBackColor = Color.PeachPuff
            p(j).Tag = j


            'labelarray(i).Top = j2         '按鈕生成垂直座標
            'labelarray(i).Left = j3 + labelarray(i).Width * i * j                '按鈕生成水平座標

            'j = j + 1
        Next


        j = 0
        While j <> i

            Panel1.Controls.Add((na(j)))
            Panel1.Controls.Add((aa(j)))
            Panel1.Controls.Add((p(j))) '加入按鈕 （Controls用法請參照延伸閱讀）
            AddHandler p(j).Click, AddressOf p_Click
            AddHandler na(j).CheckedChanged, AddressOf na_checkedchanged

            j += 1
        End While
    End Function
    Private Function searchlist()
        Me.Panel1.Controls.Clear()
        Dim i As Integer = 0
        Dim j = 0
        Dim name(1000) As String
        Dim amount(1000) As Integer
        Dim title(1) As Label

        title(0) = New Label
        title(0).Size = New Size(56, 28)
        title(0).Location = New Point(73, 12)
        title(0).Text = "名稱"
        title(0).BackColor = BackColor.White
        title(0).Font = New Font("微軟正黑體", 16, FontStyle.Bold)
        title(0).Visible = True

        title(1) = New Label
        title(1).Size = New Size(56, 28)
        title(1).Location = New Point(183, 12)
        title(1).Text = "數量"
        title(1).BackColor = BackColor.White
        title(1).Font = New Font("微軟正黑體", 16, FontStyle.Bold)
        title(1).Visible = True


        Me.Panel1.Controls.Add(title(0))
        Me.Panel1.Controls.Add(title(1))

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "SELECT * From shoppinglist where (userid='" & login.id & "')and(name like '%" & TextBox5.Text & "%');"
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



                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    name(i) = dataReader(2).ToString
                    amount(i) = dataReader(3).ToString
                    tid(i) = dataReader(0).ToString
                    i = i + 1
                Loop
                dataReader.Close()

                'MsgBox(i)

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

        End Using

        'MsgBox(i)

        Dim na(i) As CheckBox
        Dim aa(i) As Label   '建立按鈕矩陣並將矩陣實體化
        Dim p(i) As Button


        For j = 0 To i - 1
            na(j) = New CheckBox
            aa(j) = New Label
            p(j) = New Button

            'checkbox
            na(j).Text = name(j)
            na(j).Width = 50
            na(j).Top = 50 + na(j).Height * j * 1.5
            na(j).Left = 60
            na(j).Font = New Font("微軟正黑體", 14)
            na(j).AutoSize = True
            na(j).Tag = j

            '數量
            aa(j).AutoSize = True
            aa(j).Text = amount(j)
            aa(j).Top = 51 + na(j).Height * j * 1.5
            aa(j).Left = 200
            aa(j).Font = New Font("微軟正黑體", 14)

            '修改
            p(j).BackColor = Color.Transparent
            p(j).Height = 15
            p(j).Width = 15
            p(j).Top = 55 + na(j).Height * j * 1.5
            p(j).Left = 255
            p(j).BackgroundImage = My.Resources.edit
            p(j).FlatStyle = FlatStyle.Flat
            p(j).BackgroundImageLayout = ImageLayout.Stretch
            p(j).FlatAppearance.BorderSize = 0
            p(j).FlatAppearance.MouseDownBackColor = Color.SandyBrown
            p(j).FlatAppearance.MouseOverBackColor = Color.PeachPuff
            p(j).Tag = j


            'labelarray(i).Top = j2         '按鈕生成垂直座標
            'labelarray(i).Left = j3 + labelarray(i).Width * i * j                '按鈕生成水平座標

            'j = j + 1
        Next


        j = 0
        While j <> i

            Panel1.Controls.Add((na(j)))
            Panel1.Controls.Add((aa(j)))
            Panel1.Controls.Add((p(j))) '加入按鈕 （Controls用法請參照延伸閱讀）
            AddHandler p(j).Click, AddressOf p_Click
            AddHandler na(j).CheckedChanged, AddressOf na_checkedchanged

            j += 1
        End While
    End Function
#Region "偵測為哪筆資料"
    Public Sub p_Click(sender As Object, e As EventArgs)
        Dim target As Button = CType(sender, Button)
        Dim index As Integer
        Dim i, n, a, t

        'Label5.Text = target.Tag
        Panel2.Visible = True

        t = tid(target.Tag)

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From shoppinglist where tid='" & t & "';"
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

                Adapter.Fill(DataSet1.Tables(1))

                '設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(1).ToString
                '    'DataGridView 跟 ComboBox 透過 BindingSource做繫結，之後兩者的資料會連動，也就是在ComboBox選擇某資料項 DataGridView 會將該筆資料反藍，反之亦然
                'DataGridView1.DataSource = BindingSource1

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    n = dataReader(2).ToString
                    a = dataReader(3).ToString
                    'ComboBox1.Items.Add(dataReader(0))
                Loop
                dataReader.Close()

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using

        TextBox1.Text = n
        TextBox2.Text = a

    End Sub
#End Region

#Region "修改"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim target As Button = CType(sender, Button)
        Dim index As Integer
        Dim i, n, a, t

        'Label5.Text = target.Tag

        t = tid(target.Tag)
        MsgBox(t)

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From shoppinglist where tid='" & t & "';"
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



                Dim qs1 As String = "update shoppinglist set name='" & TextBox1.Text & "',amount='" & TextBox2.Text & "'where tid='" & t & "';"
                'INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
                Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                cmd.ExecuteNonQuery()

                Adapter.Fill(DataSet1.Tables(0))

                '設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(0).ToString
                '    'DataGridView 跟 ComboBox 透過 BindingSource做繫結，之後兩者的資料會連動，也就是在ComboBox選擇某資料項 DataGridView 會將該筆資料反藍，反之亦然
                'DataGridView1.DataSource = BindingSource1

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    n = dataReader(2).ToString
                    a = dataReader(3).ToString
                    'ComboBox1.Items.Add(dataReader(0))
                Loop
                dataReader.Close()

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using

        TextBox1.Text = n
        TextBox2.Text = a
        Panel2.Visible = False

        Me.Controls.Clear()
        InitializeComponent() 'load all the controls again
        shoppinglist_Load(e, e)
    End Sub
#End Region

#Region "刪除"
    Public Sub na_checkedchanged(sender As Object, e As EventArgs)
        Dim target As CheckBox = CType(sender, CheckBox)
        Dim index As Integer
        Dim name(1000) As String
        Dim amount(1000) As Integer
        Dim i, t
        Dim n, m, answer

        t = tid(target.Tag)

        If target.Checked = True Then
            answer = MsgBox("確定要刪除嗎？", MsgBoxStyle.YesNo, "刪除")
        End If

        If answer = MsgBoxResult.Yes Then

            'Label5.Text = target.Tag



            Dim ConString As New MySqlConnectionStringBuilder
            ConString.Database = "lifemanager" '資料庫名稱為lifemanager
            ConString.Server = "127.0.0.1" '資料庫的IP位置
            ConString.UserID = "user" '資料庫使用者
            ConString.Password = "12345678" '資料庫使用者密碼
            ConString.SslMode = MySqlSslMode.None
            ConString.AllowZeroDateTime = True

            '建立查詢字串
            Dim QueryString As String = "SELECT * From shoppinglist where userid='" & login.id & "';"
            ' "delete From mything where mything.thingid='" & Form3.thingid & "';"

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

                    Dim qs1 As String = "delete from shoppinglist where tid='" & t & "';"

                    Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                    cmd.ExecuteNonQuery()

                    Adapter.Fill(DataSet1.Tables(0))
                    'Adapter.Update(Form3.DataSet1.Tables(0))


                    ''設定繫結資料來源
                    BindingSource1.DataSource = DataSet1
                    '    '設定有繫結作用的資料來源中的哪個表格
                    BindingSource1.DataMember = DataSet1.Tables(0).ToString
                    'DataGridView1.DataSource = BindingSource1

                    For i = 0 To 1000
                        name(i) = ""
                        amount(i) = 0
                        tid(i) = 0
                    Next

                    i = 0

                    Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                    Do While dataReader.Read()
                        name(i) = dataReader(2).ToString
                        amount(i) = dataReader(3).ToString
                        tid(i) = dataReader(0).ToString
                        i = i + 1
                        'ComboBox1.Items.Add(dataReader(0))
                    Loop
                    dataReader.Close()



                    MsgBox("刪除成功")
                Catch ex As Exception
                    MsgBox(ex.Message)

                Finally
                    Connection.Close()
                End Try

            End Using

            Me.Controls.Clear()
            InitializeComponent() 'load all the controls again
            shoppinglist_Load(e, e)

        ElseIf answer = MsgBoxResult.No Then

            target.Checked = False
            target.CheckState = CheckState.Unchecked
            Exit Sub
        End If

    End Sub
#End Region

#Region "新增"
    'Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    '    Panel3.Visible = True

    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From shoppinglist where userid='" & login.id & "';"
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

                Dim qs1 As String = "insert into shoppinglist(userid,name,amount)values('" & login.id & "','" & TextBox4.Text & "','" & TextBox3.Text & "');"
                'INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
                Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                cmd.ExecuteNonQuery()

                Adapter.Fill(DataSet1.Tables(0))

                '設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(0).ToString
                '    'DataGridView 跟 ComboBox 透過 BindingSource做繫結，之後兩者的資料會連動，也就是在ComboBox選擇某資料項 DataGridView 會將該筆資料反藍，反之亦然
                'DataGridView1.DataSource = BindingSource1

                'Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                'Do While dataReader.Read()
                '    bmt(i) = dataReader(2).ToString
                '    t(i) = dataReader(3).ToString
                '    md(i) = dataReader(0).ToString
                '    i = i + 1
                '    'ComboBox1.Items.Add(dataReader(0))
                'Loop
                'dataReader.Close()

                'MsgBox("輸入成功")


            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()

            End Try
        End Using

        TextBox4.Clear()
        TextBox3.Clear()
        Panel3.Visible = False

        Me.Controls.Clear()
        InitializeComponent() 'load all the controls again
        shoppinglist_Load(e, e)

    End Sub
#End Region

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel3.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        memo.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Panel3.Visible = True
    End Sub
#Region "搜尋"
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

        searchlist()

    End Sub
#End Region

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox5.Visible = True Then
            TextBox5.Visible = False
        ElseIf TextBox5.Visible = False Then
            TextBox5.Visible = True
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