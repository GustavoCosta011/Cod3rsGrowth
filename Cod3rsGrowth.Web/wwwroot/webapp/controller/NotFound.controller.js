sap.ui.define([
   "./Base",
   "sap/m/MessageBox"

 ], function (Base, MessageBox) {
    "use strict";
    const DESTINO_VOLTAR = '';
    const TITULO_ERRO = "Erro";

    return Base.extend("cod3rsgrowth.webapp.controller.NotFound", {
         aoClivarEmVoltar: function(){
            try
            {
               this._navegarPara(DESTINO_VOLTAR);
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
         }
    });
 });