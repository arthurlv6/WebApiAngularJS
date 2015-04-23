(function () {
    "use strict";
    angular
        .module("main")
        .controller("ProductListCtrl",
                     ["productResource",
                         ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;
        vm.productSearchInput = "";
        productResource.query({
            //$filter: "contains(ProductCode, 'A') and Price ge 0 and Price le 2000",
            $orderby: "Name"
        },
            function (data) {
                vm.products = data;
            });
        vm.search = function() {
            productResource.query({
                $filter: "contains(Name, '" + vm.productSearchInput + "')"+
                " or contains(ProductCode, '" + vm.productSearchInput + "')",
                    $orderby: "Name"
                },
                function(data) {
                    vm.products = data;
                });
        };
        // Alternative code using variables instead of hard-coded values
        //vm.searchCriteria = "GDN";
        //vm.sortProperty = "Price";
        //vm.sortDirection = "desc";

        //productResource.query({
        //    $filter: "contains(ProductCode, '" + vm.searchCriteria + "')" +
        //        " or contains(ProductName, '" + vm.searchCriteria + "')",
        //    $orderby: vm.sortProperty + " " + vm.sortDirection
        //}, function (data) {
        //    vm.products = data;
        //})

    }
}());
