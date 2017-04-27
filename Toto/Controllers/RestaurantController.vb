Imports System.Web.Mvc

Namespace Controllers
    Public Class RestaurantController
        Inherits Controller

        Function Index() As ActionResult
            Using dal As IDal = New Dal
                Dim ListeDesRestaurants As List(Of Resto) = dal.ObtientTousLesRestaurants()
                Return View(ListeDesRestaurants)
            End Using
        End Function

        Function ModifierRestaurant(id As Nullable(Of Integer)) As ActionResult
            If id.HasValue Then
                Using dal As IDal = New Dal
                    Dim resto As Resto = dal.ObtientTousLesRestaurants.FirstOrDefault(Function(r) r.Id = id.Value)
                    If resto Is Nothing Then
                        Return View("Erreur")
                    End If
                    Return View(resto)
                End Using
            Else
                Return View("Erreur")
            End If
        End Function

        <HttpPost>
        Function ModifierRestaurant(resto As Resto) As ActionResult

            If Not ModelState.IsValid Then
                ViewBag.MessageErreur = ModelState("Nom").Errors(0).ErrorMessage
                Return View(resto)
            End If

            Using dal As IDal = New Dal
                dal.ModifierRestaurant(resto.Id, resto.Nom, resto.Telephone)
                Return RedirectToAction("Index")
            End Using

        End Function

    End Class
End Namespace