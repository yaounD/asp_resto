@ModelType List(Of Toto.Resultats)

<table>
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

<p>Vue partielle : @DateTime.Now.ToLongTimeString()</p>
