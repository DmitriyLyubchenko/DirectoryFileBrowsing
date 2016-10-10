app.service("APIService", function($http) {
    this.getAll = function (path) {
        return $http.get('api/values?path=' + path);
    };
});