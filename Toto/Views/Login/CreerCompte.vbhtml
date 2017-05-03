@ModelType Toto.Utilisateur

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code


<p>Créer un compte :</p>
@Using Html.BeginForm()

    @<div>
        @Html.LabelFor(Function(m) m.Prenom)
        @Html.TextBoxFor(Function(m) m.Prenom)
        @Html.ValidationMessageFor(Function(m) m.Prenom)
    </div>
    @<div>
         @Html.LabelFor(Function(m) m.MotDePasse)
         @Html.TextBoxFor(Function(m) m.MotDePasse)
         @Html.ValidationMessageFor(Function(m) m.MotDePasse)
    </div>

    @<input type = "submit" value="Créer" />
End Using