!
function(e, n) {
    "function" == typeof define && (define.amd || define.cmd) ? define(function() {
        return n(e)
    }) : n(e, !0)
} (this,
function(e, n) {
    function i(n, i, t) {
        e.WeixinJSBridge ? WeixinJSBridge.invoke(n, o(i),
        function(e) {
            c(n, e, t)
        }) : d(n, t)
    }
    function t(n, i, t) {
        e.WeixinJSBridge ? WeixinJSBridge.on(n,
        function(e) {
            t && t.trigger && t.trigger(e),
            c(n, e, i)
        }) : t ? d(n, t) : d(n, i)
    }
    function o(e) {
        return e = e || {},
        e.appId = L.appId,
        e.verifyAppId = L.appId,
        e.verifySignType = "sha1",
        e.verifyTimestamp = L.timestamp + "",
        e.verifyNonceStr = L.nonceStr,
        e.verifySignature = L.signature,
        e
    }
    function r(e) {
        return {
            timeStamp: e.timestamp + "",
            nonceStr: e.nonceStr,
            package: e.package,
            paySign: e.paySign,
            signType: e.signType || "SHA1"
        }
    }
    function c(e, n, i) {
        delete n.err_code,
        delete n.err_desc,
        delete n.err_detail;
        var t = n.errMsg;
        t || (t = n.err_msg, delete n.err_msg, t = a(e, t), n.errMsg = t),
        (i = i || {})._complete && (i._complete(n), delete i._complete),
        t = n.errMsg || "",
        L.debug && !i.isInnerInvoke && alert(JSON.stringify(n));
        var o = t.indexOf(":");
        switch (t.substring(o + 1)) {
        case "ok":
            i.success && i.success(n);
            break;
        case "cancel":
            i.cancel && i.cancel(n);
            break;
        default:
            i.fail && i.fail(n)
        }
        i.complete && i.complete(n)
    }
    function a(e, n) {
        var i = e,
        t = g[i];
        t && (i = t);
        var o = "ok";
        if (n) {
            var r = n.indexOf(":");
            "confirm" == (o = n.substring(r + 1)) && (o = "ok"),
            "failed" == o && (o = "fail"),
            -1 != o.indexOf("failed_") && (o = o.substring(7)),
            -1 != o.indexOf("fail_") && (o = o.substring(5)),
            "access denied" != (o = (o = o.replace(/_/g, " ")).toLowerCase()) && "no permission to execute" != o || (o = "permission denied"),
            "config" == i && "function not exist" == o && (o = "ok"),
            "" == o && (o = "fail")
        }
        return n = i + ":" + o
    }
    function s(e) {
        if (e) {
            for (var n = 0,
            i = e.length; n < i; ++n) {
                var t = e[n],
                o = m[t];
                o && (e[n] = o)
            }
            return e
        }
    }
    function d(e, n) {
        if (! (!L.debug || n && n.isInnerInvoke)) {
            var i = g[e];
            i && (e = i),
            n && n._complete && delete n._complete,
            console.log('"' + e + '",', n || "")
        }
    }
    function l(e) {
        0 != A.preVerifyState && (v || w || L.debug || M < "6.0.2" || A.systemType < 0 || V || (V = !0, A.appId = L.appId, A.initTime = b.initEndTime - b.initStartTime, A.preVerifyTime = b.preVerifyEndTime - b.preVerifyStartTime, C.getNetworkType({
            isInnerInvoke: !0,
            success: function(e) {
                A.networkType = e.networkType;
                var n = "http://open.weixin.qq.com/sdk/report?v=" + A.version + "&o=" + A.preVerifyState + "&s=" + A.systemType + "&c=" + A.clientVersion + "&a=" + A.appId + "&n=" + A.networkType + "&i=" + A.initTime + "&p=" + A.preVerifyTime + "&u=" + A.url; (new Image).src = n
            }
        })))
    }
    function u() {
        return (new Date).getTime()
    }
    function p(n) {
        I && (e.WeixinJSBridge ? n() : h.addEventListener && h.addEventListener("WeixinJSBridgeReady", n, !1))
    }
    function f() {
        C.invoke || (C.invoke = function(n, i, t) {
            e.WeixinJSBridge && WeixinJSBridge.invoke(n, o(i), t)
        },
        C.on = function(n, i) {
            e.WeixinJSBridge && WeixinJSBridge.on(n, i)
        })
    }
    if (!e.jWeixin) {
        var m = {
            config: "preVerifyJSAPI",
            onMenuShareTimeline: "menu:share:timeline",
            onMenuShareAppMessage: "menu:share:appmessage",
            onMenuShareQQ: "menu:share:qq",
            onMenuShareWeibo: "menu:share:weiboApp",
            onMenuShareQZone: "menu:share:QZone",
            previewImage: "imagePreview",
            getLocation: "geoLocation",
            openProductSpecificView: "openProductViewWithPid",
            addCard: "batchAddCard",
            openCard: "batchViewCard",
            chooseWXPay: "getBrandWCPayRequest"
        },
        g = function() {
            var e = {};
            for (var n in m) e[m[n]] = n;
            return e
        } (),
        h = e.document,
        y = h.title,
        S = navigator.userAgent.toLowerCase(),
        _ = navigator.platform.toLowerCase(),
        v = !(!_.match("mac") && !_.match("win")),
        w = -1 != S.indexOf("wxdebugger"),
        I = -1 != S.indexOf("micromessenger"),
        T = -1 != S.indexOf("android"),
        k = -1 != S.indexOf("iphone") || -1 != S.indexOf("ipad"),
        M = function() {
            var e = S.match(/micromessenger\/(\d+\.\d+\.\d+)/) || S.match(/micromessenger\/(\d+\.\d+)/);
            return e ? e[1] : ""
        } (),
        V = !1,
        x = !1,
        b = {
            initStartTime: u(),
            initEndTime: 0,
            preVerifyStartTime: 0,
            preVerifyEndTime: 0
        },
        A = {
            version: 1,
            appId: "",
            initTime: 0,
            preVerifyTime: 0,
            networkType: "",
            preVerifyState: 1,
            systemType: k ? 1 : T ? 2 : -1,
            clientVersion: M,
            url: encodeURIComponent(location.href)
        },
        L = {},
        P = {
            _completes: []
        },
        W = {
            state: 0,
            data: {}
        };
        p(function() {
            b.initEndTime = u()
        });
        var C = {
            config: function(e) {
                L = e,
                d("config", e);
                var n = !1 !== L.check;
                p(function() {
                    if (n) i(m.config, {
                        verifyJsApiList: s(L.jsApiList)
                    },
                    function() {
                        P._complete = function(e) {
                            b.preVerifyEndTime = u(),
                            W.state = 1,
                            W.data = e
                        },
                        P.success = function(e) {
                            A.preVerifyState = 0
                        },
                        P.fail = function(e) {
                            P._fail ? P._fail(e) : W.state = -1
                        };
                        var e = P._completes;
                        return e.push(function() {
                            l()
                        }),
                        P.complete = function(n) {
                            for (var i = 0,
                            t = e.length; i < t; ++i) e[i]();
                            P._completes = []
                        },
                        P
                    } ()),
                    b.preVerifyStartTime = u();
                    else {
                        W.state = 1;
                        for (var e = P._completes,
                        t = 0,
                        o = e.length; t < o; ++t) e[t]();
                        P._completes = []
                    }
                }),
                L.beta && f()
            },
            ready: function(e) {
                0 != W.state ? e() : (P._completes.push(e), !I && L.debug && e())
            },
            error: function(e) {
                M < "6.0.2" || x || (x = !0, -1 == W.state ? e(W.data) : P._fail = e)
            },
            checkJsApi: function(e) {
                var n = function(e) {
                    var n = e.checkResult;
                    for (var i in n) {
                        var t = g[i];
                        t && (n[t] = n[i], delete n[i])
                    }
                    return e
                };
                i("checkJsApi", {
                    jsApiList: s(e.jsApiList)
                },
                (e._complete = function(e) {
                    if (T) {
                        var i = e.checkResult;
                        i && (e.checkResult = JSON.parse(i))
                    }
                    e = n(e)
                },
                e))
            },
            onMenuShareTimeline: function(e) {
                t(m.onMenuShareTimeline, {
                    complete: function() {
                        i("shareTimeline", {
                            title: e.title || y,
                            desc: e.title || y,
                            img_url: e.imgUrl || "",
                            link: e.link || location.href,
                            type: e.type || "link",
                            data_url: e.dataUrl || ""
                        },
                        e)
                    }
                },
                e)
            },
            onMenuShareAppMessage: function(e) {
                t(m.onMenuShareAppMessage, {
                    complete: function(n) {
                        "favorite" === n.scene ? i("sendAppMessage", {
                            title: e.title || y,
                            desc: e.desc || "",
                            link: e.link || location.href,
                            img_url: e.imgUrl || "",
                            type: e.type || "link",
                            data_url: e.dataUrl || ""
                        }) : i("sendAppMessage", {
                            title: e.title || y,
                            desc: e.desc || "",
                            link: e.link || location.href,
                            img_url: e.imgUrl || "",
                            type: e.type || "link",
                            data_url: e.dataUrl || ""
                        },
                        e)
                    }
                },
                e)
            },
            onMenuShareQQ: function(e) {
                t(m.onMenuShareQQ, {
                    complete: function() {
                        i("shareQQ", {
                            title: e.title || y,
                            desc: e.desc || "",
                            img_url: e.imgUrl || "",
                            link: e.link || location.href
                        },
                        e)
                    }
                },
                e)
            },
            onMenuShareWeibo: function(e) {
                t(m.onMenuShareWeibo, {
                    complete: function() {
                        i("shareWeiboApp", {
                            title: e.title || y,
                            desc: e.desc || "",
                            img_url: e.imgUrl || "",
                            link: e.link || location.href
                        },
                        e)
                    }
                },
                e)
            },
            onMenuShareQZone: function(e) {
                t(m.onMenuShareQZone, {
                    complete: function() {
                        i("shareQZone", {
                            title: e.title || y,
                            desc: e.desc || "",
                            img_url: e.imgUrl || "",
                            link: e.link || location.href
                        },
                        e)
                    }
                },
                e)
            },
            startRecord: function(e) {
                i("startRecord", {},
                e)
            },
            stopRecord: function(e) {
                i("stopRecord", {},
                e)
            },
            onVoiceRecordEnd: function(e) {
                t("onVoiceRecordEnd", e)
            },
            playVoice: function(e) {
                i("playVoice", {
                    localId: e.localId
                },
                e)
            },
            pauseVoice: function(e) {
                i("pauseVoice", {
                    localId: e.localId
                },
                e)
            },
            stopVoice: function(e) {
                i("stopVoice", {
                    localId: e.localId
                },
                e)
            },
            onVoicePlayEnd: function(e) {
                t("onVoicePlayEnd", e)
            },
            uploadVoice: function(e) {
                i("uploadVoice", {
                    localId: e.localId,
                    isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
                },
                e)
            },
            downloadVoice: function(e) {
                i("downloadVoice", {
                    serverId: e.serverId,
                    isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
                },
                e)
            },
            translateVoice: function(e) {
                i("translateVoice", {
                    localId: e.localId,
                    isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
                },
                e)
            },
            chooseImage: function(e) {
                i("chooseImage", {
                    scene: "1|2",
                    count: e.count || 9,
                    sizeType: e.sizeType || ["original", "compressed"],
                    sourceType: e.sourceType || ["album", "camera"]
                },
                (e._complete = function(e) {
                    if (T) {
                        var n = e.localIds;
                        try {
                            n && (e.localIds = JSON.parse(n))
                        } catch(e) {}
                    }
                },
                e))
            },
            previewImage: function(e) {
                i(m.previewImage, {
                    current: e.current,
                    urls: e.urls
                },
                e)
            },
            uploadImage: function(e) {
                i("uploadImage", {
                    localId: e.localId,
                    isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
                },
                e)
            },
            downloadImage: function(e) {
                i("downloadImage", {
                    serverId: e.serverId,
                    isShowProgressTips: 0 == e.isShowProgressTips ? 0 : 1
                },
                e)
            },
            getNetworkType: function(e) {
                var n = function(e) {
                    var n = e.errMsg;
                    e.errMsg = "getNetworkType:ok";
                    var i = e.subtype;
                    if (delete e.subtype, i) e.networkType = i;
                    else {
                        var t = n.indexOf(":"),
                        o = n.substring(t + 1);
                        switch (o) {
                        case "wifi":
                        case "edge":
                        case "wwan":
                            e.networkType = o;
                            break;
                        default:
                            e.errMsg = "getNetworkType:fail"
                        }
                    }
                    return e
                };
                i("getNetworkType", {},
                (e._complete = function(e) {
                    e = n(e)
                },
                e))
            },
            openLocation: function(e) {
                i("openLocation", {
                    latitude: e.latitude,
                    longitude: e.longitude,
                    name: e.name || "",
                    address: e.address || "",
                    scale: e.scale || 28,
                    infoUrl: e.infoUrl || ""
                },
                e)
            },
            getLocation: function(e) {
                e = e || {},
                i(m.getLocation, {
                    type: e.type || "wgs84"
                },
                (e._complete = function(e) {
                    delete e.type
                },
                e))
            },
            hideOptionMenu: function(e) {
                i("hideOptionMenu", {},
                e)
            },
            showOptionMenu: function(e) {
                i("showOptionMenu", {},
                e)
            },
            closeWindow: function(e) {
                i("closeWindow", {},
                e = e || {})
            },
            hideMenuItems: function(e) {
                i("hideMenuItems", {
                    menuList: e.menuList
                },
                e)
            },
            showMenuItems: function(e) {
                i("showMenuItems", {
                    menuList: e.menuList
                },
                e)
            },
            hideAllNonBaseMenuItem: function(e) {
                i("hideAllNonBaseMenuItem", {},
                e)
            },
            showAllNonBaseMenuItem: function(e) {
                i("showAllNonBaseMenuItem", {},
                e)
            },
            scanQRCode: function(e) {
                i("scanQRCode", {
                    needResult: (e = e || {}).needResult || 0,
                    scanType: e.scanType || ["qrCode", "barCode"]
                },
                (e._complete = function(e) {
                    if (k) {
                        var n = e.resultStr;
                        if (n) {
                            var i = JSON.parse(n);
                            e.resultStr = i && i.scan_code && i.scan_code.scan_result
                        }
                    }
                },
                e))
            },
            openProductSpecificView: function(e) {
                i(m.openProductSpecificView, {
                    pid: e.productId,
                    view_type: e.viewType || 0,
                    ext_info: e.extInfo
                },
                e)
            },
            addCard: function(e) {
                for (var n = e.cardList,
                t = [], o = 0, r = n.length; o < r; ++o) {
                    var c = n[o],
                    a = {
                        card_id: c.cardId,
                        card_ext: c.cardExt
                    };
                    t.push(a)
                }
                i(m.addCard, {
                    card_list: t
                },
                (e._complete = function(e) {
                    var n = e.card_list;
                    if (n) {
                        for (var i = 0,
                        t = (n = JSON.parse(n)).length; i < t; ++i) {
                            var o = n[i];
                            o.cardId = o.card_id,
                            o.cardExt = o.card_ext,
                            o.isSuccess = !!o.is_succ,
                            delete o.card_id,
                            delete o.card_ext,
                            delete o.is_succ
                        }
                        e.cardList = n,
                        delete e.card_list
                    }
                },
                e))
            },
            chooseCard: function(e) {
                i("chooseCard", {
                    app_id: L.appId,
                    location_id: e.shopId || "",
                    sign_type: e.signType || "SHA1",
                    card_id: e.cardId || "",
                    card_type: e.cardType || "",
                    card_sign: e.cardSign,
                    time_stamp: e.timestamp + "",
                    nonce_str: e.nonceStr
                },
                (e._complete = function(e) {
                    e.cardList = e.choose_card_info,
                    delete e.choose_card_info
                },
                e))
            },
            openCard: function(e) {
                for (var n = e.cardList,
                t = [], o = 0, r = n.length; o < r; ++o) {
                    var c = n[o],
                    a = {
                        card_id: c.cardId,
                        code: c.code
                    };
                    t.push(a)
                }
                i(m.openCard, {
                    card_list: t
                },
                e)
            },
            chooseWXPay: function(e) {
                i(m.chooseWXPay, r(e), e)
            }
        };
        return n && (e.wx = e.jWeixin = C),
        C
    }
});