function solve(matrix){
    "use strict";
    let result = true;
    const rowSum = row => matrix[row].reduce((a, b) => a + b);
    const colSum = col => matrix.map(row => row[col]).reduce((a, b) => a + b);

    const sumRow = rowSum(0);
    const sumCol = colSum(0);

     for (let i = 1; i < matrix[0].length; i++) {
         (rowSum(i)!==sumRow)?result = false:(colSum(i)!==sumCol)?result = false:""
     }

console.log(result)
}

solve([]);

solve([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]);

