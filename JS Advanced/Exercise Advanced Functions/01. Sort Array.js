function solve (arr, method){
    function  sortAsc()  {arr.sort((a,b)=>a-b)};
    function  sortDesc()  {arr.sort((a,b)=>b-a)};

    method.toLowerCase()==="asc"?sortAsc():sortDesc();

    return arr;
}

solve([14, 7, 17, 6, 8], 'Asc');
solve([14, 7, 17, 6, 8], 'desc');