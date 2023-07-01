Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedFPS As Integer
        Dim selectedformWidth As Integer
        Dim selectedformHeight As Integer


        If Res480p.Checked Then
            selectedformWidth = 640
            selectedformHeight = 480
        ElseIf Res720p.Checked Then
            selectedformWidth = 1280
            selectedformHeight = 720
        ElseIf Res1080p.Checked Then
            selectedformWidth = 1920
            selectedformHeight = 1080
        End If

        If CheckBox30FPS.Checked Then
            selectedFPS = 30
        ElseIf CheckBox60FPS.Checked Then
            selectedFPS = 60
        ElseIf CheckBox120FPS.Checked Then
            selectedFPS = 120
        End If

        Dim ballForm As New BouncingBallForm(selectedFPS, selectedformWidth, selectedformHeight)
        ballForm.Show()
    End Sub

    Private Sub CheckBox60FPS_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox60FPS.CheckedChanged
        CheckBox30FPS.Checked = False
        CheckBox120FPS.Checked = False

    End Sub

    Private Sub CheckBox30FPS_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox30FPS.CheckedChanged
        CheckBox60FPS.Checked = False
        CheckBox120FPS.Checked = False

    End Sub

    Private Sub CheckBox120FPS_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox120FPS.CheckedChanged
        CheckBox30FPS.Checked = False
        CheckBox60FPS.Checked = False

    End Sub

    Private Sub Res1080p_CheckedChanged(sender As Object, e As EventArgs) Handles Res1080p.CheckedChanged
        Res480p.Checked = False
        Res720p.Checked = False



    End Sub

    Private Sub Res720p_CheckedChanged(sender As Object, e As EventArgs) Handles Res720p.CheckedChanged
        Res480p.Checked = False
        Res1080p.Checked = False


    End Sub

    Private Sub Res480p_CheckedChanged(sender As Object, e As EventArgs) Handles Res480p.CheckedChanged
        Res720p.Checked = False
        Res1080p.Checked = False

    End Sub
End Class

