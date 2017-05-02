﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
    <script type="text/javascript">
            jQuery.validator.addMethod("verifcontact",
                function (value, element, params) {
                    var tel = $("#" + params.parametre1).val();
                    var email = $("#" + params.parametre2).val();
                    return tel != '' || email != '';
                });
            jQuery.validator.unobtrusive.adapters.add
                ("verifcontact", ["parametre1", "parametre2"], function (options) {
                    options.rules["verifcontact"] = options.params;
                    options.messages["verifcontact"] = options.message;
                });
    </script>
    <style type="text/css">
        table {
            border-collapse: collapse;
        }

        td, th {
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Toto", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
                @Html.ActionLink("Restaurant", "Index", "Restaurant", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav"></ul>
            </div>
        </div>
    </div>

    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <script src="~/Scripts/jquery.validate-vsdoc.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.js"></script>


</body>
</html>
