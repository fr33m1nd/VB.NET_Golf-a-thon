'*************************************************************************
' Abstract:
' This form will add an event to the golfathon database based on the year.
'
' Author: Derrick Warren
'*************************************************************************

Option Strict On

Public Class frmAddEvent
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' exits form
        Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'clears data from form
        txtEventYear.Clear()

        txtEventYear.BackColor = Color.White

    End Sub

    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click

        ' create variable for Event Year
        Dim intEventYear As Integer

        ' call validation---we MUST validate ALL input
        If Validation(intEventYear) = True Then

            ' pass inputs, now validated to sub AddEvent to enter in DB
            AddEvent(intEventYear)

        End If

    End Sub

    Public Function Validation(ByRef EventYear As Integer) As Boolean

        ' validate input
        If (txtEventYear.Text) = "" Then
            txtEventYear.BackColor = Color.Yellow
            txtEventYear.Focus()
            MessageBox.Show("Please enter a valid year.")
            Return False
        Else
            EventYear = CInt(txtEventYear.Text)
            Return True
        End If

        ' chose a value of 1980 because that's plenty big enough a window for a
        ' realistic time frame for editing records in database for Golfathon
        If IsNumeric(txtEventYear.Text) AndAlso CInt(txtEventYear.Text) > 1980 Then
            EventYear = CInt(txtEventYear.Text)
            Return True
        Else
            txtEventYear.BackColor = Color.Yellow
            txtEventYear.Focus()
            MessageBox.Show("Please enter a valid year.")
            Return False
        End If

    End Function

    Private Sub AddEvent(ByVal EventYear As Integer)

        ' create command object and integer for number of returned rows
        Dim cmdAddEvent As New OleDb.OleDbCommand()
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
            cmdAddEvent.CommandText = "EXECUTE uspAddEvent '" & intPKID & "','" & EventYear & "'"
            cmdAddEvent.CommandType = CommandType.StoredProcedure

            ' Call stored proc which will insert the record 
            cmdAddEvent = New OleDb.OleDbCommand(cmdAddEvent.CommandText, m_conAdministrator)

            ' this return is the # of rows affected
            intRowsAffected = cmdAddEvent.ExecuteNonQuery()

            ' close database connection
            CloseDatabaseConnection()

            ' have to let the user know what happened 
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Event " & EventYear & " has been added.")

            Else
                MessageBox.Show("Insert failed")

            End If

            Close()  ' close the form

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

    End Sub

End Class