sap.ui.define([], () => {
    "use strict";
    const ERROR = 'Erro na requisição da API';
    const NUMZERO = 0;
    const OBTERTODOS = "api/Clubes";
    const OBTERESTADOS = "api/Clubes/estados";

    return {
        buscarClubes: function(filtros) {
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

        editarClube: async function(DadosEdição, idClube){
            this.urlClubes = OBTERTODOS + "/" + idClube;
            console.log(this.urlClubes)

            return await fetch(this.urlClubes, {
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

        criarClube: async function(DadosCriacao) {
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

        buscarClubePorId: async function (idClube){            
            this.urlClubes = OBTERTODOS + "/" + idClube;
            return fetch(this.urlClubes, {
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

        buscarEstados: async function() {
            try {
                const resposta = await fetch(OBTERESTADOS, {
                    method: "GET",
                    headers: { "Content-Type": "application/json" },
                });
                
                if (!resposta.ok) {
                    const erro = await resposta.json();
                    throw erro;
                }
                return await resposta.json();
            } 
            catch (erro) {
                throw erro;             
            }
        },

        deletarClube: async function(idDoClube) {
            this.urlClubes = OBTERTODOS + "/" + idDoClube;

            return await fetch(this.urlClubes, {
                method: "DELETE",
                headers: { "Content-Type": "application/json" },
            }) 
            .then(async resposta => {
                let response = await resposta.json(); 
                console.log(response)
                if(response.status == 400){
                    throw response   
                }
                return response             
            })
        }
    }
});
