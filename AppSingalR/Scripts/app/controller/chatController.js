var app = angular.module('app');
app.controller('chatController', function ($scope) {

    $.connection.hub.url = ReadConnectionSettings();
    var IwannaChat = $.connection.chatHub;

    $scope.load = function() {
        IwannaChat.client.addMessage = function(message) {
            $("#listMesagges").append('<li>' + message + '</li>');
        };
        $.connection.hub.start();
    };

    $scope.load();

    $scope.send = function() {

        IwannaChat.server.send(
            $("#txtMessage").val()
        );
        $.connection.hub.start();
    };

    $scope.clear = function() {
        $("#listMesagges").empty();
    };


})