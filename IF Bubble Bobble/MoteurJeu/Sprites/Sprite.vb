''' <summary>
''' Classe de base pour tous les sprites
''' </summary>
Public MustInherit Class Sprite
    ''' <summary>
    ''' Moteur de jeu parent
    ''' </summary>
    Protected parent As MoteurJeu
    ''' <summary>
    ''' Identifiant de l'objet
    ''' </summary>
    Private identifiant As String
    ''' <summary>
    ''' Position x du sprite
    ''' </summary>
    Private x As Integer
    ''' <summary>
    ''' Position y du sprite
    ''' </summary>
    Private y As Integer
    ''' <summary>
    ''' Largeur du sprite
    ''' </summary>
    Private largeur As Integer
    ''' <summary>
    ''' Hauteur du sprite
    ''' </summary>
    Private hauteur As Integer
    ''' <summary>
    ''' Le sprite est visible (dessiné)
    ''' </summary>
    Private visible As Boolean
    ''' <summary>
    ''' Le sprite a les collisions activées
    ''' </summary>
    Private collisions As Boolean
    ''' <summary>
    ''' Index de la texture
    ''' </summary>
    Private indexTexture As MoteurTextures.TEXTURES = MoteurTextures.TEXTURES.NO_TEXTURE
    ''' <summary>
    ''' Type de sprite
    ''' </summary>
    Private typeSprite As TYPEDESPRITE = TYPEDESPRITE.AUCUN
    ''' <summary>
    ''' Tick de l'horloge du moteur de jeu
    ''' </summary>
    Public MustOverride Sub Tick()
    ''' <summary>
    ''' Touche enfoncée du moteur de jeu
    ''' </summary>
    ''' <param name="_control">Control</param>
    Public MustOverride Sub KeyDown(ByVal _control As MoteurControleurs.CONTROLS)
    ''' <summary>
    ''' Touche relâchée du moteur de jeu
    ''' </summary>
    ''' <param name="_control">Control</param>
    Public MustOverride Sub KeyUp(ByVal _control As MoteurControleurs.CONTROLS)
    ''' <summary>
    ''' Fonction de collision
    ''' </summary>
    ''' <param name="_sprite">Sprite de la collision</param>
    Public MustOverride Sub Collision(ByVal _sprite As Sprite)
    ''' <summary>
    ''' Déstructeur d'objet
    ''' </summary>
    Public MustOverride Sub Detruire()

    ''' <summary>
    ''' Type de sprite
    ''' </summary>
    Enum TYPEDESPRITE
        AUCUN
        PLATEFORME
        PERSONNAGEJOUEUR
        TEXTEFLOTTANT
        OBJETRAMASSABLE
        BULLE
        ENNEMI
        PROJECTILE
    End Enum

    ''' <summary>
    ''' Défini le parent du sprite (moteur de jeu)
    ''' </summary>
    ''' <param name="_parent">Moteur de jeu parent</param>
    Public Sub SetParent(ByVal _parent As MoteurJeu)
        parent = _parent
    End Sub

    ''' <summary>
    ''' Obtient ou défini l'identifiant du sprite
    ''' </summary>
    ''' <returns>Identifiant</returns>
    Public Property GetIdentifiant As String
        Get
            Return identifiant
        End Get
        Set(value As String)
            identifiant = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini la position x du sprite
    ''' </summary>
    ''' <returns>Position x</returns>
    Public Property GetX As Integer
        Get
            Return x
        End Get
        Set(value As Integer)
            x = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini la position y du sprite
    ''' </summary>
    ''' <returns>Position y</returns>
    Public Property GetY As Integer
        Get
            Return y
        End Get
        Set(value As Integer)
            y = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini la largeur du sprite
    ''' </summary>
    ''' <returns>Largeur</returns>
    Public Property GetLargeur As Integer
        Get
            Return largeur
        End Get
        Set(value As Integer)
            largeur = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini la hauteur du sprite
    ''' </summary>
    ''' <returns>Hauteur</returns>
    Public Property GetHauteur As Integer
        Get
            Return hauteur
        End Get
        Set(value As Integer)
            hauteur = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini la position (Point) du sprite
    ''' </summary>
    ''' <returns>Position</returns>
    Public Property GetPosition As Point
        Get
            Return New Point(x, y)
        End Get
        Set(value As Point)
            x = value.X
            y = value.Y
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini les dimensions du sprite
    ''' </summary>
    ''' <returns>Dimensions</returns>
    Public Property GetDimensions As Size
        Get
            Return New Size(largeur, hauteur)
        End Get
        Set(value As Size)
            largeur = value.Width
            hauteur = value.Height
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini le rectangle du sprite
    ''' </summary>
    ''' <returns>Rectangle</returns>
    Public Property GetRectangle As Rectangle
        Get
            Return New Rectangle(x, y, largeur, hauteur)
        End Get
        Set(value As Rectangle)
            x = value.X
            y = value.Y
            largeur = value.Width
            hauteur = value.Height
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini la visibilité du sprite
    ''' </summary>
    ''' <returns>Visibilité</returns>
    Public Property GetVisible As Boolean
        Get
            Return visible
        End Get
        Set(value As Boolean)
            visible = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini si les collisions du sprite sont activées
    ''' </summary>
    ''' <returns>Collisions activés</returns>
    Public Property GetCollisions As Boolean
        Get
            Return collisions
        End Get
        Set(value As Boolean)
            collisions = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini le type de sprite
    ''' </summary>
    ''' <returns>Type de sprite</returns>
    Public Property GetTypeSprite As TYPEDESPRITE
        Get
            Return typeSprite
        End Get
        Set(value As TYPEDESPRITE)
            typeSprite = value
        End Set
    End Property

    ''' <summary>
    ''' Obtient ou défini l'index de la texture du sprite
    ''' </summary>
    ''' <returns>Index de la texture</returns>
    Public Property GetIndexTexture As MoteurTextures.TEXTURES
        Get
            Return indexTexture
        End Get
        Set(value As MoteurTextures.TEXTURES)
            indexTexture = value
        End Set
    End Property
End Class
