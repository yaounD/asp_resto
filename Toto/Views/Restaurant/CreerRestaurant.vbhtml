@ModelType Toto.Resto

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

    <h1>Restaurant</h1>
@Code
    Using Html.BeginForm()
End Code
<fieldset>
    <legend>Ajouter un restaurant</legend>
   
    <div>
        @Html.LabelFor(Function(model) model.Nom)
        @Html.TextBoxFor(Function(model) model.Nom)
        @Html.ValidationMessageFor(Function(model) model.Nom)
    </div>
    <div>
        @Html.LabelFor(Function(model) model.Telephone)
        @Html.TextBoxFor(Function(model) model.Telephone)
        @Html.ValidationMessageFor(Function(model) model.Telephone)
    </div>
    <div>
        @Html.LabelFor(Function(model) model.Email)
        @Html.TextBoxFor(Function(model) model.Email)
        @Html.ValidationMessageFor(Function(model) model.Email)
    </div>
    <br />
    <input type="submit" value="Modifier" />
</fieldset>
@Code
    End Using
End Code
