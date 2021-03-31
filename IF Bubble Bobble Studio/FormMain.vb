Public Class FormMain

    ' Informations sur le programme
    Private ReadOnly nomProgramme As String = "IF Bubble Bobble Studio"
    Private ReadOnly versionProgramme As String = "0.1"
    Private ReadOnly auteurProgramme As String = "Immortal Fox"

    ' Dossiers
    Public dirDocuments As String

    ''' <summary>
    ''' Textures de jeu
    ''' </summary>
    Public Enum TEXTURES
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
        JOUEUR1_DROITE
        JOUEUR1_GAUCHE
        JOUEUR1_BULLE1
        JOUEUR1_BULLE2
        JOUEUR1_BULLE3

    End Enum

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Informations du programme
        Me.Text = nomProgramme & " " & versionProgramme

    End Sub

End Class
