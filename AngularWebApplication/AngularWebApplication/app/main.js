/// <reference path="classes.js" />

// IIFE (immediately-invoked function expression) 
// In this case the IIFE is in effect acting like a class constructor for a 'controller' instance
(function(){
    var mainController = function ($scope) {
        $scope.message = "View Model";

        $scope.person = new Person("John", "Smith");
    }

    // Register the Controller instance with the Module (ng-app)
    angular.module("app").controller('MainController', ["$scope", mainController]);
}
)
();