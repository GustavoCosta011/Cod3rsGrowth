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
    const DETALHES = "detalhes";
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
    const TEXTO_ERRO_NOME = "Campo 'Nome' precisa ser preenchido.";
    const TEXTO_ERRO_ALTURA = "Campo 'Altura' precisa ser preenchido.";
    const TEXTO_ERRO_NASCIMENTO = "Campo 'Data de Nascimento' precisa ser preenchido.";
    const TEXTO_ERRO_CLUBE = "Campo 'Clube' precisa ser preenchido.";
    const TEXTO_ERRO_PESO = "Campo 'Peso' precisa ser preenchido.";
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
        formatter: Formatter,
        clubeServico : ClubeServico,
        jogadorServico : JogadorServico,

        onInit: function () {
            this.DadosCriacao = [];
            this._vincularRota(DETALHES, this.aoCoincidirRota);
        },
        aoCoincidirRota : async function(evento){
            this.carregarModelo();
            const argumentos = evento.getParameter(ARGUMENTS);

            await this.clubeServico.aoBuscarClubePorId(argumentos.idClube)
            .then((clube) => {
                var oModel = new JSONModel(clube);
                this.getView().setModel(oModel, CLUBE);
            })
            .catch((error) => {
                MessageBox.error(error, {title : TITULO_ERRO});
            });

            var elenco =  this.getView().getModel(CLUBE).getData().elenco

            await this.aoCarregarElenco(elenco)
            .then((jogador) =>{
                var oModel = new JSONModel(jogador);
                this.getView().setModel(oModel, JOGADORES);
            })
            .catch((error) => {
                MessageBox.error(error, {title : TITULO_ERRO});
            });
        },
        aoClicarEmVoltar: function(){
            this.navegarPara(DESTINO_VOLTAR);
        },
        aoClicarEditar: function(){
            this.navegarPara(DESTINO_EDITAR,{ idClube : this.getView().getModel(CLUBE).getData().id})
        },
        aoCarregarElenco: async function (elenco) {
            const jogadores = elenco.map( id => { 
                return this.jogadorServico.aoBuscarJogadorPorId(id);
            });
            return await Promise.all(jogadores);
        },
        aoClicarDeletar: function(){
            MessageBox.confirm(PERGUNTA, {
                title: TITULO_CONFIRMAR,
                actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                onClose: async (oAction) => {
                    if (oAction === MessageBox.Action.YES) {
                        const idDoClube = this.getView().getModel(CLUBE).getData().id;
                        await this.clubeServico.aoDeletarClube(idDoClube);
                        this.aoClicarEmVoltar();
                    } else if (oAction === MessageBox.Action.NO) {
                        MessageBox.close();
                    }
                }
            });
        },

        carregarModelo: function() {
            const JogadorModelo = new JSONModel({
                "nome": "",
                "idClube": null,
                "clube": "",
                "idade": null,
                "dataDeNascimento": null,
                "altura": null,
                "peso": null
            });
            this.getView().setModel(JogadorModelo, JOGADOR);
        },
        async aoAbrirModalDeCriacao() {           
            this.oDialog ??= await this.loadFragment({
                name: "cod3rsgrowth.webapp.view.CriarJogador"
            });
        
            this.oDialog.open();
        },
        aoFecharModal:function (){
            this.resetarItems();
            this.oDialog.close();
        },

        validarCamposPreenchidos: function () {
            const nomeValido = this.validarNome(this.byId(INPUTNOME).getValue());
            const estadioValido = this.validarAltura(this.byId(INPUTALTURA).getValue());
            const fundacaoValida = this.validarDataDeNascimento(this.byId(CALENDARIOCRIAR).getDateValue());
            const estadoValido = this.validarEstado(this.byId(CLUBECRIACAO).getSelectedKey());
            const coberturaValida = this.validarPeso(this.byId(INPUTPESO).getValue());

            return nomeValido && estadioValido && fundacaoValida && estadoValido && coberturaValida;
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
        
        validarAltura: function(altura) {
            var inputAltura = this.byId(INPUTALTURA);
            if (!altura) {
                inputAltura.setValueState(ESTADO_ERROR);
                inputAltura.setValueStateText(TEXTO_ERRO_ALTURA);
                return false;
            }
            inputAltura.setValueState(ESTADO_NONE);
            return true;
        },
        
        validarDataDeNascimento: function(data) {
            var calendarioCriar = this.byId(CALENDARIOCRIAR);
            if (!data) {
                calendarioCriar.setValueState(ESTADO_ERROR);
                calendarioCriar.setValueStateText(TEXTO_ERRO_NASCIMENTO);
                return false;
            }
            calendarioCriar.setValueState(ESTADO_NONE);
            return true;
        },
        
        validarEstado: function(estado) {
            var clubeCriacao = this.byId(CLUBECRIACAO);
            if (estado == null || estado === VAZIO) {
                clubeCriacao.setValueState(ESTADO_ERROR);
                clubeCriacao.setValueStateText(TEXTO_ERRO_CLUBE);
                return false;
            }
            clubeCriacao.setValueState(ESTADO_NONE);
            return true;
        },
        
        validarPeso: function(peso) {
            var inputPeso = this.byId(INPUTPESO);
            if (!peso) {
                inputPeso.setValueState(ESTADO_ERROR);
                inputPeso.setValueStateText(TEXTO_ERRO_PESO);
                return false;
            }
            inputPeso.setValueState(ESTADO_NONE);
            return true;
        },

        aoSalvarJogador: async function(){
            if (!this.validarCamposPreenchidos()) {
                return;
            }
            this.aoSalvarDados();
            var DadosDaCriação = this.DadosCriacao.reduce((newArray, atual) => {
                newArray[atual.key] = atual.value;
                return newArray;
            }, {})
            var hash = this._getRouter().getHashChanger().getHash().split(BARRA)
            if(hash [INDICEUM] == EDITAR){
                try {      
                    var idClube = this.getView().getModel(JOGADOR).getData().id;   
                    await this.jogadorServico.aoEditarJogador(DadosDaCriação, idClube)
                    MessageToast.show(MENSAGEM_SUCESSO_JOGADOR_EDITADO, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                    this.aoFecharModal();
                } 
                catch (erro) {
                    this.exibirErroNaTela(erro);
                }
            }else{
                try {
                    console.log(DadosDaCriação)  
                    await this.jogadorServico.aoCriarJogador(DadosDaCriação);
                    MessageToast.show(MENSAGEM_SUCESSO_JOGADOR, { duration: DURACAO_TOAST, closeOnBrowserNavigation: false });
                    this.aoFecharModal();
                } 
                catch (erro) {
                    this.exibirErroNaTela(erro);
                }
            }
        },

        aoSalvarDados:function(){
            const modelo = this.getView().getModel(JOGADOR).getData();
            var clube = this.byId(CLUBECRIACAO).getValue()
            var data = this.formatter.formatDateReverse(this.byId(CALENDARIOCRIAR).getDateValue()); 
            var hoje = new Date();
            var dataNascimento = new Date(data);
            var idade = hoje.getFullYear() - dataNascimento.getFullYear();
            var mes = hoje.getMonth() - dataNascimento.getMonth();  
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

            var inputEstadio = this.byId(INPUTALTURA);
            if (inputEstadio) {
                inputEstadio.setValue(VAZIO);
                inputEstadio.setValueState(ESTADO_NONE);
            }

            var inputEstadio = this.byId(INPUTPESO);
            if (inputEstadio) {
                inputEstadio.setValue(VAZIO);
                inputEstadio.setValueState(ESTADO_NONE);
            }

            var estadoCriacao = this.byId(CLUBECRIACAO);
            if (estadoCriacao) {
                estadoCriacao.setSelectedKey(null);
                estadoCriacao.setValueState(ESTADO_NONE);
            }
        }
	});
});