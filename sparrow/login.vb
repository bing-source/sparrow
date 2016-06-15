Public Class login
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim str_username, str_password As String
        str_username = UsernameTextBox.Text.Trim
        str_password = PasswordTextBox.Text.Trim
        If str_username = "" Then
            MessageBox.Show("请输入你的用户名。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UsernameTextBox.Focus()
            Exit Sub
        End If
        If str_password = "" Then
            MessageBox.Show("请输入你的密码。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PasswordTextBox.Focus()
            Exit Sub
        End If
        Dim retMsg As Boolean = False
        retMsg = MyCls.checkUser(str_username, str_password)
        If retMsg = False Then
            MessageBox.Show("用户名或密码不正确，请重新输入。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            UsernameTextBox.Focus()
            Exit Sub
        Else
            main.Show()    '显示主界面
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.app_ico
        Call saveFiles() '查找logo文件
        Call MyCls.load_accounts()
        ''''''正式版删除
        main.Show()    '显示主界面
        Me.Close()
        ''''''正式版删除
        Dim ret As Integer = 0
        ret = MyCls.isUserPass()
        ' If ret = 1 Then Me.Text = "登录"
        If ret = 0 Or ret = 2 Then '数据不存在
            createAccount.Show()
            Me.Close()
        End If
    End Sub

    '登陆成功在根目录生产 logo.png 和 welcome.html， 防止用户修改。
    Sub saveFiles()
        Dim welcomeHtml As String = Application.StartupPath & "/welcome.html"
        Dim biglogo As String = Application.StartupPath & "/welcome.jpg"

        Dim SW As System.IO.StreamWriter
        SW = New System.IO.StreamWriter(welcomeHtml, False)
        SW.WriteLine(My.Resources.welcome_html)
        SW.Flush()
        SW.Close()

        My.Resources.big_logo.Save(biglogo)
    End Sub
End Class

