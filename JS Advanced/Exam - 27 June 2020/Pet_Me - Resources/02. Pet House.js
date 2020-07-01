function solve() {
    class Pet {
        constructor(owner, name) {
            this.owner = owner;
            this.name = name;
            this.comments = [];
        }
 
        addComment(comment) {
            let currentComment = this.comments.find(c => comment === c);
 
            if (currentComment === undefined) {
                this.comments.push(comment);
                return "Comment is added.";
            } else {
                throw new Error("This comment is already added!")
            }
        }
 
        feed() {
            return `${this.name} is fed`;
        }
 
        toString() {
            let result = [`Here is ${this.owner}'s pet ${this.name}.`];
            let joinedComments = this.comments.join(", ")
 
            if (this.comments.length > 0) {
                result.push(`Special requirements: ${joinedComments}`);
            }
 
            return result.join("\n");
        }
    }
 
    class Cat extends Pet {
        constructor( owner, name, insideHabits, scratching ) {
            super(owner, name);
 
            this.insideHabits = insideHabits;
            this.scratching = scratching;
        }
 
        feed() {
            return super.feed() + ", happy and purring.";
        }
 
        toString() {
            let result = [
                super.toString(),
                "Main information:",
                `${ this.name } is a cat with ${ this.insideHabits }`
            ];
 
            if (this.scratching === true) {
                return [
                super.toString(),
                "Main information:",
                `${ this.name } is a cat with ${ this.insideHabits }, but beware of scratches.`
                ].join("\n");
            }
           
            return result.join("\n");
        }
    }
 
    class Dog extends Pet {
        constructor(owner, name, runningNeeds, trainability) {
            super(owner, name);
 
            this.runningNeeds = runningNeeds;
            this.trainability = trainability;
        }
 
        feed() {
            return super.feed() + ", happy and wagging tail.";
        }
 
        toString() {
            let result = [
                super.toString(),
                "Main information:",
                `${ this.name } is a dog with need of ${ this.runningNeeds }km running every day and ${ this.trainability } trainability.`
            ];
           
            return result.join("\n");
        }
 
    }
 
 
    return {
        Pet,
        Cat,
        Dog
    }
}