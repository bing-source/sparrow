Public Class group_settings
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str_groupName As String, int_sort As Integer
        If IsNumeric(txt_sort.Text.Trim) = False Then
            MessageBox.Show("请输入一个有效的排序ID。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_sort.Focus()
            Exit Sub
        End If
        int_sort = txt_sort.Text
        str_groupName = txt_hostGroup.Text.Trim
        If str_groupName = "" Then
            MessageBox.Show("请输入一个有效的设备组名称。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_hostGroup.Focus()
            Exit Sub
        End If
        If str_groupName.ToUpper = "DEFAULT" Or str_groupName.ToUpper = "[DEFAULT]" Then
            MessageBox.Show("Default 是系统保留的名称，请使用其它名称。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_hostGroup.Focus()
            Exit Sub
        End If
        Dim ret As Boolean = findHostGroup(str_groupName)
        If ret = True Then
            MessageBox.Show(str_groupName & " 已经存在，请使用其它名称。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_hostGroup.Focus()
            Exit Sub
        End If
        ret = isChange(str_groupName, int_sort)
        If ret = True Then '数据被修改后
            saveHostGroup(str_groupName, int_sort)
        End If
        '重新加载组列表
        Call main.reloadhost_tree()
        main.TreeView1.SelectedNode = main.TreeView1.Nodes.Item(h_id.ToString)
        main.TreeView1.SelectedNode.Expand()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Dim h_id As Integer = 0
    Private Sub frm_modGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        h_id = main.TreeView1.SelectedNode.Name
        Call loadHostGroup()
    End Sub
    Sub loadHostGroup()
        Dim tb_hostGroup() As DataRow
        tb_hostGroup = MyCls.hostDataSet.Tables("hostGroup").Select("id=" & h_id)
        Dim tb_gn As String, tb_id, tb_sort As Integer
        For i = 0 To tb_hostGroup.GetUpperBound(0)
            tb_id = tb_hostGroup(i)("id")
            tb_gn = tb_hostGroup(i)("groupName")
            tb_sort = tb_hostGroup(i)("sort")
            If h_id = tb_id Then
                txt_hostGroup.Text = tb_gn
                txt_sort.Text = tb_sort
                Exit For
            End If
        Next
    End Sub
    Function findHostGroup(ByVal str As String) As Boolean  '查找是否重名
        Dim ret As Boolean = False
        Dim tb_hostGroup() As DataRow
        tb_hostGroup = MyCls.hostDataSet.Tables("hostGroup").Select("id<>" & h_id)
        Dim tb_gn As String
        For i = 0 To tb_hostGroup.GetUpperBound(0)
            tb_gn = tb_hostGroup(i)("groupName")
            If tb_gn = str Then
                ret = True
                Exit For
            End If
        Next
        Return ret
    End Function
    Function isChange(ByVal str As String, ByVal sort As Integer) As Boolean  '查找是否更改
        Dim ret As Boolean = True
        Dim tb_hostGroup() As DataRow
        tb_hostGroup = MyCls.hostDataSet.Tables("hostGroup").Select("id=" & h_id & " and sort=" & sort & " and groupName='" & str & "'")

        If tb_hostGroup.GetUpperBound(0) >= 0 Then
            ret = False
        End If

        Return ret
    End Function
    Sub saveHostGroup(ByVal str As String, ByVal sort As Integer) '保存数据
        Dim ret As Boolean = True
        Dim tb_hostGroup() As DataRow
        tb_hostGroup = MyCls.hostDataSet.Tables("hostGroup").Select("id=" & h_id)
        If tb_hostGroup.GetUpperBound(0) >= 0 Then
            tb_hostGroup(0)("groupName") = str
            tb_hostGroup(0)("sort") = sort
            MyCls.hostDataSet.Tables("hostGroup").AcceptChanges()
        End If
        Dim sql As String
        sql = "update hostgroup set groupname='" & str & "',sort=" & sort & " where id=" & h_id & ";"
        MyCls.setValue(sql)
        main.TreeView1.SelectedNode.Text = str
    End Sub
    Private Sub txt_sort_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_sort.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Microsoft.VisualBasic.ChrW(8)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class