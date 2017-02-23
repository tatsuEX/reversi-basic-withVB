<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GameForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PBBoard = New System.Windows.Forms.PictureBox()
        CType(Me.PBBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PBBoard
        '
        Me.PBBoard.Location = New System.Drawing.Point(56, 72)
        Me.PBBoard.Name = "PBBoard"
        Me.PBBoard.Size = New System.Drawing.Size(100, 50)
        Me.PBBoard.TabIndex = 0
        Me.PBBoard.TabStop = False
        '
        'GameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 753)
        Me.Controls.Add(Me.PBBoard)
        Me.Name = "GameForm"
        Me.Text = "Beginner's Reversi"
        CType(Me.PBBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PBBoard As PictureBox
End Class
