﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormChangedDimension
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
        Me.ButtonEnter = New System.Windows.Forms.Button()
        Me.ComboBoxFrom = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxTo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonEnter
        '
        Me.ButtonEnter.Location = New System.Drawing.Point(201, 136)
        Me.ButtonEnter.Name = "ButtonEnter"
        Me.ButtonEnter.Size = New System.Drawing.Size(118, 45)
        Me.ButtonEnter.TabIndex = 49
        Me.ButtonEnter.Text = "确定"
        Me.ButtonEnter.UseVisualStyleBackColor = True
        '
        'ComboBoxFrom
        '
        Me.ComboBoxFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFrom.FormattingEnabled = True
        Me.ComboBoxFrom.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ComboBoxFrom.IntegralHeight = False
        Me.ComboBoxFrom.Location = New System.Drawing.Point(105, 41)
        Me.ComboBoxFrom.Name = "ComboBoxFrom"
        Me.ComboBoxFrom.Size = New System.Drawing.Size(214, 28)
        Me.ComboBoxFrom.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 20)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "出发维度："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 19)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "本触发器在玩家在两个维度间旅行时触发"
        '
        'ComboBoxTo
        '
        Me.ComboBoxTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTo.FormattingEnabled = True
        Me.ComboBoxTo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ComboBoxTo.IntegralHeight = False
        Me.ComboBoxTo.Location = New System.Drawing.Point(105, 75)
        Me.ComboBoxTo.Name = "ComboBoxTo"
        Me.ComboBoxTo.Size = New System.Drawing.Size(214, 28)
        Me.ComboBoxTo.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 78)
        Me.Label3.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 20)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "到达维度："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(16, 136)
        Me.Label4.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 20)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "大多数条件是可选的"
        '
        'FormChangedDimension
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 193)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBoxTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonEnter)
        Me.Controls.Add(Me.ComboBoxFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FormChangedDimension"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "#2进度修改者_条件编辑器"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonEnter As Button
    Friend WithEvents ComboBoxFrom As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxTo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
