Imports System.ComponentModel.DataAnnotations

Public Class Utilisateur

    Public Property Id() As Integer

    <Required()>
    Public Property Prenom() As String

    <Required()>
    Public Property MotDePasse() As String

End Class
