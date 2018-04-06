(function () {
    'use strict';

    angular
        .module('app')
        .config(function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');



            $stateProvider.state('todo', {
                url: '/',
                controller: 'TodoController',
                controllerAs: 'todo',
                templateUrl: 'app/todo/todo.html',
                resolve: {
                todos: function (todoService) {
                    return todoService.getTodos();
                },
                completed: function (todoService) {
                    return todoService.getTodos();
                }

            }
            }).state('warning', {
                url: '/warning',
                controller: 'WarningController',
                controllerAs: 'warning',
                templateUrl: 'app/warning/warning.html',
                resolve: {
                    warnings: function (warningService) {
                        return warningService.getWarnings();
                    }
                }
            }).state('complete', {
                url: '/complete',
                controller: 'CompleteController',
                controllerAs: 'complete',
                templateUrl: 'app/complete/complete.html',
                resolve: {
                    completed: function (completeService) {
                        return completeService.getTodos();
                    }
                }

            }).state('faq', {
                    url: '/faq',
                    controller: 'FaqController',
                    controllerAs: 'faqs',
                    templateUrl: 'app/faqs/faqs.html',
                    resolve: {
                        faqs: function (faqService) {
                            return faqService.getAllFaqs();
                        },
                        values: function (valueService) {
                            return valueService.getAllValues();
                        }
                    }
                })
                .state('contact', {
                    url: '/contact',
                    controller: 'ContactController',
                    controllerAs: 'contact',
                    templateUrl: 'app/contact/contact.html'
                })
                .state('pokedex', {
                    url: '/pokedex',
                    controller: 'PokedexController',
                    controllerAs: 'pokedex',
                    templateUrl: 'app/pokedex/pokedex.html'
                })
                

        });

    
})();
