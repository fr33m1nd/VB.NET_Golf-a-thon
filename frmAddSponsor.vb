'*************************************************************************
' Abstract:
' This form will add a sponsor to the golfathon database.
'
' Author: Derrick Warren
'*************************************************************************

Option Strict On

Public Class frmAddSponsor

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' exits form
        Close()

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

    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click

        ' create variables for sponsor attributes
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

                ' pass inputs, now validated to sub AddSponsor to enter in DB
                AddSponsor(strFirstName, strLastName, strStreetAddress, strCity, strState, strZipCode, strPhoneNumber, strEmail)

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

    Private Sub AddSponsor(ByVal FirstName As String, ByVal LastName As String, ByVal StreetAddress As String, ByVal City As String,
                          ByVal State As String, ByVal ZipCode As String, ByVal PhoneNumber As String, ByVal Email As String)

        ' create command object and integer for number of returned rows
        Dim cmdAddSponsor As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intPKID As Integer ' this is what we pass in as the stored procedure requires it

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
            cmdAddSponsor.CommandText = "EXECUTE uspAddSponsor '" & intPKID & "',
                                                             '" & FirstName & "',
                                                             '" & LastName & "',
                                                             '" & StreetAddress & "',
                                                             '" & City & "',
                                                             '" & State & "',
                                                             '" & ZipCode & "',
                                                             '" & PhoneNumber & "',
                                                             '" & Email & "'"

            cmdAddSponsor.CommandType = CommandType.StoredProcedure

            ' Call stored proc which will insert the record 
            cmdAddSponsor = New OleDb.OleDbCommand(cmdAddSponsor.CommandText, m_conAdministrator)

            ' this return is the # of rows affected
            intRowsAffected = cmdAddSponsor.ExecuteNonQuery()

            ' close database connection
            CloseDatabaseConnection()

            ' have to let the user know what happened 
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Sponsor " & LastName & " has been added.")

            Else
                MessageBox.Show("Insert failed")

            End If

            Close()  ' close the form

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try


    End Sub

    Private Sub frmAddSponsor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class