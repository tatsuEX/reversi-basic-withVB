Imports System.Windows

' *****************************************************************
' ボードを表すクラス
' *****************************************************************
Public Class Board
    Public Const BOARD_SIZE As Integer = 8
    Public Const MAX_TURNS As Integer = 60

    Public Enum Direction
        NONE = 0
        UPPER = 1
        UPPER_RIGHT = 2
        RIGHT = 4
        LOWER_RIGHT = 8
        LOWER = 16
        LOWER_LEFT = 32
        LEFT = 64
        UPPER_LEFT = 128
    End Enum

    ' 配列は要素数に注意！ なお、宣言時に 0 で初期化される模様
    Private RowBoard(,) As Integer = New Integer(BOARD_SIZE + 1, BOARD_SIZE + 1) {}
    Private turns As Integer
    Private currentColor As Integer

    Private updateLog As New ArrayList()

    Private MovableDir(,,) As Integer = New Integer(MAX_TURNS, BOARD_SIZE + 1, BOARD_SIZE + 1) {}
    Private MovablePos() As ArrayList = New ArrayList(MAX_TURNS) {}

    Private discs As New ColorStroage(Of Integer)

    ' *****************************************************************
    ' ボードの初期化
    Public Sub init()
        ' RowBoard は宣言とともに 0 で初期化
        RowBoard = New Integer(BOARD_SIZE + 1, BOARD_SIZE + 1) {}

        Dim MaxRow As Integer = RowBoard.GetUpperBound(0)
        ' 壁の初期配置
        For i As Integer = 0 To MaxRow
            RowBoard(0, i) = Disc.SquareState.WALL
            RowBoard(i, 0) = Disc.SquareState.WALL
            RowBoard(MaxRow, i) = Disc.SquareState.WALL
            RowBoard(i, MaxRow) = Disc.SquareState.WALL
        Next i

        ' 石の初期配置
        RowBoard(4, 4) = Disc.SquareState.WHITE
        RowBoard(5, 5) = Disc.SquareState.WHITE
        RowBoard(4, 5) = Disc.SquareState.BLACK
        RowBoard(5, 4) = Disc.SquareState.BLACK

        ' 石数の初期設定
        discs.Data(Disc.SquareState.WHITE) = 2
        discs.Data(Disc.SquareState.BLACK) = 2
        discs.Data(Disc.SquareState.EMPTY) = BOARD_SIZE * BOARD_SIZE - 4

        ' ターン数と先手のプレイヤー
        turns = 0
        currentColor = Disc.SquareState.BLACK

        ' update をすべて消去
        updateLog.Clear()

        initMovable()
    End Sub

    ' *****************************************************************
    ' コンストラクタ
    Public Sub New()
        For i As Integer = 0 To MAX_TURNS
            MovablePos(i) = New ArrayList()
        Next i
        init()
    End Sub

