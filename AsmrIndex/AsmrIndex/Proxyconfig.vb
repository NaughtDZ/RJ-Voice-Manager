Public Class Proxyconfig
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Text = "已启用"
        Button1.Enabled = False
        SetProxy(Textproxy.Text)  'HTTP代理
        WebBrowser1.Navigate("www.google.com")   ' 检测代理WEB是否成功
    End Sub
End Class