Imports System.ComponentModel.DataAnnotations

Public Class RestaurantVoteViewModel
    Implements IValidatableObject

    Public Property ListeDesResto() As List(Of RestaurantCheckBoxViewModel)

    Public Iterator Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        If Not ListeDesResto.Any(Function(r) r.EstSelectionne) Then
            Yield New ValidationResult("Vous devez choisir au moins un restaurant", New List(Of String) From {"ListeDesResto"})
        End If
    End Function
End Class
