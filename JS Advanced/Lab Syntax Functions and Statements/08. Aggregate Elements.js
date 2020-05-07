function solve(array){
    "use strict";
let sum = array.reduce((a, b) => a + b);
let sum1 =  0;
let concat = "";

for (let i = 0; i < array.length; i++) {
    const element = array[i];
    sum1 += 1 / element;
    concat += element
}

console.log(sum);
console.log(sum1);
console.log(concat);
}

solve([1, 2, 3]);