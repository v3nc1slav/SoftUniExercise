
    addBtn.addEventListener("click", function (e) {
        e.preventDefault();

        const archiveBtn = el('button', 'Archive');

        const name = inputName.value.trim();
        inputName.value = '';
        const hall = inputHall.value.trim();
        inputHall.value = '';
        const price = inputPrice.value.trim();
        inputPrice.value = '';

        if (name.length>0 && hall.length>0 && price>0) {
            
            const task = el('li', [
                el('span', name),
                el('strong', `Hall: ${ hall } `),
                el('div', [
                    el('strong', price),
                    el('input', 'Tickets Sold'),
                    archiveBtn
                ]),
            ]);

            ulMovies.appendChild(task)
        }

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