sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/UIComponent",
    "../servico/ClubeServico",
    "sap/ui/model/json/JSONModel"

], function(Controller, UIComponent, ClubeServico,JSONModel) {
    "use strict";

    const NOME_DA_ROTA_HOME = "Home";
    const NOME_MODELO_ESTADOS = "estados";
    const TEXTO_ERRO_FETCH_ESTADO = 'Erro ao buscar estados:';
    const PARAMETRO_LIMPAR = "Limpar";
    const TITULO_ERRO = "Erro";


    return Controller.extend("cod3rsgrowth.controller.Base", {
        Historico: [],
        clubeServico: ClubeServico,

        _getRouter: function() {
            return UIComponent.getRouterFor(this);
        },

        _navegarPara: function(rotaDestino, parametros = {}) {
			if (rotaDestino) {
                this._getRouter().navTo(rotaDestino, parametros);
                if(parametros.Acao == PARAMETRO_LIMPAR){
                    this.resetarItems();
                }
            }
			else { 
                this._getRouter().navTo(NOME_DA_ROTA_HOME);
            }
        },

        _carregarEstados: function() {
            ClubeServico.buscarEstados()
                .then((estados) => {
                    let oModel = new JSONModel(estados);
                    this._modelo(oModel, NOME_MODELO_ESTADOS);
                })
                .catch((error) => {
                    console.error(TEXTO_ERRO_FETCH_ESTADO, error);
                });
        },
        
        vincularRota: function(rota, metodo){
            this._getRouter().getRoute(rota).attachMatched(metodo, this); 
        },

        _modelo: function(nome, modelo = null){
            if(modelo){
                return this.getView().setModel(modelo, nome)
            }
            return this.getView().getModel(nome);
        },

        _exibirEspera: async function (funcao) {
            return Promise.resolve(funcao())
            .catch(erro => MessageBox.error(erro, {title : TITULO_ERRO}))
        }
    });
});
