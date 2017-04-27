Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


<Table("Restos")>
Public Class Resto

    Public Property Id() As Integer

    '<StringLength(80)>
    <Required(ErrorMessage:="Un nom de restaurant est demandé")>
    Public Property Nom() As String

    '<RegularExpression("^0[0-9]{9}$")>
    <Display(Name:="Téléphone")>
    Public Property Telephone() As String

    Sub New()
    End Sub





End Class
