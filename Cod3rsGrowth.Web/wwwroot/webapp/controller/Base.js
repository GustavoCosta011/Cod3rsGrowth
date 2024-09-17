sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/UIComponent",
    "../servico/ClubeServico",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"

], function(Controller, UIComponent, ClubeServico, JSONModel, MessageBox) {
    "use strict";

    const NOME_DA_ROTA_HOME = "Home";
    const NOME_MODELO_ESTADOS = "estados";
    const TEXTO_ERRO_FETCH_ESTADO = 'Erro ao buscar estados:';
    const PARAMETRO_LIMPAR = "Limpar";
    const TITULO_ERRO = "Erro";
    const MENSAGEM_ERRO_DESCONHECIDO = "Erro desconhecido encontrado!";
    const DETALHES_ERRO_INDISPONIVEL = "Stacktrace está indisponível!";
    const QUEBRADELINHA = "\r\n";
    const NOME_MODELO_CLUBE = "clube";
    const NOME_MODELO_JOGADORES = "jogadores";
    const NOME_MODELO_JOGADOR = "jogador";


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
                    this._resetarItems();
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
            .catch(erro => this._exibirErroNaTela(erro))
        },

        _exibirErroNaTela: function(erro) {  
            console.log(erro)
            let mensagemErro = MENSAGEM_ERRO_DESCONHECIDO;
            let detalhesErro = DETALHES_ERRO_INDISPONIVEL;
        
            if (erro.extensions && erro.extensions.fluentValidation) {
                mensagemErro = Object.values(erro.extensions.fluentValidation).join("\r\n");
            } 
            else if (erro.detail) {
                mensagemErro = erro.detail.split(QUEBRADELINHA);
            }
            if (erro.title || erro.Title) {
                detalhesErro = erro.detail;
            }
        
            MessageBox.error(mensagemErro, {
                title: TITULO_ERRO,
                details: detalhesErro,
                actions: [MessageBox.Action.CLOSE]
            });
        },

        _modeloClube: function (modelo = null) {
            if(modelo){
                return this._modelo(NOME_MODELO_CLUBE, modelo);
            }
            return this._modelo(NOME_MODELO_CLUBE);
        },

        _modeloJogador: function (modelo = null) {
            if(modelo){
                return this._modelo(NOME_MODELO_JOGADOR, modelo);
            }
            return this._modelo(NOME_MODELO_JOGADOR);
        },

        _modeloJogadores: function (modelo = null) {
            if(modelo){
                return this._modelo(NOME_MODELO_JOGADORES, modelo);
            }
            return this._modelo(NOME_MODELO_JOGADORES);
        },
    });
});
