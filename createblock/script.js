function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}


var go_to_vector = [];
var map = [];
var go_to = [
    [0, -1],
    [1, 0],
    [0, 1],
    [-1, 0]
];

function generate() {
    var val = parseInt(document.getElementById('textbox').value);
    if (val <= 100) {
        document.getElementById("display").innerHTML = "";
        var map = [

        ];
        start(val);
    } else {
        alert('максимальное значение - 10000 клетток')
    }
}

function generete_interface(map) {
    document.getElementById("display").innerHTML = "";
    map.forEach(array => {
        array.forEach(item => {
            var block_image = document.createElement("div");
            block_image.className = "imageBlock";
            document.getElementById("display").append(block_image);
            if (item == 128) {
                block_image.style = "background-color:'green'";
            } else {
                var element = item.toString(2);
                for (var i = 1; i <= go_to.length; i++) {
                    if (element[i] == '1') {
                        var image = document.createElement("div");
                        image.className = "imageBlock";
                        image.id = 'image_' + (i).toString();
                        block_image.appendChild(image);
                    }
                }
            }
        });
        document.getElementById("display").innerHTML += "<br>";
    });
}

function generate_go_to_vector(count) {
    var elements = [];
    go_to_vector = [];
    for (let i = 0; i < count; i++) {
        elements.push(i);
    }
    while (go_to_vector.length < 4) {
        var index = getRandomInt(elements.length);
        var element = elements[index];
        go_to_vector.push(element);
        elements.splice(index, 1);
    }
}

function getNum(a, b) {
    a |= 1 << b;
    return a;
}

function dfs(nowX, nowY, n, wasX = -1, wasY = -1, finX = map.length - 1, finY = map.length - 1) {
    generate_go_to_vector(go_to.length);
    map[nowX][nowY] = 16;
    if (nowX == finX && nowY == finY) {
        map[nowX][nowY] = 128;
        return;
    }
    go_to_vector.forEach(item => {
        var toX = nowX + go_to[item][0];
        var toY = nowY + go_to[item][1];
        if (toX != wasX || toY != wasY) {
            if ((toX < 0) || (toX >= n) || (toY < 0) || (toY >= n) || map[toX][toY] != -1) {
                map[nowX][nowY] = getNum(map[nowX][nowY], item);
            } else {
                dfs(toX, toY, n, nowX, nowY, finX, finY);
            }
        }
    });
}


function start(n) {
    for (var i = 0; i < n; i++) {
        map.push([]);
        for (var j = 0; j < n; j++) {
            map[i][j] = -1;
        }
    }
    dfs(0, 0, n);
    console.log('generated success');
    generete_interface(map);
    console.log('image generated success');

}