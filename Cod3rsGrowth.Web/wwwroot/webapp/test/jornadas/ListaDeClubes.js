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
        
    });
    opaQUnit("Deve varificar se a lista foi filtrada por nome", function (Given, When, Then) {
      //Act
      When.naPaginaListaDeClubes.aoInserirFiltroNome("Flamengo");
      //Assert
      Then.naPaginaListaDeClubes.varificarSeFoiRetornadaListaComFiltroNome("Flamengo");

      Then.iTeardownMyApp();
    });


});