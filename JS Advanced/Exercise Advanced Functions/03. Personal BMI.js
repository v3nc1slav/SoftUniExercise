function calculateBMI(name, age, weight, height) {

    class Person {
        constructor(name, age, weight, height) {
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.height = height;
        }

        get status() {
            if (this.bmi >= 30) {
                return "obese";
            } else if (this.bmi >= 25) {
                return "overweight";
            } else if (this.bmi >= 18.5) {
                return "normal";
            } else {
                return "underweight";
            }
        }

        get bmi() {
            return Math.round(this.weight / (Math.pow((this.height / 100), 2)));
        }

        info() {
            if (this.status === "obese") {
                return {
                    name: this.name,
                    personalInfo: {
                        age: this.age,
                        weight: this.weight,
                        height: this.height
                    },
                    BMI: this.bmi,
                    status: this.status,
                    recommendation: "admission required"
                }
            } 

            return {
                name: this.name,
                personalInfo: {
                    age: this.age,
                    weight: this.weight,
                    height: this.height
                },
                BMI: this.bmi,
                status: this.status
            }
        }
    }


    let person = new Person(name, age, weight, height);

    return person.info();
}