function encodeAndDecodeMessages() {
  const btnEncode = document.getElementsByTagName("button")[0];
  const btnDecode = document.getElementsByTagName("button")[1];
  let sender = document.getElementsByTagName("textarea")[0];
  let addressee = document.getElementsByTagName("textarea")[1];

  btnEncode.addEventListener("click", function (e) {
    e.preventDefault();

    let messig='';
    for(char of sender.value){
    messig += String.fromCharCode(char.charCodeAt(0) + 1)
    }
    addressee.value = messig;
    sender.value='';
  });

  btnDecode.addEventListener("click", function (e) {
    e.preventDefault();

    let codeMessig = addressee.value ;
    let uncodeMessig='';
    for(char of codeMessig){
        uncodeMessig += String.fromCharCode(char.charCodeAt(0) - 1)
    }
    addressee.value = uncodeMessig;
  });
}