Imports GraphicLibrary.MyGraphicTools

Public Class GraphicUtility
    Inherits GraphicTools
    Private rows As Integer = Board.BOARD_SIZE
    Private wid As Double
    Private maxWid As Double

    Public Sub New(ByRef picture As PictureBox, minX As Double,
                   maxX As Double, minY As Double, maxY As Double,
                   Optional notBMP As Boolean = False,
                   Optional useMath As Boolean = False)
        MyBase.New(picture, minX, maxX, minY, maxY, notBMP, useMath)
        maxWid = picture.Width
        wid = maxWid \ rows
        Init()
    End Sub

    Private Sub Init()
        FillBackColor()
        DrawLines()
    End Sub

    Private Sub FillBackColor()
        SetForeColor(Color.FromArgb(30, 180, 80))
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
    End Sub

    Public Sub SetBrushColor(col As Color)
        DirectCast(figBrush, SolidBrush).Color = col
    End Sub

    Public Overloads Sub FillCircle(x As Double, y As Double, r As Double, col As Color)
        SetBrushColor(col)
        MyBase.FillCircle(x, y, r)
    End Sub
End Class
