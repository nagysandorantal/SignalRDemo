"use strict";

    $(function ()
    {
        // Create the connection to our SignalR-powered Chat Hub on the server.
        var signalRChatHub = $.connection.chatHub;


        // Add chat messages from server to dialog.
        // Method invoked from server.
        signalRChatHub.client.addChatMessage = function (message)
        {
            $('#chatdialog').append('<li>' + message + '</li>');
        };

        // Click event-handler for broadcasting chat messages.
        $('#broadcast').click(function ()
        {
            // Call Server method.
            signalRChatHub.server.pushChatMessageToClients($('#message').val());

            $('#message').val("");
        });

        // Start the SignalR Hub.
        $.connection.hub.start(function ()
        {
            // Do stuff here, if needed.
        });

        // Click event-handler for clearing chat messages.
        $('#clear').click(function() {

            $('#chatdialog').empty();
        });
    });
