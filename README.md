## MVC Assets Helper

Lightweight assets helper for ASP.NET Core MVC

## Usage

Register your assets in any View or PartialView:

    @{
        Html.Assets().Styles.Add("~/css/dashboard.css");
        Html.Assets().Scripts.Add("~/js/dashboard.js");
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

Copyright (c) Kalman Speier

Licensed under the MIT License: https://opensource.org/licenses/MIT
