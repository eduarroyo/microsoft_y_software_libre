"use strict";
$(function() {

    //Disable send button until connection is established
    $("#create").prop("disabled", true);

    $("#create").on("click", function (event) {
        var task = document.getElementById("taskInput").value.trim();
        console.log(task);
        if(task.length) {
            connection.invoke("NewTask", task)
                .then(function() {
                    $("#taskInput").val("");
                })
                .catch(function (err) {
                return console.error(err.toString());
            });
            event.preventDefault();
        }
    });

    $("#list").on("change", ".check", function(event) {
        var li = $(this).parent();
        var id = li.data("id");
        var check = $(this).is(":checked");
        console.log(check ? "Check" : "Uncheck", id);

        connection.invoke("MarkAs", id, check).catch(function (err) {
            return console.error(err.toString());
        });
    });

    $("#list").on("click", ".delete", function(event) {
        var li = $(this).parent();
        var id = li.data("id");
        console.log("delete", id);

        connection.invoke("RemoveTask", id).catch(function (err) {
            return console.error(err.toString());
        });
    });

    function newTask(task) {
        var checked, done;
        if(task.resuelta) {
            checked = 'checked=checked';
            done="done"
        } else {
            checked = "";
            done=""
        }

        $("#list").append('<li data-id="' + task.tareaId + '"class="' + done + '" id="t' + task.tareaId + '"><input class="check" id="chk' + task.tareaId + '" type="checkbox" ' + checked + '/><span class="task">' + task.tarea + '</span><span class="delete">X</span></li>');
    }


    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/tasklisthub")
        .build();


    connection.on("listUpdated", function (taskList) {
        var checked, striked, task;
        console.log("listUpdated", taskList);

        $("#list").empty();
        for(var i in taskList) {
            var task = taskList[i];
            newTask(task);
        }
    });

    connection.on("taskUpdated", function(task) {
        console.log("taskUpdated", task);

        var tUpdate = $("#t" + task.tareaId);
        if(tUpdate.length) {
            tUpdate.children()[0].innerHTML=task.tarea;
            if(task.resuelta) {
                tUpdate.addClass("done");
                tUpdate.children("input").prop("checked", true);
            } else {
                tUpdate.removeClass("done");
                tUpdate.children("input").prop("checked", false);
            }
        } else {
            newTask(task);
        }

    });

    connection.on("taskRemoved", function(taskId) {
        console.log("taskRemoved", taskId);

        var tRemove = $("#t" + taskId);
        if(tRemove.length) {
            tRemove.remove();
        }
    });

    connection.start().then(function() {
        connection
            .invoke("AfterConnected")
            .then(function() {
                $("#create").prop("disabled", false);
            })
            .catch(function(err) {
                return console.error(err.toString());
            });

    }).catch(function (err) {
        return console.error(err.toString());
    });
});