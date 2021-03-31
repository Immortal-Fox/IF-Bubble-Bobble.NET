''' <summary>
''' Gestion des contrôles du moteur de jeu
''' </summary>
Public Class MoteurControleurs

    Private parent As MoteurJeu

    Private listeControls As List(Of Keys)

    ''' <summary>
    ''' Liste des contrôles claviers du moteur de jeu
    ''' </summary>
    Public Enum CONTROLS
        AUCUN
        J1_HAUT
        J1_BAS
        J1_GAUCHE
        J1_DROITE
        J1_ACTION
        J2_HAUT
        J2_BAS
        J2_GAUCHE
        J2_DROITE
        J2_ACTION
        START
        PAUSE

    End Enum

    Sub New(ByVal _parent As MoteurJeu)
        parent = _parent

        listeControls = New List(Of Keys)

        ControlesParDefaut()

    End Sub

    ''' <summary>
    ''' Défini les contrôles par défaut
    ''' </summary>
    Public Sub ControlesParDefaut()

        listeControls.Clear()

        ' Controles par défaut
        listeControls.Add(Keys.W)
        listeControls.Add(Keys.D)
        listeControls.Add(Keys.S)
        listeControls.Add(Keys.A)
        listeControls.Add(Keys.Space)

        listeControls.Add(Keys.Up)
        listeControls.Add(Keys.Right)
        listeControls.Add(Keys.Down)
        listeControls.Add(Keys.Left)
        listeControls.Add(Keys.NumPad0)

        listeControls.Add(Keys.Enter)
        listeControls.Add(Keys.P)
    End Sub



    ''' <summary>
    ''' Obtient la valeur Enum du controle
    ''' </summary>
    ''' <param name="_keycode">Code de touche</param>
    ''' <returns>CONTROLS</returns>
    Public Function GetControl(ByVal _keycode As Keys) As CONTROLS
        Select Case _keycode
            Case listeControls(0) ' J1 Haut
                Return CONTROLS.J1_HAUT
            Case listeControls(1) ' J1 Droite
                Return CONTROLS.J1_DROITE
            Case listeControls(2) ' J1 Bas
                Return CONTROLS.J1_BAS
            Case listeControls(3) ' J1 Gauche
                Return CONTROLS.J1_GAUCHE
            Case listeControls(4) ' J1 Action
                Return CONTROLS.J1_ACTION

            Case listeControls(5) ' J2 Haut
                Return CONTROLS.J2_HAUT
            Case listeControls(6) ' J2 Droite
                Return CONTROLS.J2_DROITE
            Case listeControls(7) ' J2 Bas
                Return CONTROLS.J2_BAS
            Case listeControls(8) ' J2 Gauche
                Return CONTROLS.J2_GAUCHE
            Case listeControls(9) ' J2 Action
                Return CONTROLS.J2_ACTION
            Case listeControls(10)
                Return CONTROLS.START ' Démarrer
            Case listeControls(11)
                Return CONTROLS.PAUSE ' Pause
        End Select

        Return CONTROLS.AUCUN
    End Function


End Class
