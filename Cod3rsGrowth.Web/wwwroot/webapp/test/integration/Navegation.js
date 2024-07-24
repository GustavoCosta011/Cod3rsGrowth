sap.ui.require([
    "sap/ui/test/opaQUnit",
    "./pages/Home"
  ], function (opaQUnit) {
  
    opaQUnit("Deve navegar para a aba de clubes", function (Given, When, Then) {
          // Arrange
          Given.iStartMyUIComponent({
            componentConfig: {
                name: "cod3rsgrowth"
            }
          });
          //Act
          When.NaPaginaClube.aoClicarEmcClubes();
          //Assert
          Then.iTeardownMyApp();
    });
});