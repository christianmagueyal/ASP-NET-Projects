(function () {
    'use strict';

    angular
        .module('app')
        .factory('valueService', function value_factory($http, $q) {

            var pokeIdExp = /(\d+)\/$/;

            function getValues() {
                var deferred = $q.defer();
                $http.get('api/values').then(function (response) {
                    deferred.resolve(response.data);
                }, 
                function (response) {
                    deferred.reject('terrible things');
                });
                return deferred.promise;


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
                    var pokeList= _.map(response.data.results, function (pokemon) {
                return{
                        name: pokemon.name,
                        id:  pokemon.url.match(pokeIdExp)[1]
                };
            }
            );
            return pokeList;
        });
            }
            var service = {
                getAllValues: getValues,
                getValue: getValue,
                getPokemonList: getPokemonList
            };
            return service;

        });
})();