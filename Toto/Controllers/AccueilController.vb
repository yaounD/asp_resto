﻿Imports System.Web.Mvc

Namespace Controllers
    Public Class AccueilController
        Inherits Controller


        Function Index() As ActionResult
            'Dim listeRestos As List(Of Resto) = New List(Of Resto) From
            '    {
            '     New Resto With {.Id = 1, .Nom = "TOTO", .Telephone = "1234"},
            '     New Resto With {.Id = 2, .Nom = "TATO", .Telephone = "5678"},
            '     New Resto With {.Id = 5, .Nom = "TOTA", .Telephone = "9012"},
            '     New Resto With {.Id = 9, .Nom = "tralala", .Telephone = "1234567890"}
            '    }

            'ViewBag.ListesDesRestos = New SelectList(listeRestos, "Id", "Nom")

            'Dim vm As AccueilViewModel = New AccueilViewModel With {
            '    .Message = "Bonjour depuis le contrôleur",
            '    .Date = DateTime.Now,
            '    .Resto = New Resto With {.Id = 1, .Nom = "TOTO", .Telephone = "1234"},
            '    .Login = "Nicolas"
            '}
            'Return View(vm)
            Return View()
        End Function

        <ChildActionOnly>
        Function AfficheListeRestaurant() As ActionResult
            Dim listeDesRestos As List(Of Resto) = New List(Of Resto) From
                {
                 New Resto With {.Id = 1, .Nom = "TOTO", .Telephone = "1234"},
                 New Resto With {.Id = 2, .Nom = "TATO", .Telephone = "5678"},
                 New Resto With {.Id = 5, .Nom = "TOTA", .Telephone = "9012"},
                 New Resto With {.Id = 9, .Nom = "tralala", .Telephone = "1234567890"}
                }
            Return PartialView(listeDesRestos)
        End Function
    End Class
End Namespace