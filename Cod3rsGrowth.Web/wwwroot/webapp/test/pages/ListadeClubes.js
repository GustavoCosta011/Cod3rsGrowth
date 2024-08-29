sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/AggregationContainsPropertyEqual"

], (Opa5,Press, EnterText, PropertyStrictEquals, AggregationLengthEquals, AggregationContainsPropertyEqual) => {
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
                },
                aoInserirFiltroNome: function(InputNome) {
                    return this.waitFor({
                        id: "InputNome",
                        viewName: dataView,
                        actions: new EnterText({ text: InputNome }),
                        errorMessage: "Campo de busca para filtrar por nome não encontrado."
                    });
                },
                aoInserirFiltroEstado: function(estado){
                    return this.waitFor({
                        id: "ComboBoxEstados",
                        viewName: dataView,
                        actions: new EnterText({text : estado}),
                        errorMessage: "Campo de busca ComboBoxEstado não encontrado."
                    })
                },
                aoInserirFiltroData: function(dataRange){
                     return this.waitFor({
                        id: "calendario",
                        viewName: dataView,
                        actions: new EnterText({text : dataRange}),
                        errorMessage: "Campo de busca fundação não encontrado."
                     })
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
                buscarOTamanhoDaLista: function(tamanho){
                    return this.waitFor({
                        controlType:"sap.m.Table",
                        viewName: dataView,
                        matchers: new AggregationLengthEquals({
							name: "items",
							length: tamanho
						}),
						success: function () {
							Opa5.assert.ok(true, "Foram adicionados na tabela mais 8 items");
						},
						errorMessage: "Os dados não foram carregados"
					});                   
                },
                verificarSeFoiRetornadaListaComFiltroNome: function(filtroNome) {
                    return this.waitFor({
                        id: "ListaDeClubes",
                        viewName: dataView,
                        success: function(oList) {
                            var aItems = oList.getItems();
                            var bFound = aItems.some(function(oItem) {
                                var oContext = oItem.getBindingContext();
                                if (oContext) {
                                    var sNome = oContext.getProperty("nome");
                                    return sNome.includes(filtroNome);
                                }
                                return false;
                            });

                            Opa5.assert.ok(bFound, "A lista contém o nome: " + filtroNome);
                        },
                        errorMessage: "A lista não contém o nome: " + filtroNome
                    });
                },
                verificarSeFoiRetornadaListaComFiltroEstado: function(estado) {
                    return this.waitFor({
                        id: "ListaDeClubes",
                        viewName: dataView,
                        success: function(oList) {
                            var aItems = oList.getItems();
                            var bFound = aItems.some(function(oItem) {
                                var oContext = oItem.getBindingContext();
                                if (oContext) {
                                    var sEstado = oContext.getProperty("estado");
                                    return sEstado.includes(estado);
                                }
                                return false;
                            });

                            Opa5.assert.ok(bFound, "A lista contém o Estado: " + estado);
                        },
                        errorMessage: "A lista não contém o Estado: " + estado
                    });
                },
                verificarSeFoiRetornadaListaComFiltroFundacao: function(DataPiso, DataTeto) {
                    return this.waitFor({
                        id: "ListaDeClubes",
                        viewName: dataView,
                        success: function(oList) {
                            var aItems = oList.getItems();
                            var bFound = aItems.some(function(oItem) {
                                var oContext = oItem.getBindingContext();
                                if (oContext) {
                                    var sData = oContext.getProperty("fundacao");
                                    if (sData) {
                                        var dataFundacao = new Date(sData);
                                        var dataPiso = new Date(DataPiso);
                                        var dataTeto = new Date(DataTeto);
                
                                        console.log("Data Fundação: ", dataFundacao);
                                        console.log("Data Piso: ", dataPiso);
                                        console.log("Data Teto: ", dataTeto);
                
                                        return dataFundacao >= dataPiso && dataFundacao <= dataTeto;
                                    }
                                    console.log("Data da Fundação não encontrada");
                                    return false;
                                }
                                console.log("Contexto não encontrado");
                                return false;
                            });
                            Opa5.assert.ok(bFound, "A lista contém fundações entre: " + DataPiso + " e " + DataTeto);
                        },
                        errorMessage: "A lista não contém fundações entre: " + DataPiso + " e " + DataTeto
                    });                
                }
            }
        }
    });
});