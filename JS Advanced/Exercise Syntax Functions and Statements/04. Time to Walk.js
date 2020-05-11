function solve(steps, meter, speed ){
    "use strict";
       speed = speed/60/60;//in secand
   let distance = steps*meter/1000;//in km
   let rests = distance/0.500
   let rest = Math.floor(rests)*60;//in secand
   let time = ((distance/speed)+rest);
   var d = new Date(0);
   d.setSeconds(time);
 console.log("00:"+d.getMinutes()+":"+d.getSeconds());
}

solve(2564, 0.70, 5.5);