(function () {

    var app = angular.module("app", ["app.density", "app.core", "service.module"]);


    app.config(function ($routeProvider, $httpProvider) {

        $routeProvider.when("/density", {
            templateUrl: "app/density/densities.html",
            controller: "DensitiesController",
            controllerAs: "vm"
        });
        $routeProvider.when("/density/new", {
            templateUrl: "app/density/density.html",
            controller: "DensityController",
            controllerAs: "vm"
        });
        $routeProvider.when("/density/:id", {
            templateUrl: "app/density/density.html",
            controller: "DensityController",
            controllerAs: "vm"
        });

        $routeProvider.when("/calculate/density", {
            templateUrl: "app/calculator/calculateDensity.html",
            controller: "CalculateDensityController",
            controllerAs: "vm"
        });
        $routeProvider.otherwise({ redirectTo: "/density" });


    });

}());