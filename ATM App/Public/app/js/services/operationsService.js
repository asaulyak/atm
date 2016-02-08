angular.module('atm')
	.factory('OperationsService', ['$http', OperationsService]);

function OperationsService($http) {
    return {
        operation: {
            cardNumber: '',
            balance: '',
            balanceBefore: '',
            date: ''
        },

        getOperation: function (operationId) {
            return $http.get('/api/operations/' + operationId);
        }
    };
}