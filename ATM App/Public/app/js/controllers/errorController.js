(function () {
    'use strict';

    function ErrorController($scope, $routeParams, $location, ErrorService) {
        var errorKey = $routeParams.error;

        $scope.message = ErrorService.getMessage(errorKey);
    }

    angular
		.module('atm')
		.controller('ErrorController', ['$scope', '$routeParams', '$location', 'ErrorService', ErrorController]);
})();


