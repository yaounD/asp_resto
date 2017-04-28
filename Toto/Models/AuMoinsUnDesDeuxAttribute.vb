Imports System.ComponentModel.DataAnnotations
Imports System.Reflection
Imports System.Web.Mvc

Public Class AuMoinsUnDesDeuxAttribute
    Inherits ValidationAttribute
    Implements IClientValidatable

    Public Property Parametre1() As String
    Public Property Parametre2() As String

    Sub New()

    End Sub

    Protected Overrides Function IsValid(value As Object, validationContext As ValidationContext) As ValidationResult
        Dim proprietes As PropertyInfo() = validationContext.ObjectType.GetProperties()
        Dim info1 As PropertyInfo = proprietes.FirstOrDefault(Function(p) p.Name.Equals(Parametre1))
        Dim info2 As PropertyInfo = proprietes.FirstOrDefault(Function(p) p.Name.Equals(Parametre2))

        Dim valeur1 As String = info1.GetValue(validationContext.ObjectInstance)
        Dim valeur2 As String = info2.GetValue(validationContext.ObjectInstance)

        If String.IsNullOrWhiteSpace(valeur1) And String.IsNullOrWhiteSpace(valeur2) Then
            Return New ValidationResult(ErrorMessage)
        End If
        Return ValidationResult.Success

    End Function

    Public Function GetClientValidationRules(metadata As ModelMetadata, context As ControllerContext) As IEnumerable(Of ModelClientValidationRule) Implements IClientValidatable.GetClientValidationRules
        Dim regle As ModelClientValidationRule = New ModelClientValidationRule()
        regle.ValidationType = "verifcontact"
        regle.ErrorMessage = ErrorMessage
        regle.ValidationParameters.Add("parametre1", Parametre1)
        regle.ValidationParameters.Add("parametre2", Parametre2)
        Return New List(Of ModelClientValidationRule) From {regle}

    End Function
End Class
