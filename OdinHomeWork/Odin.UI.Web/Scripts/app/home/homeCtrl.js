(function (app) {
    'use strict';

    app.controller('homeCtrl', homeCtrl);

    homeCtrl.$inject = ['$scope', '$location', '$route', '$routeParams', '$rootScope', 'ngDialog', 'apiService', 'systemConfig', 'notificationService', 'directoryService', 'fileService'];

    function homeCtrl($scope, $location, $route, $routeParams, $rootScope, ngDialog, apiService, systemConfig, notificationService, directoryService, fileService) {

        $scope.treeOption = {
            dataSource: new kendo.data.HierarchicalDataSource({
                transport: {
                    read: function (options) {
                        var path = ""
                        if (options.data.Path)
                            path = options.data.Path;
                        directoryService.getList(path, function (result) {
                            options.success(result.data);
                        })
                    },
                },
                schema: {
                    model: {
                        id: "Path",
                        hasChildren: true
                    }
                }
            }),
            select: onSelect,
            dataTextField: "Name"
        };

        function onSelect(e) {
            var data = $('#treeview').data('kendoTreeView').dataItem(e.node);
            _fillFilesDataSource(data.Path);
        }

        function _fillFilesDataSource(path) {
            var _path = ""
            if (path)
                _path = path;
            fileService.getList(_path, function (result) {
                $scope.filesDataSource = result.data;
                $scope.filesGrid.dataSource.read();
                $scope.filesGrid.refresh();
            })
        }

        $scope.filesDataSource = {};

        $scope.viewFile = function (e) {
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            fileService.getContent(dataItem.Path, function (result) {
                console.log(result);

                $scope.fileContentWindow.title(dataItem.Name);
                $scope.fileContentWindow.content(result.data.Content);
                console.log($scope.fileContentWindow);

                $scope.fileContentWindow.open();
            })

            return false;
        }

        $scope.gridOptions = {
            sortable: false,
            pageable: false,
            columns: [{
                field: "Name",
                title: "File Name",
            },
            {
                field: "Extension",
                field: "Extension",
            }, {
                field: "Create",
                title: "Create",
            }, {
                field: "Modify",
                title: "Modify",
            }, {
                field: "Size",
                title: "Size (byte)",
            },
            {
                command: { text: "View", click: $scope.viewFile }, title: "Actions", width: "180px"
            }
            ]
        };

        _fillFilesDataSource();
    }

})(angular.module('OdinUI'));