@ModelType RestaurantVoteViewModel

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code


<p> Cochez les restaurants où vous voulez bien aller. Attention, le vote est définitif !</p>

@*@Html.ValidationMessageFor(Function(m) m.ListeDesResto)*@

@Code
    Html.BeginForm()
End Code
@Html.ValidationMessageFor(Function(m) m.ListeDesResto)

 @Code
     For i As Integer = 0 To Model.ListeDesResto.Count - 1
End Code
        <div>
            @Html.CheckBoxFor(Function(m) m.ListeDesResto(i).EstSelectionne, New With {.data_val = "true", .data_val_verifListe = "Vous devez choisir au moins un restaurant"})
            @Html.LabelFor(Function(m) m.ListeDesResto(i).EstSelectionne, Model.ListeDesResto(i).NomEtTelephone)
           @*@Html.ValidationMessageFor(m => m.ListeDesResto[i].EstSelectionne)*@
            @Html.HiddenFor(Function(m) m.ListeDesResto(i).Id)
            @Html.HiddenFor(Function(m) m.ListeDesResto(i).NomEtTelephone)
        </div>
@Code
    Next
End Code


    <input type="submit" value="Valider le choix" style="margin-top: 20px;" />
   

   