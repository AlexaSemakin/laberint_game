// document.onkeydown = checkKey;

// function setCharaterPoint(x, y, z) {
//     let step = 10;
//     document.getElementById("character").style = "left: " + (x * (step + 6)).toString() + "px; top: " + (y * (step + 6)).toString() + "px;";
// }

// function to_top() {
//     if (map[point_now[2]][point_now[1]][point_now[0]][0] == 0) {
//         point_now[1]--;
//     }
//     to_go_point()
// }

// function to_bottom() {
//     if (map[point_now[2]][point_now[1]][point_now[0]][2] == 0) {
//         point_now[1]++;
//     }
//     to_go_point()
// }

// function to_left() {
//     if (map[point_now[2]][point_now[1]][point_now[0]][3] == 0) {
//         point_now[0]--;
//     }
//     to_go_point()
// }

// function to_right() {
//     if (map[point_now[2]][point_now[1]][point_now[0]][1] == 0) {
//         point_now[0]++;
//     }
//     to_go_point()
// }

// function to_go_point() {
//     setCharaterPoint(point_now[0], point_now[1], point_now[2]);
// }

// function change_visible_text() {
//     if (document.getElementById('checkbox-visible-text').checked) {
//         document.getElementById("button_top").className = "visible_text";
//     } else {
//         document.getElementById("button_top").className = "non_visible_text";
//     }
//     if (document.getElementById('checkbox-visible-text').checked) {
//         document.getElementById("button_left").className = "visible_text";
//     } else {
//         document.getElementById("button_left").className = "non_visible_text";
//     }
//     if (document.getElementById('checkbox-visible-text').checked) {
//         document.getElementById("button_bottom").className = "visible_text";
//     } else {
//         document.getElementById("button_bottom").className = "non_visible_text";
//     }
//     if (document.getElementById('checkbox-visible-text').checked) {
//         document.getElementById("button_right").className = "visible_text";
//     } else {
//         document.getElementById("button_right").className = "non_visible_text";
//     }
// }

// function checkKey(e) {
//     e = e || window.event;
//     switch (e.keyCode) {
//         case 37:
//         case 39:
//         case 38:
//         case 40: // Arrow keys
//         case 32:
//             e.preventDefault();
//             break; // Space
//         default:
//             break; // do not block other keys
//     }
//     if (e.keyCode == '38') {
//         to_top();
//     } else if (e.keyCode == '40') {
//         to_bottom();
//     } else if (e.keyCode == '37') {
//         to_left();
//     } else if (e.keyCode == '39') {
//         to_right();
//     }
//     to_go_point()
// }



// function getRandomInt(max) {
//     return Math.floor(Math.random() * max);
// }
// let point_now = [0, 0, 0];
// let elements = [];
// let go_to_vector = [];
// let map = [];
// let go_to = [
//     [-1, 0, 0],
//     [0, 1, 0],
//     [1, 0, 0],
//     [0, -1, 0],
//     [0, 0, 1],
//     [0, 0, -1]
// ];
// let visyble_arrow = true;

// function generate() {
//     let val = parseInt(document.getElementById('size_lab_textbox').value);
//     if (val <= 100 && val >= 10) {
//         document.getElementById("display").innerHTML = "";
//     } else {
//         document.getElementById('size_lab_textbox').value = map.length;
//         val = map.length;
//     }
//     start(val, val, val);
// }

// function restart_generate() {
//     n = map.length;
//     m = map[0].length;
//     p = map[0][0].length;
//     start(n, m, p);
// }

// function generete_interface() {
//     setCharaterPoint(0, 0);
//     point_now = [0, 0];
//     document.getElementById("display").innerHTML = "";
//     map.forEach(x_layer => {
//         (x_layer[0]).forEach(item => {
//             let block_image = document.createElement("div");
//             block_image.className = "imageBlock";
//             document.getElementById("display").append(block_image);
//             let style = "";
//             let color_border = "black";
//             let color_not_border = "royalblue";
//             if (item[0] == 1) {
//                 style += "border-top: 3px solid " + color_border + "; ";
//             } else {
//                 style += "border-top: 3px solid " + color_not_border + "; ";
//             }
//             if (item[1] == 1) {
//                 style += "border-right: 3px solid " + color_border + "; ";
//             } else {
//                 style += "border-right: 3px solid " + color_not_border + "; ";
//             }
//             if (item[2] == 1) {
//                 style += "border-bottom: 3px solid " + color_border + "; ";
//             } else {
//                 style += "border-bottom: 3px solid " + color_not_border + "; ";
//             }
//             if (item[3] == 1) {
//                 style += "border-left: 3px solid " + color_border + "; ";
//             } else {
//                 style += "border-left: 3px solid " + color_not_border + "; ";
//             }
//             if (item[4] == 0) {
//                 style += "background-image: url('img/5.svg');";
//             }
//             if (item[5] == 0) {
//                 style += "background-image: url('img/6.svg');";
//             }
//             block_image.style = style;
//             console.log(item);
//         });
//         document.getElementById("display").innerHTML += "<br>";
//     });
// }


let point_now = [0, 0, 0];
let elements = [];
let go_to_vector = [];
let map = [];
let go_to = [
    [-1, 0, 0],
    [0, 1, 0],
    [1, 0, 0],
    [0, -1, 0],
    [0, 0, 1],
    [0, 0, -1]
];
let visyble_arrow = true;




function generate_go_to_vector(count) {
    elements = [];
    go_to_vector = [];
    for (let i = 0; i < count; i++) {
        elements.push(i);
    }
    while (go_to_vector.length < go_to.length) {
        let index = getRandomInt(elements.length);
        let element = elements[index];
        go_to_vector.push(element);
        elements.splice(index, 1);
    }
}

function dfs(nowX, nowY, nowZ, n, m, p, wasX = -1, wasY = -1, wasZ = -1) {
    generate_go_to_vector(go_to.length);
    map[nowX][nowY][nowZ] = [0, 0, 0, 0, 0, 0];
    go_to_vector.forEach(item => {
        let toX = nowX + go_to[item][0];
        let toY = nowY + go_to[item][1];
        let toZ = nowZ + go_to[item][2];
        if (toX != wasX || toY != wasY || toZ != wasZ) {
            if ((toX < 0) || (toX >= n) || (toY < 0) || (toY >= m) || (toZ < 0) || (toZ >= p) || map[toX][toY][toZ].length > 0) {
                map[nowX][nowY][nowZ][item] = 1;
            } else {
                dfs(toX, toY, toZ, n, m, p, nowX, nowY, nowZ);
            }
        }
    });
}


function start(n, m, p) {
    map = [];
    for (let i = 0; i < n; i++) {
        map.push([]);
        for (let j = 0; j < m; j++) {
            map[i].push([]);
            for (let k = 0; k < p; k++) {
                map[i][j].push([]);
            }
        }
    }
    dfs(parseInt(n / 2), parseInt(m / 2), parseInt(p / 2), n, m, p);
    console.log('generated success');
    generete_interface();
    console.log('image generated success');
    console.log(map);

}