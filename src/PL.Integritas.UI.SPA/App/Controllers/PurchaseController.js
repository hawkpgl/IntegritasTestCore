/// <reference path="../../Scripts/angular.js" />
/// <reference path="../IntegritasApp.js" />
(function () {
    IntegritasApp.controller("PurchaseController", function ($scope, PurchaseApi) {

        getPurchases();

        function getPurchases() {
            PurchaseApi.getPurchases().success(function (data) {
                $scope.purchases = data;
            })
            .error(function (error) {
                $scope.status = 'Could not load data: ' + error.message;
            });
        };

        $scope.FinishPurchase = function () {

            var purchaseToAdd = {
                'Id': $scope.id,
                'CartNumber': $scope.cartNumber,
                'CardHolderName': $scope.cardHolderName,
                'CardNumber': $scope.cardNumber,
                'CardExpiryMonth': $scope.cardExpiryMonth,
                'CardExpiryYear': $scope.cardExpiryYear,
                'CVV': $scope.cvv,
                'Adress': $scope.adress,
                'Country': $scope.country,
                'State': $scope.state,
                'City': $scope.city,
                'ZipPostalCode': $scope.zipPostalCode,
            };

            PurchaseApi.finishPurchase(purchaseToAdd)
            .success(function (response) {
                alert('Purchase finished. Thanks for buying!');
                $scope.id = undefined;
                $scope.cardHolderName = undefined;
                $scope.cardNumber = undefined;
                $scope.cardExpiryMonth = undefined;
                $scope.cardExpiryYear = undefined;
                $scope.cvv = undefined;
                $scope.adress = undefined;
                $scope.country = undefined;
                $scope.state = undefined;
                $scope.city = undefined;
                $scope.zipPostalCode = undefined;
                changeLocation("index.html", true);
            })
            .error(function (response) {
                alert('Error on finishing your purchase. Please do not go away!!!');
            });

            var changeLocation = function (url, forceReload) {
                $scope = $scope || angular.element(document).scope();
                if (forceReload || $scope.$$phase) {
                    window.location = url;
                }
                else {
                    //only use this if you want to replace the history stack
                    $location.path(url).replace();

                    //this this if you want to change the URL and add it to the history stack
                    //$location.path(url);

                    $scope.$apply();
                }
            };

        };
    });
})();