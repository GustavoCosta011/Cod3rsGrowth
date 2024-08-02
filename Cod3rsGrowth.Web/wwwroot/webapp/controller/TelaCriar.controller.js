sap.ui.define([
    "./Base",
    "../servico/ClubeServico",
    "../formatter",
], (Base, ClubeServico, Formatter) => {
    "use strict";
    const NUMZERO = 0;
    const FUNDACAO = "fundacao";
    const ESTADIO = "estadio";
    const NOME = "nome";
    const VALUE = "value";
    const ITEMSELECIONADO = "selectedItem";
    const ESTADO = "estado";
    const COBERTURA = "coberturaAntiChuva";
    const SELECTEDINDEX = "selectedIndex"
    return Base.extend("cod3rsgrowth.controller.Criar", {
        clubeServico: ClubeServico,
        formatter: Formatter,
        onInit: function () {
            this.DadosCriacao = [];
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
            var cobertura = TextoSelecionado === "Sim";
            this.DadosCriacao.push({ key: COBERTURA  , value: cobertura});
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