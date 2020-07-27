
export async function sendRequest(url, token, method, body) {
    let requestObj = {
        method,
        body
    };

    if (body === undefined) {
        delete requestObj.body;
    }
    let response = await fetch((url + `?auth=` + token), requestObj);
    let data = await response;
    return data;
}