var TaskEditor = function () {
    function _postToServer() {
        var data = new FormData($('form')[0]);

        return $.ajax({
            type: "post",
            url: "/Project/TaskEditor/",
            contentType: false,
            processData: false,
            data: data,
            success: function (response) {
                if (response == null || response == "") {
                    window.location.reload();
                    return true;
                }

                $("#edit-body").replaceWith(response);
                $("form").submit(function (event) {
                    event.preventDefault();
                    TaskEditor.updateTask();
                });
            }
        });
    }

    return {
        updateTask: function () {
            _postToServer();
        }
    }
}();

var TaskFiles = function () {
    function _requestDelete(fileName) {
        $.ajax({
            type: "post",
            url: "/api/taskFiles/delete",
            data: {file: fileName}
        })
    }
    function _getFiles (taskId) {
        return $.ajax({
            type: "get",
            url: "/api/taskFiles/",
            data: { taskId: taskId },
        });
    }

    async function _populateTable(table, taskId) {
        var filesString = await _getFiles(taskId);
        var files = JSON.parse(filesString);

        $.each(files, function (_k, val) {
            var button = '<button class="file-button container-fluid w-100 overflow-auto btn" data-fullName="' + val.Name + '" data-link="' + val.Path + val.Name + '">' + val.NameSimplified + '</button>';
            $(table).jsGrid("insertItem", { Name: val.Name, File: button });
        });

        $(".file-button").click(function (event) {
            // Source: https://stackoverflow.com/questions/16086162/handle-file-download-from-ajax-post
            $.ajax({
                type: "get",
                url: "/api/taskFiles/file",
                data: { fileName: $(this).attr("data-fullName") },
                xhrFields: {
                    responseType: 'blob'
                },
                success: function (blob, status, xhr) {
                    var filename = "";
                    var disposition = xhr.getResponseHeader('Content-Disposition');
                    if (disposition && disposition.indexOf('attachment') !== -1) {
                        var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
                        var matches = filenameRegex.exec(disposition);
                        if (matches != null && matches[1]) filename = matches[1].replace(/['"]/g, '');
                    }

                    if (typeof window.navigator.msSaveBlob !== 'undefined') {
                        window.navigator.msSaveBlob(blob, filename);
                    } else {
                        var URL = window.URL || window.webkitURL;
                        var downloadUrl = URL.createObjectURL(blob);

                        if (filename) {
                            var a = document.createElement("a");
                            if (typeof a.download === 'undefined') {
                                window.location.href = downloadUrl;
                            } else {
                                a.href = downloadUrl;
                                a.download = filename;
                                document.body.appendChild(a);
                                a.click();
                            }
                        } else {
                            window.location.href = downloadUrl;
                        }

                        setTimeout(function () { URL.revokeObjectURL(downloadUrl); }, 100); 
                    }
                }
            });
        });
    }

    function _createTable(table) {
        $(table).jsGrid({
            width: "100%",
            height: "auto",

            inserting: false,
            editing: false,
            sorting: true,
            paging: true,

            onItemDeleted: function (args) {
               _requestDelete(args.item.Name);
            },

            fields: [
                {
                    name: "Name",
                    type: "text",
                    visible: false
                },

                {
                    name: "File",
                    type: "text"
                },

                { type: "control" }
            ]
        });
    }

    return {
        loadFilesTable: function (table, task) {
            _createTable(table);
            _populateTable(table, task);
        }
    }
}();

var TaskEmployees = function () {
    function _linkFromItem(item) {
        return {
            Id: 0,
            EmployeeId: item.Name,
            TaskId: parseInt($(".modal").attr("data-taskId")),
            ActualHours: item.ActualHours,
            EstimatedHours: item.EstimatedHours
        };
    }
    return {
        updateLinkInfo: function (item) {
            $.ajax({
                type: "post",
                url: "/api/taskEmployees/update",
                data: { link: _linkFromItem(item) }
            })
        },

        addLink: function (item) {
            $.ajax({
                type: "post",
                url: "/api/taskEmployees/add",
                data: { link: _linkFromItem(item) }
            })
        },

        deleteLink: function (item) {
            $.ajax({
                type: "post",
                url: "/api/taskEmployees/delete",
                data: { link: _linkFromItem(item) }
            })
        }
    }
}();

var TaskPopup = function () {
    function _populateAssigedTable(id, selector) {
        $.ajax({
            type: "get",
            url: "/api/taskEmployees/" + id,
            success: function (response) {
                $(selector).jsGrid("option", "insertByScript", true);
                $.each(response, function (_k, val) {
                    $(selector).jsGrid("insertItem", { Name: val.employeeId, EstimatedHours: val.estimatedHours, ActualHours: val.actualHours });
                });
                $(selector).jsGrid("option", "insertByScript", false);
            }
        });
    }

    function _loadAssignedTable(selector) {
        $.ajax({
            type: "get",
            url: "/api/employee/list",
            success: function (response) {
                _intializeAssignedEmployeesTable(selector, JSON.parse(response));
            }
        })
    }

    function _intializeAssignedEmployeesTable(selector, employees) {
        $(selector).jsGrid({
            width: "100%",
            height: "auto",

            inserting: true,
            editing: true,
            sorting: true,
            paging: true,
            sorting: true,

            onItemUpdating: function (args) {
                $.each(args.grid.data, function (_k, val) {
                    if (val.Name == args.item.Name) {
                        args.cancel = true;
                        alert("Employee is already assigned to this task");
                        return false;
                    }
                });
            },

            onItemUpdated: function (args) {
                if (args.item.Name == args.previousItem.Name) {
                    TaskEmployees.updateLinkInfo(args.item);
                }
                else {
                    TaskEmployees.deleteLink(args.previousItem);
                    TaskEmployees.addLink(args.item);
                }
            },

            onItemDeleted: function (args) {
                TaskEmployees.deleteLink(args.item);
            },

            onItemInserted: function (args) {
                if ($("#jsGrid").jsGrid("option", "insertByScript") == false) {
                    TaskEmployees.addLink(args.item);
                }
            },

            onItemInserting: function (args) {
                if ($("#jsGrid").jsGrid("option", "insertByScript") == false) {
                    $.each(args.grid.data, function (_k, val) {
                        if (val.Name == args.item.Name) {
                            args.cancel = true;
                            alert("Employee is already assigned to this task");
                            return false;
                        }
                    });
                }
            },

            fields: [
                {
                    align: "center",
                    name: "Name",
                    title: "Name",
                    type: "select",
                    items: [],
                    items: employees,
                    valueField: "Id",
                    textField: "Name",
                    validate: "required"
                },
                {
                    name: "EstimatedHours",
                    type: "number",
                    validate: "required"
                },
                {
                    name: "ActualHours",
                    type: "number",
                    validate: "required"
                },

                { type: "control" }
            ]
        });

        _populateAssigedTable($(".modal").attr("data-taskId"), selector);
    }

    function _switchToEdit() {
        $("#edit-body").removeClass("d-none").addClass("d-block");
        $("#readonly-body").removeClass("d-block").addClass("d-none");

        $("#edit-button").removeClass("d-block").addClass("d-none");
        $("#save-button").removeClass("d-none").addClass("d-block");

        $(".modal-title").text("Task Editor");
        $(".badge").removeClass("d-block").addClass("d-none");
    }

    function _bindPopupEvents() {
        $("form").submit(function (event) {
            event.preventDefault();
            TaskEditor.updateTask();
        });

        $(".modal").on("hidden.bs.modal", function () {
            $(".modal").remove();
        });

        $("#edit-button").click(function () {
            _switchToEdit();
        });

        $("#save-button").click(function () {
            $("form").submit();
        });
    }

    function _addToPage(htmlText) {
        $("body").append(htmlText);
        $(".modal").modal("show");
        _loadAssignedTable("#jsGrid");
        TaskFiles.loadFilesTable("#filesGrid", $(".modal").attr("data-taskId"));
        _bindPopupEvents();
    }

    function _requestPopup(id) {
        $.ajax({
            type: "POST",
            url: "/Task/Details/",
            data: { projectId: $("#tasks-list").attr("data-parentProject"), taskId: id },
            success: function (response) {
                _addToPage(response);
            }
        });
    }

    return {
        loadTask: function (id) {
            _requestPopup(id);
        },

        createTask: function () {
            _requestPopup(0);
        },

        removeFromPage: function () {

        }
    }
}();

var TaskManager = function () {
    function _requestDelete(taskId) {
        $.ajax({
            type: "POST",
            url: "/Task/Delete/",
            data: { id: taskId },
            success: function (response) {
                window.location.href = response;
            }
        });
    }
    return {
        deleteTask: function (taskId) {
            _requestDelete(taskId)
        }
    }
}();

$(function () {
    $(".task-load-button").click(function () {
        TaskPopup.loadTask(this.getAttribute("data-taskId"));
    });

    $("#new-task-button").click(function () {
        TaskPopup.createTask();
    });

    $(".task-delete").click(function () {
        TaskManager.deleteTask(this.getAttribute("data-taskId"));
    })
});