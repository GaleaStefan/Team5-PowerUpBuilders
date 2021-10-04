//delete popup
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

$(document).ready(function () {
    $('#showCreateProject').click(function () {
        var url = $('#createProjectModal').data('url');
        $.get(url, function (data) {
            $('#createContainer').html(data);

            $('#createProjectModal').modal('show');
        });
    })
})

$(document).ready(function () {
    $(".btn-group-vertical").hover(function () {
        $.each($(this).children(), function (_k, child) {
            $(child).css("opacity", 1);
            $(child).prop("disabled", false);
            
        });
    }, function () {
        $.each($(this).children(), function (_k, child) {
            $(child).css("opacity", 0);
            $(child).prop("disabled", true);
        });
    });
});