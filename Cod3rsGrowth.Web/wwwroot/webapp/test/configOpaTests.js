QUnit.config.autostart = false;

sap.ui.require([
    "sap/ui/core/Core",
	"sap/ui/test/Opa5",
    "cod3rsgrowth/test/arrangements/Startup",
    "cod3rsgrowth/test/jornadas/Home",
    "cod3rsgrowth/test/jornadas/ListaDeClubes",
    "cod3rsgrowth/test/jornadas/NotFound"
], async (Core, Opa5, Startup) => {
    "use strict";

	Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "cod3rsgrowth.view",
		autoWait: true
	});

    Core.attachInit(() => QUnit.start());
});