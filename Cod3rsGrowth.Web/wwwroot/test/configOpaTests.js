QUnit.config.autostart = false;

sap.ui.require([
    "sap/ui/core/Core",
	"sap/ui/Opa5",
    "cod3rsgrowth/arrangements/Startup",
    "cod3rsgrowth/jornadas/Home",
    "cod3rsgrowth/jornadas/ListaDeClubes",
    "cod3rsgrowth/jornadas/NotFound",
    "cod3rsgrowth/jornadas/TelaCriar",
    "cod3rsgrowth/jornadas/Detalhes",
    "cod3rsgrowth/jornadas/Editar",
    "cod3rsgrowth/jornadas/Deletar",
    "cod3rsgrowth/jornadas/Criarjogador",
    "cod3rsgrowth/jornadas/EditarJogador",
    "cod3rsgrowth/jornadas/DeletarJogador"
], async (Core, Opa5, Startup) => {
    "use strict";

	Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "cod3rsgrowth.webapp.view",
		autoWait: true
	});

    Core.attachInit(() => QUnit.start());
});