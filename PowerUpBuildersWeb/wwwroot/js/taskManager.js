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
                    $(".modal").on("hidden.bs.modal", function () {
                        $(".modal").remove();
                    });
                }
            });
        }
    }
}();

var TaskManager = function () {

}();

$(document).ready(
    $(".task-load-button").click(function () {
        TaskPopupLoader.getPopupData(this.getAttribute("data-taskId"));
    })
)