$(() => {


        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    ///// event listeners


    // event listener so when add table is clicked, modal value is id value
    //$(".createTable").click(() => {
    //    debugger;
    //    // make sure user can't trick us with null value after choosing a correct one 
    //    let areaId = $(this).data("id");
    //    console.log(areaId)
    //    debugger;
    //    $(".modal-body #AreaId").val(areaId);

    //});


})

//fetch appropriate data from db and fill selectlist
function GetStatusesToModal(reservationId) {
    removeOptions("StatusId");
    $("#updateStatusModal #Id").val(reservationId);
    fetch(`/api/reservations/getStatus/${reservationId}`)
        .then((resp) => resp.json())
        .then(function (data) { 
            addStatusOptions(data, "StatusId")
        }) //handle errors
        .catch(function (error) {
            console.log(error);
        });
}

function GetTablesToModal(reservationId, sittingId) {
    removeOptions("TableId");
    $("#tableModal #ReservationId").val(reservationId);
    $("#tableModal #SittingId").val(sittingId);
    fetch(`/api/reservations/getTables/${reservationId}`)
        .then((resp) => resp.json())
        .then(function (data) {
            addTableOptions(data, "TableId")
        }) //handle errors
        .catch(function (error) {
            console.log(error);
        });
}

function GetEditTablesToModal(reservationId, tableId, sittingId) {
    $("#editTableModal #ReservationId").val(reservationId);
    $("#editTableModal #TableId").val(tableId);
    $("#editTableModal #SittingId").val(sittingId);
}


// function to remove options from a selectlist
function removeOptions(select) {
    let list = document.getElementById(select);
    for (let i = list.options.length; i >= 1; i--) {
        list.remove(i);
    }
}

// function to add status options to a selectlist
function addStatusOptions(data, select) {
    let list = document.getElementById(select);
    for (let i = 0; i < data.length; i++) {
        let option = data[i];
        let el = document.createElement("option");
        el.text = option.description;
        el.value = option.id;
        list.appendChild(el);
    }
}

// function to add table options to a selectlist
function addTableOptions(data, select) {
    let list = document.getElementById(select);
    for (let i = 0; i < data.length; i++) {
        let option = data[i];
        let el = document.createElement("option");
        el.text = `${option.name} - ${option.seats} seats`;
        el.value = option.id;
        list.appendChild(el);
    }
}




/// press button
/// clear modal
/// call api
/// get info depending on previously added tables if they exist - context
/// done

/// submit
/// MVC controller
/// refresh page

