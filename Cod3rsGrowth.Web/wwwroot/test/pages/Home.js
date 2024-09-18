sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"
], (Opa5, Press, PropertyStrictEquals) => {
    "use strict";

    const dataView = "home.Home";

    Opa5.createPageObjects({
        naPaginaHome: {
            actions: {
                aoClicarEmClubes: function() {
                    return this.waitFor({
                        id: "BotaoIrParaClubes",
                        viewName: dataView,
                        actions: new Press(),
                        errorMessage: "Não foi possivel encontrar o botão 'BotaoIrParaClubes'"
                    });
                },
                aoNavegarParaPaginaNotFound: function(){
                    return this.waitFor({
                        success: function() {
                            sap.ui.test.Opa5.getHashChanger().setHash("RotaIncorreta");
                        }
                    });
                }
            },
            assertions: {
                buscarUrlDaPaginaHome: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "", "Navegou para a pagina Home");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                buscarOTituloDaPaginaHome: function() {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: dataView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Cod3rsGrowth" }),
                        success: function(page) {
                            Opa5.assert.ok(page, "O título da página está certo");
                        },
                        errorMessage: "Não foi possível navegar devolta para Home ou o título não esta condisente"
                    });
                }
            }
        }
    });
});