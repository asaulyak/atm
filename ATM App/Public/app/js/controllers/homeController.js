(function () {
	'use strict';

	function HomeController ($scope, Keyboard) {
		$scope.Keyboard = Keyboard;

		$scope.$on('cardNumber', function () {
			debugger;
		});
	}

	angular
		.module('atm')
		.controller('HomeController', ['$scope', 'Keyboard', HomeController]);
})();
