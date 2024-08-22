sap.ui.define([
	"./Base",
    "../servico/ClubeServico",
    "../formatter",
    "sap/ui/model/json/JSONModel"
], function (Base, ClubeServico, Formatter, JSONModel) {
	"use strict";
    const CLUBES = "clubes"
    const DETALHES = "detalhes"
    const TEXTO_ERRO_FETCH_CLUBE = "Clube não encontrado"

	return Base.extend("cod3rsgrowth.webapp.controller.Detalhes", {
        formatter: Formatter,
        clubeServico : ClubeServico,
        onInit: function () {
            this._vincularRota(DETALHES, this.aoCoincidirRota);
        },
        aoCoincidirRota : function(evento){
            const argumentos = evento.getParameter("arguments");
            this.clubeServico.aoBuscarClubePorId(argumentos.idClube)
            .then((clube) => {
                var oModel = new JSONModel(clube);
                this.getView().setModel(oModel, CLUBES);
            })
            .catch((error) => {
                console.error(TEXTO_ERRO_FETCH_CLUBE, error);
            });
        }
	});
});