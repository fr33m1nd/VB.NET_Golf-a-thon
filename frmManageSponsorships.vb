'*******************************************************************************
' Abstract:
' This form allows you to view all sponsors and golfers for an event.
' It will allow you to assign/remove a sponsor and their pledge amount to/from  
' a golfer. You can navigate sponsorships by using the Event Year combo box or
' the Sponsorship ID combo box.
'
' Author: Derrick Warren
'*******************************************************************************

Option Strict On

Public Class frmManageSponsorships

    ' Class level variable
    Dim boolSelected As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Load_Golfer()

            Load_Sponsor()

            Load_Sponsorship()

            Load_SponsorType()

            Load_PaymentType()

            Load_PaymentStatus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frmSponsorshipGolferEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form load will load the combo box. If you setup the combo box with a
        ' selected index change (see below) it will load the golfer, event, and sponsors from the
        ' event year selected into to Sponsorship Golfer Events list view. 

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


            ' Add the item to the combo box. We need the event year ID associated with the event year so 
            ' when we click on the event year we can then use the ID to pull the rest of the events data.
            ' We are binding the column event year to the combo box display and value members. 
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
            ' LOAD GOLFERS AND RELATED SPONSORS FOR EVENT IN LISTVIEW 
            ' *************************************************************************************
            Dim objListView As ListViewItem

            lvwSponsorships.Items.Clear()

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
            lvwSponsorships.BeginUpdate()

            ' Build the select statement for combo box for events
            strSelect = "SELECT * FROM vSponsorEventGolfers1 
                        WHERE EventYearID = " & cboEvent.SelectedValue.ToString

            ' Retrieve all the records 
            'm_conAdministrator = New OleDbConnection(connectionString)
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            'cmdSelect.Connection.Open()
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            'dt.Load(drSourceTable)


            Do While drSourceTable.Read = True

                objListView = New ListViewItem(CType(drSourceTable("EventYear"), String))
                objListView.SubItems.Add(CType(drSourceTable("GolferFirstName"), String))
                objListView.SubItems.Add(CType(drSourceTable("GolferLastName"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorFirstName"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorLastName"), String))
                objListView.SubItems.Add(CType(drSourceTable("PledgeAmount"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorType"), String))
                objListView.SubItems.Add(CType(drSourceTable("PaymentType"), String))
                objListView.SubItems.Add(CType(drSourceTable("PaidStatus"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorshipID"), String))
                lvwSponsorships.Items.Add(objListView)
            Loop

            ' Select the first item in the list by default
            If lvwSponsorships.Items.Count > 0 Then lvwSponsorships.Items(0).Selected = True

            ' Show any changes
            lvwSponsorships.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub cboEvent_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboEvent.SelectedIndexChanged

        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim objListView As ListViewItem

        ' clear unwanted data
        lvwSponsorships.Items.Clear()

        Try
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
            lvwSponsorships.BeginUpdate()
            cboGolfer.BeginUpdate()

            ' build select statement
            strSelect = "SELECT * FROM vSponsorEventGolfers1 WHERE EventYearID = " & cboEvent.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' populate the listview
            Do While drSourceTable.Read = True

                objListView = New ListViewItem(CType(drSourceTable("EventYear"), String))
                objListView.SubItems.Add(CType(drSourceTable("GolferFirstName"), String))
                objListView.SubItems.Add(CType(drSourceTable("GolferLastName"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorFirstName"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorLastName"), String))
                objListView.SubItems.Add(CType(drSourceTable("PledgeAmount"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorType"), String))
                objListView.SubItems.Add(CType(drSourceTable("PaymentType"), String))
                objListView.SubItems.Add(CType(drSourceTable("PaidStatus"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorshipID"), String))
                lvwSponsorships.Items.Add(objListView)

            Loop

            ' build select statement 
            strSelect = "SELECT intGolferID, strLastName, strFirstName FROM vEventGolfers1 WHERE intEventYearID = " & cboEvent.SelectedValue.ToString

            ' Retrieve all the records
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' We are binding the column name to the combo box display and value members. 
            cboGolfer.ValueMember = "intGolferID"
            cboGolfer.DisplayMember = "strLastName"
            cboGolfer.DataSource = dt

            ' Select the first item in the list by default
            'If lvwSponsorships.Items.Count > 0 Then lvwSponsorships.Items(0).Selected = True
            If cboGolfer.Items.Count > 0 Then cboGolfer.SelectedIndex = 0

            ' Show any changes
            lvwSponsorships.EndUpdate()
            cboGolfer.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub cboSponsorshipID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSponsorshipID.SelectedIndexChanged

        ' this Sub is called anytime the selected item is changed in the combo box.
        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim objListView As ListViewItem

        Try
            lvwSponsorships.Items.Clear()

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
            lvwSponsorships.BeginUpdate()

            ' Build the select statement for combo box for events
            strSelect = "SELECT * FROM vSponsorEventGolfers1 
                        WHERE SponsorshipID = " & cboSponsorshipID.SelectedValue.ToString

            ' Retrieve all the records 
            'm_conAdministrator = New OleDbConnection(connectionString)
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            'cmdSelect.Connection.Open()
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            'dt.Load(drSourceTable)


            Do While drSourceTable.Read = True

                objListView = New ListViewItem(CType(drSourceTable("EventYear"), String))
                objListView.SubItems.Add(CType(drSourceTable("GolferFirstName"), String))
                objListView.SubItems.Add(CType(drSourceTable("GolferLastName"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorFirstName"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorLastName"), String))
                objListView.SubItems.Add(CType(drSourceTable("PledgeAmount"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorType"), String))
                objListView.SubItems.Add(CType(drSourceTable("PaymentType"), String))
                objListView.SubItems.Add(CType(drSourceTable("PaidStatus"), String))
                objListView.SubItems.Add(CType(drSourceTable("SponsorshipID"), String))
                lvwSponsorships.Items.Add(objListView)
            Loop

            ' Select the first item in the list by default
            If lvwSponsorships.Items.Count > 0 Then lvwSponsorships.Items(0).Selected = True

            ' change sponsor combo box display
            cboSponsor.Text = lvwSponsorships.SelectedItems(0).SubItems(4).Text


            ' Show any changes
            lvwSponsorships.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cboSponsor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSponsor.SelectedIndexChanged

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
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, 
                                strZip, strPhoneNumber, strEmail 
                         FROM TSponsors 
                         WHERE intSponsorID = " & cboSponsor.SelectedValue.ToString


            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load the data table from the reader
            dt.Load(drSourceTable)

            ' populate the text boxes with the data
            txtSponsorFirstName.Text = dt.Rows(0).Item(0).ToString
            txtSponsorLastName.Text = dt.Rows(0).Item(1).ToString
            txtPledge.Text = ""
            cboSponsorType.Text = ""
            cboPaymentType.Text = ""
            cboPaidStatus.Text = ""

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cboGolfer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGolfer.SelectedIndexChanged

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
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, 
                                strPhoneNumber, strEmail, intShirtSizeID, intGenderID 
                         FROM TGolfers 
                         WHERE intGolferID = " & cboGolfer.SelectedValue.ToString

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load the data table from the reader
            dt.Load(drSourceTable)

            ' populate the text boxes with the data
            txtFirstName.Text = dt.Rows(0).Item(0).ToString
            txtLastName.Text = dt.Rows(0).Item(1).ToString

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lvwSponsorships_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvwSponsorships.ItemSelectionChanged

        ' Link listview to respective textboxes and combo boxes
        ' When row is selected the values in each will change as well

        If e.IsSelected Then
            boolSelected = True
            txtFirstName.Text = lvwSponsorships.SelectedItems(0).SubItems(1).Text
            txtLastName.Text = lvwSponsorships.SelectedItems(0).SubItems(2).Text
            cboGolfer.Text = lvwSponsorships.SelectedItems(0).SubItems(2).Text
            txtSponsorFirstName.Text = lvwSponsorships.SelectedItems(0).SubItems(3).Text
            txtSponsorLastName.Text = lvwSponsorships.SelectedItems(0).SubItems(4).Text
            cboSponsorshipID.Text = lvwSponsorships.SelectedItems(0).SubItems(9).Text
            cboSponsor.Text = lvwSponsorships.SelectedItems(0).SubItems(4).Text
            txtPledge.Text = lvwSponsorships.SelectedItems(0).SubItems(5).Text
            cboSponsorType.Text = lvwSponsorships.SelectedItems(0).SubItems(6).Text
            cboPaymentType.Text = lvwSponsorships.SelectedItems(0).SubItems(7).Text
            cboPaidStatus.Text = lvwSponsorships.SelectedItems(0).SubItems(8).Text
        Else
            boolSelected = False
        End If

    End Sub

    Private Sub Load_Golfer()

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
            strSelect = "SELECT intGolferID, strLastName FROM TGolfers"

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add the item to the combo box. we need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' we are binding the column name to the combo box display and value members. 
            cboGolfer.ValueMember = "intGolferID"
            cboGolfer.DisplayMember = "strLastName"
            cboGolfer.DataSource = dt

            ' select the first item in the list by default
            If cboGolfer.Items.Count > 0 Then cboGolfer.SelectedIndex = 0

            ' clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub Load_Sponsor()

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
            cboSponsor.ValueMember = "intSponsorID"
            cboSponsor.DisplayMember = "strLastName"
            cboSponsor.DataSource = dt

            ' select the first item in the list by default
            If cboSponsor.Items.Count > 0 Then cboSponsor.SelectedIndex = 0

            ' clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub Load_Sponsorship()

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
            strSelect = "SELECT SponsorshipID FROM vSponsorEventGolfers1"

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add the item to the combo box. we need the sponsorship ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the sponsor data.
            ' we are binding the column name to the combo box display and value members. 
            cboSponsorshipID.ValueMember = "SponsorshipID"
            cboSponsorshipID.DisplayMember = "SponsorshipID"
            cboSponsorshipID.DataSource = dt

            ' select the first item in the list by default
            If cboSponsorshipID.Items.Count > 0 Then cboSponsorshipID.SelectedIndex = 0

            ' clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub Load_PaymentType()
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
            strSelect = "SELECT intPaymentTypeID, strPaymentTypeDesc FROM TPaymentTypes"

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add the item to the combo box. we need the payment type ID associated with the name  
            ' we are binding the column name to the combo box display and value members. 
            cboPaymentType.ValueMember = "intPaymentTypeID"
            cboPaymentType.DisplayMember = "strPaymentTypeDesc"
            cboPaymentType.DataSource = dt

            ' select the first item in the list by default
            ' comment this line out so actual payment type is selected and not the first item
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

    Private Sub Load_SponsorType()
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
            strSelect = "SELECT intSponsorTypeID, strSponsorTypeDesc FROM TSponsorTypes"

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add the item to the combo box. we need the sponsor type ID associated with the name  
            ' we are binding the column name to the combo box display and value members. 
            cboSponsorType.ValueMember = "intSponsorTypeID"
            cboSponsorType.DisplayMember = "strSponsorTypeDesc"
            cboSponsorType.DataSource = dt

            ' select the first item in the list by default
            ' comment this line out so actual sponsorship type is selected and not the first item
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

    Private Sub Load_PaymentStatus()
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
            strSelect = "SELECT intPaidStatusID, strPaidStatusDesc FROM TPaidStatus"

            ' retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add the item to the combo box. we need the paid status ID associated with the name  
            ' we are binding the column name to the combo box display and value members. 
            cboPaidStatus.ValueMember = "intPaidStatusID"
            cboPaidStatus.DisplayMember = "strPaidStatusDesc"
            cboPaidStatus.DataSource = dt

            ' select the first item in the list by default
            ' comment this line out so actual payment status is selected and not the first item
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

    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click

        ' Created a stored sproc where sponsor will be added to golfer 
        ' and all related data would correspond to returning the desired result.
        ' This data is to populate the list view.

        ' create command object and integer for number of returned rows
        Dim cmdAddGolferEventYearSponsor As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intPKID As Integer ' this is what we pass in as the stored procedure requires it
        Dim objListView As ListViewItem

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
            cmdAddGolferEventYearSponsor.CommandText = "EXECUTE uspAddGolferEventYearSponsor '" & intPKID & "',
                                                                                              " & cboGolfer.SelectedValue.ToString & ",
                                                                                              " & cboEvent.SelectedValue.ToString & ",
                                                                                              " & cboSponsorshipID.SelectedValue.ToString & ",
                                                                                             '" & txtPledge.Text.ToString & "',
                                                                                              " & cboSponsorType.SelectedValue.ToString & ",
                                                                                              " & cboPaymentType.SelectedValue.ToString & ",
                                                                                              " & cboPaidStatus.SelectedValue.ToString & ""

            cmdAddGolferEventYearSponsor.CommandType = CommandType.StoredProcedure

            ' Call stored proc which will insert the record 
            cmdAddGolferEventYearSponsor = New OleDb.OleDbCommand(cmdAddGolferEventYearSponsor.CommandText, m_conAdministrator)

            ' Is Pledge Numeric and Not Empty
            If IsNumeric(txtPledge.Text) And
               txtPledge.Text <> String.Empty Then
                ' yes, add sponsor
                objListView = New ListViewItem(cmdAddGolferEventYearSponsor.CommandText.ToString)
                lvwSponsorships.Items.Add(objListView)
            Else
                MessageBox.Show("Error! Please enter Numeric Values for Pledge.",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' this return is the # of rows affected
            intRowsAffected = cmdAddGolferEventYearSponsor.ExecuteNonQuery()

            ' close database connection
            CloseDatabaseConnection()

            ' reload the form so the changes are shown
            Form1_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

    End Sub

    Private Sub btnRemoveSponsorship_Click_1(sender As Object, e As EventArgs) Handles btnRemoveSponsorship.Click

        ' button click to drop sponsor from golfer

        ' create command object and integer for number of returned rows
        Dim cmdDeleteGolferEventYearSponsor As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim result As DialogResult
        Dim strDelete As String

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

            ' always ask before deleting!!!!
            result = MessageBox.Show("Are you sure you want to Delete Sponsor: " & txtSponsorLastName.Text &
                                     " from Golfer: " & txtLastName.Text & " ?",
                                     "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes
            End Select

            ' Make sure we are deleting the selected row and all values in the row
            If result = DialogResult.Yes Then
                Dim intSelectedIndex As Integer = lvwSponsorships.SelectedIndices(0)

                ' build the delete statement using PK from name selected
                ' must delete any child records first
                strDelete = "Delete FROM TGolferEventYearSponsors Where intGolferEventYearSponsorID = " & cboSponsorshipID.SelectedValue.ToString & ""

                ' delete the record(s) 
                cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                intRowsAffected = cmdDelete.ExecuteNonQuery()

                ' remove row from listview
                lvwSponsorships.Items.RemoveAt(intSelectedIndex)
            End If

            ' close database connection
            CloseDatabaseConnection()

            ' reload the form so the changes are shown
            Form1_Load(sender, e)

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
