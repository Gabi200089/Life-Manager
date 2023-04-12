Imports MySql.Data.MySqlClient
Public Class memorandum

    Dim m '用作判斷memoid
    Dim md(1000) As Integer '存放memo_id
    Dim b(4) As Button '顯示的五個按鈕
    Dim bmt(1000) As String '存放memo_title的地方
    Dim t(1000) As String '存放memo的文字內容
    Dim j = 0 '每頁的五筆資料
    Dim k = 0 '全部資料總筆數
    Dim i = 0


    Private Sub memorandum_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '把按鈕放進陣列中
        b(0) = Button1
        b(1) = Button2
        b(2) = Button3
        b(3) = Button4
        b(4) = Button5

        TextBox.Enabled = False

        '建立連線字串
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "Select * From memo where userid='" & login.id & "' ;"
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
                    md(i) = dataReader(0).ToString
                    bmt(i) = dataReader(2).ToString
                    t(i) = dataReader(3).ToString
                    i = i + 1
                    'ComboBox1.Items.Add(dataReader(0))
                Loop
                dataReader.Close()

                'MsgBox(i)

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

        End Using

        k = 0

        For i = 0 To 4
            b(i).Text = bmt((5 * k) + j + i)
            If b(i).Text = "" Then
                b(i).Enabled = False
            Else
                b(i).Enabled = True
            End If
        Next

        If k = 0 Then
            Button10.Visible = False

        End If

    End Sub
    'Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
    '    Me.Close()
    '    memo.Show()
    'End Sub

