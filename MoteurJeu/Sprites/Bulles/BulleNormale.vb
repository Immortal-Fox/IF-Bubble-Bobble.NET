Public Class BulleNormale
    Inherits Bulle


    ' Informations de l'ennemi contenu dans la bulle
    Private reductionHitbox As Integer = 0
    Private typeEnnemi As Ennemi.TYPE_ENNEMI
    Private contientEnnemi As Boolean = False
    Private tempsRestantLiberationMax As Integer = 1000
    Private tempsRestantLiberation As Integer = 500
    ' Temps de vie de la bulle 

    Sub New(ByVal _directionGauche As Boolean)
        GetVisible = True
        directionGauche = _directionGauche
        Me.GetLargeur = 40
        Me.GetHauteur = 40
        Me.GetTypeSprite = TYPEDESPRITE.BULLE
        Me.GetIndexTexture = MoteurTextures.TEXTURES.BULLE_NORMALE
    End Sub

    Public Overrides Sub Tick()

        Dim velocite As Integer = CInt(velociteLaterale / 10)

        ' Réduction du temps de libération
        If contientEnnemi Then
            tempsRestantLiberation = tempsRestantLiberation - 1
            If tempsRestantLiberation = 0 Then
                Liberation()
            End If
        End If

        If monte Then
            Me.GetY = GetY - 1
        End If

        ' Si la bulle rencontre un ennemi
        If Not monte Then
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(GetRectangle)
                'For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX + reductionHitbox, GetY + reductionHitbox, GetLargeur - (2 * reductionHitbox), GetHauteur - (2 * GetHauteur)))
                If _sprite.GetTypeSprite = TYPEDESPRITE.ENNEMI Then
                    typeEnnemi = CType(_sprite, Ennemi).GetTypeEnnemi
                    parent.GetGestionSprites.SupprimerSpriteEndTick(_sprite)
                    contientEnnemi = True
                    monte = True
                    tempsRestantLiberation = tempsRestantLiberationMax
                    Me.GetPosition = _sprite.GetPosition
                    Exit For
                End If
            Next

        End If

        If directionGauche And Not monte Then
            Dim collisionMur As Boolean = False
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX - velocite, GetY, velocite, GetHauteur))
                If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME And Not parent.GetGestionSprites.CompareDeuxSprite(Me, _sprite) Then
                    Me.GetX = _sprite.GetX + _sprite.GetLargeur
                    collisionMur = True
                    monte = True
                    Exit For
                End If
            Next
            If Not collisionMur Then
                Me.GetX = Me.GetX - velocite
                velociteLaterale = velociteLaterale - 4
                If velociteLaterale = 0 Then
                    monte = True
                End If
            End If
        ElseIf Not monte Then
            Dim collisionMur As Boolean = False
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX + GetLargeur + velocite, GetY, velocite, GetHauteur))
                If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME And Not parent.GetGestionSprites.CompareDeuxSprite(Me, _sprite) Then
                    Me.GetX = _sprite.GetX - GetLargeur
                    collisionMur = True
                    monte = True
                    Exit For
                End If
            Next
            If Not collisionMur Then
                Me.GetX = Me.GetX + velocite
                velociteLaterale = velociteLaterale - 4
                If velociteLaterale = 0 Then
                    monte = True
                End If
            End If
        End If



        ' Destruction de la bulle si elle est trop haute
        If Me.GetY < -70 Then
            If Not contientEnnemi Then
                Detruire()
            Else
                Me.GetY = 700
            End If
        End If




    End Sub

    Public Sub Liberation()
        parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
        Dim sp As Sprite
        ' Type d'ennemi
        If typeEnnemi = Ennemi.TYPE_ENNEMI.ZOMBIE Then
            sp = New Zombie(False)
        ElseIf typeEnnemi = Ennemi.TYPE_ENNEMI.MONSTRE_FOU Then
            sp = New MonstreFou(False, False)
        End If
        ' Configuration du sprite
        sp.GetRectangle = New Rectangle(GetX, GetY, 40, 40)
        parent.GetGestionSprites.AjouterSprite(sp)
    End Sub

    Public Overrides Sub Detruire()
        parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
    End Sub

    Public Overrides Sub KeyDown(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub KeyUp(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub Collision(_sprite As Sprite)

        ' Si la bulle ne contient aucun ennemi
        If contientEnnemi Then
            parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
            parent.Factory.Projectiles.CreerEnnemiMort(GetX, GetY, typeEnnemi)
            parent.GetGestionPartie.AjouterPoints(100, CType(_sprite, PersonnageJoueur).GetNumeroJoueur)
            parent.GetGestionPartie.RetirerEnnemisRestant()

        Else
            parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
            parent.GetGestionPartie.AjouterPoints(10, CType(_sprite, PersonnageJoueur).GetNumeroJoueur)
        End If



    End Sub
End Class
