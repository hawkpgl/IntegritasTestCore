/// <reference path="../../Scripts/angular.js" />
(function () {
    var ProductService = angular.module('ProductService', []);

    ProductService.factory('ProductApi', function ($http) {

        var urlBase = "http://localhost:29413/api";
        var ProductApi = {};

        ProductApi.getProducts = function () {
            return $http.get(urlBase + '/Product');
        };

        return ProductApi;
    });
})();