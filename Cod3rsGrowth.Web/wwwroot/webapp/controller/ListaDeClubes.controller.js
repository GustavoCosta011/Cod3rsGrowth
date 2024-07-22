sap.ui.define([
    "./Base",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/UIComponent"
], (Base, JSONModel,UIComponent) => {
    "use strict";

    return Base.extend("cod3rsgrowth.controller.ListaDeClubes", {
        onInit: function() {
			this.urlClubes = "https://localhost:7178/api/Clubes";
			this.filtros = [];
			this.aoBuscar();
			
            var oRouter = UIComponent.getRouterFor(this);
            oRouter.getRoute("clubes").attachPatternMatched(this.aoBuscar, this);
        },

        aoBuscarPorNome: function(oEvent) {
            var nome = oEvent.getParameter("value");
			this.filtros = this.filtros.filter(f => !f.startsWith("nome="));
			if(nome){
				this.filtros.push("nome=" + encodeURIComponent(nome));
			}
        },

        aoMudarOEstadoNaComboBox: function(oEvent) {
            var estado = oEvent.getParameter("selectedItem").getKey();
			this.filtros = this.filtros.filter(f => !f.startsWith("estado="))
			if(estado){
				this.filtros.push("estado=" + encodeURIComponent(estado));
			}
        },

        aoBuscar: function() {
			this.urlClubes = "https://localhost:7178/api/Clubes";
            if (this.filtros.length > 0) {
                this.urlClubes += "?" + this.filtros.join("&");
            }
            fetch(this.urlClubes, {
                method: "GET",
                headers: { "Content-Type": "application/json" },
            })
            .then(resposta => {
                if (resposta.ok) {
                    return resposta.json();
                } else {
                    throw new Error('Erro na requisição da API');
                }
            })
            .then(Clubes => {
                this.getView().setModel(new JSONModel(Clubes));;
            })
            .catch(error => {
                console.error('Erro:', error);
            });
        }
    });
});
