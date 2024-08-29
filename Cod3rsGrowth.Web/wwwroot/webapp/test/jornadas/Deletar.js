sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Detalhes",
    "../pages/TelaCriar"

  ], (opaQUnit) => {
    "use strict";
     
    QUnit.module("Deletar");
  
    opaQUnit("Deve deletar o clube", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash : "clubes/detalhes/3"});

        //Act
        When.naPaginaDeDetalhes.aoClicarNoBotaoDeletar();

        // Assert
        Then.naPaginaDeDetalhes.DeveVerificarMessageBoxDeDeletar("Deseja excluir este clube?");

        //Act
        When.naPaginaDeDetalhes.aoClicarNoBotaoDoMessageBox("Sim");       
    }); 

    opaQUnit("Deve verificar se o clube deixa de existir na tabela", function (Given, When, Then) {
      //Act
      When.naPaginaListaDeClubes.aoInserirFiltroNome("Bahia");

      // Assert
      Then.naPaginaListaDeClubes.buscarOTamanhoDaLista(0);
      
      Then.iTeardownMyApp();
    }); 
});