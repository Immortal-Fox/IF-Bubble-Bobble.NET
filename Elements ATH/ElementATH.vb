''' <summary>
''' Représente un élément de l'ATH
''' </summary>
Public MustInherit Class ElementATH

    ' champs elementATH
    Private identifiant As String
    Private x As Integer = 0
    Private y As Integer = 0
    Private largeur As Integer = 40
    Private hauteur As Integer = 40
    Private visible As Boolean = True

    ' Champs image
    Protected bmp As Bitmap

    ' Champs mise en forme
    Private afficherBordure As Boolean = False
    Private tailleBordure As Integer = 1

    Private couleurFond As Color = Color.Red

    ''' <summary>
    ''' Mets à jour l'image du champs
    ''' </summary>
    Public MustOverride Sub MiseAJour()


    Public Property GetCouleurFond As Color
        Get
            Return couleurFond
        End Get
        Set(value As Color)
            couleurFond = value
        End Set
    End Property

    Public Property GetIdentifiant As String
        Get
            Return identifiant
        End Get
        Set(value As String)
            identifiant = value
        End Set
    End Property

    Public Property GetX As Integer
        Get
            Return x
        End Get
        Set(value As Integer)
            x = value
        End Set
    End Property

    Public Property GetY As Integer
        Get
            Return y
        End Get
        Set(value As Integer)
            y = value
        End Set
    End Property

    Public Property GetLargeur As Integer
        Get
            Return largeur
        End Get
        Set(value As Integer)
            largeur = value
        End Set
    End Property

    Public Property GetHauteur As Integer
        Get
            Return hauteur
        End Get
        Set(value As Integer)
            hauteur = value
        End Set
    End Property

    Public Property GetVisible As Boolean
        Get
            Return visible
        End Get
        Set(value As Boolean)
            visible = value
        End Set
    End Property

    Public Property GetAfficherBordure As Boolean
        Get
            Return afficherBordure
        End Get
        Set(value As Boolean)
            afficherBordure = value
        End Set
    End Property

    Public Property GetTailleBordure As Integer
        Get
            Return tailleBordure
        End Get
        Set(value As Integer)
            tailleBordure = value
        End Set
    End Property
End Class