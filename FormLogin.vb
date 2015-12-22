Imports System.Data.SqlClient

Public Class FormLogin

    Sub Kosongkan()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub FormLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Koneksi()
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Data Belum Di Isi")
            Call Kosongkan()
            Exit Sub
        Else
            Call Koneksi()
            CMD = New SqlCommand("select * from Login", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If TextBox1.Text = DR.Item("id_admin") And TextBox2.Text = DR.Item("pasword") Then
                Call Kosongkan()
                FormInput.Show()
                Me.Hide()
            Else
                MsgBox("ID atau Pasword Anda Salah")
                TextBox2.Clear()
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Kosongkan()
        Form1.Show()
        Me.Hide()
    End Sub
End Class