function lockedProfile() {

    document.querySelector("main").addEventListener('click', onClick);

    function onClick(e){
        let btn = e.target.nodeName;
        if (btn === "BUTTON") {
            const parent = e.target.parentNode;
            let hiddenInfo = parent.getElementsByTagName("div")[0];
            const unlock = parent.getElementsByTagName("input")[1];
            if (unlock.checked === true) {
                if (hiddenInfo.style.display === "block") {
                    hiddenInfo.style.display = "";
                    e.target.textContent = "Show more";
                }
                else {
                    hiddenInfo.style.display = "block";
                    e.target.textContent = "Hide it";
                }
            }
        }
    }
}