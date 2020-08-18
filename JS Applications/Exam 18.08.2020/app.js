alert("The app works!")

import { home } from "./controllers/home.js";
import { register, login, logout, registerPost, loginPost } from "./controllers/user.js";
import { create, createPost, details, edit, editPost, deleteGet, join } from "./controllers/event.js";

window.addEventListener("load", () => {
    const app = Sammy("#container", function () {
        this.use("Handlebars", "hbs");

        this.userData = {
            username: localStorage.getItem("username") || "",
            userId: localStorage.getItem("userId") || ""
        };

        this.get("/", home);
        this.get("index.html", home);
        this.get("#/home", home);

        this.get("#/register", register);
        this.post("#/register", context => { registerPost.call(context); });

        this.get("#/login", login);
        this.post("#/login", context => { loginPost.call(context); });

        this.get("#/logout", logout);

        this.get("#/create", create);
        this.post("#/create", context => { createPost.call(context); });

        this.get("#/details/:id", details);

        this.get("#/edit/:id", edit);
        this.post("#/edit/:id", context => { editPost.call(context); });

        // It gives an error when a function is called just "delete"
        this.get("#/delete/:id", deleteGet);

        // this.get("", function () {
        //     this.swap("<h1>Error 404: Page not found.</h1>")
        // })
    });

    app.run();
});