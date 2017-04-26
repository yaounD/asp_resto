Public Class Resultats

    Private _Nom As String
    Private _Telephone As String
    Private _NombreDeVotes As Integer

    Public Property Telephone As String
        Get
            Return _Telephone
        End Get
        Set(value As String)
            _Telephone = value
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

    Public Property NombreDeVotes As Integer
        Get
            Return _NombreDeVotes
        End Get
        Set(value As Integer)
            _NombreDeVotes = value
        End Set
    End Property
End Class
