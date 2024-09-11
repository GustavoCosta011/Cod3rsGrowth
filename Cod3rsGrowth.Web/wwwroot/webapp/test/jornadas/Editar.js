sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/TelaCriar",
  ], (opaQUnit) => {
    "use strict";
     
    QUnit.module("Editar");

    opaQUnit("Deve verificar o titulo e a url edição", function (Given, When, Then) {
        // Arrange     
        Given.iStartMyApp({hash : "clubes/editar/11"});

        // Act  
        Then.naPaginaDeCriacao.DeveVerificarSeAUrlSeraADaPaginaDeCriação("clubes/editar/11");
        Then.naPaginaDeCriacao.DeveVerificarSeOTituloDaPaginaEODeCriacao("Formulario - Clube");
        
    });

    opaQUnit("Deve verificar se os items da lista foram carregados", function (Given, When, Then) {
        // Assert
        Then.naPaginaDeCriacao.deVerificarSeONomeFoiCarregado("Fortaleza");
        Then.naPaginaDeCriacao.deVerificarSeAFundacaoFoiCarregada("18/10/1918");
        Then.naPaginaDeCriacao.deVerificarSeOEstadioFoiCarregado("Castelão");
        Then.naPaginaDeCriacao.deVerificarSeOEstadoFoiCarregado("Ceará");
        Then.naPaginaDeCriacao.deVerificarSeACoberturaFoiCarregada(true);       
    });

    opaQUnit("Deve verificar a mensagem  de edição", function (Given, When, Then) {
        // Act  
        When.naPaginaDeCriacao.aoClicarEmSalvarClube();

        // Assert
        Then.naPaginaDeCriacao.DeveVerificarMessageToast("Clube editado com sucesso!");
        
        Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro do nome aparece na Caixa de Dialogo", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash : "clubes/editar/11"});
  
        //Act 
        When.naPaginaDeCriacao.aoInserirNome("G");
        When.naPaginaDeCriacao.aoClicarEmSalvarClube();
  
        // Assert
        Then.naPaginaDeCriacao.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("O nome deve ter entre 3 e 60 caracteres!");
  
        Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro da fundação aparece na Caixa de Dialogo", function (Given, When, Then) {
        // Arrange     
        Given.iStartMyApp({hash : "clubes/editar/11"});

        // Act  
        When.naPaginaDeCriacao.aoInserirFundacao("18/01/2025");
        When.naPaginaDeCriacao.aoClicarEmSalvarClube();

        // Assert
        Then.naPaginaDeCriacao.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("A data deve ser anterior ou igual à data atual!");
        
        Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se o Erro do estadio aparece na Caixa de Dialogo", function (Given, When, Then) {
        // Arrange
        Given.iStartMyApp({hash : "clubes/editar/11"});
  
        //Act 
        When.naPaginaDeCriacao.aoInserirEstadio("E")
        When.naPaginaDeCriacao.aoClicarEmSalvarClube();
  
        // Assert
        Then.naPaginaDeCriacao.DeveVerificarSeOErroEstaExibidoNaCaixaDeDialogo("O nome do estádio deve ter entre 3 e 60 caracteres!");
  
        Then.iTeardownMyApp();
      });
});