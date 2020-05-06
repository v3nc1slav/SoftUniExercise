function solve(x, y, z){
    "use strict";
    let result;
    if (x>=y && x>=z)
    {
        result = x;
    }
    else if(y>=z)
    {
        result = y;
    }
    else
    {
        result = z;  
    }
      console.log(`The largest number is ${result}.`);
}
