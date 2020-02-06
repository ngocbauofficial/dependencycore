var app = angular.module('myApp', [ "datatables", "ngCookies", "pascalprecht.translate"]);


app.config(['$translateProvider',
  function ($translateProvider) {
    var language = (window.navigator.userLanguage || window.navigator.language).toLowerCase();
    $translateProvider.registerAvailableLanguageKeys(['vi-VN', 'en-US'], {
      'en-US': 'en-US',
      'vi-VN': 'vi-VN',
      'vi': 'vi-VN',
      'en': 'en-US'
    });

    $translateProvider.useStaticFilesLoader({
      files: [{
        prefix: 'js/translate/Menu.',
        suffix: '.json'
      },
      {
        prefix: 'js/translate/Button.',
        suffix: '.json'
      },
      {
        prefix: 'js/translate/Customer.',
        suffix: '.json'
      }]
    });

    $translateProvider.preferredLanguage('vi-VN'); // default
    // $translateProvider.use('de');
    $translateProvider.useCookieStorage();
    $translateProvider.fallbackLanguage("en-US");
  }
]);

app.controller('translate', ['$scope', '$translate',
  function ($scope, $translate) {

    $scope.switchLanguage = function (key) {
      $translate.use(key);
    };
  }
]);
//app.config(["$ocLazyLoadProvider", function ($ocLazyLoadProvider) {
//  $ocLazyLoadProvider.config({
   
//    'modules': [{ // Set modules initially
//      name: 'home', // State1 module
//      files: ['js/angular/rootController.js']
//    },
//      {
//      name: 'customer', // State2 module
//        files: ['js/angular/customerController.js']
//      }
//    ]
//  });
//}]);
