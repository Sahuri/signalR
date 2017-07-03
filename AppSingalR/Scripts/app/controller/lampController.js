
var app = angular.module('app');
app.controller('lampController', function ($scope) {

    $.connection.hub.url = ReadConnectionSettings();
    var signalR = $.connection.lampHub;

    $scope.b1 = "Off";
    $scope.b2 = "Off";
    $scope.b3 = "Off";
    $scope.b4 = "Off";
    $scope.b5 = "Off";
    $scope.b6 = "Off";
    $scope.b7 = "Off";
    $scope.b8 = "Off";


    $scope.send = function (e, v) {
        switch (e) {
            case 'b1':
                $scope.b1 = setLabel(v);
                break;
            case 'b2':
                $scope.b2 = setLabel(v);
                break;
            case 'b3':
                $scope.b3 = setLabel(v);
                break;
            case 'b4':
                $scope.b4 = setLabel(v);
                break;
            case 'b5':
                $scope.b5 = setLabel(v);
                break;
            case 'b6':
                $scope.b6 = setLabel(v);
                break;
            case 'b7':
                $scope.b7 = setLabel(v);
                break;
            case 'b8':
                $scope.b8 = setLabel(v);
                break;
        };

        var arrBtn = [];
        var b1 = getStatus('b1', $scope.b1);
        var b2 = getStatus('b2', $scope.b2);
        var b3 = getStatus('b3', $scope.b3);
        var b4 = getStatus('b4', $scope.b4);
        var b5 = getStatus('b5', $scope.b5);
        var b6 = getStatus('b6', $scope.b6);
        var b7 = getStatus('b7', $scope.b7);
        var b8 = getStatus('b8', $scope.b8);

        arrBtn.push(b1);
        arrBtn.push(b2);
        arrBtn.push(b3);
        arrBtn.push(b4);
        arrBtn.push(b5);
        arrBtn.push(b6);
        arrBtn.push(b7);
        arrBtn.push(b8);

        var message = {
            connectionid: 'n01'
           , arrbtn: arrBtn
        };

        $.connection.hub.url = ReadConnectionSettings();
        var signalR = $.connection.lampHub;
        signalR.client.addMessage = function (m, s) {
            $("#listMesagges").append('<li>' + m + '</li>');

            $("#msg").text = s;

        };

        $.connection.hub.start().done(function () {
            signalR.server.send(message);
            message = null;
        });

    };

    /*set label*/
    function setLabel(v) {

        if (v == "On") {
            return "Off";
        }
        else {
            return "On";
        }
    };
    /*cek status*/
    function getStatus(e,v) {
        if (v == "On")
            res = {
                btn: e
                , status: "1"
            };
        else
            res = {
                btn: e
                , status: "0"
            };
        return res;
    }
});