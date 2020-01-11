var app = angular.module('myApp', ["ngRoute", "datatables","oc.lazyLoad", "ngCookies", "pascalprecht.translate"]);


app.config(['$translateProvider',
  function ($translateProvider) {
    var language = (window.navigator.userLanguage || window.navigator.language).toLowerCase();
    console.log(language);
    $translateProvider.registerAvailableLanguageKeys(['vi-VN', 'en-US'], {
      'en-US': 'en-US',
      'vi-VN': 'vi-VN',
      'vi': 'vi-VN',
      'en': 'en-US'
    });

    $translateProvider.useStaticFilesLoader({
      prefix: 'js/translate/Menu.',
      suffix: '.json'
    });


    $translateProvider.preferredLanguage('vi-VN');
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
app.config(["$ocLazyLoadProvider", function ($ocLazyLoadProvider) {
  $ocLazyLoadProvider.config({
   
    'modules': [{ // Set modules initially
      name: 'home', // State1 module
      files: ['js/angular/rootController.js']
    },
      {
      name: 'customer', // State2 module
        files: ['js/angular/customerController.js']
      }
    ]
  });
}]);
