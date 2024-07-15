
sap.ui.define([
	"./Base",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (Base, JSONModel, Filter, FilterOperator) => {
	"use strict";

	return Base.extend("coders-growth.controller.ListaPersonagem", {
		onInit: function() {
            const ObterClubes = "https://localhost:7178//api/Clubes";

			fetch(ObterClubes, {
				method: "GET",
				headers: { "Content-Type": "application/json" },
			})
			.then(Response => Response.json())
			.then(Clubes => {
                const ClubesModels = new JSONModel(Clubes);
                this.getView().setModel(ClubesModels);
			})
            .catch(error => {
                console.error('Erro:', error);
            })
        }
	});
});