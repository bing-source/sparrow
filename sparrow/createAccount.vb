Public Class createAccount

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim str_username, str_password, str_repassword As String
        str_username = UsernameTextBox.Text.Trim
        str_password = PasswordTextBox.Text.Trim
        str_repassword = rePasswordTextBox.Text.Trim

        If str_username = "" Then
            MessageBox.Show("请输入一个有效的用户名。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UsernameTextBox.Focus()
            Exit Sub
        End If
        If str_password = "" Then
            MessageBox.Show("请输入一个有效的密码。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            PasswordTextBox.Focus()
            Exit Sub
        End If
        If str_repassword = "" Then
            MessageBox.Show("请输入确认密码。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            rePasswordTextBox.Focus()
            Exit Sub
        End If
        If str_repassword <> str_password Then
            MessageBox.Show("新密码和确认密码不匹配，请重新输入。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            rePasswordTextBox.Focus()
            Exit Sub
        End If

        MessageBox.Show("请牢记您的账户。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim sql As String
        sql = "select id,username,password from accounts order by id desc limit 1;"
        Dim tmpDs As New DataSet
        tmpDs = MyCls.FillDataset("accounts", sql)
        Dim newRow As DataRow = tmpDs.Tables(0).NewRow
        With newRow
            .Item("username") = str_username
            .Item("password") = MyCls.md5(str_password)
        End With
        tmpDs.Tables(0).Rows.Add(newRow)
        MyCls.UpdataDataTab(sql, tmpDs.Tables(0))
        MyCls.hostDataSet.Tables("accounts").Rows.Add(newRow.ItemArray)
        MyCls.hostDataSet.Tables("accounts").AcceptChanges()
        main.Show() '显示主界面
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
