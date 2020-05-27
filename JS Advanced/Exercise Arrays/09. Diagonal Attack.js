function solve(matrix){
    "use strict";
    let isDiagonal = (row, col) => row === col || col === matrix[row]
            .length - 1 - row;
    let firstDiagonalSum =0;
    let secondDiagonalSum= 0;

    matrix = matrix.map(row => row.split(' ').map(Number));

    haveDiagonal();

    firstDiagonalSum===secondDiagonalSum?newMatrix():""

    printMatrix();


function haveDiagonal(){
    for (let f= 0; f < matrix.length; f++) {
         firstDiagonalSum+=matrix[f][f];
         secondDiagonalSum+=matrix[f][matrix.length-f-1];
    }
}

function printMatrix() {
    console.log(matrix.map(row => row.join(' ')).join('\n')) 
}

function newMatrix() {
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
           if (!isDiagonal(row,col)) {
               matrix[row][col]=firstDiagonalSum
           }
        }
    }
}
}

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
)