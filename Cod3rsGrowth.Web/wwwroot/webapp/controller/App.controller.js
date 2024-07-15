sap.ui.define([
    "./Base",
    "sap/ui/model/resource/ResourceModel"
], (Base,ResourceModel) => {
    "use strict";

    return Base.extend("cod3rsgrowth.controller.App", {

        onInit() {
            const i18nModelo = new ResourceModel({ bundleName: "cod3rsgrowth.i18n.i18n" });
            this.getView().setModel(i18nModelo, "i18n");
        }
        
    });
});