Imports System.Diagnostics
Imports System.Windows.Forms

Public Class FormCreateSubmission
    Private stopwatch As Stopwatch
    Private timer As Timer

    Private Sub FormCreateSubmission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stopwatch = New Stopwatch()
        timer = New Timer()
        AddHandler timer.Tick, AddressOf TimerTick
        timer.Interval = 1000 ' Update every second
    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs)
        lblStopwatch.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            timer.Stop()
        Else
            stopwatch.Start()
            timer.Start()
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Implement the logic to submit the form data to the backend
        ' For now, let's assume the submission is successful
        Dim submission = New Submission(txtName.Text, txtEmail.Text, txtPhone.Text, txtGithub.Text, lblStopwatch.Text)
        ' Send submission to backend (implement backend call)
        MessageBox.Show("Submission successful!")
        Me.Close()
    End Sub

    Private Sub FormCreateSubmission_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            btnToggleStopwatch.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit.PerformClick()
        End If
    End Sub
End Class
