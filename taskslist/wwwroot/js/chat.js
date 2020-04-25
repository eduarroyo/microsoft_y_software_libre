"use strict";
$(function() {

    var $sendButton = $("#sendButton");
    $sendButton.prop("disabled", true);

    $sendButton.on("click", function(event) {
        var $userInput = $("#userInput");
        var user = $userInput.val();
        var $messageInput = $("#messageInput");
        var message = $messageInput.val();
        connection.invoke("SendMessage", user, message)
            .then(function() {
                $messageInput.val("");
            })
            .catch(function(err) {
                console.error(err);
            });

        event.preventDefault();
    });

    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    connection.on("ReceiveMessage", function (user, message) {
        $("#messagesList").append("<li>" + user + ": " + message + "</li>")
    });

    connection.start()
        .then(function () {
            $("#sendButton").prop("disabled", false);
        }).catch(function (err) {
            console.error(err);
        });
});