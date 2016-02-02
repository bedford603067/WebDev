// IIFE : Immediately Invoked Function Expression
// NB: myModule does not need to be declared in the function and certainly not at Module scope
(function () {
    myModule = angular.module('myAngularApplication', []);
}());


/*
var myModule = null;

function CreateModule() {
    myModule = angular.module('myAngularApplication', []);
}
CreateModule();
*/

/*
var myModule = null;

(function CreateModule(){
    myModule = angular.module('myAngularApplication', []);
}());

// As its only being called internally on initialisation don't evne need to name the function
(function () {
    myModule = angular.module('myAngularApplication', []);
}());
*/
