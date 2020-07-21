
(async () => {
    Handlebars.registerPartial("cat", await fetch("./single-cat.hbs")
        .then(res => res.text()));

    const template = Handlebars.compile(await fetch("./templates.hbs")
        .then(res => res.text()));

    const html = template({ cats });
    document.getElementById("allCats").innerHTML = html;

    let buttons = document.getElementsByTagName("button");
    Array.from(buttons).forEach(btn => {
        btn.addEventListener("click", () => {
            let info = btn.parentNode.children[1];
            
            if (btn.textContent == "Hide status code") {
                btn.textContent = "Show status code";
                info.style.display = "none";
            } else {
                btn.textContent = "Hide status code";
                info.style.display = "block";
            }
        });
    });
})();
