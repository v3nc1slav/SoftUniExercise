function attachEvents() {
    let ul = document.querySelector("#root ul");
    let input = document.getElementById("towns");
    let submitButton = document.getElementById("btnLoadTowns");

    submitButton.addEventListener("click", (e) => {
        ul.innerHTML = "";

        if (!input.value) {
            ul.innerHTML = "<li>Empty input!</li>";
        } else {
            let towns = input.value.split(", ");
            let template = Handlebars.compile("{{#each towns}}<li>{{this}}</li>{{/each}}");
            let html = template({ towns });
            ul.innerHTML = html;
        }
    });
}
attachEvents();