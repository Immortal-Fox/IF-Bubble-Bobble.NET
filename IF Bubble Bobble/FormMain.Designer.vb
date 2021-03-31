<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.tsmFichier = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmQuitter = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmJeu = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDemarrerHorloge = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmPauseHorloge = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmFenetre = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmConfiguration = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmConfigurationClavier = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmPerformances = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAfficherOmbres = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDeveloppement = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAfficherTexteDebug = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAutres = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAPropos = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmNotesMisesAJour = New System.Windows.Forms.ToolStripMenuItem()
        Me.pboxJeu = New System.Windows.Forms.PictureBox()
        Me.msMain.SuspendLayout()
        CType(Me.pboxJeu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msMain
        '
        Me.msMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFichier, Me.tsmJeu, Me.tsmFenetre, Me.tsmConfiguration, Me.tsmDeveloppement, Me.tsmAutres})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.msMain.Size = New System.Drawing.Size(1050, 35)
        Me.msMain.TabIndex = 1
        Me.msMain.Text = "MenuStrip1"
        '
        'tsmFichier
        '
        Me.tsmFichier.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudioToolStripMenuItem, Me.ToolStripSeparator1, Me.tsmQuitter})
        Me.tsmFichier.Name = "tsmFichier"
        Me.tsmFichier.Size = New System.Drawing.Size(78, 29)
        Me.tsmFichier.Text = "Fichier"
        '
        'StudioToolStripMenuItem
        '
        Me.StudioToolStripMenuItem.Name = "StudioToolStripMenuItem"
        Me.StudioToolStripMenuItem.Size = New System.Drawing.Size(169, 34)
        Me.StudioToolStripMenuItem.Text = "Studio"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(166, 6)
        '
        'tsmQuitter
        '
        Me.tsmQuitter.Name = "tsmQuitter"
        Me.tsmQuitter.Size = New System.Drawing.Size(169, 34)
        Me.tsmQuitter.Text = "Quitter"
        '
        'tsmJeu
        '
        Me.tsmJeu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmDemarrerHorloge, Me.tsmPauseHorloge})
        Me.tsmJeu.Name = "tsmJeu"
        Me.tsmJeu.Size = New System.Drawing.Size(53, 29)
        Me.tsmJeu.Text = "Jeu"
        '
        'tsmDemarrerHorloge
        '
        Me.tsmDemarrerHorloge.Image = Global.IF_Bubble_Bobble.My.Resources.Resources.play
        Me.tsmDemarrerHorloge.Name = "tsmDemarrerHorloge"
        Me.tsmDemarrerHorloge.Size = New System.Drawing.Size(188, 34)
        Me.tsmDemarrerHorloge.Text = "Démarrer"
        '
        'tsmPauseHorloge
        '
        Me.tsmPauseHorloge.Image = Global.IF_Bubble_Bobble.My.Resources.Resources.pause
        Me.tsmPauseHorloge.Name = "tsmPauseHorloge"
        Me.tsmPauseHorloge.Size = New System.Drawing.Size(188, 34)
        Me.tsmPauseHorloge.Text = "Pause"
        '
        'tsmFenetre
        '
        Me.tsmFenetre.Name = "tsmFenetre"
        Me.tsmFenetre.Size = New System.Drawing.Size(86, 29)
        Me.tsmFenetre.Text = "Fenêtre"
        '
        'tsmConfiguration
        '
        Me.tsmConfiguration.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmConfigurationClavier, Me.ToolStripSeparator2, Me.tsmPerformances})
        Me.tsmConfiguration.Name = "tsmConfiguration"
        Me.tsmConfiguration.Size = New System.Drawing.Size(137, 29)
        Me.tsmConfiguration.Text = "Configuration"
        '
        'tsmConfigurationClavier
        '
        Me.tsmConfigurationClavier.Name = "tsmConfigurationClavier"
        Me.tsmConfigurationClavier.Size = New System.Drawing.Size(277, 34)
        Me.tsmConfigurationClavier.Text = "Configuration clavier"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(274, 6)
        '
        'tsmPerformances
        '
        Me.tsmPerformances.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAfficherOmbres})
        Me.tsmPerformances.Name = "tsmPerformances"
        Me.tsmPerformances.Size = New System.Drawing.Size(277, 34)
        Me.tsmPerformances.Text = "Performances"
        '
        'tsmAfficherOmbres
        '
        Me.tsmAfficherOmbres.Checked = True
        Me.tsmAfficherOmbres.CheckOnClick = True
        Me.tsmAfficherOmbres.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmAfficherOmbres.Name = "tsmAfficherOmbres"
        Me.tsmAfficherOmbres.Size = New System.Drawing.Size(203, 34)
        Me.tsmAfficherOmbres.Text = "Ray Tracing"
        '
        'tsmDeveloppement
        '
        Me.tsmDeveloppement.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAfficherTexteDebug})
        Me.tsmDeveloppement.Name = "tsmDeveloppement"
        Me.tsmDeveloppement.Size = New System.Drawing.Size(155, 29)
        Me.tsmDeveloppement.Text = "Développement"
        '
        'tsmAfficherTexteDebug
        '
        Me.tsmAfficherTexteDebug.Checked = True
        Me.tsmAfficherTexteDebug.CheckOnClick = True
        Me.tsmAfficherTexteDebug.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmAfficherTexteDebug.Name = "tsmAfficherTexteDebug"
        Me.tsmAfficherTexteDebug.Size = New System.Drawing.Size(293, 34)
        Me.tsmAfficherTexteDebug.Text = "Afficher le texte debug"
        '
        'tsmAutres
        '
        Me.tsmAutres.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAPropos, Me.tsmNotesMisesAJour})
        Me.tsmAutres.Name = "tsmAutres"
        Me.tsmAutres.Size = New System.Drawing.Size(36, 29)
        Me.tsmAutres.Text = "?"
        '
        'tsmAPropos
        '
        Me.tsmAPropos.Name = "tsmAPropos"
        Me.tsmAPropos.Size = New System.Drawing.Size(278, 34)
        Me.tsmAPropos.Text = "A Propos"
        '
        'tsmNotesMisesAJour
        '
        Me.tsmNotesMisesAJour.Name = "tsmNotesMisesAJour"
        Me.tsmNotesMisesAJour.Size = New System.Drawing.Size(278, 34)
        Me.tsmNotesMisesAJour.Text = "Notes de mise à jour"
        '
        'pboxJeu
        '
        Me.pboxJeu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pboxJeu.Location = New System.Drawing.Point(0, 35)
        Me.pboxJeu.Name = "pboxJeu"
        Me.pboxJeu.Size = New System.Drawing.Size(1050, 1140)
        Me.pboxJeu.TabIndex = 0
        Me.pboxJeu.TabStop = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 1175)
        Me.Controls.Add(Me.pboxJeu)
        Me.Controls.Add(Me.msMain)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.msMain
        Me.Name = "FormMain"
        Me.Text = "Bubble Bobble Client"
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        CType(Me.pboxJeu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pboxJeu As PictureBox
    Friend WithEvents msMain As MenuStrip
    Friend WithEvents tsmJeu As ToolStripMenuItem
    Friend WithEvents tsmDemarrerHorloge As ToolStripMenuItem
    Friend WithEvents tsmPauseHorloge As ToolStripMenuItem
    Friend WithEvents tsmFichier As ToolStripMenuItem
    Friend WithEvents tsmAutres As ToolStripMenuItem
    Friend WithEvents tsmConfiguration As ToolStripMenuItem
    Friend WithEvents tsmConfigurationClavier As ToolStripMenuItem
    Friend WithEvents tsmAPropos As ToolStripMenuItem
    Friend WithEvents tsmQuitter As ToolStripMenuItem
    Friend WithEvents tsmNotesMisesAJour As ToolStripMenuItem
    Friend WithEvents tsmFenetre As ToolStripMenuItem
    Friend WithEvents tsmDeveloppement As ToolStripMenuItem
    Friend WithEvents tsmAfficherTexteDebug As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsmPerformances As ToolStripMenuItem
    Friend WithEvents tsmAfficherOmbres As ToolStripMenuItem
    Friend WithEvents StudioToolStripMenuItem As ToolStripMenuItem
End Class
