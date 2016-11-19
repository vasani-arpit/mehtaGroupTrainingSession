var api="http://localhost:12747/api/";
$(document).ready(function () {
    //code
    console.log("document is ready");
    $("#text").html("document is ready now.");

})

$(document).on("pagebeforecreate", "#fistpage", function () {
    console.log("page before create");
});
$(document).on("pagecreate", "#fistpage", function () {
    console.log("page created");
    $("#sharebtn").on("click", function () {
        window.plugins.socialsharing.share(localStorage["username"]);
    });
    $("#clickcme").on("click", function () {
        //onclick code
        console.log("user clicked");
        $("#text").html("you have clicked the button");
    })
});
$(document).on("pageshow", "#fistpage", function () {
    console.log("page shown");
});
$(document).on("pagebeforeshow", "#login", function () {
    console.log("page before show");
    //check if username and password is there.
    if (localStorage["username"] != undefined && localStorage["password"] != undefined) {
        $.mobile.pageContainer.pagecontainer("change", "#home", {
            transition: 'flow'
        });
    }
});
$(document).on("pageshow", "#login", function () {
    $("#username").val(localStorage["username"]);
    $("#username").hide();
    $("#secondtimePageUsername").html(localStorage["username"]);
    //$("#username").prev().hide();
    //$("#username").parent().parent().prepend("<h4>"+localStorage["username"]+"</h4>")
})
$(document).on("pagecreate", "#login", function () {
    $(".msg").hide();
    $("#loginbtn").on("click", function () {
        var username = $("#username").val();
        var password = $("#password").val();
        if (username == "admin" && password == "admin") {
            $(".msg").show();
            localStorage["username"] = username;
            localStorage["password"] = password;
            setTimeout(function () {
                $.mobile.pageContainer.pagecontainer("change", "#home", {
                    transition: 'flow'
                });
            }, 2000);
        } else {
            alert("Wrong Username and password");
        }
    });
});

$(document).on("pageshow", "#graph", function () {
    Morris.Line({
        element: 'line-example',
        data: [
          { y: '2006', a: 100, b: 90 },
          { y: '2007', a: 75, b: 65 },
          { y: '2008', a: 50, b: 40 },
          { y: '2009', a: 75, b: 65 },
          { y: '2010', a: 50, b: 40 },
          { y: '2011', a: 75, b: 65 },
          { y: '2012', a: 100, b: 90 }
        ],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Series A', 'Series B']
    });
})