Public Class BouncingBallForm
    Inherits Form
    Private ballAlive As Boolean = True ' Flag to indicate if the ball is alive
    Private collisionOccurred As Boolean = False ' Flag to track if collision has already occurred


    Private ballPosition As New Point(0, 0) ' Initialize ball position to (0, 0)
    Private ballVelocity As New Point(0, 0) ' Initialize ball velocity to (0, 0)
    Private ballRadius As Integer = 20
    Private timer As Timer
    Private fps As Integer
    Private speed As Integer = 5
    Private sunRadius As Integer = 50
    Private sunPosition As Point
    Private sunColor As Color = Color.Yellow
    Private shadowColor As Color = Color.FromArgb(100, Color.Gray) ' Shadow color
    Private shadowOpacityFactor As Single = 0.5 ' Shadow opacity factor
    Private shadowSizeFactor As Single = 0.8 ' Shadow size factor
    Private momentum As Size ' Stores the last velocity
    Private gameOver As Boolean = False

    Public Sub New(selectedFPS As Integer, formWidth As Integer, formHeight As Integer)

        Me.DoubleBuffered = True
        Me.ClientSize = New Size(formWidth, formHeight)
        Me.StartPosition = FormStartPosition.CenterScreen

        fps = selectedFPS
        Dim interval As Integer = CInt(1000 / fps)
        timer = New Timer()
        timer.Interval = interval
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim graphics As Graphics = e.Graphics
        graphics.Clear(Color.White)

        ' Update the sun position to be in the center of the form
        sunPosition = New Point(ClientSize.Width / 2, ClientSize.Height / 2)

        ' Draw the sun
        Dim sunBrush As New SolidBrush(sunColor)
        Dim sunRect As New Rectangle(sunPosition.X - sunRadius, sunPosition.Y - sunRadius, sunRadius * 2, sunRadius * 2)
        graphics.FillEllipse(sunBrush, sunRect)

        ' Calculate the angle between the ball and the sun
        Dim angle As Single = CSng(Math.Atan2(ballPosition.Y - sunPosition.Y, ballPosition.X - sunPosition.X))

        ' Update the shadow color based on the angle
        If angle >= 0 AndAlso angle <= Math.PI Then
            shadowColor = Color.FromArgb(100, Color.Gray) ' Shadow color when ball is on the left side of the sun
        Else
            shadowColor = Color.FromArgb(50, Color.Gray) ' Shadow color when ball is on the right side of the sun
        End If

        ' Calculate the distance between the ball and the sun
        Dim distance As Single = Math.Sqrt((ballPosition.X - sunPosition.X) ^ 2 + (ballPosition.Y - sunPosition.Y) ^ 2)

        ' Calculate the shadow position and size based on the ball's position relative to the sun
        Dim shadowOffsetX As Integer = CInt(Math.Cos(angle) * distance)
        Dim shadowOffsetY As Integer = CInt(Math.Sin(angle) * distance)
        Dim shadowRect As New Rectangle(ballPosition.X + shadowOffsetX - ballRadius, ballPosition.Y + shadowOffsetY - ballRadius, ballRadius * 2, ballRadius * 2)

        ' Create a GraphicsPath to define the shape of the shadow
        Dim shadowPath As New GraphicsPath()
        shadowPath.AddEllipse(shadowRect)

        ' Create a PathGradientBrush using the shadowPath to fill the shadow area
        Dim pathBrush As New PathGradientBrush(shadowPath)
        pathBrush.CenterColor = shadowColor
        pathBrush.SurroundColors = {Color.Transparent}

        ' Fill the shadow area with the pathBrush
        graphics.FillPath(pathBrush, shadowPath)

        ' Draw the ball
        Dim ballBrush As New SolidBrush(Color.Red)
        Dim ballRect As New Rectangle(ballPosition.X - ballRadius, ballPosition.Y - ballRadius, ballRadius * 2, ballRadius * 2)
        graphics.FillEllipse(ballBrush, ballRect)
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        Select Case e.KeyCode
            Case Keys.W
                momentum = New Size(momentum.Width, -speed)
            Case Keys.A
                momentum = New Size(-speed, momentum.Height)
            Case Keys.S
                momentum = New Size(momentum.Width, speed)
            Case Keys.D
                momentum = New Size(speed, momentum.Height)
        End Select

        Invalidate() ' Redraw the form to update the ball's position
    End Sub

    Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
        MyBase.OnKeyUp(e)

        ' Reset the ball's velocity to the stored momentum
        ballVelocity = momentum
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        ' Update the ball's position based on the velocity if it is alive
        If ballAlive Then
            ballPosition.X += ballVelocity.X
            ballPosition.Y += ballVelocity.Y
        End If

        ' Check for collision with the form boundaries
        If ballPosition.X < ballRadius Then
            ballPosition.X = ballRadius
            ballVelocity.X *= -1 ' Reverse the horizontal direction
        ElseIf ballPosition.X > ClientSize.Width - ballRadius Then
            ballPosition.X = ClientSize.Width - ballRadius
            ballVelocity.X *= -1 ' Reverse the horizontal direction
        End If

        If ballPosition.Y < ballRadius Then
            ballPosition.Y = ballRadius
            ballVelocity.Y *= -1 ' Reverse the vertical direction
        ElseIf ballPosition.Y > ClientSize.Height - ballRadius Then
            ballPosition.Y = ClientSize.Height - ballRadius
            ballVelocity.Y *= -1 ' Reverse the vertical direction
        End If

        ' Check for collision with the sun
        Dim distance As Double = Math.Sqrt((ballPosition.X - sunPosition.X) ^ 2 + (ballPosition.Y - sunPosition.Y) ^ 2)
        If distance <= ballRadius + sunRadius AndAlso Not collisionOccurred Then
            ' Ball touches the sun, stop its movement
            ballAlive = False
            collisionOccurred = True ' Set the collision flag to prevent multiple pop-ups
            ' Show message box
            MessageBox.Show("You died!")
            ' Reset the ball position
            ballPosition = New Point(ClientSize.Width / 2, ClientSize.Height / 2)
            ' Restart the timer after a delay
            TimerRestart()
            Me.Close()
        End If

        Invalidate() ' Redraw the form to update the ball's position
    End Sub

    Private Sub TimerRestart()
        timer.Stop() ' Stop the timer
        collisionOccurred = False ' Reset the collision flag
        ballAlive = True ' Set the ball to alive again

    End Sub



End Class