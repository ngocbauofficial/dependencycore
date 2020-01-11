angular.module('myApp').controller('rootController', ["$scope", "$http", "$rootScope", "$translate", function ($scope, $http, $rootScope, $translate) {
  $scope.Home = 'Home';
  $scope.Icons = 'Icons';
  $scope.Tables = 'Tables';
  $scope.Customer = 'Customer';
  $scope.title = 'Home';
}]);

angular.module('myApp').controller('homeController', ["$scope", "$http", "$rootScope", function ($scope, $http, $rootScope) {
  $scope.title = 'Home';
}]);


angular.module('myApp').controller('iconsController', ["$scope", "$http", "$rootScope", function ($scope, $http, $rootScope) {
  $scope.title = 'Icon';

}]);

angular.module('myApp').controller('tablesController', ["$scope", "$http", "$rootScope", function ($scope, $http, $rootScope) {
  $scope.title = 'Table';
}]);





