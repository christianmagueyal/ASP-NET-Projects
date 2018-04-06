(function () {
    'use strict';

    angular
        .module('app')
        .factory('completeService', function ($http, $q) {

            var pokeIdExp = /(\d+)\/$/;

            function getTodos() {
                /* this get function  will append whatever url you are at to the api/todos base url*/
                return $http.get('api/todo').then(function (response) {
                    var todosReadyForView = _.map(response.data, function(todo) {
                        /*todo.dueDate = 'Dates are stupid i guess';   // i had used this to see that everything was wired right to modify the dueDate
                        // variable in the Todo todo. Below momentJS will magically convert UTC time to local time*/
                        todo.dueDate = moment(todo.dueDate).local().format('lll');
                        // return the modified todo.
                        return todo;
                    })
                    // return list of todos ready to be displayed.
                    return todosReadyForView;

                });
            }
            function postTodo(newTodo) {
                return $http.post('api/todo/', JSON.stringify(newTodo)).then(function (response) {
                    return getTodos();
                });
            }
            function deleteTodo(id) {
                return $http.delete('api/todo/' + id).then(function (response) {
                    return getTodos();
                });
            }
            function getValue(id) {
                return $http.get('http://pokeapi.co/api/v2/pokemon/' + id).then(
                    function (response) {
                        return response.data;
                    }, function (errorResponse) {
                        return $q.reject('Failed Miserably: this is from interceptor reject');
                    });
            }
            function getPokemonList(offset) {
                return $http.get('http://pokeapi.co/api/v2/pokemon/?offset=' + offset).then(
                function (response) {
                    var pokeList = _.map(response.data.results, function (pokemon) {
                        return {
                            name: pokemon.name,
                            id: pokemon.url.match(pokeIdExp)[1]
                        };
                    }
            );
                    return pokeList;
                });
            }
            var service = {
                getTodos: getTodos,
                postTodo: postTodo,
                deleteTodo: deleteTodo,
                getValue: getValue,
                getPokemonList: getPokemonList
            };
            return service;

        });
})();