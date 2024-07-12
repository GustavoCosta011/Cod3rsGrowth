sap.ui.require([
    "sap/ui/test/opaQUnit",
    "/pages/app"
  ], function (opaQUnit) {
  
    opaQUnit("Obter texto esperado", function (Given, When, Then) {
          // Arrangements
          Given.iStartMyUIComponent({
            componentConfig: {
                name: "cod3rsgrowth"
            }
          });
          Then.onTheAppPage.iShouldSeeExpectedText();
          Then.iTeardownMyApp();
    });
});