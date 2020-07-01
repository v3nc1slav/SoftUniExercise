class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
 
        this.clients = [];
 
        this.totalProfit = 0;
        this.currentWorkload = 0;
        this.tempPetsCount = 1;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        if (this.tempPetsCount > this.capacity) {
            throw new Error("Sorry, we are not able to accept more patients!");
        }

        let currentOwner = this.clients.find(c => c === ownerName);
        let currentPet = this.clients.hasOwnProperty(petName);
        if (currentOwner === undefined && currentPet === undefined) {
            throw new Error(`This pet is already registered under ${this.ownerName} name! ${this.petName} is on our lists, waiting for ${joinedProcedures}.`)
        }

        this.clients.push(
            this.ownerName = ownerName, 
            [this.petName = petName , [procedures] ], 
            kind);
            this.tempPetsCount++;
        return `Welcome ${petName}!`;
    }

    onLeaving(ownerName, petName){
        let currentOwner = this.clients.find(c => c === ownerName);
        if (currentOwner === undefined ){
           throw new Error(`Sorry, there is no such client!`)
        }
        let currentPet = this.clients.hasOwnProperty(this.petName);
        if (currentPet === undefined || currentPet.procedures===0) {
            throw new Error(`Sorry, there are no procedures for { petName }!`)
        }

        totalProfit = 500;
        tempPetsCount--;
        return `Goodbye ${ petName }. Stay safe!`
    }

}
 
let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B'])); 
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
