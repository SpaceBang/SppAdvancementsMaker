﻿Imports System.IO

Public Class FormSelectSave
    Private Bool1 As Boolean

    Private Sub ButtonSelectSave_Click(sender As Object, e As EventArgs) Handles ButtonSelectSave.Click
        FolderBrowserDialog1.ShowNewFolderButton = False
        If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim StrTemps As String() = FolderBrowserDialog1.SelectedPath.Split("\")
            If StrTemps(UBound(StrTemps) - 1) = "saves" Then
                TextBoxSavePath.Text = FolderBrowserDialog1.SelectedPath
            Else
                If StrTemps(UBound(StrTemps)) = "saves" Then
                    MessageBox.Show("选择存档，不是选择 saves 文件夹！")
                ElseIf StrTemps(UBound(StrTemps)) = ".minecraft" Then
                    MessageBox.Show("选择存档，不是选择 .minecraft 文件夹！")
                ElseIf StrTemps(UBound(StrTemps)) = "data" Then
                    MessageBox.Show("选择存档，不是选择 data 文件夹！")
                Else
                    MessageBox.Show("请选择正确的游戏存档")
                End If
            End If
        End If
        TextBoxSavePath.SelectionStart = TextBoxSavePath.TextLength
    End Sub

    Private Sub ButtonEnter_Click(sender As Object, e As EventArgs) Handles ButtonEnter.Click
        ' 保存路径 打开主窗体
        If PanelOffline.Visible Then
            StrSavePath = TextBoxSavePath.Text
        Else
            If ListBoxSaves.SelectedItem IsNot Nothing Then
                StrSavePath = Environment.GetEnvironmentVariable("APPDATA") & "\.minecraft\saves\" & ListBoxSaves.SelectedItem.ToString
            Else
                ButtonEnter.Enabled = False
                Exit Sub
            End If
        End If
            FormSelectAdvancement.Show()
        Hide()
    End Sub

    Private Sub TextBoxSavePath_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSavePath.TextChanged
        If TextBoxSavePath.Text <> "" Then
            Bool1 = True
        Else
            Bool1 = False
        End If
        If Bool1 Then
            ButtonEnter.Enabled = True
        Else
            ButtonEnter.Enabled = False
        End If
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        MessageBox.Show("Copyright (c) 2007 James Newton-King

Permission is hereby granted, free of charge, to any person obtaining a copy of this
software and associated documentation files (the ""Software""), to deal in the Software
without restriction, including without limitation the rights to use, copy, modify,
merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be included in all copies
or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""As Is"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.")
    End Sub
    Private Sub FormSelectSave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(Application.StartupPath & "\Newtonsoft.Json.dll") Then
            MessageBox.Show("你为什么要删掉'Newtonsoft.Json.dll'QwQ 软件打不开了啦！")
            End
        End If
        If Not Directory.Exists(Application.StartupPath & "\advancements") Then
            MessageBox.Show("你为什么要删掉'advancements'文件夹QwQ 软件打不开了啦！")
            End
        End If
        ' 获取正版 Minecraft 的默认路径
        Dim StrPath As String = Environment.GetEnvironmentVariable("APPDATA") & "\.minecraft\saves\"
        If Dir(StrPath, vbDirectory) <> "" Then
            ' 如果有正版默认路径 就显示正版的存档列表
            PanelOffline.Visible = False
            PanelOnline.Visible = True
        Else
            PanelOffline.Visible = True
            PanelOnline.Visible = False
        End If
    End Sub
    Private Sub FormSelectSave_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim StrPath As String = Environment.GetEnvironmentVariable("APPDATA") & "\.minecraft\saves\"
        If Dir(StrPath, vbDirectory) <> "" Then
            ListBoxSaves.Items.Clear()
            Dim StrSaveNames As String()
            ' 获取所有存档
            StrSaveNames = Directory.GetDirectories(StrPath, "*", SearchOption.TopDirectoryOnly)
            ' 取存档名
            For Each StrSaveName As String In StrSaveNames
                StrSaveName = StrSaveName.Split("\")(UBound(StrSaveName.Split("\")))
                ListBoxSaves.Items.Add(StrSaveName)
            Next
        End If
    End Sub
    Private Sub LabelOffline_Click(sender As Object, e As EventArgs) Handles LabelOffline.Click
        PanelOffline.Visible = True
        PanelOnline.Visible = False
    End Sub

    Private Sub ListBoxSaves_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxSaves.SelectedIndexChanged
        If ListBoxSaves.SelectedIndex >= 0 Then
            ButtonEnter.Enabled = True
        Else
            ButtonEnter.Enabled = False
        End If
    End Sub
End Class