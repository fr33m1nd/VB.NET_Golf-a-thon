<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnManageEvents = New System.Windows.Forms.Button()
        Me.btnManageGolfers = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnManageGolferEvents = New System.Windows.Forms.Button()
        Me.btnManageSponsors = New System.Windows.Forms.Button()
        Me.btnManageSponsorships = New System.Windows.Forms.Button()
        Me.btnPledgeTotals = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Imprint MT Shadow", 39.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(182, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(293, 62)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Golf-a-thon"
        '
        'btnManageEvents
        '
        Me.btnManageEvents.AutoSize = True
        Me.btnManageEvents.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnManageEvents.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManageEvents.Font = New System.Drawing.Font("Imprint MT Shadow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageEvents.Location = New System.Drawing.Point(391, 398)
        Me.btnManageEvents.Name = "btnManageEvents"
        Me.btnManageEvents.Size = New System.Drawing.Size(169, 32)
        Me.btnManageEvents.TabIndex = 2
        Me.btnManageEvents.Text = "Manage Events"
        Me.ToolTip1.SetToolTip(Me.btnManageEvents, "Select Manage Events")
        Me.btnManageEvents.UseVisualStyleBackColor = False
        '
        'btnManageGolfers
        '
        Me.btnManageGolfers.AutoSize = True
        Me.btnManageGolfers.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnManageGolfers.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManageGolfers.Font = New System.Drawing.Font("Imprint MT Shadow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageGolfers.Location = New System.Drawing.Point(391, 436)
        Me.btnManageGolfers.Name = "btnManageGolfers"
        Me.btnManageGolfers.Size = New System.Drawing.Size(169, 32)
        Me.btnManageGolfers.TabIndex = 3
        Me.btnManageGolfers.Text = "Manage Golfers"
        Me.ToolTip1.SetToolTip(Me.btnManageGolfers, "Select Manage Golfers")
        Me.btnManageGolfers.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 7000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'btnExit
        '
        Me.btnExit.AutoSize = True
        Me.btnExit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Imprint MT Shadow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(391, 626)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(169, 32)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.ToolTip1.SetToolTip(Me.btnExit, "Exit Program")
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnManageGolferEvents
        '
        Me.btnManageGolferEvents.AutoSize = True
        Me.btnManageGolferEvents.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnManageGolferEvents.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManageGolferEvents.Font = New System.Drawing.Font("Imprint MT Shadow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageGolferEvents.Location = New System.Drawing.Point(391, 474)
        Me.btnManageGolferEvents.Name = "btnManageGolferEvents"
        Me.btnManageGolferEvents.Size = New System.Drawing.Size(169, 32)
        Me.btnManageGolferEvents.TabIndex = 5
        Me.btnManageGolferEvents.Text = "Manage Golfer Events"
        Me.ToolTip1.SetToolTip(Me.btnManageGolferEvents, "Select Manage Golfer Events")
        Me.btnManageGolferEvents.UseVisualStyleBackColor = False
        '
        'btnManageSponsors
        '
        Me.btnManageSponsors.AutoSize = True
        Me.btnManageSponsors.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnManageSponsors.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManageSponsors.Font = New System.Drawing.Font("Imprint MT Shadow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageSponsors.Location = New System.Drawing.Point(391, 512)
        Me.btnManageSponsors.Name = "btnManageSponsors"
        Me.btnManageSponsors.Size = New System.Drawing.Size(169, 32)
        Me.btnManageSponsors.TabIndex = 6
        Me.btnManageSponsors.Text = "Manage Sponsors"
        Me.ToolTip1.SetToolTip(Me.btnManageSponsors, "Select Manage Sponsors")
        Me.btnManageSponsors.UseVisualStyleBackColor = False
        '
        'btnManageSponsorships
        '
        Me.btnManageSponsorships.AutoSize = True
        Me.btnManageSponsorships.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnManageSponsorships.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManageSponsorships.Font = New System.Drawing.Font("Imprint MT Shadow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageSponsorships.Location = New System.Drawing.Point(391, 550)
        Me.btnManageSponsorships.Name = "btnManageSponsorships"
        Me.btnManageSponsorships.Size = New System.Drawing.Size(169, 32)
        Me.btnManageSponsorships.TabIndex = 7
        Me.btnManageSponsorships.Text = "Manage Sponsorships"
        Me.ToolTip1.SetToolTip(Me.btnManageSponsorships, "Select Manage Sponsorships")
        Me.btnManageSponsorships.UseVisualStyleBackColor = False
        '
        'btnPledgeTotals
        '
        Me.btnPledgeTotals.AutoSize = True
        Me.btnPledgeTotals.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnPledgeTotals.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPledgeTotals.Font = New System.Drawing.Font("Imprint MT Shadow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPledgeTotals.Location = New System.Drawing.Point(391, 588)
        Me.btnPledgeTotals.Name = "btnPledgeTotals"
        Me.btnPledgeTotals.Size = New System.Drawing.Size(169, 32)
        Me.btnPledgeTotals.TabIndex = 8
        Me.btnPledgeTotals.Text = "Pledge Totals"
        Me.ToolTip1.SetToolTip(Me.btnPledgeTotals, "Select Pledge Totals")
        Me.btnPledgeTotals.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(572, 693)
        Me.Controls.Add(Me.btnPledgeTotals)
        Me.Controls.Add(Me.btnManageSponsorships)
        Me.Controls.Add(Me.btnManageSponsors)
        Me.Controls.Add(Me.btnManageGolferEvents)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnManageGolfers)
        Me.Controls.Add(Me.btnManageEvents)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Main Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnManageEvents As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents btnManageGolfers As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnManageGolferEvents As Button
    Friend WithEvents btnManageSponsors As Button
    Friend WithEvents btnManageSponsorships As Button
    Friend WithEvents btnPledgeTotals As Button
End Class
