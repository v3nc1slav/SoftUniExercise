export function showSuccess(message) {
    let success = document.querySelector("#successBox");
    success.addEventListener("click", hideSuccess);

    success.textContent = message;
    success.style.display = "block";

    setTimeout((hideSuccess), 5000);

    function hideSuccess() {
        success.style.display = "none";
    }
}


export function showError(message) {
    let error = document.querySelector("#errorBox");
    error.addEventListener("click", hideError);
    error.textContent = message;

    error.textContent = message
    error.style.display = "block";

    function hideError() {
    error.style.display = "none";
    }
}

let requests = 0;

export function beginRequest() {
    let loading = document.querySelector("#loadingBox");
    if (loading !== null) {
        requests++;
        loading.style.display = "block";
    }
}

export function endRequest() {
    let loading = document.querySelector("#loadingBox");
    requests--;
    if (loading !== null) {
        if (requests === 0) {
            loading.style.display = "none";
        }
    }
}
