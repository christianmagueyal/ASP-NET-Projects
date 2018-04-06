(function () {
    'use strict';

    angular
        .module('app')
        .controller('ValueController', function value_controller(value) {
            /* jshint validthis:true */
            var vm = this;
            vm.value = value;
        });
})();