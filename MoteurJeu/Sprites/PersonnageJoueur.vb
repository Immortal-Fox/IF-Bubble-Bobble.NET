''' <summary>
''' Représente un personnage joueur
''' </summary>
Public Class PersonnageJoueur
    Inherits Sprite

    ' Controles pour le joueur
    Private controleHaut As MoteurControleurs.CONTROLS
    Private controleDroite As MoteurControleurs.CONTROLS
    Private controleBas As MoteurControleurs.CONTROLS
    Private controleGauche As MoteurControleurs.CONTROLS
    Private controleAction As MoteurControleurs.CONTROLS
    ' Indique si le controle est "enfoncé"
    Private controleHautDown As Boolean
    Private controleDroiteDown As Boolean
    Private controleBasDown As Boolean
    Private controleGaucheDown As Boolean
    Private controleActionDown As Boolean

    Private numJoueur As NUMEROJOUEUR

    ' Champs d'état du personnage
    Private monte As Boolean
    Private chute As Boolean
    Private regardeAGauche As Boolean
    Private velociteSaut As Integer = 0
    Private vitesse As Integer = 3

    ' Propriétés des bulles
    Private tempsDeRechargementMax As Integer = 60
    Private tempsDeRechargement As Integer = 60

    Private reductionHitboxBulles As Integer = 5

    Public Property GetNumeroJoueur As NUMEROJOUEUR
        Get
            Return numJoueur
        End Get
        Set(value As NUMEROJOUEUR)
            numJoueur = value
        End Set
    End Property

    Public Enum NUMEROJOUEUR
        JOUEUR1
        JOUEUR2
    End Enum

    Sub New(ByVal _numeroJoueur As NUMEROJOUEUR)

        numJoueur = _numeroJoueur

        ' Configuration des contrôles selon le numéro de joueur
        ' Par défaut on applique les contrôles du joueur 1
        If _numeroJoueur = NUMEROJOUEUR.JOUEUR2 Then
            controleHaut = MoteurControleurs.CONTROLS.J2_HAUT
            controleDroite = MoteurControleurs.CONTROLS.J2_DROITE
            controleBas = MoteurControleurs.CONTROLS.J2_BAS
            controleGauche = MoteurControleurs.CONTROLS.J2_GAUCHE
            controleAction = MoteurControleurs.CONTROLS.J2_ACTION
            GetIdentifiant = "Joueur2"
        Else
            controleHaut = MoteurControleurs.CONTROLS.J1_HAUT
            controleDroite = MoteurControleurs.CONTROLS.J1_DROITE
            controleBas = MoteurControleurs.CONTROLS.J1_BAS
            controleGauche = MoteurControleurs.CONTROLS.J1_GAUCHE
            controleAction = MoteurControleurs.CONTROLS.J1_ACTION
            GetIdentifiant = "Joueur1"
        End If

        GetVisible = True
        GetTypeSprite = TYPEDESPRITE.PERSONNAGEJOUEUR
    End Sub

    ''' <summary>
    ''' Tick d'horloge
    ''' </summary>
    Public Overrides Sub Tick()

        ' Gravité vers le bas si le joueur n'a pas sauté
        If Not monte Then
            Dim surUnePlateforme As Boolean = False
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX, GetY + GetHauteur + vitesse, GetLargeur, vitesse))
                If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME Then
                    surUnePlateforme = True
                    Me.GetY = _sprite.GetY - GetHauteur
                    chute = False
                    Exit For
                End If
            Next
            If Not surUnePlateforme Then
                Me.GetY += vitesse
                chute = True
            End If
        End If

        ' Déplacement à gauche
        If controleGaucheDown And Not controleDroiteDown Then
            Dim collisionMur As Boolean = False
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX - vitesse, GetY, vitesse, GetHauteur))
                If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME And Not parent.GetGestionSprites.CompareDeuxSprite(Me, _sprite) Then
                    Me.GetX = _sprite.GetX + _sprite.GetLargeur
                    collisionMur = True
                    Exit For
                End If
            Next
            If Not collisionMur Then
                Me.GetX = Me.GetX - vitesse
            End If
            regardeAGauche = True
        End If

        ' Déplacement à droite
        If controleDroiteDown And Not controleGaucheDown Then
            Dim collisionMur As Boolean = False
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX + GetLargeur + vitesse, GetY, vitesse, GetHauteur))
                If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME And Not parent.GetGestionSprites.CompareDeuxSprite(Me, _sprite) Then
                    Me.GetX = _sprite.GetX - GetLargeur
                    collisionMur = True
                    Exit For
                End If
            Next
            If Not collisionMur Then
                Me.GetX = Me.GetX + vitesse
            End If
            regardeAGauche = False
        End If

        ' Saut
        If controleHautDown Then
            If Not chute And Not monte Then
                velociteSaut = 50
                monte = True
            End If
        End If

        If monte Then
            Me.GetY = Me.GetY - CInt(velociteSaut / 5)
            velociteSaut = velociteSaut - 2
            If velociteSaut = 0 Then
                monte = False
                chute = True
            End If
        End If

        ' Détection objets dans la hitbox interne
        For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX + reductionHitboxBulles, GetY + reductionHitboxBulles, GetLargeur - (2 * reductionHitboxBulles), GetHauteur - (2 * reductionHitboxBulles)))
            If _sprite.GetTypeSprite = TYPEDESPRITE.BULLE Or _sprite.GetTypeSprite = TYPEDESPRITE.OBJETRAMASSABLE Then
                _sprite.Collision(Me)
            End If
        Next


        ' Action
        If controleActionDown And tempsDeRechargement = tempsDeRechargementMax Then
            ' Si le personnage regarde à gauche
            If regardeAGauche Then
                Dim spb As New BulleNormale(True)
                spb.GetRectangle = New Rectangle(Me.GetX - Me.GetLargeur, Me.GetY, Me.GetLargeur, Me.GetHauteur)
                parent.GetGestionSprites.AjouterSprite(spb)
                tempsDeRechargement = 0
            Else
                Dim spb As New BulleNormale(False)
                spb.GetRectangle = New Rectangle(Me.GetX + Me.GetLargeur, Me.GetY, Me.GetLargeur, Me.GetHauteur)
                parent.GetGestionSprites.AjouterSprite(spb)
                tempsDeRechargement = 0
            End If
        End If

        If tempsDeRechargement < tempsDeRechargementMax Then
            tempsDeRechargement = tempsDeRechargement + 1
        End If

        ' Si le joueur sort de la zone de jeu
        If GetY > 700 Then
            GetY = -100
        ElseIf GetY < -101 Then
            GetY = 650
        End If

    End Sub

    Public Overrides Sub Detruire()
        parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
    End Sub

    Public Overrides Sub KeyDown(_control As MoteurControleurs.CONTROLS)

        If _control = controleHaut Then
            controleHautDown = True
        ElseIf _control = controleDroite Then
            controleDroiteDown = True
        ElseIf _control = controleBas Then
            controleBasDown = True
        ElseIf _control = controleGauche Then
            controleGaucheDown = True
        ElseIf _control = controleAction Then
            controleActionDown = True
        End If

    End Sub

    Public Overrides Sub KeyUp(_control As MoteurControleurs.CONTROLS)

        If _control = controleHaut Then
            controleHautDown = False
        ElseIf _control = controleDroite Then
            controleDroiteDown = False
        ElseIf _control = controleBas Then
            controleBasDown = False
        ElseIf _control = controleGauche Then
            controleGaucheDown = False
        ElseIf _control = controleAction Then
            controleActionDown = False
        End If

    End Sub

    Public Overrides Sub Collision(_sprite As Sprite)

    End Sub

End Class
