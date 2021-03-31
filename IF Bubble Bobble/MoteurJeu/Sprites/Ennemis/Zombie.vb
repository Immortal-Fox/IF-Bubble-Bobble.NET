''' <summary>
''' Représente un zombie (ennnemi linéaire)
''' </summary>
Public Class Zombie
    Inherits Ennemi

    ' Private vitesse As Integer = 2
    Private directionGauche As Boolean
    Private chute As Boolean = False
    Private monte As Boolean = False

    Sub New(ByVal _directionGauche As Boolean)
        directionGauche = _directionGauche
        GetVisible = True
        GetTypeSprite = TYPEDESPRITE.ENNEMI
        GetTypeEnnemi = TYPE_ENNEMI.ZOMBIE
    End Sub

    Public Overrides Sub Tick()
        ' Collision avec les personnages joueurs
        Me.CollisionJoueur()
        ' Définition de la vitesse
        Dim vitesse As Integer = parent.GetGestionPartie.GetVitesseEnnemis


        If FinDelaiApparition Then
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
            If directionGauche And Not chute Then
                Dim collisionMur As Boolean = False
                For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX - vitesse, GetY, vitesse, GetHauteur))
                    If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME And Not parent.GetGestionSprites.CompareDeuxSprite(Me, _sprite) Then
                        Me.GetX = _sprite.GetX + _sprite.GetLargeur
                        collisionMur = True
                        directionGauche = False
                        Exit For
                    End If
                Next
                If Not collisionMur Then
                    Me.GetX = Me.GetX - vitesse
                End If
                ' Déplacement à droite
            ElseIf Not directionGauche And Not chute Then
                Dim collisionMur As Boolean = False
                For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX + GetLargeur + vitesse, GetY, vitesse, GetHauteur))
                    If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME And Not parent.GetGestionSprites.CompareDeuxSprite(Me, _sprite) Then
                        Me.GetX = _sprite.GetX - GetLargeur
                        collisionMur = True
                        directionGauche = True
                        Exit For
                    End If
                Next
                If Not collisionMur Then
                    Me.GetX = Me.GetX + vitesse
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

    End Sub

    Public Overrides Sub KeyDown(_control As MoteurControleurs.CONTROLS)
        'Throw New NotImplementedException()
    End Sub

    Public Overrides Sub KeyUp(_control As MoteurControleurs.CONTROLS)
        ' Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Detruire()
        ' Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Collision(_sprite As Sprite)

    End Sub
End Class
