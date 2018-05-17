self.onmessage = function (e) {
    postMessage("start");
    var sum = 0;
    for (var i = e.data.min; i <= e.data.max; i++) {
        sum += i;
        postMessage(sum);
    }
    postMessage("finish");
}