function toggle() {
    const button =  document.getElementsByClassName('button')[0];
    const texts = document.getElementById('extra');

    if (texts.style.display === 'block') {
        button.textContent = 'More';
        texts.style.display = 'none';
    }
    else {
        button.textContent = 'Less';
        texts.style.display = 'block';
    }   
}