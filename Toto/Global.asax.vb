Imports System.Data.Entity
Imports System.Web.Mvc
Imports System.Web.Routing

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        RouteConfig.RegisterRoutes(RouteTable.Routes)

        'Initisalisation de la base
        Dim init As IDatabaseInitializer(Of BddContext) = New InitChoixResto()
        Database.SetInitializer(init)
        init.InitializeDatabase(New BddContext)

    End Sub
End Class
