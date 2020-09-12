<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.TextBoxName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ButtonDL = New System.Windows.Forms.Button()
        Me.DriveListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_Shetuan = New System.Windows.Forms.RadioButton()
        Me.RadioButton_SellDate = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Shengyou = New System.Windows.Forms.RadioButton()
        Me.RadioButton_FromLocal = New System.Windows.Forms.RadioButton()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(338, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "导入批量音声进数据库"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(623, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 40)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "初次使用？"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(338, 459)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(97, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "从数据库刷新"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(338, 494)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(97, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "清空数据库"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(443, 62)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(290, 225)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(550, 332)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(183, 21)
        Me.TextBox1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(441, 335)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "RJ号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(441, 362)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "声优"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(441, 389)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "贩售日期"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(441, 416)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "社团"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label5.Location = New System.Drawing.Point(441, 443)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "本地封面地址"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(441, 470)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "本地音声地址"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(550, 359)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(183, 21)
        Me.TextBox2.TabIndex = 9
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(550, 386)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(183, 21)
        Me.TextBox3.TabIndex = 9
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(550, 413)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(183, 21)
        Me.TextBox4.TabIndex = 9
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(550, 440)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(183, 21)
        Me.TextBox5.TabIndex = 9
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(550, 467)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(183, 21)
        Me.TextBox6.TabIndex = 9
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(550, 494)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(74, 23)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "手动更新"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(658, 494)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "删除本条"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"RJ号", "声优", "贩售日期", "社团", "名字"})
        Me.ComboBox1.Location = New System.Drawing.Point(338, 67)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(99, 20)
        Me.ComboBox1.TabIndex = 13
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(338, 93)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(99, 21)
        Me.TextBox7.TabIndex = 14
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(346, 124)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(80, 23)
        Me.Button7.TabIndex = 15
        Me.Button7.Text = "搜"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(303, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "搜索"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(303, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "按照"
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 12
        Me.ListBox2.Location = New System.Drawing.Point(338, 164)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(97, 292)
        Me.ListBox2.TabIndex = 18
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(500, 12)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(117, 40)
        Me.Button8.TabIndex = 19
        Me.Button8.Text = "无法连接DLsite?"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'TextBoxName
        '
        Me.TextBoxName.Location = New System.Drawing.Point(550, 305)
        Me.TextBoxName.Name = "TextBoxName"
        Me.TextBoxName.Size = New System.Drawing.Size(183, 21)
        Me.TextBoxName.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(441, 308)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "名字"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(184, 42)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(110, 448)
        Me.ListBox1.TabIndex = 3
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(443, 12)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(38, 32)
        Me.WebBrowser1.TabIndex = 20
        Me.WebBrowser1.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(443, 520)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(84, 16)
        Me.CheckBox1.TabIndex = 21
        Me.CheckBox1.Text = "自动DL加载"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ButtonDL
        '
        Me.ButtonDL.Location = New System.Drawing.Point(443, 494)
        Me.ButtonDL.Name = "ButtonDL"
        Me.ButtonDL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonDL.Size = New System.Drawing.Size(101, 23)
        Me.ButtonDL.TabIndex = 22
        Me.ButtonDL.Text = "从Dlsite上加载"
        Me.ButtonDL.UseVisualStyleBackColor = True
        '
        'DriveListBox1
        '
        Me.DriveListBox1.FormattingEnabled = True
        Me.DriveListBox1.Location = New System.Drawing.Point(12, 12)
        Me.DriveListBox1.Name = "DriveListBox1"
        Me.DriveListBox1.Size = New System.Drawing.Size(282, 22)
        Me.DriveListBox1.TabIndex = 24
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 42)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(166, 448)
        Me.TreeView1.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton_Shetuan)
        Me.GroupBox1.Controls.Add(Me.RadioButton_SellDate)
        Me.GroupBox1.Controls.Add(Me.RadioButton_Shengyou)
        Me.GroupBox1.Controls.Add(Me.RadioButton_FromLocal)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 501)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 35)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "浏览来源"
        '
        'RadioButton_Shetuan
        '
        Me.RadioButton_Shetuan.AutoSize = True
        Me.RadioButton_Shetuan.Location = New System.Drawing.Point(189, 13)
        Me.RadioButton_Shetuan.Name = "RadioButton_Shetuan"
        Me.RadioButton_Shetuan.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton_Shetuan.TabIndex = 3
        Me.RadioButton_Shetuan.TabStop = True
        Me.RadioButton_Shetuan.Text = "社团"
        Me.RadioButton_Shetuan.UseVisualStyleBackColor = True
        '
        'RadioButton_SellDate
        '
        Me.RadioButton_SellDate.AutoSize = True
        Me.RadioButton_SellDate.Location = New System.Drawing.Point(112, 13)
        Me.RadioButton_SellDate.Name = "RadioButton_SellDate"
        Me.RadioButton_SellDate.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton_SellDate.TabIndex = 2
        Me.RadioButton_SellDate.TabStop = True
        Me.RadioButton_SellDate.Text = "贩售日期"
        Me.RadioButton_SellDate.UseVisualStyleBackColor = True
        '
        'RadioButton_Shengyou
        '
        Me.RadioButton_Shengyou.AutoSize = True
        Me.RadioButton_Shengyou.Location = New System.Drawing.Point(59, 13)
        Me.RadioButton_Shengyou.Name = "RadioButton_Shengyou"
        Me.RadioButton_Shengyou.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton_Shengyou.TabIndex = 1
        Me.RadioButton_Shengyou.TabStop = True
        Me.RadioButton_Shengyou.Text = "声优"
        Me.RadioButton_Shengyou.UseVisualStyleBackColor = True
        '
        'RadioButton_FromLocal
        '
        Me.RadioButton_FromLocal.AutoSize = True
        Me.RadioButton_FromLocal.Checked = True
        Me.RadioButton_FromLocal.Location = New System.Drawing.Point(6, 13)
        Me.RadioButton_FromLocal.Name = "RadioButton_FromLocal"
        Me.RadioButton_FromLocal.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton_FromLocal.TabIndex = 0
        Me.RadioButton_FromLocal.TabStop = True
        Me.RadioButton_FromLocal.Text = "本地"
        Me.RadioButton_FromLocal.UseVisualStyleBackColor = True
        '
        'TreeView2
        '
        Me.TreeView2.Location = New System.Drawing.Point(12, 42)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(154, 426)
        Me.TreeView2.TabIndex = 27
        Me.TreeView2.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 548)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.DriveListBox1)
        Me.Controls.Add(Me.ButtonDL)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBoxName)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "RJ音声管理器"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Button8 As Button
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ButtonDL As Button
    Friend WithEvents DriveListBox1 As Compatibility.VB6.DriveListBox
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton_Shetuan As RadioButton
    Friend WithEvents RadioButton_SellDate As RadioButton
    Friend WithEvents RadioButton_Shengyou As RadioButton
    Friend WithEvents RadioButton_FromLocal As RadioButton
    Friend WithEvents TreeView2 As TreeView
End Class
