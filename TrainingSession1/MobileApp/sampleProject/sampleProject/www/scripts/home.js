$(document).on("pagecreate", "#home", function () {
    $("#logoutbtn").on("click", function () {
        localStorage.removeItem("password");
        $.mobile.pageContainer.pagecontainer("change", "#login");
    })
});