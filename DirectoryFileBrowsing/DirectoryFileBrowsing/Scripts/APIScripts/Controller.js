app.controller("APIController", function($scope, APIService) {
    getItems(path);

    function getItems(path) {
        $(".message").hide();
        $(".warning").hide();

        if (path.innerText != "") {
            var servCall = APIService.getAll(path);
            $(".message").show();

            servCall.then(function(d) {
                $scope.files = d.data;
                $(".message").hide();
                    if ($scope.files.Warning != "") {
                        $(".warning").show();
                    }
                },
                function(error) {
                    $log.error("Something wrong while data reading!");
                });
        }
    }

    $scope.getData = function() {
        getItems($scope.path);
    }
});