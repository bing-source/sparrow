Imports System.Windows.Forms

Public Class device_settings
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim str_hostName, str_HostGroup, str_IPAddr, str_Port, str_UserName, str_Password As String
        Dim str_Url, str_GetPara, str_PostPara As String
        Dim int_HostGroup, int_Auth, int_isIcmp As Integer

        str_hostName = txt_HostName.Text.Trim
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
        'Try
        '    int_HostGroup = item_hostGroup.id
        'Catch ex As Exception
        '    int_HostGroup = 0
        'End Try
        str_IPAddr = txt_IPAddr.Text.Trim
        str_IPAddr = str_IPAddr.ToLower.Replace("http://", "")
        If MyCls.isIP(str_IPAddr) = False Then
            MessageBox.Show("请输入一个正确的IP地址。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_IPAddr.Focus()
            Exit Sub
        Else
            If str_hostName = "" Then
                str_hostName = "IP_" & str_IPAddr
            End If
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

        If rdb_Server.Checked = True Then
            int_Auth = 1
        End If
        If rdb_Session.Checked = True Then
            int_Auth = 2
        End If
        str_Url = txt_Url.Text.Trim
        str_GetPara = txt_GetPara.Text.Trim
        str_PostPara = txt_PostPara.Text.Trim
        If int_Auth = 2 And str_Url = "" And str_GetPara = "" And str_PostPara = "" Then
            MessageBox.Show("请输入正确的参数。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        rowVals(1) = str_hostName
        rowVals(2) = int_HostGroup
        rowVals(3) = str_IPAddr
        rowVals(4) = str_Port
        rowVals(5) = str_UserName
        rowVals(6) = str_Password
        rowVals(7) = int_Auth
        rowVals(8) = str_Url
        rowVals(9) = str_GetPara
        rowVals(10) = str_PostPara
        rowVals(11) = int_isIcmp

        If Me.Text = "添加设备" Then
            Dim tb_webhost() As DataRow
            tb_webhost = MyCls.hostDataSet.Tables("webhost").Select("IPAddr='" & str_IPAddr & "'")
            If tb_webhost.Length > 0 Then
                MessageBox.Show(str_IPAddr & " 已经存在，请重新输入。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_IPAddr.Focus()
                Exit Sub
            End If

            sql = "insert into webhost(hostName,HostGroup,IPAddr,Port,UserName,Password,Auth,Url,GetPara,PostPara,isicmp)"
            sql = sql & "values('" & str_hostName & "'," & int_HostGroup & ",'" & str_IPAddr & "'," &
                "'" & str_Port & "','" & str_UserName & "','" & str_Password & "'," & int_Auth & "," &
                "'" & str_Url & "','" & str_GetPara & "','" & str_PostPara & "'," & int_isIcmp & ");select last_insert_id();"
            h_id = MyCls.setValue(sql) '写入主机数据
            If h_id <= 0 Then
                MessageBox.Show("添加设备失败了，请重试。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                rowVals(0) = h_id
                addHostList(rowVals)
            End If
        Else        '修改主机
            Dim tmpRet As Integer
            tmpRet = saveChange(rowVals)
            If tmpRet = 1 Then Exit Sub
        End If
        main.TreeView1.SelectedNode = main.TreeView1.Nodes.Item(int_HostGroup.ToString)
        main.TreeView1.SelectedNode.Expand()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadHostGroup()
    End Sub
    Dim h_id As Integer = 0 '主机id
    Function ret_HostGroupId() As Integer

        Dim tb_webhost() As DataRow
        tb_webhost = MyCls.hostDataSet.Tables("webhost").Select("id=" & h_id)

        Dim int_HostGroup, int_Auth, int_isIcmp As Integer
        txt_HostName.Text = tb_webhost(0)("hostName")
        int_HostGroup = tb_webhost(0)("HostGroup")
        txt_IPAddr.Text = tb_webhost(0)("IPAddr")
        txt_Port.Text = tb_webhost(0)("Port")
        txt_UserName.Text = tb_webhost(0)("UserName")
        txt_Password.Text = MyCls.FromBase64(tb_webhost(0)("Password"))
        int_Auth = tb_webhost(0)("Auth")
        If int_Auth = 1 Then
            rdb_Server.Checked = True
        Else
            rdb_Session.Checked = True
        End If
        txt_Url.Text = tb_webhost(0)("Url")
        txt_GetPara.Text = tb_webhost(0)("GetPara")
        txt_PostPara.Text = tb_webhost(0)("PostPara")
        int_isIcmp = tb_webhost(0)("isicmp")
        If int_isIcmp = 1 Then
            ckb_isIcmp.Checked = True
        Else
            ckb_isIcmp.Checked = False
        End If

        Return int_HostGroup
    End Function
    Sub loadHostGroup()
        Dim t_Hg As Integer = 0
        If Me.Text = "添加设备" Then
            t_Hg = main.TreeView1.SelectedNode.Name
        Else
            h_id = main.TreeView1.SelectedNode.Name
            t_Hg = ret_HostGroupId()
        End If

        Dim hg_idx As Integer = 0

        Dim tb_hostGroup As DataTable
        tb_hostGroup = MyCls.hostDataSet.Tables("hostGroup")
        Dim tb_gn As String, tb_id As Integer
        cmb_HostGroup.Items.Clear()
        For i = 0 To tb_hostGroup.Rows.Count - 1
            tb_id = tb_hostGroup.Rows(i)("id")
            tb_gn = tb_hostGroup.Rows(i)("groupName")
            cmb_HostGroup.Items.Add(New item(tb_id, tb_gn))
            If tb_id = t_Hg Then hg_idx = i
        Next

        If tb_hostGroup.Rows.Count > 0 Then
            If t_Hg = 0 Then
                cmb_HostGroup.Text = ""
            Else
                cmb_HostGroup.SelectedIndex = hg_idx
            End If
        End If
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
    Function saveChange(ByVal RowVals() As Object) As Integer '保存主机
        Dim tmpRet As Integer = 0
        Dim tb_webhost() As DataRow
        Dim sql As String = ""
        tb_webhost = MyCls.hostDataSet.Tables("webhost").Select(" id=" & RowVals(0) & " or IPAddr='" & RowVals(3) & "'")
        If tb_webhost.Length = 1 Then
            Dim old_hg As String
            With tb_webhost(0)
                old_hg = .Item("HostGroup")
            End With
            tb_webhost(0).ItemArray = RowVals
            MyCls.hostDataSet.Tables("webhost").AcceptChanges()
            sql = "select id,hostName,HostGroup,IPAddr,Port,UserName,Password,Auth,Url,GetPara,PostPara,isicmp from webHost where id=" & h_id
            Dim tmpDs As New DataSet
            tmpDs = MyCls.FillDataset("webHost", sql)
            If tmpDs.Tables(0).Rows.Count > 0 Then
                tmpDs.Tables(0).Rows(0).ItemArray = RowVals
                MyCls.UpdataDataTab(sql, tmpDs.Tables(0))
            End If
            tmpDs.Dispose()
            If old_hg = RowVals(2) Then
                main.TreeView1.Nodes.Item(RowVals(2).ToString).Nodes.Item(RowVals(0).ToString).Text = RowVals(1)
            Else
                main.TreeView1.Nodes.Item(old_hg.ToString).Nodes.Item(RowVals(0).ToString).Remove()
                main.TreeView1.Nodes.Item(RowVals(2).ToString).Nodes.Add(RowVals(0), RowVals(1), 2, 2)
            End If
        ElseIf tb_webhost.Length > 1 Then
            MessageBox.Show("这个IP地址已经存在，请重新输入。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_IPAddr.Focus()
            tmpRet = 1
        End If
        Return tmpRet
    End Function

    Private Sub txt_Port_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Port.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Microsoft.VisualBasic.ChrW(8)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

End Class
