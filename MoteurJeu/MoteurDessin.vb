Public Class MoteurDessin

    Private parent As MoteurJeu

    ' Dimensions de la scène
    Private largeurDessin As Integer
    Private hauteurDessin As Integer

    ' Paramètres Dessin
    Private couleurFond As Color = Color.SandyBrown
    Private profondeurOmbres As Integer = 3
    Private couleurOmbres As Color = Color.Black
    Private couleurLumieres As Color = Color.Silver
    Private texturePlateforme As MoteurTextures.TEXTURES
    ' Paramètres performances
    Private afficherOmbresPlateforme As Boolean = True
    ' Paramètres ATH
    Private afficherATH As Boolean = True

    ' Debug info
    Private FPS As Integer
    Private debugLastTimeUpdate As Date

    ' Espacement pour ATH
    Dim decalageHaut As Integer = 40

    ' Animation de changement de niveau
    Private imageDernierNiveau As Bitmap
    Private imageNiveauSuivant As Bitmap
    Private animationEtape As Integer = 700
    Private animationVitesse As Integer = 10

    Sub New(ByRef _parent As MoteurJeu)
        parent = _parent
        largeurDessin = 700
        hauteurDessin = 700
        texturePlateforme = MoteurTextures.TEXTURES.PLATEFORME_1
    End Sub

    Public Overloads Sub SetDimensionScene(ByVal _largeur As Integer, ByVal _hauteur As Integer)
        largeurDessin = _largeur
        hauteurDessin = _hauteur
    End Sub

    Public Overloads Sub SetDimensionScene(ByVal _dimension As Size)
        largeurDessin = _dimension.Width
        hauteurDessin = _dimension.Height
    End Sub

    Public Sub SetImageDernierNiveau()
        If Not IsNothing(imageDernierNiveau) Then
            imageDernierNiveau.Dispose()
        End If
        imageDernierNiveau = DessinerSeulementPlateforme()
    End Sub

    Public Sub SetImageNiveauSuivant()
        If Not IsNothing(imageNiveauSuivant) Then
            imageNiveauSuivant.Dispose()
        End If
        imageNiveauSuivant = DessinerSeulementPlateforme()
    End Sub

    Public Function DessinerAnimationChangementNiveau()
        Dim bmp As New Bitmap(largeurDessin, hauteurDessin + decalageHaut)
        Dim g As Graphics = Graphics.FromImage(bmp)
        ' image dernier niveau
        If Not IsNothing(imageDernierNiveau) Then
            g.DrawImage(imageDernierNiveau, New Rectangle(0, 0 - (700 - animationEtape), largeurDessin, hauteurDessin))
        End If
        If Not IsNothing(imageNiveauSuivant) Then
            g.DrawImage(imageNiveauSuivant, New Rectangle(0, animationEtape, largeurDessin, hauteurDessin))
        End If


        ' Dessin ATH
        If afficherATH Then
            ' Système ATH temporaire
            g.FillRectangle(New SolidBrush(Color.Black), New RectangleF(0, hauteurDessin, largeurDessin, decalageHaut))
            ' Image des personnages joueurs
            g.DrawImage(parent.GetGestionTextures.GetTexture(MoteurTextures.TEXTURES.JOUEUR1_BASE_DROITE_1), 0, 700, 40, 40)
            g.DrawImage(parent.GetGestionTextures.GetTexture(MoteurTextures.TEXTURES.JOUEUR1_BASE_GAUCHE_1), 660, 700, 40, 40)
            ' Textes points
            g.DrawString(parent.GetGestionPartie.GetPointsJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1), New Font("Consolas", 12), New SolidBrush(Color.White), 40, 720)
            Dim sfp As New StringFormat
            sfp.Alignment = StringAlignment.Far
            g.DrawString(parent.GetGestionPartie.GetPointsJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2), New Font("Consolas", 12), New SolidBrush(Color.White), New Rectangle(500, 720, 160, 20), sfp)
            ' Texte central (niveau et crédits)
            Dim sfn As StringFormat = New StringFormat
            sfn.LineAlignment = StringAlignment.Center
            sfn.Alignment = StringAlignment.Center
            g.DrawString(parent.GetGestionPartie.GetNiveauActuel & vbCrLf & "Crédits : " & parent.GetGestionPartie.GetCredits, New Font("Consolas", 14), New SolidBrush(Color.White), New Rectangle(0, hauteurDessin, largeurDessin, decalageHaut), sfn)
            ' Dessin des vies des joueurs
            Dim rectVies As New Rectangle(40, 700, 20, 20)
            For i As Integer = 1 To parent.GetGestionPartie.GetViesJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1)
                g.FillEllipse(New SolidBrush(Color.Green), rectVies)
                rectVies.X = rectVies.X + 20
            Next
            rectVies.X = 638
            For i As Integer = 1 To parent.GetGestionPartie.GetViesJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2)
                g.FillEllipse(New SolidBrush(Color.LightBlue), rectVies)
                rectVies.X = rectVies.X - 20
            Next
        End If

        animationEtape = animationEtape - animationVitesse

        If animationEtape <= 0 Then
            parent.GetGestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.DECOMPTE_DEBUT_NIVEAU
            animationEtape = 700
        End If

        g.Dispose()
        Return bmp
    End Function

    ''' <summary>
    ''' Retourne l'image du tableau des scores game over
    ''' </summary>
    ''' <returns></returns>
    Public Function DessinerFrameGameOver() As Bitmap

        Dim bmp As New Bitmap(largeurDessin, hauteurDessin)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.Black)
        g.DrawString("GAME OVER", New Font("Consolas", 30), New SolidBrush(Color.Red), New Rectangle(0, 0, largeurDessin, hauteurDessin))

        g.Dispose()
        Return bmp
    End Function

    ''' <summary>
    ''' Retourne l'image du tableau des scores victoire
    ''' </summary>
    ''' <returns></returns>
    Public Function DessinerFrameVictoire() As Bitmap
        Dim bmp As New Bitmap(largeurDessin, hauteurDessin)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.Black)
        g.DrawString("VICTOIRE", New Font("Consolas", 30), New SolidBrush(Color.Green), New Rectangle(0, 0, largeurDessin, hauteurDessin))

        g.Dispose()
        Return bmp
    End Function

    ''' <summary>
    ''' Retourne une image ne contenant que les plateformes
    ''' </summary>
    ''' <returns>Image</returns>
    Public Function DessinerSeulementPlateforme() As Bitmap
        Dim bmp As Bitmap = New Bitmap(largeurDessin, hauteurDessin)
        Dim g As Graphics = Graphics.FromImage(bmp)



        g.Clear(couleurFond)

        If afficherOmbresPlateforme Then
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSprites
                If _sprite.GetVisible And _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.PLATEFORME Then

                    g.FillRectangle(New SolidBrush(couleurLumieres), _sprite.GetX - profondeurOmbres, _sprite.GetY - profondeurOmbres, _sprite.GetLargeur + profondeurOmbres * 2, _sprite.GetHauteur + profondeurOmbres)
                    g.FillRectangle(New SolidBrush(couleurOmbres), _sprite.GetX, _sprite.GetY, _sprite.GetLargeur + profondeurOmbres, _sprite.GetHauteur + profondeurOmbres)

                End If
            Next
        End If

        For Each _sprite As Sprite In parent.GetGestionSprites.GetSprites
            If _sprite.GetVisible Then
                If _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.PLATEFORME Then
                    Dim tBrush As TextureBrush = New TextureBrush(parent.GetGestionTextures.GetTexture(texturePlateforme))
                    tBrush.WrapMode = Drawing2D.WrapMode.Tile
                    g.FillRectangle(tBrush, _sprite.GetRectangle)
                    tBrush.Dispose()
                End If
            End If
        Next


        g.Dispose()
        Return bmp
    End Function

    ''' <summary>
    ''' Retourne l'image de l'état du jeu actuel
    ''' </summary>
    ''' <returns></returns>
    Public Function DessinerFrame()

        Dim bmp As New Bitmap(largeurDessin, hauteurDessin + decalageHaut)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(couleurFond)

        ' Paramètres de qualité
        'g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        'g.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
        'g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        'g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        If Not IsNothing(parent.GetGestionSprites.GetSprites) Then

            If afficherOmbresPlateforme Then
                For Each _sprite As Sprite In parent.GetGestionSprites.GetSprites
                    If _sprite.GetVisible And _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.PLATEFORME Then

                        g.FillRectangle(New SolidBrush(couleurLumieres), _sprite.GetX - profondeurOmbres, _sprite.GetY - profondeurOmbres, _sprite.GetLargeur + profondeurOmbres * 2, _sprite.GetHauteur + profondeurOmbres)
                        g.FillRectangle(New SolidBrush(couleurOmbres), _sprite.GetX, _sprite.GetY, _sprite.GetLargeur + profondeurOmbres, _sprite.GetHauteur + profondeurOmbres)

                    End If
                Next
            End If

            ' Dessin des sprites
            For Each _sprite As Sprite In parent.GetGestionSprites.GetSprites
                If _sprite.GetVisible Then
                    If _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.PLATEFORME Then
                        Dim tBrush As TextureBrush = New TextureBrush(parent.GetGestionTextures.GetTexture(texturePlateforme))
                        tBrush.WrapMode = Drawing2D.WrapMode.Tile
                        g.FillRectangle(tBrush, _sprite.GetRectangle)
                        tBrush.Dispose()
                    ElseIf _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.PERSONNAGEJOUEUR Or _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.BULLE Or _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.ENNEMI Or _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.PROJECTILE Or _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.OBJETRAMASSABLE Then
                        g.DrawImage(parent.GetGestionTextures.GetTexture(_sprite.GetIndexTexture), _sprite.GetRectangle)
                    ElseIf _sprite.GetTypeSprite = Sprite.TYPEDESPRITE.TEXTEFLOTTANT Then
                        ' Texte Flottant
                        Dim tf As TexteFlottant = CType(_sprite, TexteFlottant)
                        g.DrawString(tf.GetTexte, tf.GetPoliceTexte, New SolidBrush(tf.GetCouleurTexte), tf.GetPosition)
                    End If
                End If
            Next

            ' Dessin ATH
            If afficherATH Then
                ' Système ATH temporaire
                g.FillRectangle(New SolidBrush(Color.Black), New RectangleF(0, hauteurDessin, largeurDessin, decalageHaut))
                ' Image des personnages joueurs
                g.DrawImage(parent.GetGestionTextures.GetTexture(MoteurTextures.TEXTURES.JOUEUR1_BASE_DROITE_1), 0, 700, 40, 40)
                g.DrawImage(parent.GetGestionTextures.GetTexture(MoteurTextures.TEXTURES.JOUEUR1_BASE_GAUCHE_1), 660, 700, 40, 40)
                ' Textes points
                g.DrawString(parent.GetGestionPartie.GetPointsJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1), New Font("Consolas", 12), New SolidBrush(Color.White), 40, 720)
                Dim sfp As New StringFormat
                sfp.Alignment = StringAlignment.Far
                g.DrawString(parent.GetGestionPartie.GetPointsJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2), New Font("Consolas", 12), New SolidBrush(Color.White), New Rectangle(500, 720, 160, 20), sfp)
                ' Texte central (niveau et crédits)
                Dim sfn As StringFormat = New StringFormat
                sfn.LineAlignment = StringAlignment.Center
                sfn.Alignment = StringAlignment.Center
                g.DrawString(parent.GetGestionPartie.GetNiveauActuel & vbCrLf & "Crédits : " & parent.GetGestionPartie.GetCredits, New Font("Consolas", 14), New SolidBrush(Color.White), New Rectangle(0, hauteurDessin, largeurDessin, decalageHaut), sfn)
                ' Dessin des vies des joueurs
                Dim rectVies As New Rectangle(40, 700, 20, 20)
                For i As Integer = 1 To parent.GetGestionPartie.GetViesJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1)
                    g.FillEllipse(New SolidBrush(Color.Green), rectVies)
                    rectVies.X = rectVies.X + 20
                Next
                rectVies.X = 638
                For i As Integer = 1 To parent.GetGestionPartie.GetViesJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2)
                    g.FillEllipse(New SolidBrush(Color.LightBlue), rectVies)
                    rectVies.X = rectVies.X - 20
                Next
            End If

            ' Texte debug
            If parent.GetGestionDebug.GetAffichageTexteDebug Then
                g.DrawString(parent.GetGestionDebug.GetTexteDebug, New Font("Consolas", 12), New SolidBrush(Color.Black), 20, 20)
            End If

        End If

        If Not IsNothing(debugLastTimeUpdate) Then
            FPS = CInt(1000 / (Date.Now.Subtract(debugLastTimeUpdate).TotalMilliseconds))
        End If
        debugLastTimeUpdate = Date.Now

        g.Dispose()
        Return bmp
    End Function

    Public Property GetFPS As Integer
        Get
            Return FPS
        End Get
        Set(value As Integer)
            FPS = value
        End Set
    End Property

    Public Property GetLargeurDessin As Integer
        Get
            Return largeurDessin
        End Get
        Set(value As Integer)
            largeurDessin = value
        End Set
    End Property

    Public Property GetHauteurDessin As Integer
        Get
            Return hauteurDessin
        End Get
        Set(value As Integer)
            hauteurDessin = value
        End Set
    End Property

    Public Property GetAfficherATH As Boolean
        Get
            Return afficherATH
        End Get
        Set(value As Boolean)
            afficherATH = value
        End Set
    End Property

    Public Property GetAfficherOmbesPlateforme As Boolean
        Get
            Return afficherOmbresPlateforme
        End Get
        Set(value As Boolean)
            afficherOmbresPlateforme = value
        End Set
    End Property
    Public Property GetTexturePlateforme As MoteurTextures.TEXTURES
        Get
            Return texturePlateforme
        End Get
        Set(value As MoteurTextures.TEXTURES)
            texturePlateforme = value
        End Set
    End Property
    Public Property GetCouleurFond As Color
        Get
            Return couleurFond
        End Get
        Set(value As Color)
            couleurFond = value
        End Set
    End Property

    Public Property GetCouleurOmbres As Color
        Get
            Return couleurOmbres
        End Get
        Set(value As Color)
            couleurOmbres = value
        End Set
    End Property

    Public Property GetCouleurLumieres As Color
        Get
            Return couleurLumieres
        End Get
        Set(value As Color)
            couleurLumieres = value
        End Set
    End Property

    Public Property GetProfondeurOmbes As Integer
        Get
            Return profondeurOmbres
        End Get
        Set(value As Integer)
            profondeurOmbres = value
        End Set
    End Property

End Class
