Imports GraphicLibrary.MyGraphicTools

Public Class GraphicUtility
    Inherits GraphicTools
    Private rows As Integer = Board.BOARD_SIZE
    Private wid As Double
    Private maxWid As Double
    Private rowBoard As Integer(,)

    Public Sub New(ByRef picture As PictureBox, board As Integer(,), minX As Double,
                   maxX As Double, minY As Double, maxY As Double,
                   Optional notBMP As Boolean = False,
                   Optional useMath As Boolean = False)
        MyBase.New(picture, minX, maxX, minY, maxY, notBMP, useMath)
        rowBoard = board
        maxWid = picture.Width
        wid = maxWid \ rows
        Init()
    End Sub

    Private Sub Init()
        FillBackColor()
        DrawLines()
        DrawBoard()
    End Sub

    Private Sub FillBackColor()
        SetForeColor(Color.FromArgb(30, 160, 80))
        MyBase.Clear()
    End Sub

    Private Sub DrawLines()
        Dim sqwid As Integer = 1
        ' 縦
        MyBase.Line(0, 0, 0, maxWid)
        For i As Integer = 0 To rows
            MyBase.Line(sqwid, 0, sqwid, maxWid)
            sqwid += wid
        Next i
        sqwid -= wid - 1
        MyBase.Line(sqwid, 0, sqwid, maxWid)

        sqwid = 1

        ' 横
        MyBase.Line(0, 0, maxWid, 0)
        For i As Integer = 0 To rows
            MyBase.Line(0, sqwid, maxWid, sqwid)
            sqwid += wid
        Next i
        sqwid -= wid - 1
        MyBase.Line(0, sqwid, maxWid, sqwid)

        ' チョボ点
        FillCircle(wid * 2 + 1, wid * 2 + 1, 5, Color.Black)
        FillCircle(wid * 2 + 1, wid * 6 + 1, 5, Color.Black)
        FillCircle(wid * 6 + 1, wid * 2 + 1, 5, Color.Black)
        FillCircle(wid * 6 + 1, wid * 6 + 1, 5, Color.Black)
    End Sub

    Private Sub DrawDisc(col As Integer, row As Integer)
        Dim halfWid As Integer = wid \ 2
        Dim x As Integer = col * wid - halfWid
        Dim y As Integer = row * wid - halfWid
        Dim r As Integer = wid * 3 \ 8
        Select Case rowBoard(col, row)
            Case Disc.SquareState.WHITE
                FillCircle(x, y + 2, r, Color.Black)
                FillCircle(x, y - 2, r, Color.White)
            Case Disc.SquareState.BLACK
                FillCircle(x, y + 2, r, Color.White)
                FillCircle(x, y - 2, r, Color.Black)
            Case Disc.SquareState.ABLE
                FillCircle(x, y, 5, Color.Black)
        End Select
    End Sub

    Public Sub DrawBoard()
        For i As Integer = 1 To rows
            For j As Integer = 1 To rows
                DrawDisc(i, j)
            Next j
        Next i
    End Sub

    Public Sub SetBrushColor(col As Color)
        DirectCast(figBrush, SolidBrush).Color = col
    End Sub

    Public Overloads Sub FillCircle(x As Double, y As Double, r As Double, col As Color)
        SetBrushColor(col)
        MyBase.FillCircle(x, y, r)
    End Sub

    Public Sub RewriteBoard(board As Integer(,))
        rowBoard = board
    End Sub
End Class
