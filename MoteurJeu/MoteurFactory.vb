''' <summary>
''' Factory du moteur de jeu
''' </summary>
Public Class MoteurFactory
    Private ReadOnly parent As MoteurJeu

    ' Classes privées
    Private F_Plateformes As Factory_Plateforme
    Private F_Ennemis As Factory_Ennemi
    Private F_Projectiles As Factory_Projectile
    Private F_Objets As Factory_Objet
    Private F_Textes As Factory_Texte

    Sub New(ByRef _parent As MoteurJeu)
        parent = _parent
        ' Instanciation des modules
        F_Plateformes = New Factory_Plateforme(parent)
        F_Ennemis = New Factory_Ennemi(parent)
        F_Projectiles = New Factory_Projectile(parent)
        F_Objets = New Factory_Objet(parent)
        F_Textes = New Factory_Texte(parent)
    End Sub

    ''' <summary>
    ''' Accès aux méthodes de création de plateformes
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Plateformes As Factory_Plateforme
        Get
            Return F_Plateformes
        End Get
    End Property
    ''' <summary>
    ''' Accès aux méthodes de création d'ennemis
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Ennemis As Factory_Ennemi
        Get
            Return F_Ennemis
        End Get
    End Property
    ''' <summary>
    ''' Accès aux méthodes de création de projectiles
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Projectiles As Factory_Projectile
        Get
            Return F_Projectiles
        End Get
    End Property
    ''' <summary>
    ''' Accès aux méthodes de création d'objets ramassables
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Objets As Factory_Objet
        Get
            Return F_Objets
        End Get
    End Property
    ''' <summary>
    ''' Accès aux méthodes de création de textes flottants
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Textes As Factory_Texte
        Get
            Return F_Textes
        End Get
    End Property


    ''' <summary>
    ''' Module factory pour créer des plateformes
    ''' </summary>
    Public Class Factory_Plateforme
        Private ReadOnly parent As MoteurJeu

        Public Enum STRUCTURE_PLATEFORME
            NORMALE_FERMEE
        End Enum

        Sub New(ByRef _parent As MoteurJeu)
            parent = _parent
        End Sub

        Public Sub CreerStructurePlateforme(ByVal _structure As STRUCTURE_PLATEFORME)
            If _structure = 0 Then

                Dim spTop As New Plateforme
                spTop.GetRectangle = New Rectangle(0, 0, 700, 20)

                Dim spBot As New Plateforme
                spBot.GetRectangle = New Rectangle(0, 680, 700, 20)

                Dim spLeft As New Plateforme
                spLeft.GetRectangle = New Rectangle(0, 20, 20, 660)

                Dim spRight As New Plateforme
                spRight.GetRectangle = New Rectangle(680, 20, 20, 660)

                parent.GetGestionSprites.AjouterSprite(spTop)
                parent.GetGestionSprites.AjouterSprite(spBot)
                parent.GetGestionSprites.AjouterSprite(spLeft)
                parent.GetGestionSprites.AjouterSprite(spRight)

            End If

        End Sub

        Public Overloads Sub CreerPlateformeSimple(ByVal _x As Integer, ByVal _y As Integer, ByVal _largeur As Integer, ByVal _hauteur As Integer)
            CreerPlateformeSimple(New Rectangle(_x, _y, _largeur, _hauteur))
        End Sub

        Public Overloads Sub CreerPlateformeSimple(ByVal _position As Point, ByVal _dimensions As Size)
            CreerPlateformeSimple(New Rectangle(_position.X, _position.Y, _dimensions.Width, _dimensions.Height))
        End Sub

        Public Overloads Sub CreerPlateformeSimple(ByVal _rectangle As Rectangle)
            Dim sp As Sprite = New Plateforme()
            sp.GetRectangle = _rectangle
            parent.GetGestionSprites.AjouterSprite(sp)
        End Sub

    End Class

    ''' <summary>
    ''' Module factory pour créer des ennemies
    ''' </summary>
    Public Class Factory_Ennemi
        Private ReadOnly parent As MoteurJeu

        Sub New(ByVal _parent As MoteurJeu)
            parent = _parent
        End Sub

        ''' <summary>
        ''' Créer un Zombie
        ''' </summary>
        ''' <param name="_x"></param>
        ''' <param name="_y"></param>
        ''' <param name="_directionGauche"></param>
        Public Sub CreerZombie(ByVal _x As Integer, ByVal _y As Integer, ByVal _directionGauche As Boolean)
            Dim sp As Sprite = New Zombie(_directionGauche)
            sp.GetDimensions = New Size(40, 40)
            sp.GetX = _x
            sp.GetY = _y
            parent.GetGestionSprites.AjouterSprite(sp)
        End Sub

        Public Sub CreerMonstreFou(ByVal _x As Integer, ByVal _y As Integer, ByVal _directionGauche As Boolean, ByVal _directionHaut As Boolean)
            Dim sp As Sprite = New MonstreFou(_directionGauche, _directionHaut)
            sp.GetDimensions = New Size(40, 40)
            sp.GetX = _x
            sp.GetY = _y
            parent.GetGestionSprites.AjouterSprite(sp)
        End Sub
    End Class

    ''' <summary>
    ''' Module factory pour créer des projectiles
    ''' </summary>
    Public Class Factory_Projectile
        Private ReadOnly parent As MoteurJeu

        Sub New(ByRef _parent As MoteurJeu)
            parent = _parent

        End Sub

        Public Sub CreerEnnemiMort(ByVal _x As Integer, ByVal _y As Integer, ByVal _typeEnnemi As Ennemi.TYPE_ENNEMI)
            Dim sp As Sprite = New EnnemiMort(_typeEnnemi)
            sp.GetPosition = New Point(_x, _y)
            sp.GetDimensions = New Size(40, 40)
            parent.GetGestionSprites.AjouterSprite(sp)


        End Sub
    End Class

    ''' <summary>
    ''' Module factory pour créer des objets ramassables
    ''' </summary>
    Public Class Factory_Objet
        Private ReadOnly parent As MoteurJeu

        Sub New(ByRef _parent As MoteurJeu)
            parent = _parent
        End Sub

        Public Sub CreerObjetBonusPoints(ByVal _x As Integer, ByVal _y As Integer, ByVal _typeObjetBonusPoints As ObjetBonusPoints.TYPE_OBJET_BONUS_POINT)
            Dim sp As Sprite
            If _typeObjetBonusPoints = ObjetBonusPoints.TYPE_OBJET_BONUS_POINT.BANANE Then
                sp = New ObjetBanane
            End If
            sp.GetDimensions = New Size(40, 40)
            sp.GetPosition = New Point(_x, _y)
            parent.GetGestionSprites.AjouterSprite(sp)

        End Sub

    End Class

    Public Class Factory_Texte
        Private parent As MoteurJeu

        Sub New(ByRef _parent As MoteurJeu)
            parent = _parent
        End Sub

        ''' <summary>
        ''' Créer un texte flottant pour un bonus de point
        ''' </summary>
        ''' <param name="_texte">Texte</param>
        ''' <param name="_position">Position du texte</param>
        Public Sub CreerTextePoints(ByVal _texte As String, ByVal _position As Point)
            Dim tf As New TexteFlottant(_texte)
            tf.GetTaillePoliceTexte = 13
            tf.GetCouleurTexte = Color.Gold
            tf.GetPosition = _position
            tf.GetDirectionTexte = TexteFlottant.DIRECTION.HAUT
            tf.GetSeDeplace = True
            parent.GetGestionSprites.AjouterSprite(tf)
        End Sub

        ''' <summary>
        ''' Créer un texte flottant statique et persistant
        ''' </summary>
        ''' <param name="_texte">Texte</param>
        ''' <param name="_nomPolice">Nom de la police</param>
        ''' <param name="_taillePolice">Taille de la police</param>
        ''' <param name="_couleurTexte">Couleur du texte</param>
        ''' <param name="_position">Position du texte</param>
        Public Sub CreerTexteStatiquePersistant(ByVal _texte As String, ByVal _nomPolice As String, ByVal _taillePolice As String, ByVal _couleurTexte As Color, ByVal _position As Point)
            Dim tf As New TexteFlottant(_texte)
            tf.GetNomPoliceTexte = _nomPolice
            tf.GetTaillePoliceTexte = _taillePolice
            tf.GetCouleurTexte = _couleurTexte
            tf.GetPosition = _position
            tf.GetPersistant = True
            tf.GetSeDeplace = False
        End Sub


    End Class
End Class
