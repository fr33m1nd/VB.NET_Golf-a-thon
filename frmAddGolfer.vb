'*************************************************************************
' Abstract: 
' This form will add a golfer to the golfathon database.
'
' Author: Derrick Warren
'*************************************************************************
Option Strict On

Public Class frmAddGolfer
    Private Sub frmAddGolfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            ' load data from combo boxes
            Load_ShirtSize()

            Load_Gender()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Load_ShirtSize()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

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
            strSelect = "SELECT intShirtSizeID, strShirtSizeDesc FROM TShirtSizes"

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add the item to the combo box. We need the shirt size ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the shirt size data.
            ' we are binding the column name to the combo box display and value members. 
            cboShirtSize.ValueMember = "intShirtSizeID"
            cboShirtSize.DisplayMember = "strShirtSizeDesc"
            cboShirtSize.DataSource = dt

            ' select the first item in the list by default
            ' comment this line out so actual shirt size is selected and not the first item
            'If cboShirtSize.Items.Count > 0 Then cboShirtSize.SelectedIndex = 0

            ' clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Load_Gender()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

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


            ' Build the select statement
            strSelect = "SELECT intGenderID, strGenderDesc FROM TGenders"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add the item to the combo box. we need the gender ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the gender description data.
            ' we are binding the column name to the combo box display and value members. 
            cboGender.ValueMember = "intGenderID"
            cboGender.DisplayMember = "strGenderDesc"
            cboGender.DataSource = dt

            ' select the first item in the list by default
            ' comment this line out so actual shirt size is selected and not the first item
            'If cboGender.Items.Count > 0 Then cboGender.SelectedIndex = 0

            ' clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click

        ' create variables for golfer attributes
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZipCode As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""

        Try

            ' call validation---we MUST validate ALL input
            If Validation(strFirstName, strLastName, strStreetAddress, strCity,
                          strState, strZipCode, strPhoneNumber, strEmail) = True AndAlso
                          DeleteValidation() = True Then

                ' pass inputs, now validated to sub AddGolfer to enter in DB
                AddGolfer(strFirstName, strLastName, strStreetAddress, strCity, strState, strZipCode, strPhoneNumber, strEmail)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Function Validation(ByRef FirstName As String, ByRef LastName As String, ByRef StreetAddress As String, ByRef City As String,
                          ByRef State As String, ByRef ZipCode As String, ByRef PhoneNumber As String, ByRef Email As String) As Boolean

        Dim intErrorCount As Integer = 0

        ' loop through each textbox
        For Each txtTextBox As TextBox In Me.Controls.OfType(Of TextBox)()

            ' check if textbox is empty
            If txtTextBox.Text = String.Empty Then
                ' count each error
                intErrorCount += 1
            Else
                ' set parameters to textbox values
                FirstName = txtFirstName.Text
                LastName = txtLastName.Text
                StreetAddress = txtAddress.Text
                City = txtCity.Text
                State = txtState.Text
                ZipCode = txtZipCode.Text
                PhoneNumber = txtPhoneNumber.Text
                Email = txtEmail.Text
            End If
        Next

        ' did validation loop catch any errors
        If intErrorCount > 0 Then
            ' yes, alert user
            MessageBox.Show("Error! All Fields Required.", "Invalid Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Is Zip Code Numeric and length of 5
        If IsNumeric(txtZipCode.Text) And
           (txtZipCode.Text.Length = 5) Then
            ' yes, set parameter to textbox value
            ZipCode = txtZipCode.Text
        Else
            MessageBox.Show("Error! Please enter Numeric Values for:" & vbNewLine &
                            "Zip Codes(5 digits) and Phone Numbers(10 digits).", "Invalid Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' count each error
            intErrorCount += 1
        End If

        ' Is Phone Number Numeric and length of 10
        If IsNumeric(txtPhoneNumber.Text) And
               (txtPhoneNumber.Text.Length = 10) Then
            ' yes, set parameter to textbox value
            PhoneNumber = txtPhoneNumber.Text
        Else
            MessageBox.Show("Error! Please enter Numeric Values for:" & vbNewLine &
                            "Zip Codes(5 digits) and Phone Numbers(10 digits).", "Invalid Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' count each error
            intErrorCount += 1
        End If

        ' Did validation function catch any errors?
        If intErrorCount > 0 Then
            ' yes, return false
            Return False
        Else
            Return True
        End If

    End Function

    Public Function DeleteValidation() As Boolean

        ' loop through the textboxes and clear them in case they have data in them after a delete
        For Each cntrlControl As Control In Controls
            If TypeOf cntrlControl Is TextBox Then
                cntrlControl.BackColor = Color.White
                If cntrlControl.Text = String.Empty Then
                    cntrlControl.BackColor = Color.Yellow
                    cntrlControl.Focus()
                    Return False
                End If
            End If
        Next

        'everything is good so return true
        Return True

    End Function

    Private Sub AddGolfer(ByVal FirstName As String, ByVal LastName As String, ByVal StreetAddress As String, ByVal City As String,
                          ByVal State As String, ByVal ZipCode As String, ByVal PhoneNumber As String, ByVal Email As String)

        ' create command object and integer for number of returned rows
        Dim cmdAddGolfer As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intPKID As Integer ' this is what we pass in as the stored procedure requires it

        ' convert combo boxes to variables
        Dim intShirtSizeID = CInt(cboShirtSize.SelectedValue.ToString)
        Dim intGenderID = CInt(cboGender.SelectedValue.ToString)

        Try

            ' open database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' text to call stored proc
            cmdAddGolfer.CommandText = "EXECUTE uspAddGolfer '" & intPKID & "',
                                                           '" & FirstName & "',
                                                           '" & LastName & "',
                                                           '" & StreetAddress & "',
                                                           '" & City & "',
                                                           '" & State & "',
                                                           '" & ZipCode & "',
                                                           '" & PhoneNumber & "',
                                                           '" & Email & "'," &
                                                                intShirtSizeID & "," &
                                                                intGenderID & ""

            cmdAddGolfer.CommandType = CommandType.StoredProcedure

            ' Call stored proc which will insert the record 
            cmdAddGolfer = New OleDb.OleDbCommand(cmdAddGolfer.CommandText, m_conAdministrator)

            ' this return is the # of rows affected
            intRowsAffected = cmdAddGolfer.ExecuteNonQuery()

            ' close database connection
            CloseDatabaseConnection()

            ' have to let the user know what happened 
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Golfer " & LastName & " has been added.")

            Else
                MessageBox.Show("Insert failed")

            End If

            Close()  ' close the form

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

    End Sub

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