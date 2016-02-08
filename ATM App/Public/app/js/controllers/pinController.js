(function () {
	'use strict';

	function PinController ($scope, $location, $routeParams, CardService, Keyboard) {
		$scope.card = CardService;
		$scope.Keyboard = Keyboard;

		$scope.card.cardNumber = $routeParams.cardNumber;
		$scope.error = false;

		$scope.$watch('Keyboard.pressedButton', function (button) {
			if(button) {
				switch (button.role) {
				    case 'num':
				        $scope.error = false;
						if($scope.card.pinCode.length < 4) {
							$scope.card.pinCode += button.value;
						}
						break;
				    case 'clear':
				        $scope.error = false;
						$scope.card.pinCode = '';
						break;
				    case 'done':
				        if ($scope.card.pinCode.length === 4) {
				            CardService.verifyPinCode($scope.card.pinCode)
							.then(function (card) {
							    $location.path('/operations/' + card.data.sessionId);
							})
							.catch(function (error) {
							    if (error.status === 400) {
							        $location.path('/error/wrongPin');
							    }
							    else {
							        $scope.error = true;
							        $scope.card.pinCOde = '';
							    }
							});
				        }
					    
						break;
				}
			}
		});
	}

	angular
		.module('atm')
		.controller('PinController', ['$scope', '$location', '$routeParams', 'CardService', 'Keyboard', PinController]);
})();
