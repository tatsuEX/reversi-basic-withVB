Public Class GameForm
    Private board As Board
    Private rowBoard As Integer(,)
    Private currentPos As System.Windows.Point

    Private gu As GraphicUtility

    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        board = New Board()
        rowBoard = board.GetRowBoard

        With PBBoard
            .BackColor = Color.White
            .BorderStyle = BorderStyle.None
            .Width = 403
            .Height = 403
            gu = New GraphicUtility(PBBoard, rowBoard, 0, .Width, 0, .Height)
        End With

    End Sub

    ' *****************************************************************
    ' クリック座標からボード位置を取得
    Private Sub PBBoard_MouseClick(sender As Object, e As MouseEventArgs) Handles PBBoard.MouseClick
        currentPos = gu.ConvertClickToBoardPos(e.X, e.Y)
    End Sub

    ' *****************************************************************
    ' ゲーム本体
    Private Sub Game()

    End Sub

    Private Sub MenuQuit_Click(sender As Object, e As EventArgs) Handles MenuQuit.Click, Me.FormClosed
        Me.Dispose()
        Environment.Exit(0)
    End Sub
End Class
