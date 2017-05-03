Imports System.Web.Mvc

Namespace Controllers
    Public Class LoginController
        Inherits Controller

        Private dal As IDal

        Sub New()
            Me.New(New Dal())
        End Sub

        Public Sub New(dalIoc As Dal)
            dal = dalIoc
        End Sub

        ' GET: Login
        Function Index() As ActionResult
            Dim viewModel As New UtilisateurViewModel() With {
                     .Authentifie = HttpContext.User.Identity.IsAuthenticated
                }
            If HttpContext.User.Identity.IsAuthenticated Then
                viewModel.Utilisateur = dal.ObtenirUtilisateur(HttpContext.User.Identity.Name)
            End If
            Return View(viewModel)
        End Function

        <HttpPost>
        Function Index(viewModel As UtilisateurViewModel, returnUrl As String) As ActionResult
            If ModelState.IsValid Then
                Dim utilisateur As Utilisateur = dal.Authentifier(viewModel.Utilisateur.MotDePasse, viewModel.Utilisateur.MotDePasse)
                If utilisateur IsNot Nothing Then
                    FormsAuthentication.SetAuthCookie(utilisateur.Id.ToString(), False)
                    If Not String.IsNullOrWhiteSpace(returnUrl) And Url.IsLocalUrl(returnUrl) Then
                        Return Redirect(returnUrl)
                    End If
                    Return Redirect("/")
                End If
                ModelState.AddModelError("Utilisateur.Prenom", "Prénom et/ou mot de passe incorrect(s)")
            End If
            Return View(viewModel)
        End Function

        Function CreerCompte() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Function CreerCompte(utilisateur As Utilisateur) As ActionResult
            If ModelState.IsValid Then
                Dim id As Integer = dal.AjouterUtilisateur(utilisateur.Prenom, utilisateur.MotDePasse)
                FormsAuthentication.SetAuthCookie(id.ToString(), False)
                Return Redirect("/")
            End If
            Return View(utilisateur)
        End Function

        Function Deconnexion() As ActionResult
            FormsAuthentication.SignOut()
            Return Redirect("/")
        End Function
    End Class
End Namespace