#Region "Methods"
    ' *****************************************************************
    ' 各種メソッド
    ' *****************************************************************

    ' GET -------------------------------------------------------------
    Public Function GetRowBoard() As Integer(,)
        Return RowBoard
    End Function

    ' *****************************************************************
    ' 指定した色の石の数を数える
    Public Function countDisc(col As Integer) As Integer
        Return discs.Data(col)
    End Function

    ' *****************************************************************
    ' 指定された位置の色
    Public Function getColor(p As Point) As Integer
        Return RowBoard(p.X, p.Y)
    End Function

    Public Function getColor(x As Integer, y As Integer) As Integer
        Return RowBoard(x, y)
    End Function

    ' *****************************************************************
    ' 石を打てる座標のリストを得る
    Public Function getMovablePos() As ArrayList
        Return MovablePos(turns)
    End Function

    ' *****************************************************************
    ' 直前の手で打った石と裏返した石の履歴
    Public Function getUpdate() As ArrayList
        If updateLog Is Nothing Then
            Return New ArrayList
        Else
            Return updateLog.Item(updateLog.Count - 1)
        End If
    End Function

    ' *****************************************************************
    ' 現在の手番の色
    Public Function getCurrentColor() As Integer
        Return currentColor
    End Function

    ' *****************************************************************
    ' 現在の手数
    Public Function getTurns() As Integer
        Return turns
    End Function

    ' SET -------------------------------------------------------------
    Public Sub SetRowBoard(x As Integer, y As Integer, state As Integer)
        RowBoard(x, y) = state
    End Sub

    ' *****************************************************************
    ' 打てる石の位置を設定
    Public Sub SetMovablePos()
        If turns > 0 Then
            For i As Integer = 0 To MovablePos(turns - 1).Count - 1
                Dim disc As Disc = MovablePos(turns - 1).Item(i)
                Dim p As System.Windows.Point = disc.RPoint()
                If RowBoard(p.X, p.Y) = Disc.SquareState.ABLE Then
                    SetRowBoard(p.X, p.Y, Disc.SquareState.EMPTY)
                End If
            Next i
        End If
        For i As Integer = 0 To MovablePos(turns).Count - 1
            Dim disc As Disc = MovablePos(turns).Item(i)
            Dim p As System.Windows.Point = disc.RPoint()
            SetRowBoard(p.X, p.Y, Disc.SquareState.ABLE)
        Next i
    End Sub

    ' *****************************************************************
    ' 打てる石と返せる石の方向
    Private Function checkMobility(ByRef disc As Disc) As Integer
        Dim pos As Point = disc.RPoint()
        Dim dir As Integer = Direction.NONE
        Dim x, y As Integer

        ' 空きマス判定
        If RowBoard(pos.X, pos.Y) <> Disc.SquareState.EMPTY Then Return Direction.NONE

#Region "Directions"
#Region "UPPER"
        If RowBoard(pos.X, pos.Y - 1) = -disc.Color() Then
            x = pos.X : y = pos.Y - 2
            While RowBoard(x, y) = -disc.Color()
                y -= 1
            End While
            If RowBoard(x, y) = disc.Color() Then dir = dir Or Direction.UPPER
        End If
#End Region

#Region "LOWER"
        If RowBoard(pos.X, pos.Y + 1) = -disc.Color() Then
            x = pos.X : y = pos.Y + 2
            While RowBoard(x, y) = -disc.Color()
                y += 1
            End While
            If RowBoard(x, y) = disc.Color() Then dir = dir Or Direction.LOWER
        End If
#End Region

#Region "LEFT"
        If RowBoard(pos.X - 1, pos.Y) = -disc.Color() Then
            x = pos.X - 2 : y = pos.Y
            While RowBoard(x, y) = -disc.Color()
                x -= 1
            End While
            If RowBoard(x, y) = disc.Color() Then dir = dir Or Direction.LEFT
        End If
#End Region

#Region "RIGHT"
        If RowBoard(pos.X + 1, pos.Y) = -disc.Color() Then
            x = pos.X + 2 : y = pos.Y
            While RowBoard(x, y) = -disc.Color()
                x += 1
            End While
            If RowBoard(x, y) = disc.Color() Then dir = dir Or Direction.RIGHT
        End If
#End Region

#Region "UPPER_RIGHT"
        If RowBoard(pos.X + 1, pos.Y - 1) = -disc.Color() Then
            x = pos.X + 2 : y = pos.Y - 2
            While RowBoard(x, y) = -disc.Color()
                x += 1
                y -= 1
            End While
            If RowBoard(x, y) = disc.Color() Then dir = dir Or Direction.UPPER_RIGHT
        End If
#End Region

#Region "UPPER_LEFT"
        If RowBoard(pos.X - 1, pos.Y - 1) = -disc.Color() Then
            x = pos.X - 2 : y = pos.Y - 2
            While RowBoard(x, y) = -disc.Color()
                x -= 1
                y -= 1
            End While
            If RowBoard(x, y) = disc.Color() Then dir = dir Or Direction.UPPER_LEFT
        End If
#End Region

#Region "LOWER_RIGHT"
        If RowBoard(pos.X + 1, pos.Y + 1) = -disc.Color() Then
            x = pos.X + 2 : y = pos.Y + 2
            While RowBoard(x, y) = -disc.Color()
                x += 1
                y += 1
            End While
            If RowBoard(x, y) = disc.Color() Then dir = dir Or Direction.LOWER_RIGHT
        End If
