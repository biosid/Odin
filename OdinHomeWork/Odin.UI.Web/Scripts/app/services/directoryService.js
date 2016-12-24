(function (app) {
    'use strict';

    app.factory('directoryService', directoryService);

    directoryService.$inject = ['$http', '$location', 'notificationService', '$rootScope', 'systemConfig', 'apiService'];

    function directoryService($http, $location, notificationService, $rootScope, systemConfig, apiService) {

        var service = {
            getList: getList
        };

        function getList(path, completed) {
            var url = systemConfig.webApiUrl;
            apiService.get(webApiUrl + "Directory/List?path=" + path, { ignoreLoadingBar: true }, completed);
        }
        return service;
    }

})(angular.module('common.core'));