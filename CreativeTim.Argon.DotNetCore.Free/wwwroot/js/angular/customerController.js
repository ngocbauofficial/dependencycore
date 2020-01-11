
angular.module('myApp').controller('customerController', ['$scope', '$http', 'DTOptionsBuilder', 'DTColumnBuilder',
  function ($scope, $http, DTOptionsBuilder, DTColumnBuilder) {
    $scope.dtColumns = [
      DTColumnBuilder.newColumn("Id", "ID"),
      DTColumnBuilder.newColumn("Name", "NAME"),
      DTColumnBuilder.newColumn("Phone", "Phone"),
      DTColumnBuilder.newColumn("Email", "Email"),
      DTColumnBuilder.newColumn("Id", "EDIT").renderWith(function (data) {
        return '<a href="/Customer/Edit/' + data + '" class="edit"><i class="fas fa-user-edit"></i></a>'
      }),
      DTColumnBuilder.newColumn("Id", "DELETE").renderWith(function (data) {
        return '<input type="checkbox" name="name" value="' + data + '" />'
      }),
    ]

    $scope.dtOptions = DTOptionsBuilder.newOptions().withOption('ajax', {
      dataSrc: "data",
      url: "/Customer/List",
      type: "POST"
    })
      .withOption('processing', true) //for show progress bar
      .withOption('serverSide', true) // for server side processing
      .withPaginationType('full_numbers') // for get full pagination options // first / last / prev / next and page numbers
      .withOption('ordering', false)
      .withOption('info', false)
      .withOption('lengthChange', false)
      .withLanguage({
        "paginate": {
          "first": '<i class="fa fa-fast-backward"></i>',
          "last": '<i class="fa fa-fast-forward"></i>',
          "next": '<i class="fa fa-forward"></i>',
          "previous": '<i class="fa fa-backward"></i>'
        },
        "processing": '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>'
      })
      .withDisplayLength(10) // Page size
    //    .withOption('aaSorting', [0, 'asc']) // for default sorting column // here 0 means first column

  }])

//app.controller("myController", function ($scope, updateCustomerService) {
//  $scope.UpdateConfirm = function () {
//    var User = {
//      UserName: $scope.userName,
//      PassWord: $scope.passWord,
//    };
//    debugger;
//    var data = updateCustomerService.Update(User);
//    data.then(function (msg) {
//      if (msg.data.result == "1") {

//        window.location.href = msg.data.message;
//      }
//      else {
//        $scope.msg = msg.data.message;

//      }

//    })
//  }

//});




//app.service("CustomerService", function ($http) {
//  this.Edit = function (User) {
//    var response = $http({
//      method: "post",
//      url: "/Customer/Edit",
//      data: JSON.stringify(User),
//      dataType: "json",
//      headers: { 'content-type': 'application/json' }
//    })
//    return response;
//  }

//  this.Add = function (User) {
//    var response = $http({
//      method: "post",
//      url: "/Customer/Add",
//      data: JSON.stringify(User),
//      dataType: "json",
//      headers: { 'content-type': 'application/json' }
//    })
//    return response;
//  }


//  this.Delete = function (User) {
//    var response = $http({
//      method: "post",
//      url: "/Customer/Delete",
//      data: JSON.stringify(User),
//      dataType: "json",
//      headers: { 'content-type': 'application/json' }
//    })
//    return response;
//  }
//});
