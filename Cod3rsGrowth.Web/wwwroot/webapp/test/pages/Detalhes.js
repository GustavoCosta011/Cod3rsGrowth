sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/actions/Press"

], (Opa5, Properties, PropertyStrictEquals, Press) => {
    "use strict";

    const dataView = "Detalhes";
    const FUNDAÇÂO = "Fundação";
    const ESTADIO = "Estadio";
    const ESTADO = "Estado";
    const COBERTURAANTICHUVA = "Cobertura Anti-chuva";

    Opa5.createPageObjects({
        naPaginaDeDetalhes: {
            actions: {
                DevePressionarOBotãoNavBack: function(){
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        viewName: dataView,
                        actions: new Press(),
                        errorMessage: "Não foi possivel encontrar o botão de voltar"
                    });
                }
            },

            assertions: {
                buscarUrlDaPaginaDeDetalhes: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "clubes/detalhes/1", "Navegou para a pagina detalhes");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                buscarOTituloDaPaginaDeDetalhes: function() {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: dataView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Detalhes" }),
                        success: function(page) {
                            Opa5.assert.ok(page, "O título da página está certo");
                        },
                        errorMessage: "Não foi possível navegar para detalhes ou o título não esta condisente"
                    });
                },
                DeveVerificarONomeDoClube: function (NomeDoClube) {
                    return this.waitFor({
                        controlType: "sap.m.Title",
                        viewName: dataView,
                        matchers: new Properties({ text: NomeDoClube }),
                        success: function () {
                            Opa5.assert.ok(true, "O Nome esperado foi encontrado.");
                        },
                        errorMessage: "Nome inexperado  encontrado."
                    });
                },
                DeveVerificarAFundacaoDoClube: function (fundação) {
                    return this.waitFor({
                        controlType: "sap.m.ObjectStatus",
                        viewName: dataView,
                        matchers: new Properties({ title: FUNDAÇÂO , text: fundação }),
                        success: function () {
                            Opa5.assert.ok(true, "A fundação esperada foi encontrada.");
                        },
                        errorMessage: "Fundação inexperada encontrada."
                    });
                },
                DeveVerificarOEstadioDoClube: function (Estadio) {
                    return this.waitFor({
                        controlType: "sap.m.ObjectStatus",
                        viewName: dataView,
                        matchers: new Properties({ title: ESTADIO , text: Estadio }),
                        success: function () {
                            Opa5.assert.ok(true, "O estadio esperado foi encontrado.");
                        },
                        errorMessage: "Estadio inexperada encontrada."
                    });
                },
                DeveVerificarOEstadoDoClube: function (Estado) {
                    return this.waitFor({
                        controlType: "sap.m.ObjectStatus",
                        viewName: dataView,
                        matchers: new Properties({ title: ESTADO , text: Estado }),
                        success: function () {
                            Opa5.assert.ok(true, "O estado esperado foi encontrado.");
                        },
                        errorMessage: "Estado inexperada encontrada."
                    });
                },
                DeveVerificarOestadoDaCoberturaDaCoberturaAntiChuvaDoClube: function (ValorDoEstado) {
                    return this.waitFor({
                        controlType: "sap.m.ObjectStatus",
                        viewName: dataView,
                        matchers: new Properties({ title: COBERTURAANTICHUVA , state: ValorDoEstado }),
                        success: function () {
                            Opa5.assert.ok(true, "O valor do estado do campo boleano esta correto.");
                        },
                        errorMessage: "O valor do estado do campo boleano esta incorreto."
                    });
                },
            }
        }
    });
});