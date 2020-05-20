function solve(array) {
    "use strict"
    let value =0;
   array = array
        .filter(v => v > value, value+=1 )
                
    console.log(array.join("\n"));
}

solve([1,3,8,2,10,12,3,2,24])