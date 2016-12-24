(function (app) {
    'use strict';

    app.factory('fileService', fileService);

    fileService.$inject = ['$http', '$location', 'notificationService', '$rootScope', 'systemConfig', 'apiService'];

    function fileService($http, $location, notificationService, $rootScope, systemConfig, apiService) {

        var service = {
            getPurchaseMethods: getPurchaseMethods,
            getMarketPlaces: getMarketPlaces,
            getDayTypes: getDayTypes,
            getDatePeriod: getDatePeriod,
            getCountries: getCountries,
            getPaymentRequisites: getPaymentRequisites,
            getEnsuringTypes: getEnsuringTypes
        };

        function getPurchaseMethods(callback) {
            apiService.get('common/GetPurchaseMethods', { ignoreLoadingBar: true }, callback);
        }

        function getMarketPlaces(callback) {
            apiService.get('common/GetMarketPlaces', { ignoreLoadingBar: true }, callback);
        }

        function getDatePeriod(startDate, daysCount, daysType, endDate, callback) {
            if (!startDate) return;
            apiService.get('common/GetDate?startDate=' + startDate + "&daysCount=" + daysCount + "&daysType=" + daysType + "&endDate=" + endDate, { ignoreLoadingBar: true }, callback);
        }

        function getCountries(callback) {
            apiService.get('common/GetCountries', { ignoreLoadingBar: true }, callback);
        }

        function getDayTypes() {
            return [{ id: "0", name: "Рабочие дни" }, { id: "1", name: "Календарные дни" }]
        }

        function getPaymentRequisites(callback) {
            apiService.get('common/GetPaymentRequisites', { ignoreLoadingBar: true }, callback);
        }

        function getEnsuringTypes(callback) {
            apiService.get('common/GetEnsuringTypes', { ignoreLoadingBar: true }, callback);
        }

        return service;
    }

})(angular.module('common.core'));