angular
	.module('atm')
	.directive('cardNumberFormat', CardNumberFormat);

function CardNumberFormat($filter) {
	return {
		restrict: 'A',
		require: 'ngModel',
		link: function($scope, $element, $attrs, ngModel) {

			// This runs when we update the text field
			ngModel.$parsers.push(function(viewValue) {
				return viewValue.replace(/-/g, '');
			});

			// This runs when the model gets updated on the scope directly and keeps our view in sync
			ngModel.$render = function() {
				$element.val($filter('cardNumber')(ngModel.$viewValue, false))
			};
		}
	};
}
