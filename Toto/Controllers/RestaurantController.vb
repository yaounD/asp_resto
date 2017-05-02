Imports System.Web.Mvc

Namespace Controllers
    Public Class RestaurantController
        Inherits Controller

        Private dal As IDal

        Sub New()
            Me.New(New Dal())
        End Sub

        Sub New(dalIoc As IDal)
            dal = dalIoc
        End Sub

        Function Index() As ActionResult
            Dim ListeDesRestaurants As List(Of Resto) = dal.ObtientTousLesRestaurants()
            Return View(ListeDesRestaurants)
        End Function

        Function ModifierRestaurant(id As Nullable(Of Integer)) As ActionResult
            If id.HasValue Then
                Dim resto As Resto = dal.ObtientTousLesRestaurants.FirstOrDefault(Function(r) r.Id = id.Value)
                If resto Is Nothing Then
                    Return View("Erreur")
                End If
                Return View(resto)
            Else
                Return HttpNotFound()
            End If
        End Function

        <HttpPost>
        Function ModifierRestaurant(resto As Resto) As ActionResult
            If Not ModelState.IsValid Then
                Return View(resto)
            End If
            dal.ModifierRestaurant(resto.Id, resto.Nom, resto.Telephone)
            Return RedirectToAction("Index")
        End Function

        Function CreerRestaurant() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Function CreerRestaurant(resto As Resto) As ActionResult
            If dal.RestaurantExiste(resto.Nom) Then
                ModelState.AddModelError("Nom", "Ce restaurant existe déjà")
                Return View(resto)
            End If
            If Not ModelState.IsValid Then
                Return View(resto)
            End If
            dal.CreerRestaurant(resto.Nom, resto.Telephone)
            Return RedirectToAction("Index")
        End Function

        Function RetourAccueil(id As String) As ActionResult
            Return RedirectToRoute(New With {.controller = "Accueil", .action = "Index"})
        End Function
    End Class
End Namespace