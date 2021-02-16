'********************************************************************************
' Abstract: this form allows you to view all golfers that are either in an event
' or not not currently in an event. It will allow you to add or drop a 
' golfer from that event
'
'Author: Derrick Warren
'********************************************************************************
Option Strict On

Public Class frmManageGolferEvents

    Private Sub frmManageGolferEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form load will load the combo box. If you setup the combo box with a
        ' selected index change (see below) it will load the golfers from the
        ' event selected into to Golfers Event list box. Form load will also pull 
        ' golfers from the view in the DB that has golfers not in an event and load
        ' them into the Available golfers list box.

        Try

            ' *************************************************************************************
            ' LOAD EVENTS COMBO BOX
            ' *************************************************************************************

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Show changes all at once at end (MUCH faster). 
            cboEvent.BeginUpdate()

            ' Build the select statement for combo box for events
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboEvent.ValueMember = "intEventYearID"
            cboEvent.DisplayMember = "intEventYear"
            cboEvent.DataSource = dt

            ' Select the first item in the list by default
            'If cboEvent.Items.Count > 0 Then cboEvent.SelectedIndex = 0

            ' Show any changes
            cboEvent.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()


            ' *************************************************************************************
            ' LOAD AVAILABLE GOLFERS LISTBOX
            ' *************************************************************************************
            Dim dt1 As DataTable = New DataTable ' this is the table we will load from our reader

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Show changes all at once at end (MUCH faster). 
            lstAvailable.BeginUpdate()

            ' Build the select statement
            strSelect = "SELECT intGolferID, FullName FROM vAvailableGolfers WHERE intEventYearID = " & cboEvent.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt1.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstAvailable.ValueMember = "intGolferID"
            lstAvailable.DisplayMember = "strLastName"
            lstAvailable.DataSource = dt1



            ' Select the first item in the list by default
            'If lstAvailable.Items.Count > 0 Then lstAvailable.SelectedIndex = 0

            ' Show any changes
            lstAvailable.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub cboEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvent.SelectedIndexChanged
        ' create this SUB by double clicking on the combo box. This will load
        ' golfers in event based on index (DB PK) into the list box for event 
        ' golfers when combo box index changes.
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
            Dim dt1 As DataTable = New DataTable ' this is the table we will load from our reader

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Show changes all at once at end (MUCH faster). 
            lstInEvent.BeginUpdate()
            lstAvailable.BeginUpdate()

            ' Build the select statement for listbox with golfers in an event selected
            strSelect = "SELECT intGolferID, FullName FROM vEventGolfers WHERE intEventYearID = " & cboEvent.SelectedValue.ToString &
                "SELECT intGolferID, FullName FROM vAvailableGolfers WHERE intEventYearID = " & cboEvent.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            dt1.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstInEvent.ValueMember = "intGolferID"
            lstInEvent.DisplayMember = "FullName"
            lstInEvent.DataSource = dt

            lstAvailable.ValueMember = "intGolferID"
            lstAvailable.DisplayMember = "FullName"
            lstAvailable.DataSource = dt1

            ' Select the first item in the list by default
            'If lstInEvent.Items.Count > 0 Then
            '    lstInEvent.SelectedIndex = 0
            'ElseIf lstInEvent.Items.Count = 0 Then
            '    lstInEvent.SelectedIndex = 1
            'End If

            'If lstAvailable.Items.Count > 0 Then lstInEvent.SelectedIndex = 0

            ' Show any changes
            lstInEvent.EndUpdate()
            lstAvailable.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()



        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click

        ' this SUB will add an available golfer to the team in the combo box. The 
        ' player will then show up in the event golfers list box when the event is selected
        ' in the combo box.

        Try

            Dim strInsert As String = ""
            Dim cmdInsert As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
            Dim intRowsAffected As Integer

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If


            ' Build the select statement
            strInsert = "INSERT INTO TGolferEventYears ( intEventYearID, intGolferID)" &
                        "Values (" & cboEvent.SelectedValue.ToString & ", " & lstAvailable.SelectedValue.ToString & ")"

            ' Retrieve all the records 
            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


            intRowsAffected = cmdInsert.ExecuteNonQuery()


            ' close the database connection
            CloseDatabaseConnection()

            ' reload the form so the changes are shown
            frmManageGolferEvents_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnDropGolfer_Click(sender As Object, e As EventArgs) Handles btnDropGolfer.Click

        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult

        Try



            ' open the database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' always ask before deleting!!!!
            result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name-" & lstInEvent.Text & " from " & cboEvent.Text & " ?",
                                     "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' Build the delete statement using PK from name selected
                    strDelete = "Delete FROM TGolferEventYears Where intGolferID = " & lstInEvent.SelectedValue.ToString &
                        "AND intEventYearID = " & cboEvent.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()


            End Select


            ' close the database connection
            CloseDatabaseConnection()

            ' refresh the form so changes can be seen
            frmManageGolferEvents_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' close form
        Close()

    End Sub

End Class
