sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/detalhes"
  ], (opaQUnit) => {
    "use strict";

    QUnit.module("EditarJogador");
  
    opaQUnit("Deve Iniciar na pagina de edição", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash : "clubes/detalhes/1"});

        // Assert
        Then.naPaginaDeDetalhes.buscarUrlDaPaginaDeDetalhes("clubes/detalhes/1");
        When.naPaginaDeDetalhes.aoClicarNoBotaoDeEditar(0);
        Then.naPaginaDeDetalhes.DeveVerificarOTituloDoModalDeCriacao("Formulario - Jogador");

    });

    opaQUnit("Deve verificar se inputs foram carregados", function (Given, When, Then) {
        Then.naPaginaDeDetalhes.deveVerificarSeONomeFoiCarregado("Everson");
        Then.naPaginaDeDetalhes.deveVerificarSeADataFoiCarregada("22/07/1988");
        Then.naPaginaDeDetalhes.deveVerificarSeAAlturaFoiCarregada("1,92");
        Then.naPaginaDeDetalhes.deveVerificarSeOPesoFoiCarregada("82");
        Then.naPaginaDeDetalhes.deveVerificarSeOClubeFoiCarregado("Atlético Mineiro");  
        
        Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro do nome aparece na Caixa de Dialogo", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash : "clubes/detalhes/1"});

        //Act 
        When.naPaginaDeDetalhes.aoClicarNoBotaoDeEditar();
        When.naPaginaDeDetalhes.aoInserirNome("E");
        When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Salvar");
        // Assert
        Then.naPaginaDeDetalhes.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("O nome deve ter entre 3 e 60 caracteres!");
        When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Fechar"); 

        Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro da Data de Nascimento aparece na Caixa de Dialogo", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/detalhes/1"});

      //Act 
      When.naPaginaDeDetalhes.aoClicarNoBotaoDeEditar(0);
      When.naPaginaDeDetalhes.aoInserirData("18/01/2025");
      When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Salvar");

      // Assert
      Then.naPaginaDeDetalhes.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("A data deve ser anterior ou igual à data atual!");
      When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Fechar"); 

      Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o MessageToast aparece na tela", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/detalhes/1"});

      //Act 
      When.naPaginaDeDetalhes.aoClicarNoBotaoDeEditar(0);
      When.naPaginaDeDetalhes.aoInserirNome("Eversin");
      When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Salvar");
      // Assert
      Then.naPaginaDeDetalhes.deveVerificarMessageToast("Jogador editado com sucesso!");

      Then.iTeardownMyApp();
    });
});