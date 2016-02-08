(function () {
    'use strict';

    function SessionController($scope, $location, $routeParams, CardService) {
        CardService.close($routeParams.session)
        .then(function () {
            $location.path('/');
        });
    }

    angular
		.module('atm')
		.controller('SessionController', ['$scope', '$location', '$routeParams', 'CardService', SessionController]);
})();
