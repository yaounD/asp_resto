@ModelType List(Of Resto)



<table style="width:100%;">
    <tr>
        <th>Nom</th>
        <th>Téléphone</th>

    </tr>
    @Code
        For Each r As Resto In Model
    End Code
    <tr>
        <td>@r.Nom</td>
        <td>@r.Telephone</td>
    </tr>
    @Code
        Next
    End Code

</table>