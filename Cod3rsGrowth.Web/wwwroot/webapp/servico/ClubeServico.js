sap.ui.define([
], () => {
    "use strict";
    const ERROR = 'Erro na requisição da API';
    const NUMZERO = 0;
    return {
        aoBuscar: function(filtros) {
			this.urlClubes = "https://localhost:7178/api/Clubes";
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
        aoCriarClube: function(DadosCriacao) {
			 this.urlClubes = "https://localhost:7178/api/Clubes";

            return fetch(this.urlClubes, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DadosCriacao)
                
            }) 
            .then(resposta => {
                if (resposta.ok) {
                    return resposta.json();
                } 
                throw new Error(ERROR);                
            })
            .catch(error => {
                console.error('Erro:', error);
                console.log(JSON.stringify(DadosCriacao))
            });
        }
    }
});