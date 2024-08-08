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
        _getRouter: function() {
            return UIComponent.getRouterFor(this);
        },

        _onNavBack: function(rotaDestino, parametros = {}) {
			if (rotaDestino) {
                this._getRouter().navTo(rotaDestino, parametros);
                this.resetarItems();
            }
			else { 
                this._getRouter().navTo(HOME);
            }
        },
        
        _vincularRota: function(Rota, Metodo){
            this._getRouter().getRoute(Rota).attachMatched(Metodo, this); 
        },
    });
});
