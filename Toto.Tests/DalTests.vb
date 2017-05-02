Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Data.Entity

<TestClass()>
Public Class DalTests

    Private dal As IDal

    <TestInitialize()>
    Public Sub Init_AvantChaqueTest()
        Dim init As IDatabaseInitializer(Of BddContext) = New DropCreateDatabaseAlways(Of BddContext)
        Database.SetInitializer(init)
        init.InitializeDatabase(New BddContext)
        Me.dal = New Dal
    End Sub

    <TestCleanup()>
    Public Sub ApresChaqueTest()
        Me.dal.Dispose()
    End Sub

    <TestMethod()>
    Public Sub CreerRestaurant_AvecUnNouveauRestaurant_ObtientTousLesRestaurantsRenvoitBienLeRestaurant()
        Me.dal.CreerRestaurant("La bonne fourchette", "0102030405")
        Dim restos As List(Of Resto) = Me.dal.ObtientTousLesRestaurants
        Assert.IsNotNull(restos)
        Assert.AreEqual(1, restos.Count)
        Assert.AreEqual("La bonne fourchette", restos(0).Nom)
        Assert.AreEqual("0102030405", restos(0).Telephone)
    End Sub

    <TestMethod()>
    Public Sub ModifierRestaurant_CreationDUnNouveauRestaurantEtChangementNomEtTelephone_LaModificationEstCorrecteApresRechargement()
        Me.dal.CreerRestaurant("La bonne fourchette", "0102030405")
        Me.dal.ModifierRestaurant(1, "La bonne cuillere", "0203040506")
        Dim restos As List(Of Resto) = Me.dal.ObtientTousLesRestaurants
        Assert.IsNotNull(restos)
        Assert.AreEqual(1, restos.Count)
        Assert.AreEqual("La bonne cuillere", restos(0).Nom)
    End Sub

    <TestMethod()>
    Public Sub RestaurantExiste_AvecCreationDunRestauraunt_RenvoiQuilExiste()
        Me.dal.CreerRestaurant("La bonne fourchette", "0102030405")
        Dim existe As Boolean = Me.dal.RestaurantExiste("La bonne fourchette")
        Assert.IsTrue(existe)
    End Sub

    <TestMethod()>
    Public Sub RestaurantExiste_AvecRestaurauntInexistant_RenvoiQuilExiste()
        Dim existe As Boolean = Me.dal.RestaurantExiste("La bonne fourchette")
        Assert.IsFalse(existe)
    End Sub

    <TestMethod()>
    Public Sub ObtenirUtilisateur_UtilisateurInexistant_RetourneNull()
        Dim utilisateur As Utilisateur = Me.dal.ObtenirUtilisateur(1)
        Assert.IsNull(utilisateur)
    End Sub

    <TestMethod()>
    Public Sub ObtenirUtilisateur_IdNonNumerique_RetourneNull()
        Dim utilisateur As Utilisateur = Me.dal.ObtenirUtilisateur("abc")
        Assert.IsNull(utilisateur)
    End Sub

    <TestMethod()>
    Public Sub AjouterUtilisateur_NouvelUtilisateurEtRecuperation_LutilisateurEstBienRecupere()
        Me.dal.AjouterUtilisateur("Nouvel utilisateur", "12345")
        Dim utilisateur As Utilisateur = Me.dal.ObtenirUtilisateur(1)
        Assert.IsNotNull(utilisateur)
        Assert.AreEqual("Nouvel utilisateur", utilisateur.Prenom)
        utilisateur = Me.dal.ObtenirUtilisateur("1")
        Assert.IsNotNull(utilisateur)
        Assert.AreEqual("Nouvel utilisateur", utilisateur.Prenom)
    End Sub

    <TestMethod()>
    Public Sub Authentifier_LoginMdpOk_AuthentificationOK()
        Me.dal.AjouterUtilisateur("Nouvel utilisateur", "12345")
        Dim utilisateur As Utilisateur = Me.dal.Authentifier("Nouvel utilisateur", "12345")
        Assert.IsNotNull(utilisateur)
        Assert.AreEqual("Nouvel utilisateur", utilisateur.Prenom)
    End Sub

    <TestMethod()>
    Public Sub Authentifier_LoginOkMdpKo_AuthentificationKO()
        Me.dal.AjouterUtilisateur("Nouvel utilisateur", "12345")
        Dim utilisateur As Utilisateur = Me.dal.Authentifier("Nouvel utilisateur", "0")
        Assert.IsNull(utilisateur)
    End Sub

    <TestMethod()>
    Public Sub Authentifier_LoginKoMdpOk_AuthentificationKO()
        Me.dal.AjouterUtilisateur("Nouvel utilisateur", "12345")
        Dim utilisateur As Utilisateur = Me.dal.Authentifier("Nouvel", "12345")
        Assert.IsNull(utilisateur)
    End Sub

    <TestMethod()>
    Public Sub Authentifier_LoginMdpKo_AuthentificationKO()
        Dim utilisateur As Utilisateur = Me.dal.Authentifier("Nouvel utilisateur", "12345")
        Assert.IsNull(utilisateur)
    End Sub

    <TestMethod()>
    Public Sub ADejaVote_AvecIdNonNumerique_RetourneFalse()
        Dim pasVote As Boolean = Me.dal.ADejaVote(1, "abc")
        Assert.IsFalse(pasVote)
    End Sub

    <TestMethod()>
    Public Sub ADejaVote_UtilisateurNAPasVote_RetourneFalse()
        Dim idSondage As Integer = Me.dal.CreerUnSondage
        Dim idUtilisateur As Integer = Me.dal.AjouterUtilisateur("Nouvel utilisateur", "12345")
        Dim pasVote As Boolean = Me.dal.ADejaVote(idSondage, idUtilisateur.ToString)
        Assert.IsFalse(pasVote)
    End Sub

    <TestMethod()>
    Public Sub ADejaVote_UtilisateurAVote_RetourneTrue()
        Dim idSondage As Integer = Me.dal.CreerUnSondage
        Dim idUtilisateur As Integer = Me.dal.AjouterUtilisateur("Nouvel utilisateur", "12345")
        Me.dal.CreerRestaurant("La bonne fourchette", "0102030405")
        Me.dal.AjouterVote(idSondage, 1, idUtilisateur)
        Dim aVote As Boolean = Me.dal.ADejaVote(idSondage, idUtilisateur.ToString)
        Assert.IsTrue(aVote)
    End Sub

    <TestMethod()>
    Public Sub ObtenirLesResultats_AvecQuelquesChoix_RetourneBienLesResultats()
        Dim idSondage As Integer = Me.dal.CreerUnSondage
        Dim idUtilisateur1 As Integer = Me.dal.AjouterUtilisateur("Utilisateur1", "12345")
        Dim idUtilisateur2 As Integer = Me.dal.AjouterUtilisateur("Utilisateur2", "12345")
        Dim idUtilisateur3 As Integer = Me.dal.AjouterUtilisateur("Utilisateur3", "12345")
        Me.dal.CreerRestaurant("Resto piniere", "0102030405")
        Me.dal.CreerRestaurant("Resto pinambour", "0102030405")
        Me.dal.CreerRestaurant("Resto mate", "0102030405")
        Me.dal.CreerRestaurant("Resto ride", "0102030405")
        Me.dal.AjouterVote(idSondage, 1, idUtilisateur1)
        Me.dal.AjouterVote(idSondage, 3, idUtilisateur1)
        Me.dal.AjouterVote(idSondage, 4, idUtilisateur1)
        Me.dal.AjouterVote(idSondage, 1, idUtilisateur2)
        Me.dal.AjouterVote(idSondage, 1, idUtilisateur3)
        Me.dal.AjouterVote(idSondage, 3, idUtilisateur3)
        Dim resultats As List(Of Resultats) = Me.dal.ObtenirLesResultats(idSondage)
        Assert.AreEqual(3, resultats(0).NombreDeVotes)
        Assert.AreEqual("Resto piniere", resultats(0).Nom)
        Assert.AreEqual("0102030405", resultats(0).Telephone)
        Assert.AreEqual(2, resultats(1).NombreDeVotes)
        Assert.AreEqual("Resto mate", resultats(1).Nom)
        Assert.AreEqual("0102030405", resultats(1).Telephone)
        Assert.AreEqual(1, resultats(2).NombreDeVotes)
        Assert.AreEqual("Resto ride", resultats(2).Nom)
        Assert.AreEqual("0102030405", resultats(2).Telephone)
    End Sub

    <TestMethod()>
    Public Sub ObtenirLesResultats_AvecDeuxSondages_RetourneBienLesBonsResultats()
        Dim idSondage1 As Integer = Me.dal.CreerUnSondage
        Dim idUtilisateur1 As Integer = Me.dal.AjouterUtilisateur("Utilisateur1", "12345")
        Dim idUtilisateur2 As Integer = Me.dal.AjouterUtilisateur("Utilisateur2", "12345")
        Dim idUtilisateur3 As Integer = Me.dal.AjouterUtilisateur("Utilisateur3", "12345")
        Me.dal.CreerRestaurant("Resto piniere", "0102030405")
        Me.dal.CreerRestaurant("Resto pinambour", "0102030405")
        Me.dal.CreerRestaurant("Resto mate", "0102030405")
        Me.dal.CreerRestaurant("Resto ride", "0102030405")
        Me.dal.AjouterVote(idSondage1, 1, idUtilisateur1)
        Me.dal.AjouterVote(idSondage1, 3, idUtilisateur1)
        Me.dal.AjouterVote(idSondage1, 4, idUtilisateur1)
        Me.dal.AjouterVote(idSondage1, 1, idUtilisateur2)
        Me.dal.AjouterVote(idSondage1, 1, idUtilisateur3)
        Me.dal.AjouterVote(idSondage1, 3, idUtilisateur3)
        Dim idSondage2 As Integer = Me.dal.CreerUnSondage
        Me.dal.AjouterVote(idSondage2, 2, idUtilisateur1)
        Me.dal.AjouterVote(idSondage2, 3, idUtilisateur1)
        Me.dal.AjouterVote(idSondage2, 1, idUtilisateur2)
        Me.dal.AjouterVote(idSondage2, 4, idUtilisateur3)
        Me.dal.AjouterVote(idSondage2, 3, idUtilisateur3)
        Dim resultats1 As List(Of Resultats) = Me.dal.ObtenirLesResultats(idSondage1)
        Dim resultats2 As List(Of Resultats) = Me.dal.ObtenirLesResultats(idSondage2)
        Assert.AreEqual(3, resultats1(0).NombreDeVotes)
        Assert.AreEqual("Resto piniere", resultats1(0).Nom)
        Assert.AreEqual("0102030405", resultats1(0).Telephone)
        Assert.AreEqual(2, resultats1(1).NombreDeVotes)
        Assert.AreEqual("Resto mate", resultats1(1).Nom)
        Assert.AreEqual("0102030405", resultats1(1).Telephone)
        Assert.AreEqual(1, resultats1(2).NombreDeVotes)
        Assert.AreEqual("Resto ride", resultats1(2).Nom)
        Assert.AreEqual("0102030405", resultats1(2).Telephone)
        Assert.AreEqual(1, resultats2(0).NombreDeVotes)
        Assert.AreEqual("Resto pinambour", resultats2(0).Nom)
        Assert.AreEqual("0102030405", resultats2(0).Telephone)
        Assert.AreEqual(2, resultats2(1).NombreDeVotes)
        Assert.AreEqual("Resto mate", resultats2(1).Nom)
        Assert.AreEqual("0102030405", resultats2(1).Telephone)
        Assert.AreEqual(1, resultats2(2).NombreDeVotes)
        Assert.AreEqual("Resto piniere", resultats2(2).Nom)
        Assert.AreEqual("0102030405", resultats2(2).Telephone)
    End Sub
End Class

