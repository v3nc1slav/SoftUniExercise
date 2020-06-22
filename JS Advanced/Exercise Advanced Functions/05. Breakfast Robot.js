function solution() {
    const recipe = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }

    const commands = {
        restock,
        prepare,
        report
    }

    const ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    function restock(microelement, quantity) {
        ingredients[microelement] += +quantity;
        return "Success";
    }

    function prepare(rec, quantity) {
        let currentRecipe = Object.assign({}, recipe[rec]);

        let keys = Object.keys(currentRecipe);

        for (const element of keys) {
            let needed = currentRecipe[element] *= quantity;
            let available = ingredients[element];
            if (needed > available) {
                return `Error: not enough ${element} in stock`;
            } else {
                ingredients[element] -= needed;
            }
        };

        return "Success";
    }

    function report() {
        return `protein=${ingredients['protein']} carbohydrate=${ingredients['carbohydrate']} fat=${ingredients['fat']} flavour=${ingredients['flavour']}`;
    }

    function manager(input) {
        let tokens = input.split(" ");
        return commands[tokens[0]](tokens[1], tokens[2]);
    }

    return manager;
}