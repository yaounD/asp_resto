Imports Toto

Public Class Vote

    Private _Id As Integer
    Private _Resto As Resto
    Private _Utilisateur As Utilisateur

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Overridable Property Resto As Resto
        Get
            Return _Resto
        End Get
        Set(value As Resto)
            _Resto = value
        End Set
    End Property

    Public Overridable Property Utilisateur As Utilisateur
        Get
            Return _Utilisateur
        End Get
        Set(value As Utilisateur)
            _Utilisateur = value
        End Set
    End Property
End Class
