(function () {


    angular.module("app.density")
        .controller("DensityController", DensityController);

    DensityController.$inject = ["$scope","$routeParams", "$location", "densityService"];

    function DensityController($scope,$routeParams, $location, densityService) {

        var id = $routeParams.id;
        var vm = this;
        vm.density = {};
        vm.error = false;
        vm.save = save;
        vm.reset = reset;

        init();


        function init() {
            densityService.get(id).then(function (response) {
                loaded = true;
                angular.extend(vm.density, response.data);
            });
        }
        function reset() {
            $scope.formDensity.$setPristine();
            $scope.formDensity.$setUntouched();
            vm.density = {};
        }

        function save() {
            densityService.save(vm.density).success(function () {
                $location.path("/densities");
            }).error(function () {
                vm.error = true;
            });
        }
    }
}());