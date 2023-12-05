
// Write your JavaScript code.
let mybutton = document.getElementById("myBtn");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function() {scrollFunction()};

function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    mybutton.style.display = "block";
  } else {
    mybutton.style.display = "none";
  }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
  document.body.scrollTop = 0; // For Safari
  document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
}

function ChangeLanguage(selected) {
    var replace = document.getElementById("dropdownMenuButton1").innerHTML = selected;
}

function changeDirection() {
    
    if (window.location.href.indexOf("/?ui-culture=ar-EG") > -1) {
        document.documentElement.setAttribute("dir", "rtl");
        document.documentElement.setAttribute("lang", "ar");
        document.getElementById("Dropdown").innerHTML = "Arabic";
        var flg = document.createElement("i");
        document.getElementById("Dropdown").appendChild(flg);
        flg.setAttribute("id", "chngFlg");
        flg.setAttribute("class", "flag-eg flag");
        flg.setAttribute("style", "margin:1.2rem 0.5rem");
        document.getElementById("chk").remove();
        var check = document.createElement("i");
        document.getElementById("ar").appendChild(check);
        check.setAttribute("id", "chk");
        check.setAttribute("class", "fa fa-check text-success ms-2");
    }
}
window.onload = function () {
    var reloading = sessionStorage.getItem("reloading");
    if (reloading) {
        sessionStorage.removeItem("reloading");
        changeDirection();
    }
}

function reloadP() {
    sessionStorage.setItem("reloading", "true");
    document.location.reload();
}

function disableLink(link) {
// 1. Add isDisabled class to parent span
  link.classList.add('isDisabled');
// 2. Store href so we can add it later
  link.setAttribute('data-href', link.href);
// 3. Remove href
  link.href = '';
// 4. Set aria-disabled to 'true'
   link.setAttribute('aria-disabled', 'true');
   link.addEventListener('click', function (event) {
       event.preventDefault();
   });
}
function enableLink(link) {
// 1. Remove 'isDisabled' class from parent span
  link.classList.remove('isDisabled');
// 2. Set href
  link.href = link.getAttribute('data-href');
// 3. Remove 'aria-disabled', better than setting to false
  link.removeAttribute('aria-disabled');
}

// Function to handle language change
function changeLanguage(selectedValue) {
    var currentUrl = window.location.href;

    // Check if there's already a query string in the URL
    if (currentUrl.indexOf('?') > -1) {
        // Append the ui-culture parameter
        var baseUrl = currentUrl.split('?')[0];
        if (selectedValue == "ar-EG") {
            reloadP();
            var newUrl = baseUrl + '?ui-culture=' + selectedValue;
        }
        else {
            var newUrl = baseUrl + '?ui-culture=' + selectedValue;
        }
    } else {
        // Add the query string with ui-culture parameter
        if (selectedValue == "ar-EG") {
            reloadP();
            var newUrl = currentUrl + '/?ui-culture=' + selectedValue;
        }
        else {
            var newUrl = currentUrl + '/?ui-culture=' + selectedValue;
        }
    }

    // Redirect to the new URL
    window.location.href = newUrl;
}

document.addEventListener('DOMContentLoaded', function () {
    var workedTable = document.getElementById('worked');
    var addRowButton = document.querySelector('.add-row');

    addRowButton.addEventListener('click', function () {
        var template = '<tr><td><input class="form-control" type="text" /></td><td><input class="form-control" type="text" /></td><td><input class="form-control" type="text" /></td><td><input class="form-control" type="text" /></td><td><button type="button" class="btn btn-danger delete-row">-</button></td></tr>';
        var tbody = workedTable.querySelector('tbody');
        tbody.insertAdjacentHTML('beforeend', template);
    });

    workedTable.addEventListener('click', function (event) {
        if (event.target.classList.contains('delete-row')) {
            var row = event.target.closest('tr');
            row.parentNode.removeChild(row);
        }
    });
});


