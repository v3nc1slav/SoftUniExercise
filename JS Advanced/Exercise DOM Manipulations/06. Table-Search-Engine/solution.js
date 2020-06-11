function solve() {
   const btn = document.getElementById("searchBtn");
   const input = document.getElementById("searchField");
   const tr = document.getElementsByTagName("tr");
   const items = [...tr].slice(2);

   btn.addEventListener("click", function (e) {
      
      for (item of items) {
         item.className = "";
        for(td of item.cells){

         (td.textContent
            .toLowerCase()
            .includes(input
               .value
               .toLowerCase()))?item.className = "select":"";
        }
      }
         input.value="";
    });
}