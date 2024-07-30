sap.ui.define([
    "./Base",
    "sap/ui/core/UIComponent",
    "../formatter",
    "../servico/ClubeServico"
], (Base, UIComponent, Formatter, ClubeServico) => {
    "use strict";

    return Base.extend("cod3rsgrowth.controller.ListaDeClubes", {
        formatter: Formatter,
        clubeServico: ClubeServico,
        onInit: function() {
            this.filtros = [];
            this.clubeServico.aoBuscar(this.filtros, this.getView());
            
            var oRouter = UIComponent.getRouterFor(this);
            oRouter.getRoute("clubes").attachPatternMatched(this.aoBuscarFiltros, this);
        },
        aoClicarAdicionar: function(){
            this.clubeServico.aoBuscar(this.filtros, this.getView());
        },

        aoBuscarFiltros: function() {
            this.getRouter().navTo("clubes", this.filtros.length === 0 ? {} : {
                query: this.filtros.reduce((newArray, atual) => {
                    newArray[atual.key] = atual.value;
                    return newArray;
                }, {})
            });

            this.clubeServico.aoBuscar(this.filtros, this.getView());
        },

        aoBuscarPorNome: function(oEvent) {
            var nome = oEvent.getParameter("value");
            this.filtros = this.filtros.filter(f => f.key !== "nome");
            if (nome) {
                this.filtros.push({ key: "nome", value: encodeURIComponent(nome) });
            }
            this.clubeServico.aoBuscar(this.filtros, this.getView());
        },

        aoMudarOEstadoNaComboBox: function(oEvent) {
            var estado = oEvent.getParameter("selectedItem").getKey();
            this.filtros = this.filtros.filter(f => f.key !== "estado");
            if (estado >= 0) {
                this.filtros.push({ key: "estado", value: encodeURIComponent(estado) });
            }
            this.clubeServico.aoBuscar(this.filtros, this.getView());
        },

        aoAlterarData: function(oEvent) {
            var DataPiso = oEvent.getParameter("from");
            var DataTeto = oEvent.getParameter("to");
            this.filtros = this.filtros.filter(f => f.key !== "DataPiso" && f.key !== "DataTeto");
            if (DataPiso) {
                var DataFormatada = this.formatter.formatDateReverse(DataPiso);
                this.filtros.push({ key: "DataPiso", value: encodeURIComponent(DataFormatada) });
            }
            if (DataTeto) {
                var DataFormatada = this.formatter.formatDateReverse(DataTeto);
                this.filtros.push({ key: "DataTeto", value: encodeURIComponent(DataFormatada) });
            }
            this.clubeServico.aoBuscar(this.filtros, this.getView());
        },

        aoLimparOsFiltros: function() {
            var calendario = this.byId("calendario");
            if (calendario) {
                calendario.setDateValue(null);
                calendario.setSecondDateValue(null);
                this.filtros = this.filtros.filter(f => f.key !== "DataPiso" && f.key !== "DataTeto");
            }

            var ComboBox = this.byId("ComboBoxEstados");
            if (ComboBox) {
                ComboBox.setSelectedKey("-1");
                this.filtros = this.filtros.filter(f => f.key !== "estado");
            }

            var InputNome = this.byId("InputNome");
            if (InputNome) {
                InputNome.setValue("");
                this.filtros = this.filtros.filter(f => f.key !== "nome");
            }

            this.clubeServico.aoBuscar(this.filtros, this.getView());
        }
    });
});
