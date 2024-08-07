sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/core/UIComponent"
], function(Controller, History, UIComponent) {
    "use strict";

    const MENOSUM = -1;
    const HOME = "Home";
    const HASH = "hash";

    return Controller.extend("cod3rsgrowth.controller.Base", {
        Historico: [],

        getRouter: function() {
            return UIComponent.getRouterFor(this);
        },

        onInit: function() {
            this.salvarHash();
        },

        salvarHash: function() {
            var oRouter = this.getRouter();

            oRouter.attachRouteMatched((oEvent) => {
                var sHash = oEvent.getParameter(HASH);

                if (sHash && sHash.indexOf("?") === -MENOSUM) {
                    this.Historico.push(sHash);
                }
            });
        },

        onNavBack: function() {
            if (this.Historico.length > 1) {
                this.Historico.pop();
                var HashAnterior = this.Historico.pop();
                this.getRouter().navTo(HashAnterior, {}, true);
            } else {
                const oRouter = this.getRouter();
                oRouter.navTo(HOME, {}, true);
            }
        }
    });
});
