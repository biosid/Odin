﻿(function (app) {
    'use strict';

    app.factory('notificationService', notificationService);


    function notificationService() {

        var loadingScreen = null;

        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 2000,
            "timeOut": 4000,
            "extendedTimeOut": 2000
        };

        var service = {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayWarning: displayWarning,
            displayInfo: displayInfo

        };

        return service;

        function displaySuccess(message) {
            toastr.success(message);
        }

        function displayError(error) {

            if (Array.isArray(error)) {
                error.forEach(function (err) {
                    toastr.error(err);
                });
            } else {
                toastr.error(error);
            }
        }

        function displayWarning(message) {
            toastr.warning(message);
        }

        function displayInfo(message) {
            toastr.info(message);
        }
    }

})(angular.module('common.core'));