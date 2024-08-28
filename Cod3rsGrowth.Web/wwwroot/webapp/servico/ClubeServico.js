sap.ui.define([], () => {
    "use strict";
    const ERROR = 'Erro na requisição da API';
    const NUMZERO = 0;
    const OBTERTODOS = "https://localhost:7178/api/Clubes";
    const OBTERESTADOS = "https://localhost:7178/api/Clubes/estados";

    return {
        aoBuscar: function(filtros) {
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

        aoEditarClube: async function(DadosEdição, idClube){
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

        aoCriarClube: async function(DadosCriacao) {
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

        aoBuscarClubePorId: async function (idClube){            
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
            .catch(error => {
                console.error('Erro:', error);
            });
        },

        aoBuscarEstados: async function() {
            try {
                const resposta = await fetch(new URL(OBTERESTADOS), {
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
        }
    }
});
