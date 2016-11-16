$(document).on("pageshow", "#listEmp", function () {
    console.log("emp page shown");
    $.ajax({
        url: api+"Employee/GetEmployee",
        method: "GET",
        beforeSend: function () {
            $.mobile.loading('show');
        },
        complete: function () {
            $.mobile.loading('hide');
        },
        success: function (data) {
            console.log(data);
            console.log(data[0][0].EmpFirstName);
            $("#empListView").html("");
            $(data[0]).each(function (k, item) {
                $("#empListView").append('<li><a href="#"><h2>' + item.EmpFirstName + ' ' + item.EmpLastName + '</h2><p>' + item.EmpDesignation + '</p></a></li>');
            })
            $("#empListView").listview('refresh');
        },
        error: function (errorObj, errorStatus, errorMessage) {
            console.log(errorObj, errorStatus, errorMessage);
            alert("Error in commubicating with servcer");
        }
    });
})