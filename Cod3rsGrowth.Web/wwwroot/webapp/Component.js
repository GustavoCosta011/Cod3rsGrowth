sap.ui.define([
    "sap/ui/core/UIComponent"
], (UIComponent) => {
    "use strict";

    return UIComponent.extend("cod3rsgrowth.Component", {
        metadata : {
            interfaces : ["sap.ui.core.IAsyncContentCreation"],
            rootView: {"id": "app", "type": "XML", "viewName": "cod3rsgrowth.view.App"}
        }
    });
});