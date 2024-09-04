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
    const CLUBE = "clube";
    const NOME_MODELO_CLUBE = "clube";
    const ROTA_DE_DETALHES = "detalhes";
    const ARGUMENTS = "arguments";
    const DESTINO_VOLTAR = 'clubes';
    const TITULO_ERRO = "Erro";
    const DESTINO_EDITAR = 'editar';
    const PERGUNTA = "Deseja excluir este clube?";
    const TITULO_CONFIRMAR = "Confirme";
    const JOGADORES = "jogadores";
    const JOGADOR = "jogador";
    const NOME = "nome";
    const DATADENASCIMENTO = "dataDeNascimento";
    const ALTURA = "altura";
    const PESO = "peso";
    const IDCLUBE = "idClube";
    const INPUTNOME = "InputNomeJogador";
    const CALENDARIOCRIAR = "CalendarioCriarJogador";
    const INPUTALTURA = "InputAltura";
    const CLUBECRIACAO = "ClubeCriacaoJogador";
    const INPUTPESO = "InputPeso";
    const VAZIO = "";
    const ESTADO_NONE = "None";
    const ESTADO_ERROR = "Error";
    const MENSAGEM_SUCESSO_JOGADOR = "Jogador criado com sucesso!";
    const MENSAGEM_SUCESSO_JOGADOR_EDITADO = "Jogador editado com sucesso!";
    const INDICEUM = 1;
    const EDITAR = "editar";
    const DURACAO_TOAST = 5000;
    const MENSAGEM_ERRO_DESCONHECIDO = "Erro desconhecido encontrado!";
    const DETALHES_ERRO_INDISPONIVEL = "Stacktrace está indisponível!";
    const QUEBRADELINHA = "\r\n";
    const IDADE = "idade";

	return Base.extend("cod3rsgrowth.webapp.controller.Detalhes", {
        formatter : Formatter,

        onInit: function () {
            this.DadosCriacao = [];
            this._vincularRota(ROTA_DE_DETALHES, this.aoCoincidirRota);
        },
        aoCoincidirRota : async function(evento){
            try
            {
                this._carregarModelo();
            }
            catch(erro)
            {
                MessageBox.error(erro, {title : TITULO_ERRO});
            }

            const argumentos = evento.getParameter(ARGUMENTS);

            await ClubeServico.buscarClubePorId(argumentos.idClube)
            .then((clube) => {
                let oModel = new JSONModel(clube);
                this._criarModelo(oModel, NOME_MODELO_CLUBE);
            })
            .catch((error) => {
                MessageBox.error(error, {title : TITULO_ERRO});
            });
            let elenco =  this._pegarModelo(NOME_MODELO_CLUBE).getData().elenco

            await this._aoCarregarElenco(elenco)
            .then((jogador) =>{
                let oModel = new JSONModel(jogador);
                this._criarModelo(oModel, JOGADORES);
            })
            .catch((error) => {
                MessageBox.error(error, {title : TITULO_ERRO});
            });
        },
        aoClicarEmVoltar: function(){
            this._navegarPara(DESTINO_VOLTAR);
        },
        aoClicarEditar: function(){
            this._navegarPara(DESTINO_EDITAR,{ idClube : this._pegarModelo(NOME_MODELO_CLUBE).getData().id})
        },
        _aoCarregarElenco: async function (elenco) {
            const jogadores = elenco.map( id => { 
                return JogadorServico.buscarJogadorPorId(id);
            });
            return await Promise.all(jogadores);
        },
        aoClicarDeletar: function(){
            MessageBox.confirm(PERGUNTA, {
                title: TITULO_CONFIRMAR,
                actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                onClose: async (oAction) => {
                    if (oAction === MessageBox.Action.YES) {
                        const idDoClube = this._pegarModelo(NOME_MODELO_CLUBE).getData().id;
                        await ClubeServico.deletarClube(idDoClube);
                        this._navegarPara(DESTINO_VOLTAR)
                    } else if (oAction === MessageBox.Action.NO) {
                        MessageBox.close();
                    }
                }
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
            this._criarModelo(JogadorModelo, JOGADOR);
        },

        async aoAbrirModalDeCriacao() {           
            this.oDialog ??= await this.loadFragment({
                name: "cod3rsgrowth.webapp.view.CriarJogador"
            });
        
            this.oDialog.open();
        },

        aoFecharModal:function (){
            this._resetarItems();
            this.oDialog.close();
        },

        _validarCamposPreenchidos: function () {
            const nomeValido = this._validarNome(this.byId(INPUTNOME).getValue());
            const estadioValido = this._validarAltura(this.byId(INPUTALTURA).getValue());
            const fundacaoValida = this._validarDataDeNascimento(this.byId(CALENDARIOCRIAR).getDateValue());
            const estadoValido = this._validarClube(this.byId(CLUBECRIACAO).getSelectedKey());
            const coberturaValida = this._validarPeso(this.byId(INPUTPESO).getValue());

            return nomeValido && estadioValido && fundacaoValida && estadoValido && coberturaValida;
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
        
        _validarAltura: function(altura) {
            let inputAltura = this.byId(INPUTALTURA);
            if (!altura) {
                inputAltura.setValueState(ESTADO_ERROR);
                return false;
            }
            inputAltura.setValueState(ESTADO_NONE);
            return true;
        },
        
        _validarDataDeNascimento: function(data) {
            let calendarioCriar = this.byId(CALENDARIOCRIAR);
            if (!data) {
                calendarioCriar.setValueState(ESTADO_ERROR);
                return false;
            }
            calendarioCriar.setValueState(ESTADO_NONE);
            return true;
        },
        
        _validarClube: function(Clube) {
            let clubeCriacao = this.byId(CLUBECRIACAO);
            if (Clube == null || Clube === VAZIO) {
                clubeCriacao.setValueState(ESTADO_ERROR);
                return false;
            }
            clubeCriacao.setValueState(ESTADO_NONE);
            return true;
        },
        
        _validarPeso: function(peso) {
            let inputPeso = this.byId(INPUTPESO);
            if (!peso) {
                inputPeso.setValueState(ESTADO_ERROR);
                return false;
            }
            inputPeso.setValueState(ESTADO_NONE);
            return true;
        },

       aoSalvarJogador: async function(){
            if (!this._validarCamposPreenchidos()) {
                return;
            }
            this.aoSalvarDados();
            let DadosDaCriação = this._carregarArraydeDados(this.DadosCriacao)
            let hash = this._getRouter().getHashChanger().getHash().split(BARRA)
            await this._CriarOuEditarJogador(hash, DadosDaCriação);
        },

        _CriarOuEditarJogador: async function(hash, DadosDaCriação){
            if(hash [INDICEUM] == EDITAR){
                try {      
                    let idClube = this._pegarModelo(JOGADOR).getData().id;   
                    await JogadorServico.editarJogador(DadosDaCriação, idClube)
                    MessageToast.show(MENSAGEM_SUCESSO_JOGADOR_EDITADO, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                } 
                catch (erro) {
                    this.exibirErroNaTela(erro);
                }
            }else{
                try {
                    console.log(DadosDaCriação)  
                    await JogadorServico.criarJogador(DadosDaCriação);
                    MessageToast.show(MENSAGEM_SUCESSO_JOGADOR, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                    this.aoFecharModal();
                } 
                catch (erro) {
                    this.exibirErroNaTela(erro);
                }
            }
        },

        _carregarArraydeDados: function(dados){
            dados.reduce((newArray, atual) => {
                newArray[atual.key] = atual.value;
                return newArray;
            }, {})
        },

        aoSalvarDados:function(){
            const modelo = this._pegarModelo(JOGADOR).getData();
            let clube = this.byId(CLUBECRIACAO).getValue()
            let data = this.formatter.formatDateReverse(this.byId(CALENDARIOCRIAR).getDateValue()); 
            let hoje = new Date();
            let dataNascimento = new Date(data);
            let idade = hoje.getFullYear() - dataNascimento.getFullYear();
            let mes = hoje.getMonth() - dataNascimento.getMonth();  
            if (mes < 0 || (mes === 0 && hoje.getDate() < dataNascimento.getDate())) {
                idade--;
            }

            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== NOME);
            this.DadosCriacao.push({ key: NOME, value: modelo.nome});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== IDCLUBE);
            this.DadosCriacao.push({ key: IDCLUBE, value: modelo.idClube});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== CLUBE);
            this.DadosCriacao.push({ key: CLUBE, value: clube});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== IDADE);
            this.DadosCriacao.push({ key: IDADE, value: idade});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== DATADENASCIMENTO);
            this.DadosCriacao.push({ key: DATADENASCIMENTO, value: data});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== ALTURA);
            this.DadosCriacao.push({ key: ALTURA, value: modelo.altura});
            this.DadosCriacao = this.DadosCriacao.filter(f => f.key !== PESO);
            this.DadosCriacao.push({ key: PESO, value: modelo.peso});
        },

        exibirErroNaTela: function(erro) { 
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
        },

        _resetarItems: function() {
            let inputNome = this.byId(INPUTNOME);
            if (inputNome) {
                inputNome.setValue(VAZIO);
                inputNome.setValueState(ESTADO_NONE);
            }

            let dataDeNascimento = this.byId(CALENDARIOCRIAR);
            if (dataDeNascimento) {
                dataDeNascimento.setDateValue(null);
                dataDeNascimento.setValueState(ESTADO_NONE);
            }

            let inputAltura = this.byId(INPUTALTURA);
            if (inputAltura) {
                inputAltura.setValue(VAZIO);
                inputAltura.setValueState(ESTADO_NONE);
            }

            let inputPeso = this.byId(INPUTPESO);
            if (inputPeso) {
                inputPeso.setValue(VAZIO);
                inputPeso.setValueState(ESTADO_NONE);
            }

            let clubeCriacao = this.byId(CLUBECRIACAO);
            if (clubeCriacao) {
                clubeCriacao.setSelectedKey(null);
                clubeCriacao.setValueState(ESTADO_NONE);
            }
        }
	});
});