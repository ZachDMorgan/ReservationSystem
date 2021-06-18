function staffValidateFirstName(helpText) {
    var firstName = document.getElementById("FirstName").value;
    if (!firstName || firstName.length < 3) {
        helpText.innerHTML = "first name should not be empty or have less than 3 characters";
        return false;
    }
    else {
        helpText.innerHTML = "";
        return true;
    }
}
function staffValidateSurName(helpText) {
    var surName = document.getElementById("Surname").value;
    if (!surName || surName.length < 3) {
        helpText.innerHTML = "Surname should not be empty or have less than 3 characters";
        return false;
    }
    else {
        helpText.innerHTML = "";
        return true;
    }
}
function staffValidatePhoneNo(helpText) {
    var phoneNo = document.getElementById("Phone").value;
    console.log(phoneNo);
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

function staffValidateEmailHon(helpText2) {

    var email1 = document.getElementById("Email").value;
    console.log(email1);
    if (!email1) {
        helpText2.innerHTML = "Please enter valid email address";
        console.log("HiHI");
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
function staffValidateAll_Hon1(All) {
    var email = document.forms["staffBooking"]["Email"].value;
    var regex = /^[A-Za-z0-9._%+-]{2,}@[A-Za-z0-9.-]+\.[a-z]{2,4}$/;
    var validEmailAddress = regex.test(email);
    var firstName = document.forms["staffBooking"]["FirstName"].value;
    var surName = document.forms["staffBooking"]["Surname"].value;
    var phoneNo = document.forms["staffBooking"]["Phone"].value;
    var phoneRegex = /^61\d{9}$/;
    var isDigit = phoneRegex.test(phoneNo);


    if (!email || !firstName || !surName || !phoneNo) {
        document.getElementById('staffBookingErrorMessage').innerText = "No empty field in firstName, surName , phone number or email";
        return false;
    }
    if (firstName.length < 3) {
        document.getElementById('staffBookingErrorMessage').innerText = "First Name should have at least 3 characters";
        return false;
    }
    if (surName.length < 3) {
        document.getElementById('staffBookingErrorMessage').innerText = "Last Name should have at least 3 characters";
        return false;
    }
    if (!isDigit) {
        document.getElementById('staffBookingErrorMessage').innerText = "The Phone number should start with 61 and total length should be 11 digit";
        return false;
    }
    if (!validEmailAddress) {
        document.getElementById('staffBookingErrorMessage').innerText = "something wrong in email address";
        return false;
    }
    document.getElementById('staffBookingErrorMessage').innerText = "";
    return true;
}