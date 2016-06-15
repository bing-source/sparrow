Imports System.Net.NetworkInformation

Public Class scan_devices
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txt_startIP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_startIP.KeyPress
        If (Char.IsDigit(e.KeyChar) Or (e.KeyChar = ".") Or (e.KeyChar = Microsoft.VisualBasic.ChrW(8))) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_IPPoolSize_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_IPPoolSize.KeyPress
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = Microsoft.VisualBasic.ChrW(8)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Scan_Click(sender As Object, e As EventArgs) Handles Scan.Click
        If txt_IPPoolSize.TextLength = 0 Then
            MessageBox.Show("数量输入框不能为空", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_IPPoolSize.Focus()
            Exit Sub
        End If

        Dim int_IPPoolsize As Integer = Integer.Parse(txt_IPPoolSize.Text)
        If int_IPPoolsize < 1 Then
            MessageBox.Show("数量必须大于 0 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_IPPoolSize.Focus()
            Exit Sub
        End If

        Dim str_startIP As String = txt_startIP.Text.Trim
        If MyCls.isIP(str_startIP) = False Then
            MessageBox.Show("请输入一个正确的起始 IP 地址。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_startIP.Focus()
            Exit Sub
        End If
        Dim arr_startIP() As String = Split(str_startIP, ".")

        Dim ping As Ping = New Ping()
        Dim arr_pingIPs(255) As String

        Dim int_IPSuffix As Integer = Integer.Parse(arr_startIP(3))
        Dim IP As String
        For i = 0 To int_IPPoolsize - 1
            If int_IPSuffix + i > 254 Then Exit For
            IP = arr_startIP(0) & "." & arr_startIP(1) & "." & arr_startIP(2) & "." & (int_IPSuffix + i).ToString()
            If ping.Send(IP, 1000).Status = IPStatus.Success Then
                arr_pingIPs(i) = IP
            End If
        Next

        Dim form_settings As New devices_settings()
        For Each IP In arr_pingIPs
            If IP = "" Then Continue For
            form_settings.list_ips.Items.Add(IP)
        Next
        form_settings.ShowDialog()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class