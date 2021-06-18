$(() => {


        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        //var forms = document.getElementsByClassName('needs-validation');
        //// Loop over them and prevent submission
        //var validation = Array.prototype.filter.call(forms, function (form) {
        //    form.addEventListener('submit', function (event) {
        //        if ($("#Email").length > 0) {
        //            if (validateEmail($("#Email").val()) == false) {
        //                event.preventDefault();
        //                event.stopPropagation();
        //            }
        //        }
        //        if (form.checkValidity() === false) {
        //            event.preventDefault();
        //            event.stopPropagation();
        //        }
        //        form.classList.add('was-validated');
        //    }, false);
        //});
    
    ///// event listeners

    // event listener so when PAX is chosen, gets available dates from api
    $("#Guests").change(() => {
        // make sure user can't trick us with null value after choosing a correct one 
        if ($("#Guests").children("option:selected").val()) {
            // get url for fetch -> maybe should have urls in config file -> ask Peter
            const url = '/api/reservations/getDates/' + $("#Guests").children("option:selected").val();
            // talk to api - GET
            fetch(url)
                .then((resp) => resp.json())
                .then(function (data) { // this is the data as array of JSON
                    $("#finalInputs").hide();
                    $("#timesGroup").hide();
                    $("#datesGroup").show();
                    //remove any old options
                    removeOptions("dates");
                    //add the dates to the select list
                    addDateOptions(data, "dates");
                }) //handle errors
                .catch(function (error) {
                    console.log(error);
                });
        }
        else {
            $("#datesGroup").hide();
            $("#timesGroup").hide();
            $("#finalInputs").hide();
        }
    });

    // event listener so when date is chosen, gets available times from api
    $("#dates").change(() => {
        // make sure user can't trick us with null value after choosing a correct one 
        if ($("#dates").children("option:selected").val() != "") {
            //get url for fetch
            let d = new Date($("#dates").children("option:selected").val());
            const url = '/api/reservations/getTimes/' + `${d.getFullYear()}-${d.getMonth() + 1}-${d.getDate()}`;
            // talk to api - GET
            fetch(url)
                .then((resp) => resp.json())
                .then(function (data) { // this is the data as array of JSON
                    $("#finalInputs").hide();
                    $("#timesGroup").show();
                    //remove any old options
                    removeOptions("StartTime");
                    //add the times to the select list
                    addTimeOptions(data, "StartTime");
                }) //handle errors
                .catch(function (error) {
                    console.log(error);
                });
        }
        else {
            $("#timesGroup").hide();
            $("#finalInputs").hide();

        }
    });

    // event listener so when time is chosen, final inputs are shown
    $("#StartTime").change(() => {
        // make sure user can't trick us with null value after choosing a correct one 
        if ($("#StartTime").children("option:selected").val() != "") {
            $("#finalInputs").show();
        }
        else {

            $("#finalInputs").hide();
        }

    });

})



///// functions to manipulate elements

// function to remove options from a selectlist
function removeOptions(select) {
    let list = document.getElementById(select);
    for (let i = list.options.length; i >= 1; i--) {
        list.remove(i);
    }
}

// function to add date options to a selectlist
function addDateOptions(data, select) {
    let list = document.getElementById(select);
    for (let i = 0; i < data.length; i++) {
        let option = data[i];
        let el = document.createElement("option");
        el.text = new Date(option).toDateString();
        el.value = new Date(option);
        list.appendChild(el);
    }
}

// function to add time options to a selectlist
function addTimeOptions(data, select) {
    let list = document.getElementById(select);
    for (let i = 0; i < data.length; i++) {
        let option = data[i];
        let el = document.createElement("option");
        let time = new Date(option).toTimeString().slice(0, 5); //only gets hours:minutes
        el.text = time;
        el.value = new Date(option).toISOString(); //makes value c# compatible
        list.appendChild(el);
    }
}

///// Validation
function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function validateFirstName(helpText) {
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
function validateSurName(helpText) {
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
function validatePhoneNo(helpText) {
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

function validateEmailHon(helpText2) {

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
function validateAll_Hon(All) {
    var email = document.forms["booking"]["Email"].value;
    var regex = /^[A-Za-z0-9._%+-]{2,}@[A-Za-z0-9.-]+\.[a-z]{2,4}$/;   
    var validEmailAddress = regex.test(email);
    var firstName = document.forms["booking"]["FirstName"].value;
    var surName = document.forms["booking"]["Surname"].value;
    var phoneNo = document.forms["booking"]["Phone"].value;
    var phoneRegex = /^61\d{9}$/;
    var isDigit = phoneRegex.test(phoneNo);


    if (!email || !firstName || !surName || !phoneNo) {
        document.getElementById('bookingErrorMessage').innerText = "No empty field in firstName, surName , phone number or email";
        return false;
    }    
    if (firstName.length < 3) {
        document.getElementById('bookingErrorMessage').innerText = "First Name should have at least 3 characters";
        return false;
    }
    if (surName.length < 3) {
        document.getElementById('bookingErrorMessage').innerText = "Last Name should have at least 3 characters";
        return false;
    }
    if (!isDigit) {
        document.getElementById('bookingErrorMessage').innerText = "The Phone number should start with 61 and total length should be 11 digit";
        return false;
    }
    if (!validEmailAddress) {
        document.getElementById('bookingErrorMessage').innerText = "something wrong in email address";
        return false;
    }
    document.getElementById('bookingErrorMessage').innerText = "";
    return true;
}


