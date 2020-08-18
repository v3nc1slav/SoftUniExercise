import { showSuccess, showError } from "../notifications.js";
import { createNew } from "../data.js";
import { getById, updateById, deleteIt, joinIt} from "../data.js";

// ------------------------- CREATE -------------------------
export async function create() {
    this.partials = {
        header: await this.load("./templates/common/header.hbs"),
        footer: await this.load("./templates/common/footer.hbs")
    };

    this.partial("./templates/event/create.hbs", this.app.userData);
}

// ------------------------- CREATE (POST) -------------------------
export async function createPost() {
    try {
        if (this.params.name.length < 6) {
            throw new Error("Name must be at least 6 characters long.");
        }

        if (this.params.description.length < 10) {
            throw new Error("Description must be at least 10 characters long.");
        }

        if (this.params.price < 0) {
            throw new Error("Price cannot be 0 or a negative value.");
        }

        //if (!this.params.imageURL.startsWith("http://") && !this.params.imageURL.startsWith("https://")) {
        //    throw new Error("Image URL should start with \"http://\" or \"https://\".");
        //}

        const event = {
            name: this.params.name,
            price: this.params.price,
            imageUrl: this.params.imageURL,
            description: this.params.description,
            brand: this.params.brand,
            creator: this.app.userData.username,
            peopleBoughtIt: 0
        }

        const result = await createNew(event);

        if (result.hasOwnProperty("errorData")) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess("Event created successfully.");

        this.redirect("#/home");

    } catch (err) {
        showError(err.message);
    }
}

// ------------------------- EDIT -------------------------
export async function edit() {
    this.partials = {
        header: await this.load("./templates/common/header.hbs"),
        footer: await this.load("./templates/common/footer.hbs")
    };

    const eventId = this.params.id;

    let event = await getById(eventId);

    const context = Object.assign(this.app.userData, { event });

    this.partial("./templates/event/edit.hbs", context);

}

// ------------------------- EDIT (POST) -------------------------
export async function editPost() {

    const eventId = this.params.id;

    try {
        if (this.params.name.length < 6) {
            throw new Error("Name must be at least 6 characters long.");
        }

        if (this.params.description.length < 10) {
            throw new Error("Description must be at least 10 characters long.");
        }

        //if (!this.params.imageURL.startsWith("http://") && !this.params.imageURL.startsWith("https://")) {
        //     throw new Error("Image URL should start with \"http://\" or \"https://\".");
        //}

        const event = {
            name: this.params.name,
            price: this.params.price,
            imageUrl: this.params.imageURL,
            description: this.params.description,
            brand: this.params.brand,
        }

        const result = await updateById(eventId, event);

        if (result.hasOwnProperty("errorData")) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess("Event edited successfully.");

        this.redirect("#/home");

    } catch (err) {
        showError(err.message);
    }
}

// ------------------------- DELETE -------------------------
export async function deleteGet() {
    if (confirm("Are you sure you want to delete this event?") === false) {
        return this.redirect("#/home");
    }

    const eventId = this.params.id;

    try {
        const result = await deleteIt(eventId);

        if (result.hasOwnProperty("errorData")) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess("Event closed successfully.");

        this.redirect("#/home");

    } catch (err) {
        showError(err.message);
    }
}

// ------------------------- DETAILS -------------------------
export async function details() {
    this.partials = {
        header: await this.load("./templates/common/header.hbs"),
        footer: await this.load("./templates/common/footer.hbs")
    };

    const eventId = this.params.id;

    let event = await getById(eventId);

    const isOrganizer = event.organizedBy === this.app.userData.username;

    const context = Object.assign(this.app.userData, { event, isOrganizer });

    this.partial("./templates/event/details.hbs", context);
}

// ------------------------- INCREASE SOMETHING IN OBJECT -------------------------
export async function join() {
    const eventId = this.params.id;

    let event = await getById(eventId);

    try {
        const result = await joinIt(event);

        if (result.hasOwnProperty("errorData")) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess("You join the event successfully.");

        this.redirect(`#/details/${eventId}`);

    } catch (err) {
        showError(err.message);
    }
}