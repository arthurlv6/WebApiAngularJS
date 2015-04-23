(function () {
    "use strict";

    angular
        .module("main")
        .controller("ProductEditCtrl",ProductEditCtrl);

    function ProductEditCtrl(productResource) {
        var vm = this;
        vm.product = {};
        vm.message = '';

        productResource.get({ id: 0 },
            function (data) {
                vm.product = data;
                vm.originalProduct = angular.copy(data);
            });

        if (vm.product && vm.product.id) {
            vm.title = "Edit: " + vm.product.productName;
        }
        else {
            vm.title = "New Product";
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.product.id) {
                vm.product.$update({ id: vm.product.id },
                    function (data) {
                        vm.message = "... Save Complete";
                    })
            }
            else {
                vm.product.$save(
                    function (data) {
                        vm.originalProduct = angular.copy(data);

                        vm.message = "... Save Complete";
                    })
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.product = angular.copy(vm.originalProduct);
            vm.message = "";
        };

    }
}());
