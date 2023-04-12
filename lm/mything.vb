Imports MySql.Data.MySqlClient
Public Class mything

    Dim shareid
    Dim state
    Public id
    Dim tid(10000)
    Dim otid(10000)
    Dim stid(10000)
    Dim t, o, s, i
    Dim dtnow As DateTime

    Private Sub mything_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim i


        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True
        'MsgBox(id)
        '建立查詢字串
        Dim QueryString As String = "Select * From mything where ((userid='" & id & "')or (find_in_set('" & id & "',shareid))) ;" '
        '"SELECT * From mything where userid='" & userid & "';"
        Dim QueryString1 As String = "Select * From mything where (((userid='" & id & "' )or (find_in_set('" & id & "',shareid))) and (state='私有'));" '
        Dim QueryString2 As String = "Select * From mything where  (((userid='" & id & "')or (find_in_set('" & id & "',shareid))) and (state='共享')) ;" '



        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            Dim MyCommand1 As MySqlCommand = Connection.CreateCommand()
            MyCommand1.CommandText = QueryString1
            Dim MyCommand2 As MySqlCommand = Connection.CreateCommand()
            MyCommand2.CommandText = QueryString2

            Try
                '開啟資料庫連線
                Connection.Open()

                '建立資料表橋接器
                Dim Adapter As New MySqlDataAdapter()
                Dim Adapter1 As New MySqlDataAdapter()
                Dim Adapter2 As New MySqlDataAdapter()
                '送出給MySql Server 執行的 SQL 指令
                Adapter.SelectCommand = MyCommand
                Adapter1.SelectCommand = MyCommand1
                Adapter2.SelectCommand = MyCommand2

                'DataSet可以存放多個表格資料，把資料放到 DataSet1 的第一個表格
                Adapter.Fill(DataSet1.Tables(0))
                Adapter1.Fill(DataSet1.Tables(1))
                Adapter2.Fill(DataSet1.Tables(2))

                '如果程式操作期間有對DataSet1中的任何資料做修改且需要更新資料庫，則可利用 update 方法把資料送回MySql Server
                Adapter.Update(DataSet1.Tables(0))
                Adapter1.Update(DataSet1.Tables(1))
                Adapter2.Update(DataSet1.Tables(2))

                '設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                BindingSource2.DataSource = DataSet1
                BindingSource3.DataSource = DataSet1
                '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(0).ToString
                BindingSource2.DataMember = DataSet1.Tables(1).ToString
                BindingSource3.DataMember = DataSet1.Tables(2).ToString
                DataGridView1.DataSource = BindingSource1
                DataGridView2.DataSource = BindingSource2
                DataGridView3.DataSource = BindingSource3

                i = 0
                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    tid(i) = dataReader(1).ToString
                    i = i + 1
                    'ComboBox1.Items.Add(dataReader(0))
                Loop
                dataReader.Close()
            i = 0
            Dim dataReader1 As MySqlDataReader = MyCommand1.ExecuteReader()
            Do While dataReader1.Read()
                otid(i) = dataReader1(1).ToString
                i = i + 1
                'ComboBox1.Items.Add(dataReader(0))
            Loop
            dataReader1.Close()
            i = 0

                Dim dataReader2 As MySqlDataReader = MyCommand2.ExecuteReader()
            Do While dataReader2.Read()
                stid(i) = dataReader2(1).ToString
                i = i + 1
                'ComboBox1.Items.Add(dataReader(0))
            Loop
            dataReader2.Close()

            Catch ex As Exception
            MsgBox(ex.Message)

            Finally
            Connection.Close()
            End Try

        End Using
        '修改DataGridView欄位名稱

        DataGridView1.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).HeaderText = "名稱"
        DataGridView1.Columns(3).HeaderText = "數量"
        DataGridView1.Columns(4).HeaderText = "價錢"
        DataGridView1.Columns(5).HeaderText = "種類"
        DataGridView1.Columns(6).HeaderText = "位置"
        DataGridView1.Columns(7).HeaderText = "購買日"
        DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(9).Visible = False
        DataGridView1.Columns(10).Visible = False
        DataGridView1.Columns(11).Visible = False

        DataGridView2.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(1).Visible = False
        DataGridView2.Columns(2).HeaderText = "名稱"
        DataGridView2.Columns(3).HeaderText = "數量"
        DataGridView2.Columns(4).HeaderText = "價錢"
        DataGridView2.Columns(5).HeaderText = "種類"
        DataGridView2.Columns(6).HeaderText = "位置"
        DataGridView2.Columns(7).HeaderText = "購買日"
        DataGridView2.Columns(8).Visible = False
        DataGridView2.Columns(9).Visible = False
        DataGridView2.Columns(10).Visible = False
        DataGridView2.Columns(11).Visible = False

        DataGridView3.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView3.Columns(0).Visible = False
        DataGridView3.Columns(1).Visible = False
        DataGridView3.Columns(2).HeaderText = "名稱"
        DataGridView3.Columns(3).HeaderText = "數量"
        DataGridView3.Columns(4).HeaderText = "價錢"
        DataGridView3.Columns(5).HeaderText = "種類"
        DataGridView3.Columns(6).HeaderText = "位置"
        DataGridView3.Columns(7).HeaderText = "購買日"
        DataGridView3.Columns(8).Visible = False
        DataGridView3.Columns(9).Visible = False
        DataGridView3.Columns(10).Visible = False
        DataGridView3.Columns(11).Visible = False


    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Visible = True
        TabControl1.Enabled = False
        'Button1.Enabled = False
        'Button2.Enabled = False
        'Button3.Enabled = True
        'Button4.Enabled = True
        'TextBox1.Enabled = False
    End Sub


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        If CheckBox1.Checked = True Then
            TextBox2.Enabled = True
            Button5.Enabled = True
            Button8.Enabled = True
            Label14.Visible = True
            Label2.Visible = True
            state = "共享"
        End If
        If CheckBox1.Checked = False Then
            TextBox2.Enabled = False
            Button5.Enabled = False
            Button8.Enabled = False
            Label14.Visible = False
            Label2.Visible = False
            state = "私有"
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If TextBox10.Text = "" Then
            MsgBox("物品名稱為必填喔~", 0, "提示訊息")
            Exit Sub
        End If
        Dim ix, oi, si

        ix = DataGridView1.CurrentRow.Index

        Dim state

        If CheckBox2.Checked = True Then
            state = "共享"
        ElseIf CheckBox2.Checked = False Then
            state = "私有"
        End If

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "SELECT * From mything where userid='" & id & "';"
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

                ' MsgBox(tid(ix))

                Dim qs1 As String = "update mything set tname='" & TextBox10.Text & "',amount='" & TextBox11.Text & "',price='" & TextBox8.Text & "',kind='" & ComboBox4.Text & "',place='" & ComboBox3.Text & "',buyingdate='" & DateTimePicker4.Value & "',endingdate='" & DateTimePicker3.Value & "',note='" & TextBox7.Text & "',state='" & state & "',shareid='" & shareid & "'where thingid='" & tid(ix) & "';"
                'INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
                Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                cmd.ExecuteNonQuery()

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    TextBox10.Text = dataReader(2).ToString
                    TextBox11.Text = dataReader(3).ToString
                    TextBox8.Text = dataReader(4).ToString
                    ComboBox4.Text = dataReader(5).ToString
                    ComboBox3.Text = dataReader(6).ToString
                    DateTimePicker4.Value = dataReader(7)
                    DateTimePicker3.Value = dataReader(8)
                    TextBox7.Text = dataReader(9).ToString
                    Label3.Text = dataReader(11).ToString
                    i = i + 1
                    'ComboBox1.Items.Add(dataReader(0))
                Loop
                dataReader.Close()


                MsgBox("輸入成功")
                'TextBox9.Clear()
                'TextBox3.Clear()
                'TextBox4.Clear()
                'TextBox5.Clear()
                'ComboBox1.Text = ""
                'ComboBox2.Text = ""
                'DateTimePicker1.Refresh()
                'DateTimePicker2.Refresh()
                'CheckBox1.Checked = False
                'Label12.Text = ""


            Catch ex As Exception
                'MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using

        Panel1.Visible = False
        TabControl1.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        TextBox1.Enabled = True

        Me.Controls.Clear()
        InitializeComponent() 'load all the controls again
        mything_Load(e, e)
    End Sub
    '修改
    'Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click
    '    Dim ix = 0
    '    'Dim oi = 0
    '    'Dim si = 0

    '    ix = DataGridView1.CurrentRow.Index
    '    'oi = DataGridView2.CurrentRow.Index
    '    'si = DataGridView3.CurrentRow.Index
    '    'Label27.Text = ix
    '    'MsgBox(ix)
    '    Dim state

    '    Panel2.Visible = True

    '    If CheckBox2.Checked = True Then
    '        state = "共享"
    '    ElseIf CheckBox2.Checked = False Then
    '        state = "私有"
    '    End If

    '    Dim ConString As New MySqlConnectionStringBuilder
    '    ConString.Database = "lifemanager" '資料庫名稱為lifemanager
    '    ConString.Server = "127.0.0.1" '資料庫的IP位置
    '    ConString.UserID = "user" '資料庫使用者
    '    ConString.Password = "12345678" '資料庫使用者密碼
    '    ConString.SslMode = MySqlSslMode.None
    '    ConString.AllowZeroDateTime = True

    '    'MsgBox(t(ix))

    '    '建立查詢字串
    '    Dim QueryString As String = "SELECT * From mything where (userid='" & login.id & "')and(thingid='" & tid(ix) & "');"
    '    'Dim QueryString1 As String = "SELECT * From mything where (userid='" & userid & "')and(thingid='" & otid(oi) & "');"
    '    'Dim QueryString2 As String = "SELECT * From mything where (userid='" & userid & "')and(thingid='" & stid(si) & "');"
    '    '建立資料庫連線物件
    '    Using Connection As New MySqlConnection(ConString.ToString)
    '        '建立送入查詢字串物件
    '        Dim MyCommand As MySqlCommand = Connection.CreateCommand()
    '        'Dim MyCommand1 As MySqlCommand = Connection.CreateCommand()
    '        'Dim MyCommand2 As MySqlCommand = Connection.CreateCommand()
    '        MyCommand.CommandText = QueryString
    '        'MyCommand1.CommandText = QueryString1
    '        'MyCommand2.CommandText = QueryString2

    '        'Try
    '        '開啟資料庫連線
    '        Connection.Open()

    '            '建立資料表橋接器
    '            Dim Adapter As New MySqlDataAdapter()
    '        '送出給MySql Server 執行的 SQL 指令
    '        Adapter.SelectCommand = MyCommand
    '        'Adapter.SelectCommand = MyCommand1
    '        'Adapter.SelectCommand = MyCommand2

    '        'Dim qs1 As String = "update mything set tname='" & TextBox10.Text & "',amount='" & TextBox11.Text & "',price='" & TextBox8.Text & "',kind='" & ComboBox4.Text & "',place='" & ComboBox3.Text & "',buyingdate='" & DateTimePicker4.Value & "',endingdate='" & DateTimePicker3.Value & "',note='" & TextBox7.Text & "',state='" & state & "'where thingid='" & tid(ix) & "';"
    '        ''INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
    '        'Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
    '        'cmd.ExecuteNonQuery()

    '        Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
    '            Do While dataReader.Read()
    '                TextBox10.Text = dataReader(2).ToString
    '                TextBox11.Text = dataReader(3).ToString
    '                TextBox8.Text = dataReader(4).ToString
    '                ComboBox4.Text = dataReader(5).ToString
    '                ComboBox3.Text = dataReader(6).ToString
    '            DateTimePicker4.Value = dataReader(7).ToString
    '            DateTimePicker3.Value = dataReader(8).ToString
    '            TextBox7.Text = dataReader(9).ToString
    '            Label3.Text = dataReader(11).ToString
    '            i = i + 1
    '                'ComboBox1.Items.Add(dataReader(0))
    '            Loop
    '            dataReader.Close()

    '        'Dim dataReader1 As MySqlDataReader = MyCommand1.ExecuteReader()
    '        'Do While dataReader1.Read()


    '        '    TextBox10.Text = dataReader(2).ToString
    '        '    TextBox11.Text = dataReader(3).ToString
    '        '    TextBox8.Text = dataReader(4).ToString
    '        '    ComboBox4.Text = dataReader(5).ToString
    '        '    ComboBox3.Text = dataReader(6).ToString
    '        '    DateTimePicker4.Value = dataReader(7).ToString
    '        '    DateTimePicker3.Value = dataReader(8).ToString
    '        '    TextBox7.Text = dataReader(9).ToString
    '        '    Label3.Text = dataReader(1).ToString
    '        '    i = i + 1
    '        '    'ComboBox1.Items.Add(dataReader(0))
    '        'Loop
    '        'dataReader.Close()

    '        'Dim dataReader2 As MySqlDataReader = MyCommand2.ExecuteReader()
    '        'Do While dataReader2.Read()
    '        '    TextBox10.Text = dataReader(2).ToString
    '        '    TextBox11.Text = dataReader(3).ToString
    '        '    TextBox8.Text = dataReader(4).ToString
    '        '    ComboBox4.Text = dataReader(5).ToString
    '        '    ComboBox3.Text = dataReader(6).ToString
    '        '    DateTimePicker4.Value = dataReader(7).ToString
    '        '    DateTimePicker3.Value = dataReader(8).ToString
    '        '    TextBox7.Text = dataReader(9).ToString
    '        '    Label3.Text = dataReader(1).ToString
    '        '    i = i + 1
    '        '    'ComboBox1.Items.Add(dataReader(0))
    '        'Loop
    '        'dataReader.Close()

    '        MsgBox("更新成功")
    '        'TextBox9.Clear()
    '        'TextBox3.Clear()
    '        'TextBox4.Clear()
    '        'TextBox5.Clear()
    '        'ComboBox1.Text = ""
    '        'ComboBox2.Text = ""
    '        'DateTimePicker1.Refresh()
    '        'DateTimePicker2.Refresh()
    '        'CheckBox1.Checked = False
    '        'Label12.Text = ""


    '        'Catch ex As Exception
    '        '    MsgBox(ex.Message)

    '        'Finally
    '        '    Connection.Close()
    '        'End Try
    '    End Using
    '    'Me.Controls.Clear()
    '    'InitializeComponent() 'load all the controls again
    '    'mything_Load(e, e)
    'End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox4.Text = "" Then
            MsgBox("物品名稱為必填喔~", 0, "提示訊息")
            Exit Sub
        End If
        Dim name = TextBox4.Text
        Dim amount = TextBox3.Text
        Dim price = TextBox5.Text
        Dim kind = ComboBox1.Text
        Dim place = ComboBox2.Text
        Dim buyingdate = DateTimePicker1.Value
        Dim endingdate = DateTimePicker2.Value
        Dim note = TextBox9.Text

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "SELECT * From mything where userid='" & id & "'and find_in_set('" & shareid & "',shareid);"
        'Dim QueryString1 As String = "SELECT * From mything where thingid='" & otid(oi) & "';"
        'Dim QueryString2 As String = "SELECT * From mything where thingid='" & stid(si) & "';"
        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            'Dim MyCommand1 As MySqlCommand = Connection.CreateCommand()
            'MyCommand1.CommandText = QueryString1
            'Dim MyCommand2 As MySqlCommand = Connection.CreateCommand()
            'MyCommand2.CommandText = QueryString2

            Try
                '開啟資料庫連線
                Connection.Open()

                '建立資料表橋接器
                Dim Adapter As New MySqlDataAdapter()
                'Dim Adapter1 As New MySqlDataAdapter()
                'Dim Adapter2 As New MySqlDataAdapter()
                '送出給MySql Server 執行的 SQL 指令
                Adapter.SelectCommand = MyCommand
                'Adapter1.SelectCommand = MyCommand1
                'Adapter2.SelectCommand = MyCommand2
                'MsgBox(stid(si))

                Dim qs1 As String = " INSERT INTO `mything` (`userid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`,`shareid`) VALUES ('" & id & "', '" & name & "','" & amount & "','" & price & "','" & kind & "','" & place & "', '" & buyingdate & "','" & endingdate & "','" & note & "','" & state & "','" & shareid & "');"


                Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                cmd.ExecuteNonQuery()
                'Dim cmd1 As MySqlCommand = New MySqlCommand(qs2, Connection)
                'cmd1.ExecuteNonQuery()
                'Dim cmd2 As MySqlCommand = New MySqlCommand(qs3, Connection)
                'cmd2.ExecuteNonQuery()

                ''設定繫結資料來源
                'BindingSource1.DataSource = DataSet1
                '    '設定有繫結作用的資料來源中的哪個表格
                '    BindingSource1.DataMember = DataSet1.Tables(0).ToString
                '    'DataGridView 跟 ComboBox 透過 BindingSource做繫結，之後兩者的資料會連動，也就是在ComboBox選擇某資料項 DataGridView 會將該筆資料反藍，反之亦然
                '    DataGridView1.DataSource = BindingSource1


                MsgBox("輸入成功")
                TextBox9.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                DateTimePicker1.Refresh()
                DateTimePicker2.Refresh()
                CheckBox1.Checked = False
                Label12.Text = ""


            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using

        Me.Controls.Clear()
        InitializeComponent() 'load all the controls again
        mything_Load(e, e)
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox6.Enabled = True
            Button9.Enabled = True
            Button12.Enabled = True
        ElseIf CheckBox2.Checked = False Then
            TextBox6.Enabled = False
            Button9.Visible = False
            Button12.Visible = False
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim nuser = TextBox6.Text


        Dim repeat = 1

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From User where userid='" & nuser & "';"
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
                    If nuser = dataReader(0) Then
                        'MsgBox("此信箱已註冊過，請重新輸入信箱")
                        repeat = 0
                        Exit Do
                    End If

                Loop
                dataReader.Close()

                If repeat = 1 Then
                    MsgBox("沒有此用戶")
                    TextBox6.Clear()

                ElseIf repeat = 0 Then

                    shareid = Label3.Text
                    'MsgBox(Label3.Text)
                    Label3.Text = Label3.Text & nuser & " "
                    shareid = shareid & "," & nuser
                    'MsgBox(shareid)
                    TextBox6.Clear()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim duser = TextBox6.Text

        Dim repeat = 1


        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From User where userid='" & duser & "';"
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
                    If duser = dataReader(0) Then
                        'MsgBox("此信箱已註冊過，請重新輸入信箱")
                        repeat = 0
                        Exit Do
                    End If

                Loop
                dataReader.Close()

                If repeat = 1 Then
                    MsgBox("沒有此用戶")
                    TextBox6.Clear()

                ElseIf repeat = 0 Then

                    shareid = Label3.Text
                    Label3.Text = Label3.Text.Replace(duser & " ", "")
                    shareid = shareid.Replace("," & duser, "")
                    'MsgBox(shareid)
                    TextBox6.Clear()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'DataGridView1.DataSource = Nothing
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        'MsgBox(TextBox1.Text)

        '建立查詢字串
        Dim QueryString As String = "SELECT * From mything where ((userid='" & id & "')or find_in_set('" & shareid & "',shareid))and (tname like '%" & TextBox1.Text & "%');"
        Dim QueryString1 As String = "SELECT * From mything where ((userid='" & id & "')or find_in_set('" & shareid & "',shareid))and (tname like '%" & TextBox1.Text & "%') and (state='私有');"
        Dim QueryString2 As String = "SELECT * From mything where ((userid='" & id & "')or find_in_set('" & shareid & "',shareid))and (tname like '%" & TextBox1.Text & "%') and (state='共享');"
        ' "delete From mything where mything.thingid='" & Form3.thingid & "';"

        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            Dim MyCommand1 As MySqlCommand = Connection.CreateCommand()
            MyCommand1.CommandText = QueryString1
            Dim MyCommand2 As MySqlCommand = Connection.CreateCommand()
            MyCommand2.CommandText = QueryString2

            Try
                '開啟資料庫連線
                Connection.Open()

                '建立資料表橋接器
                Dim Adapter As New MySqlDataAdapter()
                '送出給MySql Server 執行的 SQL 指令
                Adapter.SelectCommand = MyCommand
                Dim Adapter1 As New MySqlDataAdapter()
                '送出給MySql Server 執行的 SQL 指令
                Adapter1.SelectCommand = MyCommand1
                Dim Adapter2 As New MySqlDataAdapter()
                '送出給MySql Server 執行的 SQL 指令
                Adapter2.SelectCommand = MyCommand2

                'Dim qs1 As String = “Select * from memo where memo like '%" & TextBox1.Text & "%'"

                'Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                'cmd.ExecuteNonQuery()
                DataSet1.Tables(0).Clear()
                DataSet1.Tables(1).Clear()
                DataSet1.Tables(2).Clear()



                Adapter.Fill(DataSet1.Tables(0))
                Adapter1.Fill(DataSet1.Tables(1))
                Adapter2.Fill(DataSet1.Tables(2))
                'Adapter.Update(DataSet1.Tables(0))


                ''設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                '    '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(0).ToString
                BindingSource2.DataSource = DataSet1
                '    '設定有繫結作用的資料來源中的哪個表格
                BindingSource2.DataMember = DataSet1.Tables(1).ToString
                BindingSource3.DataSource = DataSet1
                '    '設定有繫結作用的資料來源中的哪個表格
                BindingSource3.DataMember = DataSet1.Tables(2).ToString
                'DataGridView1.DataSource = BindingSource1


                'Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                'Do While dataReader.Read()
                '    bmt(i) = dataReader(2).ToString
                '    'MsgBox(bmt(i))
                '    t(i) = dataReader(3).ToString
                '    'MsgBox(t(i))
                '    md(i) = dataReader(0).ToString
                '    'MsgBox(md(i))
                '    i = i + 1
                '    'ComboBox1.Items.Add(dataReader(0))
                'Loop
                'dataReader.Close()



                'MsgBox("查詢結束")
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

        End Using
        'Me.Controls.Clear()
        'InitializeComponent() 'load all the controls again
        'mything_Load(e, e)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        memo.Show()
    End Sub

    Private Sub revise_Click(sender As Object, e As EventArgs) Handles revise.Click
        Dim ix = 0
        'Dim oi = 0
        'Dim si = 0

        ix = DataGridView1.CurrentRow.Index
        'oi = DataGridView2.CurrentRow.Index
        'si = DataGridView3.CurrentRow.Index
        'Label27.Text = ix
        'MsgBox(ix)
        Dim state
        If (tid(ix)) = 0 Then

        End If

        Panel2.Visible = True

        If CheckBox2.Checked = True Then
            state = "共享"
        ElseIf CheckBox2.Checked = False Then
            state = "私有"
        End If

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        'MsgBox(t(ix))

        '建立查詢字串
        Dim QueryString As String = "SELECT * From mything where (userid='" & id & "')and(thingid='" & tid(ix) & "');"
        'Dim QueryString1 As String = "SELECT * From mything where (userid='" & userid & "')and(thingid='" & otid(oi) & "');"
        'Dim QueryString2 As String = "SELECT * From mything where (userid='" & userid & "')and(thingid='" & stid(si) & "');"
        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            'Dim MyCommand1 As MySqlCommand = Connection.CreateCommand()
            'Dim MyCommand2 As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            'MyCommand1.CommandText = QueryString1
            'MyCommand2.CommandText = QueryString2

            'Try
            '開啟資料庫連線
            Connection.Open()

            '建立資料表橋接器
            Dim Adapter As New MySqlDataAdapter()
            '送出給MySql Server 執行的 SQL 指令
            Adapter.SelectCommand = MyCommand
            'Adapter.SelectCommand = MyCommand1
            'Adapter.SelectCommand = MyCommand2

            'Dim qs1 As String = "update mything set tname='" & TextBox10.Text & "',amount='" & TextBox11.Text & "',price='" & TextBox8.Text & "',kind='" & ComboBox4.Text & "',place='" & ComboBox3.Text & "',buyingdate='" & DateTimePicker4.Value & "',endingdate='" & DateTimePicker3.Value & "',note='" & TextBox7.Text & "',state='" & state & "'where thingid='" & tid(ix) & "';"
            ''INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
            'Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
            'cmd.ExecuteNonQuery()



            Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
            Do While dataReader.Read()
                TextBox10.Text = dataReader(2).ToString
                TextBox11.Text = dataReader(3).ToString
                TextBox8.Text = dataReader(4).ToString
                ComboBox4.Text = dataReader(5).ToString
                ComboBox3.Text = dataReader(6).ToString
                DateTimePicker4.Value = dataReader(7).ToString
                DateTimePicker3.Value = dataReader(8).ToString
                TextBox7.Text = dataReader(9).ToString
                Label3.Text = dataReader(11).ToString
                i = i + 1
                'ComboBox1.Items.Add(dataReader(0))
            Loop
            dataReader.Close()



            'Dim dataReader1 As MySqlDataReader = MyCommand1.ExecuteReader()
            'Do While dataReader1.Read()


            '    TextBox10.Text = dataReader(2).ToString
            '    TextBox11.Text = dataReader(3).ToString
            '    TextBox8.Text = dataReader(4).ToString
            '    ComboBox4.Text = dataReader(5).ToString
            '    ComboBox3.Text = dataReader(6).ToString
            '    DateTimePicker4.Value = dataReader(7).ToString
            '    DateTimePicker3.Value = dataReader(8).ToString
            '    TextBox7.Text = dataReader(9).ToString
            '    Label3.Text = dataReader(1).ToString
            '    i = i + 1
            '    'ComboBox1.Items.Add(dataReader(0))
            'Loop
            'dataReader.Close()

            'Dim dataReader2 As MySqlDataReader = MyCommand2.ExecuteReader()
            'Do While dataReader2.Read()
            '    TextBox10.Text = dataReader(2).ToString
            '    TextBox11.Text = dataReader(3).ToString
            '    TextBox8.Text = dataReader(4).ToString
            '    ComboBox4.Text = dataReader(5).ToString
            '    ComboBox3.Text = dataReader(6).ToString
            '    DateTimePicker4.Value = dataReader(7).ToString
            '    DateTimePicker3.Value = dataReader(8).ToString
            '    TextBox7.Text = dataReader(9).ToString
            '    Label3.Text = dataReader(1).ToString
            '    i = i + 1
            '    'ComboBox1.Items.Add(dataReader(0))
            'Loop
            'dataReader.Close()

            ' MsgBox("更新成功")
            'TextBox9.Clear()
            'TextBox3.Clear()
            'TextBox4.Clear()
            'TextBox5.Clear()
            'ComboBox1.Text = ""
            'ComboBox2.Text = ""
            'DateTimePicker1.Refresh()
            'DateTimePicker2.Refresh()
            'CheckBox1.Checked = False
            'Label12.Text = ""


            'Catch ex As Exception
            '    MsgBox(ex.Message)

            'Finally
            '    Connection.Close()
            'End Try
        End Using
        'Me.Controls.Clear()
        'InitializeComponent() 'load all the controls again
        'mything_Load(e, e)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Panel2.Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox9.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        DateTimePicker1.Refresh()
        DateTimePicker2.Refresh()
        CheckBox1.Checked = False
        Label12.Text = ""
        Panel1.Visible = False
    End Sub

