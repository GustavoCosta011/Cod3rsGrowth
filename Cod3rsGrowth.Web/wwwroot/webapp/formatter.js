sap.ui.define([], function () {
    "use strict";
    return {
        formatEstado: function (estado) {
            var oModel = this.getView().getModel("estadosModel");
            if (oModel) {
                var estados = oModel.getProperty("/estados")
                return estados[estado].sigla;
            }
        }
    };
});
