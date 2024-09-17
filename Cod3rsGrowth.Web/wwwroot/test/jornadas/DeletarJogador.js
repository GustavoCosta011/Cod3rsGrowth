sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Detalhes"

  ], (opaQUnit) => {
    "use strict";
     
    QUnit.module("DeletarJogador");
  
    opaQUnit("Deve deletar o jogador", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash : "clubes/detalhes/9"});

        //Act
        When.naPaginaDeDetalhes.aoClicarNoBotaoDeletarJogador();

        // Assert
        Then.naPaginaDeDetalhes.DeveVerificarMessageBoxDeDeletar("Deseja excluir este jogador?");

        //Act
        When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Sim");       
    });

    opaQUnit("Deve verificar se a lista diminuiu", function (Given, When, Then) {
      // Assert
      Then.naPaginaDeDetalhes.buscarOTamanhoDaLista(10);     

      Then.iTeardownMyApp();
    });

});