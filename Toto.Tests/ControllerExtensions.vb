Imports System.Runtime.CompilerServices
Imports System.ComponentModel.DataAnnotations
Imports System.Web.Mvc
Imports Toto.Controllers

Module ControllerExtensions

    <Extension()>
    Public Sub ValideLeModele(Of T)(ByVal controller As Controller, modele As T)

        controller.ModelState.Clear()

        Dim context As New ValidationContext(modele, Nothing, Nothing)
        Dim validationResults As New List(Of ValidationResult)()
        Validator.TryValidateObject(modele, context, validationResults, True)

        For Each result As ValidationResult In validationResults
            For Each memberName As String In result.MemberNames
                controller.ModelState.AddModelError(memberName, result.ErrorMessage)
            Next
        Next
    End Sub


End Module
