Public MustInherit Class Ennemi
    Inherits Sprite

    Private _typeEnnemi As TYPE_ENNEMI

    Private DecalageApparition As Integer = 200
    Protected FinDelaiApparition As Boolean = True
    Protected DelaiApparition As Integer = 100
    Protected PointApparitionY As Integer
    ''' <summary>
    ''' Recherche de collision avec les personnages joueurs
    ''' </summary>
    Public Sub CollisionJoueur()

        For Each _sprite As Sprite In parent.GetGestionSprites.GetSpritesDansRectangle(GetRectangle)
            If _sprite.GetTypeSprite = TYPEDESPRITE.PERSONNAGEJOUEUR Then
                ' Destruction du sprite du joueur
                parent.GetGestionSprites.SupprimerSpriteEndTick(_sprite)
                parent.GetGestionPartie.SetJoueurMort(CType(_sprite, PersonnageJoueur).GetNumeroJoueur)
            End If
        Next


    End Sub

    ''' <summary>
    ''' Défini le point de départ décalé du sprite ennemi
    ''' </summary>
    Public Sub PointDeDepartDecale()
        FinDelaiApparition = False
        PointApparitionY = GetY
        GetY = 0 - (700 - GetY)
    End Sub

    Public Property GetTypeEnnemi As TYPE_ENNEMI
        Get
            Return _typeEnnemi
        End Get
        Set(value As TYPE_ENNEMI)
            _typeEnnemi = value
        End Set
    End Property



    Enum TYPE_ENNEMI
        ZOMBIE
        MONSTRE_FOU
    End Enum
End Class
