function Person(first, last) {
    this.first = first;
    this.last = last;

    Person.prototype.fullName = function Fred()  {
        return this.first + ' ' + this.last;
    }

    /*
    Object.defineProperty(Person, 'fullNameProp', {
        get: function () {
            return this.firstName + ' ' + this.lastName;
        }
    });
    */
}

function Manager(first, last) {
    Person.apply(this,arguments);

    this.department = "Sales";
    this.reports = [];
}

/*
Manager.prototype = Object.create(Person.prototype); // See note below
// Set the "constructor" property to refer to Student
Manager.prototype.constructor = Manager;
*/