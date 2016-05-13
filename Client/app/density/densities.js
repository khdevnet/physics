(function () {


    angular.module("app.density")
        .controller("DensitiesController", DensitiesController);

    DensitiesController.$inject = ['$location', "$timeout", 'DensityService'];

    function DensitiesController($location, $timeout, densityService) {

        var vm = this;
        vm.successMessage = "";
        vm.errorMessage = "";
        vm.densities = [];
        vm.new = newDensity;
        vm.edit = editDensity;
        vm.remove = remove;
        vm.pagination = {
            currentPage: $location.search().page,
            totalPages: null,
            next: function () {
                if (this.hasNextPage()) {
                    $location.path("/density").search({ page: this.currentPage + 1 });
                }
            },
            hasNextPage: function () {
                return this.currentPage < this.totalPages;
            },
            prev: function () {
                if (this.hasPrevPage()) {
                    $location.path("/density").search({ page: this.currentPage - 1 });
                }
            },
            hasPrevPage: function () {
                return this.currentPage > 1;
            },
        };

        init();

        function init() {
            densityService.getDensityList(vm.pagination).then(function (densityList) {
                vm.densities = densityList.data;
                angular.extend(vm.pagination, densityList.pagination);
            });
        }

        function newDensity() {
            $location.path("/density/new");
        };
        function editDensity(id) {
            $location.path("/density/" + id);
        };
        function remove(density) {
            densityService.remove(density.id).success(function () {
                var index = vm.densities.indexOf(density);
                vm.densities.splice(index, 1);
                vm.successMessage = density.title + " Removed!";
                $timeout(function () {
                    vm.successMessage = "";
                }, 3000);
            }).error(function () {
                vm.errorMessage = "Can't remove density: " + density.title;
                $timeout(function () {
                    vm.errorMessage = "";
                },3000);
            });
        };
    }
}());