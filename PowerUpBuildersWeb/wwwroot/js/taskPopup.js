var TaskPopupLoader = function () {
    return {
        getPopupData: function (id) {
            $.ajax({
                type: "POST",
                url: "/Task/Details/",
                data: { ID: id },
                success: function (response) {
                    $("body").append(response);
                    $(".modal").modal("show");
                    alert(response);
                }
            });
        }
    }
}();

$(document).ready(
    $(".task-load-button").click(function () {
        TaskPopupLoader.getPopupData(this.getAttribute("data-taskId"));
    })
)