(function () {
    'use strict';

    function WithdrawReportController($scope, $routeParams, $location, OperationsService) {
        $scope.session = $routeParams.session;
        $scope.operation = OperationsService.operation;

        OperationsService.getOperation($routeParams.operationId)
        .then(function (response) {
            $scope.operation = response.data;            
        })
        .catch(function (response) {
            $location.path('/error/generic');
        });
    }

    angular
		.module('atm')
		.controller('WithdrawReportController', ['$scope', '$routeParams', '$location', 'OperationsService', WithdrawReportController]);
})();


