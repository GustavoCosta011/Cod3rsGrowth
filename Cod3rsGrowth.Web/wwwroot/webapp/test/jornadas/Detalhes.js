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
        Then.naPaginadedetalhes.buscarOTituloDaPaginaDeDetalhes();
        Then.naPaginadedetalhes.buscarUrlDaPaginaDeDetalhes();
        
    });
    opaQUnit("Deve verificar se a o conteudo da pagina Detalhes foi carregado", function (Given, When, Then) {

        // Assert
        Then.naPaginadedetalhes.DeveVerificarONomeDoClube("Atlético Mineiro");
        Then.naPaginadedetalhes.DeveVerificarAFundacaoDoClube("25/03/1908");
        Then.naPaginadedetalhes.DeveVerificarOEstadioDoClube("Arena MRV");
        Then.naPaginadedetalhes.DeveVerificarOEstadoDoClube("Minas Gerais");
        Then.naPaginadedetalhes.DeveVerificarOestadoDaCoberturaDaCoberturaAntiChuvaDoClube("Success");
        
        Then.iTeardownMyApp();
    });
});