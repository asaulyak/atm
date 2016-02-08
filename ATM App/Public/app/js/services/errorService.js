var ErrorService = (function () {
    var errors = {
        insufficientFunds: 'There is not enough funds for current operation.',
        blockedCard: 'Your card has been blocked.',
        wrongPin: 'You have entered wrong pin 4 times in a row. Your card has been blocked.',
        404: 'Page not found.',
        default: 'Unexpected error uccured.'
    };

    return function () {
        return {
            message: '',

            getMessage: function (errorKey) {
                return errors[errorKey] || error.default;
            }
        }
    }
})();

angular.module('atm')
	.factory('ErrorService', ErrorService);
