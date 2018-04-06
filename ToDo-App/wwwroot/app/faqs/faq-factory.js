(function () {
    'use strict';

    angular
        .module('app')
        .factory('faqService', function faq_factory() {


            function getFaqs() {
                return [
                    {
                        question: 'why are you the way that you are?',
                        answer: 'i have no idea.'
                    },
                    {
                        question: 'Is this a terrible example?',
                        answer: 'Yes of course'
                    },
                    {
                        question: 'Are you going to work?',
                        answer: 'Probably'
                    }

                ];

            }
            var service = {
                getAllFaqs: getFaqs
            };
            return service;

        });
})();