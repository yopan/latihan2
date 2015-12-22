Imports System.Data.SqlClient
Public Class Form1
  
    Private Sub ADMINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADMINToolStripMenuItem.Click
        FormLogin.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormUser.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
    End Sub

    Private Sub USERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERToolStripMenuItem.Click
        FormUser.Show()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        End
    End Sub

    Private Sub LAPORANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAPORANToolStripMenuItem.Click
        Form3.Show()
    End Sub
End Class
