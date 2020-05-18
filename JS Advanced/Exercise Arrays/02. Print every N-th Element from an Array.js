function solve(array){
    "use strict";
    let step = array.pop();
console.log(array.filter((_,i)=>i%step ===0).join("\n"))
}

solve(['5','20','31','4','20','2'])