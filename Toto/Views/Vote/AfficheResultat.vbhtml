@ModelType List(Of Toto.Resultats)
@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<p> Résultat du Sondage :</p>

<div id="tableauResultat">
    @Code
        Html.RenderAction("AfficheTableau", New With {.id = ViewBag.id})
    End Code
</div>

    @Ajax.ActionLink("Actualiser le résultat", "AfficheTableau", "Vote", New With {.id = ViewBag.id}, New AjaxOptions With
                                                                                                        {
                                                                                                        .InsertionMode = InsertionMode.Replace,
                                                                                                        .UpdateTargetId = "tableauResultat",
                                                                                                        .HttpMethod = "GET"
                                                                                                }
                                                                                                )


<p>Vue normale : @DateTime.Now.ToLongTimeString()</p>

@*<table style="width:100%;">
    <tr>
        <th>Nom</th>
        <th>Téléphone</th>
        <th>Nombre de votes</th>
    </tr>

    @Code
        For Each r As Resultats In Model
    End Code
    <tr>
        <td>@r.Nom</td>
        <td>@r.Telephone</td>
        <td>@r.NombreDeVotes</td>
    </tr>
    @Code
        Next
    End Code
 
</table>*@