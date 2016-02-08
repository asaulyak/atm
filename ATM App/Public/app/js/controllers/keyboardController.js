(function () {
	'use strict';

	function KeyboardController($scope, Keyboard) {
		$scope.buttons = Keyboard.buttons;
		$scope.pressedButton = Keyboard.pressedButton;

		$scope.onButtonClick = function (button) {
			Keyboard.pressedButton = {
				role: button.role,
					value: button.value
			};
		}
	}

	angular
		.module('atm')
		.controller('KeyboardController', ['$scope', 'Keyboard', KeyboardController]);
})();
