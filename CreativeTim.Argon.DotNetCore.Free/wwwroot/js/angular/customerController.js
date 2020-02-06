
angular.module('myApp').service("customerService", function ($http) {
  // Update customer
  this.Edit = function (customer) {
    var response = $http({
      method: "post",
      url: "/Customer/Edit",
      data: JSON.stringify(customer),
      dataType: "json",

    })
    return response;
  }

  // Add customer
  this.Add = function (customer) {
    var response = $http({
      method: "post",
      url: "/Customer/Add",
      data: JSON.stringify(customer),
      dataType: "json"
    });
    return response;
  }

  //Delete customer
  this.Delete = function (Id) {
    var response = $http({
      method: "post",
      url: "/Customer/Delete",
      params: {
        employeeId: JSON.stringify(Id)
      }
    });
    return response;
  }
})

angular.module('myApp').controller('myCtrl', ['$scope', '$http', 'DTOptionsBuilder', 'DTColumnBuilder', '$translate', 'customerService','$location',
  function ($scope, $http, DTOptionsBuilder, DTColumnBuilder, $translate, customerService, $location) {

    $scope.dtColumns = [
      { 'mData': 'Id' },
      { 'mData': 'Name' },
      { 'mData': 'Phone' },
      { 'mData': 'Email' },
      {
        'mData': 'Id',
        'mRender': function (data, type, full, meta) {
          return '<a href="/Customer/Edit/'+data+'" class="btn btn-default btn-sm btn-icon icon-left"><i class="entypo-pencil"></i>Edit</a>';
        }
      },
      {
        'mData': 'Id',
        'mRender': function (data, type, full, meta) {
          return '<a href="#"  ng-click="DeleteConfirm('+data+')" class="btn btn-danger btn-sm btn-icon icon-left"> <i class="entypo-cancel" ></i> Delete</a>'
        }
      },
    ];

    $scope.dtOptions = DTOptionsBuilder.newOptions().withOption('ajax', {
      dataSrc: "data",
      url: "/Customer/List",
      type: "POST"
    })
      .withOption('processing', true) //for show progress bar
      .withOption('serverSide', true) // for server side processing
      .withPaginationType('simple_numbers') // for get full pagination options // first / last / prev / next and page numbers
      .withOption('ordering', false)
      .withOption('info', false)
      .withOption('lengthChange', false)
     
      .withLanguage({
        "paginate": {
          "next": '<i class="entypo-right-open"></i>',
          "previous": '<i class="entypo-left-open"></i>'
        },
        "processing": '<div class="loading">Loading&#8230;</div>'
      })
      .withDisplayLength(10) // Page size
    //    .withOption('aaSorting', [0, 'asc']) // for default sorting column // here 0 means first column


    $scope.AddConfirm = function () {
      debugger;
      var Customer = {
        Name: $scope.Name,
        Phone: $scope.Phone,
        Email: $scope.Email,
        Address: $scope.Address,
        Gender: $scope.Gender,
        Address1: $scope.Address1,
      };
      var data = customerService.Add(Customer);
      data.then(function (msg) {
        if (msg.data == 1) {
          $location.url('/Customer');
          messageSuccess($translate.instant('Customer.TitleMessage'), $translate.instant('Customer.AddSuccess'));
        }
        else {
          messageFailed($translate.instant('Customer.TitleMessage'), $translate.instant('Customer.AddFailed'));
        }
      });
    }
    $scope.DeleteConfirm = function (Id) {
      debugger;
      var data = customerService.Delete(Id);
      data.then(function (msg) {
        if (msg.data == 1) {
          window.location.href = msg.data.message;
        }
        else {
          $scope.msg = msg.data.message;
        }
      });
    }

    $scope.EditConfirm = function () {
      debugger;
      var Customer = {
        Id: $scope.Id,
        Name: $scope.Name,
        Phone: $scope.Phone,
        Email: $scope.Email,
        Address: $scope.Address,
        Gender: $scope.Gender,
        Address1: $scope.Address1,
      };
      var data = customerService.Edit(Customer);
      data.then(function (msg) {
        if (msg.data == 1) {
          $location.url('/Customer');
          messageSuccess($translate.instant('Customer.TitleMessage'), $translate.instant('Customer.EditSuccess'));
        }
        else {
          messageFailed($translate.instant('Customer.TitleMessage'), $translate.instant('Customer.EditFailed'));
        }
      });
    }
  }])

