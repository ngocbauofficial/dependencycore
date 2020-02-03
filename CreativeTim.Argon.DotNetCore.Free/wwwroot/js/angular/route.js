
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
  var baseUrl = $("base").first().attr("href");
  $routeProvider
    .when('/', {
      title: 'My Dashboard',
      templateUrl: '/Home/Home',
      controller: 'homeController',
       resolve: {
        LazyLoadCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
          return $ocLazyLoad.load('home'); // Resolve promise and load before view 
        }]
      },
    })

    .when('/Customer', {
      title: 'Customer',
      templateUrl: '/Customer/List',
      controller: 'customerController',
      resolve: {
        LazyLoadCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
          return $ocLazyLoad.load('customer'); // Resolve promise and load before view 
        }]
      }
     
    })
    .when('/Customer/Edit/:id', {
      disableCache: true,
      templateUrl: function (params) {
        return '/Customer/GetEdit/' + params.id +"?"+ $.now();
      },
      controller: 'customerController',
      resolve: {
        LazyLoadCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
          return $ocLazyLoad.load('customer'); // Resolve promise and load before view 
        }]
      }
    })
    .when('/Customer/Add', {
      title: 'Customer',
      templateUrl: '/Customer/GetAdd',
      controller: 'customerController',
      resolve: {
        LazyLoadCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
          return $ocLazyLoad.load('customer'); // Resolve promise and load before view 
        }]
      }
    })

    .otherwise({
      redirectTo: '/'
    });

  $locationProvider.html5Mode(true);
}]);

app.run(['$rootScope', '$route', function ($rootScope, $route) {
  $rootScope.$on('$routeChangeSuccess', function () {
    document.title = $route.current.title + " | PTB";
  });
}]);

//app.run(['$rootScope', '$route', function ($rootScope, $route) {
//  $rootScope.$on('$routeChangeSuccess', function () {
//    document.title = $route.current.title;
//  });
//}]);
