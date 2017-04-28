Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


<Table("Restos")>
Public Class Resto
    Implements IValidatableObject

    Public Property Id() As Integer

    '<StringLength(80)>
    '<Required(ErrorMessage:="Un nom de restaurant est demandé")>
    Public Property Nom() As String

    '<RegularExpression("^0[0-9]{9}$")>
    '<Display(Name:="Téléphone")>
    '<Required(ErrorMessage:="Veuillez saisir un numéro de téléphone valable")>
    Public Property Telephone() As String
    Public Property Email() As String

    Sub New()
    End Sub

    Public Iterator Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        If String.IsNullOrWhiteSpace(Telephone) And String.IsNullOrWhiteSpace(Email) Then
            Yield New ValidationResult("Veuillez saisir le telephone ou le mail", New List(Of String) From {"Telephone", "Email"})
        End If
    End Function
End Class
