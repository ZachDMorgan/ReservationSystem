function registerValidateFirstName(helpText) {
    var firstName = document.getElementById("RFirstName").value;
    if (!firstName || firstName.length < 3) {
        helpText.innerHTML = "first name should not be empty or have less than 3 characters";
        return false;
    }
    else {
        helpText.innerHTML = "";
        return true;
    }
}
function registerValidateSurName(helpText) {
    var surName = document.getElementById("RSurname").value;
    if (!surName || surName.length < 3) {
        helpText.innerHTML = "Surname should not be empty or have less than 3 characters";
        return false;
    }
    else {
        helpText.innerHTML = "";
        return true;
    }
}
function registerValidatePhoneNo(helpText) {
    var phoneNo = document.getElementById("RPhone").value;
    
    if (!phoneNo) {
        helpText.innerHTML = "Please enter a phone number";
        return false;
    }


    var regex = /^61\d{9}$/;

    var isDigit = regex.test(phoneNo);
    if (isDigit) {
        helpText.innerHTML = "";
        return true;
    }
    else {
        helpText.innerHTML = "Can only be digit and should have 11 digit start with 61"; //error message
        return false;
    }

}

function registerValidateEmailHon(helpText2) {

    var email1 = document.getElementById("REmail").value;
   
    if (!email1) {
        helpText2.innerHTML = "Please enter valid email address";
        
        return false;
    }
    var regex = /^[A-Za-z0-9._%+-]{2,}@[A-Za-z0-9.-]+\.[a-z]{2,4}$/;
    var validEmail1 = regex.test(email1);
    if (validEmail1) {
        helpText2.innerHTML = "";
        return true;
    }
    else {
        helpText2.innerHTML = "not a valid email address pattern e.g (at least 2 letters)@example.com";
        return false;
    }
}