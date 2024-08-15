sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/actions/EnterText"
], function (Opa5, Press, PropertyStrictEquals, Properties, EnterText) {
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
                aoClicarEmSalvarClube: function() {
                    return this.waitFor({
                        id: "BotaoSalvar",
                        viewName: dataView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão 'Salvar'"
                    });
                },
                aoInserirNome: function(Nome) {
                    return this.waitFor({
                        id: "InputNome",
                        viewName: dataView,
                        actions: new EnterText({ text: Nome }),
                        errorMessage: "Não foi possível encontrar o campo 'Nome'"
                    });
                },
                aoInserirFundacao: function(Data) {
                    return this.waitFor({
                        id: "CalendarioCriar",
                        viewName: dataView,
                        actions: new EnterText({ text: Data }),
                        errorMessage: "Não foi possível encontrar o campo 'Fundação'"
                    });
                },
                aoInserirEstadio: function(Estadio) {
                    return this.waitFor({
                        id: "InputEstadio",
                        viewName: dataView,
                        actions: new EnterText({ text: Estadio }),
                        errorMessage: "Não foi possível encontrar o campo 'Estádio'"
                    });
                },
                aoSelecionarEstado: function(Estado) {
                    return this.waitFor({
                        id: "EstadoCriacao",
                        viewName: dataView,
                        actions: new EnterText({ text: Estado }),
                        errorMessage: "Não foi possível selecionar o estado no ComboBox"
                    });
                },
                aoSelecionarCoberturaAntiChuva: function(Cobertura) {
                    var Id = Cobertura === "Sim" ? "BotaoSim" : "BotaoNao";
                    return this.waitFor({
                        id: Id,
                        viewName: dataView,
                        actions: new Press(),
                        errorMessage: "Não foi possível selecionar a opção de cobertura anti-chuva"
                    });
                }                                                                                               
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
                },
                DeveVerificarMensagemDeErroParaNome: function () {
                    return this.waitFor({
                        id: "InputNome",
                        viewName: dataView,
                        matchers: new PropertyStrictEquals({
                            name: "valueStateText",
                            value: "Campo 'Nome' precisa ser preenchido."
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro para 'Nome' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Nome' não está correta."
                    });
                },
                DeveVerificarMensagemDeErroParaFundacao: function () {
                    return this.waitFor({
                        id: "CalendarioCriar",
                        viewName: dataView,
                        matchers: new PropertyStrictEquals({
                            name: "valueStateText",
                            value: "Campo 'Data de Fundação' precisa ser preenchido."
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro para 'Fundação' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Fundação' não está correta."
                    });
                },
                DeveVerificarMensagemDeErroParaEstadio: function () {
                    return this.waitFor({
                        id: "InputEstadio",
                        viewName: dataView,
                        matchers: new PropertyStrictEquals({
                            name: "valueStateText",
                            value: "Campo 'Estádio' precisa ser preenchido."
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro para 'Estádio' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Estádio' não está correta."
                    });
                },
                DeveVerificarMensagemDeErroParaEstado: function () {
                    return this.waitFor({
                        id: "EstadoCriacao",
                        viewName: dataView,
                        matchers: new PropertyStrictEquals({
                            name: "valueStateText",
                            value: "Campo 'Estado' precisa ser preenchido."
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro para 'Estado' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Estado' não está correta."
                    });
                },
                DeveVerificarMensagemDeErroParaCobertura: function () {
                    return this.waitFor({
                        controlType: "sap.m.RadioButton",
                        viewName: dataView,
                        matchers: new Properties({ selected: false }),
                        success: function () {
                            Opa5.assert.ok(true, "O valor de 'Cobertura' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Cobertura' não está correta."
                    });
                },
                DeveVerificarMessageToast: function (Mensagem) {
                    return this.waitFor({
                        pollingInterval: 100,
                        check: function () {
                            var MessageToastControle = sap.ui.test.Opa5.getJQuery()(".sapMMessageToast");
                            return MessageToastControle.filter(function (i, elemento) {
                                return elemento.textContent === Mensagem;
                            }).length > 0;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "MessageToast foi exibido com o texto: " + Mensagem);
                        },
                        errorMessage: "MessageToast com o texto '" + Mensagem + "' não foi encontrado."
                    });
                } 
            }
        }
    });
});
