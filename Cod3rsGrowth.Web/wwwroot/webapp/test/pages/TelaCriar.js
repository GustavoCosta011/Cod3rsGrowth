sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function (Opa5, Press, PropertyStrictEquals) {
    "use strict";

    const dataView = "TelaCriar"

    Opa5.createPageObjects({
        naPaginaDeCriacao: {
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
                DeveVerificarSeAUrlSeraADaPaginaDeCriação: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "clubes/criar", "Navegou para tela de NotFound");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                DeveVerificarSeOTituloDaPaginaEODeCriacao: function(){
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: dataView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Criar Clube"}),
                        success: function(page) {
                            Opa5.assert.ok(page, "O título da página está certo");
                        },
                        errorMessage: "O título da pagina Criar não esta condisente"
                    });                   
                }
            }
        }
    });
});
