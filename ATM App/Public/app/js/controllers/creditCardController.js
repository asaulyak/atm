(function () {
	'use strict';

	function CreditCardController($scope, $location, CardService, Keyboard) {

		$scope.card = CardService;
		$scope.Keyboard = Keyboard;

		$scope.$watch('Keyboard.pressedButton', function (button) {
			if(button) {
				switch (button.role) {
					case 'num':
						if($scope.card.cardNumber.length < 16) {
							$scope.card.cardNumber += button.value;
						}
						break;
					case 'clear':
						$scope.card.cardNumber = '';
						break;
					case 'done':
					    CardService.checkCardNumber($scope.card.cardNumber)
							.then(function (card) {
								if (card.data.isValid) {
								    $location.path('/pin/' + $scope.card.cardNumber);
								}
								else {
								    $location.path('/error/blockedCard');
								}
							})
							.catch(function (error) {
							    $location.path('/error/generic');
							});
						break;
				}
			}
		});
	}

	angular
		.module('atm')
		.controller('CreditCardController', ['$scope', '$location', 'CardService', 'Keyboard',
			CreditCardController]);
})();
