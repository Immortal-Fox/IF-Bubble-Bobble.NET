''' <summary>
''' Représente un modèle de niveau
''' </summary>
Public Class ModeleNiveau

    ''' <summary>
    ''' Couleur de fond du niveau
    ''' </summary>
    Private couleurDeFond As Color

    ''' <summary>
    ''' Liste contenant le code des objets
    ''' </summary>
    Private listeObjets As List(Of String)

    Sub New()
        listeObjets = New List(Of String)
    End Sub

End Class
