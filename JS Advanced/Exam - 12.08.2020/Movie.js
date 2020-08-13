class Movie{
    constructor ( movieName, ticketPrice ){
        this.movieName = movieName;
        this.ticketPrice = ticketPrice;
        this.screenings = [];
        this.totalProfit = 0;
        this.soldTickets = 0;
    }

    newScreening(date, hall, description){
            if (this.screenings.find(s => s.date === date && s.hall === hall) !== undefined) {
                throw new Error(`Sorry, ${hall} hall is not available on ${date}`);
            }

        this.screenings.push({date: date, hall: hall, description: description})
        return[
            `New screening of ${this.movieName} is added.` 
        ].join('\n');
    }

    endScreening(date, hall, soldTickets) {
        if (this.screenings.find(s => s.date === date && s.hall === hall)===undefined) {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`);
        }

        const currentProfit = soldTickets*this.ticketPrice;
        this.totalProfit +=currentProfit;
        this.soldTickets +=soldTickets;

        this.screenings = this.screenings.filter(s => s.hall !== currentScreening.hall || s.date !== currentScreening.date);
        return[
            `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${currentProfit}` 
        ].join('\n');
    }

    toString (){
        let result = 
        [   `${this.movieName} full information:`,
            `Total profit: ${this.totalProfit}$`,
            `Sold Tickets: ${this.soldTickets}`,
        ];

        if (this.screenings.length > 0) {
            result.push(`Remaining film screenings:`);
            this.screenings.sort((a, b) => a.hall.toLowerCase().localeCompare(b.hall.toLowerCase()))
            .forEach(s => result.push(`${s.hall} - ${s.date} - ${s.description}`));
        } else {
            result.push("No more screenings!");
        }
        return result.join('\n');
    }
}


let m = new Movie('Wonder Woman 1984', '10.00');
console.log(m.newScreening('October 2, 2020', 'IMAX 3D', `3D`));
console.log(m.newScreening('October 3, 2020', 'Main', `regular`));
console.log(m.newScreening('October 4, 2020', 'IMAX 3D', `3D`));
console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
console.log(m.endScreening('October 3, 2020', 'Main', 78));
console.log(m.toString());

m.newScreening('October 4, 2020', '235', `regular`);
m.newScreening('October 5, 2020', 'Main', `regular`);
m.newScreening('October 3, 2020', '235', `regular`);
m.newScreening('October 4, 2020', 'Main', `regular`);
console.log(m.toString());
