''' <summary>
''' Représente un objet ramassable
''' </summary>
Public MustInherit Class ObjetRamassable
    Inherits Sprite

    ' Champs protégés de la classe objet ramassable
    Protected chute As Boolean = True
    Protected estStatique As Boolean = False

    Public Overrides Sub Tick()
        ' Effet de chute de l'objet

        ' Si l'objet est toujours en chute
        If chute And Not estStatique Then
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX, GetY + GetHauteur, GetLargeur, 3))
                If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME Then
                    Me.GetY = _sprite.GetY
                    chute = False
                    Exit For
                End If
            Next
            If chute Then
                Me.GetY = Me.GetY + 3
            End If

        End If



    End Sub

    Public Overrides Sub KeyDown(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub KeyUp(_control As MoteurControleurs.CONTROLS)

    End Sub
End Class
