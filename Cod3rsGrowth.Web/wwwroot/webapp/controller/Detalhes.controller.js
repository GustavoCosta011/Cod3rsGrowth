sap.ui.define([
	"./Base",
    "../servico/ClubeServico",
    "../servico/JogadorServico",
    "../formatter",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageToast"

], function (Base, ClubeServico, JogadorServico, Formatter, MessageBox, JSONModel, MessageToast) {
	"use strict";

    const BARRA = "/";
    const CHAVE_CLUBE = "clube";
    const NOME_MODELO_CLUBE = "clube";
    const ROTA_DE_DETALHES = "detalhes";
    const ARGUMENTOS_DA_ROTA = "arguments";
    const DESTINO_VOLTAR = 'clubes';
    const TITULO_ERRO = "Erro";
    const DESTINO_EDITAR = 'editar';
    const PERGUNTA_MESSAGE_BOX_CLUBE = "Deseja excluir este clube?";
    const PERGUNTA_MESSAGE_BOX_JOGADOR = "Deseja excluir este jogador?";
    const TITULO_CONFIRMAR = "Confirme";
    const NOME_MODELO_JOGADORES = "jogadores";
    const NOME_MODELO_JOGADOR = "jogador";
    const CHAVE_NOME = "nome";
    const CHAVE_DATADENASCIMENTO = "dataDeNascimento";
    const CHAVE_ALTURA = "altura";
    const CHAVE_PESO = "peso";
    const CHAVE_IDCLUBE = "idClube";
    const ID_INPUTNOME = "InputNomeJogador";
    const ID_CALENDARIOCRIAR = "CalendarioCriarJogador";
    const ID_INPUTALTURA = "InputAltura";
    const ID_CLUBECRIACAO = "ClubeCriacaoJogador";
    const ID_INPUTPESO = "InputPeso";
    const STRING_VAZIA = "";
    const ESTADO_ELEMENTO_NONE = "None";
    const ESTADO_ELEMENTO_ERROR = "Error";
    const MENSAGEM_SUCESSO_NOME_MODELO_JOGADOR = "Jogador criado com sucesso!";
    const MENSAGEM_SUCESSO_NOME_MODELO_JOGADOR_EDITADO = "Jogador editado com sucesso!";
    const INDICEUM_NO_ARRAY_DE_HASHs = 1;
    const NOME_ROTA_EDITAR = "editar";
    const DURACAO_TOAST = 5000;
    const MENSAGEM_ERRO_DESCONHECIDO = "Erro desconhecido encontrado!";
    const DETALHES_ERRO_INDISPONIVEL = "Stacktrace está indisponível!";
    const QUEBRADELINHA = "\r\n";
    const CHAVE_IDADE = "idade";
    const ID_DO_BOTAO_CRIAR = "BotaoCriarJogador"

	return Base.extend("cod3rsgrowth.webapp.controller.Detalhes", {
        formatter : Formatter,

        onInit: function () {
            this.DadosCriacao = [];
            this.vincularRota(ROTA_DE_DETALHES, this.aoCoincidirRota);
        },
        aoCoincidirRota: function(evento) {
            this._exibirEspera(async () => {
                this._carregarModelo();
                const argumentos = evento.getParameter(ARGUMENTOS_DA_ROTA);
                await this._carregarClube(argumentos.idClube);
                await this._carregarElencoLIsta();
            });
        },

        _atualizarLista: async function(){
            this._exibirEspera(async () => {
                const clube = this._modelo(NOME_MODELO_CLUBE).getData();
                await this._carregarClube(clube.id);
                await this._carregarElencoLIsta();
            });
        },

        _carregarClube: async function(idClube){
            const clube = await ClubeServico.buscarClubePorId(idClube);
            let oModel = new JSONModel(clube);
            this._modeloClube( oModel);
        },

        _carregarElencoLIsta: async function(){
            let elenco = this._modelo(NOME_MODELO_CLUBE).getData().elenco;
            let jogadores = await this._carregarElenco(elenco);
            let oModel = new JSONModel(jogadores);
            this._modeloJogadores( oModel);
        },

        aoClicarEmVoltar: function() {          
            this._exibirEspera(() => this._navegarPara(DESTINO_VOLTAR));
        },

        aoClicarEditar: function() {
            this._exibirEspera(() => {
                this._navegarPara(DESTINO_EDITAR, { idClube: this._modelo(NOME_MODELO_CLUBE).getData().id });
            });
        },

        _carregarElenco: async function(elenco) {
            const jogadores = elenco.map(id => JogadorServico.buscarJogadorPorId(id));
            return await Promise.all(jogadores);
        },

        aoClicarDeletar: function() {
            this._exibirEspera(() => {
                MessageBox.confirm(PERGUNTA_MESSAGE_BOX_CLUBE, {
                    title: TITULO_CONFIRMAR,
                    actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                    onClose: async (oAction) => {
                        if (oAction === MessageBox.Action.YES) {
                            const idDoClube = this._modelo(NOME_MODELO_CLUBE).getData().id;
                            await ClubeServico.deletarClube(idDoClube);
                            this._navegarPara(DESTINO_VOLTAR);
                        }
                    }
                });
            });
        },

        _carregarModelo: function() {
            const JogadorModelo = new JSONModel({
                "nome": "",
                "idClube": null,
                "clube": "",
                "idade": null,
                "dataDeNascimento": null,
                "altura": null,
                "peso": null
            });
            this._modeloJogador( JogadorModelo);
        },

        aoAbrirModalDeCriacao: function(oEvent) {
            this._exibirEspera(async () => {
                let idDoBotao = oEvent.getSource().getId();
                let modeloJogadores = oEvent.getSource().getBindingContext(NOME_MODELO_JOGADORES);
                if (modeloJogadores) {
                    if (!idDoBotao.includes(ID_DO_BOTAO_CRIAR)) {
                        const Modelo = new JSONModel(modeloJogadores.getObject());
                        this._modeloJogador( Modelo);
                    }
                }
            
                if (!this.oDialog) {
                    this.oDialog = await this.loadFragment({ name: "cod3rsgrowth.webapp.view.CriarJogador" });
                }             
                this.oDialog.open();
            });            
        },

        aoFecharModal: function() {
            this._exibirEspera(() => {
                this._carregarModelo();
                this.oDialog.close();
            });
        },

        _validarCamposPreenchidos: function () {
            const nomeValido = this._validarNome(this.byId(ID_INPUTNOME).getValue());
            const estadioValido = this._validarAltura(this.byId(ID_INPUTALTURA).getValue());
            const fundacaoValida = this._validarDataDeNascimento(this.byId(ID_CALENDARIOCRIAR).getDateValue());
            const estadoValido = this._validarClube(this.byId(ID_CLUBECRIACAO).getSelectedKey());
            const coberturaValida = this._validarPeso(this.byId(ID_INPUTPESO).getValue());

            return nomeValido && estadioValido && fundacaoValida && estadoValido && coberturaValida;
        },

        _validarNome: function(nome) {
            let inputNome = this.byId(ID_INPUTNOME);
            if (!nome) {
                inputNome.setValueState(ESTADO_ELEMENTO_ERROR);
                return false;
            }
            inputNome.setValueState(ESTADO_ELEMENTO_NONE);
            return true;
        },
        
        _validarAltura: function(altura) {
            let inputAltura = this.byId(ID_INPUTALTURA);
            if (!altura) {
                inputAltura.setValueState(ESTADO_ELEMENTO_ERROR);
                return false;
            }
            inputAltura.setValueState(ESTADO_ELEMENTO_NONE);
            return true;
        },
        
        _validarDataDeNascimento: function(data) {
            let calendarioCriar = this.byId(ID_CALENDARIOCRIAR);
            if (!data) {
                calendarioCriar.setValueState(ESTADO_ELEMENTO_ERROR);
                return false;
            }
            calendarioCriar.setValueState(ESTADO_ELEMENTO_NONE);
            return true;
        },
        
        _validarClube: function(clube) {
            let clubeCriacao = this.byId(ID_CLUBECRIACAO);
            if (clube == null || clube === STRING_VAZIA) {
                clubeCriacao.setValueState(ESTADO_ELEMENTO_ERROR);
                return false;
            }
            clubeCriacao.setValueState(ESTADO_ELEMENTO_NONE);
            return true;
        },
        
        _validarPeso: function(peso) {
            let inputPeso = this.byId(ID_INPUTPESO);
            if (!peso) {
                inputPeso.setValueState(ESTADO_ELEMENTO_ERROR);
                return false;
            }
            inputPeso.setValueState(ESTADO_ELEMENTO_NONE);
            return true;
        },

        aoSalvarJogador: function() {
            this._exibirEspera(async () => {
                if (!this._validarCamposPreenchidos()) return;
                let id = this._modelo(NOME_MODELO_JOGADOR).getData().id; 
                this._SalvarDados(id);
                let DadosDaCriação = this._carregarArraydeDados(this.DadosCriacao);
                let hash = this._getRouter().getHashChanger().getHash().split(BARRA);

                await this._criarOuEditarJogador(hash, DadosDaCriação);
            });
        },

        aoDeletarJogador: function(evento){
            this._exibirEspera(async() => {
                MessageBox.confirm(PERGUNTA_MESSAGE_BOX_JOGADOR, {
                    title: TITULO_CONFIRMAR,
                    actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                    onClose: async (oAction) => {
                        if (oAction === MessageBox.Action.YES) {
                            const path = evento.getParameter("listItem").getBindingContext(NOME_MODELO_JOGADORES).getPath().split(BARRA)[1]
                            const idDoJogador = evento.getParameter("listItem").getBindingContext(NOME_MODELO_JOGADORES).getModel().getData()[path].id
                            console.log(idDoJogador)
                            await JogadorServico.deletarJogador(idDoJogador);
                            this._atualizarLista()
                        }
                    }
                });
            })
        },

        _criarOuEditarJogador: async function(hash, DadosDaCriação){
            let id = this._modelo(NOME_MODELO_JOGADOR).getData().id;  
            if(id){
                let idJogador = this._modelo(NOME_MODELO_JOGADOR).getData().id;   
                await JogadorServico.editarJogador(DadosDaCriação, idJogador)
                MessageToast.show(MENSAGEM_SUCESSO_NOME_MODELO_JOGADOR_EDITADO, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                await this._atualizarLista();
            }else{
                await JogadorServico.criarJogador(DadosDaCriação);
                MessageToast.show(MENSAGEM_SUCESSO_NOME_MODELO_JOGADOR, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                this.aoFecharModal();
                await this._atualizarLista();
            }
        },

        _carregarArraydeDados: function(dados){
            return dados.reduce((newArray, atual) => {
                newArray[atual.key] = atual.value;
                return newArray;
            }, {})
        },

        _SalvarDados:function(){
            const modelo = this._modelo(NOME_MODELO_JOGADOR).getData();
            let clube = this.byId(ID_CLUBECRIACAO).getValue()
            let data = this.formatter.formatDateReverse(this.byId(ID_CALENDARIOCRIAR).getDateValue()); 
            let hoje = new Date();
            let dataNascimento = new Date(data);
            let idade = hoje.getFullYear() - dataNascimento.getFullYear();
            let mes = hoje.getMonth() - dataNascimento.getMonth();  
            if (mes < 0 || (mes === 0 && hoje.getDate() < dataNascimento.getDate())) {
                idade--;
            }

            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_NOME);
            this.DadosCriacao.push({ key: CHAVE_NOME, value: modelo.nome});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_IDCLUBE);
            this.DadosCriacao.push({ key: CHAVE_IDCLUBE, value: modelo.idClube});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_CLUBE);
            this.DadosCriacao.push({ key: CHAVE_CLUBE, value: clube});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_IDADE);
            this.DadosCriacao.push({ key: CHAVE_IDADE, value: idade});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_DATADENASCIMENTO);
            this.DadosCriacao.push({ key: CHAVE_DATADENASCIMENTO, value: data});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_ALTURA);
            this.DadosCriacao.push({ key: CHAVE_ALTURA, value: modelo.altura});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CHAVE_PESO);
            this.DadosCriacao.push({ key: CHAVE_PESO, value: modelo.peso});
        }
	});
});