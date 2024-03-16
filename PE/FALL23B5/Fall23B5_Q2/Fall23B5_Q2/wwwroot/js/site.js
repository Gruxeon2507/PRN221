
"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/SignalRHub")
    .build();

connection.on("LoadStudent", function () {
    location.href = '/Student/List'
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});