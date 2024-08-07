sap.ui.define([
    "./Base",
    "sap/ui/model/resource/ResourceModel"
], (Base,ResourceModel) => {
    "use strict";
    const BUNDLENAME = "cod3rsgrowth.i18n.i18n";
    const NAMEMODEL = "i18n";

    return Base.extend("cod3rsgrowth.webapp.controller.App", {

        onInit() {
            const i18nModelo = new ResourceModel({ bundleName: BUNDLENAME });
            this.getView().setModel(i18nModelo, NAMEMODEL);
        }
        
    });
});