sap.ui.define([
    "../../common/Base",
    "../../common/servico/ClubeServico",
    "../../models/formatter",
    "sap/m/MessageBox",
    "sap/m/MessageToast",
    "sap/ui/model/json/JSONModel"
], (Base, ClubeServico, Formatter, MessageBox, MessageToast, JSONModel) => {
    "use strict";

    const NOME_MODELO_CLUBE = "clube"
    const NUMERO_ZERO = 0;
    const SIM = "Sim";
    const ID = "id";
    const CHAVE_FUNDACAO = "fundacao";
    const CHAVE_ESTADIO = "estadio";
    const CHAVE_NOME = "nome";
    const VALOR_DO_INPUT = "value";
    const KEYSELECIONADA = "selectedKey";
    const CHAVE_ESTADO = "estado";
    const CHAVE_COBERTURA = "coberturaAntiChuva";
    const PARAMETRO_SELECTEDINDEX = "selectedIndex";
    const INPUTNOME = "InputNomeCriar";
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
    const DETALHES = "detalhes"

    return Base.extend("cod3rsgrowth.webapp.clube.formulario.TelaCriar", {
        formatter: Formatter,

        onInit: function () {
            this.DadosCriacao = [];
            this.vincularRota(NOME_ROTA_CRIAR, this.aoCoincidirRota);
            this.vincularRota(NOME_ROTA_EDITAR, this.aoCoincidirRotaEditar)
        },

        aoCoincidirRotaEditar: async function(evento){
            this._exibirEspera(async () => {
                await this._aoAdiquirirClube(evento);
            });
        },
        
        _aoAdiquirirClube: async function(evento){
            this._exibirEspera(async () => {

                const argumento = evento.getParameter(ARGUMENTOS_DA_ROTA);
    
                await ClubeServico.buscarClubePorId(argumento.idClube)
                .then((resposta) => {
                    const modelo = new JSONModel(resposta)
                    this._modeloClube(modelo);
                })
                .catch(() => {
                    MessageBox.error(TEXTO_ERRO_FETCH_CLUBE, {title : TITULO_ERRO});
                });  
                this._salvarModelo();
            });
        },

        _salvarModelo: function(){
            const modelo = this._modeloClube().getData();

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

        aoCoincidirRota: function() {
            this._exibirEspera(async () => {
                this._resetarItems();
                await this._carregarEstados();
            });
        },

        aoClicarEmVoltar: function(){
            this._exibirEspera(async () => {
                this._navegarPara(DESTINO_VOLTAR, {Acao: LIMPAR});
            });
        },

        aoInserirNome: function(oEvent) {
            this._exibirEspera(async () => {
                let nome = oEvent.getParameter(VALOR_DO_INPUT);
                this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_NOME);
                if (nome) {
                    this.DadosCriacao.push({ key: CHAVE_NOME, value: nome });
                }
                this._validarNome(nome);
            });
        },
        
        aoInserirFundacao: function(oEvent) {
            this._exibirEspera(async () => {
                let fundacao = oEvent.getParameter(VALOR_DO_INPUT);
                this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_FUNDACAO);
                if (fundacao) {
                    let DataFormatada = this.formatter.formatDateReverse(fundacao);
                    this.DadosCriacao.push({ key: CHAVE_FUNDACAO, value: DataFormatada });
                }
                this._validarFundacao(fundacao);
            });
        },
        
        aoInserirEstadio: function(oEvent) {
            this._exibirEspera(async () => {
                let estadio = oEvent.getParameter(VALOR_DO_INPUT);
                this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_ESTADIO);
                if (estadio) {
                    this.DadosCriacao.push({ key: CHAVE_ESTADIO, value: estadio });
                }
                this._validarEstadio(estadio);
            });
        },
        
        aoInserirEstadoDeCriacao: function(oEvent) {
            this._exibirEspera(async () => {
                let calendario = oEvent.getSource()
                let estado = calendario.getProperty(KEYSELECIONADA)
                if(estado){
                    this._validarEstado(estado);
                    this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_ESTADO);
                    if (estado >= NUMERO_ZERO) {
                        this.DadosCriacao.push({ key: CHAVE_ESTADO, value: parseInt(estado, 10) });
                    }
                }
                this._validarEstado(estado);
            });
        },
        
        aoInserirCobertura: function(oEvent) {
            this._exibirEspera(async () => {
                this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_COBERTURA);
                let selectedIndex = oEvent.getParameter(PARAMETRO_SELECTEDINDEX);
                let grupoDeBotoes = oEvent.getSource();
                let TextoSelecionado = grupoDeBotoes.getButtons()[selectedIndex].getText();
                let cobertura = TextoSelecionado === SIM;
                this.DadosCriacao.push({ key: CHAVE_COBERTURA, value: cobertura });
                this._validarCobertura(cobertura);
            });
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
        
        _validarEstadio: function(estadio) {
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
        
        _validarEstado: function(estado) {
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
            this._exibirEspera(async () => {
                
                if (!this._validarCamposPreenchidos()) {
                    return;
                }
                var dadosDaCriacao = this._carregarArraydeDados(this.DadosCriacao);
                let hash = this._getRouter().getHashChanger().getHash().split(BARRA);
                await this._criarOuEditarClube(hash, dadosDaCriacao);
            });
        },
        
        _criarOuEditarClube: async function(hash, dadosDaCriacao) {
            if (hash[INDICEUM_NO_ARAY] == NOME_ROTA_EDITAR) {
                let idClube = this._modeloClube().getData().id;
                let resposta = await ClubeServico.editarClube(dadosDaCriacao, idClube);
                MessageToast.show(MENSAGEM_SUCESSO_CLUBE_EDITADO, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                this._navegarPara(DETALHES, { idClube: resposta});
            } else {
                let resposta = await ClubeServico.criarClube(dadosDaCriacao);
                MessageToast.show(MENSAGEM_SUCESSO_CLUBE, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                this._navegarPara(DETALHES, { idClube: resposta});
            }
        },

        _carregarArraydeDados: function(dados){
            return dados.reduce((newArray, atual) => {
                newArray[atual.key] = atual.value;
                return newArray;
            }, {});
        },


        _validarCamposPreenchidos: function () {
            const nomeValido = this._validarNome(this.byId(INPUTNOME).getValue());
            const estadioValido = this._validarEstadio(this.byId(INPUTESTADIO).getValue());
            const fundacaoValida = this._validarFundacao(this.byId(CALENDARIOCRIAR).getDateValue());
            const estadoValido = this._validarEstado(this.byId(ESTADIOCRIACAO).getSelectedKey());
            const coberturaValida = this._validarCobertura(this.byId(BOTAO_SIM).getSelected() || this.byId(BOTAO_NAO).getSelected());

            return nomeValido && estadioValido && fundacaoValida && estadoValido && coberturaValida;
        },
    });
});
 