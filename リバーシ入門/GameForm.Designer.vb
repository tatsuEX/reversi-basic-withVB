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
        Me.MenuNewGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuQuit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBoxBlack = New System.Windows.Forms.TextBox()
        Me.TextBoxWhite = New System.Windows.Forms.TextBox()
        Me.LabelPlayer1 = New System.Windows.Forms.Label()
        Me.LabelPlayer2 = New System.Windows.Forms.Label()
        Me.PBCurrentPlayer = New System.Windows.Forms.PictureBox()
        Me.ButtonPass = New System.Windows.Forms.Button()
        Me.ButtonUndo = New System.Windows.Forms.Button()
        Me.TBState = New System.Windows.Forms.TextBox()
        Me.オプションOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuOptionDebug = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PBBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PBCurrentPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PBBoard
        '
        Me.PBBoard.Location = New System.Drawing.Point(56, 168)
        Me.PBBoard.Name = "PBBoard"
        Me.PBBoard.Size = New System.Drawing.Size(100, 50)
        Me.PBBoard.TabIndex = 0
        Me.PBBoard.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルFToolStripMenuItem, Me.オプションOToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(782, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルFToolStripMenuItem
        '
        Me.ファイルFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuNewGame, Me.MenuQuit})
        Me.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem"
        Me.ファイルFToolStripMenuItem.Size = New System.Drawing.Size(79, 24)
        Me.ファイルFToolStripMenuItem.Text = "ファイル(&F)"
        '
        'MenuNewGame
        '
        Me.MenuNewGame.Name = "MenuNewGame"
        Me.MenuNewGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MenuNewGame.Size = New System.Drawing.Size(228, 26)
        Me.MenuNewGame.Text = "新しいゲーム(&N)"
        '
        'MenuQuit
        '
        Me.MenuQuit.Name = "MenuQuit"
        Me.MenuQuit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.MenuQuit.Size = New System.Drawing.Size(228, 26)
        Me.MenuQuit.Text = "終了(&Q)"
        '
        'TextBoxBlack
        '
        Me.TextBoxBlack.BackColor = System.Drawing.Color.White
        Me.TextBoxBlack.Font = New System.Drawing.Font("MS UI Gothic", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxBlack.Location = New System.Drawing.Point(48, 72)
        Me.TextBoxBlack.Name = "TextBoxBlack"
        Me.TextBoxBlack.ReadOnly = True
        Me.TextBoxBlack.Size = New System.Drawing.Size(100, 67)
        Me.TextBoxBlack.TabIndex = 2
        Me.TextBoxBlack.TabStop = False
        Me.TextBoxBlack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxWhite
        '
        Me.TextBoxWhite.BackColor = System.Drawing.Color.White
        Me.TextBoxWhite.Font = New System.Drawing.Font("MS UI Gothic", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxWhite.Location = New System.Drawing.Point(496, 72)
        Me.TextBoxWhite.Name = "TextBoxWhite"
        Me.TextBoxWhite.ReadOnly = True
        Me.TextBoxWhite.Size = New System.Drawing.Size(100, 67)
        Me.TextBoxWhite.TabIndex = 3
        Me.TextBoxWhite.TabStop = False
        Me.TextBoxWhite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelPlayer1
        '
        Me.LabelPlayer1.Location = New System.Drawing.Point(48, 48)
        Me.LabelPlayer1.Name = "LabelPlayer1"
        Me.LabelPlayer1.Size = New System.Drawing.Size(100, 23)
        Me.LabelPlayer1.TabIndex = 4
        Me.LabelPlayer1.Text = "ゲスト１"
        Me.LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelPlayer2
        '
        Me.LabelPlayer2.Location = New System.Drawing.Point(496, 48)
        Me.LabelPlayer2.Name = "LabelPlayer2"
        Me.LabelPlayer2.Size = New System.Drawing.Size(100, 23)
        Me.LabelPlayer2.TabIndex = 5
        Me.LabelPlayer2.Text = "ゲスト２"
        Me.LabelPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PBCurrentPlayer
        '
        Me.PBCurrentPlayer.Location = New System.Drawing.Point(288, 56)
        Me.PBCurrentPlayer.Name = "PBCurrentPlayer"
        Me.PBCurrentPlayer.Size = New System.Drawing.Size(80, 80)
        Me.PBCurrentPlayer.TabIndex = 6
        Me.PBCurrentPlayer.TabStop = False
        '
        'ButtonPass
        '
        Me.ButtonPass.Location = New System.Drawing.Point(64, 688)
        Me.ButtonPass.Name = "ButtonPass"
        Me.ButtonPass.Size = New System.Drawing.Size(152, 63)
        Me.ButtonPass.TabIndex = 7
        Me.ButtonPass.Text = "パス"
        Me.ButtonPass.UseVisualStyleBackColor = True
        '
        'ButtonUndo
        '
        Me.ButtonUndo.Location = New System.Drawing.Point(440, 688)
        Me.ButtonUndo.Name = "ButtonUndo"
        Me.ButtonUndo.Size = New System.Drawing.Size(152, 63)
        Me.ButtonUndo.TabIndex = 8
        Me.ButtonUndo.Text = "待った"
        Me.ButtonUndo.UseVisualStyleBackColor = True
        '
        'TBState
        '
        Me.TBState.Location = New System.Drawing.Point(824, 176)
        Me.TBState.Multiline = True
        Me.TBState.Name = "TBState"
        Me.TBState.ReadOnly = True
        Me.TBState.Size = New System.Drawing.Size(304, 312)
        Me.TBState.TabIndex = 9
        Me.TBState.TabStop = False
        Me.TBState.Visible = False
        '
        'オプションOToolStripMenuItem
        '
        Me.オプションOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOptionDebug})
        Me.オプションOToolStripMenuItem.Name = "オプションOToolStripMenuItem"
        Me.オプションOToolStripMenuItem.Size = New System.Drawing.Size(95, 24)
        Me.オプションOToolStripMenuItem.Text = "オプション(&O)"
        '
        'MenuOptionDebug
        '
        Me.MenuOptionDebug.Name = "MenuOptionDebug"
        Me.MenuOptionDebug.Size = New System.Drawing.Size(181, 26)
        Me.MenuOptionDebug.Text = "デバッグモード"
        '
        'GameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 779)
        Me.Controls.Add(Me.TBState)
        Me.Controls.Add(Me.ButtonUndo)
        Me.Controls.Add(Me.ButtonPass)
        Me.Controls.Add(Me.PBCurrentPlayer)
        Me.Controls.Add(Me.LabelPlayer2)
        Me.Controls.Add(Me.LabelPlayer1)
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
        CType(Me.PBCurrentPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PBBoard As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuQuit As ToolStripMenuItem
    Friend WithEvents TextBoxBlack As TextBox
    Friend WithEvents TextBoxWhite As TextBox
    Friend WithEvents MenuNewGame As ToolStripMenuItem
    Friend WithEvents LabelPlayer1 As Label
    Friend WithEvents LabelPlayer2 As Label
    Friend WithEvents PBCurrentPlayer As PictureBox
    Friend WithEvents ButtonPass As Button
    Friend WithEvents ButtonUndo As Button
    Friend WithEvents TBState As TextBox
    Friend WithEvents オプションOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuOptionDebug As ToolStripMenuItem
End Class
