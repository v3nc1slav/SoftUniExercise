function solve(input){
    "use strinct";
    let obj = {};
    let juice ;
    let quantity ;

    for (let i = 0; i < input.length; i++) {
        let items = input[i].replace(/\s/g, '').replace(/'/g,'').split('=>')
        juice = items[0];
        quantity = Number(items[1]);

        obj.hasOwnProperty(juice)?obj[juice] += quantity:obj[juice] = quantity
    }

    Object.keys(obj)
     .map(function(key) {
        obj[key] = Math.floor(obj[key]/1000)
    });

}

console.log(solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']
));