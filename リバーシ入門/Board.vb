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

    Private RawBoard(,) As Integer = New Integer(BOARD_SIZE + 2, BOARD_SIZE + 2) {}
    Private turns As Integer
    Private currentColor As Integer

    Private updateLog As New ArrayList()

    Private MovableDir(,,) As Integer = New Integer(MAX_TURNS + 1, BOARD_SIZE + 2, BOARD_SIZE + 2) {}
    Private MovablePos() As ArrayList = New ArrayList(MAX_TURNS + 1) {}

    Private discs As ColorStroage(Of Integer)

    ' 盤面を初期化する
    Private Sub Init()
        ' ターン数と現在のプレイヤー
        turns = 0
        currentColor = Disc.SquareState.BLACK

        Dim MaxRow As Integer = RawBoard.GetUpperBound(0)
        ' 壁の初期配置
        For i As Integer = 0 To MaxRow
            RawBoard(0, i) = Disc.SquareState.WALL
            RawBoard(i, 0) = Disc.SquareState.WALL
            RawBoard(MaxRow, i) = Disc.SquareState.WALL
            RawBoard(i, MaxRow) = Disc.SquareState.WALL
        Next
        ' 石の初期配置
        RawBoard(4, 4) = Disc.SquareState.WHITE
        RawBoard(5, 5) = Disc.SquareState.WHITE
        RawBoard(4, 5) = Disc.SquareState.BLACK
        RawBoard(5, 4) = Disc.SquareState.BLACK
        discs.Data(Disc.SquareState.WHITE) = 2
        discs.Data(Disc.SquareState.BLACK) = 2
    End Sub

    ' *****************************************************************
    ' コンストラクタ
    Public Sub New()
        Init()
    End Sub

#Region "Methods"
    ' *****************************************************************
    ' 各種メソッド
    ' *****************************************************************

    ' *****************************************************************
    ' 打てる石と返せる石の方向
    Private Function checkMobility(ByRef disc As Disc) As Integer
        Dim pos As Point = disc.RPoint()
        Dim dir As Integer = Direction.NONE
        Dim x, y As Integer

        ' 空きマス判定
        If RawBoard(pos.X, pos.Y) <> Disc.SquareState.EMPTY Then Return Direction.NONE

#Region "Directions"
#Region "UPPER"
        If RawBoard(pos.X, pos.Y - 1) = -disc.Color() Then
            x = pos.X : y = pos.Y - 2
            While RawBoard(x, y) = -disc.Color()
                y -= 1
            End While
            If RawBoard(x, y) = disc.Color() Then dir = dir Or Direction.UPPER
        End If
#End Region

#Region "LOWER"
        If RawBoard(pos.X, pos.Y + 1) = -disc.Color() Then
            x = pos.X : y = pos.Y + 2
            While RawBoard(x, y) = -disc.Color()
                y += 1
            End While
            If RawBoard(x, y) = disc.Color() Then dir = dir Or Direction.LOWER
        End If
#End Region

#Region "LEFT"
        If RawBoard(pos.X - 1, pos.Y) = -disc.Color() Then
            x = pos.X - 2 : y = pos.Y
            While RawBoard(x, y) = -disc.Color()
                x -= 1
            End While
            If RawBoard(x, y) = disc.Color() Then dir = dir Or Direction.LEFT
        End If
#End Region

#Region "RIGHT"
        If RawBoard(pos.X + 1, pos.Y) = -disc.Color() Then
            x = pos.X + 2 : y = pos.Y
            While RawBoard(x, y) = -disc.Color()
                x += 1
            End While
            If RawBoard(x, y) = disc.Color() Then dir = dir Or Direction.RIGHT
        End If
#End Region

#Region "UPPER_RIGHT"
        If RawBoard(pos.X + 1, pos.Y - 1) = -disc.Color() Then
            x = pos.X + 2 : y = pos.Y - 2
            While RawBoard(x, y) = -disc.Color()
                x += 1
                y -= 1
            End While
            If RawBoard(x, y) = disc.Color() Then dir = dir Or Direction.UPPER_RIGHT
        End If
#End Region

#Region "UPPER_LEFT"
        If RawBoard(pos.X - 1, pos.Y - 1) = -disc.Color() Then
            x = pos.X - 2 : y = pos.Y - 2
            While RawBoard(x, y) = -disc.Color()
                x -= 1
                y -= 1
            End While
            If RawBoard(x, y) = disc.Color() Then dir = dir Or Direction.UPPER_LEFT
        End If
