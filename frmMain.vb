'*************************************************************************
' Abstract: This is the main form a user will see when using the program
' it provides these paths: 
'                              1) Manage Events 
'                              2) Manage Golfers
'                              3) Manage Golfer Events
'                              4) Manage Sponsors
'                              5) Manage Sponsorships
'                              6) Pledge Totals 
'                              7) Exit program
'
'Author: Derrick Warren
'*************************************************************************

Option Strict On

Public Class frmMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' exit program
        Close()

    End Sub

    Private Sub btnManageEvents_Click(sender As Object, e As EventArgs) Handles btnManageEvents.Click

        ' access manage events form
        Dim Events As New frmManageEvents

        Events.ShowDialog()

    End Sub

    Private Sub btnManageGolfers_Click(sender As Object, e As EventArgs) Handles btnManageGolfers.Click

        ' access manage golfers form
        Dim Golfers As New frmManageGolfers

        Golfers.ShowDialog()

    End Sub

    Private Sub btnManageGolferEvents_Click(sender As Object, e As EventArgs) Handles btnManageGolferEvents.Click

        ' access manage golfer's events form
        Dim GolferEvents As New frmManageGolferEvents

        GolferEvents.ShowDialog()

    End Sub

    Private Sub btnManageSponsors_Click(sender As Object, e As EventArgs) Handles btnManageSponsors.Click

        ' access manage sponsors form
        Dim Sponsors As New frmManageSponsors

        Sponsors.ShowDialog()

    End Sub

    Private Sub btnManageSponsorships_Click(sender As Object, e As EventArgs) Handles btnManageSponsorships.Click

        ' access manage sponsorships form
        Dim Sponsorships As New frmManageSponsorships

        Sponsorships.ShowDialog()

    End Sub

    Private Sub btnPledgeTotals_Click(sender As Object, e As EventArgs) Handles btnPledgeTotals.Click

        ' access pledge totals form
        Dim PledgeTotals As New frmPledgeTotals

        PledgeTotals.ShowDialog()

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
