@ModelType Toto.UtilisateurViewModel

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code


 @Code
     If Model.Authentifie Then
End Code
    <h3>
       Vous êtes déjà authentifié avec le login :
       @Model.Utilisateur.Prenom
    </h3>
    @Html.ActionLink("Voulez-vous vous déconnecter ?", "Deconnexion")
@Code
    Else
End Code
    <p>
    Veuillez vous authentifier :
    </p>
@Code
    Using Html.BeginForm()
End Code
 <div>
    @Html.LabelFor(Function(m) m.Utilisateur.Prenom)
    @Html.TextBoxFor(Function(m) m.Utilisateur.Prenom)
    @Html.ValidationMessageFor(Function(m) m.Utilisateur.Prenom)
</div>
<div>
    @Html.LabelFor(Function(m) m.Utilisateur.MotDePasse)
    @Html.PasswordFor(Function(m) m.Utilisateur.MotDePasse)
    @Html.ValidationMessageFor(Function(m) m.Utilisateur.MotDePasse)
</div>
    <input type="submit" value="Se connecter" />
    <br />
    @Html.ActionLink("Créer un compte", "CreerCompte")

@Code
        End Using
    End If
        End Code





