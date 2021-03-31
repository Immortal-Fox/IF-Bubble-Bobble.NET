Imports System.IO
''' <summary>
''' Moteur de texture du jeu
''' </summary>
Public Class MoteurTextures
    Private parent As MoteurJeu

    ''' <summary>
    ''' Liste des textures
    ''' </summary>
    Private listeTextures As List(Of Image)
    ''' <summary>
    ''' Liste des noms de fichier
    ''' </summary>
    Private listeNomsFichiers As List(Of String)
    Private cheminDossierTextures As String

    Sub New(ByRef _parent As MoteurJeu)
        parent = _parent

        listeTextures = New List(Of Image)
        listeNomsFichiers = New List(Of String)

        ChargerListeNomsFichiers()

        ' dev
        cheminDossierTextures = "Textures"
        ChargerTextures()

    End Sub

    ''' <summary>
    ''' Créer et retourne l'image no texture
    ''' </summary>
    ''' <returns></returns>
    Private Function GetNoTexture() As Image
        Dim bmp As New Bitmap(40, 40)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.Clear(Color.Red)
        g.DrawString("no texture", New Font("Arial", 7), New SolidBrush(Color.Black), New Rectangle(0, 0, bmp.Width, bmp.Height))
        g.Dispose()
        Return bmp
    End Function

    ''' <summary>
    ''' Retourne l'image de la texture
    ''' </summary>
    ''' <param name="_texture"></param>
    ''' <returns>Texture</returns>
    Public Function GetTexture(ByVal _texture As TEXTURES) As Image
        Return listeTextures(_texture)
    End Function

    ''' <summary>
    ''' Charge les textures depuis le dossier
    ''' </summary>
    Public Sub ChargerTextures()

        ' Suppression de la liste de texture existante
        listeTextures.Clear()

        ' Ajoute la texture no texture
        listeTextures.Add(GetNoTexture)

        ' Parcours la liste des noms de fichiers et essai de charger le fichier image
        ' Sinon on utilise imageNoTexture

        For Each _fichier As String In listeNomsFichiers
            If File.Exists(cheminDossierTextures & "/" & _fichier) Then
                Dim texture As Image = Image.FromFile(cheminDossierTextures & "/" & _fichier)
                listeTextures.Add(texture)
            Else
                listeTextures.Add(GetNoTexture)
            End If
        Next

    End Sub

    ''' <summary>
    ''' Créer la liste des noms de fichiers pour les textures
    ''' </summary>
    Private Sub ChargerListeNomsFichiers()

        ' Textures plateformes
        listeNomsFichiers.Add("plateforme_1.png")
        listeNomsFichiers.Add("plateforme_2.png")
        listeNomsFichiers.Add("plateforme_3.png")
        listeNomsFichiers.Add("plateforme_4.png")
        listeNomsFichiers.Add("plateforme_5.png")
        listeNomsFichiers.Add("plateforme_6.png")
        listeNomsFichiers.Add("plateforme_7.png")
        listeNomsFichiers.Add("plateforme_8.png")
        listeNomsFichiers.Add("plateforme_9.png")
        listeNomsFichiers.Add("plateforme_10.png")
        listeNomsFichiers.Add("plateforme_11.png")
        listeNomsFichiers.Add("plateforme_12.png")
        listeNomsFichiers.Add("plateforme_13.png")
        listeNomsFichiers.Add("plateforme_14.png")
        listeNomsFichiers.Add("plateforme_15.png")
        listeNomsFichiers.Add("plateforme_16.png")
        listeNomsFichiers.Add("plateforme_17.png")
        listeNomsFichiers.Add("plateforme_18.png")
        listeNomsFichiers.Add("plateforme_19.png")
        listeNomsFichiers.Add("plateforme_20.png")
        listeNomsFichiers.Add("plateforme_21.png")
        listeNomsFichiers.Add("plateforme_22.png")
        listeNomsFichiers.Add("plateforme_23.png")
        listeNomsFichiers.Add("plateforme_24.png")
        listeNomsFichiers.Add("plateforme_25.png")
        listeNomsFichiers.Add("plateforme_26.png")
        listeNomsFichiers.Add("plateforme_27.png")
        listeNomsFichiers.Add("plateforme_28.png")
        listeNomsFichiers.Add("plateforme_29.png")
        listeNomsFichiers.Add("plateforme_30.png")
        ' Textures joueur 1
        listeNomsFichiers.Add("joueur1_base.png")
        listeNomsFichiers.Add("joueur1_base_gauche_1.png")
        listeNomsFichiers.Add("joueur1_base_gauche_2.png")
        listeNomsFichiers.Add("joueur1_base_gauche_3.png")
        listeNomsFichiers.Add("joueur1_base_droite_1.png")
        listeNomsFichiers.Add("joueur1_base_droite_2.png")
        listeNomsFichiers.Add("joueur1_base_droite_3.png")
        listeNomsFichiers.Add("joueur1_bulle_gauche_1.png")
        listeNomsFichiers.Add("joueur1_bulle_gauche_2.png")
        listeNomsFichiers.Add("joueur1_bulle_gauche_3.png")
        listeNomsFichiers.Add("joueur1_bulle_droite_1.png")
        listeNomsFichiers.Add("joueur1_bulle_droite_2.png")
        listeNomsFichiers.Add("joueur1_bulle_droite_3.png")
        listeNomsFichiers.Add("joueur1_mort1.png")
        listeNomsFichiers.Add("joueur1_mort2.png")
        listeNomsFichiers.Add("joueur1_mort3.png")
        ' Bulles
        listeNomsFichiers.Add("bulle_normale.png")
        listeNomsFichiers.Add("bulle_zombie.png")
        ' Zombie
        listeNomsFichiers.Add("zombie_base.png")
        listeNomsFichiers.Add("zombie_base_gauche_1.png")
        listeNomsFichiers.Add("zombie_base_gauche_2.png")
        listeNomsFichiers.Add("zombie_base_gauche_3.png")
        listeNomsFichiers.Add("zombie_base_droite_1.png")
        listeNomsFichiers.Add("zombie_base_droite_2.png")
        listeNomsFichiers.Add("zombie_base_droite_3.png")
        listeNomsFichiers.Add("zombie_base_mort_1.png")
        listeNomsFichiers.Add("zombie_base_mort_2.png")
        listeNomsFichiers.Add("zombie_base_mort_3.png")
        ' Monstre Fou

        ' Objets
        listeNomsFichiers.Add("objet_banane.png")
    End Sub

    ''' <summary>
    ''' Index de texture
    ''' </summary>
    Public Enum TEXTURES
        NO_TEXTURE
        PLATEFORME_1
        PLATEFORME_2
        PLATEFORME_3
        PLATEFORME_4
        PLATEFORME_5
        PLATEFORME_6
        PLATEFORME_7
        PLATEFORME_8
        PLATEFORME_9
        PLATEFORME_10
        PLATEFORME_11
        PLATEFORME_12
        PLATEFORME_13
        PLATEFORME_14
        PLATEFORME_15
        PLATEFORME_16
        PLATEFORME_17
        PLATEFORME_18
        PLATEFORME_19
        PLATEFORME_20
        PLATEFORME_21
        PLATEFORME_22
        PLATEFORME_23
        PLATEFORME_24
        PLATEFORME_25
        PLATEFORME_26
        PLATEFORME_27
        PLATEFORME_28
        PLATEFORME_29
        PLATEFORME_30
        JOUEUR1_BASE
        JOUEUR1_BASE_GAUCHE_1
        JOUEUR1_BASE_GAUCHE_2
        JOUEUR1_BASE_GAUCHE_3
        JOUEUR1_BASE_DROITE_1
        JOUEUR1_BASE_DROITE_2
        JOUEUR1_BASE_DROITE_3
        JOUEUR1_BULLE_GAUCHE_1
        JOUEUR1_BULLE_GAUCHE_2
        JOUEUR1_BULLE_GAUCHE_3
        JOUEUR1_BULLE_DROITE_1
        JOUEUR1_BULLE_DROITE_2
        JOUEUR1_BULLE_DROITE_3
        JOUEUR1_MORT_1
        JOUEUR1_MORT_2
        JOUEUR1_MORT_3
        BULLE_NORMALE
        BULLE_ZOMBIE
        ZOMBIE_BASE
        ZOMBIE_BASE_GAUCHE_1
        ZOMBIE_BASE_GAUCHE_2
        ZOMBIE_BASE_GAUCHE_3
        ZOMBIE_BASE_DROITE_1
        ZOMBIE_BASE_DROITE_2
        ZOMBIE_BASE_DROITE_3
        ZOMBIE_BASE_MORT_1
        ZOMBIE_BASE_MORT_2
        ZOMBIE_BASE_MORT_3
        OBJET_BANANE
    End Enum
End Class
