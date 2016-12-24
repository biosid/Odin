(function (app) {
    'use strict';

    app.controller('homeCtrl', homeCtrl);

    homeCtrl.$inject = ['$scope', '$location', '$route', '$routeParams', '$rootScope', 'ngDialog', 'apiService', 'systemConfig', 'notificationService', 'directoryService', 'fileService'];

    function homeCtrl($scope, $location, $route, $routeParams, $rootScope, ngDialog, apiService, systemConfig, notificationService, directoryService, fileService) {

        var url = systemConfig.webApiUrl;
        $scope.treeOption = {
            dataSource: new kendo.data.HierarchicalDataSource({
                transport: {
                    read: {
                        url: url + "Directory/List",
                        dataType: "json"
                    }
                },
                schema: {
                    model: {
                        id: "Path",
                        hasChildren: true
                    }
                }
            }),
            dataTextField: "Name"
        };
    }

})(angular.module('OdinUI'));