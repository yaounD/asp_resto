Imports System.Data.Entity
Imports Toto

Public Class InitChoixResto
    Inherits DropCreateDatabaseAlways(Of BddContext)

    Protected Overrides Sub Seed(context As BddContext)
        context.Restos.Add(New Resto With {.Id = 1, .Nom = "Resto pinpin", .Telephone = "123"})
        context.Restos.Add(New Resto With {.Id = 2, .Nom = "Resto puoluo", .Telephone = "4567"})
        context.Restos.Add(New Resto With {.Id = 3, .Nom = "Resto tralala", .Telephone = "890123"})
        MyBase.Seed(context)
    End Sub
End Class
