sap.ui.define([
    "./Base",
    "../formatter",
    "../servico/ClubeServico",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"
], function (Base, Formatter, ClubeServico, JSONModel, MessageBox) {
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
    const TITULO_ERRO = "Erro";


    return Base.extend("cod3rsgrowth.webapp.controller.ListaDeClubes", {
        formatter: Formatter,

        onInit: function() {
            this.filtros = [];
            this.vincularRota(NOME_ROTA_CLUBES, this.aoCoincidirRota);
        },

        aoCoincidirRota : function(){
            try
            {
                this.aoBuscarFiltros();
                this._carregarEstados();
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        aoClicarAdicionar: function(){
            try
            {
                this._getRouter().navTo(CRIAR, {});
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        aoSelecionarUmItem: function(oEvent){
            try
            {
                this._navegarPara(DETALHES,{ idClube : oEvent.getSource().getBindingContext(NOME_ROTA_CLUBES).getProperty(ID_DO_CLUBE)});
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }      
        },

        aoBuscarFiltros: function() {
            try
            {
                this._getRouter().navTo(NOME_ROTA_CLUBES, this.filtros.length === NUMERO_ZERO ? {} : {
                    query: this.filtros.reduce((newArray, atual) => {
                        newArray[atual.key] = atual.value;
                        return newArray;
                    }, {})
                });
    
                let oView = this.getView();
                ClubeServico.buscarClubes(this.filtros)
                .then((Clubes) => {
                    oView.setModel(new JSONModel(Clubes), NOME_ROTA_CLUBES);
                });
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }    
        },

        aoClivarEmVoltar: function(){
            try
            {
                this._navegarPara(DESTINO_VOLTAR,{Acao : LIMPAR})
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }     
        },

        aoBuscarPorNome: function(oEvent) {
            try
            {
                let nome = oEvent.getParameter(VALOR_DO_INPUT);
                this.filtros = this.filtros.filter(f => f.key !== CHAVE_NOME);
                if (nome) {
                    this.filtros.push({ key: CHAVE_NOME, value: encodeURIComponent(nome) });
                }
                this.aoBuscarFiltros();
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }   
        },

        aoMudarOEstadoNaComboBox: function(oEvent) {
            try
            {
                let estado = oEvent.getParameter(ITEMSELECIONADO).getKey();
                this.filtros = this.filtros.filter(f => f.key !== CHAVE_ESTADO);
                if (estado >= NUMERO_ZERO) {
                    this.filtros.push({ key: CHAVE_ESTADO, value: encodeURIComponent(estado) });
                }
                this.aoBuscarFiltros();
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }   
        },

        aoAlterarData: function(oEvent) {
            try
            {
                let DataPiso = oEvent.getParameter(FROM);
                let DataTeto = oEvent.getParameter(TO);
                this.filtros = this.filtros.filter(f => f.key !== CHAVE_DATA_PISO && f.key !== CHAVE_DATA_TETO);
                if (DataPiso) {
                    let DataFormatada = this.formatter.formatDateReverse(DataPiso);
                    this.filtros.push({ key: CHAVE_DATA_PISO, value: encodeURIComponent(DataFormatada) });
                }
                if (DataTeto) {
                    let DataFormatada = this.formatter.formatDateReverse(DataTeto);
                    this.filtros.push({ key: CHAVE_DATA_TETO, value: encodeURIComponent(DataFormatada) });
                }
                this.aoBuscarFiltros()
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        resetarItems: function(oEvent) {
            let calendario = this.byId(CALENDARIO);
            if (calendario) {
                calendario.setDateValue(null);
                calendario.setSecondDateValue(null);
                this.filtros = this.filtros.filter(f => f.key !== CHAVE_DATA_PISO && f.key !== CHAVE_DATA_TETO);
            }

            let ComboBox = this.byId(COMBOBOXESTADOS);
            if (ComboBox) {
                ComboBox.setSelectedKey(null);
                this.filtros = this.filtros.filter(f => f.key !== CHAVE_ESTADO);
            }

            let InputNome = this.byId(INPUTNOME);
            if (InputNome) {
                InputNome.setValue(VAZIO);
                this.filtros = this.filtros.filter(f => f.key !== CHAVE_NOME);
            }
            
            let Botao = oEvent.getSource().getId();
            if (Botao.includes(ID_BOTAO_LIMPAR)) {
                this.aoBuscarFiltros();
            }            
        }
    });
});