#End Region

#Region "LOWER_RIGHT"
        If RawBoard(pos.X + 1, pos.Y + 1) = -disc.Color() Then
            x = pos.X + 2 : y = pos.Y + 2
            While RawBoard(x, y) = -disc.Color()
                x += 1
                y += 1
            End While
            If RawBoard(x, y) = disc.Color() Then dir = dir Or Direction.LOWER_RIGHT
        End If
#End Region

#Region "LOWER_LEFT"
        If RawBoard(pos.X - 1, pos.Y + 1) = -disc.Color() Then
            x = pos.X - 2 : y = pos.Y + 2
            While RawBoard(x, y) = -disc.Color()
                x -= 1
                y += 1
            End While
            If RawBoard(x, y) = disc.Color() Then dir = dir Or Direction.LOWER_LEFT
        End If
#End Region
#End Region

        Return dir
    End Function

    ' *****************************************************************
    ' Point で指定したマス目座標に石を打つ
    ' @return   True : success,     False : failed
    Public Function move(p As Point) As Boolean
        If p.X < 0 OrElse p.X >= BOARD_SIZE Then Return False
        If p.Y < 0 OrElse p.Y >= BOARD_SIZE Then Return False
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
        RawBoard(p.X, p.Y) = currentColor
        update.Add(New Disc(p.X, p.Y, currentColor))

#Region "Directions"
#Region "UPPER"
        If (dir And Direction.UPPER) <> Direction.NONE Then
            y = p.Y - 1
            While RawBoard(p.X, y) <> currentColor
                RawBoard(p.X, y) = currentColor
                update.Add(New Disc(p.X, y, currentColor))
                y -= 1
            End While
        End If
#End Region

#Region "LOWER"
        If (dir And Direction.LOWER) <> Direction.NONE Then
            y = p.Y + 1
            While RawBoard(p.X, y) <> currentColor
                RawBoard(p.X, y) = currentColor
                update.Add(New Disc(p.X, y, currentColor))
                y += 1
            End While
        End If
#End Region

#Region "RIGHT"
        If (dir And Direction.RIGHT) <> Direction.NONE Then
            x = p.X + 1
            While RawBoard(x, p.Y) <> currentColor
                RawBoard(x, p.Y) = currentColor
                update.Add(New Disc(x, p.Y, currentColor))
                x += 1
            End While
        End If
#End Region

#Region "LEFT"
        If (dir And Direction.LEFT) <> Direction.NONE Then
            x = p.X - 1
            While RawBoard(x, p.Y) <> currentColor
                RawBoard(x, p.Y) = currentColor
                update.Add(New Disc(x, p.Y, currentColor))
                x -= 1
            End While
        End If
#End Region

#Region "UPPER_RIGHT"
        If (dir And Direction.UPPER_RIGHT) <> Direction.NONE Then
            x = p.X + 1
            y = p.Y - 1
            While RawBoard(x, y) <> currentColor
                RawBoard(x, y) = currentColor
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
            While RawBoard(x, y) <> currentColor
                RawBoard(x, y) = currentColor
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
            While RawBoard(x, y) <> currentColor
                RawBoard(x, y) = currentColor
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
            While RawBoard(x, y) <> currentColor
                RawBoard(x, y) = currentColor
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
#End Region
    End Sub

    ' *****************************************************************
    ' MovablePos と MovableDir の再計算
    Private Sub initMovable()
        Dim disc As Disc
        Dim dir As Integer

        MovablePos(turns).Clear()

        For y As Integer = 0 To BOARD_SIZE - 1
            For x As Integer = 0 To BOARD_SIZE - 1
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
    ' 前に戻る
    Public Function undo() As Boolean
        ' 1ターン目
        If turns = 0 Then Return False

        currentColor = -currentColor

        updateLog.RemoveAt(updateLog.Count - 1)
        Dim update As ArrayList = updateLog

        ' 前回がパスかどうか
        If update Is Nothing Then
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
            Dim p As Point = update.Item(0)
            RawBoard(p.X, p.Y) = Disc.SquareState.EMPTY
            For i As Integer = 1 To update.Count - 1
                p = update.Item(i)
                RawBoard(p.X, p.Y) = -currentColor
            Next i
        End If
        Return True
    End Function
#End Region
End Class
