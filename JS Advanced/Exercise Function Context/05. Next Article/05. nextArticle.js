function getArticleGenerator(articles) {
    "use strict";
    let count = 0;
    let content = document.getElementById("content");

    return () => {
        if (count < articles.length) {
            let article = document.createElement("article");
            article.textContent = articles[count++];
            content.appendChild(article);
        }
    }
}