#Region "共享者新增"
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim nuser = TextBox2.Text



        Dim repeat = 1

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From User where userid='" & nuser & "';"
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
                    If nuser = dataReader(0) Then
                        'MsgBox("此信箱已註冊過，請重新輸入信箱")
                        repeat = 0
                        Exit Do
                    End If

                Loop
                dataReader.Close()

                If repeat = 1 Then
                    MsgBox("沒有此用戶")
                    TextBox6.Clear()

                ElseIf repeat = 0 Then

                    shareid = Label2.Text
                    Label2.Text = Label2.Text & nuser & " "
                    shareid = shareid & "," & nuser
                    'MsgBox(shareid)
                    TextBox2.Clear()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using
    End Sub
#End Region

#Region "共享者刪除"
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim duser = TextBox2.Text
        Dim repeat = 1


        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From User where userid='" & duser & "';"
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
                    If duser = dataReader(0) Then
                        'MsgBox("此信箱已註冊過，請重新輸入信箱")
                        repeat = 0
                        Exit Do
                    End If

                Loop
                dataReader.Close()

                If repeat = 1 Then
                    MsgBox("沒有此用戶")
                    TextBox6.Clear()

                ElseIf repeat = 0 Then

                    shareid = Label2.Text
                    Label2.Text = Label2.Text.Replace(duser & " ", "")
                    shareid = shareid.Replace("," & duser, "")
                    'MsgBox(shareid)
                    TextBox2.Clear()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    'Private Sub forever_Tick(sender As Object, e As EventArgs) Handles forever.Tick
    '    Dim ConString As New MySqlConnectionStringBuilder
    '    ConString.Database = "lifemanager" '資料庫名稱為lifemanager
    '    ConString.Server = "127.0.0.1" '資料庫的IP位置
    '    ConString.UserID = "user" '資料庫使用者
    '    ConString.Password = "12345678" '資料庫使用者密碼
    '    ConString.SslMode = MySqlSslMode.None

    '    '建立查詢字串
    '    Dim QueryString As String = "SELECT endingdate From mything where userid='" & login.id & "';"
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

    '            'DataSet可以存放多個表格資料，把資料放到 DataSet1 的第一個表格
    '            Adapter.Fill(DataSet1.Tables(0))

    '            '如果程式操作期間有對DataSet1中的任何資料做修改且需要更新資料庫，則可利用 update 方法把資料送回MySql Server
    '            'Adapter.Update(DataSet1)

    '            '設定繫結資料來源
    '            BindingSource1.DataSource = DataSet1
    '            '設定有繫結作用的資料來源中的哪個表格
    '            BindingSource1.DataMember = DataSet1.Tables(0).ToString

    '            Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
    '            Do While dataReader.Read()
    '                Date = dataReader(0)

    '            Loop
    '            dataReader.Close()

    '        Catch ex As Exception
    '            MsgBox(ex.Message)

    '        Finally
    '            Connection.Close()

    '        End Try
    '    End Using

    '    dtnow = DateTime.Now
    '    TimeSpan ts = dtnow -
    '    'ThisMoment = Now
    '    'Label1.Text = Format(Now(), "yyyy/MM/dd H:mm:ss")
    '    If Label1.Text = "2020/06/17 2:30:00" Then
    '        'forever.Enabled = False
    '        NotifyIcon1.Visible = True
    '        NotifyIcon1.ShowBalloonTip(10000, "VPN Heartbeat", "Network Offline!", ToolTipIcon.Info) '專注輔助不可以開!!!!!!!!
    '    End If
    'End Sub
