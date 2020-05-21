function solve(array) {
    "use strict"
    let value =0;
   array = array
        .filter((v,i)=> v>= Math.max(...array.slice(0,i)))
                
    console.log(array.join("\n"));
}

solve([1,3,8,2,10,12,3,5,24])