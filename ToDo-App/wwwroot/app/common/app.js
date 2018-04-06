(function () {
    'use strict';

    angular.module('app', [
        // Angular modules 


        // Custom modules 

        // 3rd Party Modules
        'ui.bootstrap',
        'ui.router'
        
    ]).config(function ($httpProvider) {
        $httpProvider.interceptors.push(function ($q, mytoastr) {
            return {
                'responseError': function (rejection) {
                    //mytoastr.warning(rejection.data.detail);
                    mytoastr.warning("Error.")
                    return $q.reject(rejection);
                }
            };
        });
    }).run(function ($rootScope, mytoastr) {
        $rootScope.$on('$stateChangeError',
            function (event, toState, toParams, fromState, fromParams, error) {
                mytoastr.warning('Error when changing states.');
            })
        
        });
})();