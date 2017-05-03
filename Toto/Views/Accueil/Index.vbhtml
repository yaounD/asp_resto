@ModelType AccueilViewModel
@Code
    ViewData("Title") = "Accueil"
End Code

@*<ul class="list-group">
        <li class="list-group-item">@ViewData("message")</li>
        <li class="list-group-item">@CType(ViewData("date"), DateTime).ToString("dd/MM/yyyy")</li>
        @Code
            Dim rest As Resto = ViewData("resto")
        End Code

        <li Class="list-group-item">@rest.Nom</li>
        <li Class="list-group-item">>@rest.Telephone</li>
    </ul>
    <ul class="list-group">
        <li Class="list-group-item">@ViewBag.message</li>
        <li Class="list-group-item">@ViewBag.date.ToString("dd/MM/yyyy")</li>
        <li class="list-group-item">@Model.Nom</li>
        <li class="list-group-item">@Model.Telephone</li>

    </ul>*@

<p> Prêts à choisir un restaurant ?</p>
@Code
    Html.BeginForm()
End Code
<input type="submit" value="Créer un sondage" />
<br />
<br />
<ul>
    <li>@Html.ActionLink("Ajouter un restaurant", "CreerRestaurant", "Restaurant")</li>
    <li>@Html.ActionLink("Modifier les restaurants", "Index", "Restaurant")</li>
</ul>

@*@Html.Partial("Connexion", Model)
    @Html.TextBox("login", Model.Login)
    @Html.DropDownList("RestoChoisi", CType(ViewBag.ListesDesRestos, SelectList))
    <br/>
    @Html.Action("AfficheListeRestaurant")
    @Code Html.BeginForm("Index", "Home")
    End Code
    @Html.Label("estMajeur", "Cochez la case si vous êtes <strong>majeur</strong>")
    @Html.CheckBox("estMajeur", True)
    <input type="submit" value="Envoyer" />
    @Code  Html.EndForm()
    End Code*@


@*<table style="width:100%;">
        <tr>
            <th>Nom</th>
            <th>Telephone</th>
        </tr>
       @For Each r In Model.ListeResto
          @<tr>
               <td>@Html.TextBox("nom", r.Nom)</td>
               <td>@Html.TextBox("telephone", r.Telephone, New With {.style = "color:red", .class = "ma-css"}) </td>
               <td> </td>
        </tr>
       Next
    </table>*@