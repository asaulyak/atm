angular
	.module('atm')
	.directive('goBack', CurrencyFormat);

function CurrencyFormat($filter) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.on('click', function () {
                $window.history.back();
            });
        }
    };
}

