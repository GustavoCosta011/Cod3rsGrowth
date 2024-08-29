sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaDeClubes",
    "../pages/NotFound"
  ], (opaQUnit) => {
    "use strict";

    QUnit.module("ListaDeClubes");
  
    opaQUnit("Deve navegar para pagina de Clubes e verificar a paginação", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({ hash: "clubes"});

        //Act
        Then.naPaginaListaDeClubes.buscarSeExisteUmaPaginação();
        When.naPaginaListaDeClubes.apertarMaisNaPaginação();

        // Assert
        Then.naPaginaListaDeClubes.buscarOTamanhoDaLista(20);
        
    });

    opaQUnit("Deve verificar se a lista foi filtrada por nome", function (Given, When, Then) {
        //Act
        When.naPaginaListaDeClubes.aoInserirFiltroNome("Flamengo");
        //Assert
        Then.naPaginaListaDeClubes.verificarSeFoiRetornadaListaComFiltroNome("Flamengo");
        Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se a lista foi filtrada por estado", function(Given, When, Then){
        // Arrange
        Given.iStartMyApp({ hash: "clubes"});

        //Act
        When.naPaginaListaDeClubes.aoInserirFiltroEstado("Rio de Janeiro");

        //Assert
        Then.naPaginaListaDeClubes.verificarSeFoiRetornadaListaComFiltroEstado("Rio de Janeiro");

        Then.iTeardownMyApp();      
    });

    opaQUnit("Deve verificar se a lista foi filtrada por Data", function(Given, When, Then){
      // Arrange
      Given.iStartMyApp({ hash: "clubes"});

      //Act
      When.naPaginaListaDeClubes.aoInserirFiltroData("25/03/1924 - 02/01/1931");

      //Assert
      Then.naPaginaListaDeClubes.verificarSeFoiRetornadaListaComFiltroFundacao("03/25/1924","01/02/1931");

      Then.iTeardownMyApp();      
    });
});