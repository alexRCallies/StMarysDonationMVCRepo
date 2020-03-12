// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $("#bloodType").change(function () {
        var filterValue = $(this).val();
        var row = $('.row');
        var i = 3;
        row.hide()
        row.each(function (i, el) {
            if ($(el).attr('data-type') == filterValue) {
                $(el).show();
            }
        });
        if ("" == filterValue) {
            row.show();
        }
    })
})