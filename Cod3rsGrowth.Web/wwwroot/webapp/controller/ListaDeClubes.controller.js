
sap.ui.define([
	"./Base",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
	"../formatter"
], (Base, JSONModel, formatter, Filter, FilterOperator) => {
	"use strict";

	return Base.extend("cod3rsgrowth.controller.ListaDeClubes", {
		formatter: formatter,
		onInit: function() {
            const ObterClubes = "https://localhost:7178/api/Clubes";
			

			fetch(ObterClubes, {
				method: "GET",
				headers: { "Content-Type": "application/json" },
			})
			.then(resposta => {
				if (resposta.ok) {
					return resposta.json();
				}
				else {
					throw new Error('Erro na requisição da API');
				}
            })
			.then(Clubes => {
                this.getView().setModel(new JSONModel(Clubes));
			})
            .catch(error => {
                console.error('Erro:', error);
            })

			var oModel = new JSONModel();
            oModel.loadData("../estados");
            this.getView().setModel(oModel, "estadosModel");
        },
        aoPressionarUmItem(){
            this.getRouter().navTo("clubes");
        }
	});
});