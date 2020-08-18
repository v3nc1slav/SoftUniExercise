import { getAll } from "../data.js";

export async function home() {
    this.partials = {
        header: await this.load("./templates/common/header.hbs"),
        footer: await this.load("./templates/common/footer.hbs")
    };

    const token = localStorage.getItem("userToken");

    if (token) {
        const events = await getAll();

        events.sort((a, b) => {
            return b.interestedIn - a.interestedIn
        })

        const context = Object.assign(this.app.userData, { events });

        this.partial("./templates/home/home.hbs", context);
    } else {
        this.partial("./templates/home/home.hbs");
    }
}

// if (token) {
//     const events = await getAll();
//
//     events.sort((a, b) => {
//         return b.interestedIn - a.interestedIn
//     })
//
//     const context = Object.assign(this.app.userData, { events });
//
//     this.partial("./templates/home.hbs", context);
// } else {
//     this.partial("./templates/home.hbs");
// }