Public Class Form3
    Dim apppath As String = Application.StartupPath & "\"
    Dim iconpath As String = ""
    Dim splashpath As String = ""

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog = DialogResult.OK Then
            If ofd.FileName <> String.Empty Then
                Me.PictureBox1.BackgroundImage = Bitmap.FromFile(ofd.FileName)
                iconpath = ofd.FileName
                TextBox1.Text = iconpath
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog = DialogResult.OK Then
            If ofd.FileName <> String.Empty Then
                Me.PictureBox2.BackgroundImage = Bitmap.FromFile(ofd.FileName)
                splashpath = ofd.FileName
                TextBox2.Text = splashpath
            End If
        End If
    End Sub

    Private Sub ExportIcons(size As Integer, filename As String, Optional foldername As String = "")
        'This function can only export square
        Dim bmp As Bitmap = CType(PictureBox1.BackgroundImage, Bitmap)

        ' bmpt is the thumbnail
        Dim bmpt As New Bitmap(size, size)
        Using g As Graphics = Graphics.FromImage(bmpt)

            ' draw the original image to the smaller thumb
            g.DrawImage(bmp, 0, 0,
                        bmpt.Width + 1,
                        bmpt.Height + 1)
        End Using
        If My.Computer.FileSystem.FileExists(apppath & foldername & filename) Then
            My.Computer.FileSystem.DeleteFile(apppath & foldername & filename)
        End If
        bmpt.Save(apppath & foldername & filename, System.Drawing.Imaging.ImageFormat.Png)
    End Sub

    Private Sub ExportSplash(sizex As Integer, sizey As Integer, filename As String, Optional foldername As String = "")
        'This function can only export square
        Dim bmp As Bitmap = CType(PictureBox2.BackgroundImage, Bitmap)

        ' bmpt is the thumbnail
        Dim bmpt As New Bitmap(sizex, sizey)
        Using g As Graphics = Graphics.FromImage(bmpt)

            ' draw the original image to the smaller thumb
            g.DrawImage(bmp, 0, 0,
                        bmpt.Width + 1,
                        bmpt.Height + 1)
        End Using
        If My.Computer.FileSystem.FileExists(apppath & foldername & filename) Then
            My.Computer.FileSystem.DeleteFile(apppath & foldername & filename)
        End If
        bmpt.Save(apppath & foldername & filename, System.Drawing.Imaging.ImageFormat.Png)
    End Sub
    Public Function ScaleImage(ByVal TargetHeight As Integer, ByVal TargetWidth As Integer, filename As String, Optional foldername As String = "") As System.Drawing.Image
        Dim OldImage As Bitmap = CType(PictureBox2.BackgroundImage, Bitmap)
        Dim NewHeight As Integer = TargetHeight
        Dim NewWidth As Integer = NewHeight / OldImage.Height * OldImage.Width

        If NewWidth < TargetWidth Then
            NewWidth = TargetWidth
            NewHeight = NewWidth / OldImage.Width * OldImage.Height
        End If
        Dim leftshift As Integer = Math.Abs(TargetWidth - NewWidth) / 2
        Dim downshift As Integer = Math.Abs(TargetHeight - NewHeight) / 2
        Dim CropRect As New Rectangle(leftshift, downshift, TargetWidth, TargetHeight)
        Dim OriginalImage = New Bitmap(OldImage, NewWidth, NewHeight)
        Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
        Using grp = Graphics.FromImage(CropImage)
            grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            OriginalImage.Dispose()
            If My.Computer.FileSystem.FileExists(apppath & foldername & filename) Then
                My.Computer.FileSystem.DeleteFile(apppath & foldername & filename)
            End If
            CropImage.Save(apppath & foldername & filename, System.Drawing.Imaging.ImageFormat.Png)
        End Using

        Return Nothing
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CreateFolders()
        For Each i As String In ListBox1.Items
            Dim variable As String()
            variable = i.Split(",")
            ExportIcons(variable(1), variable(0), "res\icon\android\")
        Next
        For Each i As String In ListBox2.Items
            Dim variable As String()
            variable = i.Split(",")
            ExportIcons(variable(1), variable(0), "res\icon\ios\")
        Next
    End Sub

    Public Sub CreateFolders()
        If My.Computer.FileSystem.DirectoryExists(apppath & "res\") = False Then
            My.Computer.FileSystem.CreateDirectory(apppath & "res\")
            My.Computer.FileSystem.CreateDirectory(apppath & "res\screen\")
            My.Computer.FileSystem.CreateDirectory(apppath & "res\screen\android\")
            My.Computer.FileSystem.CreateDirectory(apppath & "res\screen\ios\")
            My.Computer.FileSystem.CreateDirectory(apppath & "res\icon\")
            My.Computer.FileSystem.CreateDirectory(apppath & "res\icon\android\")
            My.Computer.FileSystem.CreateDirectory(apppath & "res\icon\ios\")
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CreateFolders()
        For Each i As String In ListBox3.Items
            Dim variable As String()
            variable = i.Split(",")
            'ExportSplash(variable(1), variable(2), variable(0), "res\screen\android\")
            ScaleImage(variable(1), variable(2), variable(0), "res\screen\android\")
        Next
        For Each i As String In ListBox4.Items
            Dim variable As String()
            variable = i.Split(",")
            'ExportSplash(variable(1), variable(2), variable(0), "res\screen\ios\")
            ScaleImage(variable(1), variable(2), variable(0), "res\screen\ios\")

        Next
    End Sub
End Class