angular.module('atm')
	.factory('Keyboard', [KeyboardService]);

function KeyboardService() {
	return {
		buttons: [
			{
				value: '1',
				role: 'num'
			},
			{
				value: '2',
				role: 'num'
			},
			{
				value: '3',
				role: 'num'
			},
			{
				value: '4',
				role: 'num'
			},
			{
				value: '5',
				role: 'num'
			},
			{
				value: '6',
				role: 'num'
			},
			{
				value: '7',
				role: 'num'
			},
			{
				value: '8',
				role: 'num'
			},
			{
				value: '9',
				role: 'num'
			},
			{
				value: 'C',
				role: 'clear'
			},
			{
				value: '0',
				role: 'num'
			},
			{
				value: 'OK',
				role: 'done'
			}
		],

		pressedButton: null
	};
}


