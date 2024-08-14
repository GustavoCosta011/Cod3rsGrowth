sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/TelaCriar"
  ], (opaQUnit) => {
    "use strict";

    QUnit.module("Criar");
  
    opaQUnit("Deve Iniciar para a pagina de criação", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash : "clubes/criar"});

        // Assert
        Then.naPaginaDeCriacao.DeveVerificarSeAUrlSeraADaPaginaDeCriação();
        Then.naPaginaDeCriacao.DeveVerificarSeOTituloDaPaginaEODeCriacao();

        Then.iTeardownMyApp();
    });
});