(function () {
    'use strict';

    angular
        .module('app')
        .controller('WarningController', function (warningService, warnings) {
            /* So list of todos "todos"  will be resolved before this before you step into this controller,
            as part of todos state, i will resolve todos by calling getTodos in factory  */
            var vm = this;


            // need to go back and resolve this.
            vm.warnings = warnings;
            var d = 2;
            var h = 0;
            vm.newWarning = {
                days: 2,
                hours: 0,
                warningId: 1
            }
            vm.refreshWarnings = function () {
                warningService.getWarnings().then(function (warnings) {
                    vm.warnings = warnings;
                });
            }
            vm.edit = function (warnings) {
                warningService.putWarning(1,warnings).then(function (warnings) {
                    toastr.success('New warning window saved');
                    vm.refreshWarnings();

                });
            }
            vm.refreshWarnings();
            
            
            activate();

            function activate() {}
        });
})();