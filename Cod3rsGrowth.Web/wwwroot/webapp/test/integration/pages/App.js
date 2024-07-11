sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/Properties"
], (Opa5, Properties) => {
    "use strict";

    const sNameView = "Cod3rsGrowth.view.App";

    Opa5.createPageObjects({
        onTheAppPage: {
            actions: {},
            assertions: {
                iShouldSeeExpectedText() {
                    return this.waitFor({
                        id: "textoOM",
                        viewName: sNameView,
                        matchers: new Properties({ text: "Olá Mundo!" }),
                        success() {
                            Opa5.assert.ok(true, "Texto esperado!");
                        },
                        errorMessage: "O texto não é o esperado"
                    });
                }
            }
        }
    });
});