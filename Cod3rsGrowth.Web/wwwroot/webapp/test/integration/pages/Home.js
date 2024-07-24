sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press"
], (Opa5, Press) => {
    "use strict";

    const sNameView = "cod3rsgrowth.view.Home";

    Opa5.createPageObjects({
        NaPaginaClube: {
            actions: {
                aoClicarEmcClubes: function() {
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