(function (app) {
    'use strict';

    app.factory('fileService', fileService);

    fileService.$inject = ['$http', '$location', 'notificationService', '$rootScope', 'systemConfig', 'apiService'];

    function fileService($http, $location, notificationService, $rootScope, systemConfig, apiService) {

        var webApiUrl = systemConfig.webApiUrl;


        var service = {
            getList: getList,
            getContent: getContent
        };

        function getList(path, callback) {
            apiService.get(webApiUrl + 'File/List?path=' + path, { ignoreLoadingBar: true }, callback);
        }

        function getContent(filePath, callback) {
            apiService.get(webApiUrl + 'File/Content?filePath=' + filePath, null, callback);
        }



        return service;
    }

})(angular.module('common.core'));