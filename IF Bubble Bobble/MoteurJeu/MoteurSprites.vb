''' <summary>
''' Moteur de gestion des sprites
''' </summary>
Public Class MoteurSprites

    ''' <summary>
    ''' Moteur de jeu parent
    ''' </summary>
    Private parent As MoteurJeu
    ''' <summary>
    ''' Liste des sprites
    ''' </summary>
    Private listeSprites As List(Of Sprite)
    ''' <summary>
    ''' Liste des sprites
    ''' </summary>
    Private listeSpritesSuppression As List(Of Sprite)

    Sub New(ByRef _parent As MoteurJeu)
        parent = _parent
        listeSprites = New List(Of Sprite)
        listeSpritesSuppression = New List(Of Sprite)
    End Sub

    ''' <summary>
    ''' Ajouter un sprite
    ''' </summary>
    ''' <param name="_sprite"></param>
    Public Sub AjouterSprite(ByVal _sprite As Sprite)
        If Not IsNothing(_sprite) Then
            If Not IsNothing(listeSprites) Then

                If _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.ENNEMI And parent.GetGestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.CHANGEMENT_NIVEAU Then
                    CType(_sprite, Ennemi).PointDeDepartDecale()
                    parent.GetGestionPartie.AjouterEnnemiRestant()
                End If

                _sprite.SetParent(parent)
                listeSprites.Add(_sprite)

            End If
        End If
    End Sub

    ''' <summary>
    ''' Supprime le sprite à la fin du tick d'horloge
    ''' </summary>
    ''' <param name="_sprite">Instance du sprite</param>
    Public Sub SupprimerSpriteEndTick(ByVal _sprite As Sprite)
        listeSpritesSuppression.Add(_sprite)
    End Sub

    ''' <summary>
    ''' Supprime les sprites à la fin du tick d'horloge
    ''' </summary>
    Public Sub SupprimerLesSpritesDelai()
        For i As Integer = listeSpritesSuppression.Count - 1 To 0 Step -1
            SupprimerSprite(listeSpritesSuppression(i))
        Next
        listeSpritesSuppression.Clear()
    End Sub

    ''' <summary>
    ''' Supprimer un sprite
    ''' </summary>
    ''' <param name="_sprite">Instance du sprite</param>
    Public Sub SupprimerSprite(ByVal _sprite As Sprite)
        listeSprites.Remove(_sprite)
    End Sub

    ''' <summary>
    ''' Supprime tous les sprites
    ''' </summary>
    Public Sub SupprimerTousLesSprites()
        If Not IsNothing(listeSprites) Then
            listeSprites.Clear()
        End If
    End Sub

    ''' <summary>
    ''' Retourne l'instance du sprite selon l'identifiant
    ''' </summary>
    ''' <param name="_id">Identifiant</param>
    ''' <returns>Instance du sprite</returns>
    Public Function GetSpriteByID(ByVal _id As String)
        If Not IsNothing(listeSprites) Then
            For Each _sprite As Sprite In listeSprites
                If _sprite.GetIdentifiant = _id Then
                    Return _sprite
                End If
            Next
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Vérifie si 2 instances de sprite sont en collision
    ''' </summary>
    ''' <param name="_sprite1">Instance sprite 1</param>
    ''' <param name="_sprite2">Instance sprite 2</param>
    ''' <returns>Vrai si les sprites sont en collision</returns>
    Public Function CompareDeuxSprite(ByVal _sprite1 As Sprite, ByVal _sprite2 As Sprite) As Boolean
        If _sprite1.GetRectangle.IntersectsWith(_sprite2.GetRectangle) Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Retourne le premier sprite trouvé sur le point
    ''' </summary>
    ''' <param name="_point">Point à tester</param>
    ''' <returns>Sprite</returns>
    Public Function GetSpriteDepuisPoint(ByVal _point As Point)
        For Each _sprite As Sprite In listeSprites
            If _point.X > _sprite.GetX And _point.X < _sprite.GetX + _sprite.GetLargeur Then
                If _point.Y > _sprite.GetY And _point.Y < _sprite.GetY + _sprite.GetHauteur Then
                    Return _sprite
                End If
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Obtient la liste des sprites contenu dans un rectangle
    ''' </summary>
    ''' <param name="_rectangle">Rectangle</param>
    ''' <returns>Liste de sprites</returns>
    Public Function GetSpritesDansRectangle(ByVal _rectangle As Rectangle) As List(Of Sprite)
        Dim liste As New List(Of Sprite)
        For Each _sprite As Sprite In listeSprites
            If _sprite.GetRectangle.IntersectsWith(_rectangle) Then
                liste.Add(_sprite)
            End If
        Next
        Return liste
    End Function

    ''' <summary>
    ''' Retourne un boolean indiquant si le sprite est en collision avec un ou plusieurs autres sprites
    ''' </summary>
    ''' <param name="_sprite">Sprite de référence</param>
    ''' <returns>Valeur indiquant si il y'a collision ou non</returns>
    Public Function EstEnCollision(ByVal _sprite As Sprite) As Boolean
        If Not IsNothing(listeSprites) Then
            For Each _sp As Sprite In listeSprites
                If Not _sp Is _sprite Then
                    If _sp.GetRectangle.IntersectsWith(_sprite.GetRectangle) Then
                        Return True
                    End If
                End If
            Next
        End If
        Return False
    End Function


    ''' <summary>
    ''' Obtient la liste des sprites en collision avec un sprite de référence
    ''' </summary>
    ''' <param name="_sprite">Sprite de référence</param>
    ''' <returns>Liste des sprites en collision</returns>
    Public Function GetSpritesEnCollsion(ByVal _sprite As Sprite) As List(Of Sprite)
        If Not IsNothing(listeSprites) Then
            Dim liste As New List(Of Sprite)
            For Each _sp As Sprite In listeSprites
                If Not _sp Is _sprite Then
                    If _sp.GetRectangle.IntersectsWith(_sprite.GetRectangle) Then
                        liste.Add(_sp)
                    End If
                End If
            Next
            Return liste
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Obtient la liste de tous les sprites
    ''' </summary>
    ''' <returns></returns>
    Public Function GetSprites()
        Return listeSprites
    End Function

    ''' <summary>
    ''' Retourne le nombre de sprites
    ''' </summary>
    ''' <returns>Nombre de sprite</returns>
    Public Function GetNombreSprites()
        If Not IsNothing(listeSprites) Then
            Return listeSprites.Count
        Else
            Return 0
        End If
    End Function

End Class
