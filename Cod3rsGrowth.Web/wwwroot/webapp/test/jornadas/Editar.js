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
        
        Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar se os items da lista foram carregados", function (Given, When, Then) {
        // Arrange     
        Given.iStartMyApp({hash : "clubes/editar/11"});

        // Assert
        Then.naPaginaDeCriacao.deVerificarSeONomeFoiCarregado("Fortaleza");
        Then.naPaginaDeCriacao.deVerificarSeAFundacaoFoiCarregada("18/10/1918");
        Then.naPaginaDeCriacao.deVerificarSeOEstadioFoiCarregado("Castelão");
        Then.naPaginaDeCriacao.deVerificarSeOEstadoFoiCarregado("Ceará");
        Then.naPaginaDeCriacao.deVerificarSeACoberturaFoiCarregada(true);
        
        Then.iTeardownMyApp();
    });

    opaQUnit("Deve verificar a mensagem  de edição", function (Given, When, Then) {
        // Arrange     
        Given.iStartMyApp({hash : "clubes/editar/11"});

        // Act  
        When.naPaginaDeCriacao.aoClicarEmSalvarClube();

        // Assert
        Then.naPaginaDeCriacao.DeveVerificarMessageToast("Clube editado com sucesso!");
        
        Then.iTeardownMyApp();
    });
});