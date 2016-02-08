angular
	.module('atm')
	.directive('currency', CurrencyFormat);

function CurrencyFormat($filter) {
	return {
		restrict: 'A',
		require: 'ngModel',
		scope: {
			currency: '@'
		},
		link: function($scope, $element, $attrs, ngModel) {

			// This runs when the model gets updated on the scope directly and keeps our view in sync
			ngModel.$render = function() {
				$element.val($filter('currency')(ngModel.$viewValue, $scope.currency))
			};
		}
	};
}

