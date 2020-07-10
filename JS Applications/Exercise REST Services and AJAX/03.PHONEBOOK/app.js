function attachEvents() {
      const URL = `http://localhost:8000/phonebook`;
      const btnLoad = document.getElementById('btnLoad');
      const btnCreate = document.getElementById('btnCreate');
      const ul = document.getElementById('phonebook');

      let person = document.getElementById('person');
      let phone = document.getElementById('phone');
 

      btnLoad.addEventListener('click', getOfPhoneBook);
      btnCreate.addEventListener('click', saveInPhoneBook);

    function getOfPhoneBook(){
        fetch(URL).then((x)=>x.json()).then((result)=>showInfo(result));
        
        function showInfo(data){
           Object.values(data).forEach((key)=>{

            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = "Delete";

            const li = document.createElement('li');
                  li.textContent = `${key.person} ${key.phone}`;

            deleteBtn.addEventListener('click', deteleOfPhoneBook);

            li.appendChild(deleteBtn);
            ul.appendChild(li);

            function deteleOfPhoneBook(){
                fetch(URL, {
                    method: "DELETE",
                    body: JSON.stringify(key)
                }).then((x)=>x.json)
                getOfPhoneBook();
            }
        })

        btn.disabled = true;
        }
    }

    function saveInPhoneBook(){
        person = person.value
        phone = phone.value
        fetch(URL, {
            method: "POST",
            body: JSON.stringify({person, phone})
        }).then((x)=>x.json);
        document.getElementById('person').value = "";
        document.getElementById('phone').value = "";
    }
  
}

attachEvents();