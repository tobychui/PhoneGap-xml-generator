Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = Form1.Height
    End Sub

    Public Sub CreateView(content As String)
        Me.Left = Form1.Right
        Me.Top = Form1.Top
        Me.Show()
        ListBox1.Items.Clear()
        Dim symbol As Integer = 0
        Dim newcontent As String = ""
        Do While content.Contains("%")
            newcontent = content.Substring(0, content.LastIndexOf("%"))
            symbol += 1
            If symbol Mod 2 = 0 Then
                ListBox1.Items.Add(content.Replace(newcontent, "").Replace("%", ""))
            End If
            content = newcontent
        Loop
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Left = Form1.Right
        Me.Top = Form1.Top
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.TextBox2.Text = Form1.TextBox2.Text.Replace("%" & ListBox1.SelectedItem & "%", TextBox1.Text)
    End Sub
End Class