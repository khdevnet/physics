(function () {


    angular.module("service.module")
           .factory("calculatorService", CalculatorService);

    CalculatorService.$inject = ["$http","config"];

    function CalculatorService($http, config) {

        var serviceUrl = config.serviceUrl;
        
        return {
            calcVolume: calcVolume,
            calcWeight: calcWeight,
            calcDensity: calcDensity
        };

        function calcVolume(options) {
            return $http.post(serviceUrl + "/api/calculate/volume", options);
        }

        function calcWeight(options) {
            return $http.post(serviceUrl + "/api/calculate/weight", options);

        }
        
        function calcDensity(options) {
            return $http.post(serviceUrl + "/api/calculate/density", options);
        }
    }
}());