@ModelType Toto.Resto

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewData("Title") = "Restaurant"
End Code



@Code
    Using Html.BeginForm()
End Code
<fieldset>
    <legend>Modifier un restaurant</legend>

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
    <br />
    <input type="submit" value="Modifier" />
</fieldset>
@Code
    End Using
End Code

