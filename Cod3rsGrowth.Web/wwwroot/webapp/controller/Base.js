sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent"
], function(Controller, History, UIComponent) {
	"use strict";
    const MENOSUM = -1
    const HOME = "Home"

    return Controller.extend("cod3rsgrowth.controller.Base", {
        getRouter: function () {
            return UIComponent.getRouterFor(this);
        },
        onNavBack() {
            var oHistory = History.getInstance();
            var sPreviousHash = oHistory.getPreviousHash();

            if (sPreviousHash !== undefined) {
            window.history.go(MENOSUM);
            } else {
            const oRouter = this.getRouter();
            oRouter.navTo(HOME, {}, true);
            }
        }
    });
});