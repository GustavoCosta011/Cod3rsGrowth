sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/resource/ResourceModel"
], (Controller, ResourceModel) => {
    "use strict";

    return Controller.extend("cod3rsgrowth.controller.App", {
        onInit() {
            const oModel = new ResourceModel({ bundleName: "cod3rsgrowth.i18n.i18n" });
            this.getView().setModel(oModel, "i18n");
        }
    });
});