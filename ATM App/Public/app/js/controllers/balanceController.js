(function () {
	'use strict';

	function BalanceController ($scope, $routeParams, $location, CardService) {
		$scope.card = CardService;

		$scope.date = Date.now();

		$scope.session = $routeParams.session;

		CardService.updateBalance($scope.session)
        .then(function (response) {
            $scope.card.balance = response.data.balance;
        })
        .catch(function (response) {
            $location.path('/error/generic');
        });
	}

	angular
		.module('atm')
		.controller('BalanceController', ['$scope', '$routeParams', '$location', 'CardService', BalanceController]);
})();


