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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.tsmFichier = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAutres = New System.Windows.Forms.ToolStripMenuItem()
        Me.pboxEditeur = New System.Windows.Forms.PictureBox()
        Me.panelEditeurDroite = New System.Windows.Forms.Panel()
        Me.panelEditeurGauche = New System.Windows.Forms.Panel()
        Me.panelEditeurCentre = New System.Windows.Forms.FlowLayoutPanel()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.btTextures = New System.Windows.Forms.ToolStripButton()
        Me.btEditeur = New System.Windows.Forms.ToolStripButton()
        Me.panelEditeur = New System.Windows.Forms.Panel()
        Me.panelTextures = New System.Windows.Forms.Panel()
        Me.panelTexturesContenu = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelTexturesOptions = New System.Windows.Forms.Panel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.btCouleurFond = New System.Windows.Forms.ToolStripButton()
        Me.msMain.SuspendLayout()
        CType(Me.pboxEditeur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelEditeurCentre.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.panelEditeur.SuspendLayout()
        Me.panelTextures.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMain
        '
        Me.msMain.BackColor = System.Drawing.Color.DarkGray
        Me.msMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFichier, Me.tsmAutres})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(1112, 24)
        Me.msMain.TabIndex = 0
        Me.msMain.Text = "MenuStrip1"
        '
        'tsmFichier
        '
        Me.tsmFichier.Name = "tsmFichier"
        Me.tsmFichier.Size = New System.Drawing.Size(54, 20)
        Me.tsmFichier.Text = "Fichier"
        '
        'tsmAutres
        '
        Me.tsmAutres.Name = "tsmAutres"
        Me.tsmAutres.Size = New System.Drawing.Size(24, 20)
        Me.tsmAutres.Text = "?"
        '
        'pboxEditeur
        '
        Me.pboxEditeur.Location = New System.Drawing.Point(33, 33)
        Me.pboxEditeur.Name = "pboxEditeur"
        Me.pboxEditeur.Size = New System.Drawing.Size(600, 600)
        Me.pboxEditeur.TabIndex = 1
        Me.pboxEditeur.TabStop = False
        '
        'panelEditeurDroite
        '
        Me.panelEditeurDroite.BackColor = System.Drawing.Color.LightGray
        Me.panelEditeurDroite.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelEditeurDroite.Location = New System.Drawing.Point(237, 0)
        Me.panelEditeurDroite.Name = "panelEditeurDroite"
        Me.panelEditeurDroite.Size = New System.Drawing.Size(250, 131)
        Me.panelEditeurDroite.TabIndex = 2
        '
        'panelEditeurGauche
        '
        Me.panelEditeurGauche.BackColor = System.Drawing.Color.LightGray
        Me.panelEditeurGauche.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelEditeurGauche.Location = New System.Drawing.Point(0, 0)
        Me.panelEditeurGauche.Name = "panelEditeurGauche"
        Me.panelEditeurGauche.Size = New System.Drawing.Size(207, 131)
        Me.panelEditeurGauche.TabIndex = 3
        '
        'panelEditeurCentre
        '
        Me.panelEditeurCentre.AutoScroll = True
        Me.panelEditeurCentre.Controls.Add(Me.pboxEditeur)
        Me.panelEditeurCentre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelEditeurCentre.Location = New System.Drawing.Point(207, 0)
        Me.panelEditeurCentre.Name = "panelEditeurCentre"
        Me.panelEditeurCentre.Padding = New System.Windows.Forms.Padding(30)
        Me.panelEditeurCentre.Size = New System.Drawing.Size(30, 131)
        Me.panelEditeurCentre.TabIndex = 4
        '
        'tsMain
        '
        Me.tsMain.AutoSize = False
        Me.tsMain.BackColor = System.Drawing.Color.LightGray
        Me.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btTextures, Me.btEditeur, Me.ToolStripLabel1, Me.btCouleurFond})
        Me.tsMain.Location = New System.Drawing.Point(0, 24)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(1112, 37)
        Me.tsMain.TabIndex = 5
        Me.tsMain.Text = "ToolStrip1"
        '
        'btTextures
        '
        Me.btTextures.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btTextures.Image = Global.IF_Bubble_Bobble_Studio.My.Resources.Resources.image
        Me.btTextures.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btTextures.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btTextures.Name = "btTextures"
        Me.btTextures.Size = New System.Drawing.Size(78, 34)
        Me.btTextures.Text = "Textures"
        '
        'btEditeur
        '
        Me.btEditeur.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btEditeur.Image = CType(resources.GetObject("btEditeur.Image"), System.Drawing.Image)
        Me.btEditeur.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btEditeur.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEditeur.Name = "btEditeur"
        Me.btEditeur.Size = New System.Drawing.Size(64, 34)
        Me.btEditeur.Text = "Editeur"
        '
        'panelEditeur
        '
        Me.panelEditeur.Controls.Add(Me.panelEditeurCentre)
        Me.panelEditeur.Controls.Add(Me.panelEditeurGauche)
        Me.panelEditeur.Controls.Add(Me.panelEditeurDroite)
        Me.panelEditeur.Location = New System.Drawing.Point(12, 546)
        Me.panelEditeur.Name = "panelEditeur"
        Me.panelEditeur.Size = New System.Drawing.Size(487, 131)
        Me.panelEditeur.TabIndex = 6
        '
        'panelTextures
        '
        Me.panelTextures.Controls.Add(Me.panelTexturesContenu)
        Me.panelTextures.Controls.Add(Me.panelTexturesOptions)
        Me.panelTextures.Location = New System.Drawing.Point(169, 107)
        Me.panelTextures.Name = "panelTextures"
        Me.panelTextures.Size = New System.Drawing.Size(884, 393)
        Me.panelTextures.TabIndex = 7
        '
        'panelTexturesContenu
        '
        Me.panelTexturesContenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelTexturesContenu.Location = New System.Drawing.Point(0, 0)
        Me.panelTexturesContenu.Name = "panelTexturesContenu"
        Me.panelTexturesContenu.Size = New System.Drawing.Size(668, 393)
        Me.panelTexturesContenu.TabIndex = 0
        '
        'panelTexturesOptions
        '
        Me.panelTexturesOptions.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelTexturesOptions.Location = New System.Drawing.Point(668, 0)
        Me.panelTexturesOptions.Name = "panelTexturesOptions"
        Me.panelTexturesOptions.Size = New System.Drawing.Size(216, 393)
        Me.panelTexturesOptions.TabIndex = 1
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(79, 34)
        Me.ToolStripLabel1.Text = "Couleur Fond"
        '
        'btCouleurFond
        '
        Me.btCouleurFond.AutoSize = False
        Me.btCouleurFond.BackColor = System.Drawing.Color.Yellow
        Me.btCouleurFond.Checked = True
        Me.btCouleurFond.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btCouleurFond.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.btCouleurFond.Image = CType(resources.GetObject("btCouleurFond.Image"), System.Drawing.Image)
        Me.btCouleurFond.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btCouleurFond.Name = "btCouleurFond"
        Me.btCouleurFond.Size = New System.Drawing.Size(40, 20)
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 689)
        Me.Controls.Add(Me.panelTextures)
        Me.Controls.Add(Me.panelEditeur)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.msMain)
        Me.MainMenuStrip = Me.msMain
        Me.Name = "FormMain"
        Me.Text = "IF Bubble Bobble Studio"
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        CType(Me.pboxEditeur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelEditeurCentre.ResumeLayout(False)
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.panelEditeur.ResumeLayout(False)
        Me.panelTextures.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents msMain As MenuStrip
    Friend WithEvents tsmFichier As ToolStripMenuItem
    Friend WithEvents tsmAutres As ToolStripMenuItem
    Friend WithEvents pboxEditeur As PictureBox
    Friend WithEvents panelEditeurDroite As Panel
    Friend WithEvents panelEditeurGauche As Panel
    Friend WithEvents panelEditeurCentre As FlowLayoutPanel
    Friend WithEvents tsMain As ToolStrip
    Friend WithEvents btTextures As ToolStripButton
    Friend WithEvents btEditeur As ToolStripButton
    Friend WithEvents panelEditeur As Panel
    Friend WithEvents panelTextures As Panel
    Friend WithEvents panelTexturesContenu As FlowLayoutPanel
    Friend WithEvents panelTexturesOptions As Panel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents btCouleurFond As ToolStripButton
End Class
