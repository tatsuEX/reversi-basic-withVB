Public Class GameForm
    Private board As Board
    Private rowBoard As Integer(,)
    Private currentPos As System.Windows.Point

    Private gu As GraphicUtility
    Private crtPly As GraphicUtility

    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        board = New Board()
        board.SetMovablePos()
        rowBoard = board.GetRowBoard

        With PBBoard
            .BackColor = Color.White
            .BorderStyle = BorderStyle.None
            .Width = 403
            .Height = 403
            gu = New GraphicUtility(PBBoard, rowBoard, 0, .Width, 0, .Height)
        End With

        With PBCurrentPlayer
            .BorderStyle = BorderStyle.Fixed3D
            crtPly = New GraphicUtility(PBCurrentPlayer, rowBoard, 0, .Width, 0, .Height)
        End With

        crtPly.ShowCurrentPlayer(board.getCurrentColor())

        ShowCount()
        Game()
    End Sub

    ' *****************************************************************
    ' クリック座標からボード位置を取得
    Private Sub PBBoard_MouseClick(sender As Object, e As MouseEventArgs) Handles PBBoard.MouseClick
        currentPos = gu.ConvertClickToBoardPos(e.X, e.Y)
        If board.move(currentPos) Then
            board.SetMovablePos()
            rowBoard = board.GetRowBoard
            gu.RewriteBoard(rowBoard)
            crtPly.ShowCurrentPlayer(board.getCurrentColor())
            ShowCount()
        End If
    End Sub

    Private Sub ShowCount()
        TextBoxBlack.Text = board.countDisc(Disc.SquareState.BLACK)
        TextBoxWhite.Text = board.countDisc(Disc.SquareState.WHITE)
        If board.getCurrentColor = Disc.SquareState.BLACK Then
            TextBoxBlack.BackColor = Color.White
            TextBoxWhite.BackColor = Color.Gray
        Else
            TextBoxBlack.BackColor = Color.Gray
            TextBoxWhite.BackColor = Color.White
        End If
    End Sub

    ' *****************************************************************
    ' ゲーム本体
    Private Sub Game()

        If board.isGameOver() Then
            Exit Sub
        End If
    End Sub

    Private Sub MenuNewGame_Click(sender As Object, e As EventArgs) Handles MenuNewGame.Click
        Dim dr As DialogResult
        If Not board.isGameOver() Then
            dr = MessageBox.Show("中断して新しいゲームを始めますか？", "確認", MessageBoxButtons.YesNo)
        End If
        If dr = DialogResult.Yes Then
            board.init()
            board.SetMovablePos()
            rowBoard = board.GetRowBoard()
            gu.RewriteBoard(rowBoard)
            ShowCount()
        End If
    End Sub

    Private Sub MenuQuit_Click(sender As Object, e As EventArgs) Handles MenuQuit.Click, Me.FormClosed
        Me.Dispose()
        Environment.Exit(0)
    End Sub
End Class
