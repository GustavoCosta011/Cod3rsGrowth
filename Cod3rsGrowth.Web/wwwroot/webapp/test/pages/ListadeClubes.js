sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"
], (Opa5, PropertyStrictEquals) => {
    "use strict";

    const nomeDaView = "ListaDeClubes";

    Opa5.createPageObjects({
        naPaginaListaDeClubes: {
            actions: { },
            assertions: {
                verificarUrlDaPaginaDeClubes: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "clubes", "Navegou para Lista De Clubes");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                verificarOTituloDaPagina: function() {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: nomeDaView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Clubes" }),
                        success: function(page) {
                            Opa5.assert.ok(page, "O título da página está certo");
                        },
                        errorMessage: "Não foi possível navegar para a ListaDeClubes ou o título não esta condisente"
                    });
                }
            }
        }
    });
});