#End Region

#Region "LOWER_LEFT"
        If RowBoard(pos.X - 1, pos.Y + 1) = -disc.Color() Then
            x = pos.X - 2 : y = pos.Y + 2
            While RowBoard(x, y) = -disc.Color()
                x -= 1
                y += 1
            End While
            If RowBoard(x, y) = disc.Color() Then dir = dir Or Direction.LOWER_LEFT
        End If
#End Region
#End Region

        Return dir
    End Function

    ' *****************************************************************
    ' Point で指定したマス目座標に石を打つ
    ' @return   True : success,     False : failed
    Public Function move(p As Point) As Boolean
        If p.X < 0 OrElse p.X >= BOARD_SIZE + 1 Then Return False
        If p.Y < 0 OrElse p.Y >= BOARD_SIZE + 1 Then Return False
        If MovableDir(turns, p.X, p.Y) = Direction.NONE Then Return False

        ' 裏返しとログの更新
        flipDiscs(p)

        turns += 1
        currentColor = -currentColor

        ' 手数や手番の更新
        initMovable()

        Return True
    End Function

    ' *****************************************************************
    ' 石を打ち、裏返す -> UpdateLog
    Private Sub flipDiscs(p As Point)
        Dim x, y As Integer
        Dim dir As Integer = MovableDir(turns, p.X, p.Y)

        Dim update As ArrayList = New ArrayList()

        ' 今打った石を反映させる
        RowBoard(p.X, p.Y) = currentColor
        update.Add(New Disc(p.X, p.Y, currentColor))

#Region "Directions"
#Region "UPPER"
        If (dir And Direction.UPPER) <> Direction.NONE Then
            y = p.Y - 1
            While RowBoard(p.X, y) <> currentColor
                RowBoard(p.X, y) = currentColor
                update.Add(New Disc(p.X, y, currentColor))
                y -= 1
            End While
        End If
#End Region

#Region "LOWER"
        If (dir And Direction.LOWER) <> Direction.NONE Then
            y = p.Y + 1
            While RowBoard(p.X, y) <> currentColor
                RowBoard(p.X, y) = currentColor
                update.Add(New Disc(p.X, y, currentColor))
                y += 1
            End While
        End If
#End Region

#Region "RIGHT"
        If (dir And Direction.RIGHT) <> Direction.NONE Then
            x = p.X + 1
            While RowBoard(x, p.Y) <> currentColor
                RowBoard(x, p.Y) = currentColor
                update.Add(New Disc(x, p.Y, currentColor))
                x += 1
            End While
        End If
#End Region

#Region "LEFT"
        If (dir And Direction.LEFT) <> Direction.NONE Then
            x = p.X - 1
            While RowBoard(x, p.Y) <> currentColor
                RowBoard(x, p.Y) = currentColor
                update.Add(New Disc(x, p.Y, currentColor))
                x -= 1
            End While
        End If
#End Region

#Region "UPPER_RIGHT"
        If (dir And Direction.UPPER_RIGHT) <> Direction.NONE Then
            x = p.X + 1
            y = p.Y - 1
            While RowBoard(x, y) <> currentColor
                RowBoard(x, y) = currentColor
                update.Add(New Disc(x, y, currentColor))
                x += 1
                y -= 1
            End While
        End If
#End Region

#Region "UPPER_LEFT"
        If (dir And Direction.UPPER_LEFT) <> Direction.NONE Then
            x = p.X - 1
            y = p.Y - 1
            While RowBoard(x, y) <> currentColor
                RowBoard(x, y) = currentColor
                update.Add(New Disc(x, y, currentColor))
                x -= 1
                y -= 1
            End While
        End If
#End Region

#Region "LOWER_RIGHT"
        If (dir And Direction.LOWER_RIGHT) <> Direction.NONE Then
            x = p.X + 1
            y = p.Y + 1
            While RowBoard(x, y) <> currentColor
                RowBoard(x, y) = currentColor
                update.Add(New Disc(x, y, currentColor))
                x += 1
                y += 1
            End While
        End If
#End Region

