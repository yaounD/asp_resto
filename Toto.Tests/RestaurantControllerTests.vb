Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Toto.Controllers

<TestClass()> Public Class RestaurantControllerTests

    <TestMethod()>
    Public Sub RestaurantController_Index_LeControleurEstOk()
        Using dal As IDal = New DalEnDur()
            Dim controller As RestaurantController = New RestaurantController(dal)
            Dim resultat As ViewResult = CType(controller.Index(), ViewResult)
            Dim modele As List(Of Resto) = resultat.Model
            Assert.AreEqual("Resto pinambour", modele(0).Nom)
        End Using
    End Sub

    <TestMethod()>
    Public Sub RestaurantController_ModifierRestaurantAvecRestoInvalide_RenvoiVueParDefaut()
        Using dal As IDal = New DalEnDur()
            Dim controller As RestaurantController = New RestaurantController(dal)
            controller.ModelState.AddModelError("Nom", "Le nom du restaurant doit être saisi")

            Dim resultat As ViewResult = controller.ModifierRestaurant(New Resto With {.Id = 1, .Nom = Nothing, .Telephone = "0102030405"})

            Assert.AreEqual(String.Empty, resultat.ViewName)
            Assert.IsFalse(resultat.ViewData.ModelState.IsValid)
        End Using
    End Sub

    <TestMethod>
    Public Sub RestaurantController_ModifierRestaurantAvecRestoInvalideEtBindingDeModele_RenvoiVueParDefaut()
        Dim controller As New RestaurantController(New DalEnDur())
        Dim resto As New Resto() With {
           .Id = 1,
            .Nom = Nothing,
            .Telephone = "0102030405"
        }
        controller.ValideLeModele(resto)

        Dim resultat As ActionResult = DirectCast(controller.ModifierRestaurant(resto), RedirectToRouteResult)


    End Sub


End Class