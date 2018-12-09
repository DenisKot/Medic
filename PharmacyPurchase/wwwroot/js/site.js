// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var items = {};


angular.module('medicApp', [])
    .controller('MedicamentsListController', ['$scope', '$http', function ($scope, $http) {
        this.items = {};
        
        this.buyItems = function () {
            var itemsToBuy = [];

            for (var key in this.items) {
                var value = this.items[key];
                if (value === true) {
                    var count = this.items[key + "Count"];
                    if (count > 0) {
                        itemsToBuy.push({
                            id: parseInt(key.replace(/model/, '')),
                            count: count
                        });
                    }
                }
            }

            var req = {
                method: 'POST',
                url: '/Medicaments/buy',
                data: {
                    items: itemsToBuy
                }
            };

            $http(req).then(function() {
                location.reload();
            });
        };
    }]);
