<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.CheckBox120FPS = New System.Windows.Forms.CheckBox()
        Me.CheckBox60FPS = New System.Windows.Forms.CheckBox()
        Me.CheckBox30FPS = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Res480p = New System.Windows.Forms.CheckBox()
        Me.Res1080p = New System.Windows.Forms.CheckBox()
        Me.Res720p = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CheckBox120FPS
        '
        Me.CheckBox120FPS.AutoSize = True
        Me.CheckBox120FPS.Location = New System.Drawing.Point(271, 37)
        Me.CheckBox120FPS.Name = "CheckBox120FPS"
        Me.CheckBox120FPS.Size = New System.Drawing.Size(67, 17)
        Me.CheckBox120FPS.TabIndex = 7
        Me.CheckBox120FPS.Text = "120 FPS"
        Me.CheckBox120FPS.UseVisualStyleBackColor = True
        '
        'CheckBox60FPS
        '
        Me.CheckBox60FPS.AutoSize = True
        Me.CheckBox60FPS.Checked = True
        Me.CheckBox60FPS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox60FPS.Location = New System.Drawing.Point(204, 37)
        Me.CheckBox60FPS.Name = "CheckBox60FPS"
        Me.CheckBox60FPS.Size = New System.Drawing.Size(61, 17)
        Me.CheckBox60FPS.TabIndex = 6
        Me.CheckBox60FPS.Text = "60 FPS"
        Me.CheckBox60FPS.UseVisualStyleBackColor = True
        '
        'CheckBox30FPS
        '
        Me.CheckBox30FPS.AutoSize = True
        Me.CheckBox30FPS.Location = New System.Drawing.Point(137, 37)
        Me.CheckBox30FPS.Name = "CheckBox30FPS"
        Me.CheckBox30FPS.Size = New System.Drawing.Size(61, 17)
        Me.CheckBox30FPS.TabIndex = 5
        Me.CheckBox30FPS.Text = "30 FPS"
        Me.CheckBox30FPS.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(35, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Res480p
        '
        Me.Res480p.AutoSize = True
        Me.Res480p.Location = New System.Drawing.Point(137, 60)
        Me.Res480p.Name = "Res480p"
        Me.Res480p.Size = New System.Drawing.Size(69, 17)
        Me.Res480p.TabIndex = 10
        Me.Res480p.Text = "Res480p"
        Me.Res480p.UseVisualStyleBackColor = True
        '
        'Res1080p
        '
        Me.Res1080p.AutoSize = True
        Me.Res1080p.Checked = True
        Me.Res1080p.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Res1080p.Location = New System.Drawing.Point(271, 60)
        Me.Res1080p.Name = "Res1080p"
        Me.Res1080p.Size = New System.Drawing.Size(75, 17)
        Me.Res1080p.TabIndex = 9
        Me.Res1080p.Text = "Res1080p"
        Me.Res1080p.UseVisualStyleBackColor = True
        '
        'Res720p
        '
        Me.Res720p.AutoSize = True
        Me.Res720p.Location = New System.Drawing.Point(204, 60)
        Me.Res720p.Name = "Res720p"
        Me.Res720p.Size = New System.Drawing.Size(69, 17)
        Me.Res720p.TabIndex = 8
        Me.Res720p.Text = "Res720p"
        Me.Res720p.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Res480p)
        Me.Controls.Add(Me.Res1080p)
        Me.Controls.Add(Me.Res720p)
        Me.Controls.Add(Me.CheckBox120FPS)
        Me.Controls.Add(Me.CheckBox60FPS)
        Me.Controls.Add(Me.CheckBox30FPS)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBox120FPS As CheckBox
    Friend WithEvents CheckBox60FPS As CheckBox
    Friend WithEvents CheckBox30FPS As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Res480p As CheckBox
    Friend WithEvents Res1080p As CheckBox
    Friend WithEvents Res720p As CheckBox
End Class
