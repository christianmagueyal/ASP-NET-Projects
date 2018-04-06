(function () {
    'use strict';

    angular
        .module('app')
        .controller('PokedexController',
    function pokedex_controller(valueService) {
        var vm = this;
        vm.pokelist = [];
        vm.title = 'pokedex_controller';
        vm.loadList = function (offset) {
            vm.loading = true;
            valueService.getPokemonList(offset).then(function (pokemonList) {
                vm.pokelist = pokemonList;
                vm.loading = false;

            }, function () {
                vm.loading = false;
            });
        }
        vm.loadList(0);

    });
})();
