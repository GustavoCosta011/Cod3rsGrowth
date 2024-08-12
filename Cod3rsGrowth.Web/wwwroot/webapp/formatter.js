sap.ui.define([
    "sap/ui/core/format/DateFormat"
], function(DateFormat) {
    "use strict";
    const VAZIO = "";
    return {
        formatDate: function(data) {
            if (!data) {
                return VAZIO;
            }
            var oDateFormat = DateFormat.getDateTimeInstance({
                pattern: "dd/MM/yyyy"
            });
            return oDateFormat.format(new Date(data));
        },
        formatDateReverse: function(data) {
            if (!data) {
                return VAZIO;
            }
            var parts = data.split("/");
            if (parts.length !== 3) {
                return VAZIO;
            }
        
            var day = parts[0];
            var month = parts[1] - 1;
            var year = parts[2];
        
            var DATE = new Date(year, month, day);
            if (isNaN(DATE)) {
                return VAZIO;
            }
        
            var oDateFormat = DateFormat.getDateTimeInstance({
                pattern: "yyyy-MM-dd"
            });
            return oDateFormat.format(DATE);
        }        
    };
});