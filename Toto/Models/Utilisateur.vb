Imports System.ComponentModel.DataAnnotations

Public Class Utilisateur

    Public Property Id() As Integer

    <Required()>
    <Display(Name:="Prénom")>
    Public Property Prenom() As String

    <Required()>
    <Display(Name:="Mot de passe")>
    Public Property MotDePasse() As String

End Class
