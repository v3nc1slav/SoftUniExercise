function solve() {
   const button = document.getElementById("send");
   const result = document.getElementById('chat_messages');
   
   button.addEventListener("click", function (e) {
      e.preventDefault();
      
      const message = document.getElementById("chat_input").value;
      let div = document.createElement('div');

      //div.setAttribute("class", "message my-message");
      div.className = "message my-message";

      div.textContent = message;
      result.appendChild(div);

      document.getElementById("chat_input").value = "";
   })
}


