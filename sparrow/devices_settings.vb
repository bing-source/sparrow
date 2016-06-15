Public Class devices_settings
    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadHostGroup()
    End Sub

    Private Sub txt_Port_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Port.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Microsoft.VisualBasic.ChrW(8)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Dim g_id As Integer = main.TreeView1.SelectedNode.Name
    Sub loadHostGroup()
        Dim hg_idx As Integer = 0

        Dim tb_hostGroup As DataTable
        tb_hostGroup = MyCls.hostDataSet.Tables("hostGroup")
        Dim tb_gn As String, tb_id As Integer
        cmb_HostGroup.Items.Clear()
        For i = 0 To tb_hostGroup.Rows.Count - 1
            tb_id = tb_hostGroup.Rows(i)("id")
            tb_gn = tb_hostGroup.Rows(i)("groupName")
            cmb_HostGroup.Items.Add(New item(tb_id, tb_gn))
            If tb_id = g_id Then hg_idx = i
        Next

        If tb_hostGroup.Rows.Count > 0 Then
            If g_id = 0 Then
                cmb_HostGroup.Text = ""
            Else
                cmb_HostGroup.SelectedIndex = hg_idx
            End If
        End If
    End Sub

    Dim h_id As Integer = 0 '主机id
    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Dim str_HostGroup, str_Port, str_UserName, str_Password As String
        Dim str_Url, str_GetPara As String
        Dim int_HostGroup, int_Auth, int_isIcmp As Integer

        str_HostGroup = cmb_HostGroup.Text.Trim
        If str_HostGroup.ToUpper = "DEFAULT" Or str_HostGroup.ToUpper = "[DEFAULT]" Then
            MessageBox.Show("Default 是系统保留的名称，请使用其它的设备组名称。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmb_HostGroup.Focus()
            Exit Sub
        End If

        Dim item_hostGroup As item = cmb_HostGroup.SelectedItem
        If str_HostGroup = "" Then
            int_HostGroup = 0
        Else
            int_HostGroup = findHostGroup(str_HostGroup)
        End If

        str_Port = txt_Port.Text.Trim
        If Integer.Parse(str_Port) > 65535 Then
            MessageBox.Show("端口号不能大于 65535 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        str_UserName = txt_UserName.Text.Trim
        'If str_UserName = "" Then
        '    MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK)
        '    txt_UserName.Focus()
        '    Exit Sub
        'End If
        str_Password = txt_Password.Text.Trim
        'If str_Password = "" Then
        '    MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK)
        '    txt_Password.Focus()
        '    Exit Sub
        'End If
        str_Password = MyCls.ToBase64(str_Password)

        int_Auth = 2
        str_Url = txt_Url.Text.Trim
        str_GetPara = txt_GetPara.Text.Trim

        If str_Url = "" Then
            MessageBox.Show("URL 不能为空值。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_Url.Focus()
            Exit Sub
        End If
        'If int_HostGroup = 0 And str_HostGroup <> "" Then
        '    int_HostGroup = findHostGroup(str_HostGroup)
        'End If
        If ckb_isIcmp.Checked Then
            int_isIcmp = 1
        Else
            int_isIcmp = 0
        End If

        Dim sql As String = ""
        Dim rowVals(11) As Object
        rowVals(0) = h_id
        'rowVals(1) = str_hostName
        rowVals(2) = int_HostGroup
        'rowVals(3) = str_IPAddr
        rowVals(4) = str_Port
        rowVals(5) = str_UserName
        rowVals(6) = str_Password
        rowVals(7) = int_Auth
        rowVals(8) = str_Url
        rowVals(9) = str_GetPara
        rowVals(10) = "" 'PostPara
        rowVals(11) = int_isIcmp

        For i = 0 To list_ips.Items.Count - 1
            rowVals(3) = list_ips.Items.Item(i).ToString().Trim
            rowVals(1) = "IP_" & rowVals(3)

            Dim tb_webhost() As DataRow
            tb_webhost = MyCls.hostDataSet.Tables("webhost").Select("IPAddr='" & rowVals(3) & "'")
            If tb_webhost.Length > 0 Then
                MessageBox.Show(rowVals(3) & " 已经存在，将忽略这个设备。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Continue For
            End If

            sql = "insert into webhost(hostName,HostGroup,IPAddr,Port,UserName,Password,Auth,Url,GetPara,PostPara,isicmp)"
            sql = sql & "values('" & rowVals(1) & "'," & int_HostGroup & ",'" & rowVals(3) & "'," &
                "'" & str_Port & "','" & str_UserName & "','" & str_Password & "'," & int_Auth & "," &
                "'" & str_Url & "','" & str_GetPara & "','" & "" & "'," & int_isIcmp & ");select last_insert_id();"
            h_id = MyCls.setValue(sql) '写入主机数据
            If h_id <= 0 Then
                MessageBox.Show("写入数据库失败了，请稍后再重试。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                rowVals(0) = h_id
                addHostList(rowVals)
            End If
        Next

        main.TreeView1.SelectedNode = main.TreeView1.Nodes.Item(int_HostGroup.ToString)
        main.TreeView1.SelectedNode.Expand()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Function findHostGroup(ByVal str As String) As Integer
        str = str.Trim()
        If str.Trim = "" Then Return 0
        Dim tb_hostGroup As DataTable
        tb_hostGroup = MyCls.hostDataSet.Tables("hostGroup")
        Dim tb_id As Integer = 0
        Dim foundRows() As DataRow = tb_hostGroup.Select("groupName='" & str & "'")
        If foundRows.Length > 0 Then tb_id = foundRows(0)("id")
        If tb_id = 0 Then '添加组
            foundRows = Nothing
            foundRows = tb_hostGroup.Select("", "sort desc")
            Dim sort As Integer = 0
            If foundRows.Length > 0 Then sort = foundRows(0)("sort")
            sort = sort + 1
            Dim sql As String = ""
            sql = "insert into hostGroup(groupName,sort)values('" & str & "'," & sort & ");select last_insert_id();"
            tb_id = MyCls.setValue(sql)
            If tb_id > 0 Then
                Dim myRow As DataRow = MyCls.hostDataSet.Tables("hostGroup").NewRow
                With myRow
                    .Item("id") = tb_id
                    .Item("groupName") = str
                    .Item("sort") = sort
                End With
                MyCls.hostDataSet.Tables("hostGroup").Rows.Add(myRow)
                MyCls.hostDataSet.Tables("hostGroup").AcceptChanges()
                main.TreeView1.Nodes.Add(tb_id, str)
            Else
                MessageBox.Show("创建新组失败了，请重试。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Return tb_id
    End Function

    Sub addHostList(ByVal RowVals() As Object)
        MyCls.hostDataSet.Tables("webhost").Rows.Add(RowVals)
        Dim hgidx As Integer = main.getHgIdx(RowVals(2))
        main.TreeView1.Nodes.Item(hgidx).Nodes.Add(RowVals(0), RowVals(1), 2, 2)
    End Sub
End Class