sap.ui.define([], () => {
    "use strict";
    const OBTERTODOS = "/api/Jogadores";
    const NUMZERO = 0;

    return {
        buscarJogadores: function(filtros) {
            this.urlClubes = OBTERTODOS;
            if (filtros.length > NUMZERO) {
                this.urlClubes += "?" + filtros.map(filtro => `${filtro.key}=${filtro.value}`).join("&");
            }

            return fetch(this.urlClubes, {
                method: "GET",
                headers: { "Content-Type": "application/json" },
            }) 
            .then(resposta => {
                if (resposta.ok) {
                    return resposta.json();
                } 
                throw new Error(ERROR);                
            })
            .catch(error => {
                console.error('Erro:', error);
            });
        },

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

        editarJogador: async function(DadosEdicao, idDoJogador){
            this.urlJogadores = OBTERTODOS + "/" + idDoJogador;
            return await fetch(this.urlJogadores, {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DadosEdicao)
            }) 
            .then(async resposta => {
                let response = await resposta.json(); 
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
