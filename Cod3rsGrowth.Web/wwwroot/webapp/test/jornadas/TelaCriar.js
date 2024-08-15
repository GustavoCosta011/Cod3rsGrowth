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
        Then.naPaginaDeCriacao.DeveVerificarSeAUrlSeraADaPaginaDeCriação();
        Then.naPaginaDeCriacao.DeveVerificarSeOTituloDaPaginaEODeCriacao();

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

    opaQUnit("Deve Verificar  se as mensagens de erro aparecem nis inputs", function (Given, When, Then) {
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