<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPledgeTotals
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
        Me.Label32 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cboEvent = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboSponsor = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboGolfer = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblPledgeGolfer = New System.Windows.Forms.Label()
        Me.lblPledgeEvent = New System.Windows.Forms.Label()
        Me.lblPledgeSponsor = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(151, 208)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(161, 13)
        Me.Label32.TabIndex = 119
        Me.Label32.Text = "Total Amount Pledged for Event:"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(194, 258)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(66, 32)
        Me.btnClear.TabIndex = 117
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(151, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(161, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Total Amount Pledged for Golfer:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(151, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 13)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "Total Amount Sponsor Pledged:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(356, 258)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(66, 32)
        Me.btnExit.TabIndex = 112
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cboEvent
        '
        Me.cboEvent.FormattingEnabled = True
        Me.cboEvent.Location = New System.Drawing.Point(253, 47)
        Me.cboEvent.Name = "cboEvent"
        Me.cboEvent.Size = New System.Drawing.Size(106, 21)
        Me.cboEvent.TabIndex = 165
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label24.Location = New System.Drawing.Point(396, 49)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 13)
        Me.Label24.TabIndex = 162
        Me.Label24.Text = "Sponsor:"
        '
        'cboSponsor
        '
        Me.cboSponsor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboSponsor.FormattingEnabled = True
        Me.cboSponsor.Location = New System.Drawing.Point(399, 78)
        Me.cboSponsor.Name = "cboSponsor"
        Me.cboSponsor.Size = New System.Drawing.Size(189, 21)
        Me.cboSponsor.TabIndex = 157
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label15.Location = New System.Drawing.Point(30, 49)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 156
        Me.Label15.Text = "Golfer:"
        '
        'cboGolfer
        '
        Me.cboGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboGolfer.FormattingEnabled = True
        Me.cboGolfer.Location = New System.Drawing.Point(33, 78)
        Me.cboGolfer.Name = "cboGolfer"
        Me.cboGolfer.Size = New System.Drawing.Size(189, 21)
        Me.cboGolfer.TabIndex = 151
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(281, 21)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 174
        Me.Label7.Text = "Event:"
        '
        'lblPledgeGolfer
        '
        Me.lblPledgeGolfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPledgeGolfer.Location = New System.Drawing.Point(315, 168)
        Me.lblPledgeGolfer.Name = "lblPledgeGolfer"
        Me.lblPledgeGolfer.Size = New System.Drawing.Size(130, 20)
        Me.lblPledgeGolfer.TabIndex = 178
        '
        'lblPledgeEvent
        '
        Me.lblPledgeEvent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPledgeEvent.Location = New System.Drawing.Point(315, 203)
        Me.lblPledgeEvent.Name = "lblPledgeEvent"
        Me.lblPledgeEvent.Size = New System.Drawing.Size(130, 20)
        Me.lblPledgeEvent.TabIndex = 179
        '
        'lblPledgeSponsor
        '
        Me.lblPledgeSponsor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPledgeSponsor.Location = New System.Drawing.Point(315, 134)
        Me.lblPledgeSponsor.Name = "lblPledgeSponsor"
        Me.lblPledgeSponsor.Size = New System.Drawing.Size(130, 20)
        Me.lblPledgeSponsor.TabIndex = 180
        '
        'frmPledgeTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 302)
        Me.Controls.Add(Me.lblPledgeSponsor)
        Me.Controls.Add(Me.lblPledgeEvent)
        Me.Controls.Add(Me.lblPledgeGolfer)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboEvent)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.cboSponsor)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboGolfer)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmPledgeTotals"
        Me.Text = "frmPledgeTotals"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label32 As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents cboEvent As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents cboSponsor As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cboGolfer As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblPledgeGolfer As Label
    Friend WithEvents lblPledgeEvent As Label
    Friend WithEvents lblPledgeSponsor As Label
End Class
