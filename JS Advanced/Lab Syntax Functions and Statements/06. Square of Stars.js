function solve(n){
    "use strict";
    n= n? n : 5;
    for (let i = 0; i < Number(n); i++) {
        let array = "";

        for (let j = 0; j < Number(n); j++) {
            array += "* ";          
        }

        console.log(String(array));
    }
}