'*************************************************************************
' Abstract:
' This form allows you to manage events (view/add/delete) in
' the golfathon database based on the event year.
'
' Author: Derrick Warren
'*************************************************************************

Option Strict On

Public Class frmManageEvents

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            ' load years combo box
            Load_Years()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Load_Years()

        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Try

            ' open the DB this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' warn user if program is having system problems working
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' build the select statement
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add the item to the combo box. we need the event year ID associated with the event so 
            ' when we click on the event year we can then use the ID to pull the rest of the event years data.
            ' we are binding the column name to the combo box display and value members. 
            cboYears.ValueMember = "intEventYearID"
            cboYears.DisplayMember = "intEventYear"
            cboYears.DataSource = dt

            ' select the first item in the list by default
            If cboYears.Items.Count > 0 Then cboYears.SelectedIndex = 0

            ' clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub cboYears_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYears.SelectedIndexChanged

        ' this Sub is called anytime the selected item is changed in the combo box.
        Dim strSelect As String = ""
        Dim intEventYear As Integer
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        Try

            ' open the database this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' warn user if program is having system problems working
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' build the select statement using PK from name selected
            strSelect = "SELECT intEventYearID FROM TEventYears Where intEventYearID = " & cboYears.SelectedValue.ToString

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load the data table from the reader
            dt.Load(drSourceTable)

            ' populate the text boxes with the data
            intEventYear = CInt(dt.Rows(0).Item(0)) 'put event year ID into variable
            cboYears.SelectedValue = intEventYear 'set selected value of year combo box to correct size

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Function Validation() As Boolean

        ' validate data in combo box years
        If (cboYears.Text) = "" Then
            cboYears.BackColor = Color.Yellow
            cboYears.Focus()
            MessageBox.Show("Please select a year.")
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click

        ' create a new instance of the add event form
        Dim AddEvent As New frmAddEvent

        ' show the new form so any past data is not still on the form
        AddEvent.ShowDialog()

        ' call the form load so the combo box refreshes with current date
        Form1_Load(sender, e)

    End Sub

    Private Sub btnDeleteEvent_Click(sender As Object, e As EventArgs) Handles btnDeleteEvent.Click

        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strEventYear As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult  ' this is the result of which button the user selects

        Try
            ' open the database this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' warn user if program is having system problems working
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' message box used to ask user to confirm deletion of data
            result = MessageBox.Show("Are you sure you want to Delete Event Year-" & cboYears.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' build the delete statement using PK from name selected
                    ' must delete any child records first
                    strDelete = "Delete FROM TGolferEventYearSponsors Where intEventYearID = " & cboYears.SelectedValue.ToString

                    ' delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    strDelete = "Delete FROM TGolferEventYears Where intEventYearID = " & cboYears.SelectedValue.ToString

                    ' delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' now we can delete the parent record
                    strDelete = "Delete FROM TEventYears Where intEventYearID = " & cboYears.SelectedValue.ToString

                    ' delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' if statement makes sure data was affected
                    If intRowsAffected > 0 Then

                        ' Yes, success
                        MessageBox.Show("Delete successful")

                    End If

            End Select


            ' close the database connection
            CloseDatabaseConnection()

            ' call the Form Load sub to refresh the combo box data after a delete
            Form1_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' exits form
        Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ' clears form of data
        cboYears.ResetText()

        cboYears.BackColor = Color.White

    End Sub

End Class