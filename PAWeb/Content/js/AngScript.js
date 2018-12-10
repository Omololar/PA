var myApp = angular
    .module("myModule", [])
    .controller("myController", function ($scope) {
       
        var technologies =
        {
            likes: 0,
            dislikes: 0
        }
           
        
        $scope.technologies = technologies;

        $scope.incrementLikes = (technology) => {
            technology.likes++;
        }
        $scope.incrementDislikes = (technology) => {
            technology.dislikes++;
        }
        $scope.technologies = technologies;
    });