'*************************************************************************
' Abstract: 
' This form allows you to manage sponsors (view/add/update/delete) in
' the golfathon database based on the last name of sponsor.
'
' Author: Derrick Warren
'*************************************************************************

Option Strict On

Public Class frmManageSponsors

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Load_LastName() ' load names combo box last so it pulls all info for sponsor 

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cboLastName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLastName.SelectedIndexChanged

        ' this Sub is called anytime the selected item is changed in the combo box.
        Dim strSelect As String = ""
        Dim strName As String = ""
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
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, 
                                strCity, strState, strZip, strPhoneNumber, strEmail 
                         FROM TSponsors 
                         WHERE intSponsorID = " & cboLastName.SelectedValue.ToString

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load the data table from the reader
            dt.Load(drSourceTable)

            ' populate the text boxes with the data
            txtFirstName.Text = dt.Rows(0).Item(0).ToString
            txtLastName.Text = dt.Rows(0).Item(1).ToString
            txtAddress.Text = dt.Rows(0).Item(2).ToString
            txtCity.Text = dt.Rows(0).Item(3).ToString
            txtState.Text = dt.Rows(0).Item(4).ToString
            txtZipCode.Text = dt.Rows(0).Item(5).ToString
            txtPhoneNumber.Text = dt.Rows(0).Item(6).ToString
            txtEmail.Text = dt.Rows(0).Item(7).ToString

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Load_LastName()

        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Try
            ' loop through the textboxes and clear them in case they have data in them after a delete
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

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
            strSelect = "SELECT intSponsorID, strLastName FROM TSponsors"

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add the item to the combo box. we need the sponsor ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the sponsor data.
            ' we are binding the column name to the combo box display and value members. 
            cboLastName.ValueMember = "intSponsorID"
            cboLastName.DisplayMember = "strLastName"
            cboLastName.DataSource = dt

            ' select the first item in the list by default
            If cboLastName.Items.Count > 0 Then cboLastName.SelectedIndex = 0

            ' clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        ' declare variables 
        Dim strSelect As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZipCode As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        Dim intRowsAffected As Integer

        ' thie will hold our Update statement
        Dim cmdUpdate As OleDb.OleDbCommand

        Try
            ' check to make sure all text boxes have data. no data no update!
            If Validation() = True Then
                ' open database this is in module
                If OpenDatabaseConnectionSQLServer() = False Then

                    ' warn user if program is having system problems working
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If

                ' after you validate there is data put values into variables
                If Validation() = True Then

                    strFirstName = txtFirstName.Text
                    strLastName = txtLastName.Text
                    strStreetAddress = txtAddress.Text
                    strCity = txtCity.Text
                    strState = txtState.Text
                    strZipCode = txtZipCode.Text
                    strPhoneNumber = txtPhoneNumber.Text
                    strEmail = txtEmail.Text


                    ' build the select statement using PK from name selected
                    strSelect = "Update TSponsors Set strFirstName = '" & strFirstName & "', 
                                                  " & "strLastName = '" & strLastName & "', 
                                                  " & "strStreetAddress = '" & strStreetAddress & "', 
                                                  " & "strCity = '" & strCity & "', 
                                                  " & "strState = '" & strState & "', 
                                                  " & "strZip = '" & strZipCode & "', 
                                                  " & "strPhoneNumber = '" & strPhoneNumber & "',  
                                                  " & "strEmail = '" & strEmail & "'" &
                                                  "Where intSponsorID = " & cboLastName.SelectedValue.ToString

                    ' uncomment out the following message box line to use as a tool to check your sql statement
                    ' remember anything not a numeric value going into SQL Server must have single quotes '
                    ' around it, including dates.

                    'MessageBox.Show(strSelect)


                    ' make the connection
                    cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                    ' update the row with execute the statement
                    intRowsAffected = cmdUpdate.ExecuteNonQuery()

                    ' have to let the user know what happened 
                    If intRowsAffected = 1 Then
                        MessageBox.Show("Update successful")
                    Else
                        MessageBox.Show("Update failed")
                    End If

                    ' close the database connection
                    CloseDatabaseConnection()

                    ' call the Form Load sub to refresh the combo box data after an update
                    Form1_Load(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
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
            result = MessageBox.Show("Are you sure you want to Delete Sponsor: Last Name-" & cboLastName.Text & "?",
                                     "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' build the delete statement using PK from name selected
                    ' must delete any child records first
                    strDelete = "Delete FROM TGolferEventYearSponsors Where intSponsorID = " & cboLastName.SelectedValue.ToString

                    ' delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' now we can delete the parent record
                    strDelete = "Delete FROM TSponsors Where intSponsorID = " & cboLastName.SelectedValue.ToString

                    ' delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' Did it work?
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

    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click

        ' create a new instance of the add sponsor form
        Dim AddSponsor As New frmAddSponsor

        ' show the new form so any past data is not still on the form
        AddSponsor.ShowDialog()

        ' call the form load so the combo box refreshes with current date
        Form1_Load(sender, e)

    End Sub

    Public Function Validation() As Boolean

        ' loop through the textboxes and check to make sure there is data in them
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                End If
            End If
        Next

        'everything is good so return true
        Return True

    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        Dim cntrlControl As Control

        ' loop through controls on form to clear data input
        For Each cntrlControl In Me.Controls

            ' clear text boxes and combo boxes, also set back color to white
            If TypeOf cntrlControl Is TextBox Or TypeOf cntrlControl Is ComboBox Then
                cntrlControl.ResetText()
                cntrlControl.BackColor = Color.White
            End If
        Next

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' exits form
        Close()

    End Sub

End Class