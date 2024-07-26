sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/AggregationLengthEquals"
], (Opa5,Press, PropertyStrictEquals, AggregationLengthEquals) => {
    "use strict"; 

    const dataView = "ListaDeClubes";

    Opa5.createPageObjects({
        naPaginaListaDeClubes: {
            actions: {
                apertarMaisNaPaginação: function() {
                    return this.waitFor({
                        id: "ListaDeClubes",
                        viewName: dataView,
                        actions: new Press(),
                        errorMessage: "Os dados não foram carregados ao clicar 'Mais'"
                    });
                }
            },
            assertions: {
                buscarUrlDaPaginaDeClubes: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "clubes", "Navegou para Lista De Clubes");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                buscarOTituloDaPaginaClubes: function() {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: dataView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Clubes" }),
                        success: function(page) {
                            Opa5.assert.ok(page, "O título da página está certo");
                        },
                        errorMessage: "Não foi possível navegar para a ListaDeClubes ou o título não esta condisente"
                    });
                },
                buscarSeExisteUmaPaginação: function(){
                    return this.waitFor({
                        id: "ListaDeClubes",
                        viewName: dataView,
                        matchers: new AggregationLengthEquals({
							name: "items",
							length: 10
						}),
						success: function () {
							Opa5.assert.ok(true, "A tabela esta exibindo uma lista de 10 items");
						},
						errorMessage: "Os dados não foram carregados"
					});                   
                },
                buscarSeItemsForamAdicionados: function(){
                    return this.waitFor({
                        id: "ListaDeClubes",
                        viewName: dataView,
                        matchers: new AggregationLengthEquals({
							name: "items",
							length: 20
						}),
						success: function () {
							Opa5.assert.ok(true, "Foram adicionados na tabela mais 10 items");
						},
						errorMessage: "Os dados não foram carregados"
					});                   
                },
            }
        }
    });
});