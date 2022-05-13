function getConfirmation() {
  var Pname = document.getElementById("product").value;
  var Quan = document.getElementById("quantity").value;
  confirm("Please confirm your order " + Quan + " of " + Pname)
}
