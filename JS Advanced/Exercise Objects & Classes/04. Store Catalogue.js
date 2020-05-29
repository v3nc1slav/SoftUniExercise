function solve (input){
    "use strict";
    let array = [];

   input.sort((a, b) => a.toLowerCase()
    .localeCompare(b.toLowerCase()));

    for (let i = 0; i < input.length; i++) {
        let char = input[i][0];

        !array.includes(char)? array.push(char):"";

        array.push('  '+input[i].replace(/ : /g, ': '));
    }

    console.log(array.join("\n"))
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
)
