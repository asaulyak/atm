(function () {
	'use strict';

	function WithdrawController($scope, $routeParams, $location, CardService, Keyboard) {
		$scope.card = CardService;
		$scope.Keyboard = Keyboard;
		$scope.session = $routeParams.session;
		$scope.sum = '0';

		$scope.$watch('Keyboard.pressedButton', function (button) {
			if(button) {
				switch (button.role) {
					case 'num':
							$scope.sum += button.value;
						break;
					case 'clear':
						$scope.sum = '0';
						break;
				    case 'done':
				        if (+$scope.sum) {
				            CardService.withdrawMoney($scope.session, $scope.sum)
                           .then(function (response) {
                               $location.path('/operations/' + $scope.session + '/' + response.data.operationId);
                           })
                           .catch(function (error) {
                               $location.path('/error/insufficientFunds');
                           });
				        }
					   
						break;
				}
			}
		});
	}

	angular
		.module('atm')
		.controller('WithdrawController', ['$scope', '$routeParams', '$location','CardService', 'Keyboard', WithdrawController]);
})();



