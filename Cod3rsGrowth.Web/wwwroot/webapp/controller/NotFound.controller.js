sap.ui.define([
    "sap/ui/core/mvc/Controller"
 ], function (Controller) {
    "use strict";
    return Controller.extend("cod3rsgrowth.controller.NotFound", {
         onInit: function () {
         },

         onNavBack() {
            const oHistory = History.getInstance();
            const sPreviousHash = oHistory.getPreviousHash();

            if (sPreviousHash !== undefined) {
               window.history.go(-1);
            } else {
               const oRouter = this.getOwnerComponent().getRouter();
               oRouter.navTo("home", {}, true);
            }
         }
    });
 });