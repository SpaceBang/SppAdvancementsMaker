﻿Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FormNetherTravel
    Public Sub Reading(StrJson As String)
        On Error Resume Next
        ' 显示本窗体
        Visible = False
        Show(FormCriteria)
        ' 读取传送过来的 Json 文本
        Dim ObjJson As JObject = CType(JsonConvert.DeserializeObject(StrJson), JObject)
        If ObjJson.ToString <> "{}" Then
            If ObjJson.Item("disatance") IsNot Nothing Then
                If ObjJson.Item("disatance").Item("absolute") IsNot Nothing Then
                    If ObjJson.Item("disatance").Item("absolute").Item("max") IsNot Nothing Then
                        NumericUpDownAbsoluteMax.Value = ObjJson.Item("disatance").Item("absolute").Item("max").ToString
                    Else
                        NumericUpDownAbsoluteMax.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("absolute").Item("min") IsNot Nothing Then
                        NumericUpDownAbsoluteMin.Value = ObjJson.Item("disatance").Item("absolute").Item("min").ToString
                    Else
                        NumericUpDownAbsoluteMin.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("absolute").Item("max") Is Nothing And ObjJson.Item("disatance").Item("absolute").Item("min") Is Nothing Then
                        If ObjJson.Item("disatance").Item("absolute").ToString <> "{}" Then
                            NumericUpDownAbsoluteMax.Value = ObjJson.Item("disatance").Item("absolute").ToString
                            NumericUpDownAbsoluteMin.Value = ObjJson.Item("disatance").Item("absolute").ToString
                        End If
                    End If
                End If
                If ObjJson.Item("disatance").Item("horizontal") IsNot Nothing Then
                    If ObjJson.Item("disatance").Item("horizontal").Item("max") IsNot Nothing Then
                        NumericUpDownHorizontalMax.Value = ObjJson.Item("disatance").Item("horizontal").Item("max").ToString
                    Else
                        NumericUpDownHorizontalMax.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("horizontal").Item("min") IsNot Nothing Then
                        NumericUpDownHorizontalMin.Value = ObjJson.Item("disatance").Item("horizontal").Item("min").ToString
                    Else
                        NumericUpDownHorizontalMin.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("horizontal").Item("max") Is Nothing And ObjJson.Item("disatance").Item("horizontal").Item("min") Is Nothing Then
                        If ObjJson.Item("disatance").Item("horizontal").ToString <> "{}" Then
                            NumericUpDownHorizontalMax.Value = ObjJson.Item("disatance").Item("horizontal").ToString
                            NumericUpDownHorizontalMin.Value = ObjJson.Item("disatance").Item("horizontal").ToString
                        End If
                    End If
                End If
                If ObjJson.Item("disatance").Item("x") IsNot Nothing Then
                    If ObjJson.Item("disatance").Item("x").Item("max") IsNot Nothing Then
                        NumericUpDownXMax.Value = ObjJson.Item("disatance").Item("x").Item("max").ToString
                    Else
                        NumericUpDownXMax.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("x").Item("min") IsNot Nothing Then
                        NumericUpDownXMin.Value = ObjJson.Item("disatance").Item("x").Item("min").ToString
                    Else
                        NumericUpDownXMin.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("x").Item("max") Is Nothing And ObjJson.Item("disatance").Item("x").Item("min") Is Nothing Then
                        If ObjJson.Item("disatance").Item("x").ToString <> "{}" Then
                            NumericUpDownXMax.Value = ObjJson.Item("disatance").Item("x").ToString
                            NumericUpDownXMin.Value = ObjJson.Item("disatance").Item("x").ToString
                        End If
                    End If
                End If
                If ObjJson.Item("disatance").Item("y") IsNot Nothing Then
                    If ObjJson.Item("disatance").Item("y").Item("max") IsNot Nothing Then
                        NumericUpDownYMax.Value = ObjJson.Item("disatance").Item("y").Item("max").ToString
                    Else
                        NumericUpDownYMax.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("y").Item("min") IsNot Nothing Then
                        NumericUpDownYMin.Value = ObjJson.Item("disatance").Item("y").Item("min").ToString
                    Else
                        NumericUpDownYMin.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("y").Item("max") Is Nothing And ObjJson.Item("disatance").Item("y").Item("min") Is Nothing Then
                        If ObjJson.Item("disatance").Item("y").ToString <> "{}" Then
                            NumericUpDownYMax.Value = ObjJson.Item("disatance").Item("y").ToString
                            NumericUpDownYMin.Value = ObjJson.Item("disatance").Item("y").ToString
                        End If
                    End If
                End If
                If ObjJson.Item("disatance").Item("z") IsNot Nothing Then
                    If ObjJson.Item("disatance").Item("z").Item("max") IsNot Nothing Then
                        NumericUpDownZMax.Value = ObjJson.Item("disatance").Item("z").Item("max").ToString
                    Else
                        NumericUpDownZMax.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("z").Item("min") IsNot Nothing Then
                        NumericUpDownZMin.Value = ObjJson.Item("disatance").Item("z").Item("min").ToString
                    Else
                        NumericUpDownZMin.Value = 0
                    End If
                    If ObjJson.Item("disatance").Item("z").Item("max") Is Nothing And ObjJson.Item("disatance").Item("z").Item("min") Is Nothing Then
                        If ObjJson.Item("disatance").Item("z").ToString <> "{}" Then
                            NumericUpDownZMax.Value = ObjJson.Item("disatance").Item("z").ToString
                            NumericUpDownZMin.Value = ObjJson.Item("disatance").Item("z").ToString
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Writing(sender As Object, e As EventArgs) Handles ButtonEnter.Click
        Dim StrResult As String
        StrResult = "{"
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
        StrResult &= "}"
        StrResult = StrResult.Replace(",}", "}")
        StrResult = StrResult.Replace(",]", "]")
        ' 将处理后的 Json 文本返回条件窗体
        FormCriteria.ButtonCriteria.Tag = StrResult
        Hide()
        FormCriteria.Hide()
        FormCriteria.Show(FormMain)
    End Sub
End Class