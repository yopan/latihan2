<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.TblguruBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.KaryawanDataSet = New WindowsApplication1.KaryawanDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tblguruTableAdapter = New WindowsApplication1.KaryawanDataSetTableAdapters.tblguruTableAdapter()
        Me.tblguruBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.TblguruBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KaryawanDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblguruBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TblguruBindingSource1
        '
        Me.TblguruBindingSource1.DataMember = "tblguru"
        Me.TblguruBindingSource1.DataSource = Me.KaryawanDataSet
        '
        'KaryawanDataSet
        '
        Me.KaryawanDataSet.DataSetName = "KaryawanDataSet"
        Me.KaryawanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.tblguruBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "WindowsApplication1.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(463, 232)
        Me.ReportViewer1.TabIndex = 0
        '
        'tblguruTableAdapter
        '
        Me.tblguruTableAdapter.ClearBeforeFill = True
        '
        'tblguruBindingSource
        '
        Me.tblguruBindingSource.DataMember = "tblguru"
        Me.tblguruBindingSource.DataSource = Me.KaryawanDataSet
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 232)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Form3"
        Me.Text = "Form3"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TblguruBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KaryawanDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblguruBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents KaryawanDataSet As WindowsApplication1.KaryawanDataSet
    Friend WithEvents tblguruTableAdapter As WindowsApplication1.KaryawanDataSetTableAdapters.tblguruTableAdapter
    Friend WithEvents TblguruBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents tblguruBindingSource As System.Windows.Forms.BindingSource
End Class
