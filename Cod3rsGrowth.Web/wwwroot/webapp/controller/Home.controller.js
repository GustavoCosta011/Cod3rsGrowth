sap.ui.define([
	"./Base"
], function (Base) {
	"use strict";

	return Base.extend("cod3rsgrowth.controller.Home", {
		IrParaClubes(){
			this.getRouter().navTo("clubes");
		}
	});
});
