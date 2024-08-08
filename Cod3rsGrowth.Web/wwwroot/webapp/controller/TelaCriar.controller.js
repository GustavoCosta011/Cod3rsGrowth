sap.ui.define([
    "./Base",
    "../servico/ClubeServico",
    "../formatter",
], (Base, ClubeServico, Formatter) => {
    "use strict";

    const NUMZERO = 0;
    const SIM = "Sim";
    const FUNDACAO = "fundacao";
    const ESTADIO = "estadio";
    const NOME = "nome";
    const VALUE = "value";
    const ITEMSELECIONADO = "selectedItem";
    const ESTADO = "estado";
    const COBERTURA = "coberturaAntiChuva";
    const SELECTEDINDEX = "selectedIndex";
    const INPUTNOME = "InputNome";
    const CALENDARIOCRIAR = "CalendarioCriar";
    const INPUTESTADIO = "InputEstadio";
    const ESTADIOCRIACAO = "EstadoCriacao";
    const BOTAO_SIM = "BotaoSim";
    const BOTAO_NAO = "BotaoNao";
    const VAZIO = "";

    return Base.extend("cod3rsgrowth.webapp.controller.Criar", {
        clubeServico: ClubeServico,
        formatter: Formatter,
        onInit: function () {
            this.DadosCriacao = [];
            this._vincularRota("criar", this.aoCoincidirRota);
        },

        aoCoincidirRota: function(){
            this.resetarItems();
            this.Modelo = this.getView().getModel("clubes");
        },

        aoInserirNome: function(oEvent){
            var nome = oEvent.getParameter(VALUE);
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== NOME);
            if (nome) {
                this.DadosCriacao.push({ key: NOME, value: nome});
            }
        },

        aoInserirFundação: function(oEvent){
            var fundacao = oEvent.getParameter(VALUE);
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== FUNDACAO);
            if(fundacao){
                var DataFormatada = this.formatter.formatDateReverse(fundacao);
                this.DadosCriacao.push({key: FUNDACAO, value: DataFormatada});
            }
        },

        aoInserirEstadio: function(oEvent){
            var estadio = oEvent.getParameter(VALUE);
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== ESTADIO);
            if (estadio) {
                this.DadosCriacao.push({ key: ESTADIO, value: estadio});
            }
        },

        aoInserirEstadoDeCriação: function(oEvent){
            var estado = oEvent.getParameter(ITEMSELECIONADO).getKey();
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== ESTADO);
            if (estado >= NUMZERO) {
                this.DadosCriacao.push({ key: ESTADO, value: parseInt(estado, 10)});
            }
        },

        aoInserirCobertura: function(oEvent){
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== COBERTURA);
            var selectedIndex = oEvent.getParameter(SELECTEDINDEX);
            var grupoDeBotoes = oEvent.getSource();
            var TextoSelecionado = grupoDeBotoes.getButtons()[selectedIndex].getText();
            var cobertura = TextoSelecionado === SIM;
            this.DadosCriacao.push({ key: COBERTURA, value: cobertura});
        },

        resetarItems: function() {
            var inputNome = this.byId(INPUTNOME);
            if (inputNome) {
                inputNome.setValue(VAZIO);
            }

            var calendarioCriar = this.byId(CALENDARIOCRIAR);
            if (calendarioCriar) {
                calendarioCriar.setDateValue(null);
            }

            var inputEstadio = this.byId(INPUTESTADIO);
            if (inputEstadio) {
                inputEstadio.setValue(VAZIO);
            }

            var estadoCriacao = this.byId(ESTADIOCRIACAO);
            if (estadoCriacao) {
                estadoCriacao.setSelectedKey(null);
            }

            var botaoSim = this.byId(BOTAO_SIM);
            if (botaoSim) {
                botaoSim.setSelected(false);
            }

            var botaoNao = this.byId(BOTAO_NAO);
            if (botaoNao) {
                botaoNao.setSelected(false);
            }
        },

        aoSalvarClube: function () {
            var DadosDaCriação = this.DadosCriacao.reduce((newArray, atual) => {
                newArray[atual.key] = atual.value;
                return newArray;
            }, {})
            this.clubeServico.aoCriarClube(DadosDaCriação);
        }
    });
});
