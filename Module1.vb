Imports System.Data.SqlClient

Module Module1
    Public CONN As SqlConnection
    Public DA As SqlDataAdapter
    Public DS As DataSet
    Public CMD As SqlCommand
    Public DR As SqlDataReader
    Public STR As String

    Sub Koneksi()
        STR = "Data Source=.\SQLEXPRESS;AttachDbFilename=J:\5.Login\From Login\FormLogin\Karyawan.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        CONN = New SqlConnection(STR)
        If CONN.State = ConnectionState.Closed Then
            CONN.Open()
        End If
    End Sub
End Module
