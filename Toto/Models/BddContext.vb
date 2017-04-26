Imports System.Data.Entity
Imports Toto

Public Class BddContext
    Inherits DbContext

    Private _Sondages As DbSet(Of Sondage)
    Private _Restos As DbSet(Of Resto)
    Private _Utilisateurs As DbSet(Of Utilisateur)

    Public Property Sondages As DbSet(Of Sondage)
        Get
            Return _Sondages
        End Get
        Set(value As DbSet(Of Sondage))
            _Sondages = value
        End Set
    End Property

    Public Property Restos As DbSet(Of Resto)
        Get
            Return _Restos
        End Get
        Set(value As DbSet(Of Resto))
            _Restos = value
        End Set
    End Property

    Public Property Utilisateurs As DbSet(Of Utilisateur)
        Get
            Return _Utilisateurs
        End Get
        Set(value As DbSet(Of Utilisateur))
            _Utilisateurs = value
        End Set
    End Property
End Class
