(function () {
    'use strict';

    angular
        .module('app')
        .factory('warningService', function ($http, $q) {


            function getWarnings() {
                /* this get function  will append whatever url you are at to the api/todos base url*/
                return $http.get('api/warning').then(function (response) {
                    var warningsReadyForView = _.map(response.data)
                    // return list of todos ready to be displayed.
                    return warningsReadyForView;

                });
            }
            function putWarning(id,warning) {
                return $http.put('api/warning/1', id , warning).then(function (response) {
                    return getWarnings();
                });
            }
            
            
            
            
            var service = {
                getWarnings: getWarnings,
                putWarning: putWarning
            };
            return service;

        });
})();