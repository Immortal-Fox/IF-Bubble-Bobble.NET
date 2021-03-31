Imports System.Text.RegularExpressions

Module FonctionsScripts

    Public Const REGEX_SEPARATEURPARAMETRES As String = "[^,()]+"

    ''' <summary>
    ''' Retourne le nom de la fonction dans une ligne de code script
    ''' </summary>
    ''' <param name="_code"></param>
    ''' <returns></returns>
    Public Function GetCommande(ByVal _code As String) As String
        Return _code.Substring(0, _code.IndexOf("("))
    End Function

    ''' <summary>
    ''' Obtient le paramètres voulu dans une ligne de code script
    ''' </summary>
    ''' <param name="_code"></param>
    ''' <param name="_parametre"></param>
    ''' <returns></returns>
    Public Function GetParametre(ByVal _code As String, _parametre As Integer) As String

        Dim ParametreFinal As String = ""
        'Dim options As RegexOptions = RegexOptions.Multiline
        Dim _parameters As MatchCollection = Regex.Matches(_code, REGEX_SEPARATEURPARAMETRES, RegexOptions.Multiline)
        If _parameters.Count > _parametre Then
            ParametreFinal = _parameters.Item(_parametre).Value
        End If

        If ParametreFinal = "" Then
            ParametreFinal = 0
        End If
        If IsNothing(ParametreFinal) Then
            Return 0
        Else
            Return ParametreFinal
        End If

    End Function

    Public Function GetScriptFromTexte(ByVal _texte As String) As String
        If Not IsNothing(_texte) Then
            _texte = _texte.Replace("(", "\a")
            _texte = _texte.Replace(")", "\b")
            _texte = _texte.Replace(",", "\v")
            _texte = _texte.Replace(vbCrLf, "\n")
            _texte = _texte.Replace(vbCr, "\n")
            Return _texte
        Else
            Return "0"
        End If
    End Function

    Public Function GetTexteFromScript(ByVal _texte As String) As String
        If Not IsNothing(_texte) Then
            _texte = _texte.Replace("\a", "(")
            _texte = _texte.Replace("\b", ")")
            _texte = _texte.Replace("\v", ",")
            _texte = _texte.Replace("\n", vbCrLf)
            Return _texte
        Else
            Return 0
        End If
    End Function
End Module
