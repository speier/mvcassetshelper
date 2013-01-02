## MVC Assets Helper

Lightweight assets helper for ASP.NET MVC

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
