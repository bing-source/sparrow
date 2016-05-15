Public Class settings

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim str_oldpassword, str_password, str_repassword As String
        str_oldpassword = Trim(oldPasswordTextBox.Text)
        str_password = Trim(PasswordTextBox.Text)
        str_repassword = Trim(rePasswordTextBox.Text)
        Dim isMod As Boolean = False

        If str_oldpassword <> "" Then isMod = True '密码为空不修改密码

        If isMod = True And str_password = "" Then
            MessageBox.Show("请输入新密码。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PasswordTextBox.Focus()
            Exit Sub
        End If
        If isMod = True And str_repassword = "" Then
            MessageBox.Show("请输入确认密码。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            rePasswordTextBox.Focus()
            Exit Sub
        End If
        If isMod = True And str_oldpassword = str_password Then
            MessageBox.Show("新密码不能和旧密码相同，请重新输入。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PasswordTextBox.Focus()
            Exit Sub
        End If
        If isMod = True And str_repassword <> str_password Then
            MessageBox.Show("新密码和确认密码不匹配，请重新输入。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            rePasswordTextBox.Focus()
            Exit Sub
        End If

        If isMod = True Then
            Dim msg_ret As Integer
            msg_ret = MessageBox.Show("你确定要修改密码吗？", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If msg_ret = 6 Then '是
                Dim sql As String
                If isMod = True Then
                    Dim tb_username As String
                    sql = "select id,username,password from accounts order by id desc limit 1;"
                    Dim tmpDs As New DataSet, retMsg As Boolean = False
                    tmpDs = MyCls.FillDataset("accounts", sql)
                    If tmpDs.Tables(0) IsNot Nothing Then
                        tb_username = tmpDs.Tables(0).Rows(0)("username")
                        retMsg = MyCls.checkUser(tb_username, str_oldpassword)
                        If retMsg = False Then
                            MessageBox.Show("旧密码不正确，请重新输入。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            oldPasswordTextBox.Focus()
                            Exit Sub
                        End If
                        str_password = MyCls.md5(str_password)
                        tmpDs.Tables(0).Rows(0)("password") = str_password
                        MyCls.UpdataDataTab(sql, tmpDs.Tables(0))

                        MyCls.hostDataSet.Tables("accounts").Rows(0)("password") = str_password
                        MyCls.hostDataSet.Tables("accounts").AcceptChanges()
                    Else
                        MessageBox.Show("未知错误。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            ElseIf msg_ret = 7 Then '否
                oldPasswordTextBox.Focus()
                Exit Sub
            End If
        End If

        Dim i_timeout As String = Trim(txt_timeOut.Text)
        If i_timeout = "" Or IsNumeric(i_timeout) = False Then i_timeout = 30
        My.MySettings.Default.int_timeOut = i_timeout
        main.int_timeOut = i_timeout
        If ckb_Icmp.Checked = True Then
            'Form1.Timer1.Enabled = False
            My.MySettings.Default.int_icmp = 1
            main.int_icmp = 1
            If main.BackgroundWorker1.IsBusy = False Then main.BackgroundWorker1.RunWorkerAsync()
        Else
            ' Form1.Timer1.Enabled = True
            My.MySettings.Default.int_icmp = 0
            main.int_icmp = 0
            main.BackgroundWorker1.CancelAsync()
            Dim tmpdr() As DataRow
            tmpdr = MyCls.hostDataSet.Tables("webHost").Select("pingcount >=1")
            For i = 0 To tmpdr.GetUpperBound(0)
                tmpdr(i)("pingcount") = 0
            Next
            MyCls.hostDataSet.Tables("webHost").AcceptChanges()
        End If
        Dim i_retry As String = Trim(txt_retry.Text)
        If i_retry = "" Or IsNumeric(i_retry) = False Then i_retry = 3
        My.MySettings.Default.int_retry = i_retry
        main.int_retry = i_retry
        Dim s_centerIP As String = Trim(txt_centerIP.Text)
        My.MySettings.Default.str_centerIP = s_centerIP
        main.str_centerIP = s_centerIP
        My.MySettings.Default.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Dim int_icmp As Integer = My.MySettings.Default.int_icmp
    Dim int_timeOut As Integer = My.MySettings.Default.int_timeOut
    Dim int_retry As Integer = My.MySettings.Default.int_retry
    Dim str_centerIP As String = My.MySettings.Default.str_centerIP
    Private Sub setForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If int_icmp = 0 Then
            ckb_Icmp.Checked = False
        Else
            ckb_Icmp.Checked = True
        End If
        txt_timeOut.Text = int_timeOut
        txt_retry.Text = int_retry
        txt_centerIP.Text = str_centerIP
    End Sub

    Private Sub txt_timeOut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_timeOut.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Microsoft.VisualBasic.ChrW(8)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_retry_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_retry.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Microsoft.VisualBasic.ChrW(8)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub lab_tip_Click(sender As Object, e As EventArgs)

    End Sub
End Class
