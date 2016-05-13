(function () {


    angular.module("service.module")
        .factory("CalculatorService", CalculatorService);

    CalculatorService.$inject = ["$http"];

    function CalculatorService($http) {

        var serviceUrl = "http://localhost:49750";
        var pageSize = 5;
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