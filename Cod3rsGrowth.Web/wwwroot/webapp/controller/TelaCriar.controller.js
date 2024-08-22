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
    const CRIAR = "criar"; 
    const QUEBRADELINHA = "\r\n";
    const ESTADOS = "estados";
    const TITULO_ERRO = "Erro";
    const MENSAGEM_ERRO_DESCONHECIDO = "Erro desconhecido encontrado!";
    const DETALHES_ERRO_INDISPONIVEL = "Stacktrace está indisponível!";
    const MENSAGEM_SUCESSO_CLUBE = "Clube criado com sucesso!";
    const DURACAO_TOAST = 5000;
    const ESTADO_NONE = "None";
    const ESTADO_ERROR = "Error";
    const TEXTO_ERRO_NOME = "Campo 'Nome' precisa ser preenchido.";
    const TEXTO_ERRO_ESTADIO = "Campo 'Estádio' precisa ser preenchido.";
    const TEXTO_ERRO_FUNDACAO = "Campo 'Data de Fundação' precisa ser preenchido.";
    const TEXTO_ERRO_ESTADO = "Campo 'Estado' precisa ser preenchido.";
    const TEXTO_ERRO_FETCH_ESTADO = 'Erro ao buscar estados:';

    return Base.extend("cod3rsgrowth.webapp.controller.Criar", {
        clubeServico: ClubeServico,
        formatter: Formatter,

        onInit: function () {
            this.DadosCriacao = [];
            this._vincularRota(CRIAR, this.aoCoincidirRota);
        },

        aoCoincidirRota: function(){
            this.resetarItems();
            this._CarregarEstados();
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
                inputNome.setValueState(ESTADO_ERROR);
                inputNome.setValueStateText(TEXTO_ERRO_NOME);
                return false;
            }
            inputNome.setValueState(ESTADO_NONE);
            return true;
        },
        
        validarEstadio: function(estadio) {
            var inputEstadio = this.byId(INPUTESTADIO);
            if (!estadio) {
                inputEstadio.setValueState(ESTADO_ERROR);
                inputEstadio.setValueStateText(TEXTO_ERRO_ESTADIO);
                return false;
            }
            inputEstadio.setValueState(ESTADO_NONE);
            return true;
        },
        
        validarFundacao: function(data) {
            var calendarioCriar = this.byId(CALENDARIOCRIAR);
            if (!data) {
                calendarioCriar.setValueState(ESTADO_ERROR);
                calendarioCriar.setValueStateText(TEXTO_ERRO_FUNDACAO);
                return false;
            }
            calendarioCriar.setValueState(ESTADO_NONE);
            return true;
        },
        
        validarEstado: function(estado) {
            var estadoCriacao = this.byId(ESTADIOCRIACAO);
            if (estado == null || estado === VAZIO) {
                estadoCriacao.setValueState(ESTADO_ERROR);
                estadoCriacao.setValueStateText(TEXTO_ERRO_ESTADO);
                return false;
            }
            estadoCriacao.setValueState(ESTADO_NONE);
            return true;
        },
        
        validarCobertura: function(cobertura) {
            var botaoSim = this.byId(BOTAO_SIM);
            var botaoNao = this.byId(BOTAO_NAO);
            if (cobertura === undefined) {
                botaoSim.setValueState(ESTADO_ERROR);
                botaoNao.setValueState(ESTADO_ERROR);
                return false;
            }
            botaoSim.setValueState(ESTADO_NONE);
            botaoNao.setValueState(ESTADO_NONE);
            return true;
        },

        resetarItems: function() {
            var inputNome = this.byId(INPUTNOME);
            if (inputNome) {
                inputNome.setValue(VAZIO);
                inputNome.setValueState(ESTADO_NONE);
            }

            var calendarioCriar = this.byId(CALENDARIOCRIAR);
            if (calendarioCriar) {
                calendarioCriar.setDateValue(null);
                calendarioCriar.setValueState(ESTADO_NONE);
            }

            var inputEstadio = this.byId(INPUTESTADIO);
            if (inputEstadio) {
                inputEstadio.setValue(VAZIO);
                inputEstadio.setValueState(ESTADO_NONE);
            }

            var estadoCriacao = this.byId(ESTADIOCRIACAO);
            if (estadoCriacao) {
                estadoCriacao.setSelectedKey(null);
                estadoCriacao.setValueState(ESTADO_NONE);
            }

            var botaoSim = this.byId(BOTAO_SIM);
            if (botaoSim) {
                botaoSim.setSelected(false);
                botaoSim.setValueState(ESTADO_NONE);
            }

            var botaoNao = this.byId(BOTAO_NAO);
            if (botaoNao) {
                botaoNao.setSelected(false);
                botaoNao.setValueState(ESTADO_NONE);
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
                MessageToast.show(MENSAGEM_SUCESSO_CLUBE, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                this.resetarItems();
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

            let mensagemErro = MENSAGEM_ERRO_DESCONHECIDO;
            let detalhesErro = DETALHES_ERRO_INDISPONIVEL;
        
            if (erro.extensions && erro.extensions.fluentValidation) {
                mensagemErro = Object.values(erro.extensions.fluentValidation).join("\r\n");
            } 
            else if (erro.detail) {
                mensagemErro = erro.detail.split(QUEBRADELINHA)[0];
            }
            if (erro.title || erro.Title) {
                detalhesErro = erro.detail;
            }
        
            MessageBox.error(mensagemErro, {
                title: TITULO_ERRO,
                details: detalhesErro,
                actions: [MessageBox.Action.CLOSE]
            });
        }
    });
});
 