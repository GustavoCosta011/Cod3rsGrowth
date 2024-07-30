sap.ui.define([
    "sap/ui/model/json/JSONModel"
], (JSONModel) => {
    "use strict";
    return {
        aoBuscar: function(filtros, oView) {
			this.urlClubes = "https://localhost:7178/api/Clubes";
            if (filtros.length > 0) {
                this.urlClubes += "?" + filtros.map(filtro => `${filtro.key}=${filtro.value}`).join("&");
            }

            fetch(this.urlClubes, {
                method: "GET",
                headers: { "Content-Type": "application/json" },
            }) 
            .then(resposta => {
                if (resposta.ok) {
                    return resposta.json();
                } else {
                    throw new Error('Erro na requisição da API');
                }
            })
            .then(Clubes => {
                oView.setModel(new JSONModel(Clubes));;
            })
            .catch(error => {
                console.error('Erro:', error);
            });
        }
    }
});