Imports System.IO

Public Class Form1
    Dim apppath As String = Application.StartupPath & "\"
    Dim filecontent As String = ""
    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        Select Case CheckedListBox1.SelectedIndex
            Case 0
                If My.Settings.initialize = "" Then
                    TextBox2.Text = My.Resources.initialize
                Else
                    TextBox2.Text = My.Settings.initialize
                End If
            Case 1
                If My.Settings.name = "" Then
                    TextBox2.Text = My.Resources.name.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.name
                End If

            Case 2
                If My.Settings.description = "" Then
                    TextBox2.Text = My.Resources.description.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.description
                End If

            Case 3
                If My.Settings.author = "" Then
                    TextBox2.Text = My.Resources.author.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.author
                End If

            Case 4
                If My.Settings.content = "" Then
                    TextBox2.Text = My.Resources.content.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.content
                End If

            Case 5
                If My.Settings.preference = "" Then
                    TextBox2.Text = My.Resources.preference.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.preference
                End If

            Case 6
                If My.Settings.platform_android = "" Then
                    TextBox2.Text = My.Resources.platform_android.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.platform_android
                End If

            Case 7
                If My.Settings.platform_ios = "" Then
                    TextBox2.Text = My.Resources.platform_ios.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.platform_ios
                End If
            Case 8
                If My.Settings.platform_wp8 = "" Then
                    TextBox2.Text = My.Resources.platform_wp8.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.platform_wp8
                End If
            Case 9
                If My.Settings.platform_windows = "" Then
                    TextBox2.Text = My.Resources.platform_windows.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.platform_windows
                End If
            Case 10
                If My.Settings.allow_intent = "" Then
                    TextBox2.Text = My.Resources.allow_intent.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.allow_intent
                End If
            Case 11
                If My.Settings.platform_spec = "" Then
                    TextBox2.Text = My.Resources.platform_spec.Replace(vbCr, "").Replace(vbLf, "")
                Else
                    TextBox2.Text = My.Settings.platform_spec
                End If


        End Select
        Form2.CreateView(TextBox2.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim directory As String = Path.GetDirectoryName(TextBox1.Text)
        Dim file As System.IO.StreamWriter
        Dim filename As String = "config"
        If My.Computer.FileSystem.FileExists(apppath & filename & ".xml") Then
            If My.Computer.FileSystem.FileExists(apppath & filename & "_new.xml") Then
                My.Computer.FileSystem.DeleteFile(apppath & filename & "_new.xml")
            End If
            file = My.Computer.FileSystem.OpenTextFileWriter(apppath & filename & "_new.xml", True)
            Else
                file = My.Computer.FileSystem.OpenTextFileWriter(apppath & filename & ".xml", True)
        End If


        Dim i As Integer = 0
        For Each i In CheckedListBox1.CheckedIndices
            If GetContent(i).contains("%") Then
                MsgBox(CheckedListBox1.Items(i) & "contains unfilled variable.")
                Return
            End If
            i += 1
        Next

        i = 0
        While i < CheckedListBox1.CheckedItems.Count
            If CheckedListBox1.GetItemCheckState(i) Then
                file.WriteLine(GetContent(i))
            End If
            i += 1
        End While

        file.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Function GetContent(id As Integer)
        Select Case id
            Case 0
                If My.Settings.initialize <> "" Then
                    Return My.Settings.initialize
                Else
                    Return My.Resources.initialize
                End If

            Case 1
                If My.Settings.name <> "" Then
                    Return My.Settings.name
                Else
                    Return My.Resources.name
                End If
            Case 2
                If My.Settings.description <> "" Then
                    Return My.Settings.description
                Else
                    Return My.Resources.description
                End If
            Case 3
                If My.Settings.author <> "" Then
                    Return My.Settings.author
                Else
                    Return My.Resources.author
                End If
            Case 4
                If My.Settings.preference <> "" Then
                    Return My.Settings.preference
                Else
                    Return My.Resources.preference
                End If
            Case 5
                If My.Settings.plugins <> "" Then
                    Return My.Settings.plugins
                Else
                    Return My.Resources.plugins
                End If
            Case 6
                If My.Settings.platform_android <> "" Then
                    Return My.Settings.platform_android
                Else
                    Return My.Resources.platform_android
                End If
            Case 7
                If My.Settings.platform_ios <> "" Then
                    Return My.Settings.platform_ios
                Else
                    Return My.Resources.platform_ios
                End If
            Case 8
                If My.Settings.platform_wp8 <> "" Then
                    Return My.Settings.platform_wp8
                Else
                    Return My.Resources.platform_wp8
                End If
            Case 9
                If My.Settings.platform_windows <> "" Then
                    Return My.Settings.platform_windows
                Else
                    Return My.Resources.platform_windows
                End If
            Case 10
                If My.Settings.allow_intent <> "" Then
                    Return My.Settings.allow_intent
                Else
                    Return My.Resources.allow_intent
                End If
            Case 11
                If My.Settings.platform_spec <> "" Then
                    Return My.Settings.platform_spec
                Else
                    Return My.Resources.platform_spec
                End If
        End Select
        Return Nothing
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Select Case CheckedListBox1.SelectedIndex
            Case 0
                My.Settings.initialize = TextBox2.Text
            Case 1
                My.Settings.name = TextBox2.Text
            Case 2
                My.Settings.description = TextBox2.Text
            Case 3
                My.Settings.author = TextBox2.Text
            Case 4
                My.Settings.content = TextBox2.Text
            Case 5
                My.Settings.preference = TextBox2.Text
            Case 6
                My.Settings.platform_android = TextBox2.Text
            Case 7
                My.Settings.platform_ios = TextBox2.Text
            Case 8
                My.Settings.platform_wp8 = TextBox2.Text
            Case 9
                My.Settings.platform_windows = TextBox2.Text
            Case 10
                My.Settings.allow_intent = TextBox2.Text
            Case 11
                My.Settings.platform_spec = TextBox2.Text

        End Select
        My.Settings.Save()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.Reset()
        MsgBox("All the data you entered has been reset.")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form3.Show()
    End Sub
End Class
