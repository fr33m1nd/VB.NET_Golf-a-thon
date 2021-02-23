<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageSponsorships
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
        Me.cboPaidStatus = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPaymentType = New System.Windows.Forms.ComboBox()
        Me.txtPledge = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSponsorType = New System.Windows.Forms.ComboBox()
        Me.lvwSponsorships = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboEvent = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtSponsorLastName = New System.Windows.Forms.TextBox()
        Me.txtSponsorFirstName = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboSponsorshipID = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboGolfer = New System.Windows.Forms.ComboBox()
        Me.btnAddSponsor = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRemoveSponsorship = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSponsor = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cboPaidStatus
        '
        Me.cboPaidStatus.FormattingEnabled = True
        Me.cboPaidStatus.Items.AddRange(New Object() {"", "Yes", "No"})
        Me.cboPaidStatus.Location = New System.Drawing.Point(752, 325)
        Me.cboPaidStatus.Name = "cboPaidStatus"
        Me.cboPaidStatus.Size = New System.Drawing.Size(198, 21)
        Me.cboPaidStatus.TabIndex = 148
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(658, 328)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Paid Status"
        '
        'cboPaymentType
        '
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Items.AddRange(New Object() {"", "Check ", "Cash", "Credit Card"})
        Me.cboPaymentType.Location = New System.Drawing.Point(752, 298)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(198, 21)
        Me.cboPaymentType.TabIndex = 146
        '
        'txtPledge
        '
        Me.txtPledge.Location = New System.Drawing.Point(752, 241)
        Me.txtPledge.Name = "txtPledge"
        Me.txtPledge.Size = New System.Drawing.Size(126, 20)
        Me.txtPledge.TabIndex = 145
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(658, 244)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "Pledge Amount"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(658, 273)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "Sponsor Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(657, 301)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "Payment Type"
        '
        'cboSponsorType
        '
        Me.cboSponsorType.FormattingEnabled = True
        Me.cboSponsorType.Items.AddRange(New Object() {"", "Parent", "Alumni", "Friend", "Business"})
        Me.cboSponsorType.Location = New System.Drawing.Point(752, 270)
        Me.cboSponsorType.Name = "cboSponsorType"
        Me.cboSponsorType.Size = New System.Drawing.Size(198, 21)
        Me.cboSponsorType.TabIndex = 141
        '
        'lvwSponsorships
        '
        Me.lvwSponsorships.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lvwSponsorships.FullRowSelect = True
        Me.lvwSponsorships.GridLines = True
        Me.lvwSponsorships.HideSelection = False
        Me.lvwSponsorships.Location = New System.Drawing.Point(41, 385)
        Me.lvwSponsorships.Name = "lvwSponsorships"
        Me.lvwSponsorships.Size = New System.Drawing.Size(1015, 289)
        Me.lvwSponsorships.TabIndex = 140
        Me.lvwSponsorships.UseCompatibleStateImageBehavior = False
        Me.lvwSponsorships.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Event Year"
        Me.ColumnHeader1.Width = 66
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DisplayIndex = 2
        Me.ColumnHeader2.Text = "Golfer First Name"
        Me.ColumnHeader2.Width = 110
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 3
        Me.ColumnHeader3.Text = "Golfer Last Name"
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 4
        Me.ColumnHeader4.Text = "Sponsor First Name"
        Me.ColumnHeader4.Width = 110
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 5
        Me.ColumnHeader5.Text = "Sponsor Last Name"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DisplayIndex = 6
        Me.ColumnHeader6.Text = "Pledge Amount"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DisplayIndex = 7
        Me.ColumnHeader7.Text = "Sponsor Type"
        Me.ColumnHeader7.Width = 115
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.DisplayIndex = 8
        Me.ColumnHeader8.Text = "Payment Type"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.DisplayIndex = 9
        Me.ColumnHeader9.Text = "Paid Status"
        Me.ColumnHeader9.Width = 80
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.DisplayIndex = 1
        Me.ColumnHeader10.Text = "Sponsorship ID"
        Me.ColumnHeader10.Width = 90
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(512, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 139
        Me.Label9.Text = "Event:"
        '
        'cboEvent
        '
        Me.cboEvent.FormattingEnabled = True
        Me.cboEvent.Location = New System.Drawing.Point(484, 38)
        Me.cboEvent.Name = "cboEvent"
        Me.cboEvent.Size = New System.Drawing.Size(106, 21)
        Me.cboEvent.TabIndex = 138
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(38, 357)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 137
        Me.Label8.Text = "Sponsorships:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label24.Location = New System.Drawing.Point(654, 52)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(82, 13)
        Me.Label24.TabIndex = 134
        Me.Label24.Text = "Sponsorship ID:"
        '
        'txtSponsorLastName
        '
        Me.txtSponsorLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSponsorLastName.Location = New System.Drawing.Point(752, 211)
        Me.txtSponsorLastName.Name = "txtSponsorLastName"
        Me.txtSponsorLastName.Size = New System.Drawing.Size(198, 20)
        Me.txtSponsorLastName.TabIndex = 133
        '
        'txtSponsorFirstName
        '
        Me.txtSponsorFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSponsorFirstName.Location = New System.Drawing.Point(752, 184)
        Me.txtSponsorFirstName.Name = "txtSponsorFirstName"
        Me.txtSponsorFirstName.Size = New System.Drawing.Size(198, 20)
        Me.txtSponsorFirstName.TabIndex = 132
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label22.Location = New System.Drawing.Point(657, 214)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(58, 13)
        Me.Label22.TabIndex = 131
        Me.Label22.Text = "Last Name"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label23.Location = New System.Drawing.Point(658, 187)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 13)
        Me.Label23.TabIndex = 130
        Me.Label23.Text = "First Name"
        '
        'cboSponsorshipID
        '
        Me.cboSponsorshipID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboSponsorshipID.FormattingEnabled = True
        Me.cboSponsorshipID.Location = New System.Drawing.Point(657, 81)
        Me.cboSponsorshipID.Name = "cboSponsorshipID"
        Me.cboSponsorshipID.Size = New System.Drawing.Size(189, 21)
        Me.cboSponsorshipID.TabIndex = 129
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label15.Location = New System.Drawing.Point(153, 52)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 128
        Me.Label15.Text = "Golfer:"
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtLastName.Location = New System.Drawing.Point(231, 163)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(198, 20)
        Me.txtLastName.TabIndex = 127
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFirstName.Location = New System.Drawing.Point(231, 136)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(198, 20)
        Me.txtFirstName.TabIndex = 126
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label13.Location = New System.Drawing.Point(153, 166)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 125
        Me.Label13.Text = "Last Name"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label14.Location = New System.Drawing.Point(153, 139)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 124
        Me.Label14.Text = "First Name"
        '
        'cboGolfer
        '
        Me.cboGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboGolfer.FormattingEnabled = True
        Me.cboGolfer.Location = New System.Drawing.Point(156, 81)
        Me.cboGolfer.Name = "cboGolfer"
        Me.cboGolfer.Size = New System.Drawing.Size(189, 21)
        Me.cboGolfer.TabIndex = 123
        '
        'btnAddSponsor
        '
        Me.btnAddSponsor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSponsor.Location = New System.Drawing.Point(479, 117)
        Me.btnAddSponsor.Name = "btnAddSponsor"
        Me.btnAddSponsor.Size = New System.Drawing.Size(120, 35)
        Me.btnAddSponsor.TabIndex = 121
        Me.btnAddSponsor.Text = "Add Sponsorship"
        Me.btnAddSponsor.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(328, 692)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(125, 35)
        Me.btnClear.TabIndex = 150
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(642, 692)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(125, 35)
        Me.btnExit.TabIndex = 149
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRemoveSponsorship
        '
        Me.btnRemoveSponsorship.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveSponsorship.Location = New System.Drawing.Point(479, 193)
        Me.btnRemoveSponsorship.Name = "btnRemoveSponsorship"
        Me.btnRemoveSponsorship.Size = New System.Drawing.Size(120, 35)
        Me.btnRemoveSponsorship.TabIndex = 151
        Me.btnRemoveSponsorship.Text = "Remove Sponsorship"
        Me.btnRemoveSponsorship.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(654, 119)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 153
        Me.Label5.Text = "Sponsor:"
        '
        'cboSponsor
        '
        Me.cboSponsor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboSponsor.FormattingEnabled = True
        Me.cboSponsor.Location = New System.Drawing.Point(657, 139)
        Me.cboSponsor.Name = "cboSponsor"
        Me.cboSponsor.Size = New System.Drawing.Size(189, 21)
        Me.cboSponsor.TabIndex = 152
        '
        'frmManageSponsorships
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 755)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboSponsor)
        Me.Controls.Add(Me.btnRemoveSponsorship)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.cboPaidStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboPaymentType)
        Me.Controls.Add(Me.txtPledge)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSponsorType)
        Me.Controls.Add(Me.lvwSponsorships)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboEvent)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtSponsorLastName)
        Me.Controls.Add(Me.txtSponsorFirstName)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cboSponsorshipID)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboGolfer)
        Me.Controls.Add(Me.btnAddSponsor)
        Me.Name = "frmManageSponsorships"
        Me.Text = "frmManageSponsorships"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboPaidStatus As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboPaymentType As ComboBox
    Friend WithEvents txtPledge As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboSponsorType As ComboBox
    Friend WithEvents lvwSponsorships As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Label9 As Label
    Friend WithEvents cboEvent As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtSponsorLastName As TextBox
    Friend WithEvents txtSponsorFirstName As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents cboSponsorshipID As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cboGolfer As ComboBox
    Friend WithEvents btnAddSponsor As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnRemoveSponsorship As Button
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents Label5 As Label
    Friend WithEvents cboSponsor As ComboBox
End Class
