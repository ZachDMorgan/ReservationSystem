$(() => {
    const createStart = flatpickr("#StartTime", {
        enableTime: true,
        dateFormat: "d-m-Y H:i",
        minDate: "today",
        maxDate: new Date().fp_incr(90),
        altInput: true,
        altFormat: "F j, Y h:i K",

    });

    const createEnd = flatpickr("#EndTime", {
        enableTime: true,
        dateFormat: "d-m-Y H:i",
        minDate: "today",
        maxDate: new Date().fp_incr(90),
        altInput: true,
        altFormat: "F j, Y h:i K",
    });

    createStart.config.onClose = [() => {
        setTimeout(() => createEnd.open(), 1);
    }]
    createStart.config.onChange = [(selectedDates) => {
        createEnd.set("defaultDate", selectedDates[0]);
        createEnd.set("minDate", selectedDates[0]);
    }];
    
    $(".customSittingType").hide();

    $("#createSittingModal #SittingTypeId").change(() => {
        if ($("#createSittingModal #SittingTypeId").children("option:selected").val() == -1) {
            $("#createSittingModal .customSittingType").show();
        }
        else {
            $("#createSittingModal .customSittingType").hide();
        }
    });
    $("#editSittingModal #EditSittingTypeId").change(() => {
        if ($("#editSittingModal #EditSittingTypeId").children("option:selected").val() == -1) {
            $("#editSittingModal .customSittingType").show();
        }
        else {
            $("#editSittingModal .customSittingType").hide();
        }
    });

    $(".manageSittingType").click(() => {
        fetch('/api/sittingTypes/getAllSittingTypes/')
            .then((resp) => resp.json())
            .then(function (data) {

                //fill the manage sitting types modal
                addSittingTypes(data);
                addEvents(document.getElementsByClassName("btn-stManager").length);

            }) //handle errors
            .catch(function (error) {
                console.log(error);
            });
    });

    $("#OpenCheckbox").click(() => {
        let open = $("#Open");
        if (open.val()) {
            open.val(false)
        }
        else {
            open.val(true)
        }
    });


    function getSittingTypes() {
        fetch('/api/sittingTypes/getSittingTypes/')
            .then((resp) => resp.json())
            .then(function (data) {

                //add the dates to the select list
                addSittingTypeOptions(data, "SittingTypeId");
            }) //handle errors
            .catch(function (error) {
                console.log(error);
            });
    }

    $(".createSitting").click(() => {
        removeOptions("SittingTypeId");
        getSittingTypes();
    });

    $(".editSitting").click((e) => {
        removeOptions("SittingTypeId");
        getSittingTypes();
        fetch(`/api/sittings/getSitting/${$(e.currentTarget).data('id')}`)
            .then((resp) => resp.json())
            .then(function (data) {
                const editStart = flatpickr("#EditStartTime", {
                    enableTime: true,
                    dateFormat: "d-m-Y H:i",
                    minDate: "today",
                    maxDate: new Date().fp_incr(90),
                    altInput: true,
                    altFormat: "F j, Y h:i K",
                    defaultDate: new Date(data.startTime)
                });

                const editEnd = flatpickr("#EditEndTime", {
                    enableTime: true,
                    dateFormat: "d-m-Y H:i",
                    minDate: "today",
                    maxDate: new Date().fp_incr(90),
                    altInput: true,
                    altFormat: "F j, Y h:i K",
                    defaultDate: new Date(data.endTime)
                });
        editStart.config.onClose = [() => {
            setTimeout(() => editEnd.open(), 1);
        }]
        editStart.config.onChange = [(selectedDates) => {
            editEnd.set("minDate", selectedDates[0]);
        }];

                $("#editSittingModal #EditSittingTypeId").val(data.sittingTypeId);
                $("#editSittingModal #EditCapacity").val(data.capacity);
                $("#editSittingModal #EditId").val($(e.currentTarget).data('id'));
            }) //handle errors
            .catch(function (error) {
                console.log(error);
            });

    })

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
})



///// functions to manipulate elements

// function to remove options from a selectlist
function removeOptions(select) {
    let list = document.getElementsByClassName(select);
    for (var j = 0; j < list.length; j++) {
        for (let i = list[j].options.length; i > 1; i--) {
            list[j].remove(i);
        }
    }

}

// function to add date options to a selectlist
function addSittingTypeOptions(data, select) {
    let list = document.getElementsByClassName(select);
    for (let i = 0; i < data.length; i++) {
        for (var j = 0; j < list.length; j++) {
            let option = data[i];
            let el = document.createElement("option");
            el.text = option.description;
            el.value = option.id;
            list[j].appendChild(el);
        }

    }
}

// function to add sitting types to modal
function addSittingTypes(data) {
    let wrapper = document.createElement("div");
    wrapper.className = "container"
    for (let i = 0; i < data.length; i++) {
        console.log(data);
        let rowWrapper = document.createElement("div");
        rowWrapper.className = "row m-1";
        let label = document.createElement("div");
        label.className = "col-6";
        label.innerHTML = data[i].description;
        let button = document.createElement("input");
        button.type = "button";
        button.className = `btn-stManager btn-stManager-${i} btn btn-${data[i].active ? "success" : "danger"} col`;
        button.dataset.id = data[i].id;
        button.dataset.action = `${data[i].active ? "activate" : "deactivate"}`;
        button.value = `${data[i].active ? "Active" : "Deactive"}`;

        rowWrapper.appendChild(label);
        rowWrapper.appendChild(button);
        wrapper.appendChild(rowWrapper);
    }
    $("#editSittingTypesModal .modal-body").html(wrapper);
}

function addEvents(len) {
    for (var i = 0; i < len; i++) {
        $(`.btn-stManager-${i}`).click((e) => {

            let id = $(e.currentTarget).data('id');
            let action = $(e.currentTarget).data('action');

            fetch(`/api/sittingTypes/${action}/${id}`, {
                method: 'post',
                body: JSON.stringify(id)
            }).then(response => {
                if (response.status == '200') {

                    if (action == 'activate') {
                        $(e.currentTarget).data('action', 'deactivate');
                        $(e.currentTarget).removeClass('btn-danger');
                        $(e.currentTarget).addClass('btn-success');
                        $(e.currentTarget).val('Active');
                    }
                    else {
                        $(e.currentTarget).data('action', 'activate');
                        $(e.currentTarget).removeClass('btn-success');
                        $(e.currentTarget).addClass('btn-danger');
                        $(e.currentTarget).val('Deactive');
                    }
                }
                else {
                    alert('oops, something went wrong :(');
                }
            }).catch(function (error) {
                console.log(error);
            });

        });
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

function validateAll(form) {
    var type = document.getElementById("SittingTypeId").value;
    var customType = document.getElementById("CustomSittingType").value;
    if (type === "-1" && customType ==="" ) {
        document.getElementById("formErrorMessage").innerText = "should not leave empty";
        return false;
    }
    var capacity = document.getElementById("Capacity").value;
    if (capacity < 1 || capacity > 40 || capacity === "") {
        document.getElementById("formErrorMessage").innerText = "Capacity has to be more than 0 but less than 41";
        return false;
    }
    var startTime = document.getElementById("StartTime").value;
    var endTime = document.getElementById("EndTime").value;
    if (startTime === "" || endTime === "") {
        document.getElementById("formErrorMessage").innerText = "Start time or end time cannot be empty";
        return false;
    }
    
    if (!type) {
        document.getElementById("formErrorMessage").innerText = "Please pick a sitting type";
        return false;
    }
    
    document.getElementById("formErrorMessage").innerText = "";
    return true;
}

