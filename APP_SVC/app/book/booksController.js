(function () {

    var booksController = function ($scope, $filter, localBooksService) {
        $scope.message = "List of books";

        $scope.books = [];
        $scope.book = {};
        $scope.editBook = null;

        $scope.fetchBooks = function () {
            $scope.books = localBooksService.books;
        }

        $scope.addBook = function (frmAddBook) {
            if (frmAddBook.$valid) {
                localBooksService.addBook($scope.book);
                $scope.book = {}
                $scope.fetchBooks();
            }
            else {
                alert("Invalid values. All values are required");
            }
        }

        $scope.updateBook = function (frmEditBook) {

            /*
            alert("Called updateBook");
            alert(frmEditBook.$valid);
            */

            if (frmEditBook.$valid) {
                localBooksService.updateBook($scope.editBook);
                $scope.editBook = null;
                $scope.fetchBooks();
            }
            else {
                alert("Invalid values. All values are required");
            }
        }

        $scope.setEditBook = function (selected) {
            $scope.editBook = angular.copy(selected);
            $scope.book = {}
        }

        $scope.cancelEdit = function () {
            $scope.editBook = null;
            $scope.book = {}
        }

        $scope.fetchBooks();
    }

    angular.module('myAngularApplication').controller('booksController', ["$scope", "$filter", "localBooksService", booksController]);
}());