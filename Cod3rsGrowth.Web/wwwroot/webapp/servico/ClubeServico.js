sap.ui.define([], () => {
    "use strict";
    const ERROR = 'Erro na requisição da API';
    const NUMZERO = 0;
    const OBTERTODOS = "https://localhost:7178/api/Clubes";
    const OBTERESTADOS = "https://localhost:7178/api/Clubes/estados"; // Endpoint for states

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
