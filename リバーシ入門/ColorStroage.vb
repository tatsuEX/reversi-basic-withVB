' *****************************************************************
' 石の数を格納するオブジェクト
' *****************************************************************
Public Class ColorStroage(Of T)
    Private _data() As T = New T(3) {}       ' 0 - WHITE, 1 - EMPTY, 2 - BLACK

    Public Property Data(index As Integer) As T
        Get
            Return _data(index + 1)
        End Get
        Set(value As T)
            _data(index + 1) = value
        End Set
    End Property
End Class
