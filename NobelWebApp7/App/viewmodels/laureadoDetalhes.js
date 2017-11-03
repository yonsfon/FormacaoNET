define(['plugins/router'], function (router) {
    var ctor = function () {
        console.log('ViewModel initiated...')
        var self = this;
        var baseUri = _baseUrl + '/api/LaureadoIndividuos/';
        this.displayName = 'Lista de Laureados';
        this.laureadosURI
        var laureadoId = router.activeInstruction().params[0];
        baseUri +=laureadoId

        //---Variáveis locais
        self.error = ko.observable();
        self.laureatesDetails = ko.observable();
        //--- Internal functions
        function ajaxHelper(uri, method, data) {
            self.error(''); // Clear error message
            return $.ajax({
                type: method,
                url: uri,
                dataType: 'json',
                contentType: 'application/json',
                data: data ? JSON.stringify(data) : null,
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log("AJAX Call[" + uri + "] Fail...");
                    self.error(errorThrown);
                }
            })
        }

        getLaureates = function () {
            console.log('CALL: getLaureate...')
            ajaxHelper(baseUri, 'GET').done(function (data) {
                self.laureatesDetails(data);
                if (self.laureatesDetails().length == 0)
                    alert('No Laureate found...');
            });
        };

        parseDate = function (theDate) {
            return theDate.split('T')[0];
        }

        start = function () {
            console.log('CALL: start...');
            getLaureates();
        };
        start();
    };

    return ctor;
});