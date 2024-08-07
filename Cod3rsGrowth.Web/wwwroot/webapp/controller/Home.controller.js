sap.ui.define([
	"./Base"
], function (Base) {
	"use strict";
	const CLUBES = "clubes";

	return Base.extend("cod3rsgrowth.webapp.controller.Home", {
		IrParaClubes(){
			this.getRouter().navTo(CLUBES);
		}
	});
});
