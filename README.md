## MVC Assets Helper

Lightweight assets helper for ASP.NET MVC

## NuGet

For a NuGet package, pelase check out the [nuget](https://github.com/speier/mvcassetshelper/tree/nuget) branch

## ASP.NET Core

For an ASP.NET Core MVC version with the above NuGet package, please check out the [aspnetcore](https://github.com/speier/mvcassetshelper/tree/aspnetcore) branch

## Usage

Register your assets in any View or PartialView:

    @{
        Html.Assets().Styles.Add("/Dashboard/Content/Dashboard.css");
        Html.Assets().Scripts.Add("/Dashboard/Scripts/Dashboard.js");
    }

Render your assets in the Layout page:

    <head>
        @Html.Assets().Styles.Render()
    </head>
    <body>
        ...
        @Html.Assets().Scripts.Render()
    </body>

## License

Copyright 2012 Kalman Speier

Licensed under the MIT License: http://www.opensource.org/licenses/mit-license.php
