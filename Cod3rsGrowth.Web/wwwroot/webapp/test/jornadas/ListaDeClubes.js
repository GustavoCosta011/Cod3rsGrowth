sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListadeClubes",
    "../pages/NotFound"
  ], (opaQUnit) => {
    "use strict";

    QUnit.module("ListaDeClubes");
  
    opaQUnit("Deve navegar para pagina de Clubes e verificar a paginação", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp();

        //Parar que possa ser excutado os testes na pagina de lista
        When.naPaginaHome.aoClicarEmClubes();

        //Act
        Then.naPaginaListaDeClubes.buscarSeExisteUmaPaginação();
        When.naPaginaListaDeClubes.apertarMaisNaPaginação();

        // Assert
        Then.naPaginaListaDeClubes.buscarSeItemsForamAdicionados();
        
        Then.iTeardownMyApp();
    });
});