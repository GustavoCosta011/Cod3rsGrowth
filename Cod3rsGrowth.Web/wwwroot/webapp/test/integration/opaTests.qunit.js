
sap.ui.require([
	"sap/ui/core/Core",
	"cod3rsgrowth/test/integration/Navegation"
], async(Core) => {
	"use strict";
	await Core.ready();
	QUnit.start();
});