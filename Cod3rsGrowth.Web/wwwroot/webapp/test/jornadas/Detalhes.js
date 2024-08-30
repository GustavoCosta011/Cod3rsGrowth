sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Detalhes"
  ], (opaQUnit) => {
    "use strict";
     
    QUnit.module("Detalhes");
  
    opaQUnit("Deve verificar se a o app foi iniciado  na pagina de Detalhes", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash :"clubes/detalhes/1"});

        // Assert
        Then.naPaginaDeDetalhes.buscarOTituloDaPaginaDeDetalhes();
        Then.naPaginaDeDetalhes.buscarUrlDaPaginaDeDetalhes();
        
    });
    opaQUnit("Deve verificar se a o conteudo da pagina Detalhes foi carregado", function (Given, When, Then) {

        // Assert
        Then.naPaginaDeDetalhes.DeveVerificarONomeDoClube("Atlético Mineiro");
        Then.naPaginaDeDetalhes.DeveVerificarAFundacaoDoClube("25/03/1908");
        Then.naPaginaDeDetalhes.DeveVerificarOEstadioDoClube("Arena MRV");
        Then.naPaginaDeDetalhes.DeveVerificarOEstadoDoClube("Minas Gerais");
        Then.naPaginaDeDetalhes.DeveVerificarOestadoDaCoberturaDaCoberturaAntiChuvaDoClube("Success");

    });

    opaQUnit("Deve verificar se existe uma tabela de elenco com paginação", function (Given, When, Then) {
        // Assert
        Then.naPaginaDeDetalhes.buscarSeExisteUmaPaginação();
    });

    opaQUnit("Deve pressionar a paginação  e conferir o tamanho da lista", function (Given, When, Then) {
        //Act
        When.naPaginaDeDetalhes.apertarMaisNaPaginação();

        // Assert
        Then.naPaginaDeDetalhes.buscarOTamanhoDaLista(11);
    });

    opaQUnit("Deve verificar se o botão de voltar retorna para  a pagina de Clubes", function (Given, When, Then) {

        // Act
        When.naPaginaDeDetalhes.DevePressionarOBotãoNavBack();

        // Assert
        Then.naPaginaListaDeClubes.buscarOTituloDaPaginaClubes();
        Then.naPaginaListaDeClubes.buscarUrlDaPaginaDeClubes();

        Then.iTeardownMyApp();
    });
});