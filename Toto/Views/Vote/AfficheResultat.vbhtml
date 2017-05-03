@ModelType List(Of Toto.Resultats)

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<p> Résultat du Sondage :</p>


<table style="width:100%;">
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
 
</table>