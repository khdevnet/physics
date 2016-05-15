(function () {


    angular.module("service.module")
           .factory("densityService", DensityService);

    DensityService.$inject = ["$http","config"];

    function DensityService($http,config) {

        var serviceUrl = config.serviceUrl;
        var pageSize = config.pageSize;
        
        return {
            save: save,
            get: get,
            add: add,
            remove: remove,
            getDensityList: getDensityList
        };


        function save(density) {
            if (density.id) return $http.put(serviceUrl + "/api/density/" + density.id, density);
            return $http.post(serviceUrl + "/api/density", density);
        }
        
        function get(id) {
            return $http.get(serviceUrl + "/api/density/" + id);
        }
        
        function add(density) {
            return $http.post(serviceUrl + "/api/density", density);
        }
        
        function remove(id) {
            return $http.delete(serviceUrl + "/api/density/" + id);
        }
        
        function getDensityList(pagination) {
            return $http.get(serviceUrl + "/api/density",
                { params: { page: pagination.currentPage, pageSize: pageSize } })
                .then(function (response) {
                    var paginationHeaderJson = response.headers("x-pagination");
                    var pagination = angular.fromJson(paginationHeaderJson);
                    return {
                        data: response.data,
                        pagination: pagination
                    };
                });
        }
    }
}());