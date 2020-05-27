function solve(input){
    "use strict";

    return createTable(input);

    function createTd(x) {
      return  `\t\t<td>${x}</td>\n`;
    }

    function createTr(array){
        let str ="\t<tr>\n";
        for (let i = 0; i < array.length; i++) {
            str += createTd(array[i])
        }
        str +="\t</tr>\n";
        return str;
    }

    function createTable(input){
    let str="<table>\n";
    for (const item of input) {
        let json = JSON.parse(item);
        str += createTr([json.name,json.position,json.salary]);
    }
    str += "</table>";
    return str;
    }
}

console.log(solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
));