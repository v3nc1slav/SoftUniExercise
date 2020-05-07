function solve(text){
    "use strict";
    let result = text.toUpperCase().split(/\W+/).filter(w => w != "");

    console.log(result.join(", "))
}

solve('Hi, how are you?');