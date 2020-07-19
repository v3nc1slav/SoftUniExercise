const appId = '3EFE7925-EBBB-1515-FF06-EE24137D9200';
const apiKey = '8C0059EA-4082-4243-941D-D8C826DB0595';

function getUrl(endpoint) {
    return `https://api.backendless.com/${appId}/${apiKey}/data/${endpoint}`;
}

export async function getData(){
    const response = await fetch(getUrl("Players"));
    return await response.json();
}

export async function createPlayer(data){
    const response = await fetch(getUrl("Players"), {
        headers: {
            "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify(data)
    });
    const output = await response.json();
    return output;
}

export async function deletePlayer(id){
    const response = await fetch(getUrl(`Players/${id}`), {
        method: "DELETE"
    });
    const data = await response.json();
    return data;
}

