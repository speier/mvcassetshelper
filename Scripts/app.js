var app = {
    init: function () {
        $(document).ready(function () {
            $('#example-btn').click(function () {
                $('#example').html('Hello, world!').fadeToggle('slow');
            });
        });
    }
};

$(document).ready(function () {
    app.init();
});