var commonHelper = {
    isArray: function (value) {
        return Object.prototype.toString.call(value) === "[object Array]";
    },
    isFunction: function (value) {
        return Object.prototype.toString.call(value) === "[object Function]";
    }
};
var layerHelper = {
    openWeuiLoading: function (content, options) {
        !content && (content = "加载中...");
        !options && (options = {});
        !options.className && (options.className = "custom-loading");
        return weui.loading(content, options);
    },
    openWeuiAlert: function (content, yes, options) {
        !options && (options = {});
        !options.title && (options.title = "友情提示");
        return weui.alert(content, yes, options);
    },
    openWeuiConfirm: function (content, yes, no, options) {
        !options && (options = {});
        !options.title && (options.title = "请您确认");
        return weui.confirm(content, yes, no, options);
    },
    openWeuiDialog: function (options) {
        return weui.dialog(options);
    },
    closeWeuiDialog: function (dialog, callback) {
        dialog.hide(callback);
    }
};