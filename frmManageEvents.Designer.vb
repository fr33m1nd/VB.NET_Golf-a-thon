<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageEvents
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageEvents))
        Me.cboYears = New System.Windows.Forms.ComboBox()
        Me.btnAddEvent = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDeleteEvent = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'cboYears
        '
        Me.cboYears.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboYears.FormattingEnabled = True
        Me.cboYears.Location = New System.Drawing.Point(67, 33)
        Me.cboYears.Name = "cboYears"
        Me.cboYears.Size = New System.Drawing.Size(248, 24)
        Me.cboYears.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cboYears, "Choose Event Year")
        '
        'btnAddEvent
        '
        Me.btnAddEvent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddEvent.Location = New System.Drawing.Point(67, 78)
        Me.btnAddEvent.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddEvent.Name = "btnAddEvent"
        Me.btnAddEvent.Size = New System.Drawing.Size(79, 45)
        Me.btnAddEvent.TabIndex = 41
        Me.btnAddEvent.Text = "Add New Event"
        Me.ToolTip1.SetToolTip(Me.btnAddEvent, "Add New Event Year")
        Me.btnAddEvent.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(229, 146)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(95, 23)
        Me.btnExit.TabIndex = 44
        Me.btnExit.Text = "Exit"
        Me.ToolTip1.SetToolTip(Me.btnExit, "Exit Form")
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(51, 146)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(95, 23)
        Me.btnClear.TabIndex = 47
        Me.btnClear.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.btnClear, "Clear Form")
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDeleteEvent
        '
        Me.btnDeleteEvent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteEvent.Location = New System.Drawing.Point(229, 78)
        Me.btnDeleteEvent.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDeleteEvent.Name = "btnDeleteEvent"
        Me.btnDeleteEvent.Size = New System.Drawing.Size(79, 45)
        Me.btnDeleteEvent.TabIndex = 48
        Me.btnDeleteEvent.Text = "Delete " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Event"
        Me.ToolTip1.SetToolTip(Me.btnDeleteEvent, "Delete Event Year")
        Me.btnDeleteEvent.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 7000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'frmManageEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 197)
        Me.Controls.Add(Me.btnDeleteEvent)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAddEvent)
        Me.Controls.Add(Me.cboYears)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmManageEvents"
        Me.Text = "Manage Events Form"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboYears As ComboBox
    Friend WithEvents btnAddEvent As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDeleteEvent As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
