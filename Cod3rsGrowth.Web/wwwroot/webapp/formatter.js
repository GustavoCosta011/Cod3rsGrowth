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
        
            if (data instanceof Date) {
                var oDateFormat = sap.ui.core.format.DateFormat.getDateTimeInstance({
                    pattern: "yyyy-MM-dd"
                });
                return oDateFormat.format(data);
            }

            var parts = data.split("/");
            if (parts.length !== 3) {
                return VAZIO;
            }
        
            var day = parseInt(parts[0], 10);
            var month = parseInt(parts[1], 10) - 1;
            var year = parseInt(parts[2], 10);
        
            var DATE = new Date(year, month, day);
            if (isNaN(DATE.getTime())) {
                return VAZIO;
            }
        
            var oDateFormat = sap.ui.core.format.DateFormat.getDateTimeInstance({
                pattern: "yyyy-MM-dd"
            });
            return oDateFormat.format(DATE);
        }                
    };
});