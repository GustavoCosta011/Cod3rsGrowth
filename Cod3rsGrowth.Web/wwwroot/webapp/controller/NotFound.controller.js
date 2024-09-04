sap.ui.define([
    "./Base"
 ], function (Base) {
    "use strict";
    const DESTINO_VOLTAR = '';

    return Base.extend("cod3rsgrowth.webapp.controller.NotFound", {
         onInit: function () {
         },
         aoClivarEmVoltar: function(){
            this._navegarPara(DESTINO_VOLTAR);
        }
    });
 });