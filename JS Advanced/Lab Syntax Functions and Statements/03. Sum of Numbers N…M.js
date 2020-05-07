function solve(n, m){
    "use strict";
    let sum = 0;

    for (let i = Number(n); i <= Number(m); i++) {
        sum += i;
    }

    console.log(sum);
}
solve(5,6);
