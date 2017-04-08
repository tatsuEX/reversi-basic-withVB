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

        DebugBoardState()

        ButtonPass.Enabled = board.enablePass()
        endGame()
    End Sub

    ' *****************************************************************
    ' ボード情報の表示
    Private Sub DebugBoardState()
        Dim state As String = "+---------------------------+" & vbCrLf
        For i As Integer = 1 To Board.BOARD_SIZE
            For j As Integer = 1 To Board.BOARD_SIZE
                state &= String.Format("|{0, 4}", rowBoard(j, i))
            Next j
            state &= "|" & vbCrLf & "+---------------------------+" & vbCrLf
        Next i
        TBState.Text = state
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
            DebugBoardState()
        End If
        ButtonPass.Enabled = board.enablePass()
        endGame()
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
    ' ゲーム結果
    Private Sub endGame()

        If board.isGameOver() Then
            Dim dr As DialogResult = DialogResult.None
            Dim winner As String = GetWinner()

            If winner = "draw" Then
                dr = MessageBox.Show("引き分けです。", "結果", MessageBoxButtons.OK)
            Else
                Dim winPlayer As String = IIf(winner = "Player1", LabelPlayer1, LabelPlayer2).Text
                dr = MessageBox.Show(winPlayer & "さんの勝ちです。", "結果", MessageBoxButtons.OK)
            End If
            If dr = DialogResult.OK Then Exit Sub
        End If
    End Sub

    ' *****************************************************************
    ' 勝者の判定
    Private Function GetWinner() As String
        Dim winner As String = ""
        If TextBoxBlack.Text = TextBoxWhite.Text Then
            winner = "draw"
        Else
            winner = IIf(CInt(TextBoxBlack.Text) > CInt(TextBoxWhite.Text), "Player1", "Player2")
        End If
        Return winner
    End Function

    Private Sub ButtonPass_Click(sender As Object, e As EventArgs) Handles ButtonPass.Click
        If Not board.pass() Then
            MessageBox.Show("パスできません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            board.SetMovablePos()
            rowBoard = board.GetRowBoard
            gu.RewriteBoard(rowBoard)
            crtPly.ShowCurrentPlayer(board.getCurrentColor())
            ShowCount()
            DebugBoardState()
        End If
    End Sub

    Private Sub ButtonUndo_Click(sender As Object, e As EventArgs) Handles ButtonUndo.Click
        If Not board.undo() Then
            MessageBox.Show("一手戻れません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            board.SetMovablePos()
            rowBoard = board.GetRowBoard
            gu.RewriteBoard(rowBoard)
            crtPly.ShowCurrentPlayer(board.getCurrentColor())
            ShowCount()
            DebugBoardState()
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
            DebugBoardState()
        End If
    End Sub

    Private Sub MenuQuit_Click(sender As Object, e As EventArgs) Handles MenuQuit.Click, Me.FormClosed
        Me.Dispose()
        Environment.Exit(0)
    End Sub
End Class
