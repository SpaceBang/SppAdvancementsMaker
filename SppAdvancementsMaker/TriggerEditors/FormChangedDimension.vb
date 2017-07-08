﻿Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FormChangedDimension
    Public Sub Reading(StrJson As String)
        ' 显示本窗体
        Visible = False
        Show(FormCriteria)
        ' 读取传送过来的 Json 文本
        Dim StrTemp As String
        Dim ObjJson As Object = CType(JsonConvert.DeserializeObject(StrJson), JObject)
        'If ObjJson.ToString <> "{}" Then
        If ObjJson.Item("from") <> Nothing Then
            StrTemp = ObjJson.Item("from").ToString
            ComboBoxFrom.Text = EnToZh(StrTemp, ZhDimension, EnDimension)
        End If
        If ObjJson.Item("to") <> Nothing Then
            StrTemp = ObjJson.Item("to").ToString
            ComboBoxTo.Text = EnToZh(StrTemp, ZhDimension, EnDimension)
        End If
        'End If
    End Sub

    Private Sub Writing(sender As Object, e As EventArgs) Handles ButtonEnter.Click
        Dim ObjJson As Object = CType(JsonConvert.DeserializeObject("{}"), JObject)
        Dim StrResult As String
        If ComboBoxFrom.Text <> "" Then
            ObjJson.Add("from", ZhToEn(ComboBoxFrom.Text, ZhDimension, EnDimension))
        End If
        If ComboBoxTo.Text <> "" Then
            ObjJson.Add("to", ZhToEn(ComboBoxTo.Text, ZhDimension, EnDimension))
        End If
        StrResult = ObjJson.ToString
        ' 将处理后的 Json 文本返回条件窗体
        FormCriteria.ButtonCriteria.Tag = StrResult
        Hide()
    End Sub
End Class