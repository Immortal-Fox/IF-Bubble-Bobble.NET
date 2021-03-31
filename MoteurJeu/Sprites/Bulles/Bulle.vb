Public MustInherit Class Bulle
    Inherits Sprite

    Protected directionGauche As Boolean = False
    Protected monte As Boolean = False
    Protected velociteLaterale As Integer = 100

    ''' <summary>
    ''' Physique de la bulle
    ''' </summary>
    Protected Sub PhysiqueBulle()



        If monte Then

        End If

        If directionGauche And Not monte Then
            Dim collisionMur As Boolean = False
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(New Rectangle(GetX - 3, GetY, 3, GetHauteur))
                If _sprite.GetTypeSprite = TYPEDESPRITE.PLATEFORME And Not parent.GetGestionSprites.CompareDeuxSprite(Me, _sprite) Then
                    Me.GetX = _sprite.GetX + _sprite.GetLargeur
                    collisionMur = True
                    Exit For
                End If
            Next
            If Not collisionMur Then
                Me.GetX = Me.GetX - CInt(velociteLaterale / 3)
                velociteLaterale = velociteLaterale - 3
            End If
        End If







    End Sub


End Class
