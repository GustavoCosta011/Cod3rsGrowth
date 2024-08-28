sap.ui.define([
	"./Base",
    "../servico/ClubeServico",
    "../formatter",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel"
], function (Base, ClubeServico, Formatter, MessageBox,JSONModel) {
	"use strict";

    const CLUBES = "clubes";
    const DETALHES = "detalhes";
    const TEXTO_ERRO_FETCH_CLUBE = "Clube não encontrado";
    const ARGUMENTS = "arguments";
    const DESTINO_VOLTAR = 'clubes';
    const TITULO_ERRO = "Erro";
    const DESTINO_EDITAR = 'editar';

	return Base.extend("cod3rsgrowth.webapp.controller.Detalhes", {
        formatter: Formatter,
        clubeServico : ClubeServico,
        onInit: function () {
            this._vincularRota(DETALHES, this.aoCoincidirRota);
        },
        aoCoincidirRota : function(evento){
            const argumentos = evento.getParameter(ARGUMENTS);
            this.clubeServico.aoBuscarClubePorId(argumentos.idClube)
            .then((clube) => {
                var oModel = new JSONModel(clube);
                this.getView().setModel(oModel, CLUBES);
            })
            .catch((error) => {
                MessageBox.error(TEXTO_ERRO_FETCH_CLUBE, {title : TITULO_ERRO});
            });
        },
        aoClivarEmVoltar: function(){
            this.navegarPara(DESTINO_VOLTAR);
        },
        aoClicarEditar: function(){
            this.navegarPara(DESTINO_EDITAR,{ idClube : this.getView().getModel(CLUBES).getData().id})
        }
	});
});