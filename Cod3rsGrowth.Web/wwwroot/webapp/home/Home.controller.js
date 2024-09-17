sap.ui.define([
	"../common/Base",
	"sap/m/MessageBox"
], function (Base, MessageBox) {
	"use strict";
	const CLUBES = "clubes";
	const TITULO_ERRO = "Erro";

	return Base.extend("cod3rsgrowth.webapp.home.Home", {
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
