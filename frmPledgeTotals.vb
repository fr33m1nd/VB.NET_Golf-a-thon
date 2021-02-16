'*****************************************************************************************
' Abstract: this form allows you to view different pledge totals by event: 
'                                                           1) Total Pledged for a Golfer
'                                                           2) Total Pledged by a Sponsor
'                                                           3) Total Pledged for an event
'
'Author: Derrick Warren
'*****************************************************************************************
Option Strict On

Public Class frmPledgeTotals

    Private Sub frmPledgeTotals_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            strSelect = "SELECT intEventYearID, intEventYear FROM vTotalPledgedEvent"

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
            If cboEvent.Items.Count > 0 Then cboEvent.SelectedIndex = 0

            ' Show any changes
            cboEvent.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()


            ' *************************************************************************************
            ' LOAD TOTAL PLEDGED FOR EVENT
            ' *************************************************************************************
            Dim dt1 As DataTable = New DataTable ' this is the table we will load from our reader
            Dim row As DataRow

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
            strSelect = "SELECT TotalPledgedEvent
                         FROM   vTotalPledgedEvent              
                         WHERE  intEventYearID = " & cboEvent.SelectedValue.ToString

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load the data table from the reader
            dt1.Load(drSourceTable)

            ' display Totals pledged for event in textbox
            For Each row In dt1.Rows
                lblPledgeEvent.Text = row.Field(Of String)("TotalPledgedEvent")
            Next

            'lblPledgeEvent.Text = dt1.Rows(0).Item(0).ToString

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
            Dim dt1 As DataTable = New DataTable
            Dim dt2 As DataTable = New DataTable
            Dim row As DataRow

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
            cboGolfer.BeginUpdate()
            cboSponsor.BeginUpdate()

            ' Build the select statement for sponsors and golfers that are affiliated with sponsorship  
            strSelect = "SELECT intGolferID, FullName 
                         FROM vEventGolfers 
                         WHERE intEventYearID = " & cboEvent.SelectedValue.ToString &
                        "SELECT intSponsorID, SponsorName 
                         FROM vTotalPledgedSponsor 
                         WHERE EventYearID = " & cboEvent.SelectedValue.ToString &
                        "SELECT TotalPledgedEvent
                         FROM   vTotalPledgedEvent              
                         WHERE  intEventYearID = " & cboEvent.SelectedValue.ToString


            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)
            dt1.Load(drSourceTable)
            dt2.Load(drSourceTable)

            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboGolfer.ValueMember = "intGolferID"
            cboGolfer.DisplayMember = "FullName"
            cboGolfer.DataSource = dt

            cboSponsor.ValueMember = "intSponsorID"
            cboSponsor.DisplayMember = "SponsorName"
            cboSponsor.DataSource = dt1


            ' display Totals pledged for event in textbox
            For Each row In dt2.Rows
                lblPledgeEvent.Text = row.Field(Of String)("TotalPledgedEvent")
            Next

            ' Select the first item in the list by default
            If cboGolfer.Items.Count > 0 Then cboGolfer.SelectedIndex = 0
            If cboSponsor.Items.Count > 0 Then cboSponsor.SelectedIndex = 0

            ' Show any changes
            cboGolfer.EndUpdate()
            cboSponsor.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub cboGolfer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGolfer.SelectedIndexChanged

        ' create this SUB by double clicking on the combo box. This will load
        ' golfers in event based on index (DB PK) into the list box for event 
        ' golfers when combo box index changes.
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
            Dim row As DataRow

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
            strSelect = "SELECT TotalPledgedGolfer
                         FROM   vTotalPledgedGolfer              
                         WHERE  intGolferID = " & cboGolfer.SelectedValue.ToString &
                                "AND intEventYearID = " & cboEvent.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' display Totals pledged for golfer in textbox
            For Each row In dt.Rows
                lblPledgeGolfer.Text = row.Field(Of String)("TotalPledgedGolfer")
            Next

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub cboSponsor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSponsor.SelectedIndexChanged

        ' create this SUB by double clicking on the combo box. This will load
        ' golfers in event based on index (DB PK) into the list box for event 
        ' golfers when combo box index changes.

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
            Dim row As DataRow
            Dim intIndex As Integer = 0

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
            strSelect = "SELECT TotalPledgedSponsor
                         FROM   vTotalPledgedSponsor              
                         WHERE  intSponsorID = " & cboSponsor.SelectedValue.ToString &
                                "AND EventYearID = " & cboEvent.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' display Totals pledged for sponsor in textbox
            For Each row In dt.Rows
                lblPledgeSponsor.Text = row.Field(Of String)("TotalPledgedSponsor")
            Next

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        Dim cntrlControl As Control

        ' loop through controls on form to clear data input
        For Each cntrlControl In Me.Controls

            ' clear labels and combo boxes, also set back color to white
            If TypeOf cntrlControl Is ComboBox Then
                cntrlControl.ResetText()
                cntrlControl.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' close form
        Close()

    End Sub

End Class