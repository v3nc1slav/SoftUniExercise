function solveClasses (){
    class Hall{
        constructor(capacity, name ) {
            this.capacity = capacity;
            this.name = name;
            this.events  = [];
        }

        hallEvent(title){
            for (let i = 0; i < this.events.length; i++) {
                if (this.events[i] === title) {
                    return[
                        `This event is already added!` 
                    ].join('\n');
                }
            }
            this.events.push(title);
            return[
                `Event is added.` 
            ].join('\n');
        }

        close(){
            this.events.splice(0,this.events.length);
            return[
                `${this.name} hall is closed.`
            ].join('\n');
        }

        toString(){
            return[
                `${this.name} hall - ${this.capacity}`
            ].join('\n');
        }
    }

    class MovieTheater extends Hall{
        constructor(capacity, name, screenSize){
            super(capacity, name);
            this.screenSize = screenSize;
        }

        close(){
            const result = [
                super.close(),
                `Аll screenings are over.`
            ].join('\n');
            return result
        }

        toString(){
        const result = [
            super.toString(),
            `${this.name} is a movie theater with ${this.screenSize} screensize and ${this.capacity} seats capacity.`
        ].join('\n');
        }
    }

    class ConcertHall extends Hall{
        constructor( capacity, name ){
            super(capacity, name);
        }

        close(){
            const result = [
                super.close(),
                'Аll performances are over.'
            ].join('\n');
            return result
        }

        toString(){
            let arr = this.events.join(', ')
            const result = [
                super.toString(),
                `Performers: ${arr}.`
            ].join('\n');
        }
    }

    return {
        Hall,
        MovieTheater,
        ConcertHall
    }
}


let classes = solveClasses();
let hall = new classes.Hall(20, 'Main');
console.log(hall.hallEvent('Breakfast Ideas'));
console.log(hall.hallEvent('Annual Charity Ball'));
console.log(hall.toString());
console.log(hall.close()); 

let movieHall = new classes.MovieTheater(10, 'Europe', '10m');
console.log(movieHall.hallEvent('Top Gun: Maverick')); 
console.log(movieHall.toString());

let concert = new classes.ConcertHall(5000, 'Diamond');        
console.log(concert.hallEvent('The Chromatica Ball', ['LADY GAGA']));  
console.log(concert.toString());
console.log(concert.close());
console.log(concert.toString());
