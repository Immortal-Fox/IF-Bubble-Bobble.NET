''' <summary>
''' Texte flottant
''' </summary>
Public Class TexteFlottant
    Inherits Sprite
    ''' <summary>
    ''' Nom de la police du texte
    ''' </summary>
    Private nomPoliceTexte As String = "Arial"
    ''' <summary>
    ''' Taille de la police du texte
    ''' </summary>
    Private taillePoliceTexte As Integer = 9
    ''' <summary>
    ''' Couleur de la police du texte
    ''' </summary>
    Private couleurTexte As Color = Color.Black
    ''' <summary>
    ''' Texte affiché
    ''' </summary>
    Private texte As String = ""
    ''' <summary>
    ''' Police du texte (Font)
    ''' </summary>
    Private policeTexte As Font
    ''' <summary>
    ''' Direction de déplacement du texte
    ''' </summary>
    Private directionTexte As DIRECTION
    ''' <summary>
    ''' Le texte se déplace
    ''' </summary>
    Private seDeplace As Boolean = False
    ''' <summary>
    ''' Vélocité de déplacement
    ''' </summary>
    Private velocite As Integer = 1
    ''' <summary>
    ''' Temps d'affichage en tick d'horloge
    ''' </summary>
    Private tempsAffichage As Integer = 30
    ''' <summary>
    ''' Si le texte est persistant
    ''' </summary>
    Private persistant As Boolean = False

    ''' <summary>
    ''' Direction de déplacement du texte
    ''' </summary>
    Public Enum DIRECTION
        HAUT
        DROITE
        BAS
        GAUCHE
    End Enum

    Sub New(ByVal _texte As String, Optional _policeTexte As String = "Consolas", Optional _policeTaille As Integer = 11)
        GetTypeSprite = TYPEDESPRITE.TEXTEFLOTTANT
        GetVisible = True
        GetCollisions = False

        ' Valeurs par défaut
        taillePoliceTexte = _policeTaille
        nomPoliceTexte = _policeTexte
        texte = _texte
        couleurTexte = Color.Black
        directionTexte = DIRECTION.HAUT
        seDeplace = True
        persistant = False

        ConstruirePoliceTexte()
    End Sub

    ''' <summary>
    ''' Tick d'horloge
    ''' </summary>
    Public Overrides Sub Tick()

        If seDeplace Then
            If directionTexte = DIRECTION.HAUT Then
                Me.GetY = Me.GetY - 1
            ElseIf directionTexte = DIRECTION.BAS Then
                Me.GetY = Me.GetY + 1
            ElseIf directionTexte = DIRECTION.GAUCHE Then
                Me.GetX = Me.GetX + 1
            ElseIf directionTexte = DIRECTION.DROITE Then
                Me.GetX = Me.GetX - 1
            End If
        End If

        If Not persistant Then
            If tempsAffichage = 0 Then
                parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
            End If
            tempsAffichage = tempsAffichage - 1

        End If
    End Sub

    ''' <summary>
    ''' Construit l'objet de police du texte
    ''' </summary>
    Private Sub ConstruirePoliceTexte()
        policeTexte = New Font(nomPoliceTexte, taillePoliceTexte)
    End Sub

    ''' <summary>
    ''' Retourne ou défini le nom de la police du texte
    ''' </summary>
    ''' <returns>Nom de police</returns>
    Public Property GetNomPoliceTexte As String
        Get
            Return nomPoliceTexte
        End Get
        Set(value As String)
            nomPoliceTexte = value
            ConstruirePoliceTexte()
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini la taille de la police du texte
    ''' </summary>
    ''' <returns>Taille de la police du texte</returns>
    Public Property GetTaillePoliceTexte As Integer
        Get
            Return taillePoliceTexte
        End Get
        Set(value As Integer)
            taillePoliceTexte = value
            ConstruirePoliceTexte()
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini la couleur du texte
    ''' </summary>
    ''' <returns></returns>
    Public Property GetCouleurTexte As Color
        Get
            Return couleurTexte
        End Get
        Set(value As Color)
            couleurTexte = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini le texte
    ''' </summary>
    ''' <returns></returns>
    Public Property GetTexte As String
        Get
            Return texte
        End Get
        Set(value As String)
            texte = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne la police du texte (font)
    ''' </summary>
    ''' <returns>Font</returns>
    Public ReadOnly Property GetPoliceTexte As Font
        Get
            Return policeTexte
        End Get
    End Property

    ''' <summary>
    ''' Retourne ou défini la direction de mouvement du texte flottant
    ''' </summary>
    ''' <returns>Direction</returns>
    Public Property GetDirectionTexte As DIRECTION
        Get
            Return directionTexte
        End Get
        Set(value As DIRECTION)
            directionTexte = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini si le texte est statique
    ''' </summary>
    ''' <returns></returns>
    Public Property GetSeDeplace As Boolean
        Get
            Return seDeplace
        End Get
        Set(value As Boolean)
            seDeplace = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini si le texte est persistant
    ''' </summary>
    ''' <returns></returns>
    Public Property GetPersistant As Boolean
        Get
            Return persistant
        End Get
        Set(value As Boolean)
            persistant = value
        End Set
    End Property

    ''' <summary>
    ''' Retourne ou défini le temps d'affichage du texte (si non persistant)
    ''' </summary>
    ''' <returns>Temps d'affichage en tick d'horloge</returns>
    Public Property GetTempsAffichage As Integer
        Get
            Return tempsAffichage
        End Get
        Set(value As Integer)
            tempsAffichage = value
        End Set
    End Property

    Public Overrides Sub Detruire()
        parent.GetGestionSprites.SupprimerSpriteEndTick(Me)
    End Sub

    Public Overrides Sub KeyDown(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub KeyUp(_control As MoteurControleurs.CONTROLS)

    End Sub

    Public Overrides Sub Collision(_sprite As Sprite)

    End Sub

End Class
