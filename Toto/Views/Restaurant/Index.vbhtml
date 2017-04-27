@ModelType List(Of Resto)

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Liste des restaurants</title>

</head>
<body>
    <table style="width:100%;">
        <tr>
            <th>Nom</th>
            <th>Téléphone</th>
            <th>Modifier</th>
        </tr>
        @Code
            For Each r As Resto In Model
        End Code
        <tr>
            <td>@r.Nom</td>
            <td>@r.Telephone</td>
           <td>@Html.ActionLink("Modifier " & r.Nom, "ModifierRestaurant", New With {.id = r.Id})</td>
        </tr>
        @Code
            Next
        End Code

    </table>
</body>
</html>
