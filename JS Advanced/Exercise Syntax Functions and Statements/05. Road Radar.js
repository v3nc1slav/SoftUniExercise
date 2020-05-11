function solve(array){
    "use strict";
    let speed = array[0];
    let area = array[1];
    const motorway = 130;
    const interstate = 90;
    const city  = 50;
    const residential  = 20;
    if (area === "motorway") {
        speedCheck(speed, motorway)
    }
    else if (area === "interstate") {
        speedCheck(speed, interstate)
    }
    else if (area === "city") {
        speedCheck(speed, city)
    }
    else if (area === "residential") {
        speedCheck(speed, residential)
    }
}
function speedCheck(speed, motorway){
    "use strict";
    let value = speed-motorway;
    if (value<=0) {
        return;
    }
    else if (value<=20) {
        console.log(`speeding`);
    }
    else if(value<=40){
        console.log(`excessive speeding`);
    }
    else if(value>40){
        console.log(`reckless driving`);
    }
}
solve([40, 'city']);
solve([21, 'residential']);
solve([120, 'interstate']);
solve([200, 'motorway']);