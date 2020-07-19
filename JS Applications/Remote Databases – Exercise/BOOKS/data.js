const appId = '3EFE7925-EBBB-1515-FF06-EE24137D9200';
const apiKey = '8C0059EA-4082-4243-941D-D8C826DB0595';

function getUrl(endpoint) {
    return `https://api.backendless.com/${appId}/${apiKey}/data/${endpoint}`;
}

export async function getBooks() {
    const response = await fetch(getUrl('Books'));
    const data = await response.json();
    return data;
}

export async function createBook(book) {
    const response = await fetch(getUrl('Books'), {
        headers: {
            "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify(book)
    });
    const data = await response.json();
    return data;
}

export async function updateBook(book) {
    const id = book.objectId;
    const response = await fetch(getUrl(`Books/${id}`), {
        headers: {
            "Content-Type": "application/json",
        },
        method: "PUT",
        body: JSON.stringify(book)
    });
    const data = await response.json();
    return data;
}

export async function deleteBook(id) {
    const response = await fetch(getUrl(`Books/${id}`), {
        method: "DELETE"
    });
    const data = await response.json();
    return data;
}