Imports System.IO
Imports MySql.Data.MySqlClient
Public Class EmployeeArchiveForm
    Private Sub EmployeeArchiveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim QueryString = "SELECT * FROM employee_sys.employee_archive;"
            Dim Search As New MySqlDataAdapter(QueryString, myconn)
            Dim ds As DataSet = New DataSet
            Search.Fill(ds, "employee_archive")
            DataGridView1.DataSource = ds.Tables("employee_archive")
            myconn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            myconn.Close()
        End Try
    End Sub

    Private Sub MenuBtn12_Click(sender As Object, e As EventArgs) Handles MenuBtn12.Click
        MenuForm.Show()
    End Sub

    Private Sub LocateDataBtn1_Click(sender As Object, e As EventArgs) Handles LocateDataBtn1.Click
        Dim openFileDialog2 As New OpenFileDialog()

        If openFileDialog2.ShowDialog() = DialogResult.OK Then
            Dim filePath1 As String = openFileDialog2.FileName

            Dim fileName1 As String = Path.GetFileName(filePath1)
            Dim destinationPath As String = "C:\ProgramData\MySQL\MySQL Server 8.0\Uploads\" & fileName1
            File.Move(filePath1, destinationPath)

            MessageBox.Show("File moved successfully!")
        End If
    End Sub

    Private Sub PrintDataBtn1_Click(sender As Object, e As EventArgs) Handles PrintDataBtn1.Click
        'MsgBox(currentDate.ToString)
        Call importToExcel(Me.DataGridView1, "samplereport.xlsx")
    End Sub
End Class