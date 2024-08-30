sap.ui.define([], () => {
    "use strict";
    const OBTERTODOS = "https://localhost:7178/api/Jogadores";

    return {
        aoBuscarJogadorPorId: async function (IdDoJogador){            
            this.urlJogadores = OBTERTODOS + "/" + IdDoJogador;
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

        aoCriarJogador: async function(DadosCriacao) {
            try {
                const resposta = await fetch(new URL(OBTERTODOS), {
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

        aoEditarJogador: async function(DadosEdição, IdDoJogador){
            this.urlJogadores = OBTERTODOS + "/" + IdDoJogador;
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

        aoDeletarJogador: async function(IdDoJogador) {
            this.urlJogadores = OBTERTODOS + "/" + IdDoJogador;

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
