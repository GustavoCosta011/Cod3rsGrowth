sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/UIComponent",
    "../servico/ClubeServico",
    "sap/ui/model/json/JSONModel"

], function(Controller, UIComponent, ClubeServico,JSONModel) {
    "use strict";

    const HOME = "Home";
    const ESTADOS = "estados";
    const TEXTO_ERRO_FETCH_ESTADO = 'Erro ao buscar estados:';

    return Controller.extend("cod3rsgrowth.controller.Base", {
        Historico: [],
        clubeServico: ClubeServico,

        _getRouter: function() {
            return UIComponent.getRouterFor(this);
        },

        navegarPara: function(rotaDestino, parametros = {}) {
			if (rotaDestino) {
                this._getRouter().navTo(rotaDestino, parametros);
                if(parametros.Acao == "Limpar"){
                    this.resetarItems();
                }
            }
			else { 
                this._getRouter().navTo(HOME);
                this.resetarItems();
            }
        },

        _CarregarEstados: function() {
            this.clubeServico.aoBuscarEstados()
                .then((estados) => {
                    var oModel = new JSONModel(estados);
                    this.getView().setModel(oModel, ESTADOS);
                })
                .catch((error) => {
                    console.error(TEXTO_ERRO_FETCH_ESTADO, error);
                });
        },
        
        _vincularRota: function(Rota, Metodo){
            this._getRouter().getRoute(Rota).attachMatched(Metodo, this); 
        },
    });
});
