Imports System.ComponentModel.DataAnnotations
Imports Toto

Public Class AccueilViewModel

    <Display(Name:="Le messsage")>
    Private _Message As String
    Private _Date As DateTime
    Private _Resto As Resto
    Private _Login As String

    Public Property Message As String
        Get
            Return _Message
        End Get
        Set(value As String)
            _Message = value
        End Set
    End Property

    Public Property [Date] As DateTime
        Get
            Return _Date
        End Get
        Set(value As DateTime)
            _Date = value
        End Set
    End Property

    Public Property Login As String
        Get
            Return _Login
        End Get
        Set(value As String)
            _Login = value
        End Set
    End Property

    Public Property Resto As Resto
        Get
            Return _Resto
        End Get
        Set(value As Resto)
            _Resto = value
        End Set
    End Property
End Class
