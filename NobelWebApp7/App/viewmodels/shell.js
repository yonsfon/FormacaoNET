define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function () {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', title: 'Welcome', rolhas: '<i class="fa fa-home"></i>', moduleId: 'viewmodels/welcome', nav: true },
                { route: 'flickr', rolhas:'<i class="fa fa-flickr"></i>', moduleId: 'viewmodels/flickr', nav: true },
                //{ route: 'laureadoIndividuo', title: 'Laureados', moduleId: 'viewmodels/laureadoIndividuo', nav: true },

                // Colocar um icon no 
                { route: 'laureadoIndividuo', title: 'Person Page', rolhas: '<i class="fa fa-leaf"></i>', moduleId: 'viewmodels/laureadoIndividuo', nav: true },
                { route: 'laureadoDetalhes/:id', title: 'Person Details', moduleId: 'viewmodels/laureadoDetalhes', nav: false }
            ]).buildNavigationModel();

            return router.activate();
        }
    };
});