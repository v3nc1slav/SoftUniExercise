function solve(steps, meter, speed ){
    "use strict";
       speed = speed/60;//in minnutes
   let distance = steps*meter/1000;//in km
   let rests = distance/0.500
   let rest = Math.floor(rests);
   let time = ((distance/speed)+rest);
   var minutes = Math.floor(time);
   var secands =  Math.round((time-minutes)*60);
 console.log("00:"+minutes+":"+secands);
}

solve(2564, 0.70, 5.5);