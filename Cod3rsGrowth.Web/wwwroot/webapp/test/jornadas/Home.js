sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaDeClubes",
    "../pages/NotFound"
  ], (opaQUnit) => {
    "use strict";
     
    QUnit.module("Home");
  
    opaQUnit("Deve navegar para a pagina da lista de clubes", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp();

        // Act  
        When.naPaginaHome.aoClicarEmClubes();

        // Assert
        Then.naPaginaListaDeClubes.buscarOTituloDaPaginaClubes();
        Then.naPaginaListaDeClubes.buscarUrlDaPaginaDeClubes();
        
        Then.iTeardownMyApp();
    });
});