/// <reference path="../../Scripts/angular.js" />
/// <reference path="../IntegritasApp.js" />
/// <reference path="../Services/ProductService.js" />
(function () {
    IntegritasApp.controller("HomeController", function ($scope, ProductApi, ShoppingCartApi) {

        getProducts();

        function getProducts() {
            ProductApi.getProducts().success(function (data) {
                $scope.products = data;
            })
            .error(function (error) {
                $scope.status = 'Could not load data: ' + error.message;
            });
        };

        $scope.AddToCart = function (product) {
            var productToAdd = {
                'Id': product.id,
                'Name': product.name,
                'CartNumber': $scope.cartNumber,
            };

            ShoppingCartApi.addProductToCart(productToAdd)
            .success(function (response) {
                alert('Product added to cart.');
                $scope.id = undefined;
                $scope.name = undefined;
            })
            .error(function (response) {
                alert('Error on adding product to cart.');
            });
        };
    });
})();