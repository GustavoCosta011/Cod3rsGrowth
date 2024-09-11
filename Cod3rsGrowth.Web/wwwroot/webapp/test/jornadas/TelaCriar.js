sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/TelaCriar"
  ], (opaQUnit) => {
    "use strict";

    QUnit.module("Criar");
  
    opaQUnit("Deve Iniciar na pagina de criação", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash : "clubes/criar"});

        // Assert
        Then.naPaginaDeCriacao.DeveVerificarSeAUrlSeraADaPaginaDeCriação("clubes/criar");
        Then.naPaginaDeCriacao.DeveVerificarSeOTituloDaPaginaEODeCriacao("Formulario - Clube");

        Then.iTeardownMyApp();
    });

    opaQUnit("Deve Verificar  se as mensagens de erro aparecem nos inputs", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/criar"});
      //Act 
      When.naPaginaDeCriacao.aoClicarEmSalvarClube();

      // Assert
      Then.naPaginaDeCriacao.DeveVerificarMensagemDeErroParaNome();
      Then.naPaginaDeCriacao.DeveVerificarMensagemDeErroParaFundacao();
      Then.naPaginaDeCriacao.DeveVerificarMensagemDeErroParaEstadio();
      Then.naPaginaDeCriacao.DeveVerificarMensagemDeErroParaEstado();
      Then.naPaginaDeCriacao.DeveVerificarMensagemDeErroParaCobertura();


      Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro do nome aparece na Caixa de Dialogo", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/criar"});

      //Act 
      When.naPaginaDeCriacao.aoInserirNome("G");
      When.naPaginaDeCriacao.aoInserirFundacao("18/01/1976");
      When.naPaginaDeCriacao.aoInserirEstadio("Estadio Olimpico")
      When.naPaginaDeCriacao.aoSelecionarEstado("Goiás")
      When.naPaginaDeCriacao.aoSelecionarCoberturaAntiChuva("Não")
      When.naPaginaDeCriacao.aoClicarEmSalvarClube();

      // Assert
      Then.naPaginaDeCriacao.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("O nome deve ter entre 3 e 60 caracteres!");

      Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro do fundação aparece na Caixa de Dialogo", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/criar"});

      //Act 
      When.naPaginaDeCriacao.aoInserirNome("Goiânia");
      When.naPaginaDeCriacao.aoInserirFundacao("18/01/2025");
      When.naPaginaDeCriacao.aoInserirEstadio("Estadio Olimpico")
      When.naPaginaDeCriacao.aoSelecionarEstado("Goiás")
      When.naPaginaDeCriacao.aoSelecionarCoberturaAntiChuva("Não")
      When.naPaginaDeCriacao.aoClicarEmSalvarClube();

      // Assert
      Then.naPaginaDeCriacao.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("A data deve ser anterior ou igual à data atual!");

      Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro do estadio aparece na Caixa de Dialogo", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/criar"});

      //Act 
      When.naPaginaDeCriacao.aoInserirNome("Goiânia");
      When.naPaginaDeCriacao.aoInserirFundacao("18/01/1976");
      When.naPaginaDeCriacao.aoInserirEstadio("E")
      When.naPaginaDeCriacao.aoSelecionarEstado("Goiás")
      When.naPaginaDeCriacao.aoSelecionarCoberturaAntiChuva("Não")
      When.naPaginaDeCriacao.aoClicarEmSalvarClube();

      // Assert
      Then.naPaginaDeCriacao.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("O nome do estádio deve ter entre 3 e 60 caracteres!");

      Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro do Cobertura Antichuva aparece na Caixa de Dialogo", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/criar"});

      //Act 
      When.naPaginaDeCriacao.aoInserirNome("Goiânia");
      When.naPaginaDeCriacao.aoInserirFundacao("18/01/1976");
      When.naPaginaDeCriacao.aoInserirEstadio("Estadio Olimpico")
      When.naPaginaDeCriacao.aoSelecionarEstado("Goiás")
      When.naPaginaDeCriacao.aoClicarEmSalvarClube();

      // Assert
      Then.naPaginaDeCriacao.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("Campo 'Cobertura Antichuva' deve ser preenchido!");

      Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o MessageToast aparece na tela", function (Given, When, Then) {
      // Arrange
      Given.iStartMyApp({hash : "clubes/criar"});

      //Act 
      When.naPaginaDeCriacao.aoInserirNome("Goiânia");
      When.naPaginaDeCriacao.aoInserirFundacao("18/01/1976");
      When.naPaginaDeCriacao.aoInserirEstadio("Estadio Olimpico")
      When.naPaginaDeCriacao.aoSelecionarEstado("Goiás")
      When.naPaginaDeCriacao.aoSelecionarCoberturaAntiChuva("Não")
      When.naPaginaDeCriacao.aoClicarEmSalvarClube();

      // Assert
      Then.naPaginaDeCriacao.DeveVerificarMessageToast("Clube criado com sucesso!");

      Then.iTeardownMyApp();
    });
});