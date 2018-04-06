(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', function homeController() {
            /* jshint validthis:true */
            var vm = this;
            vm.title = 'Welcome';
            vm.user = {
                name: 'Christian',
                welcome: true,
                image: 'https://scontent-dft4-2.xx.fbcdn.net/v/t1.0-9/12189087_979770468725299_4054796271002351625_n.jpg?oh=ac01ab7808385968062f98eadec0eb45&oe=593F0893',
                website: 'https://www.instagram.com/dogtown_dog/',
                email: 'christian.magueyal@facebook.com',
                hobbies: [
                    {
                        name: 'Skateboarding',
                        link: 'http://www.reddit.com/r/skateboarding'
                    },
                    {
                        name: 'Guitar',
                        link: 'http://www.reddit.com/r/guitar'
                    }
                ]
            };
        });
})();
