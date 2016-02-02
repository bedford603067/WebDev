// This anonymous function in javaScript is filling the role of a Constructor 
// and also it seems as they don't both creatin variable declarations to define Public properties e.g $scope.books

(function () {
    // With TWO Services
    var booksController = function ($scope, $filter, localBooksService, remoteBooksService) {

        // variable accessible via Controller As
        this.greeting = "This is a greeting message using Controller As syntax";

        // locally defined rather than in a Service 
        $scope.countries = [
            "India",
            "Denmark",
            "USA",
            "Singapore",
            "Germany"
        ];

        // Add properties to the $scope object
        $scope.message = "List of books";
        $scope.books = [];
        $scope.book = {};
        $scope.editBook = null;

        // Expose Service methods to the $scope object
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

        $scope.fetchBooksFromServer = function () {

            remoteBooksService.fetchBooks()
            .success(function (data, status, headers, config) {
                $scope.books = data;
            })
            .error(function (data, status, headers, config) {
                $scope.books = [];
                $scope.error = "Failed to retrieve data from server";
                // Unclear how else to get Error to throw to browser when called from ng-click...
                alert($scope.error);
            });
        };

        // Populate Books list from the off
        // $scope.fetchBooks();
    }

    angular.module('myAngularApplication').controller('booksController', ["$scope", "$filter", "localBooksService", "remoteBooksService", booksController]);

}());

/*
(function () {
    // With a Service
    var booksController = function ($scope, $filter, localBooksService) {
        $scope.message = "List of books";

        $scope.books = [];

        // fetch content from a Service 
        $scope.fetchBooks = function () {
            $scope.books = localBooksService.books;
        }

        // locally defined rather than in a Service 
        $scope.countries = [
            "India",
            "Denmark",
            "USA",
            "Singapore",
            "Germany"
        ];
    }

    angular.module('myAngularApplication').controller('booksController', ["$scope", "$filter", "localBooksService", booksController]);

}());
*/

/*
(function () {
    // Without a Service
    var booksController = function ($scope) {
        $scope.message = "Hello from booksController";

        this.greeting = "This is a greeting message using controller as syntax";
        $scope.books = [];

        $scope.fetchBooks = function () {
            $scope.books = [
                { ID: 1, BookName: "Test Books 1", AuthorName: "Test Author 1", ISBN: "TEST1" },
                { ID: 2, BookName: "Test Books 2", AuthorName: "Test Author 2", ISBN: "TEST2" },
                { ID: 3, BookName: "Test Books 3", AuthorName: "Test Author 3", ISBN: "TEST3" },
                { ID: 4, BookName: "Test Books 4", AuthorName: "Test Author 4", ISBN: "TEST4" },
                { ID: 5, BookName: "Test Books 5", AuthorName: "Test Author 5", ISBN: "TEST5" }
            ];
        }

        $scope.countries = [
            "India",
            "Denmark",
            "USA",
            "Singapore",
            "Germany"
        ];

        // $scope.conversionRate = $filter("number")(62.3, 5); // Last arg = no. odf decimal places
    }

    // Note minification messes with the variable names including $scope. The second argument is necessary so it can relates referenced parameters even after rename
    // On the same lines, we can pass all the controller parameters as string literals in this function call and the angular will know that even after minification how these parameters should be treated.

    // Seems like this has to come last, associating the defined Controller object with the main Application module
    angular.module('myAngularApplication').controller('booksController', ["$scope", booksController]);

}());
*/

/*
var booksController = function ($scope) {
    $scope.message = "Hello from booksController";
}
myModule.controller('booksController', booksController);
*/