(function() {
    'use strict';

    angular
        .module('app')

    .directive('gravatar', function() {
        return {
            restrict: 'E',
            scope: {
                email: '='
            },
            controller: function($scope){
                $scope.emailHash = md5($scope.email);
                $scope.gravatarImgSrc = 'https://www.gravatar.com/avatar/' + $scope.emailHash;

            },
            templateUrl: 'app/common/directives/gravatar/gravatar.html'
        };
    });

})();