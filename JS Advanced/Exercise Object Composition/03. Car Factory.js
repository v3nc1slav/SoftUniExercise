function assemble(car) {
    const engines = {
    small: {engine: {power: 90, volume: 1800}},
    normal: {engine: {power: 120, volume: 2400}},
    monster: {engine: {power: 200, volume: 3500}}
    };

    const resultCar = {
        model: car.model
    };

    car.power <= 90 ? Object.assign(resultCar, engines.small) : car.power <= 120 
                    ? Object.assign(resultCar, engines.normal) 
                    : Object.assign(resultCar, engines.monster);
               
 
    car.carriage === "hatchback" ? Object.assign(resultCar, {carriage: {type: "hatchback", color: car.color}})
                                 : Object.assign(resultCar, {carriage: {type: "coupe", color: car.color}});
                                 
    car.wheelsize % 2 === 1 ? Object.assign(resultCar, {wheels: [car.wheelsize, car.wheelsize, car.wheelsize, car.wheelsize]})
                            : Object.assign(resultCar, {wheels: [car.wheelsize-1, car.wheelsize-1, car.wheelsize-1, car.wheelsize-1]});
                            
    return resultCar;

}