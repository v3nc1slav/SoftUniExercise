function solve(array){
    "use strict";
    let obj = [] ;
    let heroName ;
    let heroLevel ;
    let heroItems = new Array();
    
    for (let i = 0; i < array.length; i++) {
        const items = array[i].split(' / ');

        items.length>1?heroName = items[0]:"";
        !isNaN(Number(items[1]))?heroLevel=(Number(items[1])):"";
        items.length > 2?heroItems = items[2].split(", "):"";

        obj.push({name: heroName, level: heroLevel, items: heroItems});
    }
    return obj;
}

console.log(JSON.stringify(solve(['Isacc / 12 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
)));