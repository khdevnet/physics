(function () {


    angular.module("app.density")
        .controller("CalculateDensityController", DensityController);

    DensityController.$inject = ["CalculatorService"];

    function DensityController(calculatorService) {

        var vm = this;
        vm.calculate = calculate;
        vm.result = "";

        function calculate() {
            calculatorService.calcDensity(vm.options).then(function (response) {
                vm.result = response.data;
            });
        }


    }
}());