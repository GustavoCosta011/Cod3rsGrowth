sap.ui.define([
    "sap/ui/core/UIComponent"
], (UIComponent) => {
    "use strict";

    return UIComponent.extend("cod3rsgrowth.webapp.Component", {
        metadata: {
            interfaces: ["sap.ui.core.IAsyncContentCreation"],
            manifest: "json"
        },

        init() {
            UIComponent.prototype.init.apply(this, arguments);

            var oRouter = this.getRouter();
            if (oRouter) {
                oRouter.initialize();
            } else {
                console.error("Roteador não encontrado.");
            }
        }
    });
});
