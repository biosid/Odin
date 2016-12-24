(function () {
    'use strict';

    var settings = settingsHttpGet();
    var app = angular.module('OdinUI', ['common.core', 'common.ui'])
            .config(config).constant('systemConfig', {
                AppName: 'OdinUI',
                debugMode: settings.debugMode,
                webApiUrl: settings.webApiUrl
            })
            .run(run);

    config.$inject = ['$routeProvider', '$httpProvider', '$locationProvider'];

    function config($routeProvider, $httpProvider, $locationProvider) {

        //   $httpProvider.interceptors.push('authInterceptorService');

        // $httpProvider.defaults.useXDomain = true;

        // delete $httpProvider.defaults.headers.common['X-Requested-With'];


        $routeProvider
            .when("/", { templateUrl: "home/mainpage", controller: "homeCtrl" })
            .otherwise({ redirectTo: '/' });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes


        $(document).ready(function () {
            kendo.culture("ru-RU");
        });
    }

    function settingsHttpGet() {
        var settings;

        $.ajax({
            type: "GET",
            url: "Home/GetConfiguration",
            dataType: "json",
            success: function (data) {
                console.log(data);
                settings = {
                    debugMode: data.config.DebugMode,
                    webApiUrl: data.config.WebApiUrl
                };
            },
            async: false
        });

        return settings;
    }

})();