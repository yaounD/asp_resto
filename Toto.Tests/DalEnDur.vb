
Imports System.Security.Cryptography
Imports System.Text
Imports Toto

Public Class DalEnDur
    Implements IDal

    Private listeDesRestaurants As List(Of Resto)
    Private listeDesUtilisateurs As List(Of Utilisateur)
    Private listeDesSondages As List(Of Sondage)

    Sub New()
        listeDesRestaurants = New List(Of Resto) From
            {
            New Resto With {.Id = 1, .Nom = "Resto pinambour", .Telephone = "0102030405"},
            New Resto With {.Id = 2, .Nom = "Resto pinière", .Telephone = "0102030405"},
            New Resto With {.Id = 3, .Nom = "Resto toro", .Telephone = "0102030405"}
            }
        listeDesUtilisateurs = New List(Of Utilisateur)()
        listeDesSondages = New List(Of Sondage)()

    End Sub

    Public Function ObtientTousLesRestaurants() As List(Of Resto) Implements IDal.ObtientTousLesRestaurants
        Return listeDesRestaurants
    End Function

    Public Sub CreerRestaurant(nom As String, telephone As String) Implements IDal.CreerRestaurant
        Dim id As Integer = If(listeDesRestaurants.Count = 0, 1, listeDesRestaurants.Max(Function(r) r.Id + 1))
        listeDesRestaurants.Add(New Resto With {.Id = id, .Nom = nom, .Telephone = telephone})
    End Sub

    Public Sub ModifierRestaurant(id As Integer, nom As String, telephone As String) Implements IDal.ModifierRestaurant
        Dim resto As Resto = listeDesRestaurants.FirstOrDefault(Function(r) r.Id = id)
        If resto IsNot Nothing Then
            resto.Nom = nom
            resto.Telephone = telephone
        End If
    End Sub

    Public Function RestaurantExiste(nom As String) As Boolean Implements IDal.RestaurantExiste
        Return listeDesRestaurants.Any(Function(r) (String.Compare(r.Nom, nom, StringComparison.CurrentCultureIgnoreCase) = 0))
    End Function

    Public Function AjouterUtilisateur(prenom As String, motDePasse As String) As Integer Implements IDal.AjouterUtilisateur
        Dim id As Integer = If(listeDesUtilisateurs.Count = 0, 1, listeDesUtilisateurs.Max(Function(u) u.Id + 1))
        listeDesUtilisateurs.Add(New Utilisateur With {.Id = id, .Prenom = prenom, .MotDePasse = motDePasse})
        Return id
    End Function

    Public Function Authentifier(prenom As String, motDePasse As String) As Object Implements IDal.Authentifier
        Return listeDesUtilisateurs.FirstOrDefault(Function(u) u.Prenom.Equals(prenom) And u.MotDePasse.Equals(motDePasse))
    End Function

    Public Function ObtenirUtilisateur(id As Integer) As Utilisateur Implements IDal.ObtenirUtilisateur
        Return listeDesUtilisateurs.FirstOrDefault(Function(u) u.Id = id)
    End Function

    Public Function ObtenirUtilisateur(idStr As String) As Utilisateur Implements IDal.ObtenirUtilisateur
        Dim id As Integer
        If (Integer.TryParse(idStr, id)) Then
            Return ObtenirUtilisateur(id)
        End If
        Return Nothing
    End Function

    Public Function CreerUnSondage() As Integer Implements IDal.CreerUnSondage
        Dim id As Integer = If(listeDesSondages.Count = 0, 1, listeDesSondages.Max(Function(s) s.Id + 1))
        listeDesSondages.Add(New Sondage With {.Id = id, .Date = DateTime.Now, .Votes = New List(Of Vote)()})
        Return id
    End Function

    Public Sub AjouterVote(idSondage As Integer, idResto As Integer, idUtilisateur As Integer) Implements IDal.AjouterVote
        Dim vote As Vote = New Vote With {
            .Resto = listeDesRestaurants.First(Function(r) r.Id = idResto),
            .Utilisateur = listeDesUtilisateurs.First(Function(u) u.Id = idUtilisateur)
            }
    End Sub

    Public Function ADejaVote(idSondage As Integer, idUtilisateur As String) As Boolean Implements IDal.ADejaVote
        Dim utilisateur As Utilisateur = ObtenirUtilisateur(idUtilisateur)
        If utilisateur Is Nothing Then
            Return False
        End If
        Dim sondage As Sondage = listeDesSondages.First(Function(s) s.Id = idSondage)
        Return sondage.Votes.Any(Function(v) v.Utilisateur.Id = utilisateur.Id)
    End Function

    Public Function ObtenirLesResultats(idSondage As Integer) As List(Of Resultats) Implements IDal.ObtenirLesResultats
        Dim restaurants As List(Of Resto) = ObtientTousLesRestaurants()
        Dim resultats As List(Of Resultats) = New List(Of Resultats)()
        Dim sondage As Sondage = listeDesSondages.First(Function(s) s.Id = idSondage)
        For Each grouping As IGrouping(Of Integer, Vote) In sondage.Votes.GroupBy(Function(v) v.Resto.Id)
            Dim idRestaurant As Integer = grouping.Key
            Dim resto As Resto = restaurants.First(Function(r) r.Id = idRestaurant)
            Dim nombreDeVotes = grouping.Count()
            resultats.Add(New Resultats With {.Nom = resto.Nom,
                                                  .Telephone = resto.Telephone,
                                                  .NombreDeVotes = nombreDeVotes})
        Next
        Return resultats
    End Function

    Public Function EncodeMD5(motDePasse As String) As String Implements IDal.EncodeMD5
        Dim motDePasseSel As String = "ChoixResto" + motDePasse + "ASP.NET MVC"
        Return BitConverter.ToString(New MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)))
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        listeDesRestaurants = New List(Of Resto)()
        listeDesSondages = New List(Of Sondage)()
        listeDesUtilisateurs = New List(Of Utilisateur)()
    End Sub
End Class
