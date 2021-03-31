''' <summary>
''' Moteur de gestion de l'ATH
''' </summary>
Public Class MoteurATH
    Private ReadOnly parent As MoteurJeu

    ''' <summary>
    ''' Liste des éléments d'ATH
    ''' </summary>
    Private listeElementATH As List(Of ElementATH)

    Sub New(ByRef _parent As MoteurJeu)
        parent = _parent
        listeElementATH = New List(Of ElementATH)
    End Sub

    ''' <summary>
    ''' Ajouter un élément d'ATH
    ''' </summary>
    ''' <param name="_elementATH">Instance de l'élément d'ATH</param>
    Public Sub AjouterElementATH(ByVal _elementATH As ElementATH)
        If Not IsNothing(_elementATH) Then
            listeElementATH.Add(_elementATH)
        End If
    End Sub

    Public Function ElementATHExist(ByVal _id As String) As Boolean
        For Each _elementATH As ElementATH In listeElementATH
            If _elementATH.GetIdentifiant = _id Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function GetElementATHIdentifiant(ByVal _id As String)
        For Each _elementATH As ElementATH In listeElementATH
            If _elementATH.GetIdentifiant = _id Then
                Return _elementATH
            End If
        Next

        Return Nothing
    End Function

    Public Function GetListeElementATH() As List(Of ElementATH)
        Return listeElementATH
    End Function

End Class


