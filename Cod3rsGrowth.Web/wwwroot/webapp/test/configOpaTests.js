QUnit.config.autostart = false;

sap.ui.require([
    "sap/ui/core/Core",
	"sap/ui/test/Opa5",
    "cod3rsgrowth/webapp/test/arrangements/Startup",
    "cod3rsgrowth/webapp/test/jornadas/Home",
    "cod3rsgrowth/webapp/test/jornadas/ListaDeClubes",
    "cod3rsgrowth/webapp/test/jornadas/NotFound",
    "cod3rsgrowth/webapp/test/jornadas/TelaCriar",
    "cod3rsgrowth/webapp/test/jornadas/Detalhes",
    "cod3rsgrowth/webapp/test/jornadas/Editar",
    "cod3rsgrowth/webapp/test/jornadas/Deletar",
    "cod3rsgrowth/webapp/test/jornadas/Criarjogador",
    "cod3rsgrowth/webapp/test/jornadas/EditarJogador",
    "cod3rsgrowth/webapp/test/jornadas/DeletarJogador"
], async (Core, Opa5, Startup) => {
    "use strict";

	Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "cod3rsgrowth.webapp.view",
		autoWait: true
	});

    Core.attachInit(() => QUnit.start());
});