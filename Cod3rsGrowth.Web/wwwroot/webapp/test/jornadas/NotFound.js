sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaDeClubes",
    "../pages/NotFound"
  ], (opaQUnit) => {
    "use strict";

    QUnit.module("NotFound");
  
    opaQUnit("Deve navegar para a pagina de NotFound", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp();

        // Act  
        When.naPaginaHome.aoNavegarParaPaginaNotFound();

        // Assert
        Then.naPaginaNotFound.buscarUrlDaPaginaNotFound();
        Then.naPaginaNotFound.buscarTituloDaPaginaNotFound();        
    });

    opaQUnit("Deve navegar devolta para a pagina home", function (Given, When, Then) {
        //Act
        When.naPaginaNotFound.aoClicarEmNavBack();
        
        //Assert
        Then.naPaginaHome.buscarUrlDaPaginaHome();
        Then.naPaginaHome.buscarOTituloDaPaginaHome();

        Then.iTeardownMyApp();
    });
});