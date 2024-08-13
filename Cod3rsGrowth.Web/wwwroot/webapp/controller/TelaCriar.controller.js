sap.ui.define([
    "./Base",
    "../servico/ClubeServico",
    "../formatter",
    "sap/m/MessageBox",
    "sap/m/MessageToast",
    "sap/ui/model/json/JSONModel"
], (Base, ClubeServico, Formatter, MessageBox, MessageToast, JSONModel) => {
    "use strict";

    const NUMZERO = 0;
    const SIM = "Sim";
    const FUNDACAO = "fundacao";
    const ESTADIO = "estadio";
    const NOME = "nome";
    const VALUE = "value";
    const ITEMSELECIONADO = "selectedItem";
    const ESTADO = "estado";
    const COBERTURA = "coberturaAntiChuva";
    const SELECTEDINDEX = "selectedIndex";
    const INPUTNOME = "InputNome";
    const CALENDARIOCRIAR = "CalendarioCriar";
    const INPUTESTADIO = "InputEstadio";
    const ESTADIOCRIACAO = "EstadoCriacao";
    const BOTAO_SIM = "BotaoSim";
    const BOTAO_NAO = "BotaoNao";
    const VAZIO = "";
    const ESTADOS = "estados";

    return Base.extend("cod3rsgrowth.webapp.controller.Criar", {
        clubeServico: ClubeServico,
        formatter: Formatter,

        onInit: function () {
            this.DadosCriacao = [];
            this._vincularRota("criar", this.aoCoincidirRota);
            this._CarregarEstados();
        },

        aoCoincidirRota: function(){
            this.resetarItems();
        },

        _CarregarEstados: function() {
            this.clubeServico.aoBuscarEstados()
                .then((estados) => {
                    var oModel = new JSONModel(estados);
                    this.getView().setModel(oModel, ESTADOS);
                })
                .catch((error) => {
                    console.error('Erro ao buscar estados:', error);
                });
        },


        aoInserirNome: function(oEvent){
            var nome = oEvent.getParameter(VALUE);
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== NOME);
            if (nome) {
                this.DadosCriacao.push({ key: NOME, value: nome});
            }
            this.validarNome(nome);
        },

        aoInserirFundação: function(oEvent){
            var fundacao = oEvent.getParameter(VALUE);
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== FUNDACAO);
            if(fundacao){
                var DataFormatada = this.formatter.formatDateReverse(fundacao);
                this.DadosCriacao.push({key: FUNDACAO, value: DataFormatada});
            }
            this.validarFundacao(fundacao);
        },

        aoInserirEstadio: function(oEvent){
            var estadio = oEvent.getParameter(VALUE);
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== ESTADIO);
            if (estadio) {
                this.DadosCriacao.push({ key: ESTADIO, value: estadio});
            }
            this.validarEstadio(estadio);
        },

        aoInserirEstadoDeCriação: function(oEvent){
            var estado = oEvent.getParameter(ITEMSELECIONADO).getKey();
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== ESTADO);
            if (estado >= NUMZERO) {
                this.DadosCriacao.push({ key: ESTADO, value: parseInt(estado, 10)});
            }
            this.validarEstado(estado);
        },

        aoInserirCobertura: function(oEvent){
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== COBERTURA);
            var selectedIndex = oEvent.getParameter(SELECTEDINDEX);
            var grupoDeBotoes = oEvent.getSource();
            var TextoSelecionado = grupoDeBotoes.getButtons()[selectedIndex].getText();
            var cobertura = TextoSelecionado === SIM;
            this.DadosCriacao.push({ key: COBERTURA, value: cobertura});
            this.validarCobertura(cobertura);
        },

        validarNome: function(nome) {
            var inputNome = this.byId(INPUTNOME);
            if (!nome) {
                inputNome.setValueState("Error");
                inputNome.setValueStateText("Campo 'Nome' precisa ser preenchido.");
                return false;
            } else if (nome.length < 3 || nome.length > 60) {
                inputNome.setValueState("Error");
                inputNome.setValueStateText("Nome deve ter entre 3 e 60 caracteres.");
                return false;
            }
            inputNome.setValueState("None");
            return true;
        },
        
        validarEstadio: function(estadio) {
            var inputEstadio = this.byId(INPUTESTADIO);
            if (!estadio) {
                inputEstadio.setValueState("Error");
                inputEstadio.setValueStateText("Campo 'Estádio' precisa ser preenchido.");
                return false;
            } else if (estadio.length < 3 || estadio.length > 60) {
                inputEstadio.setValueState("Error");
                inputEstadio.setValueStateText("Estádio deve ter entre 3 e 60 caracteres.");
                return false;
            }
            inputEstadio.setValueState("None");
            return true;
        },
        
        validarFundacao: function(data) {
            var calendarioCriar = this.byId(CALENDARIOCRIAR);
            if (!data) {
                calendarioCriar.setValueState("Error");
                calendarioCriar.setValueStateText("Campo 'Data de Fundação' precisa ser preenchido.");
                return false;
            } else if (new Date(data) > new Date()) {
                calendarioCriar.setValueState("Error");
                calendarioCriar.setValueStateText("A data deve ser igual ou anterior ao dia atual.");
                return false;
            }
            calendarioCriar.setValueState("None");
            return true;
        },
        
        validarEstado: function(estado) {
            var estadoCriacao = this.byId(ESTADIOCRIACAO);
            if (estado == null || estado === "") {
                estadoCriacao.setValueState("Error");
                estadoCriacao.setValueStateText("Campo 'Estado' precisa ser preenchido.");
                return false;
            }
            estadoCriacao.setValueState("None");
            return true;
        },
        
        validarCobertura: function(cobertura) {
            var botaoSim = this.byId(BOTAO_SIM);
            var botaoNao = this.byId(BOTAO_NAO);
            if (cobertura === undefined) {
                botaoSim.setValueState("Error");
                botaoNao.setValueState("Error");
                return false;
            }
            botaoSim.setValueState("None");
            botaoNao.setValueState("None");
            return true;
        },

        resetarItems: function() {
            var inputNome = this.byId(INPUTNOME);
            if (inputNome) {
                inputNome.setValue(VAZIO);
                inputNome.setValueState("None");
            }

            var calendarioCriar = this.byId(CALENDARIOCRIAR);
            if (calendarioCriar) {
                calendarioCriar.setDateValue(null);
                calendarioCriar.setValueState("None");
            }

            var inputEstadio = this.byId(INPUTESTADIO);
            if (inputEstadio) {
                inputEstadio.setValue(VAZIO);
                inputEstadio.setValueState("None");
            }

            var estadoCriacao = this.byId(ESTADIOCRIACAO);
            if (estadoCriacao) {
                estadoCriacao.setSelectedKey(null);
                estadoCriacao.setValueState("None");
            }

            var botaoSim = this.byId(BOTAO_SIM);
            if (botaoSim) {
                botaoSim.setSelected(false);
                botaoSim.setValueState("None");
            }

            var botaoNao = this.byId(BOTAO_NAO);
            if (botaoNao) {
                botaoNao.setSelected(false);
                botaoNao.setValueState("None");
            }
        },

        aoSalvarClube: async function () {
            if (!this.validarCamposPreenchidos()) {
                return;
            }
            var DadosDaCriação = this.DadosCriacao.reduce((newArray, atual) => {
                newArray[atual.key] = atual.value;
                return newArray;
            }, {})
            try {
                const resultado = await this.clubeServico.aoCriarClube(DadosDaCriação);
                MessageToast.show(`Clube criado com sucesso!`, { duration: 5000, closeOnBrowserNavigation: false });
                this.resetarItems();
                this._onNavBack("clubes");
            } 
            catch (erro) {
                this.exibirErroNaTela(erro);
            }
        },

        validarCamposPreenchidos: function () {
            const nomeValido = this.validarNome(this.byId(INPUTNOME).getValue());
            const estadioValido = this.validarEstadio(this.byId(INPUTESTADIO).getValue());
            const fundacaoValida = this.validarFundacao(this.byId(CALENDARIOCRIAR).getDateValue());
            const estadoValido = this.validarEstado(this.byId(ESTADIOCRIACAO).getSelectedKey());
            const coberturaValida = this.validarCobertura(this.byId(BOTAO_SIM).getSelected() || this.byId(BOTAO_NAO).getSelected());

            return nomeValido && estadioValido && fundacaoValida && estadoValido && coberturaValida;
        },

        exibirErroNaTela: function(erro) {  
            console.log(erro);

            let mensagemErro = "Erro desconhecido encontrado!";
            let detalhesErro = "Stacktrace está indisponível!";
        
            if (erro.extensions && erro.extensions.fluentValidation) {
                mensagemErro = Object.values(erro.extensions.fluentValidation).join("\r\n");
            } 
            else if (erro.detail) {
                mensagemErro = erro.detail.split("\r\n")[0];
            }
            if (erro.title || erro.Title) {
                detalhesErro = `Status: ${erro.status || erro.Status} - Detalhes: ${erro.title || erro.Title}`;
            }
        
            MessageBox.error(mensagemErro, {
                title: "Erro",
                details: detalhesErro,
                actions: [MessageBox.Action.CLOSE]
            });
        }
    });
});
 