#End Region
#Region "刪除"
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Panel2.Visible = True
        Dim ix = 0, oi = 0, si = 0

        ix = DataGridView1.CurrentRow.Index
        'oi = DataGridView2.CurrentRow.Index
        'si = DataGridView3.CurrentRow.Index
        'MsgBox(si)

        Dim name = TextBox4.Text
        Dim amount = TextBox3.Text
        Dim price = TextBox5.Text
        Dim kind = ComboBox1.Text
        Dim place = ComboBox2.Text
        Dim buyingdate = DateTimePicker1.Value
        Dim endingdate = DateTimePicker2.Value
        Dim note = TextBox9.Text

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "SELECT * From mything where thingid='" & tid(ix) & "';"
        'Dim QueryString1 As String = "SELECT * From mything where thingid='" & otid(oi) & "';"
        'Dim QueryString2 As String = "SELECT * From mything where thingid='" & stid(si) & "';"
        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            'Dim MyCommand1 As MySqlCommand = Connection.CreateCommand()
            'MyCommand1.CommandText = QueryString1
            'Dim MyCommand2 As MySqlCommand = Connection.CreateCommand()
            'MyCommand2.CommandText = QueryString2

            Try
                '開啟資料庫連線
                Connection.Open()

                '建立資料表橋接器
                Dim Adapter As New MySqlDataAdapter()
                'Dim Adapter1 As New MySqlDataAdapter()
                'Dim Adapter2 As New MySqlDataAdapter()
                '送出給MySql Server 執行的 SQL 指令
                Adapter.SelectCommand = MyCommand
                'Adapter1.SelectCommand = MyCommand1
                'Adapter2.SelectCommand = MyCommand2
                ''MsgBox(stid(si))

                Dim qs1 As String = "delete from mything where thingid='" & tid(ix) & "';"
                'Dim qs2 As String = "delete from mything where thingid='" & otid(oi) & "';"
                'Dim qs3 As String = "delete from mything where thingid='" & stid(si) & "';"

                Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                cmd.ExecuteNonQuery()
                'Dim cmd1 As MySqlCommand = New MySqlCommand(qs2, Connection)
                'cmd1.ExecuteNonQuery()
                'Dim cmd2 As MySqlCommand = New MySqlCommand(qs3, Connection)
                'cmd2.ExecuteNonQuery()

                ''設定繫結資料來源
                'BindingSource1.DataSource = DataSet1
                '    '設定有繫結作用的資料來源中的哪個表格
                '    BindingSource1.DataMember = DataSet1.Tables(0).ToString
                '    'DataGridView 跟 ComboBox 透過 BindingSource做繫結，之後兩者的資料會連動，也就是在ComboBox選擇某資料項 DataGridView 會將該筆資料反藍，反之亦然
                '    DataGridView1.DataSource = BindingSource1


                MsgBox("刪除成功")
                TextBox9.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                DateTimePicker1.Refresh()
                DateTimePicker2.Refresh()
                CheckBox1.Checked = False
                Label12.Text = ""


            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using

        Me.Controls.Clear()
        InitializeComponent() 'load all the controls again
        mything_Load(e, e)
    End Sub
#End Region
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