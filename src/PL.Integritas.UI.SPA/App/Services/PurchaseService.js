/// <reference path="../../Scripts/angular.js" />
(function () {
    var PurchaseService = angular.module('PurchaseService', []);

    PurchaseService.factory('PurchaseApi', function ($http) {

        var urlBase = "http://localhost:29413/api";
        var PurchaseApi = {};

        PurchaseApi.getPurchases = function () {
            return $http.get(urlBase + '/Purchase');
        };

        PurchaseApi.finishPurchase = function (purchaseToAdd) {
            return $http.post(urlBase + '/Purchase', purchaseToAdd)
        }

        return PurchaseApi;
    });
})();