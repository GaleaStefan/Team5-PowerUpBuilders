﻿//delete popup
var deleteUrl = '/Projects/Delete';
$(function () {
    $(".deleteProject").click(function () {
        debugger;
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: deleteUrl,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                $('#myModalContent0').html(data);
                $('#myModal0').modal('show');
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    $("#closbtn").click(function () {
        $('#myModal0').modal('hide');
    });
});

//create newProject
$(function () {
    $("#btnShowModal").click(function () {
        $("#createModal").modal('show');
    });

    $("#btnHideModal").click(function () {
        $("#createModal").modal('hide');
    });
});

var updateUrl = '/Projects/Edit';
$(function () {
    $(".updateProject").click(function () {
        debugger;
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: updateUrl,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                $('#myModalContent2').html(data);
                $('#myModal2').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    $("#closbtn").click(function () {
        $('#myModal2').modal('hide');
    });
});