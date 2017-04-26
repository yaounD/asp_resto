Public Interface IDal
    Inherits IDisposable

    Sub CreerRestaurant(nom As String, telephone As String)
    Sub ModifierRestaurant(id As Integer, nom As String, telephone As String)
    Function RestaurantExiste(nom As String) As Boolean
    Function ObtientTousLesRestaurants() As List(Of Resto)
    Function ObtenirUtilisateur(id As Integer) As Utilisateur
    Function ObtenirUtilisateur(idStr As String) As Utilisateur
    Function AjouterUtilisateur(prenom As String, motDePasse As String) As Integer
    Function Authentifier(prenom As String, motDePasse As String)
    Sub AjouterVote(idSondage As Integer, idResto As Integer, idUtilisateur As Integer)
    Function ADejaVote(idSondage As Integer, idUtilisateur As String) As Boolean
    Function CreerUnSondage() As Integer
    Function ObtenirLesResultats(idSondage As Integer) As List(Of Resultats)
    Function EncodeMD5(motDePasse As String) As String
End Interface
