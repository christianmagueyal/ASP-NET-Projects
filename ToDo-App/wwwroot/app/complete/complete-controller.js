(function () {
    'use strict';

    angular
        .module('app')
        .controller('CompleteController', function (completeService, completed) {
            /* So list of todos "todos"  will be resolved before this before you step into this controller,
            as part of todos state, i will resolve todos by calling getTodos in factory  */
            var vm = this;
            vm.datePopupVisible = false
            vm.completed = completed;

            // for completed todos:
            vm.refreshCompleted = function () {
                completeService.getTodos().then(function (completed) {
                    vm.completed = completed;
                });
            }
            vm.remove = function (id) {
                completeService.deleteTodo(id).then(function (id) {
                    toastr.success('Delete Successful!');
                    vm.refreshCompleted();
                });
            }
        


            vm.refreshCompleted();
           
            
            
            activate();

            function activate() {}
        });
})();