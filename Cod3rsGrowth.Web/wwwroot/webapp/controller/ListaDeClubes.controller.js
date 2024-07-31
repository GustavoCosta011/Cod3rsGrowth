sap.ui.define([
    "./Base",
    "sap/ui/core/UIComponent",
    "../formatter",
    "../servico/ClubeServico",
    "sap/ui/model/json/JSONModel"
], (Base, UIComponent, Formatter, ClubeServico, JSONModel) => {
    "use strict";
    const NUMZERO = 0;
    const CLUBES = "clubes";
    const VALUE = "value";
    const NOME = "nome";
    const ESTADO = "estado";
    const ITEMSELECIONADO = "selectedItem";
    const FROM = "from";
    const TO = "to";
    const DATAPISO = "DataPiso";
    const DATATETO = "DataTeto";
    const CALENDARIO = "calendario";
    const COMBOBOXESTADOS = "ComboBoxEstados";
    const INPUTNOME = "InputNome";
    const VAZIO = "";
    const CRIAR = "criar"

    return Base.extend("cod3rsgrowth.controller.ListaDeClubes", {
        formatter: Formatter,
        clubeServico: ClubeServico,
        onInit: function() {
            this.filtros = [];
            this.aoBuscarFiltros();
            
            var oRouter = UIComponent.getRouterFor(this);
            oRouter.getRoute(CLUBES).attachPatternMatched(this.aoBuscarFiltros, this);
        },

        aoClicarAdicionar: function(){
            this.getRouter().navTo(CRIAR,{});
        },

        aoBuscarFiltros: function() {
            this.getRouter().navTo(CLUBES, this.filtros.length === NUMZERO ? {} : {
                query: this.filtros.reduce((newArray, atual) => {
                    newArray[atual.key] = atual.value;
                    return newArray;
                }, {})
            });
            var oView = this.getView();
            ClubeServico.aoBuscar(this.filtros)
            .then(function(Clubes) {
                oView.setModel(new JSONModel(Clubes));
            })
            .catch(function(error) {
                console.error('Erro:', error);
            });
        },

        aoBuscarPorNome: function(oEvent) {
            var nome = oEvent.getParameter(VALUE);
            this.filtros = this.filtros.filter(f => f.key !== NOME);
            if (nome) {
                this.filtros.push({ key: NOME, value: encodeURIComponent(nome) });
            }
            this.aoBuscarFiltros();
        },

        aoMudarOEstadoNaComboBox: function(oEvent) {
            var estado = oEvent.getParameter(ITEMSELECIONADO).getKey();
            this.filtros = this.filtros.filter(f => f.key !== ESTADO);
            if (estado >= NUMZERO) {
                this.filtros.push({ key: ESTADO, value: encodeURIComponent(estado) });
            }
            this.aoBuscarFiltros();
        },


        aoAlterarData: function(oEvent) {
            var DataPiso = oEvent.getParameter(FROM);
            var DataTeto = oEvent.getParameter(TO);
            this.filtros = this.filtros.filter(f => f.key !== DATAPISO && f.key !== DATATETO);
            if (DataPiso) {
                var DataFormatada = this.formatter.formatDateReverse(DataPiso);
                this.filtros.push({ key: DATAPISO, value: encodeURIComponent(DataFormatada) });
            }
            if (DataTeto) {
                var DataFormatada = this.formatter.formatDateReverse(DataTeto);
                this.filtros.push({ key: DATATETO, value: encodeURIComponent(DataFormatada) });
            }
            this.aoBuscarFiltros();
        },

        aoLimparOsFiltros: function() {
            var calendario = this.byId(CALENDARIO);
            if (calendario) {
                calendario.setDateValue(null);
                calendario.setSecondDateValue(null);
                this.filtros = this.filtros.filter(f => f.key !== DATAPISO && f.key !== DATATETO);
            }

            var ComboBox = this.byId(COMBOBOXESTADOS);
            if (ComboBox) {
                ComboBox.setSelectedKey(null);
                this.filtros = this.filtros.filter(f => f.key !== ESTADO);
            }

            var InputNome = this.byId(INPUTNOME);
            if (InputNome) {
                InputNome.setValue(VAZIO);
                this.filtros = this.filtros.filter(f => f.key !== NOME);
            }

            this.aoBuscarFiltros();
        }
    });
});
