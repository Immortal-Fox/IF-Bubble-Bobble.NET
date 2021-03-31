''' <summary>
''' Moteur des informations de debug
''' </summary>
Public Class MoteurDebug

    Private parent As MoteurJeu
    Private affichageTexteDebug As Boolean

    Sub New(ByRef _parent As MoteurJeu)
        parent = _parent
        affichageTexteDebug = True
    End Sub

    ''' <summary>
    ''' Retourne le texte de debug
    ''' </summary>
    ''' <returns></returns>
    Public Function GetTexteDebug() As String
        Dim str As String
        str = "Performance : " & parent.GetGestionDessin.GetFPS & vbCrLf
        str = str & "Sprites : " & parent.GetGestionSprites.GetNombreSprites & vbCrLf
        ' str = str & "Crédits : " & parent.GetGestionPartie.GetCredits & vbCrLf
        ' str = str & "Vies joueur 1 : " & parent.GetGestionPartie.GetViesJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1) & vbCrLf
        ' str = str & "Vies joueur 2 : " & parent.GetGestionPartie.GetViesJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2) & vbCrLf
        'str = str & "Points joueur 1 : " & parent.GetGestionPartie.GetPointsJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR1) & vbCrLf
        'str = str & "Points joueur 2 : " & parent.GetGestionPartie.GetPointsJoueur(PersonnageJoueur.NUMEROJOUEUR.JOUEUR2) & vbCrLf
        str = str & "Ennemis restant : " & parent.GetGestionPartie.GetEnnemisRestant & vbCrLf
        str = str & "Game over : " & parent.GetGestionPartie.GetEstGameOver & vbCrLf
        '  str = str & "Niveau : " & parent.GetGestionPartie.GetNiveauActuel & vbCrLf
        str = str & "Niveau max : " & parent.GetGestionPartie.GetNiveauMax & vbCrLf
        str = str & "Etat de la partie : " & parent.GetGestionPartie.GetEtatPartie & vbCrLf
        str = str & "Temps début : " & parent.GetTempsDebutNiveau & vbCrLf
        str = str & "Temps fin : " & parent.GetTempsFinNiveau & vbCrLf
        str = str & "Temps restant : " & parent.GetGestionPartie.GetTempsRestant & vbCrLf
        Return str
    End Function

    ''' <summary>
    ''' Obtient ou défini si le texte de debug est affiché
    ''' </summary>
    ''' <returns></returns>
    Public Property GetAffichageTexteDebug As Boolean
        Get
            Return affichageTexteDebug
        End Get
        Set(value As Boolean)
            affichageTexteDebug = value
        End Set
    End Property

End Class
