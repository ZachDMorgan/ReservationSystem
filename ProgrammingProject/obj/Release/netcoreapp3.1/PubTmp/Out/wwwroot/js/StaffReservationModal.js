$(() => {
    fetch('/api/reservationSources/getSources/')
        .then((resp) => resp.json())
        .then(function (data) {
            //add the dates to the select list
            addSourceOptions(data, "SourceId");
        }) //handle errors
        .catch(function (error) {
            console.log(error);
        });

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName('needs-validation');
    // Loop over them and prevent submission
    var validation = Array.prototype.filter.call(forms, function (form) {
        form.addEventListener('submit', function (event) {
            if ($("#Email").length > 0) {
                if (validateEmail($("#Email").val()) == false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
            }
            if (form.checkValidity() === false) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        }, false);
    });

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

    $(".btn-manager").click((e) => {

        let sittingId = $(e.currentTarget).data('sitting');
        let action = $(e.currentTarget).data('action');

        fetch(`/api/sittings/${action}/${sittingId}`, {
            method: 'post',
            body: JSON.stringify(sittingId)
        }).then(response => {

            if (response.status == '200') {

                if (action == 'open') {
                    $(e.currentTarget).data('action', 'close');
                    $(e.currentTarget).removeClass('btn-danger');
                    $(e.currentTarget).addClass('btn-success');
                    $(e.currentTarget).val('Open');
                }
                else {
                    $(e.currentTarget).data('action', 'open');
                    $(e.currentTarget).removeClass('btn-success');
                    $(e.currentTarget).addClass('btn-danger');
                    $(e.currentTarget).val('Closed');
                }
            }
            else {
                alert('oops, something went wrong :(');
            }
        }).catch(function (error) {
            console.log(error);
        });
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
function addSourceOptions(data, select) {
    let list = document.getElementById(select);
    for (let i = 0; i < data.length; i++) {
        let option = data[i];        
        let el = document.createElement("option");
        el.text = option.description;
        el.value = option.id;
        list.appendChild(el);
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


