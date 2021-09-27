var TaskPopupLoader = function () {
    return {
        switchToEditMode: function () {
            $("#edit-body").removeClass("d-none").addClass("d-block");
            $("#readonly-body").removeClass("d-block").addClass("d-none");

            $("#edit-button").removeClass("d-block").addClass("d-none");
            $("#save-button").removeClass("d-none").addClass("d-block");

            $(".modal-title").text("Task Editor");
            $(".badge").removeClass("d-block").addClass("d-none");
        },

        addPopup: function (htmlText) {
            $("body").append(htmlText);
            $(".modal").modal("show");
            $(".modal").on("hidden.bs.modal", function () {
                $(".modal").remove();
            });

            $("#edit-button").click(function () {
                TaskPopupLoader.switchToEditMode();
            });

            $("#save-button").click(function () {
                $("form").submit();
            })
        },
        getPopupData: function (id) {
            $.ajax({
                type: "POST",
                url: "/Task/Details/",
                data: { projectId: $("#tasks-list").attr("data-parentProject"), ID: id },
                success: function (response) {
                    TaskPopupLoader.addPopup(response);
                }
            });
        }
    }
}();

var TaskManager = function () {
    return {
        triggerTaskDelete: function (_id) {
            $.ajax({
                type: "POST",
                url: "/Task/Delete/",
                data: { id: _id },
                success: function (response) {
                    alert(response);
                    window.location.href = response;
                }
            });
        },

        enableCreateForm: function () {
            $.ajax({
                type: "GET",
                url: "/Task/Create/",
                data: { projectId: $("#tasks-list").attr("data-parentProject")},
                success: function (response) {
                    TaskPopupLoader.addPopup(response);
                }
            })
        },
    }
}();

$(function () {
    $(".task-load-button").click(function () {
        TaskPopupLoader.getPopupData(this.getAttribute("data-taskId"));
    });

    $("#new-task-button").click(function () {
        TaskManager.enableCreateForm();
    });

    $(".task-delete").click(function () {
        TaskManager.triggerTaskDelete(this.getAttribute("data-taskId"));
    })
})
