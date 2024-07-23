sap.ui.define([
    "./Base",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/UIComponent",
	"../formatter"
], (Base, JSONModel,UIComponent,formatter) => {
    "use strict";

    return Base.extend("cod3rsgrowth.controller.ListaDeClubes", {
		formatter: formatter,
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
			this.aoBuscar();
        },

        aoMudarOEstadoNaComboBox: function(oEvent) {
            var estado = oEvent.getParameter("selectedItem").getKey();
			this.filtros = this.filtros.filter(f => !f.startsWith("estado="))
			if(estado >= 0){
				this.filtros.push("estado=" + encodeURIComponent(estado));
			}
			this.aoBuscar();
        },

		aoAlterarData: function(oEvent){
			var DataPiso = oEvent.getParameter("from");
            var DataTeto = oEvent.getParameter("to");
			this.filtros = this.filtros.filter(f => !f.startsWith("DataPiso="))
            this.filtros = this.filtros.filter(f => !f.startsWith("DataTeto="))
			if(DataPiso){
                var DataFormatada = formatter.formatDateReverse(DataPiso);
				this.filtros.push("DataPiso=" + encodeURIComponent(DataFormatada));
			}
            if(DataTeto){
                var DataFormatada = formatter.formatDateReverse(DataTeto);
				this.filtros.push("DataTeto=" + encodeURIComponent(DataFormatada));
			}
			this.aoBuscar();
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
