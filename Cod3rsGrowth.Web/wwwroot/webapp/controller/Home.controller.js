sap.ui.define([
	"./Base",
	"sap/m/MessageBox"
], function (Base, MessageBox) {
	"use strict";
	const CLUBES = "clubes";
	const TITULO_ERRO = "Erro";

	return Base.extend("cod3rsgrowth.webapp.controller.Home", {
		aoIrParaClubes(){
			try
            {
				this._getRouter().navTo(CLUBES);
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
		}
	});
});
