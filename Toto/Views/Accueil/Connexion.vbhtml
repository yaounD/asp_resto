@Code
    Html.BeginForm()
End Code
<fieldset>
    <legend>Connexion :</legend>
    @Html.Label("Login")
    @Html.TextBox("login")
    <br />
    @Html.Label("Mot de passe")
    @Html.TextBox("mdp")
    <br />
    <input type="submit" value="Se connecter..." />
</fieldset>
