$(document).on("pagecreate", "#addEmp", function () {
    //add button clicked
    console.log("saving employee name");
    $("#saveEmployee").on("click", function () {
        var settings = {
            "async": true,
            "crossDomain": true,
            "url": api+"Employee/AddEmployee",
            "method": "POST",
            "headers": {
                "content-type": "application/x-www-form-urlencoded"
            },
            "data": {
                "empFirstName": $("#fname").val(),
                "empLastName": $("#lanme").val(),
                "empDesignation": $("#designation").val(),
                "empLatLong": $("#latlong").val(),
                "empPassword": $("#empPassword").val()
            },
            "error": function () {
                alert("There is an error");
            }
        }
        $.ajax(settings).done(function (response) {
            console.log(response);
            //give message
            alert("record added succefully.");

            //redirect to list page
            $.mobile.pageContainer.pagecontainer("change", "#listEmp");
        })
    })
})
$(document).on("pageshow", "#addEmp", function () {
    var onSuccess = function (position) {
        $("#latlong").val(position.coords.latitude + "," + position.coords.longitude);        
    };

    // onError Callback receives a PositionError object
    function onError(error) {
        alert('code: ' + error.code + '\n' +
              'message: ' + error.message + '\n');
    }
    navigator.geolocation.getCurrentPosition(onSuccess, onError);
})