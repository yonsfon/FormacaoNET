define(['durandal/app'], function (app) {
    var ctor = function () {
        console.log('ViewModel initiated...')
        var self = this;
        //var baseUri = 'http://localhost:54257/api/LaureadoIndividuos';
        var baseUri = _baseUrl + '/api/LaureadoIndividuos';
        this.displayName = 'Lista de Laureados';
        this.laureadosURI
        //---Variáveis locais
        self.error = ko.observable();
        self.laureates = ko.observableArray();
        self.srchName = ko.observable();
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
            console.log('CALL: getLaureates...')
            ajaxHelper(baseUri, 'GET').done(function (data) {
                self.laureates(data);
                if (self.laureates().length == 0)
                    alert('No Laureates found...');
            });
        };

        resetForm = function () {
            console.log('CALL: resetForm...')
            self.srchName("");
            self.laureates.removeAll();
        };
        laureadoDetalhes = function () {
            console.log('CALL: getLaureates (with name)...')
            newBaseUri = baseUri + "?srchName=" + self.srchName();
            ajaxHelper(newBaseUri, 'GET').done(function (data) {
                self.laureates(data);
                if (self.laureates().length == 0)
                    alert('No Laureates found...');
            });
        };

        parseDate = function (theDate) {
            if (theDate != null)
                return theDate.split('T')[0];
            else
                return "-";
        }

        start = function () {
            console.log('CALL: start...');
            getLaureates();
        };
        start();
    };

    return ctor;
});