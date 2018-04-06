(function () {
    'use strict';

    angular
        .module('app')
        .controller('FaqController', function FaqController(faqService, faqs, values) {
            /* jshint validthis:true */
            var vm = this;
            vm.title = 'faq_controller';
            vm.faqs = faqs;
            vm.values = values;
            

            
        });
})();
