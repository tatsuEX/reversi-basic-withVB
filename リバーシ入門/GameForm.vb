Public Class GameForm
    Private board As Board
    Private rowBoard As Integer(,)

    Private gu As GraphicUtility

    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        board = New Board()
        rowBoard = board.GetRowBoard




    End Sub
End Class
