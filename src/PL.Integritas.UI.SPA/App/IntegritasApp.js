/// <reference path="../../Scripts/angular.js" />

var IntegritasApp = angular.module("IntegritasApp", ['ngRoute', 'ProductService', 'ShoppingCartService', 'PurchaseService']);

IntegritasApp.config(['$routeProvider',
    function ($routeProvider) {

        $routeProvider.
            when('/Home', {
                templateUrl: 'App/Views/home.html',
                controller: 'HomeController',
                restricted: false
            }).
            when('/ShoppingCart', {
                templateUrl: 'App/Views/shoppingCart.html',
                controller: 'ShoppingCartController',
                restricted: false
            }).
             when('/AllPurchases', {
                 templateUrl: 'App/Views/allPurchases.html',
                 controller: 'PurchaseController',
                 restricted: false
             }).
            when('/Purchase', {
                templateUrl: 'App/Views/purchase.html',
                controller: 'PurchaseController',
                restricted: '/ShoppingCart'
            }).
            otherwise({
                redirectTo: '/Home'
            });
    }]);

IntegritasApp.run(function ($rootScope, $location, $route) {

    $rootScope.$on('$locationChangeStart', function (event, next, current) {

        var nextRoute = $route.routes[$location.path()];

        var currentPath = current.split('#')[1];

        var restricted = false;

        if (nextRoute != undefined) {
            restricted = nextRoute.restricted;
        }

        if (restricted && nextRoute.restricted !== currentPath) {

            $location.path('/');
            alert('You cannot access payment this way.');

        }

    });

});