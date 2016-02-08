angular.module('atm')
	.filter('cardNumber', function () {
		return function (input) {

			// Taken from http://www.peterbe.com/plog/cc-formatter
			var v = input.replace(/\s+/g, '')
				.replace(/[^0-9]/gi, '');
			var matches = v.match(/\d{4,16}/g);
			var match = matches && matches[0] || '';
			var parts = [];
			for (var i = 0, len = match.length; i < len; i += 4) {
				parts.push(match.substring(i, i + 4));
			}
			if (parts.length) {
				return parts.join('-')
			}
			else {
				return input;
			}
		};
	});
