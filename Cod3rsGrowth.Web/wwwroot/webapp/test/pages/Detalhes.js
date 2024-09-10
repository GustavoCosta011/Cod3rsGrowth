sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Ancestor",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/actions/EnterText"

], (Opa5, Properties, PropertyStrictEquals, Press, Ancestor, AggregationLengthEquals, EnterText) => {
    "use strict";

    const nomeDaView = "Detalhes";
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
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possivel encontrar o botão de voltar"
                    });
                },  
                aoClicarNoBotaoDeletar: function(){
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        viewName: nomeDaView,
                        matchers: new Properties({text : "Deletar"}),
                        actions: new Press(),
                        errorMessage: "Não foi possivel encontrar o botão de voltar"
                    });
                },
                aoClicarEmCriar: function(){
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        viewName: nomeDaView,
                        matchers: new Properties({text : "Criar"}),
                        actions: new Press(),
                        errorMessage: "Não foi possivel encontrar o botão de voltar"
                    });
                },
                aoClicarNoBotaoDoDialogo: function (textoButao) {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        matchers: [
                            new Properties({ text: textoButao }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        actions: new Press(),
                        success: function () {
                            Opa5.assert.ok(true, `Sucesso ao fechar MessageBox ao clicar no botao '${textoButao}'.`);
                        },
                        errorMessage: "Falha ao fechar MessageBox ao clicar no botao Ok."
                    });
                },

                apertarMaisNaPaginação: function() {
                    return this.waitFor({
                        controlType: "sap.m.Table",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Os dados não foram carregados ao clicar 'Mais'"
                    });
                },
                aoInserirNome: function(Nome) {
                    return this.waitFor({
                        id: "InputNomeJogador",
                        viewName: nomeDaView,
                        matchers: [
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        actions: new EnterText({ text: Nome }),
                        errorMessage: "Não foi possível encontrar o campo 'Nome'"
                    });
                },
                aoInserirData: function(Data) {
                    return this.waitFor({
                        id: "CalendarioCriarJogador",
                        viewName: nomeDaView,
                        matchers: [
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        actions: new EnterText({ text: Data }),
                        errorMessage: "Não foi possível encontrar o campo 'Data de Nascimento'"
                    });
                },
                aoInserirAltura: function(altura) {
                    return this.waitFor({
                        id: "InputAltura",
                        viewName: nomeDaView,
                        matchers: [
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        actions: new EnterText({ text: altura }),
                        errorMessage: "Não foi possível encontrar o campo 'Altura'"
                    });
                },
                aoInserirPeso: function(peso) {
                    return this.waitFor({
                        id: "InputPeso",
                        viewName: nomeDaView,
                        matchers: [
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        actions: new EnterText({ text: peso }),
                        errorMessage: "Não foi possível encontrar o campo 'Peso'"
                    });
                },
                aoSelecionarClube: function(clube) {
                    return this.waitFor({
                        id: "ClubeCriacaoJogador",
                        viewName: nomeDaView,
                        matchers: [
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        actions: new EnterText({ text: clube }),
                        errorMessage: "Não foi possível selecionar o clube no ComboBox"
                    });
                },
                aoClicarNoBotaoDeEditar: function () {
                    return this.waitFor({
                        controlType: "sap.m.ColumnListItem",
                        viewName: nomeDaView,
                        success: (a) => {
                            a[0].fireDetailPress()
                            Opa5.assert.ok(true, "Botao de editar encontrado")},
                        errorMessage: "Item da lista de jogadores não encontrado."
                    });
                },
                aoClicarNoBotaoDeletarJogador: function(){
                    return this.waitFor({
                        controlType: "sap.m.ColumnListItem",
                        viewName: nomeDaView,
                        success: (a) => {
                            a[0].fireDelete()
                            Opa5.assert.ok(true, "Botao de editar encontrado")},
                        errorMessage: "Item da lista de jogadores não encontrado."
                    });
                }
                
                // aoClicarNoBotaoDeletarJogador: function(){
                //     return this.waitFor({
                //         controlType: "sap.ui.core.Icon",
                //         viewName: nomeDaView,
                //         matchers: new PropertyStrictEquals({
                //             name: "src", 
                //             value: "sap-icon://decline"
                //         }),
                //         success: (a) => {
                //             debugger
                //             a[0].firePress()
                //             Opa5.assert.ok(true, "Botao de editar encontrado")},
                //         errorMessage: "Item da lista de jogadores não encontrado."
                //     });
                // }
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
                        viewName: nomeDaView,
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
                        viewName: nomeDaView,
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
                        viewName: nomeDaView,
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
                        viewName: nomeDaView,
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
                        viewName: nomeDaView,
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
                        viewName: nomeDaView,
                        matchers: new Properties({ title: COBERTURAANTICHUVA , state: ValorDoEstado }),
                        success: function () {
                            Opa5.assert.ok(true, "O valor do estado do campo boleano esta correto.");
                        },
                        errorMessage: "O valor do estado do campo boleano esta incorreto."
                    });
                },

                DeveVerificarMessageBoxDeDeletar: function (mensagemEsperada){
                    return this.waitFor({
                        controlType: "sap.m.Dialog",
                        matchers: new PropertyStrictEquals({
                            name: "title",
                            value: "Confirme"
                        }),
                        success: function(CaixaDeDialogo) {
                            Opa5.assert.ok(CaixaDeDialogo.length, "Caixa de diálogo de erro foi exibida.");
                
                            var dialogo = CaixaDeDialogo[0];
                            var conteudo = dialogo.getContent()[0];
                            var texto = conteudo.getText();
                            Opa5.assert.strictEqual(texto, mensagemEsperada, "Mensagem de erro está correta.");
                        },
                        errorMessage: "Caixa de diálogo de erro não foi exibida corretamente."
                    });
                },

                buscarSeExisteUmaPaginação: function(){
                    return this.waitFor({
                        id: "Elenco",
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
							name: "items",
							length: 10
						}),
						success: function () {
							Opa5.assert.ok(true, "A tabela esta exibindo um Elenco de 10 jogadores");
						},
						errorMessage: "Os dados não foram carregados"
					});                   
                },

                buscarOTamanhoDaLista: function(tamanho){
                    return this.waitFor({
                        controlType:"sap.m.Table",
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
							name: "items",
							length: tamanho
						}),
						success: function () {
							Opa5.assert.ok(true, "Foram adicionados na tabela mais 1 items");
						},
						errorMessage: "Os dados não foram carregados"
					});                   
                },

                DeveVerificarOTituloDoModalDeCriacao: function (){
                    return this.waitFor({
                        controlType: "sap.m.Dialog",
                        matchers: new PropertyStrictEquals({
                            name: "title",
                            value: "Formulario - Jogador"
                        }),
                        success: function(CaixaDeDialogo) {
                            Opa5.assert.ok(CaixaDeDialogo.length, "Caixa de diálogo de erro foi exibida.");
                        },
                        errorMessage: "Caixa de diálogo de erro não foi exibida corretamente."
                    });
                },
                DeveVerificarMensagemDeErroParaNome: function () {
                    return this.waitFor({
                        id: "InputNomeJogador",
                        viewName: nomeDaView,
                        matchers:[ 
                            new PropertyStrictEquals({
                                name: "valueStateText",
                                value: "Campo 'Nome' precisa ser preenchido."
                            }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro para 'Nome' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Nome' não está correta."
                    });
                },
                DeveVerificarMensagemDeErroParaData: function () {
                    return this.waitFor({
                        id: "CalendarioCriarJogador",
                        viewName: nomeDaView,
                        matchers: [
                            new PropertyStrictEquals({
                                name: "valueStateText",
                                value: "Campo 'Data de Nascimento' precisa ser preenchido."
                            }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro para 'Data de Nascimento' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Data de Nascimento' não está correta."
                    });
                },
                DeveVerificarMensagemDeErroParaAltura: function () {
                    return this.waitFor({
                        id: "InputAltura",
                        viewName: nomeDaView,
                        matchers: [
                            new PropertyStrictEquals({
                                name: "valueStateText",
                                value: "Campo 'Altura' precisa ser preenchido."
                            }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro para 'Altura' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Altura' não está correta."
                    });
                },
                DeveVerificarMensagemDeErroParaPeso: function () {
                    return this.waitFor({
                        id: "InputPeso",
                        viewName: nomeDaView,
                        matchers: [
                            new PropertyStrictEquals({
                                name: "valueStateText",
                                value: "Campo 'Peso' precisa ser preenchido."
                            }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro para 'Peso' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Peso' não está correta."
                    });
                },
                DeveVerificarMensagemDeErroParaClube: function () {
                    return this.waitFor({
                        id: "ClubeCriacaoJogador",
                        viewName: nomeDaView,
                        matchers: [
                            new PropertyStrictEquals({
                            name: "valueStateText",
                            value: "Campo 'Clube' precisa ser preenchido."
                            }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro para 'Clube' está correta.");
                        },
                        errorMessage: "A mensagem de erro para 'Clube' não está correta."
                    });
                },
                DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo: function(mensagemEsperada) {
                    return this.waitFor({
                        controlType: "sap.m.Dialog",
                        matchers: new PropertyStrictEquals({
                            name: "title",
                            value: "Erro"
                        }),
                        success: function(CaixaDeDialogo) {
                            Opa5.assert.ok(CaixaDeDialogo.length, "Caixa de diálogo de erro foi exibida.");
                
                            var dialogo = CaixaDeDialogo[0];
                            var vbox = dialogo.getContent()[0];
                            var conteudo = vbox.getItems()[0]
                            var texto = conteudo.getText();
                            Opa5.assert.strictEqual(texto, mensagemEsperada, "Mensagem de erro está correta.");
                
                            var detalhes = vbox.getItems()[1]; 
                            var textoDetalhes = detalhes.getText();
                            Opa5.assert.ok(textoDetalhes.length > 0, "Detalhes do erro estão presentes.");
                        },
                        errorMessage: "Caixa de diálogo de erro não foi exibida corretamente."
                    });
                },
                deveVerificarMessageToast: function (Mensagem) {
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
                },
                deveVerificarSeONomeFoiCarregado: function (Nome) {
                    return this.waitFor({
                        id : "InputNomeJogador",
                        viewName: nomeDaView,
                        matchers: [
                            new Properties({ value: Nome }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "O campo nome foi preenchido corretamente.");
                        },
                        errorMessage: "O campo não foi preenchido corretamente."
                    });
                },
                deveVerificarSeADataFoiCarregada: function (Data) {
                    return this.waitFor({
                        controlType: "sap.m.DatePicker",
                        viewName: nomeDaView,
                        matchers: [
                            new Properties({value: Data }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "O campo data de nascimneto foi preenchido corretamente.");
                        },
                        errorMessage: "O campo foi não preenchido corretamente."
                    });
                },

                deveVerificarSeAAlturaFoiCarregada: function (altura) {
                    return this.waitFor({
                        id : "InputAltura",
                        viewName: nomeDaView,
                        matchers: [
                            new Properties({ value: altura }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "O campo altura foi preenchido corretamente.");
                        },
                        errorMessage: "O campo não foi preenchido corretamente."
                    });
                },

                deveVerificarSeOPesoFoiCarregada: function (peso) {
                    return this.waitFor({
                        id : "InputPeso",
                        viewName: nomeDaView,
                        matchers: [
                            new Properties({ value: peso }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "O campo peso foi preenchido corretamente.");
                        },
                        errorMessage: "O campo não foi preenchido corretamente."
                    });
                },

                deveVerificarSeOClubeFoiCarregado: function (clube) {
                    return this.waitFor({
                        id : "ClubeCriacaoJogador",
                        viewName: nomeDaView,
                        matchers: [
                            new Properties({ value : clube }),
                            new Ancestor(Opa5.getContext().dialog, false)
                        ],
                        success: function () {
                            Opa5.assert.ok(true, "O campo clube foi preenchido corretamente.");
                        },
                        errorMessage: "O campo não foi preenchido corretamente."
                    });
                }
            }
        }
    });
});