Imports System.IO

Public Class FormMain

    Private ReadOnly nomProgramme As String = "IF Bubble Bobble Client"
    Private ReadOnly versionProgramme As String = "0.1"
    Private ReadOnly auteurProgramme As String = "Immortal Fox"

    Public Jeu As MoteurJeu

    Public imgTest As Image

    ' Dossiers

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = nomProgramme & " " & versionProgramme

        Jeu = New MoteurJeu(pboxJeu)

        If File.Exists("IF Bubble Bobble/Campagnes/Campagne1.txt") Then

            Dim sr As New StreamReader("IF Bubble Bobble/Campagnes/Campagne1.txt")
            Dim code As New List(Of String)

            Do Until (sr.EndOfStream)
                code.Add(sr.ReadLine())
            Loop

            sr.Close()
            Jeu.GetGestionNiveaux.ChargerCodeProjet(code)
            Jeu.GetGestionNiveaux.ChargerNiveauSuivant()
        End If

        Dim img As Image = Image.FromFile("mur.png")
        'For x As Integer = 1 To 8
        '    Dim sp As New Plateforme
        '    sp.GetX = x
        '    sp.GetY = x * 70
        '    sp.GetDimensions = New Size(300, 10)
        '    Jeu.GetGestionSprites.AjouterSprite(sp)
        'Next

        'Dim tf As New TexteFlottant("Texte flottant")
        'tf.GetPosition = New Point(50, 50)
        'Jeu.GetGestionSprites.AjouterSprite(tf)

        '' Dev joueur
        'Dim pj As New PersonnageJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1)
        'pj.GetRectangle = New Rectangle(200, 200, 40, 40)
        ''pj.AjouterImage(img)
        'Jeu.GetGestionSprites.AjouterSprite(pj)

        'Dim pj2 As New PersonnageJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2)
        'pj2.GetRectangle = New Rectangle(300, 300, 40, 40)
        'Jeu.GetGestionSprites.AjouterSprite(pj2)

        ''Dim ennemiS As New Zombie(False)
        ''ennemiS.GetRectangle = New Rectangle(100, 100, 40, 40)
        ''Jeu.GetGestionSprites.AjouterSprite(ennemiS)

        'Jeu.Factory.Ennemis.CreerZombie(40, 40, False)
        'Jeu.Factory.Ennemis.CreerZombie(80, 40, True)
        'Jeu.Factory.Ennemis.CreerZombie(40, 200, False)

        'Jeu.GetGestionFonctions.ConstruireBordures(img)

        imgTest = img
    End Sub
    Private Sub FormMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Jeu.KeyDown(e.KeyCode)
    End Sub

    Private Sub FormMain_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Jeu.KeyUp(e.KeyCode)
    End Sub

    Private Sub tsmDemarrerHorloge_Click(sender As Object, e As EventArgs) Handles tsmDemarrerHorloge.Click
        Jeu.DemarrerHorloge()
    End Sub

    Private Sub tsmPauseHorloge_Click(sender As Object, e As EventArgs) Handles tsmPauseHorloge.Click
        Jeu.ArreterHorloge()
    End Sub


    Private Sub ManetteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FormProtoControleur.Show()
    End Sub

    Private Sub tsmConfigurationClavier_Click(sender As Object, e As EventArgs) Handles tsmConfigurationClavier.Click
        FormConfigurationClavier.ShowDialog()
    End Sub

    Private Sub tsmQuitter_Click(sender As Object, e As EventArgs) Handles tsmQuitter.Click
        Me.Close()
    End Sub

    Private Sub tsmAPropos_Click(sender As Object, e As EventArgs) Handles tsmAPropos.Click
        FormAPropos.ShowDialog()
    End Sub

    Private Sub tsmNotesMisesAJour_Click(sender As Object, e As EventArgs) Handles tsmNotesMisesAJour.Click
        FormNotesMisesAJour.ShowDialog()
    End Sub

    Private Sub tsmAfficherOmbres_Click(sender As Object, e As EventArgs) Handles tsmAfficherOmbres.Click
        Jeu.GetGestionDessin.GetAfficherOmbesPlateforme = tsmAfficherOmbres.Checked
    End Sub

End Class
