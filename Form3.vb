Imports System.Data.SqlClient

Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'KaryawanDataSet.tblguru' table. You can move, or remove it, as needed.
        Me.tblguruTableAdapter.Fill(Me.KaryawanDataSet.tblguru)

        Me.ReportViewer1.RefreshReport()
        Call Koneksi()
    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load
        Call Koneksi()
    End Sub
End Class