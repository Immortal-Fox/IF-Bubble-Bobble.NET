''' <summary>
''' Un ennemi mort qui valse à travers le niveau
''' </summary>
Public Class EnnemiMort
    Inherits Projectile

    Private velocite As Integer = 200
    Private chute As Boolean
    Private typeEnnemi As Ennemi.TYPE_ENNEMI

    ' Chute Minimum
    Private tempsChuteMinimum As Integer = 100
    Sub New(ByVal _typeEnnemi As Ennemi.TYPE_ENNEMI)


        ' dev
        chute = True
        GetVisible = True
        typeEnnemi = _typeEnnemi
        GetIndexTexture = MoteurTextures.TEXTURES.NO_TEXTURE
        GetTypeSprite = TYPEDESPRITE.PROJECTILE
    End Sub

    Public Overrides Sub Tick()


        If chute Then
            If tempsChuteMinimum = 0 Then
                For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX, GetY + GetLargeur, GetLargeur, 2))
                    If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME And Not parent.GetGestionSprites.CompareDeuxSprite(_sprite, Me) Then
                        parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
                        parent.Factory.Objets.CreerObjetBonusPoints(GetX, GetY, ObjetBonusPoints.TYPE_OBJET_BONUS_POINT.BANANE)

                        Exit For
                    End If
                Next
            Else
                tempsChuteMinimum = tempsChuteMinimum - 1
            End If

            Me.GetY = Me.GetY + 2

        End If

        If GetY > 750 Then
            GetY = -50
        End If


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
