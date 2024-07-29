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
			this.filtros = this.filtros.filter(f => f.key !== "nome");
			if(nome){
				this.filtros.push({key : "nome" , value : encodeURIComponent(nome)});
			}
			this.aoBuscar();
        },

        aoMudarOEstadoNaComboBox: function(oEvent) {
            var estado = oEvent.getParameter("selectedItem").getKey();
			this.filtros = this.filtros.filter(f => f.key !== "estado");
			if(estado >= 0){
				this.filtros.push({ key : "estado" , value : encodeURIComponent(estado)});
			}
			this.aoBuscar();
        },

		aoAlterarData: function(oEvent){
			var DataPiso = oEvent.getParameter("from");
            var DataTeto = oEvent.getParameter("to");
            this.filtros = this.filtros.filter(f => f.key !== "DataPiso" && f.key !== "DataTeto");
			if(DataPiso){
                var DataFormatada = formatter.formatDateReverse(DataPiso);
				this.filtros.push({key : "DataPiso"  , value : encodeURIComponent(DataFormatada)});
			}
            if(DataTeto){
                var DataFormatada = formatter.formatDateReverse(DataTeto);
				this.filtros.push({key : "DataTeto"  , value : encodeURIComponent(DataFormatada)});
			}
			this.aoBuscar();
		},
        aoLimparOsFiltros: function(){
            var calendario = this.byId("calendario");
            if(calendario){
                calendario.setDateValue(null);
                calendario.setSecondDateValue(null);
                this.filtros = this.filtros.filter(f => f.key !== "DataPiso" && f.key !== "DataTeto");
            }

            var ComboBox = this.byId("ComboBoxEstados");
            if(ComboBox){
                ComboBox.setSelectedKey("-1");
                this.filtros = this.filtros.filter(f => f.key !== "estado");
            }

            var InputNome = this.byId("InputNome");
            if(InputNome){
                InputNome.setValue("");
                this.filtros = this.filtros.filter(f => f.key !== "nome");
            }

            this.aoBuscar();
        },
		
        aoBuscar: function() {
			this.urlClubes = "https://localhost:7178/api/Clubes";
            if (this.filtros.length > 0) {
                this.urlClubes += "?" + this.filtros.map(filtro => `${filtro.key}=${filtro.value}`).join("&");
            }

            this.getRouter().navTo("clubes", Object.keys(this.filtros).length === 0 ? {} : {
                query: this.filtros.reduce((newArray, atual) => {
                    newArray[atual.key] = atual.value;
                    return newArray;
                }, {})
            });

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
