sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/resource/ResourceModel"
], (Controller, ResourceModel) => {
    "use strict";

    return Controller.extend("Cod3rsGrowth.controller.App", {
        onInit() {
            const oModel = new ResourceModel({ bundleName: "Cod3rsGrowth.i18n.i18n" });
            this.getView().setModel(oModel, "i18n");
        }
    });
});