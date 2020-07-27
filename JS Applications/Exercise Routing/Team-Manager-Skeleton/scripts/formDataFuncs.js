export function getFormEntity(form) {
    let formData = new FormData(form).entries();
    let data = {};
    for (const [key, value] of formData) {
        data[key] = value;
    }
    return data;
}

export function clearForm(form) {
    form.reset();
}