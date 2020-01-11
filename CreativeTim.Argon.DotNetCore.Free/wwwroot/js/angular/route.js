
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
    .when('/Icons', {
      title: 'Icon',
      templateUrl:'/Home/Icons',
      controller: 'iconsController',
      resolve: {
        LazyLoadCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
          return $ocLazyLoad.load('home'); // Resolve promise and load before view 
        }]
      },
    })
    .when('/Tables', {
      templateUrl: '/Home/Tables',
      controller: 'tablesController',
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

      templateUrl: function (params) {
        return '/Customer/Edit/' + params.id;
      },
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

app.run(['$rootScope', function ($rootScope) {
  $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
    $rootScope.title = current.$$route.title;
  });
}]);

//app.run(['$rootScope', '$route', function ($rootScope, $route) {
//  $rootScope.$on('$routeChangeSuccess', function () {
//    document.title = $route.current.title;
//  });
//}]);
