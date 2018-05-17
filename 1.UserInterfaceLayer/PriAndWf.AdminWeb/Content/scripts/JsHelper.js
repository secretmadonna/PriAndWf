(function (global) {
    var JsHelper = function () { };
    JsHelper.IsNumber = function (v) {
        if ((v) === (+v)) {
            return true;
        }
        return false;
    };
    JsHelper.IsInteger = function (v) {
        if ((v) === (~~v)) {
            return true;
        }
        return false;
    };
    global.JsHelper = JsHelper;
})(typeof (window) !== "undefined" ? window : this);
