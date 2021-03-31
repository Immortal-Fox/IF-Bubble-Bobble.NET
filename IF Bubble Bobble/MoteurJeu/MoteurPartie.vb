

''' <summary>
''' Moteur de partie (Gère les joueurs, les vies, les points, les crédits etc)
''' </summary>
Public Class MoteurPartie

    Private ReadOnly parent As MoteurJeu

    ' Etat des joueurs
    Private joueur1Mort As Boolean
    Private joueur2Mort As Boolean

    ' Vies et crédits des joueurs
    Private viesJoueur1 As Integer
    Private viesJoueur2 As Integer
    Private credits As Integer
    Private viesJoueursMax As Integer = 6
    Private creditsMax As Integer = 8

    ' Points des joueurs
    Private pointsJoueur1 As Integer = 0
    Private pointsJoueur2 As Integer = 0

    Private meilleursPointsJoueur1 As Integer = 0
    Private meilleursPointsJoueur2 As Integer = 0

    ' Poisition d'apparition des joueurs
    Private positionApparitionJoueur1 As Point
    Private positionApparitionJoueur2 As Point

    ' Ennemi restant
    Private ennemisRestant As Integer

    ' Temps avant acceleration
    Private tempsAvantAcceleration As Integer
    Private tempsAvantEnnemiLaMort As Integer
    Private tempsActuelMax As Integer = 3000
    Private tempsActuel As Integer

    ' La partie est game over
    Private estGameOver As Boolean
    Private estVictoire As Boolean

    ' Information d'avancement des niveaux
    Private niveauActuel As Integer
    Private niveauMax As Integer

    ' Etat de la partie
    Private etatDeLaPartie As ETAT_PARTIE = ETAT_PARTIE.CHANGEMENT_NIVEAU

    ' Nombre de niveaux à passer
    Private nombreNiveauxAPasser As Integer = 0

    ' Informations de l'état des ennemies
    Private vitesseEnnemis As Integer = 2

    ''' <summary>
    ''' Représente un état de la partie
    ''' </summary>
    Public Enum ETAT_PARTIE
        AUCUN
        CHARGEMENT_NIVEAU
        ANIMATION_CHANGEMENT_NIVEAU
        DECOMPTE_DEBUT_NIVEAU
        DEBUT_NIVEAU
        DECOMPTE_FIN_NIVEAU
        CHANGEMENT_NIVEAU
        GAME_OVER
        VICTOIRE
    End Enum

    Sub New(ByRef _parent As MoteurJeu)
        parent = _parent
        positionApparitionJoueur1 = New Point(20, parent.GetGestionDessin.GetHauteurDessin - 60)
        positionApparitionJoueur2 = New Point(640, parent.GetGestionDessin.GetHauteurDessin - 60)
        ReinitialisationPartie()
    End Sub

    ''' <summary>
    ''' Réinitialise les informations de partie
    ''' </summary>
    Public Sub ReinitialisationPartie()

        estGameOver = False
        estVictoire = False
        viesJoueur1 = 3
        viesJoueur2 = 3
        credits = 8
        pointsJoueur1 = 0
        pointsJoueur2 = 0
        meilleursPointsJoueur1 = 0
        meilleursPointsJoueur2 = 0
        ennemisRestant = 0
        niveauActuel = 1
        ReinitialiserTemps()

    End Sub

    ''' <summary>
    ''' Tick d'horloge
    ''' </summary>
    Public Sub Tick()

        If etatDeLaPartie = ETAT_PARTIE.DEBUT_NIVEAU Then
            ' Gestion du temps
            If tempsActuel > 0 Then
                tempsActuel = tempsActuel - 1
            End If
            ' Accélération des ennemis
            If tempsActuel = tempsAvantAcceleration Then
                vitesseEnnemis = 4
                ' Spawn des ennemies de la mort
            ElseIf tempsActuel = tempsAvantEnnemiLaMort Then

            End If
        End If

    End Sub

    ''' <summary>
    ''' Remet le compteur de temps à 0
    ''' </summary>
    Public Sub ReinitialiserTemps()
        tempsActuel = tempsActuelMax
        vitesseEnnemis = 2
    End Sub

    ''' <summary>
    ''' Touche enfoncée du moteur de jeu
    ''' </summary>
    ''' <param name="_ctrl"></param>
    Public Sub KeyDown(ByVal _ctrl As MoteurControleurs.CONTROLS)

        ' Joueur 1 - Clique Action
        If _ctrl = MoteurControleurs.CONTROLS.J1_ACTION Then
            If joueur1Mort Then
                If viesJoueur1 > 0 Then
                    viesJoueur1 = viesJoueur1 - 1
                    joueur1Mort = False
                    CreerPersonnageJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1)
                Else
                    If credits > 0 Then
                        credits = credits - 1
                        viesJoueur1 = 3
                        joueur1Mort = False
                        pointsJoueur1 = 0
                        CreerPersonnageJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1)
                        If viesJoueur2 = 0 And joueur2Mort Then
                            estGameOver = True
                        End If
                    End If
                End If

            End If
        ElseIf _ctrl = MoteurControleurs.CONTROLS.J2_ACTION Then
            If joueur2Mort Then
                If viesJoueur2 > 0 Then
                    viesJoueur2 = viesJoueur2 - 1
                    joueur2Mort = False
                    CreerPersonnageJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2)
                Else
                    If credits > 0 Then
                        credits = credits - 1
                        viesJoueur2 = 3
                        joueur2Mort = False
                        pointsJoueur2 = 0
                        CreerPersonnageJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2)
                    Else
                        If viesJoueur1 = 0 And joueur1Mort Then
                            estGameOver = True
                        End If
                    End If
                End If

            End If
        End If

    End Sub

    ''' <summary>
    ''' Créer un personnage joueur sur son point de réapparition
    ''' </summary>
    ''' <param name="_numeroJoueur"></param>
    Public Sub CreerPersonnageJoueur(ByVal _numeroJoueur As PersonnageJoueur.NUMEROJOUEUR)
        Dim sp As Sprite = New PersonnageJoueur(_numeroJoueur)
        sp.GetDimensions = New Size(40, 40)
        If _numeroJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR1 Then
            sp.GetPosition = positionApparitionJoueur1
        ElseIf _numeroJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR2 Then
            sp.GetPosition = positionApparitionJoueur2
        End If
        parent.GetGestionSprites.AjouterSprite(sp)


    End Sub

    ''' <summary>
    ''' Définir l'état d'un joueur sur mort
    ''' </summary>
    ''' <param name="_numJoueur">Numéro de joueur</param>
    Public Sub SetJoueurMort(ByVal _numJoueur As PersonnageJoueur.NUMEROJOUEUR)
        If _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR1 Then
            joueur1Mort = True
        ElseIf _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR2 Then
            joueur2Mort = True
        End If
    End Sub

    ''' <summary>
    ''' Ajouter des points au joueur
    ''' </summary>
    ''' <param name="_nbrPoints">Nombre de points</param>
    ''' <param name="_numJoueur">Numéro de joueur</param>
    Public Sub AjouterPoints(ByVal _nbrPoints As Integer, ByVal _numJoueur As PersonnageJoueur.NUMEROJOUEUR)
        If _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR1 Then
            pointsJoueur1 = pointsJoueur1 + _nbrPoints
            If pointsJoueur1 > meilleursPointsJoueur1 Then
                meilleursPointsJoueur1 = pointsJoueur1
            End If
        ElseIf _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR2 Then
            pointsJoueur2 = pointsJoueur2 + _nbrPoints
            If pointsJoueur2 > meilleursPointsJoueur2 Then
                meilleursPointsJoueur2 = pointsJoueur2
            End If
        End If
    End Sub

    ''' <summary>
    ''' Effacer les points d'un joueur
    ''' </summary>
    ''' <param name="_numJoueur">Numéro de joueur</param>
    Public Sub EffacerPoints(ByVal _numJoueur As PersonnageJoueur.NUMEROJOUEUR)
        If _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR1 Then
            pointsJoueur1 = 0
        ElseIf _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR2 Then
            pointsJoueur2 = 0
        End If
    End Sub

    ''' <summary>
    ''' Ajouter des vies à un joueur
    ''' </summary>
    ''' <param name="_nbrVies">Nombre de vies</param>
    ''' <param name="_numJoueur">Numéro de joueur</param>
    Public Sub AjouterVie(ByVal _nbrVies As Integer, ByVal _numJoueur As PersonnageJoueur.NUMEROJOUEUR)
        If _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR1 Then

            If viesJoueur1 + _nbrVies <= viesJoueursMax Then
                viesJoueur1 = viesJoueur1 + _nbrVies
            Else
                viesJoueur1 = viesJoueursMax
            End If

        ElseIf _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR2 Then

            If viesJoueur2 + _nbrVies <= viesJoueursMax Then
                viesJoueur2 = viesJoueur2 + _nbrVies
            Else
                viesJoueur2 = viesJoueursMax
            End If
        End If
    End Sub

    ''' <summary>
    ''' Retirer des vies à un joueur
    ''' </summary>
    ''' <param name="_nbrVies">Nombre de vies</param>
    ''' <param name="_numJoueur">Numéro de joueur</param>
    Public Sub RetirerVies(ByVal _nbrVies As Integer, ByVal _numJoueur As PersonnageJoueur.NUMEROJOUEUR)
        If _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR1 Then
            viesJoueur1 = viesJoueur1 - _nbrVies
        ElseIf _numJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR2 Then
            viesJoueur2 = viesJoueur2 - _nbrVies
        End If
    End Sub

    ''' <summary>
    ''' Ajouter des crédits
    ''' </summary>
    ''' <param name="_nbrCredits">Nombre de crédits</param>
    Public Sub AjouterCredits(ByVal _nbrCredits As Integer)
        credits = credits + _nbrCredits
    End Sub

    ''' <summary>
    ''' Retirer des crédits
    ''' </summary>
    ''' <param name="_nbrCredits">Nombre de crédits</param>
    Public Sub RetirerCredits(ByVal _nbrCredits As Integer)
        credits = credits - _nbrCredits
    End Sub

    ''' <summary>
    ''' Ajouter des ennemis au compteur d'ennemis restant
    ''' </summary>
    ''' <param name="_nbrEnnemi">Nombre d'ennemis</param>
    Public Sub AjouterEnnemiRestant(Optional _nbrEnnemi As Integer = 1)
        ennemisRestant = ennemisRestant + _nbrEnnemi
    End Sub

    ''' <summary>
    ''' Retirer des ennemis au compteur d'ennemis restant
    ''' </summary>
    ''' <param name="_nbrEnnemi">Nombre d'ennemis</param>
    Public Sub RetirerEnnemisRestant(Optional _nbrEnnemi As Integer = 1)
        ennemisRestant = ennemisRestant - _nbrEnnemi
        If ennemisRestant = 0 Then
            parent.GetGestionDessin.SetImageDernierNiveau()
            etatDeLaPartie = ETAT_PARTIE.DECOMPTE_FIN_NIVEAU
        End If
    End Sub

    ''' <summary>
    ''' Retourne si la partie est game over
    ''' </summary>
    ''' <returns>Vrai si game over</returns>
    Public ReadOnly Property GetEstGameOver As Boolean
        Get
            Return estGameOver
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property GetEstVictoire As Boolean
        Get
            Return estVictoire
        End Get
        Set(value As Boolean)
            estVictoire = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne le nombre d'ennemis restants
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GetEnnemisRestant As Integer
        Get
            Return ennemisRestant
        End Get
    End Property

    ''' <summary>
    ''' Retourne le score du joueur
    ''' </summary>
    ''' <param name="_numeroJoueur">Numéro de joueur</param>
    ''' <returns>Points du joueur</returns>
    Public ReadOnly Property GetPointsJoueur(ByVal _numeroJoueur As PersonnageJoueur.NUMEROJOUEUR)
        Get
            If _numeroJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR1 Then
                Return pointsJoueur1
            Else
                Return pointsJoueur2
            End If
        End Get
    End Property

    ''' <summary>
    ''' Retourne le meilleur score du joueur
    ''' </summary>
    ''' <param name="_numeroJoueur">Numéro de joueur</param>
    ''' <returns>Meilleurs points du joueur</returns>
    Public ReadOnly Property GetMeilleursPointsJoueur(ByVal _numeroJoueur As PersonnageJoueur.NUMEROJOUEUR)
        Get
            If _numeroJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR1 Then
                Return meilleursPointsJoueur1
            Else
                Return meilleursPointsJoueur2
            End If
        End Get
    End Property

    ''' <summary>
    ''' Retourne le nombre de vies du joueur
    ''' </summary>
    ''' <param name="_numeroJoueur">Numéro de joueur</param>
    ''' <returns>Nombre de vies du joueur</returns>
    Public ReadOnly Property GetViesJoueur(ByVal _numeroJoueur As PersonnageJoueur.NUMEROJOUEUR)
        Get
            If _numeroJoueur = PersonnageJoueur.NUMEROJOUEUR.JOUEUR1 Then
                Return viesJoueur1
            Else
                Return viesJoueur2
            End If
        End Get
    End Property

    ''' <summary>
    ''' Retourne le nombre de crédits restant
    ''' </summary>
    ''' <returns>Nombre de crédits</returns>
    Public ReadOnly Property GetCredits
        Get
            Return credits
        End Get
    End Property

    ''' <summary>
    ''' Obtient ou défini le numéro de niveau actuel
    ''' </summary>
    ''' <returns>Niveau actuel</returns>
    Public Property GetNiveauActuel As Integer
        Get
            Return niveauActuel
        End Get
        Set(value As Integer)
            niveauActuel = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini le nombre de niveau
    ''' </summary>
    ''' <returns>Nombre de niveau</returns>
    Public Property GetNiveauMax As Integer
        Get
            Return niveauMax
        End Get
        Set(value As Integer)
            niveauMax = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défii l'état de la partie
    ''' </summary>
    ''' <returns>Etat de la partie</returns>
    Public Property GetEtatPartie As ETAT_PARTIE
        Get
            Return etatDeLaPartie
        End Get
        Set(value As ETAT_PARTIE)
            etatDeLaPartie = value
        End Set
    End Property

    Public Property GetNombreNiveauxAPasser As Integer
        Get
            Return nombreNiveauxAPasser
        End Get
        Set(value As Integer)
            nombreNiveauxAPasser = value
        End Set
    End Property

    Public Property GetVitesseEnnemis As Integer
        Get
            Return vitesseEnnemis
        End Get
        Set(value As Integer)
            vitesseEnnemis = value
        End Set
    End Property

    Public Property GetTempsRestant As Integer
        Get
            Return tempsActuel
        End Get
        Set(value As Integer)
            tempsActuel = value
        End Set
    End Property

End Class
