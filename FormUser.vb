Imports System.Data.SqlClient

Public Class FormUser
    Sub Kosongkan()
        TextBox1.Clear()
        ComboBox1.Text = ""
        TextBox1.Focus()
    End Sub
    Sub Tampilgrid()
        Call Koneksi()
        DA = New SqlDataAdapter("select * from tblguru", CONN)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Private Sub FormUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'KaryawanDataSet.tblguru' table. You can move, or remove it, as needed.
        Me.TblguruTableAdapter.Fill(Me.KaryawanDataSet.tblguru)
        Call Tampilgrid()
    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        Call Koneksi()
        CMD = New SqlCommand("select * from tblguru where nama like '%" & TextBox12.Text & "%'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Call Koneksi()
            DA = New SqlDataAdapter("select * from tblguru where nama like '%" & TextBox12.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
        Else
            MsgBox("Data Tidak Ditemukan Coba Periksa Lagi Nama Yang Anda Masukan")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.Text = "ABSEN" Then
            FormAbsen.TextBox1.Text = (Me.TextBox1.Text)
            FormAbsen.Show()
        ElseIf ComboBox1.Text = "GAJI" Then
            FormGaji.TextBox1.Text = (Me.TextBox1.Text)
            FormGaji.Show()
        ElseIf ComboBox1.Text = "DATA GURU" Then
            FormData.TextBox1.Text = (Me.TextBox1.Text)
            FormData.Show()
        Else
            MsgBox("Data Belum Di Isi Silahkan Isi Terlebih Dahulu")
            TextBox1.Focus()
            Call Kosongkan()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        On Error Resume Next
        TextBox1.Text = DGV.Rows(e.RowIndex).Cells(0).Value
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form3.Show()
    End Sub
End Class