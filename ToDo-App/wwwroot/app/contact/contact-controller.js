(function () {
    'use strict';

    angular
        .module('app')
        .controller('ContactController', function ContactController(mytoastr) {
            /* jshint validthis:true */
            var vm = this;
            vm.title = 'contact_controller';
            vm.contact = {};
            vm.isSubmitted = false;

            vm.sendToMe = function(){
                console.log(vm.contact);
                console.log('We sent it');
                vm.isSubmitted = true;
                mytoastr.success("You!!!!!!");
                mytoastr.warning("error!!!!!");
            }

            

        });
})();
