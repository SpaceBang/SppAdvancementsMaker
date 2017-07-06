﻿Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FormCriteria
    Public Sub Reading(StrCriteriaName As String, StrCriteriaJson As String, StrGroupJson As String)
        Dim ObjJson As Object = CType(JsonConvert.DeserializeObject("{" & StrCriteriaJson & "}"), JObject)
        '读取条件名
        TextBoxName.Tag = StrCriteriaName
        TextBoxName.Text = StrCriteriaName
        '读取触发器-种类
        Dim StrTriggerName As String = ObjJson.Item(StrCriteriaName).Item("trigger").ToString()
        Dim i As Int16
        For i = 0 To StrTriggerNames.Count - 1
            If StrTriggerNames(i) = StrTriggerName Then
                ComboBoxTrigger.Text = StrTriggerDescriptions(i)
                Exit For
            End If
        Next
        '读取触发器-条件Json
        ButtonCriteria.Tag = ObjJson.Item(StrCriteriaName).Item("conditions").ToString()
        '读取分组
        Dim j As Int16
        ComboBoxGroup.Items.Clear()
        ObjJson = CType(JsonConvert.DeserializeObject("[" & StrGroupJson & "]"), JArray)
        For i = 0 To ObjJson.Count - 1
            ComboBoxGroup.Items.Add("组" & i)
            For j = 0 To ObjJson.Item(i).Count - 1
                If ObjJson.Item(i).Item(j).ToString = StrCriteriaName Then
                    ComboBoxGroup.Text = "组" & i
                    ComboBoxGroup.Tag = "组" & i
                End If
            Next
        Next
    End Sub

    Private Sub Writing(sender As Object, e As EventArgs) Handles ButtonEnter.Click
        Dim StrResult As String
        Dim StrTemp As String = ""
        Dim i As Int16
        StrResult = Chr(34) & TextBoxName.Text & Chr(34) & ":{"
        For i = 0 To StrTriggerDescriptions.Count - 1
            If StrTriggerDescriptions(i) = ComboBoxTrigger.Text Then
                StrTemp = StrTriggerNames(i)
                Exit For
            End If
        Next
        StrResult &= Chr(34) & "trigger" & Chr(34) & ":" & Chr(34) & StrTemp & Chr(34) & ","
        StrResult &= Chr(34) & "conditions" & Chr(34) & ":" & ButtonCriteria.Tag
        StrResult &= "}"
        ' 找到正在编辑的条件所在 Node
        Dim j As Int16
        Dim k As Int16
        For i = 0 To FormMain.TreeViewCriterias.GetNodeCount(False) - 1
            For j = 0 To FormMain.TreeViewCriterias.Nodes.Item(i).GetNodeCount(False) - 1
                With FormMain.TreeViewCriterias.Nodes.Item(i).Nodes.Item(j)
                    If .Text = TextBoxName.Tag Then
                        ' 找到啦
                        If ComboBoxGroup.Text = ComboBoxGroup.Tag Then
                            ' 没更换分组
                            ' 直接更改 Tag(存储Json) 属性和 Text 属性
                            .Text = TextBoxName.Text
                            .Tag = StrResult
                            Exit For
                        Else
                            ' 更换了分组
                            ' 先删掉旧的这个
                            If .Text = TextBoxName.Tag Then
                                .Remove()
                            End If
                            ' 然后在更换后的组建一个新的
                            For k = 0 To FormMain.TreeViewCriterias.Nodes.Count - 1
                                If FormMain.TreeViewCriterias.Nodes.Item(k).Text = ComboBoxGroup.Text Then
                                    Dim Node As TreeNode = FormMain.TreeViewCriterias.Nodes.Item(k).Nodes.Add(TextBoxName.Text)
                                    Node.Name = "条"
                                    Node.Tag = StrResult
                                End If
                            Next k
                        End If
                    End If
                End With
            Next j
        Next i
        FormMain.SaveGroupJson()
        Hide()
    End Sub

    Private Sub ButtonCriteria_Click(sender As Object, e As EventArgs) Handles ButtonCriteria.Click
        Dim i As Int16
        Dim StrTemp As String = "minecraft:impossible"
        For i = 0 To StrTriggerDescriptions.Count - 1
            ' 找到当前触发器种类的英文
            If StrTriggerDescriptions(i) = ComboBoxTrigger.Text Then
                StrTemp = StrTriggerNames(i)
                Exit For
            End If
        Next
        ' 找到此触发器对应的窗体
        ' VB.NET 似乎没有类似 VB6 的 Forms 集合，如果有大佬知道如何实现可以告诉本渣
        ' How to use forms(like vb6) in vb.net? Sorry for my poor English :D
        Dim FormTemp As Form = FormImpossible
        Select Case StrTemp
            Case "minecraft:bred_animals"

            Case "minecraft:brewed_potion"
            Case "minecraft:changed_dimension"
            Case "minecraft:construct_beacon"
            Case "minecraft:consume_item"
            Case "minecraft:cured_zombie_villager"
            Case "minecraft:effects_changed"
            Case "minecraft:enchanted_item"
            Case "minecraft:enter_block"
            Case "minecraft:entity_hurt_player"
            Case "minecraft:entity_killed_player"
            Case "minecraft:impossible"
                FormTemp = FormImpossible
            Case "minecraft:inventory_changed"
            Case "minecraft:item_durability_changed"
            Case "minecraft:levitation"
            Case "minecraft:location"
            Case "minecraft:nether_travel"
            Case "minecraft:placed_block"
            Case "minecraft:player_hurt_entity"
            Case "minecraft:player_killed_entity"
            Case "minecraft:recipe_unlocked"
            Case "minecraft:slept_in_bed"
            Case "minecraft:summoned_entity"
            Case "minecraft:tame_animal"
            Case "minecraft:tick"
            Case "minecraft:used_ender_eye"
            Case "minecraft:used_totem"
            Case "minecraft:villager_trade"
            Case Else
                FormTemp = FormImpossible
        End Select
        FormTemp.Visible = False
        FormTemp.Show(Me)
        FormTemp.Tag = ButtonCriteria.Tag
    End Sub
End Class