angular.module('myApp').controller('myCtrl', ["$scope", "$http", "$rootScope", "$translate", function ($scope, $http, $rootScope, $translate) {
  $scope.Home = 'Home';
  $scope.Icons = 'Icons';
  $scope.Tables = 'Tables';
  $scope.Customer = 'Customer';
  $scope.title = 'Home';
}]);


