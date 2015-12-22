Imports System.Data.SqlClient

Public Class FormDataGaji

    Sub Tampilgrid()
        Call Koneksi()
        DA = New SqlDataAdapter("select * from Gaji", CONN)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Private Sub FormDataGaji_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'KaryawanDataSet.Gaji' table. You can move, or remove it, as needed.
        Me.GajiTableAdapter.Fill(Me.KaryawanDataSet.Gaji)
        Call Koneksi()
        CMD = New SqlCommand("select * from Gaji", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        TextBox4.Text = DR.Item("kode")
        TextBox1.Text = DR.Item("GA")
        TextBox2.Text = DR.Item("GB")
        TextBox3.Text = DR.Item("GC")
        TextBox1.Focus()
        Call Tampilgrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Koneksi()
        CMD = New SqlCommand("select * from Gaji where kode='" & TextBox4.Text & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            Call Koneksi()
            Dim simpan As String = "insert Gaji values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
            CMD = New SqlCommand(simpan, CONN)
            CMD.ExecuteNonQuery()
        Else
            Call Koneksi()
            Dim edit As String = "update Gaji set GA='" & TextBox1.Text & "',GB='" & TextBox2.Text & "',GC='" & TextBox3.Text & "'where kode='" & textbox4.text & "'"
            CMD = New SqlCommand(edit, CONN)
            CMD.ExecuteNonQuery()
        End If
        Call Tampilgrid()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class