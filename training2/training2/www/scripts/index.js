$(document).ready(function () {
    //global code block.
})

function myFunction() {
    alert("fun called");
}

function loginbtnClik() {
    console.log("button clicked");
    var username = $("#username").val();
    var password = $("#password").val();
    console.log(username);
    console.log(password);

    if (username == "admin" && password == "admin") {
        //            alert("Login Success");
        $.mobile.pageContainer.pagecontainer("change", "#welcome", {
            transition: "slide"
        });
    } else {
        alert("Login Failed");
    }
}

function loginPageCreate() {
    //page created
    console.log("Page has been created");
    $("#loginbtn").on("click", loginbtnClik);
}

$(document).on("pagecreate", "#login", loginPageCreate);

$(document).on("pageshow", "#login", function () {
    //page created
    console.log("Page has been shown");
})


function employeeList() {
    //console.log("Page is shown");
    $("#empListview").html("");
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "http://192.168.8.137:57545/api/Employee/GetEmployee",
        "method": "GET",
        "headers": {
            "cache-control": "no-cache"
        }
    }

    $.ajax(settings).done(function (response) {
        console.log(response);
        var i;
        for (i = 0; i < response.Table.length; i++) {
            console.log(response.Table[i].EmpDesignation);
            $("#empListview").append("<li><a href='#'><h2>" + response.Table[i].EmpFirstName + " " + response.Table[i].EmpLastName + "</h2><p>Broken Bells</p></a></li>")
        }
        $("#empListview").listview("refresh");
    }).fail(function () {
        alert("There was an error.");
    });

}

$(document).on("pageshow", "#empList", employeeList)

function addEmpbtnclick() {
    //send values to server
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "http://192.168.8.137:57545/api/Employee/InsertEmployee",
        "method": "POST",
        "headers": {
            "content-type": "application/x-www-form-urlencoded",
            "cache-control": "no-cache",
        },
        "data": {
            "EmpFirstName": $("#faname").val(),
            "EmpLastName": $("#lname").val(),
            "EmpDesignation": $("#designation").val(),
            "LatLong": $("#location").val(),
            "Password": $("#txtpassword").val()
        }
    }

    $.ajax(settings).done(function (response) {
        console.log(response.isSaved);
        if (response.isSaved == "-1") {
            alert("User already exists");
        }
    }).fail(function () {
        alert("server error");
    });
}
function addEmployee() {
    $("#addEmpbtn").on("click", addEmpbtnclick);
    function cameraClick() {
        navigator.camera.getPicture(onSuccess, onFail, null);

        function onSuccess(imageURI) {
            //var image = document.getElementById('myImage');
            //image.src = imageURI;
            alert("image captured");
            $("#empImage").attr("src", imageURI);
        }

        function onFail(message) {
            alert('Failed because: ' + message);
        }
    }

    $("#captureImage").on("click", cameraClick);

}
$(document).on("pagecreate", "#addEmployee", addEmployee);

function addEmployeeShown() {
    //page is shown
    $("#designation").blur(function () {
        var onSuccess = function (position) {
            $("#location").val(position.coords.latitude + " " + position.coords.longitude);
        };

        // onError Callback receives a PositionError object
        //
        function onError(error) {
            alert('code: ' + error.code + '\n' +
                  'message: ' + error.message + '\n');
        }
        navigator.geolocation.getCurrentPosition(onSuccess, onError);
    })
}
$(document).on("pageshow", "#addEmployee", addEmployeeShown);