<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proxyconfig
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Textproxy = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'Textproxy
        '
        Me.Textproxy.Location = New System.Drawing.Point(71, 6)
        Me.Textproxy.Name = "Textproxy"
        Me.Textproxy.Size = New System.Drawing.Size(187, 21)
        Me.Textproxy.TabIndex = 0
        Me.Textproxy.Text = "例如: 127.0.0.1:2081"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "代理地址"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(71, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 30)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "启用代理"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "若要停止代理，请退出程序！"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(12, 81)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(243, 169)
        Me.WebBrowser1.TabIndex = 4
        '
        'Proxyconfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 262)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Textproxy)
        Me.Name = "Proxyconfig"
        Me.Text = "Proxyconfig"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Textproxy As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents WebBrowser1 As WebBrowser
End Class
