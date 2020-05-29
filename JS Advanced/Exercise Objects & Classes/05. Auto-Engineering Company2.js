function solve (input){
    "use strict";
    let array = [];

    for (let i = 0; i < input.length; i++) {
        const items = input[i].split(" | ");
        const [brand, model, number] = [items[0], items[1], Number(items[2])];

        !array.includes(brand)?
            array.push(brand,[model,number]):
            array.push([model,number]);
            

    }

    console.log(array.join("\n"))
}


solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);