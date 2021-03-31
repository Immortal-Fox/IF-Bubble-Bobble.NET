Public Class MonstreFou
    Inherits Ennemi

    Private directionHaut As Boolean = False
    Private directionGauche As Boolean = True
    Private vitesse As Integer
    ' 1 haut gauche
    ' 2 haut droite
    ' 3 bas gauche
    ' 4 bas droite

    Sub New(ByVal _directionGauche As Boolean, ByVal _directionHaut As Boolean)
        vitesse = 2
        directionGauche = _directionGauche
        directionHaut = _directionHaut

        GetVisible = True
        GetTypeSprite = TYPEDESPRITE.ENNEMI
        GetTypeEnnemi = TYPE_ENNEMI.MONSTRE_FOU
        GetIndexTexture = MoteurTextures.TEXTURES.ZOMBIE_BASE

    End Sub

    Public Overrides Sub Tick()
        ' Détection des collisions avec les personnages joueurs
        CollisionJoueur()
        ' Définition de la vitesse
        Dim vitesse As Integer = parent.GetGestionPartie.GetVitesseEnnemis



        If FinDelaiApparition Then
            ' Directions latérales
            If directionGauche Then
                Dim collisionMur As Boolean = False
                ' détection gauche
                For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX - vitesse, GetY, vitesse, GetHauteur))
                    If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME Then
                        GetX = _sprite.GetX + _sprite.GetLargeur
                        collisionMur = True
                        directionGauche = False
                        Exit For
                    End If
                Next
                ' détection haut
                If Not collisionMur Then
                    GetX = GetX - vitesse
                End If
            Else
                Dim collisionMur As Boolean = False
                ' détection droite
                For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX + GetLargeur, GetY, vitesse, GetHauteur))
                    If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME Then
                        GetX = _sprite.GetX - GetLargeur
                        collisionMur = True
                        directionGauche = True
                        Exit For
                    End If
                Next
                ' détection haut
                If Not collisionMur Then
                    GetX = GetX + vitesse
                End If
            End If

            ' Direction haut-bas
            If directionHaut Then
                ' Direction haut
                Dim collisionMur As Boolean = False
                For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX, GetY - vitesse, GetLargeur, vitesse))
                    If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME Then
                        GetY = _sprite.GetY + _sprite.GetHauteur
                        collisionMur = True
                        directionHaut = False
                        Exit For
                    End If

                Next
                If Not collisionMur Then
                    GetY = GetY - vitesse
                End If
            Else
                ' Direction bas
                Dim collisionMur As Boolean = False
                For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX, GetY + GetHauteur, GetLargeur, vitesse))
                    If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME Then
                        GetY = _sprite.GetY - GetHauteur
                        collisionMur = True
                        directionHaut = True
                        Exit For
                    End If

                Next
                If Not collisionMur Then
                    GetY = GetY + vitesse
                End If
            End If
        End If

        ' Si le sprite sort de la zone de jeu
        If FinDelaiApparition Then
            If GetY > 700 Then
                GetY = -100
            ElseIf GetY < -101 Then
                GetY = 650
            End If
        Else
            ' Delai d'apparition
            If GetY < PointApparitionY Then
                GetY = GetY + 3
            Else
                GetY = PointApparitionY
                DelaiApparition = DelaiApparition - 1
                If DelaiApparition = 0 Then
                    FinDelaiApparition = True
                End If
            End If
        End If

        FormMain.Text = directionGauche & " " & directionHaut

    End Sub

    Public Overrides Sub KeyDown(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub KeyUp(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub Collision(_sprite As Sprite)

    End Sub

    Public Overrides Sub Detruire()

    End Sub
End Class
