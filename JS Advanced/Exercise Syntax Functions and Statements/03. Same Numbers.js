function solve(number){
    "use strict";
    number = number.toString()
    .split("");
    let result = true;  
for (let i = 0; i < number.length-1; i++) {
     if (number[i]!==number[i+1]) {
         result=false;
         break;
     }
}

let sum = number
.map(Number)
.reduce((a, b) => (a + b));

 console.log(result);
 console.log(sum)
}

solve(1234);