$(document).on("pagecreate", "#camera", function () {

    $("#cameraCapture").on("click", function () {
        navigator.camera.getPicture(onSuccess, onFail, null);

        function onSuccess(imageURI) {
            $("#photo").attr("src", imageURI);
            console.log("Camera cleanup success.")
        }

        function onFail(message) {
            alert('Failed because: ' + message);
        }
    })
})