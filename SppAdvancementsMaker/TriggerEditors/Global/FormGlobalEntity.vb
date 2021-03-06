﻿Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FormGlobalEntity
    Private ButtonTarget As Button
    ' 状态效果相关
    Private IntEffects As Int16
    Private OldSelectedIndex As Int32 = -1
    Private StrEachEffectJson(127) As String

    ' 常规
    Private Sub FormGlobalEntity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Int16
        ' 读取 ComboBox 们
        ComboBoxEffectName.Items.Add("")
        For i = 0 To UBound(ZhEffects)
            ComboBoxEffectName.Items.Add(ZhEffects(i))
        Next
        ComboBoxType.Items.Add("")
        For i = 0 To UBound(ZhEntityIds)
            ComboBoxType.Items.Add(ZhEntityIds(i))
        Next
    End Sub
    Public Sub Reading(ByRef ButtonTarget As Button, StrType As String())
        On Error Resume Next
        ' 显示本窗体
        Visible = False
        Show()
        ' 读取缺省信息
        ComboBoxType.Items.Clear()
        If StrType(0) <> "N/A" Then
            ComboBoxType.Items.Add("")
            For i As Int16 = 0 To UBound(StrType)
                ComboBoxType.Items.Add(EnToZh(StrType(i), ZhEntityIds, EnEntityIds))
            Next
        Else
            ComboBoxType.Items.Add("")
            For i = 0 To UBound(ZhEntityIds)
                ComboBoxType.Items.Add(ZhEntityIds(i))
            Next
        End If
        ' 读取传送过来的 Json 文本
        Reset()
        Me.ButtonTarget = ButtonTarget
        Dim ObjJson As JObject = CType(JsonConvert.DeserializeObject(ButtonTarget.Tag), JObject)
        If ObjJson.ToString <> "{}" Then
            ' 读取状态效果
            If ObjJson.Item("effects") IsNot Nothing Then
                Dim StrTemp As String = ObjJson.Item("effects").ToString
                Dim ObjTempJson As JObject = CType(JsonConvert.DeserializeObject(StrTemp), JObject)
                ' 遍历所有的状态效果
                For Each ObjJP As JProperty In ObjTempJson.Children
                    ListBoxEffects.Items.Add("效果" & IntEffects)
                    StrEachEffectJson(IntEffects) = ObjJP.ToString.Replace(vbCrLf, "").Replace(" ", "")
                    IntEffects += 1
                Next
                ListBoxEffects.SelectedIndex = ListBoxEffects.Items.Count - 1
            End If
            ' 读取常规
            If ObjJson.Item("distance") IsNot Nothing Then
                If ObjJson.Item("distance").Item("absolute") IsNot Nothing Then
                    If ObjJson.Item("distance").Item("absolute").Item("max") IsNot Nothing Then
                        NumericUpDownAbsoluteMax.Value = ObjJson.Item("distance").Item("absolute").Item("max").ToString
                    End If
                    If ObjJson.Item("distance").Item("absolute").Item("min") IsNot Nothing Then
                        NumericUpDownAbsoluteMin.Value = ObjJson.Item("distance").Item("absolute").Item("min").ToString
                    End If
                    If ObjJson.Item("distance").Item("absolute").Item("max") Is Nothing And ObjJson.Item("distance").Item("absolute").Item("min") Is Nothing Then
                        If ObjJson.Item("distance").Item("absolute").ToString <> "{}" Then
                            NumericUpDownAbsoluteMax.Value = ObjJson.Item("distance").Item("absolute").ToString
                            NumericUpDownAbsoluteMin.Value = ObjJson.Item("distance").Item("absolute").ToString
                        End If
                    End If
                End If
                If ObjJson.Item("distance").Item("horizontal") IsNot Nothing Then
                    If ObjJson.Item("distance").Item("horizontal").Item("max") IsNot Nothing Then
                        NumericUpDownHorizontalMax.Value = ObjJson.Item("distance").Item("horizontal").Item("max").ToString
                    End If
                    If ObjJson.Item("distance").Item("horizontal").Item("min") IsNot Nothing Then
                        NumericUpDownHorizontalMin.Value = ObjJson.Item("distance").Item("horizontal").Item("min").ToString
                    End If
                    If ObjJson.Item("distance").Item("horizontal").Item("max") Is Nothing And ObjJson.Item("distance").Item("horizontal").Item("min") Is Nothing Then
                        If ObjJson.Item("distance").Item("horizontal").ToString <> "{}" Then
                            NumericUpDownHorizontalMax.Value = ObjJson.Item("distance").Item("horizontal").ToString
                            NumericUpDownHorizontalMin.Value = ObjJson.Item("distance").Item("horizontal").ToString
                        End If
                    End If
                End If
                If ObjJson.Item("distance").Item("x") IsNot Nothing Then
                    If ObjJson.Item("distance").Item("x").Item("max") IsNot Nothing Then
                        NumericUpDownXMax.Value = ObjJson.Item("distance").Item("x").Item("max").ToString
                    End If
                    If ObjJson.Item("distance").Item("x").Item("min") IsNot Nothing Then
                        NumericUpDownXMin.Value = ObjJson.Item("distance").Item("x").Item("min").ToString
                    End If
                    If ObjJson.Item("distance").Item("x").Item("max") Is Nothing And ObjJson.Item("distance").Item("x").Item("min") Is Nothing Then
                        If ObjJson.Item("distance").Item("x").ToString <> "{}" Then
                            NumericUpDownXMax.Value = ObjJson.Item("distance").Item("x").ToString
                            NumericUpDownXMin.Value = ObjJson.Item("distance").Item("x").ToString
                        End If
                    End If
                End If
                If ObjJson.Item("distance").Item("y") IsNot Nothing Then
                    If ObjJson.Item("distance").Item("y").Item("max") IsNot Nothing Then
                        NumericUpDownYMax.Value = ObjJson.Item("distance").Item("y").Item("max").ToString
                    End If
                    If ObjJson.Item("distance").Item("y").Item("min") IsNot Nothing Then
                        NumericUpDownYMin.Value = ObjJson.Item("distance").Item("y").Item("min").ToString
                    End If
                    If ObjJson.Item("distance").Item("y").Item("max") Is Nothing And ObjJson.Item("distance").Item("y").Item("min") Is Nothing Then
                        If ObjJson.Item("distance").Item("y").ToString <> "{}" Then
                            NumericUpDownYMax.Value = ObjJson.Item("distance").Item("y").ToString
                            NumericUpDownYMin.Value = ObjJson.Item("distance").Item("y").ToString
                        End If
                    End If
                End If
                If ObjJson.Item("distance").Item("z") IsNot Nothing Then
                    If ObjJson.Item("distance").Item("z").Item("max") IsNot Nothing Then
                        NumericUpDownZMax.Value = ObjJson.Item("distance").Item("z").Item("max").ToString
                    End If
                    If ObjJson.Item("distance").Item("z").Item("min") IsNot Nothing Then
                        NumericUpDownZMin.Value = ObjJson.Item("distance").Item("z").Item("min").ToString
                    End If
                    If ObjJson.Item("distance").Item("z").Item("max") Is Nothing And ObjJson.Item("distance").Item("z").Item("min") Is Nothing Then
                        If ObjJson.Item("distance").Item("z").ToString <> "{}" Then
                            NumericUpDownZMax.Value = ObjJson.Item("distance").Item("z").ToString
                            NumericUpDownZMin.Value = ObjJson.Item("distance").Item("z").ToString
                        End If
                    End If
                End If
            End If
            If ObjJson.Item("location") IsNot Nothing Then
                ButtonLocation.Tag = ObjJson.Item("location").ToString
            End If
            If ObjJson.Item("nbt") IsNot Nothing Then
                TextBoxNbt.Text = ObjJson.Item("nbt").ToString.Replace("\" & Chr(34), Chr(34))
            End If
            If ObjJson.Item("type") IsNot Nothing Then
                ComboBoxType.Text = EnToZh(ObjJson.Item("type").ToString, ZhEntityIds, EnEntityIds)
            End If
        End If
    End Sub
    Private Sub Writing(sender As Object, e As EventArgs) Handles ButtonEnter.Click
        Dim i As Int16
        Dim StrResult As String
        StrResult = "{"
        ' 写入状态效果
        SaveCurrentEffect(OldSelectedIndex)
        If ListBoxEffects.Items.Count >= 1 Then
            StrResult &= Chr(34) & "effects" & Chr(34) & ":" & "{"
            For i = 0 To ListBoxEffects.Items.Count - 1
                StrResult &= StrEachEffectJson(i) & ","
            Next
            StrResult &= "},"
        End If
        ' 写入常规
        If NumericUpDownAbsoluteMax.Value <> 0 Or NumericUpDownAbsoluteMin.Value <> 0 Or NumericUpDownHorizontalMax.Value <> 0 Or NumericUpDownHorizontalMin.Value Or NumericUpDownXMax.Value <> 0 Or NumericUpDownXMin.Value Or NumericUpDownYMax.Value <> 0 Or NumericUpDownYMin.Value Or NumericUpDownZMax.Value <> 0 Or NumericUpDownZMin.Value Then
            StrResult &= Chr(34) & "distance" & Chr(34) & ":" & "{"
            If NumericUpDownAbsoluteMax.Value <> 0 Or NumericUpDownAbsoluteMin.Value <> 0 Then
                StrResult &= Chr(34) & "absolute" & Chr(34) & ":" & "{"
                If NumericUpDownAbsoluteMax.Value <> 0 Then
                    StrResult &= Chr(34) & "max" & Chr(34) & ":" & NumericUpDownAbsoluteMax.Value & ","
                End If
                If NumericUpDownAbsoluteMin.Value <> 0 Then
                    StrResult &= Chr(34) & "min" & Chr(34) & ":" & NumericUpDownAbsoluteMin.Value
                End If
                StrResult &= "},"
            End If
            If NumericUpDownHorizontalMax.Value <> 0 Or NumericUpDownHorizontalMin.Value <> 0 Then
                StrResult &= Chr(34) & "horizontal" & Chr(34) & ":" & "{"
                If NumericUpDownHorizontalMax.Value <> 0 Then
                    StrResult &= Chr(34) & "max" & Chr(34) & ":" & NumericUpDownHorizontalMax.Value & ","
                End If
                If NumericUpDownHorizontalMin.Value <> 0 Then
                    StrResult &= Chr(34) & "min" & Chr(34) & ":" & NumericUpDownHorizontalMin.Value
                End If
                StrResult &= "},"
            End If
            If NumericUpDownXMax.Value <> 0 Or NumericUpDownXMin.Value <> 0 Then
                StrResult &= Chr(34) & "x" & Chr(34) & ":" & "{"
                If NumericUpDownXMax.Value <> 0 Then
                    StrResult &= Chr(34) & "max" & Chr(34) & ":" & NumericUpDownXMax.Value & ","
                End If
                If NumericUpDownXMin.Value <> 0 Then
                    StrResult &= Chr(34) & "min" & Chr(34) & ":" & NumericUpDownXMin.Value
                End If
                StrResult &= "},"
            End If
            If NumericUpDownYMax.Value <> 0 Or NumericUpDownYMin.Value <> 0 Then
                StrResult &= Chr(34) & "y" & Chr(34) & ":" & "{"
                If NumericUpDownYMax.Value <> 0 Then
                    StrResult &= Chr(34) & "max" & Chr(34) & ":" & NumericUpDownYMax.Value & ","
                End If
                If NumericUpDownYMin.Value <> 0 Then
                    StrResult &= Chr(34) & "min" & Chr(34) & ":" & NumericUpDownYMin.Value
                End If
                StrResult &= "},"
            End If
            If NumericUpDownZMax.Value <> 0 Or NumericUpDownZMin.Value <> 0 Then
                StrResult &= Chr(34) & "z" & Chr(34) & ":" & "{"
                If NumericUpDownZMax.Value <> 0 Then
                    StrResult &= Chr(34) & "max" & Chr(34) & ":" & NumericUpDownZMax.Value & ","
                End If
                If NumericUpDownZMin.Value <> 0 Then
                    StrResult &= Chr(34) & "min" & Chr(34) & ":" & NumericUpDownZMin.Value
                End If
                StrResult &= "}"
            End If
            StrResult &= "},"
        End If
        If ButtonLocation.Tag <> "{}" Then
            StrResult &= Chr(34) & "location" & Chr(34) & ":" & ButtonLocation.Tag & ","
        End If
        If TextBoxNbt.Text <> "" Then
            StrResult &= Chr(34) & "nbt" & Chr(34) & ":" & Chr(34) & TextBoxNbt.Text.Replace(Chr(34), "\" & Chr(34)) & Chr(34) & ","
        End If
        If ComboBoxType.Text <> "" Then
            StrResult &= Chr(34) & "type" & Chr(34) & ":" & Chr(34) & ZhToEn(ComboBoxType.Text, ZhEntityIds, EnEntityIds) & Chr(34)
        End If
        StrResult &= "}"
        StrResult = StrResult.Replace(",}", "}")
        StrResult = StrResult.Replace(",]", "]")
        ' 将处理后的 Json 文本返回条件窗体
        ButtonTarget.Tag = StrResult
        Hide()
        ButtonTarget.Parent.Hide()
        ButtonTarget.Parent.Show()
    End Sub
    Private Sub Reset()
        IntEffects = 0
        OldSelectedIndex = -1
        ReDim StrEachEffectJson(127)
        ButtonLocation.Tag = "{}"
        ComboBoxEffectName.SelectedIndex = 0
        ComboBoxType.SelectedIndex = 0
        ListBoxEffects.Items.Clear()
        NumericUpDownAbsoluteMax.Value = 0
        NumericUpDownAbsoluteMin.Value = 0
        NumericUpDownAmplifierMax.Value = 0
        NumericUpDownAmplifierMin.Value = 0
        NumericUpDownDurationMax.Value = 0
        NumericUpDownDurationMin.Value = 0
        NumericUpDownHorizontalMax.Value = 0
        NumericUpDownHorizontalMin.Value = 0
        NumericUpDownXMax.Value = 0
        NumericUpDownXMin.Value = 0
        NumericUpDownYMax.Value = 0
        NumericUpDownYMin.Value = 0
        NumericUpDownZMax.Value = 0
        NumericUpDownZMin.Value = 0
        TextBoxNbt.Text = ""
    End Sub

    ' 状态效果相关
    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        ComboBoxEffectName.Enabled = True
        NumericUpDownAmplifierMax.Enabled = True
        NumericUpDownAmplifierMin.Enabled = True
        NumericUpDownDurationMax.Enabled = True
        NumericUpDownDurationMin.Enabled = True
        ListBoxEffects.SelectedIndex = ListBoxEffects.Items.Add("效果" & IntEffects)
        ComboBoxEffectName.Text = ""
        ComboBoxEffectName.Tag = ""
        NumericUpDownAmplifierMax.Value = 0
        NumericUpDownAmplifierMin.Value = 0
        NumericUpDownDurationMax.Value = 0
        NumericUpDownDurationMin.Value = 0
        IntEffects += 1
    End Sub
    Private Sub ButtonDel_Click(sender As Object, e As EventArgs) Handles ButtonDel.Click
        If ListBoxEffects.SelectedIndex >= 0 Then
            StrEachEffectJson(ListBoxEffects.SelectedIndex) = ""
            ListBoxEffects.Items.Remove(ListBoxEffects.SelectedItem)
        End If
        ButtonDel.Enabled = False
    End Sub
    Private Sub ListBoxEffects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxEffects.SelectedIndexChanged
        ' 保存旧的Effect
        SaveCurrentEffect(OldSelectedIndex)
        If ListBoxEffects.SelectedIndex >= 0 Then
            OldSelectedIndex = Microsoft.VisualBasic.Right(ListBoxEffects.SelectedItem.ToString, ListBoxEffects.SelectedItem.ToString.Length - 2)
            ButtonDel.Enabled = True
        End If
        ' 读取新选中的编辑
        Dim ObjJson As JObject
        If ListBoxEffects.SelectedIndex >= 0 Then
            If StrEachEffectJson(Microsoft.VisualBasic.Right(ListBoxEffects.SelectedItem.ToString, ListBoxEffects.SelectedItem.ToString.Length - 2)) <> "" Then
                ObjJson = CType(JsonConvert.DeserializeObject("{" & StrEachEffectJson(Microsoft.VisualBasic.Right(ListBoxEffects.SelectedItem.ToString, ListBoxEffects.SelectedItem.ToString.Length - 2)) & "}"), JObject)
                If ObjJson.ToString <> "{}" Then
                    Dim StrTemp As String = Mid(ObjJson.ToString.Replace(vbCrLf, "").Replace(" ", ""), 3, ObjJson.ToString.Replace(vbCrLf, "").Replace(" ", "").IndexOf(Chr(34), 2) + 1 - 3)
                    ComboBoxEffectName.Tag = StrTemp
                    ComboBoxEffectName.Text = EnToZh(ComboBoxEffectName.Tag, ZhEffects, EnEffects)
                    If ObjJson.Item(ComboBoxEffectName.Tag) IsNot Nothing Then
                        If ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier") IsNot Nothing Then
                            If ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier").Item("min") IsNot Nothing Then
                                NumericUpDownAmplifierMin.Value = ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier").Item("min").ToString
                            Else
                                NumericUpDownAmplifierMin.Value = 0
                            End If
                            If ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier").Item("max") IsNot Nothing Then
                                NumericUpDownAmplifierMax.Value = ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier").Item("max").ToString
                            Else
                                NumericUpDownAmplifierMax.Value = 0
                            End If
                            If ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier").Item("max") Is Nothing And ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier").Item("min") Is Nothing Then
                                If ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier").ToString <> "{}" Then
                                    NumericUpDownAmplifierMax.Value = ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier").ToString
                                    NumericUpDownAmplifierMin.Value = ObjJson.Item(ComboBoxEffectName.Tag).Item("amplifier").ToString
                                End If
                            End If
                        Else
                            NumericUpDownAmplifierMax.Value = 0
                            NumericUpDownAmplifierMin.Value = 0
                        End If
                        If ObjJson.Item(ComboBoxEffectName.Tag).Item("duration") IsNot Nothing Then
                            If ObjJson.Item(ComboBoxEffectName.Tag).Item("duration").Item("min") IsNot Nothing Then
                                NumericUpDownDurationMin.Value = ObjJson.Item(ComboBoxEffectName.Tag).Item("duration").Item("min").ToString
                            Else
                                NumericUpDownDurationMin.Value = 0
                            End If
                            If ObjJson.Item(ComboBoxEffectName.Tag).Item("duration").Item("max") IsNot Nothing Then
                                NumericUpDownDurationMax.Value = ObjJson.Item(ComboBoxEffectName.Tag).Item("duration").Item("max").ToString
                            Else
                                NumericUpDownDurationMax.Value = 0
                            End If
                            If ObjJson.Item(ComboBoxEffectName.Tag).Item("duration").Item("max") Is Nothing And ObjJson.Item(ComboBoxEffectName.Tag).Item("duration").Item("min") Is Nothing Then
                                If ObjJson.Item(ComboBoxEffectName.Tag).Item("duration").ToString <> "{}" Then
                                    NumericUpDownDurationMax.Value = ObjJson.Item(ComboBoxEffectName.Tag).Item("duration").ToString
                                    NumericUpDownDurationMin.Value = ObjJson.Item(ComboBoxEffectName.Tag).Item("duration").ToString
                                End If
                            End If
                            Else
                            NumericUpDownDurationMax.Value = 0
                            NumericUpDownDurationMin.Value = 0
                        End If
                    Else
                        ComboBoxEffectName.Text = ""
                        ComboBoxEffectName.Tag = ""
                        NumericUpDownAmplifierMax.Value = 0
                        NumericUpDownAmplifierMin.Value = 0
                        NumericUpDownDurationMax.Value = 0
                        NumericUpDownDurationMin.Value = 0
                    End If
                Else
                    ComboBoxEffectName.Text = ""
                    ComboBoxEffectName.Tag = ""
                    NumericUpDownAmplifierMax.Value = 0
                    NumericUpDownAmplifierMin.Value = 0
                    NumericUpDownDurationMax.Value = 0
                    NumericUpDownDurationMin.Value = 0
                End If
            End If
        End If
    End Sub
    Private Sub SaveCurrentEffect(OldSelectedIndex As Int32)
        ' 保存当前的编辑
        If OldSelectedIndex >= 0 Then
            Dim StrResult As String = Chr(34) & ComboBoxEffectName.Tag & Chr(34) & ":" & "{"
            If NumericUpDownAmplifierMin.Value <> 0 And NumericUpDownAmplifierMax.Value <> 0 Then
                StrResult &= Chr(34) & "amplifier" & Chr(34) & ":{"
                If NumericUpDownAmplifierMin.Value <> 0 Then
                    StrResult &= Chr(34) & "min" & Chr(34) & ":" & NumericUpDownAmplifierMin.Value & ","
                End If
                If NumericUpDownAmplifierMax.Value <> 0 Then
                    StrResult &= Chr(34) & "max" & Chr(34) & ":" & NumericUpDownAmplifierMax.Value
                End If
                StrResult &= "},"
            End If
            If NumericUpDownDurationMin.Value <> 0 And NumericUpDownDurationMax.Value <> 0 Then
                StrResult &= Chr(34) & "duration" & Chr(34) & ":{"
                If NumericUpDownDurationMin.Value <> 0 Then
                    StrResult &= Chr(34) & "min" & Chr(34) & ":" & NumericUpDownDurationMin.Value & ","
                End If
                If NumericUpDownDurationMax.Value <> 0 Then
                    StrResult &= Chr(34) & "max" & Chr(34) & ":" & NumericUpDownDurationMax.Value
                End If
                StrResult &= "}"
            End If
            StrResult &= "}"
            StrResult = StrResult.Replace(",}", "}")
            StrResult = StrResult.Replace(",]", "]")
            StrEachEffectJson(OldSelectedIndex) = StrResult
        End If
    End Sub
    Private Sub ComboBoxEffectName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEffectName.SelectedIndexChanged
        ComboBoxEffectName.Tag = ZhToEn(ComboBoxEffectName.Text, ZhEffects, EnEffects)
    End Sub

    Private Sub ButtonLocation_Click(sender As Object, e As EventArgs) Handles ButtonLocation.Click
        FormGlobalLocation.Reading(ButtonLocation)
    End Sub
End Class