Public Class Plateforme
    Inherits Sprite

    Sub New()
        GetVisible = True
        GetTypeSprite = TYPEDESPRITE.PLATEFORME
        GetIndexTexture = MoteurTextures.TEXTURES.PLATEFORME_1
    End Sub

    Public Overrides Sub Tick()

    End Sub

    Public Overrides Sub KeyDown(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub KeyUp(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub Detruire()
        parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
    End Sub

    Public Overrides Sub Collision(_sprite As Sprite)

    End Sub


End Class
