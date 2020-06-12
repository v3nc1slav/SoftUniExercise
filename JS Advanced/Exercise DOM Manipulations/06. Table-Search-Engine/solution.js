function solve() {
   const btn = document.getElementById("searchBtn");
   const input = document.getElementById("searchField");
   const tr = document.getElementsByTagName("tr");
   const items = [...tr].slice(2);

   for (item of items) {
      item.className = '';
   }

   btn.addEventListener("click", function (e) {
      e.preventDefault();

      for (tr of items) {
        item.className = '';
        for(td of tr.cells){

         (td.textContent
            .toLowerCase()
            .includes(input
               .value
               .toLowerCase()))?tr.className = 'select':"";
        }
      }
         input.value="";
    });
}