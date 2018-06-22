'use strict';
var contactsApp = angular.module('contactsApp', []);

contactsApp.controller('contactsController',
	function($scope, $http, contactsService) {
		contactsService.getCustomers
			.success(function(data) {
				$scope.customers = data;
			})
			.error(function(response) {
				console.log(response);
			});

		$scope.update = function (customer) {
			contactsService.updateCustomer(customer);
		}

		$scope.addCustomer = function(customer) {
			contactsService.addCustomer(customer);
		}

	});

contactsApp.factory('contactsService',
	function($http) {
		var contactsService = {};

		var getCustomers = function() {
			return $http.get('https://localhost:44312/api/customer');
		}

		contactsService.getCustomers = function() {
			return getCustomers();
		}

		var addCustomer = function (customer) {
			return $http.post('https://localhost:44312/api/customer', customer);
		}

		contactsService.addCustomer = function (customer) {
			return addCustomer(customer);
		}

		var updateCustomer = function(customer) {
			return $http.put('https://localhost:44312/api/customer' + customer.id, customer);
		}

		contactsService.updateCustomer = function(customer) {
			return updateCustomer(customer);
		}

		var removeCustomer = function (customer) {
			return $http.delete('https://localhost:44312/api/customer', customer);
		}

		contactsService.removeCustomer = function (customer) {
			return removeCustomer(customer);
		}
		return contactsService;
	});