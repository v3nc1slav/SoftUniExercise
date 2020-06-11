function lockedProfile() {

   const div = document.getElementsByClassName("profile")

   for (const profile of div) {
    let btn = profile.getElementsByTagName("button")[0];
    const unlock = profile.getElementsByTagName("input")[1];
    let hiddenInfo = profile.getElementsByTagName("div")[0];

   btn.addEventListener("click", function (e) {
    e.preventDefault();

    if (unlock.checked === true) {
        if ( btn.textContent ==="Hide it") {
            hiddenInfo.style.display  = "none";
            btn.textContent ="Show more";
        }
        else{
            hiddenInfo.style.display  = "block";
            btn.textContent ="Hide it";
        }    
    }

    });
}
}