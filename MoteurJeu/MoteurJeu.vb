
''' <summary>
''' Moteur de jeu
''' </summary>
Public Class MoteurJeu

    ''' <summary>
    ''' Support graphique pour le dessin
    ''' </summary>
    Private WithEvents SupportRendu As PictureBox

    ''' <summary>
    ''' Horloge de jeu
    ''' </summary>
    Private WithEvents HorlogeJeu As Timer

    ' Les différents modules du moteur de jeu
    Private GestionDessin As MoteurDessin
    Private GestionSprites As MoteurSprites
    Private GestionFonction As MoteurFonction
    Private GestionControleurs As MoteurControleurs
    Private GestionDebug As MoteurDebug
    Private GestionPartie As MoteurPartie
    Private GestionTextures As MoteurTextures
    Private GestionFactory As MoteurFactory
    Private GestionATH As MoteurATH
    Private GestionNiveaux As MoteurNiveaux

    ' Différents temps de chargement
    Private tempsDebutNiveauMax As Integer = 300
    Private tempsDebutNiveau As Integer = 300
    Private tempsFinNiveauMax As Integer = 600
    Private tempsFinNiveau As Integer = 600

    ''' <summary>
    ''' Retourne le temps avant le début du niveau [TICK]
    ''' </summary>
    ''' <returns>Temps début de niveau</returns>
    Public ReadOnly Property GetTempsDebutNiveau As Integer
        Get
            Return tempsDebutNiveau
        End Get
    End Property

    ''' <summary>
    ''' Retourne le temps avant la fin du niveau [TICK]
    ''' </summary>
    ''' <returns>Temps fin de niveau</returns>
    Public ReadOnly Property GetTempsFinNiveau As Integer
        Get
            Return tempsFinNiveau
        End Get
    End Property

    Sub New(ByRef _supportRendu As PictureBox)

        If Not IsNothing(_supportRendu) Then
            SupportRendu = _supportRendu
        Else
            SupportRendu = New PictureBox
        End If

        HorlogeJeu = New Timer With {
            .Interval = 10
        }

        ' Instancie les modules du moteur de jeu
        GestionDessin = New MoteurDessin(Me)
        GestionSprites = New MoteurSprites(Me)
        GestionFonction = New MoteurFonction(Me)
        GestionControleurs = New MoteurControleurs(Me)
        GestionDebug = New MoteurDebug(Me)
        GestionPartie = New MoteurPartie(Me)
        GestionTextures = New MoteurTextures(Me)
        GestionFactory = New MoteurFactory(Me)
        GestionATH = New MoteurATH(Me)
        GestionNiveaux = New MoteurNiveaux(Me)
    End Sub

    ''' <summary>
    ''' Démarrer l'horloge de jeu
    ''' </summary>
    Public Sub DemarrerHorloge()
        HorlogeJeu.Start()
    End Sub

    ''' <summary>
    ''' Arrêter l'horloge de jeu
    ''' </summary>
    Public Sub ArreterHorloge()
        HorlogeJeu.Stop()
    End Sub

    ''' <summary>
    ''' Passe les touches enfoncées
    ''' </summary>
    ''' <param name="_key">Code de la touche</param>
    Public Sub KeyDown(ByVal _key As Keys)

        Dim ctrl As MoteurControleurs.CONTROLS = GestionControleurs.GetControl(_key)

        If GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.DEBUT_NIVEAU Or GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.DECOMPTE_FIN_NIVEAU Then
            For Each _sprite As Sprite In GestionSprites.GetSprites
                _sprite.KeyDown(ctrl)
            Next
        End If

        GetGestionPartie.KeyDown(ctrl)

        If ctrl = MoteurControleurs.CONTROLS.PAUSE Then
            ArreterHorloge()
        ElseIf ctrl = MoteurControleurs.CONTROLS.START Then
            DemarrerHorloge()
        End If
    End Sub

    ''' <summary>
    ''' Passe les touches relâchées
    ''' </summary>
    ''' <param name="_key">code de la touche</param>
    Public Sub KeyUp(ByVal _key As Keys)
        Dim ctrl As MoteurControleurs.CONTROLS = GestionControleurs.GetControl(_key)

        If GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.DEBUT_NIVEAU Or GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.DECOMPTE_FIN_NIVEAU Then
            For Each _sprite As Sprite In GestionSprites.GetSprites
                _sprite.KeyUp(ctrl)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Grande boucle de jeu
    ''' </summary>
    Private Sub HorlogeTick() Handles HorlogeJeu.Tick
        If Not IsNothing(SupportRendu.Image) Then
            SupportRendu.Image.Dispose()
        End If

        If Not GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.AUCUN And Not GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.CHANGEMENT_NIVEAU And Not GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.VICTOIRE And Not GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.GAME_OVER And Not GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.ANIMATION_CHANGEMENT_NIVEAU Then
            ' Tick sur chaque sprite
            Dim listeSprite As New List(Of Sprite)
            For Each _sprite As Sprite In GestionSprites.GetSprites()
                listeSprite.Add(_sprite)
            Next

            For Each _sprite As Sprite In listeSprite
                _sprite.Tick()
            Next

            ' Suppression des sprites *détruits"
            GestionSprites.SupprimerLesSpritesDelai()

            SupportRendu.Image = GestionDessin.DessinerFrame()
        ElseIf GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.VICTOIRE Then
            SupportRendu.Image = GestionDessin.DessinerFrameVictoire
        ElseIf GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.GAME_OVER Then
            SupportRendu.Image = GestionDessin.DessinerFrameGameOver
        ElseIf GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.ANIMATION_CHANGEMENT_NIVEAU Then
            SupportRendu.Image = GestionDessin.DessinerAnimationChangementNiveau
        End If

        ' Changement niveau
        ' Ordonne le chargement du niveau suivant
        If GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.CHANGEMENT_NIVEAU Then
            GestionNiveaux.ChargerNiveauSuivant()
            GestionPartie.ReinitialiserTemps()
        ElseIf GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.DECOMPTE_DEBUT_NIVEAU Then
            tempsDebutNiveau = tempsDebutNiveau - 1
            If tempsDebutNiveau = 0 Then
                GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.DEBUT_NIVEAU
                tempsDebutNiveau = tempsDebutNiveauMax
            End If
        ElseIf GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.DECOMPTE_FIN_NIVEAU Then
            tempsFinNiveau = tempsFinNiveau - 1
            If tempsFinNiveau = 0 Then
                GestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.CHANGEMENT_NIVEAU
                tempsFinNiveau = tempsFinNiveauMax
            End If
        End If

        GestionPartie.Tick()

    End Sub


    Public ReadOnly Property GetGestionDessin As MoteurDessin
        Get
            Return GestionDessin
        End Get
    End Property

    Public ReadOnly Property GetGestionSprites As MoteurSprites
        Get
            Return GestionSprites
        End Get
    End Property

    Public ReadOnly Property GetGestionFonctions As MoteurFonction
        Get
            Return GestionFonction
        End Get
    End Property

    Public ReadOnly Property GetGestionDebug As MoteurDebug
        Get
            Return GestionDebug
        End Get
    End Property

    Public ReadOnly Property GetGestionPartie As MoteurPartie
        Get
            Return GestionPartie
        End Get
    End Property

    Public ReadOnly Property GetGestionTextures As MoteurTextures
        Get
            Return GestionTextures
        End Get
    End Property

    Public ReadOnly Property Factory As MoteurFactory
        Get
            Return GestionFactory
        End Get
    End Property

    Public ReadOnly Property ATH As MoteurATH
        Get
            Return GestionATH
        End Get
    End Property

    Public ReadOnly Property GetGestionNiveaux As MoteurNiveaux
        Get
            Return GestionNiveaux
        End Get
    End Property
End Class
