function attachEventsListeners() {
    const daysButton = document.getElementById("daysBtn");
    const hoursButton = document.getElementById("hoursBtn");
    const minutesButton = document.getElementById("minutesBtn");
    const secondsButton = document.getElementById("secondsBtn");
    let days =  document.getElementById("days");
    let hours = document.getElementById("hours");
    let minutes =  document.getElementById("minutes");
    let seconds = document.getElementById("seconds");

    daysButton.addEventListener("click", function (e) {
        e.preventDefault();

        const daysValue = Number(days.value);
        hours.value = daysValue * 24;
        minutes.value = daysValue * 1440;
        seconds.value = daysValue * 86400;

    });

    hoursButton.addEventListener("click", function (e) {
        e.preventDefault();

        const hoursValue = Number(hours.value);
        days.value = hoursValue / 24;
        minutes.value = hoursValue * 60;
        seconds.value = hoursValue * 60 * 60;

    });

    minutesButton.addEventListener("click", function (e) {
        e.preventDefault();

        const minutesValue = Number(minutes.value);
        days.value = minutesValue / 60 / 24;
        hours.value = minutesValue / 60;
        seconds.value = minutesValue * 60;

    });

    secondsButton.addEventListener("click", function (e) {
        e.preventDefault();

        const secondsValue = Number(seconds.value);
        days.value = secondsValue / 60 / 60 / 24;
        hours.value = secondsValue / 60 / 60;
        minutes.value = secondsValue / 60;

    });
}