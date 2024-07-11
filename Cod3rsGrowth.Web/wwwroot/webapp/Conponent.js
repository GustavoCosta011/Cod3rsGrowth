sap.ui.define([
    "sap/ui/core/UIComponent"
], (UIComponent) => {
    "use strict";

    return UIComponent.extend("Cod3rsGrowth.Component", {
        metadata : {
            "interfaces": ["sap.ui.core.IAsyncContentCreation"],
            "rootView": { "id": "app", "type": "XML", "viewName": "Cod3rsGrowth.view.App" }
        }
    });
});