(function () {
    'use strict';

    angular
        .module('app')
        .factory('mytoastr', mytoastr_factory);

    function mytoastr_factory() {
        var service = {
            success: success,
            warning: warning
        };

        return service;

        function success(message) {
            toastr.success(message);
        }
        function warning(message) {
            toastr.warning(message);
        }
    }
})();