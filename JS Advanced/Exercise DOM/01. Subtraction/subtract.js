function subtract() {
    const first =  document.getElementById('firstNumber');
    const second =  document.getElementById('secondNumber');
    const result =  document.getElementById('result');

    let value = Number(first.value)-Number(second.value);

    result.textContent=value;
}