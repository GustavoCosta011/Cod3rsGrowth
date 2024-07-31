sap.ui.define([
    "./Base",
    "sap/m/MessageToast"
], (Base, MessageToast) => {
    "use strict";
    const NOME = "nome";
    const VALUE = "value";
    return Base.extend("cod3rsgrowth.controller.Criar", {
        onInit: function () {
            this.DadosInseridos = [];
        },

        aoInserirNome: function(oEvent){
            var nome = oEvent.getParameter(VALUE);
            this.DadosInseridos = this.DadosInseridos.filter(f => f.key !== NOME);
            if (nome) {
                this.DadosInseridos.push({ key: NOME, value: encodeURIComponent(nome)});
            }
        },
        aoSalvarClube: function () {
            var oInputNome = this.byId("InputNome");
            var sNomeValue = oInputNome.getValue();
            var oErrorText = this.byId("NomeErrorText");

            if (sNomeValue === "") {
                oInputNome.setValueState("Error");
                oErrorText.setVisible(true);
            } else {
                oInputNome.setValueState("None");
                oErrorText.setVisible(false);
            }
        }
    });
});