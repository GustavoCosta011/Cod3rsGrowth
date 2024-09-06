sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/detalhes"
  ], (opaQUnit) => {
    "use strict";

    QUnit.module("CriarJogador");
  
    opaQUnit("Deve Iniciar na pagina de criação", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash : "clubes/detalhes/1"});

        // Assert
        Then.naPaginaDeDetalhes.buscarUrlDaPaginaDeDetalhes("clubes/detalhes/1");
        When.naPaginaDeDetalhes.aoClicarEmCriar();
        Then.naPaginaDeDetalhes.DeveVerificarOTituloDoModalDeCriacao("Formulario - Jogador");

    });

    opaQUnit("Deve Verificar  se as mensagens de erro aparecem nos inputs", function (Given, When, Then) {
      //Act 
      When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Salvar");

      // Assert
      Then.naPaginaDeDetalhes.DeveVerificarMensagemDeErroParaNome();
      Then.naPaginaDeDetalhes.DeveVerificarMensagemDeErroParaData();
      Then.naPaginaDeDetalhes.DeveVerificarMensagemDeErroParaAltura();
      Then.naPaginaDeDetalhes.DeveVerificarMensagemDeErroParaClube();
      Then.naPaginaDeDetalhes.DeveVerificarMensagemDeErroParaPeso();


      Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro do nome aparece na Caixa de Dialogo", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/detalhes/1"});

      //Act 
      When.naPaginaDeDetalhes.aoClicarEmCriar();
      When.naPaginaDeDetalhes.aoInserirNome("G");
      When.naPaginaDeDetalhes.aoInserirData("17/01/2004");
      When.naPaginaDeDetalhes.aoInserirAltura("1,72")
      When.naPaginaDeDetalhes.aoSelecionarClube("Flamengo")
      When.naPaginaDeDetalhes.aoInserirPeso("70")
      When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Salvar");

      // Assert
      Then.naPaginaDeDetalhes.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("O nome deve ter entre 3 e 60 caracteres!");

      Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro da Data de Nascimento aparece na Caixa de Dialogo", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/detalhes/1"});

      //Act 
      When.naPaginaDeDetalhes.aoClicarEmCriar();
      When.naPaginaDeDetalhes.aoInserirNome("Gustavo");
      When.naPaginaDeDetalhes.aoInserirData("18/01/2025");
      When.naPaginaDeDetalhes.aoInserirAltura("1,72")
      When.naPaginaDeDetalhes.aoSelecionarClube("Flamengo")
      When.naPaginaDeDetalhes.aoInserirPeso("70")
      When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Salvar");

      // Assert
      Then.naPaginaDeDetalhes.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("A data deve ser anterior ou igual à data atual!");

      Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o MessageToast aparece na tela", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/detalhes/1"});

      //Act 
      When.naPaginaDeDetalhes.aoClicarEmCriar();
      When.naPaginaDeDetalhes.aoInserirNome("Gustavo");
      When.naPaginaDeDetalhes.aoInserirData("17/01/2004");
      When.naPaginaDeDetalhes.aoInserirAltura("1,72")
      When.naPaginaDeDetalhes.aoSelecionarClube("Flamengo")
      When.naPaginaDeDetalhes.aoInserirPeso("70")
      When.naPaginaDeDetalhes.aoClicarNoBotaoDoDialogo("Salvar");

      // Assert
      Then.naPaginaDeDetalhes.DeveVerificarMessageToast("Jogador criado com sucesso!");

      Then.iTeardownMyApp();
    });
});