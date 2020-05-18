function solve(array){
    "use strict";
    let step = array.pop();
    for (let index = 0; index < step % array.length; index++) {
        array.unshift(array.pop());
    }
console.log(array.join(" "))
}

solve(['1','2','3','4','100']);