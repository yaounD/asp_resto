Imports System.Data.Entity
Imports Toto

Public Class InitChoixResto
    Inherits DropCreateDatabaseAlways(Of BddContext)

    Protected Overrides Sub Seed(context As BddContext)
        context.Restos.Add(New Resto With {.Id = 1, .Nom = "Resto pinpin", .Telephone = "0234567890"})
        context.Restos.Add(New Resto With {.Id = 2, .Nom = "Resto puoluo", .Telephone = "0567890123"})
        context.Restos.Add(New Resto With {.Id = 3, .Nom = "Resto tralala", .Telephone = "0901234567"})
        MyBase.Seed(context)
    End Sub
End Class
