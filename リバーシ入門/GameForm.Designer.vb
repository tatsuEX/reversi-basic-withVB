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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuQuit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBoxBlack = New System.Windows.Forms.TextBox()
        Me.TextBoxWhite = New System.Windows.Forms.TextBox()
        CType(Me.PBBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PBBoard
        '
        Me.PBBoard.Location = New System.Drawing.Point(56, 136)
        Me.PBBoard.Name = "PBBoard"
        Me.PBBoard.Size = New System.Drawing.Size(100, 50)
        Me.PBBoard.TabIndex = 0
        Me.PBBoard.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルFToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(782, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルFToolStripMenuItem
        '
        Me.ファイルFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuQuit})
        Me.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem"
        Me.ファイルFToolStripMenuItem.Size = New System.Drawing.Size(79, 24)
        Me.ファイルFToolStripMenuItem.Text = "ファイル(&F)"
        '
        'MenuQuit
        '
        Me.MenuQuit.Name = "MenuQuit"
        Me.MenuQuit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.MenuQuit.Size = New System.Drawing.Size(188, 26)
        Me.MenuQuit.Text = "終了(&Q)"
        '
        'TextBoxBlack
        '
        Me.TextBoxBlack.BackColor = System.Drawing.Color.White
        Me.TextBoxBlack.Font = New System.Drawing.Font("MS UI Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxBlack.Location = New System.Drawing.Point(32, 56)
        Me.TextBoxBlack.Name = "TextBoxBlack"
        Me.TextBoxBlack.ReadOnly = True
        Me.TextBoxBlack.Size = New System.Drawing.Size(100, 47)
        Me.TextBoxBlack.TabIndex = 2
        Me.TextBoxBlack.TabStop = False
        '
        'TextBoxWhite
        '
        Me.TextBoxWhite.BackColor = System.Drawing.Color.White
        Me.TextBoxWhite.Font = New System.Drawing.Font("MS UI Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxWhite.Location = New System.Drawing.Point(520, 64)
        Me.TextBoxWhite.Name = "TextBoxWhite"
        Me.TextBoxWhite.ReadOnly = True
        Me.TextBoxWhite.Size = New System.Drawing.Size(100, 47)
        Me.TextBoxWhite.TabIndex = 3
        Me.TextBoxWhite.TabStop = False
        '
        'GameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 753)
        Me.Controls.Add(Me.TextBoxWhite)
        Me.Controls.Add(Me.TextBoxBlack)
        Me.Controls.Add(Me.PBBoard)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GameForm"
        Me.Text = "Beginner's Reversi"
        CType(Me.PBBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PBBoard As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuQuit As ToolStripMenuItem
    Friend WithEvents TextBoxBlack As TextBox
    Friend WithEvents TextBoxWhite As TextBox
End Class
