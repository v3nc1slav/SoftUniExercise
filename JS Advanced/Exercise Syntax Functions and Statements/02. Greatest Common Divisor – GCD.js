function solve(num1, num2){
    "use strict";
    let result ;
    num1 = Math.abs(num1);
    num2 = Math.abs(num2);
  while(num2) {
    var t = num2;
    num2 = num1 % num2;
    num1 = t;
    result = num1;
}
console.log(result)
}

solve(2154, 458);