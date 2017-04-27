Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


<Table("Restos")>
Public Class Resto

    Private _Id As Integer
    <Required(ErrorMessage:="Un nom de restaurant est demandé")>
    Private _Nom As String
    <Display(Name:="Téléphone")>
    Private _Telephone As String

    Sub New()
    End Sub


    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property Nom As String
        Get
            Return _Nom
        End Get
        Set(value As String)
            _Nom = value
        End Set
    End Property

    Public Property Telephone As String
        Get
            Return _Telephone
        End Get
        Set(value As String)
            _Telephone = value
        End Set
    End Property

End Class
