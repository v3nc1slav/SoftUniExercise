import { showSuccess, showError } from "../notifications.js";
import { register as apiRegister, getEventsByCreator } from "../data.js";
import { login as apiLogin } from "../data.js";
import { logout as apiLogout } from "../data.js";
export async function register() {
    this.partials = {
        header: await this.load("./templates/common/header.hbs"),
        footer: await this.load("./templates/common/footer.hbs")
    };

    this.partial("./templates/register/register.hbs", this.app.userData);
}

export async function registerPost() {
    try {
        if (this.params.email === "") {
            throw new Error("Email field must be filled.");
        }

        if (this.params.password.length < 6) {
            throw new Error("Password must be at least 6 characters long.");
        }

        if (this.params.password !== this.params.repeatPassword) {
            throw new Error("Passwords don't match");
        }

        const result = await apiRegister(this.params.email, this.params.password);

        if (result.hasOwnProperty("errorData")) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess("Successful registration!");
        // showSuccess("User registration successful.");

        this.redirect("#/home");

    } catch (err) {
        showError(err.message);
        // showError(err.message);
    }
}

export async function login() {
    this.partials = {
        header: await this.load("./templates/common/header.hbs"),
        footer: await this.load("./templates/common/footer.hbs")
    };

    this.partial("./templates/login/login.hbs", this.app.userData);
}

export async function loginPost() {
    try {
        const result = await apiLogin(this.params.email, this.params.password);

        if (result.hasOwnProperty("errorData")) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.userEmail = result.email;
        this.app.userData.userId = result.objectId;

        showSuccess("Login successful.");

        this.redirect("#/home")

    } catch (err) {
        showError(err.message);
    }
}

export async function logout() {
    try {
        const result = await apiLogout();
        if (result.hasOwnProperty("errorData")) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.userEmail = "";
        this.app.userData.userId = "";

        showSuccess("Successful logout.");

        this.redirect("#/home");

    } catch (err) {
        showError(err.message);
    }
}