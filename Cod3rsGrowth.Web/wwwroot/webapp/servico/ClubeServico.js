sap.ui.define([
    "sap/ui/model/json/JSONModel"
], (JSONModel) => {
    "use strict";
    const ERRROR = 'Erro na requisição da API';
    return {
        aoBuscar: function(filtros) {
			this.urlClubes = "https://localhost:7178/api/Clubes";
            if (filtros.length > 0) {
                this.urlClubes += "?" + filtros.map(filtro => `${filtro.key}=${filtro.value}`).join("&");
            }

            return fetch(this.urlClubes, {
                method: "GET",
                headers: { "Content-Type": "application/json" },
            }) 
            .then(resposta => {
                if (resposta.ok) {
                    return resposta.json();
                } else {
                    throw new Error(ERRROR);
                }
            })
            .catch(error => {
                console.error('Erro:', error);
            });
        }
    }
});