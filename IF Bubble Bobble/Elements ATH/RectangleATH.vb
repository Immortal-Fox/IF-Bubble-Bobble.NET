''' <summary>
''' Rectangle de couleur unie
''' </summary>
Public Class RectangleATH
    Inherits ElementATH

    Sub New()

        ' valeurs par défaut
        GetCouleurFond = Color.Red

        MiseAJour()
    End Sub

    Public Overrides Sub MiseAJour()
        If Not IsNothing(bmp) Then
            bmp.Dispose()
        End If

        bmp = New Bitmap(GetLargeur, GetHauteur)
        Dim g As Graphics = Graphics.FromImage(bmp)

        g.Clear(GetCouleurFond)

        g.Dispose()

    End Sub
End Class
