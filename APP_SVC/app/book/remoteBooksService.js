(function () {

    var remoteBooksService = function ($http) {
        var _fetchBooks = function () {
            return $http.get('http://localhost:57386/api/Books');
        };

        return {
            fetchBooks: _fetchBooks
        };
    }

    angular.module('myAngularApplication').factory('remoteBooksService', ["$http", remoteBooksService]);

}());