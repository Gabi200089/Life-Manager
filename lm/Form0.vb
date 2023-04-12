Public Class Form0
    Private Sub Form0_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim p1title As Label = New Label
        Dim p1login As Button = New Button
        Dim p1register As Button = New Button
        Dim wf As System.Drawing.Font

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        '第一頁
        '基本版面設定
        Me.BackgroundImage = My.Resources.whiteback
        Me.Controls.Add(p1title)
        p1title.Text = "生活小管家"
        p1title.Top = 391
        p1title.Left = 83
        p1title.ForeColor = Color.DarkSlateGray
        p1title.Font = New Font("微軟正黑體", 36, Font.Style.Bold)
        p1title.AutoSize = True
        p1title.BackColor = Color.Transparent

        Me.Controls.Add(p1login)
        p1login.BackColor = Color.Transparent
        p1login.BackgroundImage = My.Resources.buttony
        p1login.BackgroundImageLayout = ImageLayout.Stretch
        p1login.FlatStyle = FlatStyle.Flat
        p1login.Font = New Font("微軟正黑體", 16)
        p1login.Text = "有阿~你怎麼忘記了"
        p1login.TextAlign = ContentAlignment.MiddleCenter
        p1login.Top = 382
        p1login.Left = 300
        p1login.Height = 65
        p1login.Width = 290
        'AddHandler p1login.Click, AddressOf button_Click




        Me.Controls.Add(p1register)


    End Sub
End Class
