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
    const PERGUNTA_MESSAGE_BOX = "Deseja excluir este clube?";
    const TITULO_CONFIRMAR = "Confirme";
    const NOME_MODELO_NOME_MODELO_JOGADORES = "jogadores";
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

            const argumentos = evento.getParameter(ARGUMENTOS_DA_ROTA);

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
                this._criarModelo(oModel, NOME_MODELO_NOME_MODELO_JOGADORES);
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
            MessageBox.confirm(PERGUNTA_MESSAGE_BOX, {
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
            this._criarModelo(JogadorModelo, NOME_MODELO_JOGADOR);
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
        
        _validarClube: function(Clube) {
            let clubeCriacao = this.byId(ID_CLUBECRIACAO);
            if (Clube == null || Clube === STRING_VAZIA) {
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
            if(hash [INDICEUM_NO_ARRAY_DE_HASHs] == NOME_ROTA_EDITAR){
                try {      
                    let idClube = this._pegarModelo(NOME_MODELO_JOGADOR).getData().id;   
                    await JogadorServico.editarJogador(DadosDaCriação, idClube)
                    MessageToast.show(MENSAGEM_SUCESSO_NOME_MODELO_JOGADOR_EDITADO, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                } 
                catch (erro) {
                    this.exibirErroNaTela(erro);
                }
            }else{
                try {
                    console.log(DadosDaCriação)  
                    await JogadorServico.criarJogador(DadosDaCriação);
                    MessageToast.show(MENSAGEM_SUCESSO_NOME_MODELO_JOGADOR, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
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
            const modelo = this._pegarModelo(NOME_MODELO_JOGADOR).getData();
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
            let inputNome = this.byId(ID_INPUTNOME);
            if (inputNome) {
                inputNome.setValue(STRING_VAZIA);
                inputNome.setValueState(ESTADO_ELEMENTO_NONE);
            }

            let dataDeNascimento = this.byId(ID_CALENDARIOCRIAR);
            if (dataDeNascimento) {
                dataDeNascimento.setDateValue(null);
                dataDeNascimento.setValueState(ESTADO_ELEMENTO_NONE);
            }

            let inputAltura = this.byId(ID_INPUTALTURA);
            if (inputAltura) {
                inputAltura.setValue(STRING_VAZIA);
                inputAltura.setValueState(ESTADO_ELEMENTO_NONE);
            }

            let inputPeso = this.byId(ID_INPUTPESO);
            if (inputPeso) {
                inputPeso.setValue(STRING_VAZIA);
                inputPeso.setValueState(ESTADO_ELEMENTO_NONE);
            }

            let clubeCriacao = this.byId(ID_CLUBECRIACAO);
            if (clubeCriacao) {
                clubeCriacao.setSelectedKey(null);
                clubeCriacao.setValueState(ESTADO_ELEMENTO_NONE);
            }
        }
	});
});