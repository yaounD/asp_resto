Imports System.Web.Mvc

Namespace Controllers
    <Authorize()>
    Public Class VoteController
        Inherits Controller

        Private dal As IDal

        Sub New()
            Me.New(New Dal())
        End Sub

        Sub New(dalIoc As IDal)
            dal = dalIoc
        End Sub

        Function Index(id As Integer) As ActionResult
            Dim viewModel As New RestaurantVoteViewModel With
                {
                   .ListeDesResto = dal.ObtientTousLesRestaurants().Select(Function(r) New RestaurantCheckBoxViewModel With
                                                                           {
                                                                            .Id = r.Id,
                                                                           .NomEtTelephone = String.Format("{0} ({1})", r.Nom, r.Telephone)
                                                                           }).ToList()
                }
            If dal.ADejaVote(id, HttpContext.User.Identity.Name) Then
                Return RedirectToAction("AfficheResultat", New With
                                        {
                                        .id = id
                                         })
            End If
            Return View(viewModel)
        End Function

        <HttpPost>
        Public Function Index(viewModel As RestaurantVoteViewModel, id As Integer) As ActionResult
            If Not ModelState.IsValid Then
                Return View(viewModel)
            End If
            Dim utilisateur As Utilisateur = dal.ObtenirUtilisateur(HttpContext.User.Identity.Name)
            If utilisateur Is Nothing Then
                Return New HttpUnauthorizedResult()
            End If
            For Each restaurantCheckBoxViewModel As RestaurantCheckBoxViewModel In viewModel.ListeDesResto.Where(Function(r) r.EstSelectionne)
                dal.AjouterVote(id, restaurantCheckBoxViewModel.Id, utilisateur.Id)
            Next
            Return RedirectToAction("AfficheResultat", New With
                                    {
                                     .id = id
                                     })
        End Function

        Function AfficheResultat(id As Integer) As ActionResult

            If (Not dal.ADejaVote(id, HttpContext.User.Identity.Name)) Then

                Return RedirectToAction("Index", New With {.id = id})
            End If
            Dim resultats As List(Of Resultats) = dal.ObtenirLesResultats(id)
            Return View(resultats.OrderByDescending(Function(r) r.NombreDeVotes).ToList())
        End Function

    End Class
End Namespace