#Region "LOWER_LEFT"
        If (dir And Direction.LOWER_LEFT) <> Direction.NONE Then
            x = p.X - 1
            y = p.Y + 1
            While RowBoard(x, y) <> currentColor
                RowBoard(x, y) = currentColor
                update.Add(New Disc(x, y, currentColor))
                x -= 1
                y += 1
            End While
        End If
#End Region
#End Region

#Region "石の数の更新"
        Dim discdiff As Integer = update.Count

        ' 打った石の数をひっくり返した枚数 + 打った石一枚分増やす
        discs.Data(currentColor) += discdiff
        ' 相手の石の数をひっくり返した枚数分減らす
        discs.Data(-currentColor) -= discdiff - 1
        ' 空きマスを一マス減らす
        discs.Data(Disc.SquareState.EMPTY) -= 1

        updateLog.Add(update)
#End Region
    End Sub

    ' *****************************************************************
    ' MovablePos と MovableDir の再計算
    Private Sub initMovable()
        Dim disc As Disc
        Dim dir As Integer

        MovablePos(turns).Clear()

        For y As Integer = 0 To BOARD_SIZE
            For x As Integer = 0 To BOARD_SIZE
                disc = New Disc(x, y, currentColor)
                dir = checkMobility(disc)
                If dir <> Direction.NONE Then
                    MovablePos(turns).Add(disc)
                End If
                MovableDir(turns, x, y) = dir
            Next x
        Next y
    End Sub

    ' *****************************************************************
    ' ゲームの終了判定
    Public Function isGameOver() As Boolean
        If turns = MAX_TURNS Then Return True

        If MovablePos(turns).Count > 0 Then Return False

        Dim disc As New Disc
        disc.Color = -currentColor
        For x As Integer = 0 To BOARD_SIZE - 1
            For y As Integer = 0 To BOARD_SIZE - 1
                disc.RPoint = New Point(x, y)
                If checkMobility(disc) <> Direction.NONE Then Return False
            Next y
        Next x

        Return True
    End Function

    ' *****************************************************************
    ' パス
    Public Function pass() As Boolean
        ' 打つ手があるならパスはできない
        If MovablePos(turns).Count > 0 Then Return False

        ' ゲームが終了しているならパスはできない
        If isGameOver() Then Return False

        currentColor = -currentColor

        ' 空の update を挿入
        updateLog.Add(New ArrayList())

        initMovable()

        Return True
    End Function

    ' *****************************************************************
    ' パス可能判定（パスの実行は行わず、あくまで判定）
    Public Function enablePass() As Boolean
        ' 打つ手があるならパスはできない
        If MovablePos(turns).Count > 0 Then Return False

        ' ゲームが終了しているならパスはできない
        If isGameOver() Then Return False

        ' それ以外
        Return True
    End Function

    ' *****************************************************************
    ' 前に戻る
    Public Function undo() As Boolean
        ' 1ターン目
        If turns = 0 Then Return False

        ' ゲーム終了
        If isGameOver() Then Return False

        currentColor = -currentColor

        If updateLog.Count > 1 Then
            updateLog.RemoveAt(updateLog.Count - 1)
        End If
        Dim update As ArrayList = updateLog
        Dim discdiff As Integer = update.Count

        ' 前回がパスかどうか
        If discdiff = 0 Then
            MovablePos(turns).Clear()
            ' MovablePos と MovableDir を再構築
            For x As Integer = 0 To BOARD_SIZE
                For y As Integer = 0 To BOARD_SIZE
                    MovableDir(turns, x, y) = Direction.NONE
                Next y
            Next x
        Else
            turns -= 1
            ' 石を元に戻す
            Dim d As Disc = update(0).Item(0)
            Dim p As Point = d.RPoint()
            RowBoard(p.X, p.Y) = Disc.SquareState.EMPTY
            For i As Integer = 1 To update.Count - 1
                p = DirectCast(update(i).Item(0), Disc).RPoint()
                RowBoard(p.X, p.Y) = -currentColor
            Next i
        End If

        discs.Data(currentColor) -= discdiff + 1
        discs.Data(-currentColor) += discdiff
        discs.Data(Disc.SquareState.EMPTY) += 1
        Return True
    End Function
#End Region
End Class
