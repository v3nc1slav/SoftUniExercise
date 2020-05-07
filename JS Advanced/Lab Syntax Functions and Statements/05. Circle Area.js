function solve(input){
    "use strict";
if(typeof(input)==='number'){
    let result = Math.pow(input, 2) * Math.PI;
    console.log(result.toFixed(2))
}
else{
    console.log(`We can not calculate the circle area, because we receive a ${typeof(input)}.`);
}}

solve(3);