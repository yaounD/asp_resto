
Imports System.Security.Cryptography
Imports Toto

Public Class Dal
    Implements IDal

    Private bdd As BddContext

    Sub New()
        bdd = New BddContext()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        bdd.Dispose()
    End Sub

    Public Function ObtientTousLesRestaurants() As List(Of Resto) Implements IDal.ObtientTousLesRestaurants
        Return bdd.Restos.ToList()
    End Function
    Public Sub CreerRestaurant(nom As String, telephone As String) Implements IDal.CreerRestaurant
        bdd.Restos.Add(New Resto With {.Nom = nom, .Telephone = telephone})
        bdd.SaveChanges()
    End Sub

    Public Sub ModifierRestaurant(id As Integer, nom As String, telephone As String) Implements IDal.ModifierRestaurant
        Dim restoTrouve As Resto = bdd.Restos.FirstOrDefault(Function(Resto) Resto.Id = id)

        If Not (restoTrouve) Is Nothing Then
            restoTrouve.Nom = nom
            restoTrouve.Telephone = telephone
            bdd.SaveChanges()
        End If
    End Sub

    Public Function RestaurantExiste(nom As String) As Boolean Implements IDal.RestaurantExiste
        Dim boolResult As Boolean = False
        Dim restoExiste As Resto = bdd.Restos.FirstOrDefault(Function(Resto As Resto) Resto.Nom.Equals(nom))
        If Not restoExiste Is Nothing Then
            boolResult = True
        End If
        Return boolResult
    End Function

    Public Function AjouterUtilisateur(prenom As String, motDePasse As String) As Integer Implements IDal.AjouterUtilisateur
        Dim mdpEncode As String = EncodeMD5(motDePasse)
        Dim usus As Utilisateur = bdd.Utilisateurs.Add(New Utilisateur With {.Prenom = prenom, .MotDePasse = mdpEncode})
        bdd.SaveChanges()
        Return usus.Id
    End Function

    Public Function ObtenirUtilisateur(id As Integer) As Utilisateur Implements IDal.ObtenirUtilisateur
        Return bdd.Utilisateurs.FirstOrDefault(Function(Utilisateur) Utilisateur.Id = id)
    End Function

    Public Function ObtenirUtilisateur(idStr As String) As Utilisateur Implements IDal.ObtenirUtilisateur

        Dim id As Integer
        If Integer.TryParse(idStr, id) Then
            Return ObtenirUtilisateur(id)
        End If
        Return Nothing
    End Function

    Public Function Authentifier(prenom As String, motDePasse As String) As Object Implements IDal.Authentifier

        Dim mdpCrypt As String = EncodeMD5(motDePasse)
        Return bdd.Utilisateurs.FirstOrDefault(Function(Utilisateur) Utilisateur.Prenom.Equals(prenom) And
                                                                     Utilisateur.MotDePasse.Equals(mdpCrypt))
    End Function

    Public Function ADejaVote(idSondage As Integer, idUtilisateur As String) As Boolean Implements IDal.ADejaVote
        Dim id As Integer
        If Integer.TryParse(idUtilisateur, id) Then
            Dim soso As Sondage = bdd.Sondages.First(Function(Sondage) Sondage.Id = idSondage)
            If soso.Votes Is Nothing Then
                Return False
            End If
            Return soso.Votes.Any(Function(vote) Not vote.Utilisateur Is Nothing And vote.Utilisateur.Id = id)
        End If
        Return False
    End Function

    Public Function CreerUnSondage() As Integer Implements IDal.CreerUnSondage
        Dim soso As Sondage = bdd.Sondages.Add(New Sondage With {.Date = DateTime.Now})
        bdd.SaveChanges()
        Return soso.Id

    End Function

    Public Sub AjouterVote(idSondage As Integer, idResto As Integer, idUtilisateur As Integer) Implements IDal.AjouterVote
        Dim vote As Vote = New Vote With {
        .Resto = bdd.Restos.First(Function(r) r.Id = idResto),
        .Utilisateur = bdd.Utilisateurs.First(Function(u) u.Id = idUtilisateur)
        }
        Dim sondage As Sondage = bdd.Sondages.First(Function(s) s.Id = idSondage)
        If sondage.Votes Is Nothing Then
            sondage.Votes = New List(Of Vote)
        End If
        sondage.Votes.Add(vote)
        bdd.SaveChanges()
    End Sub

    Public Function ObtenirLesResultats(idSondage As Integer) As List(Of Resultats) Implements IDal.ObtenirLesResultats
        Dim listeResultat As List(Of Resultats) = New List(Of Resultats)
        Dim listeResto As List(Of Resto) = ObtientTousLesRestaurants()
        Dim sondage As Sondage = bdd.Sondages.FirstOrDefault(Function(s) s.Id = idSondage)

        For Each vote As IGrouping(Of Integer, Vote) In sondage.Votes.GroupBy(Function(v) v.Resto.Id)
            Dim idRestaurant As Integer = vote.Key
            Dim resto As Resto = listeResto.First(Function(r) r.Id = idRestaurant)
            Dim nombreDeVotes = vote.Count()
            listeResultat.Add(New Resultats With {.Nom = resto.Nom,
                                                  .Telephone = resto.Telephone,
                                                  .NombreDeVotes = nombreDeVotes})
        Next

        Return listeResultat


    End Function


    Public Function EncodeMD5(motDePasse As String) As String Implements IDal.EncodeMD5
        Dim motDePasseSel As String = "ChoixResto" + motDePasse + "ASP.NET MVC"
        Return BitConverter.ToString(New MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)))

    End Function


End Class
