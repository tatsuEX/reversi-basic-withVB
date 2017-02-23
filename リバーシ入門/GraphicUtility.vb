Imports GraphicLibrary.MyGraphicTools

Public Class GraphicUtility
    Inherits GraphicTools

    Public Sub New(ByRef picture As PictureBox, minX As Double,
                   maxX As Double, minY As Double, maxY As Double,
                   Optional notBMP As Boolean = False,
                   Optional useMath As Boolean = False)
        MyBase.New(picture, minX, maxX, minY, maxY, notBMP, useMath)
    End Sub
End Class
