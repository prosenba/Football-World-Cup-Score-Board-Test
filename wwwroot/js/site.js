// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#btnGetCurrentScores').click(function () {
    $.ajax({
        type: 'POST',
        url: '/Home/GetScores',
        success: function (result) {
            // Handle the result here

            $("#scoreBoardDiv").html(result);
        },
        error: function (xhr, status, error) {
            // Send an error message back to the controller
            $.ajax({
                type: 'POST',
                url: '/Home/HandleJavaScriptError',
                data: { 'error': error }
            });
        }


    });
});

