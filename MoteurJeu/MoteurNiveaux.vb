Imports System.Text.RegularExpressions

''' <summary>
''' Moteur de gestion des niveaux
''' </summary>
Public Class MoteurNiveaux

    Private ReadOnly parent As MoteurJeu
    Private listeNiveaux As List(Of Niveau)

    Private nomAuteur As String
    Private nomProjet As String

    Sub New(ByRef _parent As MoteurJeu)
        parent = _parent
        listeNiveaux = New List(Of Niveau)
    End Sub

    ''' <summary>
    ''' Charger le code d'un projet
    ''' </summary>
    ''' <param name="_codeProjet">Code projet</param>
    Public Sub ChargerCodeProjet(ByVal _codeProjet As List(Of String))
        listeNiveaux.Clear()
        parent.GetGestionPartie.ReinitialisationPartie()
        Dim tempNiv As Niveau = Nothing

        For Each _ligneCode As String In _codeProjet

            If GetCommande(_ligneCode) = "Projet" Then
                ' Charge le projet
                ConfigurerProjet(_ligneCode)

            ElseIf GetCommande(_ligneCode) = "Niveau" Then

                If Not IsNothing(tempNiv) Then
                    listeNiveaux.Add(tempNiv)
                End If
                tempNiv = GetNiveauDepuisCode(_ligneCode)

            Else
                ' Sans doute du code objet alors on l'ajoute au niveau
                If Not IsNothing(tempNiv) Then
                    tempNiv.AjouterLigneObjet(_ligneCode)
                End If
            End If

        Next
        If Not IsNothing(tempNiv) Then
            listeNiveaux.Add(tempNiv)
        End If

        ' dev
        parent.GetGestionPartie.GetNiveauActuel = 0
        parent.GetGestionPartie.GetNiveauMax = listeNiveaux.Count

    End Sub

    ''' <summary>
    ''' Charge le niveau suivant
    ''' </summary>
    Public Sub ChargerNiveauSuivant()
        parent.GetGestionPartie.GetNiveauActuel += 1

        If parent.GetGestionPartie.GetNiveauActuel <= parent.GetGestionPartie.GetNiveauMax Then
            parent.GetGestionSprites.SupprimerTousLesSprites()
            ChargerSpriteDepuisCode(listeNiveaux(parent.GetGestionPartie.GetNiveauActuel - 1).GetListeObjets)
            ' Créer les personnages joueurs
            parent.GetGestionPartie.CreerPersonnageJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1)
            parent.GetGestionPartie.CreerPersonnageJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2)
            ' Paramètres des couleurs
            parent.GetGestionDessin.GetCouleurFond = listeNiveaux(parent.GetGestionPartie.GetNiveauActuel - 1).GetCouleurFond
            parent.GetGestionDessin.GetCouleurOmbres = listeNiveaux(parent.GetGestionPartie.GetNiveauActuel - 1).GetCouleurOmbres
            parent.GetGestionDessin.GetCouleurLumieres = listeNiveaux(parent.GetGestionPartie.GetNiveauActuel - 1).GetCouleurLumieres
            parent.GetGestionDessin.GetTexturePlateforme = listeNiveaux(parent.GetGestionPartie.GetNiveauActuel - 1).GetTexturePlateformes
            ' Chargement de la structure des bordures de niveau
            parent.Factory.Plateformes.CreerStructurePlateforme(listeNiveaux(parent.GetGestionPartie.GetNiveauActuel - 1).GetStructurePlateforme)
            ' Changement de l'état de la partie
            parent.GetGestionDessin.SetImageNiveauSuivant()
            parent.GetGestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.ANIMATION_CHANGEMENT_NIVEAU
        Else
            parent.GetGestionPartie.GetEstVictoire = True
            parent.GetGestionPartie.GetEtatPartie = MoteurPartie.ETAT_PARTIE.VICTOIRE
        End If
    End Sub

    ''' <summary>
    ''' Retourne une instance d'un niveau à partir de son code
    ''' </summary>
    ''' <param name="_code"></param>
    ''' <returns></returns>
    Private Function GetNiveauDepuisCode(ByVal _code As String) As Niveau
        Dim niv As Niveau = New Niveau()
        niv.GetCouleurFond = ColorTranslator.FromHtml(GetParametre(_code, 1))
        niv.GetJoueur1PositionX = GetParametre(_code, 2)
        niv.GetJoueur1PositionY = GetParametre(_code, 3)
        niv.GetJoueur2PositionX = GetParametre(_code, 4)
        niv.GetJoueur2PositionY = GetParametre(_code, 5)
        niv.GetTexturePlateformes = GetParametre(_code, 6)
        niv.GetCouleurOmbres = ColorTranslator.FromHtml(GetParametre(_code, 7))
        niv.GetCouleurLumieres = ColorTranslator.FromHtml(GetParametre(_code, 8))
        Return niv
    End Function

    ''' <summary>
    ''' configure le projet avec la ligne de script projet
    ''' </summary>
    ''' <param name="_code"></param>
    Private Sub ConfigurerProjet(ByVal _code As String)

    End Sub

    ''' <summary>
    ''' Charge les sprites depuis le code de niveau
    ''' </summary>
    ''' <param name="_listeCode"></param>
    Private Sub ChargerSpriteDepuisCode(ByVal _listeCode As List(Of String))
        If Not IsNothing(_listeCode) Then
            ' Lis chaque ligne pour créer l'objet associé au code
            For Each _ligne As String In _listeCode
                Dim cmd As String = GetCommande(_ligne)
                ' Plateforme
                If cmd = "PlateformeSimple" Then
                    parent.Factory.Plateformes.CreerPlateformeSimple(GetParametre(_ligne, 1), GetParametre(_ligne, 2), GetParametre(_ligne, 3), GetParametre(_ligne, 4))
                ElseIf cmd = "Zombie" Then
                    parent.Factory.Ennemis.CreerZombie(GetParametre(_ligne, 1), GetParametre(_ligne, 2), GetParametre(_ligne, 3))
                ElseIf cmd = "MonstreFou" Then
                    parent.Factory.Ennemis.CreerMonstreFou(GetParametre(_ligne, 1), GetParametre(_ligne, 2), GetParametre(_ligne, 3), GetParametre(_ligne, 4))
                End If
            Next
        End If
    End Sub

End Class
