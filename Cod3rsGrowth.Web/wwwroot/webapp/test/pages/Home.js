sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press"
], (Opa5, Press) => {
    "use strict";

    const dataView = "Home";

    Opa5.createPageObjects({
        naPaginaHome: {
            actions: {
                aoClicarEmClubes: function() {
                    return this.waitFor({
                        id: "BotaoIrParaClubes",
                        viewName: dataView,
                        actions: new Press(),
                        errorMessage: "Não foi possivel encontrar o botão 'BotaoIrParaClubes'"
                    });
                }
            }
        }
    });
});