﻿Imports System.Data.SqlClient

Public Class FormGaji

    Private Sub FormGaji_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Button2.Focus()
            Call Koneksi()
            CMD = New SqlCommand("select * from tblguru where nip='" & TextBox1.Text & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                TextBox2.Text = DR.Item("nama")
                TextBox3.Text = DR.Item("gapok")
                TextBox4.Text = DR.Item("tunjangan")
                TextBox5.Text = DR.Item("potongan")
                TextBox6.Text = DR.Item("gaber")
            Else
                MsgBox("Data Tidak Di Temukan Coba Periksa Kembali")
                FormUser.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FormUser.Show()
        Me.Hide()
    End Sub
End Class