(function () {


    angular.module("app.density")
        .controller("CalculateDensityController", CalculateDensityController);

    CalculateDensityController.$inject = ["$timeout","calculatorService"];

    function CalculateDensityController($timeout, calculatorService) {

        var vm = this;
        vm.calculate = calculate;
        vm.result = "";
        vm.error = "";

        function calculate() {
            calculatorService.calcDensity(vm.options).then(function (response) {
                vm.result = response.data;
            }, function(response){
                vm.error = response.data.message;
                $timeout(function () {
                    vm.error="";
                }, 3000);
            });
        }
    }
}());