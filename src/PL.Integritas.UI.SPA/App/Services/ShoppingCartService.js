/// <reference path="../../Scripts/angular.js" />

(function () {
    var ShoppingCartService = angular.module('ShoppingCartService', []);

    ShoppingCartService.factory('ShoppingCartApi', function ($http) {

        var urlBase = "http://localhost:29413/api";
        var ShoppingCartApi = {};

        ShoppingCartApi.addProductToCart = function (productToAdd) {

            var request = $http({
                method: 'put',
                url: urlBase + '/ShoppingCart/' + productToAdd.Id,
                data: productToAdd
            });

            return request;
        }

        ShoppingCartApi.getShoppingCartItems = function (cartNumber) {
            return $http.get(urlBase + '/ShoppingCart/' + cartNumber);
        };

        return ShoppingCartApi;
    });
})();