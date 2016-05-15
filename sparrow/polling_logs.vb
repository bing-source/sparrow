Public Class polling_logs
    Private Sub logForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tool_ischk.SelectedIndex = 0
        Call loadpages()
    End Sub
    Dim page As String = 1, allpage As Integer = 1
    Dim dataDs As DataSet
    Sub loadpages()
        If page = "" Or IsNumeric(page) = False Then page = 1
        Const pagesize As Integer = 100
        Dim sfields, tabnames, strWhere, strOrder As String

        tabnames = "polling_logs"
        strOrder = "id desc"
        sfields = "id,create_at,logtxt,case when ischk=0 then 'No' else 'Yes' end aschk"
        strWhere = ""
        Dim ischk As String = Trim(tool_ischk.SelectedIndex)
        If ischk = 0 Then
            strWhere += " ischk=0"
        Else
            strWhere += " ischk=1"
        End If
        Dim kw As String = Trim(tool_Keywords.Text)
        If kw <> "" Then
            strWhere += " and (logtxt like '%" & kw & "%')"
        End If

        Dim pagenum As Integer = (page - 1) * pagesize
        Dim sql As String = "select SQL_CALC_FOUND_ROWS " & sfields & " from " & tabnames & " where " & strWhere & " order by " & strOrder & " limit " & pagenum & "," & pagesize & ";" & "select FOUND_ROWS()totalNum;"
        dataDs = MyCls.FillDataset("polling_logs", sql)
        If dataDs Is Nothing Then
            MyCls.WriteLog("日志加载失败！SQL语句：" & sql)
            Return
        End If
        DataGridView1.DataSource = dataDs.Tables(0)
        With DataGridView1.Columns
            .Item("id").ReadOnly = True
            .Item("id").HeaderText = "ID"
            .Item("id").Width = 45
            .Item("id").Visible = False

            .Item("create_at").ReadOnly = True
            .Item("create_at").HeaderText = "Date"
            .Item("create_at").Width = 130
            .Item("create_at").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Item("logtxt").ReadOnly = True
            .Item("logtxt").HeaderText = "Description"
            .Item("logtxt").Width = 490

            .Item("aschk").ReadOnly = True
            .Item("aschk").HeaderText = "Confirmed"
            .Item("aschk").Width = 80
            .Item("aschk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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

    Private Sub tool_btn_goto_Click(sender As Object, e As EventArgs) Handles tool_goto.Click
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

    Private Sub tool_search_Click(sender As Object, e As EventArgs) Handles tool_search.Click
        page = 1
        Call loadpages()
    End Sub

    Private Sub tool_gobox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tool_gobox.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Microsoft.VisualBasic.ChrW(8)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        btn_ok.Enabled = False
        Call sub_ok()
        btn_ok.Enabled = True
    End Sub

    Private Sub tool_end_Click(sender As Object, e As EventArgs) Handles tool_end.Click
        page = allpage
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

    Private Sub meu_ok_Click(sender As Object, e As EventArgs) Handles meu_ok.Click
        meu_ok.Enabled = False
        Call sub_ok()
        meu_ok.Enabled = True
    End Sub

    Private Sub meu_ref_Click(sender As Object, e As EventArgs) Handles meu_ref.Click
        meu_ref.Enabled = False
        DataGridView1.DataSource = Nothing
        Call loadpages()
        meu_ref.Enabled = True
    End Sub

    Private Sub btn_del_Click(sender As Object, e As EventArgs) Handles btn_del.Click
        btn_del.Enabled = False
        Call sub_del()
        btn_del.Enabled = True
    End Sub

    Sub sub_ok()
        Dim ret As DialogResult = MessageBox.Show("Are you sure to confirm the selected records?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ret = 7 Then Return
        Dim nidx As IEnumerable(Of Integer) = getRowIndex()
        Dim vid As Integer = 0, aschk As String = "", sql As String = ""
        For i = 0 To nidx.Count - 1
            With DataGridView1.Rows(nidx(i))
                vid = .Cells("id").Value
                aschk = .Cells("aschk").Value
                If aschk = "No" Then
                    .Cells("aschk").Value = "Yes"
                    sql += "update polling_logs set ischk=1 where id=" & vid & ";"
                End If
            End With
        Next
        If sql <> "" Then
            MyCls.setValue_batch(sql.Split(";"))
        End If

    End Sub

    Private Sub meu_del_Click(sender As Object, e As EventArgs) Handles meu_del.Click
        meu_del.Enabled = False
        Call sub_del()
        meu_del.Enabled = True
    End Sub

    Private Sub btn_excvs_Click(sender As Object, e As EventArgs) Handles btn_excvs.Click
        Call MyCls.DataGridViewToExcel(DataGridView1)
    End Sub

    Private Sub meu_excvs_Click(sender As Object, e As EventArgs) Handles meu_excvs.Click
        meu_excvs.Enabled = False
        Call MyCls.DataGridViewToExcel(DataGridView1)
        meu_excvs.Enabled = True
    End Sub

    Sub sub_del()
        Dim ret As DialogResult = MessageBox.Show("Are you sure to delete the selected records?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ret = 7 Then Return
        Dim nidx As IEnumerable(Of Integer) = getRowIndex()
        Dim vid As Integer = 0, sql As String = ""
        For i = 0 To nidx.Count - 1
            With DataGridView1.Rows(nidx(i))
                vid = .Cells("id").Value
            End With
            sql += "delete from polling_logs where id=" & vid & ";"
        Next
        If sql <> "" Then
            MyCls.setValue_batch(sql.Split(";"))
        End If
        Call loadpages()
    End Sub
End Class