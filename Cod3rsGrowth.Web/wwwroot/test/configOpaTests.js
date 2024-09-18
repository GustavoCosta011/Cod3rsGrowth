QUnit.config.autostart = false;

sap.ui.require([
    "sap/ui/core/Core",
	"sap/ui/test/Opa5",
    "cod3rsgrowth/test/arrangements/Startup",
    "cod3rsgrowth/test/jornadas/Home",
    "cod3rsgrowth/test/jornadas/ListaDeClubes",
    "cod3rsgrowth/test/jornadas/NotFound",
    "cod3rsgrowth/test/jornadas/TelaCriar",
    "cod3rsgrowth/test/jornadas/Detalhes",
    "cod3rsgrowth/test/jornadas/Editar",
    "cod3rsgrowth/test/jornadas/Deletar",
    "cod3rsgrowth/test/jornadas/Criarjogador",
    "cod3rsgrowth/test/jornadas/EditarJogador",
    "cod3rsgrowth/test/jornadas/DeletarJogador"
], async (Core, Opa5, Startup) => {
    "use strict";

	Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "cod3rsgrowth.webapp",
		autoWait: true
	});

    Core.attachInit(() => QUnit.start());
});