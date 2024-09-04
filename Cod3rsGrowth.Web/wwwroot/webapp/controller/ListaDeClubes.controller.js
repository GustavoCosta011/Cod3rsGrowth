sap.ui.define([
    "./Base",
    "../formatter",
    "../servico/ClubeServico",
    "sap/ui/model/json/JSONModel"
], function (Base, Formatter, ClubeServico, JSONModel) {
    "use strict";
    const NUMERO_ZERO = 0;
    const NOME_ROTA_CLUBES = "clubes";
    const VALOR_DO_INPUT = "value";
    const CHAVE_NOME = "nome";
    const CHAVE_ESTADO = "estado";
    const ITEMSELECIONADO = "selectedItem";
    const FROM = "from";
    const TO = "to";
    const CHAVE_DATA_PISO = "DataPiso";
    const CHAVE_DATA_TETO = "DataTeto";
    const CALENDARIO = "calendario";
    const COMBOBOXESTADOS = "ComboBoxEstados";
    const INPUTNOME = "InputNome";
    const VAZIO = "";
    const CRIAR = "criar";
    const DETALHES = "detalhes";
    const ID_DO_CLUBE = "id";
    const DESTINO_VOLTAR = '';
    const LIMPAR = "Limpar";
    const ID_BOTAO_LIMPAR = "BotaoLimpar";


    return Base.extend("cod3rsgrowth.webapp.controller.ListaDeClubes", {
        formatter: Formatter,

        onInit: function() {
            this.filtros = [];
            this._vincularRota(NOME_ROTA_CLUBES, this.aoCoincidirRota);
        },

        aoCoincidirRota : function(){
            this.aoBuscarFiltros();
            this._CarregarEstados();
        },

        aoClicarAdicionar: function(){
            this._getRouter().navTo(CRIAR, {});
        },

        aoSelecionarUmItem: function(oEvent){
            this._navegarPara(DETALHES,{ idClube : oEvent.getSource().getBindingContext(NOME_ROTA_CLUBES).getProperty(ID_DO_CLUBE)})
        },

        aoBuscarFiltros: function() {
            this._getRouter().navTo(NOME_ROTA_CLUBES, this.filtros.length === NUMERO_ZERO ? {} : {
                query: this.filtros.reduce((newArray, atual) => {
                    newArray[atual.key] = atual.value;
                    return newArray;
                }, {})
            });

            var oView = this.getView();
            ClubeServico.buscarClubes(this.filtros)
                .then((Clubes) => {
                    oView.setModel(new JSONModel(Clubes),NOME_ROTA_CLUBES);
                })
                .catch((error) => {
                    console.error('Erro:', error);
                });
        },

        aoClivarEmVoltar: function(){
            this._navegarPara(DESTINO_VOLTAR,{Acao : LIMPAR})
        },

        aoBuscarPorNome: function(oEvent) {
            var nome = oEvent.getParameter(VALOR_DO_INPUT);
            this.filtros = this.filtros.filter(f => f.key !== CHAVE_NOME);
            if (nome) {
                this.filtros.push({ key: CHAVE_NOME, value: encodeURIComponent(nome) });
            }
            this.aoBuscarFiltros();
        },

        aoMudarOEstadoNaComboBox: function(oEvent) {
            var estado = oEvent.getParameter(ITEMSELECIONADO).getKey();
            this.filtros = this.filtros.filter(f => f.key !== CHAVE_ESTADO);
            if (estado >= NUMERO_ZERO) {
                this.filtros.push({ key: CHAVE_ESTADO, value: encodeURIComponent(estado) });
            }
            this.aoBuscarFiltros();
        },

        aoAlterarData: function(oEvent) {
            var DataPiso = oEvent.getParameter(FROM);
            var DataTeto = oEvent.getParameter(TO);
            this.filtros = this.filtros.filter(f => f.key !== CHAVE_DATA_PISO && f.key !== CHAVE_DATA_TETO);
            if (DataPiso) {
                var DataFormatada = this.formatter.formatDateReverse(DataPiso);
                this.filtros.push({ key: CHAVE_DATA_PISO, value: encodeURIComponent(DataFormatada) });
            }
            if (DataTeto) {
                var DataFormatada = this.formatter.formatDateReverse(DataTeto);
                this.filtros.push({ key: CHAVE_DATA_TETO, value: encodeURIComponent(DataFormatada) });
            }
            this.aoBuscarFiltros();
        },

        resetarItems: function(oEvent) {
            var calendario = this.byId(CALENDARIO);
            if (calendario) {
                calendario.setDateValue(null);
                calendario.setSecondDateValue(null);
                this.filtros = this.filtros.filter(f => f.key !== CHAVE_DATA_PISO && f.key !== CHAVE_DATA_TETO);
            }

            var ComboBox = this.byId(COMBOBOXESTADOS);
            if (ComboBox) {
                ComboBox.setSelectedKey(null);
                this.filtros = this.filtros.filter(f => f.key !== CHAVE_ESTADO);
            }

            var InputNome = this.byId(INPUTNOME);
            if (InputNome) {
                InputNome.setValue(VAZIO);
                this.filtros = this.filtros.filter(f => f.key !== CHAVE_NOME);
            }
            
            var Botao = oEvent.getSource().getId();
            if (Botao.includes(ID_BOTAO_LIMPAR)) {
                this.aoBuscarFiltros();
            }            
        }
    });
});
