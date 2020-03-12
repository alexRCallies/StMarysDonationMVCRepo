// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $("#bloodType").change(function () {
        var filterValue = $(this).val();
        var bt = $('#bloodTypes');
        var row = $('.flex-row');
   
        row.hide();
        row.each(function () {
            bt.each(function (i, el) {
                if ($(el).val() == filterValue) {
                    $(el).show(); 
                }
            });

        if ("" == filterValue) {
            row.show();
        }
    })
})