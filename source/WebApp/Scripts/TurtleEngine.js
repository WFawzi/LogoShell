$(document).ready(function () {

    var c = document.getElementById("logoCanvas");
    var ctx = c.getContext("2d");
    ctx.lineWidth = 2;
    ctx.moveTo(0, 0);
    ctx.lineTo(50, 150);
    ctx.stroke();
});


function SendScript() {
    
    //var formData = { name: "ravi", age: "31" }; //Json


    var userScript = document.getElementById("codeEditor").textContent;
    var formData = {
        userScript: userScript,
        direction: 0,
        x: 0,
        y: 0
    }; //always use ";" in JS
 


    $.ajax({
        url: "/Turtle/Draw",
        type: "POST",
        data : formData,
        success: function(data, textStatus, jqXHR)
        {
            //data - response from server
            debugger;
        },
        error: function (jqXHR, textStatus, errorThrown)
        {
 
        }
    });
}