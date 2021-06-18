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


function GetAreaIdToModal(areaId) {
    $("#createTableModal #AreaId").val(areaId * 1);
}
function GetTableIdToModal(tableId) {
    $("#editTableModal #Id").val(tableId * 1);
}

function GetEditModalValues(tableId) {
    const url = '/api/tables/getTable/' + tableId;
    // talk to api - GET
    fetch(url)
        .then((resp) => resp.json())
        .then(function (data) { // this is the data as array of JSON
            $("#editTableModal #Name").val("");
            $("#editTableModal #Seats").val("");
            $("#editTableModal #Name").val(data.name);
            $("#editTableModal #Seats").val(data.seats);
            $("#editTableModal #AreaId").val(data.areaId);
        }) //handle errors
        .catch(function (error) {
            console.log(error);
        });
}


///// functions to manipulate elements



