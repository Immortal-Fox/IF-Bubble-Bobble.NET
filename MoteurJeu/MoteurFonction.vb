
Public Class MoteurFonction

    Private parent As MoteurJeu

    Sub New(ByVal _parent As MoteurJeu)
        parent = _parent
    End Sub

    Public Sub ConstruireBordures(ByVal _texture As Image)

        '  Dim spTop As New Plateforme
        '   spTop.GetRectangle = New Rectangle(0, 0, 700, 20)
        ' spTop.AjouterImage(_texture)

        Dim spBot As New Plateforme
        spBot.GetRectangle = New Rectangle(0, 680, 700, 20)


        Dim spLeft As New Plateforme
        spLeft.GetRectangle = New Rectangle(0, 20, 20, 660)

        Dim spRight As New Plateforme
        spRight.GetRectangle = New Rectangle(680, 20, 20, 660)

        'parent.GetGestionSprites.AjouterSprite(spTop)
        parent.GetGestionSprites.AjouterSprite(spBot)
        parent.GetGestionSprites.AjouterSprite(spLeft)
        parent.GetGestionSprites.AjouterSprite(spRight)
    End Sub

End Class
