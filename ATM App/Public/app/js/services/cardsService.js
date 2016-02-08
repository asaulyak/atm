angular.module('atm')
	.factory('CardService', ['$http', CardService]);

function CardService($http) {
	return {
	    cardNumber: '1456741236541235',

		pinCode: '',

		balance: '',

		checkCardNumber: function () {
			return $http.get('/api/cards/' + this.cardNumber);
		},

		verifyPinCode: function () {
		    return $http.post('/api/cards/' + this.cardNumber + '/pin', {
                pinCode: this.pinCode
		    });
		},

		updateBalance: function (sessionId) {
		    return $http.get('/api/session/' + sessionId + '/balance');
		},

		withdrawMoney: function (sessionId, amount) {
		    return $http.post('/api/session/' + sessionId + '/withdraw', {
		        withdrawAmount: amount
		    });
		},

		close: function (sessionId) {
		    return $http.post('/api/session/' + sessionId + '/close');
		}
	};
}