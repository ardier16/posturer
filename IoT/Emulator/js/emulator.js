var ctx, neckDot, backDot, buttDot, sideNeckDot, sideBackDot, sideButtDot;

function initializeObjects() {
    var canvas = document.getElementById("canvas");
    ctx = canvas.getContext('2d');

    neckDot = {
        x: 150,
        y: 20
    };

    backDot = {
        x: 150,
        y: 202
    };

    buttDot = {
        x: 150,
        y: 280
    };

    sideNeckDot = {
        x: 388,
        y: 72
    }

    sideBackDot = {
        x: 382,
        y: 190
    }

    sideButtDot = {
        x: 374,
        y: 235
    }
}

function drawAll() {
    drawPicture('img/back.jpg', 0, 0);
    drawPicture('img/side.jpg', 300, 0);
}
function drawPicture(url, x, y) {
    var pic = new Image();
    pic.src = url;

    pic.onload = function () {
        ctx.drawImage(pic, x, y);
        drawObjects();
    }
}

function drawObjects() {
    drawCircle(neckDot.x, neckDot.y, 10);
    drawCircle(backDot.x, backDot.y, 10);
    drawCircle(buttDot.x, buttDot.y, 10);

    drawCircle(sideNeckDot.x, sideNeckDot.y, 10);
    drawCircle(sideBackDot.x, sideBackDot.y, 10);
    drawCircle(sideButtDot.x, sideButtDot.y, 10);
}

function drawCircle(x, y, r) {
    ctx.beginPath();
    ctx.arc(x, y, r, 0, 2 * Math.PI, false);
    ctx.fillStyle = '#007bff';
    ctx.fill();
}

function initializeSliders() {
    initializeSlider("neckSlider", neckDot, 130, 0.4);
    initializeSlider("backSlider", backDot, 120, 0.6);
    initializeSlider("sideNeckSlider", sideNeckDot, 368, 0.4);
    initializeSlider("sideBackSlider", sideBackDot, 362, 0.4);
}

function initializeSlider(name, obj, initValue, coef) {
    var slider = document.getElementById(name);

    slider.oninput = function () {
        obj.x = initValue + this.value * coef;
        drawAll();
        document.getElementById("result").innerHTML = getPostureLevel();
    }
}

function getPostureLevel() {
    var neckLevel = 5 - Math.abs(150 - neckDot.x) / 4;
    var backLevel = 5 - Math.abs(150 - backDot.x) / 6;
    var sideNeckLevel = 5 - Math.abs(388 - sideNeckDot.x) / 4;
    var sideBackLevel = 5 - Math.abs(382 - sideBackDot.x) / 4;

    var postureLevel = (neckLevel + backLevel + sideNeckLevel + sideBackLevel) / 4;
    return Math.round(postureLevel * 1000) / 1000;
}

function setPostureLevel() {
    document.getElementById("result").innerHTML = getPostureLevel();
}