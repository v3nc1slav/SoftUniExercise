function solve(array){
    "use strict";
let matrix = [
    [false, false, false],
    [false, false, false],
    [false, false, false]
];
let row ;
let col ;
let player = "X";
let length 

array.length>9?length=9:length=array.length;

for (let i= 0; i < length; i++) {
    row = array[i][0];
    col = array[i][2];
   if(matrix[row][col]==="X"
   ||matrix[row][col]==="O")
   {console
    .log(`This place is already taken. Please choose another!`)
    length++
    continue;
    }

    matrix[row][col]=player
    if (win() != null) {
        console.log(win())
        printMatrix()
        return;
    }
    player==="O"?player="X":player="O"
}
if (win() == null) {
    console.log(`The game ended! Nobody wins :(`)
}
printMatrix()

function win(){
    let text =`Player ${player} wins!`;
    for (let r = 0; r < matrix.length; r++) {
        for (let c = 0; c < matrix[r].length; c++) {
            if (matrix[0][c]===player
                && matrix[1][c]===player
                && matrix[2][c]===player) {
                    return  text
            }
        }
        if (matrix[r][0]===player
            && matrix[r][1]===player
            && matrix[r][2]===player ) {
                return  text
        }
        else if(matrix[0][0]===player
            && matrix[1][1]===player
            && matrix[2][2]===player ) {
            return  text
        }
        else if(matrix[0][2]===player
            && matrix[1][1]===player
            && matrix[2][0]===player ) {
            return  text
        }
    }
}

function printMatrix() {
    for (let row = 0; row < matrix.length; row++) {
        console.log(matrix[row].join('\t'));
    }
}

}

solve(["0 1",
"0 0",
"1 1",
"2 0",
"2 1"]
)