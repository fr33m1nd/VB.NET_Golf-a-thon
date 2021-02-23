<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageGolferEvents
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
        Me.components = New System.ComponentModel.Container()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDropGolfer = New System.Windows.Forms.Button()
        Me.btnAddGolfer = New System.Windows.Forms.Button()
        Me.lstAvailable = New System.Windows.Forms.ListBox()
        Me.lstInEvent = New System.Windows.Forms.ListBox()
        Me.cboEvent = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(296, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Available Golfers:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Event Golfers:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Event:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(205, 324)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(66, 32)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Exit"
        Me.ToolTip1.SetToolTip(Me.btnExit, "Exit Manage Golfer Events")
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDropGolfer
        '
        Me.btnDropGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.btnDropGolfer.Location = New System.Drawing.Point(215, 237)
        Me.btnDropGolfer.Name = "btnDropGolfer"
        Me.btnDropGolfer.Size = New System.Drawing.Size(46, 38)
        Me.btnDropGolfer.TabIndex = 14
        Me.btnDropGolfer.Text = "→"
        Me.ToolTip1.SetToolTip(Me.btnDropGolfer, "Drop Golfer from Event")
        Me.btnDropGolfer.UseVisualStyleBackColor = True
        '
        'btnAddGolfer
        '
        Me.btnAddGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddGolfer.Location = New System.Drawing.Point(215, 156)
        Me.btnAddGolfer.Name = "btnAddGolfer"
        Me.btnAddGolfer.Size = New System.Drawing.Size(46, 35)
        Me.btnAddGolfer.TabIndex = 13
        Me.btnAddGolfer.Text = "←"
        Me.btnAddGolfer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.btnAddGolfer, "Add Golfer to Event")
        Me.btnAddGolfer.UseVisualStyleBackColor = True
        '
        'lstAvailable
        '
        Me.lstAvailable.FormattingEnabled = True
        Me.lstAvailable.Location = New System.Drawing.Point(299, 123)
        Me.lstAvailable.Name = "lstAvailable"
        Me.lstAvailable.Size = New System.Drawing.Size(160, 199)
        Me.lstAvailable.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.lstAvailable, "Select a Golfer")
        '
        'lstInEvent
        '
        Me.lstInEvent.FormattingEnabled = True
        Me.lstInEvent.Location = New System.Drawing.Point(19, 123)
        Me.lstInEvent.Name = "lstInEvent"
        Me.lstInEvent.Size = New System.Drawing.Size(160, 199)
        Me.lstInEvent.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.lstInEvent, "Select a Golfer")
        '
        'cboEvent
        '
        Me.cboEvent.FormattingEnabled = True
        Me.cboEvent.Location = New System.Drawing.Point(19, 48)
        Me.cboEvent.Name = "cboEvent"
        Me.cboEvent.Size = New System.Drawing.Size(106, 21)
        Me.cboEvent.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.cboEvent, "Select an Event")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(210, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Add Golfer"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(202, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Remove Golfer"
        '
        'frmManageGolferEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 388)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDropGolfer)
        Me.Controls.Add(Me.btnAddGolfer)
        Me.Controls.Add(Me.lstAvailable)
        Me.Controls.Add(Me.lstInEvent)
        Me.Controls.Add(Me.cboEvent)
        Me.Name = "frmManageGolferEvents"
        Me.Text = "Manage Golfer Events"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnDropGolfer As Button
    Friend WithEvents btnAddGolfer As Button
    Friend WithEvents lstAvailable As ListBox
    Friend WithEvents lstInEvent As ListBox
    Friend WithEvents cboEvent As ComboBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
