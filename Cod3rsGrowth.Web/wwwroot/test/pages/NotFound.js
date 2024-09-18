sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function (Opa5, Press, PropertyStrictEquals) {
    "use strict";

    const dataView = "notFound.NotFound"

    Opa5.createPageObjects({
        naPaginaNotFound: {
            actions: {
                aoClicarEmNavBack: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        viewName: dataView,
                        actions: new Press(),
                        errorMessage: "Não foi possivel encontrar o botão de voltar"
                    });
                },
            },
            assertions: {
                buscarUrlDaPaginaNotFound: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "RotaIncorreta", "Navegou para tela de NotFound");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                buscarTituloDaPaginaNotFound: function(){
                    return this.waitFor({
                        controlType: "sap.m.MessagePage",
                        viewName: dataView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Not Found"}),
                        success: function(page) {
                            Opa5.assert.ok(page, "O título da página está certo");
                        },
                        errorMessage: "Não foi possível navegar para a Not Found ou o título não esta condisente"
                    });                   
                }
            }
        }
    });
});
