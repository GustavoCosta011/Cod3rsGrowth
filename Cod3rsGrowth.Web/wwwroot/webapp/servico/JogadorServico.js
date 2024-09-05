sap.ui.define([], () => {
    "use strict";
    const OBTERTODOS = "api/Jogadores";

    return {
        buscarJogadorPorId: async function (idDoJogador){            
            this.urlJogadores = OBTERTODOS + "/" + idDoJogador;
            return fetch(this.urlJogadores, {
                method: "GET",
                headers: { "Content-Type": "application/json" },
            }) 
            .then(async resposta => {
                if (resposta.ok) {
                    return await resposta.json();
                } 
                throw resposta;                
            })
        },

        criarJogador: async function(DadosCriacao) {
            try {
                const resposta = await fetch(OBTERTODOS, {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(DadosCriacao)
                });
                
                if (!resposta.ok) {
                    const erro =  await resposta.json();
                    throw erro;
                }
                return await resposta.json();
            } 
            catch (erro) {
                throw erro;             
            }
        },

        editarJogador: async function(DadosEdição, idDoJogador){
            this.urlJogadores = OBTERTODOS + "/" + idDoJogador;
            console.log(this.urlJogadores)

            return await fetch(this.urlJogadores, {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DadosEdição)
            }) 
            .then(async resposta => {
                let response = await resposta.json(); 
                console.log(response)
                if(response.status == 400){
                    throw response   
                }
                return response             
            })
        },

        deletarJogador: async function(idDoJogador) {
            this.urlJogadores = OBTERTODOS + "/" + idDoJogador;

            return await fetch(this.urlJogadores, {
                method: "DELETE",
                headers: { "Content-Type": "application/json" },
            }) 
            .then(async resposta => {
                let response = await resposta.json(); 
                if(response.status == 400){
                    throw response   
                }
                return response             
            })
        }
    }
});
