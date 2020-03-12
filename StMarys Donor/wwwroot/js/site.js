// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $("#bloodType").change(function () {
        var filterValue = $(this).val();
        var bt = $('.bloodTypes');
        var row = $('.flex-row');

        row.each(function (i, val) {
            if (bt[i].innerText.toLowerCase() != filterValue.toLowerCase()) {
                console.log(val);
                val.hidden = true;
            }
            });

    })
    $("#ethnicity").change(function () {
        var filterValue = $(this).val();
        var ethnic = $('.ethnicity');
        var row = $('.flex-row');

        row.each(function (i, val) {
            if (ethnic[i].innerText.toLowerCase() != filterValue.toLowerCase()) {
                console.log(val);
                val.hidden = true;
            }
        });
    })
    $("#gender").change(function () {
        var filterValue = $(this).val();
        var gen = $('.gender');
        var row = $('.flex-row');

        row.each(function (i, val) {
            if (gen[i].innerText.toLowerCase() != filterValue.toLowerCase()) {
                console.log(val);
                val.hidden = true;
            }
        });
    })
    $("#medications").change(function () {
        var filterValue = $(this).val();
        var meds = $('.medication');
        var row = $('.flex-row');

        row.each(function (i, val) {
            if (meds[i].innerText.toLowerCase() != filterValue.toLowerCase()) {
                console.log(val);
                val.hidden = true;
            }
        });
    })
    $("#allergies").change(function () {
        var filterValue = $(this).val();
        var alrgy = $('.allergy');
        var row = $('.flex-row');

        row.each(function (i, val) {
            if (alrgy[i].innerText.toLowerCase() != filterValue.toLowerCase()) {
                console.log(val);
                val.hidden = true;
            }
        });
    })
})