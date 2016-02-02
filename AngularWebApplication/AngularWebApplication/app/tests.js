/// <reference path="../scripts/_references.js" />

/// <reference path="app.module.js" />
/// <reference path="main.js" />
/// <reference path="classes.js" />

describe('MainController', function () {
    beforeEach(module('app'));

    var $controller;

    beforeEach(inject(function (_$controller_) {
        // The injector unwraps the underscores (_) from around the parameter names when matching
        $controller = _$controller_;
    }));

    describe('$scope.message', function () {
        it('tests the initial value of scope.message', function () {
            var $scope = {};
            var controller = $controller('MainController', { $scope: $scope });
            expect($scope.message).toEqual('View Model');
        });
    });
});

describe('MainController', function () {
    beforeEach(module('app'));

    var $controller;

    beforeEach(inject(function (_$controller_) {
        // The injector unwraps the underscores (_) from around the parameter names when matching
        $controller = _$controller_;
    }));

    describe('$scope.message', function () {
        it('tests the initial value of scope.message', function () {
            var $scope = {};
            var controller = $controller('MainController', { $scope: $scope });
            expect($scope.message).not.toEqual('View Model 2');
        });
    });
});