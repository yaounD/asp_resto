Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Toto.Controllers
Imports System.Web.Mvc

<TestClass()> Public Class AccueilControllerTests

    <TestMethod()>
    Public Sub AccueilController_Index_RenvoiVueParDefaut()
        Dim controller As AccueilController = New AccueilController()
        Dim resultat As ViewResult = CType(controller.Index(), ViewResult)
        Assert.AreEqual(String.Empty, resultat.ViewName)

    End Sub

End Class