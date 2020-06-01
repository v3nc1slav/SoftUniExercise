function solve(input, command) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let array = [];

    for (let i = 0; i < input.length; i++) {
        let items = input[i].split("|");
        const destination = items[0];
        const price = Number(items[1]);
        const status = items[2];

        const tickets = new Ticket(destination, price, status);
        array.push(tickets)
    }

    command==="destination"?array.sort((a,b)=>a.destination.localeCompare(b.destination)):"";
    command==="price"?array.sort((a,b)=>a.price-b.price):"";
    command==="status"?array.sort((a,b)=>a.status.localeCompare(b.status)):"";

    return array;
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
);