#Region "按下按鈕"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox.Text = t((5 * k) + j)
        m = md((5 * k) + j)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox.Text = t((5 * k) + j + 1)
        m = md((5 * k) + j + 1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox.Text = t((5 * k) + j + 2)
        m = md((5 * k) + j + 2)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox.Text = t((5 * k) + j + 3)
        m = md((5 * k) + j + 3)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox.Text = t((5 * k) + j + 4)
        m = md((5 * k) + j + 4)
    End Sub
#End Region

#Region "上一頁/下一頁"
    ''下頁
    'Private Sub button11_Click(sender As Object, e As EventArgs) Handles button11.Click

    '    If (b(0).Text = "") Or (b(1).Text = "") Or (b(2).Text = "") Or (b(3).Text = "") Or (b(4).Text = "") Then
    '        MsgBox("已經為最後一頁備忘錄",, "最後一頁備忘錄")
    '        'button11.Visible = False
    '    Else
    '        k = k + 1
    '        For i = 0 To 4

    '            b(i).Text = bmt((5 * k) + j + i)
    '            If b(i).Text = "" Then
    '                b(i).Enabled = False
    '            Else
    '                b(i).Enabled = True
    '            End If
    '        Next
    '    End If
    '    If k = 0 Then
    '        button10.Visible = False
    '    Else
    '        button10.Visible = True
    '    End If
    '    If (b(0).Text = "") Or (b(1).Text = "") Or (b(2).Text = "") Or (b(3).Text = "") Or (b(4).Text = "") Then
    '        button11.Visible = False
    '    Else
    '        button11.Visible = True
    '    End If

    'End Sub
    ''上頁
    'Private Sub button10_Click(sender As Object, e As EventArgs) Handles button10.Click
    '    If k = 0 Then
    '        button10.Visible = True
    '        MsgBox("已經為第一頁備忘錄",, "第一頁備忘錄")

    '    Else
    '        button10.Visible = True
    '        k = k - 1
    '        For i = 0 To 4
    '            b(i).Text = bmt((5 * k) + j + i)
    '            If b(i).Text = "" Then
    '                b(i).Enabled = False
    '            Else
    '                b(i).Enabled = True
    '            End If
    '        Next
    '    End If
    '    If k = 0 Then
    '        button10.Visible = False
    '    Else
    '        button10.Visible = True
    '    End If
    '    If (b(0).Text = "") Or (b(1).Text = "") Or (b(2).Text = "") Or (b(3).Text = "") Or (b(4).Text = "") Then
    '        button11.Visible = False
    '    Else
    '        button11.Visible = True
    '    End If
    'End Sub


#End Region

#Region "新增"
    '    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
    '        Dim title
    '        title = InputBox("請輸入標題：", "新備忘錄")
    '        If title = "" Then
    '            MsgBox("未輸入標題",, "未輸入標題")
    '            title = InputBox("請輸入標題：", "新備忘錄")
    '        End If

    '        Dim ConString As New MySqlConnectionStringBuilder
    '        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
    '        ConString.Server = "127.0.0.1" '資料庫的IP位置
    '        ConString.UserID = "user" '資料庫使用者
    '        ConString.Password = "12345678" '資料庫使用者密碼
    '        ConString.SslMode = MySqlSslMode.None

    '        '建立查詢字串
    '        Dim QueryString As String = "SELECT * From memo where userid='" & login.id & "';"
    '        '建立資料庫連線物件
    '        Using Connection As New MySqlConnection(ConString.ToString)
    '            '建立送入查詢字串物件
    '            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
    '            MyCommand.CommandText = QueryString

    '            Try
    '                '開啟資料庫連線
    '                Connection.Open()

    '                '建立資料表橋接器
    '                Dim Adapter As New MySqlDataAdapter()
    '                '送出給MySql Server 執行的 SQL 指令
    '                Adapter.SelectCommand = MyCommand

    '                Dim qs1 As String = "insert into memo(userid,memotitle)values('" & login.id & "','" & title & "');"
    '                'INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
    '                Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
    '                cmd.ExecuteNonQuery()

    '                Adapter.Fill(DataSet1.Tables(0))

    '                '設定繫結資料來源
    '                BindingSource1.DataSource = DataSet1
    '                '設定有繫結作用的資料來源中的哪個表格
    '                BindingSource1.DataMember = DataSet1.Tables(0).ToString
    '                '    'DataGridView 跟 ComboBox 透過 BindingSource做繫結，之後兩者的資料會連動，也就是在ComboBox選擇某資料項 DataGridView 會將該筆資料反藍，反之亦然
    '                'DataGridView1.DataSource = BindingSource1

    '                For i = 0 To 1000
    '                    bmt(i) = ""
    '                    t(i) = ""
    '                Next

    '                i = 0

    '                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
    '                Do While dataReader.Read()
    '                    bmt(i) = dataReader(2).ToString
    '                    t(i) = dataReader(3).ToString
    '                    md(i) = dataReader(0).ToString
    '                    i = i + 1
    '                    'ComboBox1.Items.Add(dataReader(0))
    '                Loop
    '                dataReader.Close()

    '                MsgBox("輸入成功")


    '            Catch ex As Exception
    '                MsgBox(ex.Message)

    '            Finally
    '                Connection.Close()

    '            End Try
    '        End Using
    '        TextBox.Clear()
    '        k = 0
    '        For i = 0 To 4
    '            b(i).Text = ""
    '        Next
    '        For i = 0 To 4
    '            b(i).Text = bmt((5 * k) + j + i)
    '            If b(i).Text = "" Then
    '                b(i).Enabled = False
    '            Else
    '                b(i).Enabled = True
    '            End If
    '        Next
    '        TextBox.Text = ""
    '        TextBox.Text = t((5 * k) + j + i)


    '    End Sub


#End Region

#Region "刪除"
    'Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
    '    Dim ConString As New MySqlConnectionStringBuilder
    '    ConString.Database = "lifemanager" '資料庫名稱為lifemanager
    '    ConString.Server = "127.0.0.1" '資料庫的IP位置
    '    ConString.UserID = "user" '資料庫使用者
    '    ConString.Password = "12345678" '資料庫使用者密碼
    '    ConString.SslMode = MySqlSslMode.None
    '    ConString.AllowZeroDateTime = True

    '    '建立查詢字串
    '    Dim QueryString As String = "SELECT * From memo where userid='" & login.id & "';"
    '    ' "delete From mything where mything.thingid='" & Form3.thingid & "';"

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

    '            Dim qs1 As String = "delete from memo where memoid='" & m & "';"

    '            Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
    '            cmd.ExecuteNonQuery()

    '            Adapter.Fill(DataSet1.Tables(0))
    '            'Adapter.Update(Form3.DataSet1.Tables(0))


    '            ''設定繫結資料來源
    '            BindingSource1.DataSource = DataSet1
    '            '    '設定有繫結作用的資料來源中的哪個表格
    '            BindingSource1.DataMember = DataSet1.Tables(0).ToString
    '            'DataGridView1.DataSource = BindingSource1

    '            For i = 0 To 1000
    '                bmt(i) = ""
    '                t(i) = ""
    '            Next

    '            i = 0

    '            Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
    '            Do While dataReader.Read()
    '                bmt(i) = dataReader(2).ToString
    '                t(i) = dataReader(3).ToString
    '                md(i) = dataReader(0).ToString
    '                i = i + 1
    '                'ComboBox1.Items.Add(dataReader(0))
    '            Loop
    '            dataReader.Close()



    '            MsgBox("刪除成功")
    '        Catch ex As Exception
    '            MsgBox(ex.Message)

    '        Finally
    '            Connection.Close()
    '        End Try

    '    End Using
    '    TextBox.Clear()
    '    k = 0
    '    For i = 0 To 4
    '        b(i).Text = ""
    '    Next
    '    For i = 0 To 4
    '        b(i).Text = bmt((5 * k) + j + i)
    '        If b(i).Text = "" Then
    '            b(i).Enabled = False
    '        Else
    '            b(i).Enabled = True
    '        End If
    '    Next
    '    TextBox.Text = ""
    '    TextBox.Text = t((5 * k) + j + i)
    'End Sub


#End Region

#Region "顯示修改/查詢"
    'Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
    '    TextBox.Enabled = True
    '    Button6.Visible = True
    'End Sub

    'Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click
    '    If TextBox1.Visible = True Then
    '        TextBox1.Visible = False
    '    ElseIf TextBox1.Visible = False Then
    '        TextBox1.Visible = True
    '    End If
    'End Sub

#End Region

    '#Region "修改"
    '    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click
    '        Dim ConString As New MySqlConnectionStringBuilder
    '        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
    '        ConString.Server = "127.0.0.1" '資料庫的IP位置
    '        ConString.UserID = "user" '資料庫使用者
    '        ConString.Password = "12345678" '資料庫使用者密碼
    '        ConString.SslMode = MySqlSslMode.None

    '        '建立查詢字串
    '        Dim QueryString As String = "SELECT * From memo where userid='" & login.id & "';"
    '        '建立資料庫連線物件
    '        Using Connection As New MySqlConnection(ConString.ToString)
    '            '建立送入查詢字串物件
    '            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
    '            MyCommand.CommandText = QueryString

    '            Try
    '                '開啟資料庫連線
    '                Connection.Open()

    '                '建立資料表橋接器
    '                Dim Adapter As New MySqlDataAdapter()
    '                '送出給MySql Server 執行的 SQL 指令
    '                Adapter.SelectCommand = MyCommand

    '                Dim qs1 As String = "update memo set memo='" & TextBox.Text & "'where memoid='" & m & "';"
    '                'INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
    '                Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
    '                cmd.ExecuteNonQuery()

    '                Adapter.Fill(DataSet1.Tables(0))

    '                '設定繫結資料來源
    '                BindingSource1.DataSource = DataSet1
    '                '設定有繫結作用的資料來源中的哪個表格
    '                BindingSource1.DataMember = DataSet1.Tables(0).ToString
    '                '    'DataGridView 跟 ComboBox 透過 BindingSource做繫結，之後兩者的資料會連動，也就是在ComboBox選擇某資料項 DataGridView 會將該筆資料反藍，反之亦然
    '                'DataGridView1.DataSource = BindingSource1

    '                For i = 0 To 1000
    '                    bmt(i) = ""
    '                    t(i) = ""
    '                Next

    '                i = 0

    '                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
    '                Do While dataReader.Read()
    '                    bmt(i) = dataReader(2).ToString
    '                    t(i) = dataReader(3).ToString
    '                    md(i) = dataReader(0).ToString
    '                    i = i + 1
    '                    'ComboBox1.Items.Add(dataReader(0))
    '                Loop
    '                dataReader.Close()

    '                MsgBox("輸入成功")


    '            Catch ex As Exception
    '                MsgBox(ex.Message)

    '            Finally
    '                Connection.Close()
    '            End Try
    '        End Using
    '        TextBox.Text = t((5 * k) + j + i)
    '        PictureBox15.Visible = False
    '        TextBox.Enabled = False
    '        k = 0
    '        For i = 0 To 4
    '            b(i).Text = bmt((5 * k) + j + i)
    '            If b(i).Text = "" Then
    '                b(i).Enabled = False
    '            Else
    '                b(i).Enabled = True
    '            End If
    '        Next
    '    End Sub


    '#End Region

#Region "查詢"
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "SELECT * From memo where (userid='" & login.id & "')and((memotitle like '%" & TextBox1.Text & "%')or(memo like '%" & TextBox1.Text & "%'));"
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

                'Dim qs1 As String = “Select * from memo where memo like '%" & TextBox1.Text & "%'"

                'Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                'cmd.ExecuteNonQuery()

                Adapter.Fill(DataSet1.Tables(0))
                'Adapter.Update(Form3.DataSet1.Tables(0))


                ''設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                '    '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(0).ToString
                'DataGridView1.DataSource = BindingSource1

                For i = 0 To 1000
                    bmt(i) = ""
                    t(i) = ""
                Next

                i = 0

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    bmt(i) = dataReader(2).ToString
                    'MsgBox(bmt(i))
                    t(i) = dataReader(3).ToString
                    'MsgBox(t(i))
                    md(i) = dataReader(0).ToString
                    'MsgBox(md(i))
                    i = i + 1
                    'ComboBox1.Items.Add(dataReader(0))
                Loop
                dataReader.Close()



                'MsgBox("查詢結束")
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

        End Using
        TextBox.Clear()
        k = 0
        For i = 0 To 4
            b(i).Text = ""
        Next
        For i = 0 To 4
            b(i).Text = bmt((5 * k) + j + i)
            If b(i).Text = "" Then
                b(i).Enabled = False
            Else
                b(i).Enabled = True
            End If
        Next
        TextBox.Text = ""
        TextBox.Text = t((5 * k) + j + i)
    End Sub
#End Region
#Region "確認"
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From memo where userid='" & login.id & "';"
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

                Dim qs1 As String = "update memo set memo='" & TextBox.Text & "'where memoid='" & m & "';"
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

                For i = 0 To 1000
                    bmt(i) = ""
                    t(i) = ""
                Next

                i = 0

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    bmt(i) = dataReader(2).ToString
                    t(i) = dataReader(3).ToString
                    md(i) = dataReader(0).ToString
                    i = i + 1
                    'ComboBox1.Items.Add(dataReader(0))
                Loop
                dataReader.Close()

                MsgBox("更新成功")


            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using
        TextBox.Text = t((5 * k) + j + i)
        Button6.Visible = False
        TextBox.Enabled = False
        k = 0
        For i = 0 To 4
            b(i).Text = bmt((5 * k) + j + i)
            If b(i).Text = "" Then
                b(i).Enabled = False
            Else
                b(i).Enabled = True
            End If
        Next
        Button10.Visible = False
        Button11.Visible = True
    End Sub
#End Region
#Region "新增"
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim title
        title = InputBox("請輸入標題：", "新備忘錄")
        Do While title = ""
            MsgBox("未輸入標題",, "未輸入標題")
            title = InputBox("請輸入標題：", "新備忘錄")
        Loop

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From memo where userid='" & login.id & "';"
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

                Dim qs1 As String = "insert into memo(userid,memotitle)values('" & login.id & "','" & title & "');"
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

                For i = 0 To 1000
                    bmt(i) = ""
                    t(i) = ""
                Next

                i = 0

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    bmt(i) = dataReader(2).ToString
                    t(i) = dataReader(3).ToString
                    md(i) = dataReader(0).ToString
                    i = i + 1
                    'ComboBox1.Items.Add(dataReader(0))
                Loop
                dataReader.Close()

                'MsgBox("輸入成功")


            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()

            End Try
        End Using
        TextBox.Clear()
        k = 0
        For i = 0 To 4
            b(i).Text = ""
        Next
        For i = 0 To 4
            b(i).Text = bmt((5 * k) + j + i)
            If b(i).Text = "" Then
                b(i).Enabled = False
            Else
                b(i).Enabled = True
            End If
        Next
        TextBox.Text = ""
        TextBox.Text = t((5 * k) + j + i)
        Button10.Visible = False
        Button11.Visible = True

    End Sub
#End Region
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        memo.Show()
    End Sub
#Region "刪除"
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "lifemanager" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None
        ConString.AllowZeroDateTime = True

        '建立查詢字串
        Dim QueryString As String = "SELECT * From memo where userid='" & login.id & "';"
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

                Dim qs1 As String = "delete from memo where memoid='" & m & "';"

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
                    bmt(i) = ""
                    t(i) = ""
                Next

                i = 0

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    bmt(i) = dataReader(2).ToString
                    t(i) = dataReader(3).ToString
                    md(i) = dataReader(0).ToString
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
        TextBox.Clear()
        k = 0
        For i = 0 To 4
            b(i).Text = ""
        Next
        For i = 0 To 4
            b(i).Text = bmt((5 * k) + j + i)
            If b(i).Text = "" Then
                b(i).Enabled = False
            Else
                b(i).Enabled = True
            End If
        Next
        TextBox.Text = ""
        TextBox.Text = t((5 * k) + j + i)
    End Sub
#End Region
#Region "顯示修改/查詢"
    Private Sub revise_Click(sender As Object, e As EventArgs) Handles revise.Click
        TextBox.Enabled = True
        Button6.Visible = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox1.Visible = True Then
            TextBox1.Visible = False
        ElseIf TextBox1.Visible = False Then
            TextBox1.Visible = True
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If k = 0 Then
            Button10.Visible = True
            MsgBox("已經為第一頁備忘錄",, "第一頁備忘錄")

        Else
            Button10.Visible = True
            k = k - 1
            For i = 0 To 4
                b(i).Text = bmt((5 * k) + j + i)
                If b(i).Text = "" Then
                    b(i).Enabled = False
                Else
                    b(i).Enabled = True
                End If
            Next
        End If
        If k = 0 Then
            Button10.Visible = False
        Else
            Button10.Visible = True
        End If
        If (b(0).Text = "") Or (b(1).Text = "") Or (b(2).Text = "") Or (b(3).Text = "") Or (b(4).Text = "") Then
            Button11.Visible = False
        Else
            Button11.Visible = True
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If (b(0).Text = "") Or (b(1).Text = "") Or (b(2).Text = "") Or (b(3).Text = "") Or (b(4).Text = "") Then
            MsgBox("已經為最後一頁備忘錄",, "最後一頁備忘錄")
            'button11.Visible = False
        Else
            k = k + 1
            For i = 0 To 4

                b(i).Text = bmt((5 * k) + j + i)
                If b(i).Text = "" Then
                    b(i).Enabled = False
                Else
                    b(i).Enabled = True
                End If
            Next
        End If
        If k = 0 Then
            Button10.Visible = False
        Else
            Button10.Visible = True
        End If
        If (b(0).Text = "") Or (b(1).Text = "") Or (b(2).Text = "") Or (b(3).Text = "") Or (b(4).Text = "") Then
            Button11.Visible = False
        Else
            Button11.Visible = True
        End If
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