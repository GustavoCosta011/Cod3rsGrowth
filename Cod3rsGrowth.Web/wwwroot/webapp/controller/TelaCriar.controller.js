sap.ui.define([
    "./Base",
    "../servico/ClubeServico",
    "../formatter",
    "sap/m/MessageBox",
    "sap/m/MessageToast",
    "sap/ui/model/json/JSONModel"
], (Base, ClubeServico, Formatter, MessageBox, MessageToast, JSONModel) => {
    "use strict";

    const CLUBES = "clube"
    const NUMERO_ZERO = 0;
    const SIM = "Sim";
    const ID = "id";
    const CHAVE_FUNDACAO = "fundacao";
    const CHAVE_ESTADIO = "estadio";
    const CHAVE_NOME = "nome";
    const VALOR_DO_INPUT = "value";
    const ITEMSELECIONADO = "selectedItem";
    const CHAVE_ESTADO = "estado";
    const CHAVE_COBERTURA = "coberturaAntiChuva";
    const PARAMETRO_SELECTEDINDEX = "selectedIndex";
    const INPUTNOME = "InputNome";
    const CALENDARIOCRIAR = "CalendarioCriar";
    const INPUTESTADIO = "InputEstadio";
    const ESTADIOCRIACAO = "EstadoCriacao";
    const BOTAO_SIM = "BotaoSim";
    const BOTAO_NAO = "BotaoNao";
    const STRING_VAZIA = "";
    const NOME_ROTA_CRIAR = "criar";
    const INDICEUM_NO_ARAY = 1;
    const BARRA = "/";
    const QUEBRADELINHA = "\r\n";
    const TITULO_ERRO = "Erro";
    const MENSAGEM_ERRO_DESCONHECIDO = "Erro desconhecido encontrado!";
    const DETALHES_ERRO_INDISPONIVEL = "Stacktrace está indisponível!";
    const MENSAGEM_SUCESSO_CLUBE = "Clube criado com sucesso!";
    const MENSAGEM_SUCESSO_CLUBE_EDITADO = "Clube editado com sucesso!";
    const DURACAO_TOAST = 5000;
    const ESTADO_NONE = "None";
    const ESTADO_ERROR = "Error";
    const DESTINO_VOLTAR = 'clubes';
    const NOME_ROTA_EDITAR = "editar";
    const LIMPAR = "Limpar";
    const ARGUMENTOS_DA_ROTA = "arguments";
    const TEXTO_ERRO_FETCH_CLUBE = "Clube não encontrado";

    return Base.extend("cod3rsgrowth.webapp.controller.TelaCriar", {
        formatter: Formatter,

        onInit: function () {
            this.DadosCriacao = [];
            this.vincularRota(NOME_ROTA_CRIAR, this.aoCoincidirRota);
            this.vincularRota(NOME_ROTA_EDITAR, this.aoCoincidirRotaEditar)
        },

        aoCoincidirRotaEditar: async function(evento){
            try
            {
                await this._aoAdiquirirClube(evento);
                this._salvarModelo();
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },
        
        _aoAdiquirirClube: async function(evento){
            try
            {
                const argumento = evento.getParameter(ARGUMENTOS_DA_ROTA);
                let oView = this.getView();
    
                await ClubeServico.buscarClubePorId(argumento.idClube)
                .then((resposta) => {
                    oView.setModel(new JSONModel(resposta) , CLUBES);
                })
                .catch(() => {
                    MessageBox.error(TEXTO_ERRO_FETCH_CLUBE, {title : TITULO_ERRO});
                });  
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        _salvarModelo: function(){
            const modelo = this._modelo(CLUBES).getData();

            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_NOME);
            this.DadosCriacao.push({ key: CHAVE_NOME, value: modelo.nome});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_FUNDACAO);
            let fundacao = this.formatter.formatDateReverse(this.formatter.formatDate(modelo.fundacao))
            this.DadosCriacao.push({ key: CHAVE_FUNDACAO, value: fundacao });
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_ESTADIO);
            this.DadosCriacao.push({ key: CHAVE_ESTADIO, value: modelo.estadio});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_ESTADO);
            this.DadosCriacao.push({ key: CHAVE_ESTADO, value: modelo.estadoInt});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_COBERTURA);
            this.DadosCriacao.push({ key: CHAVE_COBERTURA, value: modelo.coberturaAntiChuva});
        },

        aoCoincidirRota: function(){
            try
            {
                this._resetarItems();
                this._carregarEstados();
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        aoClicarEmVoltar: function(){
            try
            {
                this._navegarPara(DESTINO_VOLTAR, {Acao : LIMPAR});
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        aoInserirNome: function(oEvent){
            try
            {
                let nome = oEvent.getParameter(VALOR_DO_INPUT);
                this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_NOME);
                if (nome) {
                    this.DadosCriacao.push({ key: CHAVE_NOME, value: nome});
                }
                this._validarNome(nome);
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        aoInserirFundação: function(oEvent){
            try
            {
                let fundacao = oEvent.getParameter(VALOR_DO_INPUT);
                this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_FUNDACAO);
                if(fundacao){
                    let DataFormatada = this.formatter.formatDateReverse(fundacao);
                    this.DadosCriacao.push({key: CHAVE_FUNDACAO, value: DataFormatada});
                }
                this._validarFundacao(fundacao);
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        aoInserirEstadio: function(oEvent){
            try
            {
                let estadio = oEvent.getParameter(VALOR_DO_INPUT);
                this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_ESTADIO);
                if (estadio) {
                    this.DadosCriacao.push({ key: CHAVE_ESTADIO, value: estadio});
                }
                this._validarFundacao(estadio);
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        aoInserirEstadoDeCriação: function(oEvent){
            try
            {
                let estado = oEvent.getParameter(ITEMSELECIONADO).getKey();
                this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_ESTADO);
                if (estado >= NUMERO_ZERO) {
                    this.DadosCriacao.push({ key: CHAVE_ESTADO, value: parseInt(estado, 10)});
                }
                this._validarFundacao(estado);
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        aoInserirCobertura: function(oEvent){
            try
            {
                this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_COBERTURA);
                let selectedIndex = oEvent.getParameter(PARAMETRO_SELECTEDINDEX);
                let grupoDeBotoes = oEvent.getSource();
                let TextoSelecionado = grupoDeBotoes.getButtons()[selectedIndex].getText();
                let cobertura = TextoSelecionado === SIM;
                this.DadosCriacao.push({ key: CHAVE_COBERTURA, value: cobertura});
                this._validarCobertura(cobertura);
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }
        },

        _validarNome: function(nome) {
            let inputNome = this.byId(INPUTNOME);
            if (!nome) {
                inputNome.setValueState(ESTADO_ERROR);
                return false;
            }
            inputNome.setValueState(ESTADO_NONE);
            return true;
        },
        
        _validarFundacao: function(estadio) {
            let inputEstadio = this.byId(INPUTESTADIO);
            if (!estadio) {
                inputEstadio.setValueState(ESTADO_ERROR);
                return false;
            }
            inputEstadio.setValueState(ESTADO_NONE);
            return true;
        },
        
        _validarFundacao: function(data) {
            let calendarioCriar = this.byId(CALENDARIOCRIAR);
            if (!data) {
                calendarioCriar.setValueState(ESTADO_ERROR);
                return false;
            }
            calendarioCriar.setValueState(ESTADO_NONE);
            return true;
        },
        
        _validarFundacao: function(estado) {
            let estadoCriacao = this.byId(ESTADIOCRIACAO);
            if (estado == null || estado === STRING_VAZIA) {
                estadoCriacao.setValueState(ESTADO_ERROR);
                return false;
            }
            estadoCriacao.setValueState(ESTADO_NONE);
            return true;
        },
        
        _validarCobertura: function(cobertura) {
            let botaoSim = this.byId(BOTAO_SIM);
            let botaoNao = this.byId(BOTAO_NAO);
            if (cobertura === undefined) {
                botaoSim.setValueState(ESTADO_ERROR);
                botaoNao.setValueState(ESTADO_ERROR);
                return false;
            }
            botaoSim.setValueState(ESTADO_NONE);
            botaoNao.setValueState(ESTADO_NONE);
            return true;
        },

        _resetarItems: function() {
            let inputNome = this.byId(INPUTNOME);
            if (inputNome) {
                inputNome.setValue(STRING_VAZIA);
                inputNome.setValueState(ESTADO_NONE);
            }

            let calendarioCriar = this.byId(CALENDARIOCRIAR);
            if (calendarioCriar) {
                calendarioCriar.setDateValue(null);
                calendarioCriar.setValueState(ESTADO_NONE);
            }

            let inputEstadio = this.byId(INPUTESTADIO);
            if (inputEstadio) {
                inputEstadio.setValue(STRING_VAZIA);
                inputEstadio.setValueState(ESTADO_NONE);
            }

            let estadoCriacao = this.byId(ESTADIOCRIACAO);
            if (estadoCriacao) {
                estadoCriacao.setSelectedKey(null);
                estadoCriacao.setValueState(ESTADO_NONE);
            }

            let botaoSim = this.byId(BOTAO_SIM);
            if (botaoSim) {
                botaoSim.setSelected(false);
                botaoSim.setValueState(ESTADO_NONE);
            }

            let botaoNao = this.byId(BOTAO_NAO);
            if (botaoNao) {
                botaoNao.setSelected(false);
                botaoNao.setValueState(ESTADO_NONE);
            }
        },

        aoSalvarClube: async function () {
            try
            {
                if (!this._validarCamposPreenchidos()) {
                    return;
                }
                let DadosDaCriação = this._carregarArraydeDados(this.DadosCriacao)
                let hash = this._getRouter().getHashChanger().getHash().split(BARRA)
                await this._criarOuEditarClube(hash, DadosDaCriação);
            }
            catch(erro)
            {
                this._exibirErroNaTela(erro);
            }
        },

        _criarOuEditarClube: async function(hash, dadosDaCriação){
            if(hash [INDICEUM_NO_ARAY] == NOME_ROTA_EDITAR){ 
                let idClube = this._modelo(CLUBES).getData().id;   
                await ClubeServico.editarClube(dadosDaCriação, idClube)
                MessageToast.show(MENSAGEM_SUCESSO_CLUBE_EDITADO, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
            }else{
                await ClubeServico.criarClube(dadosDaCriação);
                MessageToast.show(MENSAGEM_SUCESSO_CLUBE, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                this._resetarItems();
            }
        },

        _carregarArraydeDados: function(dados){
            dados.reduce((newArray, atual) => {
                newArray[atual.key] = atual.value;
                return newArray;
            }, {})
        },


        _validarCamposPreenchidos: function () {
            const nomeValido = this._validarNome(this.byId(INPUTNOME).getValue());
            const estadioValido = this._validarFundacao(this.byId(INPUTESTADIO).getValue());
            const fundacaoValida = this._validarFundacao(this.byId(CALENDARIOCRIAR).getDateValue());
            const estadoValido = this._validarFundacao(this.byId(ESTADIOCRIACAO).getSelectedKey());
            const coberturaValida = this._validarCobertura(this.byId(BOTAO_SIM).getSelected() || this.byId(BOTAO_NAO).getSelected());

            return nomeValido && estadioValido && fundacaoValida && estadoValido && coberturaValida;
        },

        _exibirErroNaTela: function(erro) {  
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
 