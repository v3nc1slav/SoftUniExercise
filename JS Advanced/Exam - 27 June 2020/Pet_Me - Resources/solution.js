function solve() {
    const input = document.querySelectorAll("input");
    const addBtn = document.querySelector("button");
    const inputName = input[0];
    const inputAge = input[1];
    const inputKind = input[2];
    const inputOwner = input[3];
    const adoption = document.getElementById("adoption").querySelector("ul");
    const adopted = document.getElementById("adopted").querySelector("ul");
    const li = document.createElement('li');
 
    addBtn.addEventListener("click", function (e) {
        e.preventDefault();
        if (inputName.value.length>0 && inputAge.value>0 && inputKind.value.length>0
            && inputOwner.value.length>0) {
 
            const html = `<p><strong>${inputName.value}</strong> is a <strong>${inputAge.value}</strong> year old <strong>${inputKind.value}</strong></p><span>Owner: ${inputOwner.value}</span><button>Contact with owner</button>`
            li.innerHTML = html;
            adoption.appendChild(li);
 
            inputName.value = '';
            inputAge.value = '';
            inputKind.value = '';
            inputOwner.value = '';
        }
 
        const contactBtn = document.getElementById("adoption")
        .querySelector("button");
       
        contactBtn.addEventListener("click", function (e) {
            e.preventDefault();
            const div = document.createElement('div');
            const htmls = `<input placeholder="Enter your names"><button>Yes! I take it!</button>`;
            div.innerHTML = htmls;
            contactBtn.remove();
            li.appendChild(div);
           
            const takeBtn = document.getElementById("adoption")
            .querySelector("button");
            const takeInput = document.getElementById("adoption")
            .querySelector("input");
 
            takeBtn.addEventListener("click", function (e) {
                e.preventDefault();
                const html = `<p><strong>${inputName.value}</strong> is a <strong>${inputAge.value}</strong> year old <strong>${inputKind.value}</strong></p><span>New Owner: ${takeInput.value}</span><button>Checked</button>`
                 li.innerHTML = html;
                if (takeInput.value.length>0) {
                    adopted.appendChild(li);
                }
 
                const checkedBtn = document.getElementById("adopted")
                .querySelector("button");
   
                checkedBtn.addEventListener("click", function (e) {
                    li.remove();
                })
            })
         })
    })
}
