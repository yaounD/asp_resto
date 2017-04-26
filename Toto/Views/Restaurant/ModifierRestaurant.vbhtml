@ModelType Toto.Resto

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>ModifierRestaurant</title>
</head>
<body>
    <h1> Modification </h1>
    <h2> Pour test Git</h2>
    @Code
        Using Html.BeginForm()
    End Code         
     <fieldset>
        <legend>Modifier un restaurant</legend>

        <div>
            @Html.LabelFor(Function(model) model.Nom)
            @Html.TextBoxFor(Function(model) model.Nom)
        </div>
        <div>
            @Html.LabelFor(Function(model) model.Telephone)
            @Html.TextBoxFor(Function(model) model.Telephone)
        </div>
        <br />
        <input type="submit" value="Modifier" />
    </fieldset>
    @Code
        End Using
    End Code
            
</body>
</html>
