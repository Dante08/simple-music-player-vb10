Public Class Form1
    Dim currentTrack As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath.ToString
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (Not ListBox1.SelectedItem = Nothing) Then
            AxWindowsMediaPlayer1.URL = TextBox1.Text & "\" & ListBox1.SelectedItem
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        AxWindowsMediaPlayer1.Ctlcontrols.pause()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If currentTrack = 0 Then
            AxWindowsMediaPlayer1.URL = ListBox1.Items(ListBox1.Items.Count - 1)
            currentTrack = ListBox1.Items.Count - 1
        Else
            AxWindowsMediaPlayer1.URL = ListBox1.Items(currentTrack - 1)
            currentTrack -= 1
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If currentTrack = (ListBox1.Items.Count = 1) Then
            AxWindowsMediaPlayer1.URL = ListBox1.Items(0)
        Else
            AxWindowsMediaPlayer1.URL = ListBox1.Items(currentTrack + 1)
            currentTrack += 1
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        ListBox1.Items.Clear()
        If Not TextBox1.Text = "" Then
            For Each File As String In My.Computer.FileSystem.GetFiles(TextBox1.Text, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*mp3")
                ListBox1.Items.Add(File)
            Next
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem.ToString
        currentTrack = ListBox1.SelectedIndex

    End Sub

    Private Sub Button5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button5.KeyDown
        If e.KeyCode = Keys.F1 Then
            If currentTrack = 0 Then
                AxWindowsMediaPlayer1.URL = ListBox1.Items(ListBox1.Items.Count - 1)
                currentTrack = ListBox1.Items.Count - 1
            Else
                AxWindowsMediaPlayer1.URL = ListBox1.Items(currentTrack - 1)
                currentTrack -= 1
            End If
        End If
    End Sub

    Private Sub Button6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button6.KeyDown
        If e.KeyCode = Keys.F2 Then
            If currentTrack = (ListBox1.Items.Count = 1) Then
                AxWindowsMediaPlayer1.URL = ListBox1.Items(0)
            Else
                AxWindowsMediaPlayer1.URL = ListBox1.Items(currentTrack + 1)
                currentTrack += 1
            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox2.Text = AxWindowsMediaPlayer1.currentMedia.getItemInfo("Artist") & " - " & AxWindowsMediaPlayer1.currentMedia.getItemInfo("Title")
    End Sub
End Class
