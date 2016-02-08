(function () {
	'use strict';

	function OperationsController ($scope, $routeParams) {
		$scope.session = $routeParams.session;
	}

	angular
		.module('atm')
		.controller('OperationsController', ['$scope', '$routeParams', OperationsController]);
})();

