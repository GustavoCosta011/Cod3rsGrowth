sap.ui.define([
   "./Base",
   "sap/m/MessageBox"

 ], function (Base, MessageBox) {
    "use strict";
    const DESTINO_VOLTAR = '';
    const TITULO_ERRO = "Erro";

    return Base.extend("cod3rsgrowth.webapp.controller.NotFound", {
         aoClivarEmVoltar: function(){
            this._exibirEspera(async () =>{
               this._navegarPara(DESTINO_VOLTAR);
            });
         }
    });
 });