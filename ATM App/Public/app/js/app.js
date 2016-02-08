'use strict';

// Declare app level module which depends on views, and components
angular.module('atm', [
	'ngRoute'
]).config(['$routeProvider', function ($routeProvider) {
	$routeProvider
		.when('/', {
			controller: 'CreditCardController',
			templateUrl: 'Public/app/views/home.html'
		})
		.when('/pin/:cardNumber', {
			controller: 'PinController',
			templateUrl: 'Public/app/views/pin.html'
		})
		.when('/operations/:session', {
			controller: 'OperationsController',
			templateUrl: 'Public/app/views/operations.html'
		})
		.when('/balance/:session', {
			controller: 'BalanceController',
			templateUrl: 'Public/app/views/balance.html'
		})
		.when('/withdraw/:session', {
			controller: 'WithdrawController',
			templateUrl: 'Public/app/views/withdraw.html'
		})
		.when('/operations/:session/:operationId', {
		    controller: 'WithdrawReportController',
		    templateUrl: 'Public/app/views/withdrawReport.html'
		})
		.when('/sessions/:session/close', {
		    controller: 'SessionController',
		    templateUrl: 'Public/app/views/home.html'
		})
		.when('/error/:error', {
		    controller: 'ErrorController',
		    templateUrl: 'Public/app/views/error.html'
		})
		.otherwise({
			redirectTo: '/error/404'
		});
}]);
