function solve() {
    const div = document.querySelectorAll("input");
    const sectionMovies = document.getElementById("movies");
    const sectionАrchive = document.getElementById("archive");
    const inputName = div[0];
    const inputHall = div[1];
    const inputPrice = div[2];
    const ulMovies = sectionMovies.querySelector('ul')
    const ulАrchive = sectionАrchive.querySelector('ul')
    const btns = document.querySelectorAll("button");
    const addBtn = btns[0];
    const clearBtn = sectionАrchive.querySelector('button');

    addBtn.addEventListener("click", function (e) {
        e.preventDefault();

        const archiveBtn = el('button', 'Archive');
        const deleteBtn = el('button', 'Delete');
        
        const name = inputName.value.trim();
        inputName.value = '';
        const hall = inputHall.value.trim();
        inputHall.value = '';
        const price = inputPrice.value.trim();
        inputPrice.value = '';

        let task = el('li', [
            el('span', name),
            el('strong', `Hall: ${ hall } `),
            el('div', [
                el('strong', price),
                el('input', 'Tickets Sold'),
                archiveBtn
            ]),
        ]);

        if (name.length>0 && hall.length>0 && price>0) {
            ulMovies.appendChild(task);
        }

        archiveBtn.addEventListener("click", function (e) {
            e.preventDefault();

            const inputValue = sectionMovies.querySelector('input')
    
            const value = inputValue.value.trim();
            console.log(value);
            const amount = value*parseInt(price);
    
            if (value>0) {
                 task = el('li', [
                    el('span', name),
                    el('strong', `Total amount: ${amount} `),
                    deleteBtn
                
                ]);
                ulАrchive.appendChild(task);
                ulMovies.remove();
            }
        });
        
        deleteBtn.addEventListener("click", function (e) {
        e.preventDefault();
            ulАrchive.remove();
        });

        clearBtn.addEventListener("click", function (e) {
            e.preventDefault();
            ulАrchive.remove();
        });
    });

    function el(type, content, attributes){
        const result = document.createElement(type);
        
        if (attributes !== undefined) {
            Object.assign(result, attributes);
        }
    
        if (Array.isArray(content)){
            content.forEach(append);
        } else{
            append(content);
        }
    
        function append(node){
            if (typeof node === 'string'){
                node = document.createTextNode(node);
            } 
            result.appendChild(node);
        }
        return result;
    }
}