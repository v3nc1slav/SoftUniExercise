function addItem() {
    const text =  document.getElementById('newItemText');
    const value =  document.getElementById('newItemValue');
    const result =  document.getElementById('menu');

    const option = document.createElement('option');

    option.value=value.value;
    option.textContent = text.value

    result.appendChild(option);

    text.value="";
    value.value="";
}