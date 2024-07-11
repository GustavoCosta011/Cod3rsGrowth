
sap.ui.require([
	"sap/ui/core/Core",
	"Cod3rsGrowth/test/integration/Navegation"
], async(Core) => {
	"use strict";

	await Core.ready();
	QUnit.start();
});