
function solve(x, y, z){
    "use strict";
    let totalLength = x.length + y.length + z.length;
    let averageLength = Math.floor(totalLength / 3);

    console.log(totalLength);
    console.log(averageLength);
}

solve('chocolate', 'ice cream', 'cake');
