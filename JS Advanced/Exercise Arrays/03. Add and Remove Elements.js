const array =[];
let step = 1;
const ifTextAdd = x => x==="add"?array.push(step++):array.pop(step++);
const ifArrayEmpty = x => x.length === 0 ? "Empty" : x;

function solve(text){
    "use strict";
  text.map(ifTextAdd)
console.log(array.map(ifArrayEmpty).join("\n"))
}

//solve(['add','add','add','add']);
//solve(['add','add','remove','add','add']);
solve(['remove','remove','remove']);