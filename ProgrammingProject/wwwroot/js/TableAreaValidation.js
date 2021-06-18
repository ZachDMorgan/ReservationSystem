function ValidateTableName(helpText) {
    var tableName = $("#createTableModal #Name").val();
    if (tableName.length < 2) {
        helpText.innerHTML = "Table name should have at least 2 characters.";
        return false;
    }
    else {
        helpText.innerHTML = "";
        return true;
    }
}
function ValidateNumberOfSeat(helpText) {
    var numberOfSeat = document.getElementById("Seats").value;
    if (numberOfSeat < 1) {
        helpText.innerHTML = "Seats must seat at least 1 person.";
        return false;
    }
    else {
        helpText.innerHTML = "";
        return true;
    }
}
function ValidateAreaName(name) {
    var areaName = document.getElementById("Name").value;
    if (areaName.length < 3) {
        document.getElementById('AreaErrorMessage').innerText = "Area names should have at least 2 characters.";
        return false;
    }
    document.getElementById('AreaErrorMessage').innerText = "";
    return true;
}




function checkTableNameAndSeat(form) {
    var tableName = $("#createTableModal #Name").val();
    if (tableName.length < 2) {
        document.getElementById('tableError').innerText = "table name should have at least 2 characters";
        return false;
    }
    var numberOfSeat = document.getElementById("Seats").value;
    if (numberOfSeat < 1 || numberOfSeat === "") {
        document.getElementById('tableError').innerText = "Seat number cannot be less than 0 or empty";
        return false;
    }
    document.getElementById('tableError').innerText = "";
    return true;
}
function EditCheckTableNameAndSeat(form) {
    var tableName = $("#editTableModal #Name").val();
    if (tableName.length < 2) {
        document.getElementById('editTableError').innerText = "table name should have at least 2 characters";
        return false;
    }
    var numberOfSeat = $("#editTableModal #Seats").val();
    if (numberOfSeat < 1 || numberOfSeat === "") {
        document.getElementById('editTableError').innerText = "Seat number cannot be 0 or empty";
        return false;
    }
    document.getElementById('editTableError').innerText = "";
    return true;
}

