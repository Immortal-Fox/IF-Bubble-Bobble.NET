Public Class ObjetBanane
    Inherits ObjetRamassable

    Private tempsObjet As Integer = 700
    Private pointBonus As Integer = 0
    Sub New()

        GetVisible = True
        GetIndexTexture = MoteurTextures.TEXTURES.OBJET_BANANE
        GetTypeSprite = TYPEDESPRITE.OBJETRAMASSABLE
        pointBonus = 1000

    End Sub


    Public Overrides Sub Tick()

        tempsObjet = tempsObjet - 1
        If tempsObjet = 0 Then
            parent.GetGestionSprites.SupprimerSpriteEndTick(Me)

        End If


    End Sub

    Public Overrides Sub KeyDown(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub KeyUp(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub Collision(_sprite As Sprite)
        parent.GetGestionPartie.AjouterPoints(pointBonus, CType(_sprite, PersonnageJoueur).GetNumeroJoueur)
        parent.Factory.Textes.CreerTextePoints("+" & pointBonus, Me.GetPosition)
        parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
    End Sub

    Public Overrides Sub Detruire()

    End Sub
End Class
