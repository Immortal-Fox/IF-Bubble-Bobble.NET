''' <summary>
''' Représente un niveau
''' </summary>
Public Class Niveau

    ''' <summary>
    ''' Liste des objets
    ''' </summary>
    Private listeObjets As List(Of String)
    ''' <summary>
    ''' Couleur de fond du niveau
    ''' </summary>
    Private couleurFond As Color
    ''' <summary>
    ''' Position X du joueur 1
    ''' </summary>
    Private joueur1PositionX As Integer
    ''' <summary>
    ''' Position Y du joueur 1
    ''' </summary>
    Private joueur1PositionY As Integer
    ''' <summary>
    ''' Position X du joueur 2
    ''' </summary>
    Private joueur2PositionX As Integer
    ''' <summary>
    ''' Position Y du joueur 2
    ''' </summary>
    Private Joueur2PositionY As Integer
    ''' <summary>
    ''' Texture des plateformes
    ''' </summary>
    Private texturePlateformes As MoteurTextures.TEXTURES
    ''' <summary>
    ''' Couleur des ombres
    ''' </summary>
    Private couleurOmbres As Color
    ''' <summary>
    ''' Couleur des lumières
    ''' </summary>
    Private couleurLumieres As Color
    ''' <summary>
    ''' Structure des plateformes englobants le niveau
    ''' </summary>
    Private structurePlateforme As MoteurFactory.Factory_Plateforme.STRUCTURE_PLATEFORME

    ''' <summary>
    ''' Instancie un nouveau niveau avec ses paramètres de base
    ''' </summary>
    Sub New()
        listeObjets = New List(Of String)
        couleurFond = Color.SandyBrown
        joueur1PositionX = 0
        joueur1PositionY = 0
        joueur2PositionX = 0
        Joueur2PositionY = 0
        texturePlateformes = MoteurTextures.TEXTURES.PLATEFORME_1
        couleurOmbres = Color.Black
        couleurLumieres = Color.Silver
        structurePlateforme = MoteurFactory.Factory_Plateforme.STRUCTURE_PLATEFORME.NORMALE_FERMEE
    End Sub

    ''' <summary>
    ''' Ajoute une ligne de script objet
    ''' </summary>
    ''' <param name="_code"></param>
    Public Sub AjouterLigneObjet(ByVal _code As String)
        listeObjets.Add(_code)
    End Sub

    ''' <summary>
    ''' Rtourne la liste des scripts objet
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property GetListeObjets As List(Of String)
        Get
            Return listeObjets
        End Get
    End Property

    ''' <summary>
    ''' Retourne ou défini la couleur de fond du niveau
    ''' </summary>
    ''' <returns>Couleur de fond</returns>
    Public Property GetCouleurFond As Color
        Get
            Return couleurFond
        End Get
        Set(value As Color)
            couleurFond = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini la position x du point de départ du joueur 1
    ''' </summary>
    ''' <returns>Position x joueur 1</returns>
    Public Property GetJoueur1PositionX As Integer
        Get
            Return joueur1PositionX
        End Get
        Set(value As Integer)
            joueur1PositionX = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini la position y du point de départ du joueur 1
    ''' </summary>
    ''' <returns>Position y joueur 1</returns>
    Public Property GetJoueur1PositionY As Integer
        Get
            Return joueur1PositionY
        End Get
        Set(value As Integer)
            joueur1PositionY = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini la position x du point de départ du joueur 2
    ''' </summary>
    ''' <returns>Position x joueur 2</returns>
    Public Property GetJoueur2PositionX As Integer
        Get
            Return joueur2PositionX
        End Get
        Set(value As Integer)
            joueur2PositionX = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini la position y du point de départ du joueur 2
    ''' </summary>
    ''' <returns>Position y joueur 2</returns>
    Public Property GetJoueur2PositionY As Integer
        Get
            Return Joueur2PositionY
        End Get
        Set(value As Integer)
            Joueur2PositionY = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini l'id de la texture utilisée pour les plateformes
    ''' </summary>
    ''' <returns>Id texture</returns>
    Public Property GetTexturePlateformes As MoteurTextures.TEXTURES
        Get
            Return texturePlateformes
        End Get
        Set(value As MoteurTextures.TEXTURES)
            texturePlateformes = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini la couleur des ombres des plateformes
    ''' </summary>
    ''' <returns>Couleur des ombres</returns>
    Public Property GetCouleurOmbres As Color
        Get
            Return couleurOmbres
        End Get
        Set(value As Color)
            couleurOmbres = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini la couleur des lumières des plateformes
    ''' </summary>
    ''' <returns>Couleur des lumières</returns>
    Public Property GetCouleurLumieres As Color
        Get
            Return couleurLumieres
        End Get
        Set(value As Color)
            couleurLumieres = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini la structure de base des plateformes
    ''' </summary>
    ''' <returns>Structure des plateformes</returns>
    Public Property GetStructurePlateforme As MoteurFactory.Factory_Plateforme.STRUCTURE_PLATEFORME
        Get
            Return structurePlateforme
        End Get
        Set(value As MoteurFactory.Factory_Plateforme.STRUCTURE_PLATEFORME)
            structurePlateforme = value
        End Set
    End Property
End Class
