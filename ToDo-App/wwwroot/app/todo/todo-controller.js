(function () {
    'use strict';

    angular
        .module('app')
        .controller('TodoController', function (todoService, todos, completed) {
            /* So list of todos "todos"  will be resolved before this before you step into this controller,
            as part of todos state, i will resolve todos by calling getTodos in factory  */
            var vm = this;
            vm.datePopupVisible = false;
            vm.todos = todos;
            vm.completed = completed;

            vm.newTodo = {
                name: 'Todo',
                description: 'Description',
                dueDate: new Date(),                
                active: true
            }
            // for active todos:
            vm.refreshTodos = function () {
                todoService.getTodos().then(function (todos) {
                    vm.todos = todos;
                });
            }
            vm.save = function () {
                todoService.postTodo(vm.newTodo).then(function (todos) {

                    toastr.success('Your To-Do was saved');
                    vm.refreshTodos();
                });
            }
            // for completed todos:
            vm.refreshCompleted = function () {
                todoService.getTodos().then(function (todos) {
                    vm.todos = todos;
                });
            }
            activate();

            function activate() {}
        });
})();