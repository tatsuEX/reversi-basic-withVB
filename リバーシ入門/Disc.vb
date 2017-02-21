' *****************************************************************
' マス目の位置、状態を表すクラス
' 座標：_rPoint、状態：Color
' *****************************************************************
Public Class Disc
    ' プロパティ
    Private _rPoint As System.Windows.Point
    Public Property RPoint() As System.Windows.Point
        Get
            Return _rPoint
        End Get
        Set(p As System.Windows.Point)
            _rPoint = p
        End Set
    End Property

    Private _color As Integer
    Public Property Color() As Integer
        Get
            Return _color
        End Get
        Set(value As Integer)
            _color = value
        End Set
    End Property

    Public Enum SquareState
        WHITE = -1      ' 白
        EMPTY           ' 空き
        BLACK           ' 黒
        ABLE            ' 石を打てるマス
        WALL            ' 盤面範囲外
    End Enum

    ' *****************************************************************
    ' コンストラクタ
    ' *****************************************************************
    ' (0, 0) に空きマス
    Public Sub New()
        _rPoint = New System.Windows.Point(0, 0)
        _color = SquareState.EMPTY
    End Sub

    ' (x, y) に空きマス
    Public Sub New(x As Integer, y As Integer)
        _rPoint = New System.Windows.Point(x, y)
        _color = SquareState.EMPTY
    End Sub

    ' (x, y) に col に対応する石または状態
    Public Sub New(x As Integer, y As Integer, col As Integer)
        _rPoint = New System.Windows.Point(x, y)
        _color = col
    End Sub
End Class
