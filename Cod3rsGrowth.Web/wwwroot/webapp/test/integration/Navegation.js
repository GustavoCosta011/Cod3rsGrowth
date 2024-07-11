sap.ui.require([
    "sap/ui/test/opaQUnit",
    "/pages/app"
  ], function (Opa5, opaQUnit, Press, PropertyStrictEquals) {
  
    opaQUnit("Obter texto esperado", function (Given, When, Then) {
          // Arrangements
          Given.iStartMyUIComponent({
            componentConfig: {
                name: "Cod3rsGrowth"
            }
          });
          Then.onTheAppPage.iShouldSeeExpectedText();
          Then.iTeardownMyApp();
    });
});