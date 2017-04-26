Imports System.ComponentModel.DataAnnotations

Public Class Utilisateur

    Private _Id As Integer
    <Required()>
    Private _Prenom As String
    <Required()>
    Private _MotDePasse As String


    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property Prenom As String
        Get
            Return _Prenom
        End Get
        Set(value As String)
            _Prenom = value
        End Set
    End Property

    Public Property MotDePasse As String
        Get
            Return _MotDePasse
        End Get
        Set(value As String)
            _MotDePasse = value
        End Set
    End Property
End Class
