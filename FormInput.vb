Imports System.Data.SqlClient

Public Class FormInput
    Sub Kosongkan()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox1.Focus()
    End Sub

    Sub DataBaru()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox2.Focus()
    End Sub

    Sub Tampilgrid()
        Call Koneksi()
        DA = New SqlDataAdapter("select * from tblguru", CONN)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Private Sub FormInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'KaryawanDataSet.tblguru' table. You can move, or remove it, as needed.
        Me.TblguruTableAdapter.Fill(Me.KaryawanDataSet.tblguru)
        Call Koneksi()
        Call Tampilgrid()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        TextBox1.MaxLength = 20
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            CMD = New SqlCommand("select * from tblguru where nip='" & TextBox1.Text & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                TextBox2.Text = DR.Item("nama")
                TextBox3.Text = DR.Item("alamat")
                ComboBox1.Text = DR.Item("status")
                ComboBox2.Text = DR.Item("sk")
                ComboBox3.Text = DR.Item("golongan")
                TextBox4.Text = DR.Item("sakit")
                TextBox5.Text = DR.Item("izin")
                TextBox6.Text = DR.Item("alfa")
                TextBox7.Text = DR.Item("masuk")
                TextBox8.Text = DR.Item("gapok")
                TextBox9.Text = DR.Item("potongan")
                TextBox10.Text = DR.Item("tunjangan")
                TextBox11.Text = DR.Item("gaber")
            Else
                Call DataBaru()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Then
            MsgBox("Data Belum Lengkap Silahkan Isi Dulu")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New SqlCommand("select * from tblguru where nip='" & TextBox1.Text & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                Call Koneksi()
                Dim simpan As String = "insert tblguru values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "')"
                CMD = New SqlCommand(simpan, CONN)
                CMD.ExecuteNonQuery()
            Else
                Call Koneksi()
                Dim edit As String = "update tblguru set nama='" & TextBox2.Text & "',alamat='" & TextBox3.Text & "',status='" & ComboBox1.Text & "',sk='" & ComboBox2.Text & "',golongan='" & ComboBox3.Text & "',sakit='" & TextBox4.Text & "',izin='" & TextBox5.Text & "',alfa='" & TextBox6.Text & "',masuk='" & TextBox7.Text & "',gapok='" & TextBox8.Text & "',potongan='" & TextBox9.Text & "',tunjangan='" & TextBox10.Text & "',gaber='" & TextBox11.Text & "'where nip ='" & TextBox1.Text & "'"
                CMD = New SqlCommand(edit, CONN)
                CMD.ExecuteNonQuery()
            End If
            Call Kosongkan()
            Call Tampilgrid()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Data Harus Di Isi Dulu")
            TextBox1.Focus()
            Exit Sub
        Else
            If MessageBox.Show("Apakah Anda Ingin Menghapus Data Ini", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete from tblguru where nip='" & TextBox1.Text & "'"
                CMD = New SqlCommand(hapus, CONN)
                CMD.ExecuteNonQuery()
                Call Kosongkan()
                Call Tampilgrid()
            Else
                Call Kosongkan()
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call Kosongkan()
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

    Private Sub TextBox9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.LostFocus
        If TextBox8.Text = "" Then
            TextBox8.Focus()
            Exit Sub
        Else
            If ComboBox1.Text = "K" Then
                TextBox9.Text = 0.02 * Int(TextBox8.Text)
            Else
                TextBox9.Text = 0
            End If
        End If
    End Sub

    Private Sub TextBox10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.LostFocus
        If TextBox8.Text = "" Then
            MsgBox("Maaf Data Gaji Belum Di Isi Silahkan Isi Terlebih Dahulu")
            TextBox8.Focus()
            Exit Sub
        Else
            TextBox10.Text = (0.01 * Int(TextBox5.Text) + 0.03 * Int(TextBox6.Text)) * Int(TextBox8.Text)
        End If
    End Sub

    Private Sub TextBox11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox11.LostFocus
        TextBox11.Text = (Int(TextBox8.Text) + Int(TextBox9.Text)) - Int(TextBox10.Text)
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            ComboBox3.Focus()
        End If
    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox5.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox7.Focus()
        End If
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox8.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox9.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox10.Focus()
        End If
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox11.Focus()
        End If
    End Sub

    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.Focus()
        End If
    End Sub

    Private Sub DGV_CellMouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        On Error Resume Next
        TextBox1.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DGV.Rows(e.RowIndex).Cells(2).Value
        ComboBox1.Text = DGV.Rows(e.RowIndex).Cells(3).Value
        ComboBox2.Text = DGV.Rows(e.RowIndex).Cells(4).Value
        ComboBox3.Text = DGV.Rows(e.RowIndex).Cells(5).Value
        TextBox4.Text = DGV.Rows(e.RowIndex).Cells(6).Value
        TextBox5.Text = DGV.Rows(e.RowIndex).Cells(7).Value
        TextBox6.Text = DGV.Rows(e.RowIndex).Cells(8).Value
        TextBox7.Text = DGV.Rows(e.RowIndex).Cells(9).Value
        TextBox8.Text = DGV.Rows(e.RowIndex).Cells(10).Value
        TextBox9.Text = DGV.Rows(e.RowIndex).Cells(11).Value
        TextBox10.Text = DGV.Rows(e.RowIndex).Cells(12).Value
        TextBox11.Text = DGV.Rows(e.RowIndex).Cells(13).Value
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click, Button4.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.LostFocus
        Call Koneksi()
        CMD = New SqlCommand("select * from Gaji", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            If ComboBox3.Text = "A" Then
                TextBox8.Text = DR.Item("GA")
            ElseIf ComboBox3.Text = "B" Then
                TextBox8.Text = DR.Item("GB")
            ElseIf ComboBox3.Text = "C" Then
                TextBox8.Text = DR.Item("GC")
            Else
                TextBox9.Focus()
            End If
        End If
    End Sub

    Private Sub ComboBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.LostFocus
        If ComboBox2.Text = "HONORER" Then
            ComboBox3.Text = "-"
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        If TextBox4.Text < 0 Or TextBox5.Text < 0 Or TextBox6.Text < 0 And TextBox4.Text > 30 Or TextBox5.Text > 30 Or TextBox6.Text > 30 Then
            MsgBox("Maaf Data Data Yang Anda Input Tidak Sesuai Silahkan Periksa Kembali")
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox4.Focus()
            Exit Sub
        Else
            TextBox7.Text = 30 - (Int(TextBox4.Text) + Int(TextBox5.Text) + Int(TextBox6.Text))
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        FormDataGaji.Show()
    End Sub
End Class