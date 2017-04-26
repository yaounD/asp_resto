Imports Toto

Public Class Sondage

    Private _Id As Integer
    Private _Date As DateTime
    Private _Votes As List(Of Vote)

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property [Date] As Date
        Get
            Return _Date
        End Get
        Set(value As Date)
            _Date = value
        End Set
    End Property

    Public Overridable Property Votes As List(Of Vote)
        Get
            Return _Votes
        End Get
        Set(value As List(Of Vote))
            _Votes = value
        End Set
    End Property
End Class
