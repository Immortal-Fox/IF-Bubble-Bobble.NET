
Public Class FormProtoControleur
    Private Sub FormProtoControleur_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormProtoControleur_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        MsgBox(e.KeyCode)
    End Sub
End Class