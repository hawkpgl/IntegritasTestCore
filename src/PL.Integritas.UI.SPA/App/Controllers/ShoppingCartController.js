/// <reference path="../../Scripts/angular.js" />
/// <reference path="../IntegritasApp.js" />
/// <reference path="../Services/ShoppingCartService.js" />
(function () {
    IntegritasApp.controller("ShoppingCartController", function ($scope, $location, ShoppingCartApi) {

        getShoppingCartItems($scope.cartNumber);

        function getShoppingCartItems(cartNumber) {
            ShoppingCartApi.getShoppingCartItems(cartNumber).success(function (data) {
                $scope.shoppingCartItems = data;
            })
            .error(function (error) {
                $scope.status = 'Could not load data: ' + error.message;
            });
        };

        $scope.Purchase = function () {
            $location.path("/Purchase");
        };

    });
})();