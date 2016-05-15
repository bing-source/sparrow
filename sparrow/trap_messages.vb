Public Class trap_messages
    Private Sub alarForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadHostGroup()
        tool_Hostgroup.SelectedIndex = 0
        tool_level.SelectedIndex = 0
        tool_ischk.SelectedIndex = 0
        Call loadpages()
    End Sub
    Sub loadHostGroup()
        MyCls.load_hostGroup()
        Dim hg_idx As Integer = 0
        Dim tb_hostGroup As DataTable
        tb_hostGroup = MyCls.hostDataSet.Tables("hostGroup")
        Dim tb_gn As String, tb_id As Integer
        tool_Hostgroup.Items.Clear()
        tool_Hostgroup.Items.Add(New item(-1, "All"))
        tool_Hostgroup.Items.Add(New item(0, "[Default]"))
        For i = 0 To tb_hostGroup.Rows.Count - 1
            tb_id = tb_hostGroup.Rows(i)("id")
            tb_gn = tb_hostGroup.Rows(i)("groupName")
            tool_Hostgroup.Items.Add(New item(tb_id, tb_gn))
        Next
    End Sub
    Dim page As String = 1, allpage As Integer = 1
    Dim dataDs As DataSet

    Private Sub tool_search_Click(sender As Object, e As EventArgs) Handles tool_search.Click
        page = 1
        Call loadpages()
    End Sub

    Private Sub tool_start_Click(sender As Object, e As EventArgs) Handles tool_start.Click
        page = 1
        Call loadpages()
    End Sub

    Private Sub tool_prev_Click(sender As Object, e As EventArgs) Handles tool_prev.Click
        page = page - 1
        Call loadpages()
    End Sub

    Private Sub tool_next_Click(sender As Object, e As EventArgs) Handles tool_next.Click
        page = page + 1
        Call loadpages()
    End Sub

    Private Sub tool_end_Click(sender As Object, e As EventArgs) Handles tool_end.Click
        page = allpage
        Call loadpages()
    End Sub

    Private Sub tool_goto_Click(sender As Object, e As EventArgs) Handles tool_goto.Click
        page = tool_gobox.Text
        If page = "" Or IsNumeric(page) = False Then page = 1
        If page <= 0 Then
            page = 1
        ElseIf page > allpage Then
            page = allpage
        End If
        tool_gobox.Text = page
        Call loadpages()
    End Sub
    Function getRowIndex() As IEnumerable(Of Integer)
        Dim nidx As IEnumerable(Of Integer)
        Dim idx() As Integer
        Dim allcell As Integer = DataGridView1.SelectedCells.Count
        ReDim idx(allcell - 1)
        For i = 0 To allcell - 1
            idx(i) = DataGridView1.SelectedCells(i).RowIndex
        Next
        nidx = idx.Distinct
        Return nidx
    End Function

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        btn_ok.Enabled = False
        Call sub_ok()
        btn_ok.Enabled = True
    End Sub
    Sub sub_ok()
        Dim ret As DialogResult = MessageBox.Show("你要确定所选择的告警信息吗？", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ret = 7 Then Return
        Dim nidx As IEnumerable(Of Integer) = getRowIndex()

        Dim vid As Integer = 0, aschk As String = "", sql As String = ""
        For i = 0 To nidx.Count - 1
            With DataGridView1.Rows(nidx(i))
                vid = .Cells("id").Value
                aschk = .Cells("aschk").Value
                If aschk = "否" Then
                    .Cells("aschk").Value = "是"
                    sql += "update trap_messages set confirmed=1 where id=" & vid & ";"
                End If
            End With
        Next
        If sql <> "" Then
            MyCls.setValue_batch(sql.Split(";"))
        End If
    End Sub

    Private Sub btn_del_Click(sender As Object, e As EventArgs) Handles btn_del.Click
        btn_del.Enabled = False
        Call sub_del()
        btn_del.Enabled = True
    End Sub

    Sub loadpages()
        If page = "" Or IsNumeric(page) = False Then page = 1
        Const pagesize As Integer = 100
        Dim sfields, tabnames, strWhere, strOrder As String
        tabnames = "trap_messages"
        strOrder = "id desc"
        sfields = "id,create_at,ipaddr,hostname,case when level=0 then '信息' when level=1 then '警告' when level=2 then '严重' end aslevel,message,case when confirmed=0 then '否' else '是' end aschk"
        strWhere = ""
        Dim ischk As String = Trim(tool_ischk.SelectedIndex)
        If ischk = 0 Then
            strWhere += " confirmed=0"
        Else
            strWhere += " confirmed=1"
        End If
        Dim kw As String = Trim(tool_Keywords.Text)
        If kw <> "" Then
            strWhere += " and ipaddr= '" & kw & "'"
        End If
        Dim isgroup As Integer = tool_Hostgroup.SelectedItem.id
        If isgroup >= 0 Then
            strWhere += " and hostgroup=" & isgroup
        End If

        Dim islevel As Integer = Trim(tool_level.SelectedIndex)
        Select Case islevel
            Case 1
                strWhere += " and level=0"
            Case 2
                strWhere += " and level=1"
            Case 3
                strWhere += " and level=2"
        End Select
        Dim pagenum As Integer = (page - 1) * pagesize
        Dim sql As String = "select SQL_CALC_FOUND_ROWS " & sfields & " from " & tabnames & " where " & strWhere & " order by " & strOrder & " limit " & pagenum & "," & pagesize & ";" &
            "select FOUND_ROWS()totalNum;"
        dataDs = MyCls.FillDataset("trap_messages", sql)
        If dataDs Is Nothing Then
            MyCls.WriteLog("日志加载失败！SQL语句：" & sql)
            Return
        End If
        DataGridView1.DataSource = dataDs.Tables(0)
        With DataGridView1.Columns
            .Item("id").ReadOnly = True
            .Item("id").HeaderText = "ID"
            .Item("id").Width = 0
            .Item("id").Visible = False

            .Item("create_at").ReadOnly = True
            .Item("create_at").HeaderText = "时间"
            .Item("create_at").Width = 120
            '.Item("create_at").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Item("ipaddr").ReadOnly = True
            .Item("ipaddr").HeaderText = "IP地址"
            .Item("ipaddr").Width = 100

            .Item("hostname").ReadOnly = True
            .Item("hostname").HeaderText = "主机名"
            .Item("hostname").Width = 160

            .Item("aslevel").ReadOnly = True
            .Item("aslevel").HeaderText = "级别"
            .Item("aslevel").Width = 80
            ' .Item("aslevel").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Item("message").ReadOnly = True
            .Item("message").HeaderText = "描述"
            .Item("message").Width = 400

            .Item("aschk").ReadOnly = True
            .Item("aschk").HeaderText = "确定"
            .Item("aschk").Width = 80
            ' .Item("aschk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Dim totalNum As Integer = 0
        If dataDs.Tables(1).Rows.Count > 0 Then
            totalNum = dataDs.Tables(1).Rows(0)("totalNum")
        End If
        allpage = totalNum \ pagesize
        If totalNum Mod pagesize <> 0 Then
            allpage = allpage + 1
        ElseIf allpage <= 0 Then
            allpage = 1
        End If
        tool_pagetxt.Text = page & "/" & allpage
        tool_start.Enabled = True
        tool_prev.Enabled = True
        tool_next.Enabled = True
        tool_end.Enabled = True
        If page = 1 Then
            tool_start.Enabled = False
            tool_prev.Enabled = False
        End If
        If page >= allpage Then
            tool_next.Enabled = False
            tool_end.Enabled = False
        End If
        tool_gobox.Text = page
    End Sub

    Private Sub btn_excvs_Click(sender As Object, e As EventArgs) Handles btn_excvs.Click
        Call MyCls.DataGridViewToExcel(DataGridView1)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Sub sub_del()
        Dim ret As DialogResult = MessageBox.Show("你要删除所选择的告警信息吗？", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ret = 7 Then Return
        Dim nidx As IEnumerable(Of Integer) = getRowIndex()
        Dim vid As Integer = 0, sql As String = ""
        For i = 0 To nidx.Count - 1
            With DataGridView1.Rows(nidx(i))
                vid = .Cells("id").Value
            End With
            'DataGridView1.Rows.Remove(DataGridView1.Rows(nidx(i)))
            sql += "delete from trap_messages where id=" & vid & ";"
        Next
        MyCls.setValue_batch(sql.Split(";"))
        Call loadpages()
    End Sub
End Class