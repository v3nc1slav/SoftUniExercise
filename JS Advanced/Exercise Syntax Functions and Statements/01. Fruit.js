function solve(fruit, grams, price){
    "use strict";
 let weight = grams/1000;
 let money = weight*price;

 console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`)
}

solve('orange', 2500, 1.80);