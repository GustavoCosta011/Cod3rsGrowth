sap.ui.define([
    "sap/ui/core/format/DateFormat"
], function(DateFormat) {
    "use strict";
    return {
        formatDate: function(data) {
            if (!data) {
                return "";
            }
            var oDateFormat = DateFormat.getDateTimeInstance({
                pattern: "dd/MM/yyyy"
            });
            return oDateFormat.format(new Date(data));
        },
        formatDateReverse: function(data){
            if (!data) {
                return "";
            }
            var oDateFormat = DateFormat.getDateTimeInstance({
                pattern: "yyyy-MM-dd"
            });
            return oDateFormat.format(new Date(data))
        }
    };
});