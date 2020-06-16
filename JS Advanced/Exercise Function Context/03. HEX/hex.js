"use strict";
class Hex {
    constructor(number){
        this.value = number;
    }

    valueOf(){
        return this.value;
    }

    toString(){
        return "0x" + this.value.toString(16).toUpperCase();;
    }

    plus(number){
        return new Hex(this.value + number);
    }

    minus(number){
        return  new Hex(this.value - number);
    }

    parse(hex){
        return parseInt(hex, 16);
    }

}